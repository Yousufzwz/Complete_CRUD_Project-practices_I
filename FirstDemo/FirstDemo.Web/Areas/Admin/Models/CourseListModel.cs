using FirstDemo.Application.Features.Training.Services;
using FirstDemo.Infrastructure;
using System.Web;

namespace FirstDemo.Web.Areas.Admin.Models;

public class CourseListModel
{
    private ICourseManagementService _courseManagementService;

    public CourseListModel() { }

    public CourseListModel(ICourseManagementService courseManagementService)
    {
        _courseManagementService = courseManagementService;
    }

    public async Task<object> GetDataOfCoursesAsync(DataTablesAjaxRequestUtility dataTablesInfo)
    {
        var data = await _courseManagementService.GetDataOfCoursesAsync(
            dataTablesInfo.PageIndex,
            dataTablesInfo.PageSize,
            dataTablesInfo.SearchText,
            dataTablesInfo.GetSortText(new string[] { "Title", "Description", "Fees" }));

        return new
        {
            recordsTotal = data.total,
            recordsFiltered = data.totalDisplay,
            data = (from record in data.records
                    select new string[]
                    {
                        HttpUtility.HtmlEncode(record.Title),
                        HttpUtility.HtmlEncode(record.Description),
                        record.Fees.ToString(),
                        record.Id.ToString(),
                    }
                    ).ToArray()

        };
    }
}
