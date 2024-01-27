using Autofac;
using AutoMapper;
using FirstDemo.Application.Features.Training.Services;
using FirstDemo.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace FirstDemo.Web.Areas.Admin.Models;

public class CourseUpdateModel
{
    private ICourseManagementService _courseService;
    private IMapper _mapper;

    [Required]
    public Guid Id { get; set; }

    [Required]
    public string Title{ get; set; }
    public string Description { get; set; }
    public uint Fees { get; set; }

    public CourseUpdateModel() { }  

    public CourseUpdateModel(ICourseManagementService courseService, IMapper mapper)
    {
        _courseService = courseService;
        _mapper = mapper;
    }

    public void Resolve(ILifetimeScope scope)
    {
        _courseService = scope.Resolve<ICourseManagementService>();
        _mapper = scope.Resolve<IMapper>();
    }

    public async Task UpdateAsync(Guid id)
    {
        Course course = await _courseService.GetCourseAsync(id);
        if (course != null)
        {
            _mapper.Map(course, this);
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
