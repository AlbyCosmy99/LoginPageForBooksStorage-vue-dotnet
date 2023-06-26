using Autofac;
using loginPage_v1.Services;
using System.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;

namespace loginPage_v1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        { 
            config.MapHttpAttributeRoutes();

            var corsConfig = new EnableCorsAttribute(ConfigurationManager.AppSettings["corsEnabledOrigins"], "*", "*");
            config.EnableCors(corsConfig);

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
