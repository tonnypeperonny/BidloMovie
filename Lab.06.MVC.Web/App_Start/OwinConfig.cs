using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Common;
using Lab._06.MVC.Web.Helper.AutofacModules;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(Lab._06.MVC.Web.OwinConfig))]
namespace Lab._06.MVC.Web
{
    public class OwinConfig
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = AutofacHelper.InitBuilder();
            builder.RegisterModule<ControllerModule>();
            builder.RegisterModule<HelpersModule>();
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