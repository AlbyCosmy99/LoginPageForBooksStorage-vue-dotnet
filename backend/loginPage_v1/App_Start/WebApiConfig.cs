using Autofac;
using loginPage_v1.Services;
using System.Web.Http;

namespace loginPage_v1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var builder = new ContainerBuilder();
            //register instance se pageContext avesse dei parametri che io voglio configurare
            //Builder.RegisterInstance(new PageContext()).AsSelf();
            builder.RegisterType<PageContext.Ctx>();
            builder.RegisterType<LoginsService>();
            //builder.RegisterType<LoginsService>().As<ILoginsService>().InstancePerLifetimeScope();

            //Builder.RegisterInstance(new UsersServices(new PageContext())).AsSelf();
            builder.Build();
        }
    }
}
