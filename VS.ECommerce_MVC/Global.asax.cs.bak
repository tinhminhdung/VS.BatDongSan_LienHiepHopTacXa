using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using TeduShop.Web.Mappings;

namespace VS.ECommerce_MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfiguration.Configure();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_BeginRequest()
        {

        }

        protected void Application_MapRequestHandler()
        {
        }

        protected void Application_PostMapRequestHandler()
        {
        }

        protected void Application_AcquireRequestState()
        {
        }

        protected void Application_PreRequestHandlerExecute()
        {
        }

        protected void Application_PostRequestHandlerExecute()
        {
        }

        protected void Application_EndRequest()
        {
        } 
    }
}
