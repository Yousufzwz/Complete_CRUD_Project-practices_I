namespace FirstDemo.Application.Features.Training.Services;

public interface ICourseManagementService
{
    Task CreateCourseAsync(string title, string description, uint fees);
}