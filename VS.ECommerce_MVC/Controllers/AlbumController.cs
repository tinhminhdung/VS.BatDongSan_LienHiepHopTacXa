using MoreAll;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace VS.ECommerce_MVC.Controllers
{
    public class AlbumController : Controller
    {
        DatalinqDataContext db = new DatalinqDataContext();
        private string language = Captionlanguage.SetLanguage();

        #region Index
        public ActionResult Index()
        {
            ViewBag.ltshow = ShowListAlbum();
            return View();
        }
        protected string ShowListAlbum()
        {
            string str = "";
            List<Entity.MenuShow> dt = SMenu.Pages_Home(More.AB, language, "1");
            if (dt.Count > 0)
            {
                foreach (Entity.MenuShow item in dt)
                {
                    str += "<div class=\"nhomnhe\">";
                    str += "<h2 class=\"title\"><a href=\"/danh-muc-anh/" + item.TangName + ".html\">" + item.Name + "</a></h2>";
                    str += "</div>";
                    str += "<div style=\"clear: both\"></div>";
                    str += "<ul class=\"Album \">";
                    List<Entity.Album_RutGon> table = SAlbum.Name_Text_RG("select top " + Commond.Setting("txtHomePagealbum") + " Alt,ID,Title,Images,ImagesSmall,Create_Date,TangName,Anhnhieu from  Album where News=1 and Menu_ID in (" + More.Sub_Menu(More.AB, item.ID.ToString()) + ") and Status=1   order by Create_Date desc");
                    if (table.Count >= 1)
                    {
                        str += Commond.LoadALbum_Home(table);
                    }
                    str += "</ul>";
                    str += "<div style=\"clear: both\"></div>";
                }
            }
            return str;
        }
        #endregion

        #region Category
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
            int Tongsotrang = int.Parse(Commond.Setting("pagePhoto"));

            if ((Request.QueryString["page"] != null) && (Request.QueryString["page"] != ""))
            {
                pages = Convert.ToInt16(Request.QueryString["page"].Trim());
            }
            List<Entity.Album_RutGon> dt = SAlbum.CATEGORY_PHANTRANG(More.Sub_Menu(More.AB, More.TangNameicid(hp)), language, "1", (pages - 1), ref Tongsobanghi, Tongsotrang);
            if (dt.Count >= 1)
            {
                ViewBag.ShowList = Commond.LoadALbum_Home(dt);
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
            ViewBag.Phantrang = Commond.Phantrang("/danh-muc-anh/" + hp + ".html", Tongsobanghi, pages);
            return View();
        }

        #endregion

        #region Detail
        public ActionResult Detail(string hp)
        {
            if (hp == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LAlbum items = db.LAlbums.SingleOrDefault(p => p.TangName == hp);
            if (items == null)
            {
                Commond.Link301();
            }
            else if (items != null)
            {
                ViewBag.Name = Commond.Name(items.Menu_ID.ToString());
                string iphoto = items.ID.ToString();
                ViewBag.Title = items.Title.ToString();

                #region views
                if (MoreAll.MoreAll.GetCookies("views").Equals("") || !MoreAll.MoreAll.GetCookies("views").Equals(iphoto))
                {
                    SAlbum.Name_Text("update Album set Views=Views + 1 where ID=" + iphoto + "");
                    MoreAll.MoreAll.SetCookie("views", iphoto);
                }
                #endregion
                ViewBag.ViewsSlide = ViewslideMax(hp);
            }
            return View();
        }
        public string ViewslideMax(string hp)
        {
            string bReturn = "";
            LAlbum dbPro = db.LAlbums.SingleOrDefault(p => p.TangName == hp);
            if (dbPro != null)
            {
                string[] strArray = dbPro.Anhnhieu.ToString().Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    // bReturn += "<li class=\"albumli\"><a href=\"" + strArray[i].ToString() + "\" rel=\"prettyPhoto[gallery1]\"><img alt='" + dbPro.Title.ToString() + "'  src=\"" + strArray[i].ToString() + "\"/></li>";
                    bReturn += "<li class=\"albumli\"><a href='" + strArray[i].ToString() + "'><img src='" + strArray[i].ToString() + "' alt='" + dbPro.Title + "" + i + "' /></br></a></li>";
                }
            }
            return bReturn;
        }
        #endregion

    }
}