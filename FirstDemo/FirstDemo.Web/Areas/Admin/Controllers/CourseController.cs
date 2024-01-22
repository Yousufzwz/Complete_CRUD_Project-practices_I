using Autofac;
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
            courseModel.Resolve(_scope);
            await courseModel.CreateCourseAsync();
            return RedirectToAction("Index");
        }

          return View(courseModel);
    }

    public async Task<JsonResult> GetCourses()
    {
        var dataTablesModel = new DataTablesAjaxRequestUtility(Request);
        var model = _scope.Resolve<CourseListModel>();

        var data = await model.GetDataOfCoursesAsync(dataTablesModel);
        return Json(data);
    }
}
