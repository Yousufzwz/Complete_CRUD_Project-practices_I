using FirstDemo.Application.Features.Training.DTOs;
using FirstDemo.Domain.Entities;

namespace FirstDemo.Application.Features.Training.Services;

public interface ICourseManagementService
{
    Task CreateCourseAsync(string title, string description, uint fees);

    Task<(IList<Course> records, int total, int totalDisplay)>
        GetDataOfCoursesAsync(int pageIndex, int pageSize, string searchTitle,
        uint searchFeesFrom, uint searchFeesTo, string sortBy);
    Task RemoveCourseAsync(Guid id);
    Task UpdateCourseAsync(Guid id, string title, string description, uint fees);
    Task<Course> GetCourseAsync(Guid id);
    Task<(IList<CourseEnrollmentDTO> records, int total, int totalDisplay)> GetCourseEnrollmentsAsync(
            int pageIndex, int pageSize, string orderBy,
            string courseName, string studentName, DateTime enrollmentDateFrom,
            DateTime enrollmentDateTo);
}