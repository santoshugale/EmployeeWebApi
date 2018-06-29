using System.Web.Http;
using System.Web.Http.Cors;
using EmployeeWebApi.Filters;
using System.Web.Http.ExceptionHandling;
using EmployeeWebApi.GlobalExceptionHandling;
using Unity;
using EmployeeWebApi.BusinessLogic;
using Unity.Lifetime;

namespace EmployeeWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //Enabling cross origin resource sharing 
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            //Adding exception filter
            config.Filters.Add(new NotImplExceptionFilterAttribute());

            //Global Exception handler
            //We have to replcae the IExceptionHandler as there can be only one global exception handler exist
            config.Services.Replace(typeof(IExceptionHandler), new OopsExceptionHandler());

            //Dependancy Injector
            var container = new UnityContainer();
            container.RegisterType<IEmployeeBuisnessLogic, EmployeeBuisnessLogic>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
