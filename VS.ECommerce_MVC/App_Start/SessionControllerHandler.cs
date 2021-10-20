using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.WebHost;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

// khai báo class này thêm để chạy được Session trong API
public class SessionControllerHandler : HttpControllerHandler, IRequiresSessionState
{
    public SessionControllerHandler(RouteData routeData)
        : base(routeData)
    { }
}

public class SessionHttpControllerRouteHandler : HttpControllerRouteHandler
{
    protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
    {
        return new SessionControllerHandler(requestContext.RouteData);
    }
}