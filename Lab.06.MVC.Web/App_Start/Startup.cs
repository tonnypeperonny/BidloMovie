using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using Autofac;
using Autofac.Integration.Mvc;
using Lab._06.MVC.Web.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(Lab._06.MVC.Web.Startup))]
namespace Lab._06.MVC.Web
{
    public class Startup
    {
        private readonly Ioc.Autofac iocbuilder = new Ioc.Autofac();
        public void Configuration(IAppBuilder app)
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var builder = iocbuilder.ConfigureContainer();
            builder.RegisterType<AccountController>().InstancePerRequest();
            builder.RegisterType<MovieController>().InstancePerRequest();
            builder.RegisterType<CommentsController>().InstancePerDependency();
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).As<IAuthenticationManager>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }
}