using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ProductCRUD.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // CORS via custom handler
            config.MessageHandlers.Add(new Handlers.CorsMessageHandler());

            // Rotas
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
