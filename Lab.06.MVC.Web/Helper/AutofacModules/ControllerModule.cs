using Autofac;
using Lab._06.MVC.Web.Controllers;

namespace Lab._06.MVC.Web.Helper.AutofacModules
{
    public class ControllerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AccountController>().InstancePerRequest();
            builder.RegisterType<MovieController>().InstancePerRequest();
            builder.RegisterType<CommentsController>().InstancePerDependency();
            base.Load(builder);
        }
    }
}