using System.Web;
using Autofac;
using Lab._06.MVC.Web.Models;
using Microsoft.Owin.Security;

namespace Lab._06.MVC.Web.Helper.AutofacModules
{
    public class HelpersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MapperWeb>().AsSelf().InstancePerDependency();
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).As<IAuthenticationManager>();
            base.Load(builder);
        }
    }
}