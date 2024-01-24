using Autofac;
using FirstDemo.Web.Areas.Admin.Models;

namespace FirstDemo.Web;

public class WebModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CourseCreateModel>().AsSelf();
        builder.RegisterType<CourseListModel>().AsSelf();
        builder.RegisterType<CourseUpdateModel>().AsSelf(); 
    }
}  
