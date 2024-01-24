using Autofac;
using FirstDemo.Application.Features.Training.Services;
using FirstDemo.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace FirstDemo.Web.Areas.Admin.Models;

public class CourseUpdateModel
{
    private ICourseManagementService _courseService;

    [Required]
    public Guid Id { get; set; }

    [Required]
    public string Title{ get; set; }
    public string Description { get; set; }
    public uint Fees { get; set; }

    public CourseUpdateModel() { }  

    public CourseUpdateModel(ICourseManagementService courseService)
    {
        _courseService = courseService;
    }

    public void Resolve(ILifetimeScope scope)
    {
        _courseService = scope.Resolve<ICourseManagementService>();
    }

    public async Task UpdateAsync(Guid id)
    {
        Course course = await _courseService.GetCourseAsync(id);
        if (course != null)
        {
            Id = course.Id;
            Title = course.Title;
            Description = course.Description;
            Fees = course.Fees;
        }
    }

    public async Task UpdateCourseAsync()
    {
        if(!string.IsNullOrWhiteSpace(Title)
            && Fees >= 0)
        {
            await _courseService.UpdateCourseAsync(Id, Title, Description, Fees);
        }
    }
}
