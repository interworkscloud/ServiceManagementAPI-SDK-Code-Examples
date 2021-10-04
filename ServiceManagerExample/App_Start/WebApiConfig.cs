using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ServiceManagerExample
{
    using Interworks = Interworks.Cloud.ServiceManagersSDK.Libraries.Filters;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Filters.Add(new Interworks.AuthorizationAttribute());
            config.Filters.Add(new Interworks.NoAccessActionFilterAttribute());
            config.Filters.Add(new Interworks.LogExceptionFilterAtribute());
            config.Filters.Add(new Interworks.ActionNameActionFilterAttribute());
        }
    }
}
