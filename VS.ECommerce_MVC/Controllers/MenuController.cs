using MoreAll;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VS.ECommerce_MVC.Controllers
{
    public class MenuController : Controller
    {
        private string currLevel = "";
        private string language = Captionlanguage.SetLanguage();
        DatalinqDataContext db = new DatalinqDataContext();
        public ActionResult Index()
        {
            return View();
        }

        #region MenuTop
        public ActionResult MenuTop()
        {
            currLevel = GetCurrentLevel();
            // Chỉ sử dụng cache ở trang chủ thôi, vì trang trong còn sử dụng các active css lên ko áp dụng dc
            if (Request.RawUrl.ToString() == "/")
            {
                ViewBag.ShowMenu += MoreAll.MoreAll.GetCache("MenuTop", System.Web.HttpContext.Current.Cache["MenuTop"] != null ? "" : ShowMenu());
            }
            else
            {
                ViewBag.ShowMenu = ShowMenu();
            }

            return PartialView();
        }
        private string GetCurrentLevel()
        {
            string culevel = "";
            string curLink = "";
            var curURL = Request.RawUrl;
            curLink = curURL.Substring(curURL.LastIndexOf("/") + 1);
            var curPage = db.Menus.FirstOrDefault(s => s.Link == curURL && s.Views == 1);
            var homePage = db.Menus.FirstOrDefault(s => s.Link == "/" && s.TangName.Contains("trang-chu"));
            if (homePage != null)
                culevel = homePage.Level;
            try
            {
                if (Request.RawUrl.Contains("/tin-tuc/"))
                {
                    string pagtag = curURL.Substring(curURL.LastIndexOf("/") + 1);
                    New tbnew = db.News.SingleOrDefault(p => p.TangName == pagtag.Replace(".html", ""));
                    var data = db.Menus.Where(u => u.ID == tbnew.icid).FirstOrDefault();

                    var xx = db.Menus.Where(u => u.Level == data.Level.Substring(0, 5) && u.capp == "NS").FirstOrDefault();
                    string chuoi = xx.TangName + ".html";

                    var kq = db.Menus.Where(u => u.Link == "/danh-muc-tin/" + chuoi).FirstOrDefault();
                    return kq.Level.Substring(0, 5);
                }
            }
            catch (Exception) { }
            try
            {
                if (Request.RawUrl.Contains("/san-pham/"))
                {
                    string pagtag = curURL.Substring(curURL.LastIndexOf("/") + 1);
                    product tbnew = db.products.SingleOrDefault(p => p.TangName == pagtag.Replace(".html", ""));
                    var data = db.Menus.Where(u => u.ID == int.Parse(tbnew.icid.ToString())).FirstOrDefault();

                    var xx = db.Menus.Where(u => u.Level == data.Level.Substring(0, 5) && u.capp == "PR").FirstOrDefault();
                    string chuoi = xx.TangName + ".html";

                    var kq = db.Menus.Where(u => u.Link == "/danh-muc/" + chuoi).FirstOrDefault();
                    return kq.Level.Substring(0, 5);
                }
            }
            catch (Exception) { }

            try
            {
                if (Request.RawUrl.Contains("/album/"))
                {
                    string pagtag = curURL.Substring(curURL.LastIndexOf("/") + 1);

                    LAlbum tbnew = db.LAlbums.SingleOrDefault(p => p.TangName == pagtag.Replace(".html", ""));
                    var data = db.Menus.Where(u => u.ID == tbnew.Menu_ID).FirstOrDefault();

                    var xx = db.Menus.Where(u => u.Level == data.Level.Substring(0, 5) && u.capp == "AB").FirstOrDefault();
                    string chuoi = xx.TangName + ".html";

                    var kq = db.Menus.Where(u => u.Link == "/danh-muc-anh/" + chuoi).FirstOrDefault();
                    return kq.Level.Substring(0, 5);
                }
            }
            catch (Exception) { }

            try
            {
                if (Request.RawUrl.Contains("/video/"))
                {
                    string pagtag = curURL.Substring(curURL.LastIndexOf("/") + 1);

                    VideoClip tbnew = db.VideoClips.SingleOrDefault(p => p.TangName == pagtag.Replace(".html", ""));
                    var data = db.Menus.Where(u => u.ID == tbnew.Menu_ID).FirstOrDefault();

                    var xx = db.Menus.Where(u => u.Level == data.Level.Substring(0, 5) && u.capp == "VD").FirstOrDefault();
                    string chuoi = xx.TangName + ".html";

                    var kq = db.Menus.Where(u => u.Link == "/danh-muc-video/" + chuoi).FirstOrDefault();
                    return kq.Level.Substring(0, 5);
                }
            }
            catch (Exception) { }
            if (curPage != null)
            {
                return curPage.Level;
            }
            else
            {
                return culevel;
            }
        }

        protected string ShowMenu()
        {

            string strMenu = "";
            List<Entity.Menu_OK> list = SMenu.Name_Text_Rg("SELECT capp,Create_Date,Description,Equals,ID,Images,Lang,Level,Link,Module,Name,Orders,Parent_ID,ShowID,Styleshow,TangName,Type,Url_Name,Views FROM Menu where capp='" + More.MN + "' and lang='" + language + "' and Views=1 and status=1 order by level,Orders asc").ToList();//Views là vị trí menu top
            if (list != null)
            {
                int ilevel = 0, iblevel = 0, k = 0, n = 1, ilength = 5, istartlevel = 0;
                string tmpLevel = "";
                for (int j = 0; j < list.Count; j++)
                {
                    string liClass = "";
                    tmpLevel = list[j].Level;
                    ilevel = (tmpLevel.Length / ilength) - istartlevel;
                    if (ilevel > iblevel)
                    {
                        strMenu += ilevel == 1 ? string.Format("") : "<ul>";
                    }
                    if (ilevel < iblevel)
                    {
                        for (k = 1; k <= (iblevel - ilevel); k++)
                        {
                            strMenu += "</ul>";
                            if (iblevel > 1) { strMenu += "</li>"; }
                        }
                        iblevel = ilevel;
                    }
                    string strName = list[j].Name;

                    if (list[j].ShowID == 2)
                    {
                        if ((currLevel.Length > 0 && currLevel.Length >= list[j].Level.Length && list[j].Level == currLevel.Substring(0, list[j].Level.Length)) || (list[j].TangName.Length > 1 && (Request.Url.AbsolutePath.Contains(list[j].TangName) || Request.RawUrl.Contains(list[j].TangName))))
                        {
                            liClass = "active";
                        }
                    }
                    else
                    {
                        if (list[j].Link != "/")
                        {
                            if ((currLevel.Length > 0 && currLevel.Length >= list[j].Level.Length && list[j].Level == currLevel.Substring(0, list[j].Level.Length)) || (list[j].Link.Length > 1 && (Request.Url.AbsolutePath.Contains(list[j].Link) || Request.RawUrl.Contains(list[j].Link))))
                            {
                                liClass = "active";
                            }
                        }
                    }
                    string lastClass = j == list.Count - 1 ? "last" : "";
                    string iconClass = SMenu.Menu_ExitstByLevel(tmpLevel).Count > 0 ? ilevel == 1 ? "itop" : "icon" : "";
                    if (iconClass.Length > 0)
                        liClass += " " + iconClass;
                    if (lastClass.Length > 0)
                        liClass += " " + lastClass;
                    if (liClass.Length > 0)
                        liClass = string.Format(" class=\"{0}\"", liClass.Trim());

                    string Link = "";
                    if (list[j].ShowID == 2)// dạng nội dung=2
                    {
                        Link = "/page/" + list[j].TangName + ".html";
                    }
                    else if (list[j].ShowID == 3)// dạng link=3
                    {
                        Link = list[j].Link;
                    }
                    else//Trang liên kết =1
                    {
                        if (list[j].Link == "/")
                        {
                            Link = list[j].Link;
                        }
                        else
                        {
                            Link = list[j].Link;
                        }
                    }
                    string anh = "";
                    if (list[j].Images.Length > 0)
                    {
                        // anh += "<div class='iconmn'><img src=\"" + list[j].Images + "\" /></div>";
                    }
                    if ((j < list.Count - 2) && list[j + 1].Level.StartsWith(list[j].Level) && list[j + 1].Level.Length == list[j].Level.Length + 5)
                    {
                        strMenu += "<li" + liClass + "><a href=\"" + Link + "\" >" + anh + list[j].Name + "</a>";
                    }
                    else
                    {
                        strMenu += "<li" + liClass + "><a href=\"" + Link + "\" target=\"" + list[j].Styleshow + "\">" + anh + list[j].Name + "</a>";
                    }
                    if (SMenu.Menu_ExitstByLevel(tmpLevel).Count == 0)
                    {
                        strMenu += "</li>";
                    }
                    iblevel = ilevel;
                    if (n == list.Count)
                    {
                        k = 0;
                        for (k = iblevel - 1; k == 1; k--)
                        {
                            strMenu += "</ul>";
                            if (iblevel > 1) { strMenu += "</ul></li>"; }
                        }
                    }
                    n++;
                }
            }
            list.Clear();
            list = null;
            return strMenu;
        }
        #endregion

        #region MenuBottom
        public ActionResult MenuBottom()
        {
            ViewBag.ShowMenu = MoreAll.MoreAll.GetCache("MenuBottom", System.Web.HttpContext.Current.Cache["MenuBottom"] != null ? "" : ShowMenuBottom());
            return PartialView();
        }
        protected string ShowMenuBottom()
        {
            string str = "";
            List<Entity.Menu_OK> table = SMenu.Name_Text_Rg("SELECT capp,Create_Date,Description,Equals,ID,Images,Lang,Level,Link,Module,Name,Orders,Parent_ID,ShowID,Styleshow,TangName,Type,Url_Name,Views FROM Menu where capp='" + More.MN + "' and lang='" + language + "' and Views=2 and status=1 order by level,Orders asc");//Views là vị trí menu top
            table = table.Where(s => s.Level.Length == 5).ToList();
            if (table.Count > 0)
            {
                for (int i = 0; i < table.Count; i++)
                {
                    string Link = "";
                    if (table[i].ShowID == 2)// dạng nội dung=2
                    {
                        Link = "/page/" + table[i].TangName + ".html";
                    }
                    else if (table[i].ShowID == 3)// dạng link=3
                    {
                        Link = table[i].Link;
                    }
                    else//Trang liên kết =1
                    {
                        if (table[i].Link == "/")
                        {
                            Link = table[i].Link;
                        }
                        else
                        {
                            Link = table[i].Link;
                        }
                    }
                    str += "<div id=\"nav_menu-2\" class=\"col pb-0 widget widget_nav_menu\">";
                    str += "<span class=\"widget-title\">" + table[i].Name.ToString() + "</span>";
                    str += "<div class=\"is-divider small\"></div>";
                    str += "<div class=\"menu-dieu-huong-footer-1-container\">";
                    str += "<ul id=\"menu-dieu-huong-footer-1\" class=\"menu\">";
                    str += SubMenuBottom(table[i].Level.ToString());
                    str += "</ul>";
                    str += "</div>";
                    str += "</div>";

                }
            }
            return (str);
        }
        protected string SubMenuBottom(string id)
        {
            string str = "";
            List<Entity.Menu_OK> list = SMenu.Name_Text_Rg("SELECT capp,Create_Date,Description,Equals,ID,Images,Lang,Level,Link,Module,Name,Orders,Parent_ID,ShowID,Styleshow,TangName,Type,Url_Name,Views FROM Menu where capp='" + More.MN + "' and lang='" + language + "' and Views=2 and status=1 and  len([Level]) >= 10 and [Level] like '" + id + "%'  order by level,Orders asc");//Views là vị trí menu top
            if (list.Count > 0)
            {
                foreach (Entity.Menu_OK item in list)
                {
                    string Link = "";
                    if (item.ShowID == 2)// dạng nội dung=2
                    {
                        Link = "/page/" + item.TangName + ".html";
                    }
                    else if (item.ShowID == 3)// dạng link=3
                    {
                        Link = item.Link;
                    }
                    else//Trang liên kết =1
                    {
                        if (item.Link == "/")
                        {
                            Link = item.Link;
                        }
                        else
                        {
                            Link = item.Link;
                        }
                    }
                    str += "<li id=\"menu-item-807\" class=\"menu-item menu-item-type-custom menu-item-object-custom menu-item-807\"><a  href='" + Link + "'>" + item.Name.ToString() + "</a></li>";
                }
            }
            str += "</ul>";
            return str.ToString();
        }
        #endregion

        #region Menu Page
        public ActionResult MenuPage()
        {
            ViewBag.ShowMenu = ShowMenuPage();
            // ViewBag.ShowMenu = MoreAll.MoreAll.GetCache("ShowMenuPage", System.Web.HttpContext.Current.Cache["ShowMenuPage"] != null ? "" : ShowMenuPage());
            return PartialView();
        }
        protected string ShowMenuPage()
        {
            string hp = Request.RawUrl.ToString();
            hp = Removelink.RemoveUrl(hp);

            string str = "";
            List<Entity.Menu_OK> dt2 = SMenu.Name_Text_Rg("SELECT capp,Create_Date,Description,Equals,ID,Images,Lang,Level,Link,Module,Name,Orders,Parent_ID,ShowID,Styleshow,TangName,Type,Url_Name,Views FROM Menu where capp='" + More.MN + "'  and  len([Level])= 5 and [Level] like '" + RequestMenuLevel(Request["hp"]) + "%'   and Views=1  and lang='" + language + "'  and status=1 order by level,Orders asc");
            if (dt2.Count > 0)
            {
                str += "<li class=\"header\"><a  href='/" + dt2[0].TangName.ToString() + ".html'>" + dt2[0].Name.ToString() + "</a></li>";
            }
            List<Entity.Menu_OK> dt = SMenu.Name_Text_Rg("SELECT capp,Create_Date,Description,Equals,ID,Images,Lang,Level,Link,Module,Name,Orders,Parent_ID,ShowID,Styleshow,TangName,Type,Url_Name,Views  FROM Menu where capp='" + More.MN + "'  and  len([Level]) >= 10 and [Level] like '" + RequestMenuLevel(Request["hp"]) + "%'   and Views=1  and lang='" + language + "'  and status=1 order by level,Orders asc");
            if (dt.Count > 0)
            {
                foreach (Entity.Menu_OK item in dt)
                {
                    if (More.MenuDacap(More.TangNameicid(hp)) == More.MenuDacap(item.ID.ToString()))
                    {
                        str += "<li  class=\"activer\"><a  href='/" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a></li>";
                    }
                    else
                    {
                        str += "<li><a  href='/" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a></li>";
                    }
                }
            }
            return str.ToString();
        }

        public string RequestMenuLevel(string Request)
        {
            string Modul = "";
            List<Entity.Menu_OK> str = SMenu.Name_Text_Rg("SELECT top 1 capp,Create_Date,Description,Equals,ID,Images,Lang,Level,Link,Module,Name,Orders,Parent_ID,ShowID,Styleshow,TangName,Type,Url_Name,Views FROM [Menu]  where TangName=N'" + Request + "'");
            if (str.Count > 0 || str != null)
            {
                Modul = str[0].Level.Substring(0, 5).ToString();
            }
            return Modul;
        }

        #endregion

        #region MenuCategoryPro Menu sản phẩm lấy theo nhóm cha
        public ActionResult MenuCategoryPro()
        {
            ViewBag.ShowMenu = ShowMenuCategoryPro();
            return PartialView();
        }
        protected string ShowMenuCategoryPro()
        {
            string Case = Request.RawUrl.ToString();
            string hp = Request.RawUrl.ToString();
            hp = Removelink.RemoveUrl(hp);
            string str = "";
            try
            {

                if (Case.Contains("/danh-muc/"))
                {
                    List<Entity.Menu> dt = SMenu.Name_Text("SELECT * FROM [Menu]  where ID=" + More.MenuDacap(More.TangNameicid(hp)) + " and  capp='" + More.PR + "'  order by Orders asc");
                    if (dt.Count > 0)
                    {
                        foreach (Entity.Menu item in dt)
                        {
                            str += "<div class=\"catalog\">";
                            str += "<div class=\"blog-title\">";
                            str += "<h2>" + item.Name + "</h2>";
                            str += "</div>";
                            str += "<div class=\"calalog-inner\">";
                            str += "<ul class=\"catalog-list\">";
                            str += MenuPro1(item.ID.ToString());
                            str += "</ul>";
                            str += "</div>";
                            str += "</div>";
                        }
                    }
                }
                else if (Case.Contains("/san-pham/"))
                {
                    List<Entity.Menu> dt = SMenu.Name_Text("SELECT * FROM [Menu]  where ID=" + More.MenuDacap(More.TangNameProducts(hp)) + " and  capp='" + More.PR + "'  order by Orders asc");
                    if (dt.Count > 0)
                    {
                        foreach (Entity.Menu item in dt)
                        {
                            str += "<div class=\"catalog\">";
                            str += "<div class=\"blog-title\">";
                            str += "<h2>" + item.Name + "</h2>";
                            str += "</div>";
                            str += "<div class=\"calalog-inner\">";
                            str += "<ul class=\"catalog-list\">";
                            str += MenuPro1(item.ID.ToString());
                            str += "</ul>";
                            str += "</div>";
                            str += "</div>";
                        }
                    }
                }


            }
            catch (Exception)
            { }
            return str.ToString();
        }
        protected string MenuPro1(string id)
        {
            string str = "";

            List<Entity.Menu> dt = SMenu.capp_Lang_Parent_ID_Status(More.PR, language, id, "1");
            if (dt.Count > 0)
            {
                foreach (Entity.Menu item in dt)
                {
                    str += "<li class=\"catalog-item\" ><a class=\"catalog-link\" href='/" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a>";
                    str += MenuPro(item.ID.ToString());
                    str += "</li>";
                }
            }
            return str.ToString();
        }
        protected string MenuPro(string id)
        {
            string str = "";

            List<Entity.Menu> dt = SMenu.capp_Lang_Parent_ID_Status(More.PR, language, id, "1");
            if (dt.Count > 0)
            {
                str += "<ul class=\"sub1-list\" style=\"display: none\">";
                foreach (Entity.Menu item in dt)
                {
                    str += "<li class=\"sub1-item\"><a class=\"sub1-link\" href='/" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a></li>";
                }
                str += "</ul>";
            }
            return str.ToString();
        }
        #endregion


        public ActionResult MenuTopMobile()
        {
            if (Request.RawUrl.ToString() == "/")
            {
                ViewBag.ShowMenu += MoreAll.MoreAll.GetCache("ShowMenuMobile", System.Web.HttpContext.Current.Cache["ShowMenuMobile"] != null ? "" : ShowMenuMobile());
            }
            else
            {
                ViewBag.ShowMenu = ShowMenuMobile();
            }

            return PartialView();
        }
        protected string ShowMenuMobile()
        {

            string strMenu = "";
            List<Entity.Menu_OK> list = SMenu.Name_Text_Rg("SELECT capp,Create_Date,Description,Equals,ID,Images,Lang,Level,Link,Module,Name,Orders,Parent_ID,ShowID,Styleshow,TangName,Type,Url_Name,Views FROM Menu where capp='" + More.MN + "' and lang='" + language + "' and Views=1 and status=1 order by level,Orders asc").ToList();//Views là vị trí menu top
            if (list != null)
            {
                int ilevel = 0, iblevel = 0, k = 0, n = 1, ilength = 5, istartlevel = 0;
                string tmpLevel = "";
                for (int j = 0; j < list.Count; j++)
                {
                    string liClass = "";
                    tmpLevel = list[j].Level;
                    ilevel = (tmpLevel.Length / ilength) - istartlevel;
                    if (ilevel > iblevel)
                    {
                        strMenu += ilevel == 1 ? string.Format("") : "<ul>";
                    }
                    if (ilevel < iblevel)
                    {
                        for (k = 1; k <= (iblevel - ilevel); k++)
                        {
                            strMenu += "</ul>";
                            if (iblevel > 1) { strMenu += "</li>"; }
                        }
                        iblevel = ilevel;
                    }
                    string strName = list[j].Name;

                    if (list[j].ShowID == 2)
                    {
                        if ((currLevel.Length > 0 && currLevel.Length >= list[j].Level.Length && list[j].Level == currLevel.Substring(0, list[j].Level.Length)) || (list[j].TangName.Length > 1 && (Request.Url.AbsolutePath.Contains(list[j].TangName) || Request.RawUrl.Contains(list[j].TangName))))
                        {
                            liClass = "active";
                        }
                    }
                    else
                    {
                        if (list[j].Link != "/")
                        {
                            if ((currLevel.Length > 0 && currLevel.Length >= list[j].Level.Length && list[j].Level == currLevel.Substring(0, list[j].Level.Length)) || (list[j].Link.Length > 1 && (Request.Url.AbsolutePath.Contains(list[j].Link) || Request.RawUrl.Contains(list[j].Link))))
                            {
                                liClass = "active";
                            }
                        }
                    }
                    string lastClass = j == list.Count - 1 ? "last" : "";
                    string iconClass = SMenu.Menu_ExitstByLevel(tmpLevel).Count > 0 ? ilevel == 1 ? "itop" : "icon" : "";
                    if (iconClass.Length > 0)
                        liClass += " " + iconClass;
                    if (lastClass.Length > 0)
                        liClass += " " + lastClass;
                    if (liClass.Length > 0)
                        liClass = string.Format(" class=\"{0}\"", liClass.Trim());

                    string Link = "";
                    if (list[j].ShowID == 2)// dạng nội dung=2
                    {
                        Link = "/page/" + list[j].TangName + ".html";
                    }
                    else if (list[j].ShowID == 3)// dạng link=3
                    {
                        Link = list[j].Link;
                    }
                    else//Trang liên kết =1
                    {
                        if (list[j].Link == "/")
                        {
                            Link = list[j].Link;
                        }
                        else
                        {
                            Link = list[j].Link;
                        }
                    }
                    string anh = "";
                    if (list[j].Images.Length > 0)
                    {
                        // anh += "<div class='iconmn'><img src=\"" + list[j].Images + "\" /></div>";
                    }
                    if ((j < list.Count - 2) && list[j + 1].Level.StartsWith(list[j].Level) && list[j + 1].Level.Length == list[j].Level.Length + 5)
                    {
                        strMenu += "<li" + liClass + "><a href=\"" + Link + "\" >" + anh + list[j].Name + "</a>";
                    }
                    else
                    {
                        strMenu += "<li" + liClass + "><a href=\"" + Link + "\" target=\"" + list[j].Styleshow + "\">" + anh + list[j].Name + "</a>";
                    }
                    if (SMenu.Menu_ExitstByLevel(tmpLevel).Count == 0)
                    {
                        strMenu += "</li>";
                    }
                    iblevel = ilevel;
                    if (n == list.Count)
                    {
                        k = 0;
                        for (k = iblevel - 1; k == 1; k--)
                        {
                            strMenu += "</ul>";
                            if (iblevel > 1) { strMenu += "</ul></li>"; }
                        }
                    }
                    n++;
                }
            }
            list.Clear();
            list = null;
            return strMenu;
        }
    }
}