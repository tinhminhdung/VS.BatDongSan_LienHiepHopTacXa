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
    public class VideoController : Controller
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
            List<Entity.MenuShow> dt = SMenu.Pages_Home(More.VD, language, "1");
            if (dt.Count > 0)
            {
                foreach (Entity.MenuShow item in dt)
                {
                    str += "<div class=\"nhomnhe\">";
                    str += "<h2 class=\"TieudeVideo\"><a href=\"/danh-muc-video/" + item.TangName + ".html\">" + item.Name + "</a></h2>";
                    str += "</div>";
                    str += "<div style=\"clear: both\"></div>";
                    str += "<div class=\"videos\">";

                    List<Entity.VideoClip_RutGon> table = SVideoClip.Name_Text_RG("select top " + Commond.Setting("VideopageHome") + " ID,Title,Images,ImagesSmall,Create_Date,TangName,Alt,Youtube,Brief from  VideoClip where News=1 and Menu_ID in (" + More.Sub_Menu(More.VD, item.ID.ToString()) + ") and Status=1   order by Create_Date desc");
                    if (table.Count >= 1)
                    {
                        str += Commond.LoadVideo_Home(table);
                    }
                    str += "</div>";
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
            int Tongsotrang = int.Parse(AllQuery.MoreVideoClip.Pagevideo());

            if ((Request.QueryString["page"] != null) && (Request.QueryString["page"] != ""))
            {
                pages = Convert.ToInt16(Request.QueryString["page"].Trim());
            }
            List<Entity.VideoClip_RutGon> dt = SVideoClip.CATEGORY_PHANTRANG(More.Sub_Menu(More.VD, More.TangNameicid(hp)), language, "1", (pages - 1), ref Tongsobanghi, Tongsotrang);
            if (dt.Count >= 1)
            {
                ViewBag.ShowList = Commond.LoadVideo_Home(dt);
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
            ViewBag.Phantrang = Commond.Phantrang("/danh-muc-video/" + hp + ".html", Tongsobanghi, pages);
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
            VideoClip dt = db.VideoClips.SingleOrDefault(p => p.TangName == hp);
            if (dt == null)
            {
                Commond.Link301();
            }
            else if (dt != null)
            {
                ViewBag.Name = Commond.Name(dt.Menu_ID.ToString());
                string iVideo = dt.ID.ToString();
                string Menu_ID = dt.Menu_ID.ToString();
                string url = dt.Contents.ToString();
                string FormattedUrl = AllQuery.MoreVideoClip.GetYouTubeID(url);
                ViewBag.lttitle = dt.Title.ToString();
                ViewBag.ltdesc = dt.Brief;
                 ViewBag.ltcontent = dt.Contents;
                string str = "";

                #region LinkYoutube
                if (dt.Youtube.ToString().Length > 0)
                {
                    try
                    {
                        ViewBag.ltyoutube = "<iframe width=\"" + AllQuery.MoreVideoClip.Width() + "\" height=\"" + AllQuery.MoreVideoClip.Height() + "\" src=\"https://www.youtube.com/embed/" + dt.Youtube.ToString().Replace("http://youtu.be/", "") + "\" frameborder=\"0\" allowfullscreen></iframe>";
                    }
                    catch (Exception)
                    {
                    }
                }

                #endregion

                #region views
                if (MoreAll.MoreAll.GetCookies("views").Equals("") || !MoreAll.MoreAll.GetCookies("views").Equals(iVideo))
                {
                    SVideoClip.UPDATE_VIEWS_TIMES(iVideo);
                    MoreAll.MoreAll.SetCookie("views", iVideo);
                }
                #endregion
                ViewBag.Other = Other(iVideo, Menu_ID);
            }
            return View();
        }
        protected string Other(string iVideo, string Menu_ID)
        {
            string str = "";
            List<Entity.VideoClip_RutGon> table = SVideoClip.Name_Text_RG("select top " + AllQuery.MoreVideoClip.Pagevideo() + " ID,Title,Images,ImagesSmall,Create_Date,TangName,Alt,Youtube,Brief from  VideoClip where ID!=" + iVideo + " and Menu_ID in (" + More.Sub_Menu(More.VD, Menu_ID) + ") and Status=1   order by Create_Date desc");
            if (table.Count >= 1)
            {
                str += Commond.LoadVideo_Home(table);
            }
      
            str += "<div style=\"clear: both\"></div>";
            return str;
        }
        #endregion
    }
}