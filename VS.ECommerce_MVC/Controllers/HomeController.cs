using Advertisings;
using MoreAll;
using OfficeOpenXml;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.IO;
using Vietdung.Common;
using System.Runtime.Caching;
using GHTK;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace VS.ECommerce_MVC.Controllers
{
    public class HomeController : Controller
    {
        DatalinqDataContext db = new DatalinqDataContext();
        private string language = Captionlanguage.SetLanguage();
        #region Index
        public ActionResult Index()
        {
            string link = "";
            #region Sét link giới thiệu
            if (Request["link"] != null && !Request["link"].Equals(""))
            {
                link = Request["link"].ToString();//lấy ID qua Request
                if (Request.RawUrl.Contains("?link="))
                {
                    Response.Redirect("/dang-ky.html?info=" + link + "");
                }
            }
            #endregion

            if (MoreAll.MoreAll.GetCookies("MembersID").ToString() != "")
            {
                Response.Redirect("/wallet.html");
            }
            else
            {
                Response.Redirect("/Dang-nhap.html");
            }

           // ViewBag.nhomsanpham = MoreAll.MoreAll.GetCache("ShowNhomsanpham", System.Web.HttpContext.Current.Cache["ShowNhomsanpham"] != null ? "" : ShowNhomsanpham());
            return View();
        }
   
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
        #endregion
      
    }
}