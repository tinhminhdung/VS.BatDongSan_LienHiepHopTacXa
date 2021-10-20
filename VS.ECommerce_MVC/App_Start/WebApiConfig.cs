using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.WebHost;

namespace VS.ECommerce_MVC
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // khai báo thêm để chạy được Session trong API
            var httpControllerRouteHandler = typeof(HttpControllerRouteHandler).GetField("_instance",System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
            if (httpControllerRouteHandler != null)
            {
                httpControllerRouteHandler.SetValue(null,
                    new Lazy<HttpControllerRouteHandler>(() => new SessionHttpControllerRouteHandler(), true));
            }

            // chạy cái này nếu lỗi
            //Install-Package Microsoft.AspNet.WebApi.WebHost

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{action}/{id}",
            defaults: new { id = RouteParameter.Optional }
            );

            // cũ
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
