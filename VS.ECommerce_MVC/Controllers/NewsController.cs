using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Services;
using MoreAll;
using System.Net;

namespace VS.ECommerce_MVC.Controllers
{
    public class NewsController : Controller
    {
        DatalinqDataContext db = new DatalinqDataContext();
        private string language = Captionlanguage.SetLanguage();
        public ActionResult Index()
        {
            int Tongsobanghi = 0;
            Int16 pages = 1;
            int Tongsotrang = int.Parse(Commond.Setting("pagenews"));

            if ((Request.QueryString["page"] != null) && (Request.QueryString["page"] != ""))
            {
                pages = Convert.ToInt16(Request.QueryString["page"].Trim());
            }
            List<Entity.Category_News> dt = SNews.News_All(language, "1", (pages - 1), ref Tongsobanghi, Tongsotrang);
            if (dt.Count >= 1)
            {
                ViewBag.ShowList = Commond.LoadNewsList(dt, language);
            }
            else
            {
                ViewBag.ShowList = "<div class='Checkdata'>" + Commond.label("I_dulieuchuadccapnhat") + "</div>";
            }
            if (Tongsobanghi % Tongsotrang > 0)
            {
                Tongsobanghi = (Tongsobanghi / Tongsotrang) + 1;
            }
            else
            {
                Tongsobanghi = Tongsobanghi / Tongsotrang;
            }
            ViewBag.Phantrang = Commond.Phantrang("/tin-tuc-new.html", Tongsobanghi, pages);
            return View();
        }

        public ActionResult Category(string hp)
        {
            if (hp == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            #region Menu
            Menu table = db.Menus.SingleOrDefault(p => p.ID == int.Parse(More.TangNameicid(hp)));
            if (table == null)
            {
                Commond.Link301();
            }
            else if (table != null)
            {
                ViewBag.Name = table.Name.ToString();
            }
            #endregion

            int Tongsobanghi = 0;
            Int16 pages = 1;
            int Tongsotrang = int.Parse(Commond.Setting("pagenews"));

            if ((Request.QueryString["page"] != null) && (Request.QueryString["page"] != ""))
            {
                pages = Convert.ToInt16(Request.QueryString["page"].Trim());
            }
            List<Entity.Category_News> dt = SNews.CATEGORY_PHANTRANG(More.Sub_Menu(More.NS, More.TangNameicid(hp)), language, "1", (pages - 1), ref Tongsobanghi, Tongsotrang);
            if (dt.Count >= 1)
            {
                ViewBag.ShowList = Commond.LoadNewsList(dt, language);
            }
            else
            {
                ViewBag.ShowList = "<div class='Checkdata'>" + Commond.label("I_dulieuchuadccapnhat") + "</div>";
            }
            if (Tongsobanghi % Tongsotrang > 0)
            {
                Tongsobanghi = (Tongsobanghi / Tongsotrang) + 1;
            }
            else
            {
                Tongsobanghi = Tongsobanghi / Tongsotrang;
            }
            ViewBag.Phantrang = Commond.Phantrang("/danh-muc-tin/" + hp + ".html", Tongsobanghi, pages);
            return View();
        }

        public ActionResult Detail(string hp)
        {
            if (hp == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var dt = SQLNews.Detail(hp);
            if (dt == null)
            {
                Commond.Link301();
            }
            else if (dt != null)
            {
                string nid = dt.inid.ToString();
                string cid = dt.icid.ToString();
                ViewBag.Name = Commond.Name(dt.icid.ToString());

                #region Facebook
                if (Commond.Setting("NFacebook").Equals("1"))
                {
                    ViewBag.Facebook = "<div class='fb-like' data-href='" + MoreAll.MoreAll.RequestUrl(Request.Url.ToString()) + "' data-send='true' data-width='450' data-show-faces='false'></div>";
                }
                if (Commond.Setting("NFacebook").Equals("2"))
                {
                    ViewBag.Facebook = "<div class='fb-like' data-href='" + MoreAll.MoreAll.RequestUrl(Request.Url.ToString()) + "' data-send='true' data-width='450' data-show-faces='true' data-font='arial'></div>";
                }
                #endregion

                #region Other
                var dt2 = SNews.OTHERFIRST(nid, int.Parse(Commond.Setting("newsother")), language, cid);
                if (dt2.Count > 0)
                {
                    ViewBag.Other2 = dt2;
                }

                var dt1 = SNews.OTHERLAST(nid, int.Parse(Commond.Setting("newsother")), language, cid);
                if (dt1.Count > 0)
                {
                    ViewBag.Other1 = dt1;
                }

                #endregion

                #region views
                if (MoreAll.MoreAll.GetCookies("views").Equals("") || !MoreAll.MoreAll.GetCookies("views").Equals(nid))
                {
                    SNews.UPDATEVIEWS_TIMES(nid);
                    MoreAll.MoreAll.SetCookie("views", nid);
                }
                #endregion
            }
            return View(dt);
        }

    }
}