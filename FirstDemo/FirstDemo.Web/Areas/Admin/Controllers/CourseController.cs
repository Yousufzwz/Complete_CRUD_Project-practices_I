using Autofac;
using FirstDemo.Domain.Exceptions;
using FirstDemo.Infrastructure;
using FirstDemo.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstDemo.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class CourseController : Controller
{
    private readonly ILifetimeScope _scope;
    private readonly ILogger<CourseController> _logger;

    public CourseController(ILifetimeScope scope,
        ILogger<CourseController> logger)
    {
        _scope = scope;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        var model = _scope.Resolve<CourseCreateModel>();
        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CourseCreateModel courseModel)
    {
        if (ModelState.IsValid)
        {
            try
            {
                courseModel.Resolve(_scope);
                await courseModel.CreateCourseAsync();
                TempData.Put("ResponseMessage", new ResponseModel
                {
                    Message = "New course inserted successfully!",
                    Type = ResponseTypes.Success
                });
                return RedirectToAction("Index");
            }

            catch (DuplicateTitleException dte)
            {
                TempData.Put("ResponseMessage", new ResponseModel
                {
                    Message = dte.Message,
                    Type = ResponseTypes.Danger
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Server Error");
                TempData.Put("ResponseMessage", new ResponseModel
                {
                    Message = "Failed to insert a course!",
                    Type = ResponseTypes.Danger
                });
            }

        }

        return View(courseModel);
    }

    [HttpPost]
    public async Task<JsonResult> GetCourses(CourseListModel model)
    {
        var dataTablesModel = new DataTablesAjaxRequestUtility(Request);
        model.Resolve(_scope);

        var data = await model.GetPagedCoursesAsync(dataTablesModel);
        return Json(data);
    }


    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id)
    {
        var courseModel = _scope.Resolve<CourseListModel>();

        if (ModelState.IsValid)
        {
            try
            {
                await courseModel.RemoveCourseAsync(id);
                TempData.Put("ResponseMessage", new ResponseModel
                {
                    Message = "Course successfully removed!",
                    Type = ResponseTypes.Success
                });

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Server Error");

                TempData.Put("ResponseMessage", new ResponseModel
                {
                    Message = "Failed to removed a course!",
                    Type = ResponseTypes.Danger
                });
            }
        }

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Update(Guid id)
    {
        var courseModel = _scope.Resolve<CourseUpdateModel>();
        await courseModel.UpdateAsync(id);
        return View(courseModel);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(CourseUpdateModel courseUpdateModel)
    {
        courseUpdateModel.Resolve(_scope);

        if (ModelState.IsValid)
        {
            try
            {
                await courseUpdateModel.UpdateCourseAsync();
                TempData.Put("ResponseMessage", new ResponseModel
                {
                    Message = "Course successfully updated!",
                    Type = ResponseTypes.Success
                });

                return RedirectToAction("Index");

            }
            catch (DuplicateTitleException dte)
            {
                TempData.Put("ResponseMessage", new ResponseModel
                {
                    Message = dte.Message,
                    Type = ResponseTypes.Danger
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Server Error");

                TempData.Put("ResponseMessage", new ResponseModel
                {
                    Message = "Failed to update a course!",
                    Type = ResponseTypes.Danger
                });
            }

        }
        return View(courseUpdateModel);
    }
}

