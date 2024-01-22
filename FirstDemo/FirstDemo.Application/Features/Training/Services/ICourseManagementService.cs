using FirstDemo.Domain.Entities;

namespace FirstDemo.Application.Features.Training.Services;

public interface ICourseManagementService
{
    Task CreateCourseAsync(string title, string description, uint fees);

    Task<(IList<Course> records, int total, int totalDisplay)>
        GetDataOfCoursesAsync(int pageIndex, int pageSize, string searchText, string sortBy);

    Task RemoveCourseAsync(Guid id);
}