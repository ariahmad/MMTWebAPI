using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CustomerOrderWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

          
            // This next line could stay if you want xml formatting
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.Filters.Add(new Models.NotImplExceptionFilterAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
               name: "CustomerWebApi",
               routeTemplate: "api/{controller}/{customerId}/{email}",
               defaults: new { customerId = RouteParameter.Optional, email = RouteParameter.Optional }
           );

        }
    }
}
