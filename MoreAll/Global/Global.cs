using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Web.UI;

public class Global : HttpApplication
{
    protected void Application_AuthenticateRequest(object sender, EventArgs e)
    {
    }
    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        //HttpApplication app = (HttpApplication)sender;
        //string acceptEncoding = app.Request.Headers["Accept-Encoding"];
        //System.IO.Stream prevUncompressedStream = app.Response.Filter;
        //if (acceptEncoding == null || acceptEncoding.Length == 0)
        //    return;
        //acceptEncoding = acceptEncoding.ToLower();
        //if (acceptEncoding.Contains("gzip"))
        //{
        //    // gzip
        //    app.Response.Filter = new System.IO.Compression.GZipStream(prevUncompressedStream,
        //        System.IO.Compression.CompressionMode.Compress);
        //    app.Response.AppendHeader("Content-Encoding", "gzip");
        //}
        //else if (acceptEncoding.Contains("deflate"))
        //{
        //    // defalte
        //    app.Response.Filter = new System.IO.Compression.DeflateStream(prevUncompressedStream,
        //        System.IO.Compression.CompressionMode.Compress);
        //    app.Response.AppendHeader("Content-Encoding", "deflate");
        //}
    }

    protected void Application_End(object sender, EventArgs e)
    {

    }

    protected void Application_EndRequest(object sender, EventArgs e)
    {
    }

    protected void Application_Error(object sender, EventArgs e)
    {
    }

    protected void Application_Start(object sender, EventArgs e)
    {
        base.Application["UserOnline"] = 0;
    }

    protected void Session_End(object sender, EventArgs e)
    {
        base.Application.Lock();
        base.Application["UserOnline"] = ((int)base.Application["UserOnline"]) - 1;
        base.Application.UnLock();
    }

    protected void Session_Start(object sender, EventArgs e)
    {
        if (base.Application["UserOnline"] != null)
        {
            base.Application.Lock();
            base.Application["UserOnline"] = ((int)base.Application["UserOnline"]) + 1;
            base.Application.UnLock();
        }
        else
        {
            base.Application["UserOnline"] = 0;
        }
    }
    protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
    {
        HttpCompress((HttpApplication)sender);
    }
    private void HttpCompress(HttpApplication app)
    {
        //string acceptEncoding = app.Request.Headers["Accept-Encoding"];
        //Stream prevUncompressedStream = app.Response.Filter;
        //if (!(app.Context.CurrentHandler is Page) ||
        //    app.Request["HTTP_X_MICROSOFTAJAX"] != null)
        //    return;
        //if (string.IsNullOrEmpty(acceptEncoding))
        //    return;
        //acceptEncoding = acceptEncoding.ToLower();
        //if ((acceptEncoding.Contains("deflate") || acceptEncoding == "*") && CompressScript(Request.ServerVariables["SCRIPT_NAME"]))
        //{
        //    app.Response.Filter = new DeflateStream(prevUncompressedStream, CompressionMode.Compress);
        //    app.Response.AppendHeader("Content-Encoding", "deflate");
        //}
        //else if (acceptEncoding.Contains("gzip") && CompressScript(Request.ServerVariables["SCRIPT_NAME"]))
        //{
        //    app.Response.Filter = new GZipStream(prevUncompressedStream, CompressionMode.Compress);
        //    app.Response.AppendHeader("Content-Encoding", "gzip");
        //}
    }
    private static bool CompressScript(string scriptName)
    {
        if (scriptName.ToLower().Contains(".axd")) return false;
        return true;
    }
}
