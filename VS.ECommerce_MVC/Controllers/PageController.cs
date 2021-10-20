using MoreAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace VS.ECommerce_MVC.Controllers
{
    public class PageController : Controller
    {
        DatalinqDataContext db = new DatalinqDataContext();
        private string language = Captionlanguage.SetLanguage();
        public ActionResult Index(string hp)
        {
            if (hp == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var dt = db.Menus.Where(s => s.TangName == hp && s.Lang == language).FirstOrDefault();
            if (dt == null)
            {
                Commond.Link301();
            }
            else if (dt != null)
            {
                ViewBag.Name = dt.Name;
                ViewBag.Description = dt.Description;
            }
            return View();
        }
        public ActionResult OnOff()
        {
            if (OnOffs.StatusOnOff().Equals("1"))
            {
                ViewBag.ltcontent = OnOffs.OnOff();
            }
            else if (OnOffs.StatusOnOff().Equals("0"))
            {
                Response.Redirect("/");
            }
            return PartialView();
        }
        public ActionResult Error()
        {
            // Tất cả các lỗi ngoài ý muốn sẽ đổ về đây
            Commond.Link301();
            return View();
        }
    }
}