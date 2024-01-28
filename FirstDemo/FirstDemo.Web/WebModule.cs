using Autofac;
using FirstDemo.Web.Areas.Admin.Models;
using FirstDemo.Web.Models;

namespace FirstDemo.Web;

public class WebModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CourseCreateModel>().AsSelf();
        builder.RegisterType<CourseListModel>().AsSelf();
        builder.RegisterType<CourseUpdateModel>().AsSelf(); 
        builder.RegisterType<RegistrationModel>().AsSelf();
    }
}  
