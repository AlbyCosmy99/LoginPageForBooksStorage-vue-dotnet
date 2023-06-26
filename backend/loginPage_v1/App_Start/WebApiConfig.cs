using Autofac;
using AutoMapper;
using loginPage_v1.App_Start;
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
            
            builder.RegisterType<PageContext.Ctx>().InstancePerLifetimeScope();
            builder.RegisterType<LoginsService>().InstancePerLifetimeScope();

            builder.Build();

            //register instance se pageContext avesse dei parametri che io voglio configurare
            //Builder.RegisterInstance(new PageContext()).AsSelf();

            //builder.RegisterInstance(AutomapperConfig.CreateMapper()).As<IMapper>().SingleInstance();
            //Builder.RegisterInstance(new UsersServices(new PageContext())).AsSelf();
        }
    }
}
