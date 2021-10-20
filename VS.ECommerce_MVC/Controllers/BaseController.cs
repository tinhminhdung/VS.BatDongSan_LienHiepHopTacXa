using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VS.ECommerce_MVC.Controllers
{
    public class BaseController : Controller
    {
        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-danger";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-warning";
            }
        }
        public static string AlertMessage(string message, string type)
        {
            if (type == "success")
            {
                return "<div class=\"alert alert-success\">" + message + "</div>";
            }
            else if (type == "warning")
            {
                return "<div class=\"alert alert-danger\">" + message + "</div>";
            }
            else if (type == "error")
            {
                return "<div class=\"alert alert-warning\">" + message + "</div>";
            }
            return "<div class=\"alert alert-warning\">" + message + "</div>";
        }


    }
}