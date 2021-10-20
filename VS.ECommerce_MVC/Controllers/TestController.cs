using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VS.ECommerce_MVC.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/
        public ActionResult Payment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Payment(string shipName, string mobile, string address, string email)
        {
            string content = System.IO.File.ReadAllText(Server.MapPath("~/Views/Test/Order.html"));
            content = content.Replace("{{CustomerName}}", shipName);
            content = content.Replace("{{Phone}}", mobile);
            content = content.Replace("{{Email}}", email);
            content = content.Replace("{{Address}}", address);
            //content = content.Replace("{{Total}}", total.ToString("N0"));

            var toEmail = "nvietdung1109@gmail.com";

           // new MailHelper().SendMail(email, "Đơn hàng mới từ OnlineShop", content);
            new MailHelper().SendMail(toEmail, "Đơn hàng mới từ OnlineShop", content);

            return Redirect("/Test");
        }
    }
}