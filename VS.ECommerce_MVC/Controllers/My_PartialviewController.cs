using Common;
using MoreAll;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VS.ECommerce_MVC.Controllers
{
    public class My_PartialviewController : Controller
    {
        //
        // GET: /My_Partialview/
        string hp = "";
        string nav = "";
        string u = "";
        int _cid = -1;
        DatalinqDataContext db = new DatalinqDataContext();
        private string language = Captionlanguage.SetLanguage();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AutoRefreshCart()
        {
            return PartialView();
        }
        public ActionResult AutoRefreshHeaderCart()
        {
            return PartialView();
        }
        public ActionResult Header()
        {
            return PartialView();
        }
        public ActionResult Footer()
        {
            return PartialView();
        }
        public ActionResult Lefmenu()
        {
            ViewBag.TuVan = MoreAll.MoreAll.GetCache("TuVan", System.Web.HttpContext.Current.Cache["TuVan"] != null ? "" : TuVan());
            ViewBag.PhongThuy = MoreAll.MoreAll.GetCache("PhongThuy", System.Web.HttpContext.Current.Cache["PhongThuy"] != null ? "" : PhongThuy());
            return PartialView();
        }
        protected string TuVan()// tin mới
        {
            string str = "";
            List<Entity.Category_News> table = SNews.Name_Text_Rg("SELECT " + Commond.Sql_News() + " FROM [News] WHERE CheckBox1=1 AND lang='" + language + "'  AND Status=1  order by Create_Date desc");
            if (table.Count >= 1)
            {
                str += Commond.LoadNewsListHome(table, language);
            }
            return str;
        }
        protected string PhongThuy()// tin mới
        {
            string str = "";
            List<Entity.Category_News> table = SNews.Name_Text_Rg("SELECT " + Commond.Sql_News() + " FROM [News] WHERE CheckBox2=1 AND lang='" + language + "'  AND Status=1  order by Create_Date desc");
            if (table.Count >= 1)
            {
                str += Commond.LoadNewsListHome(table, language);
            }
            return str;
        }
        public ActionResult LefmenuTrong()
        {
            ViewBag.ddlcountry = Bind_ddlCountry();
            ViewBag.NhaDatBan = NhaDatBan();
            return PartialView();
        }
        [HttpGet]
        public string NhaDatBan()
        {
            string str = "";
            str += "<option value=\"0\">Chọn loại nhà đất</option>";
            List<Menu> dt = db.Menus.Where(p => p.Parent_ID.ToString() == "792" && p.capp == "PR").OrderBy(s => s.Orders).ToList();
            for (int i = 0; i < dt.Count; i++)
            {
                str += "<option value=\"" + dt[i].ID.ToString() + "\">" + dt[i].Name.ToString() + "</option>";
            }
            return str;
        }

        [HttpGet]
        public string NhaChoThue()
        {
            string str = "";
            str += "<option value=\"0\">Chọn loại nhà đất</option>";
            List<Menu> dt = db.Menus.Where(p => p.Parent_ID.ToString() == "794" && p.capp == "PR").OrderByDescending(s => s.Orders).ToList();
            for (int i = 0; i < dt.Count; i++)
            {
                str += "<option value=\"" + dt[i].ID.ToString() + "\">" + dt[i].Name.ToString() + "</option>";
            }
            return str;
        }

        #region Tỉnh thành
        protected string Bind_ddlCountry()
        {
            string str = "";
            str += "<select id=\"ddlcountry\" name=\"ddlcountry\" class='form-control custom-select'>";
            str += "<option value=\"0\">Chọn tỉnh thành</option>";
            List<Tinhthanh> dt = db.Tinhthanhs.Where(p => p.Parent_ID.ToString() == "-1" && p.capp == "TT").OrderByDescending(s => s.Orders).ToList();
            for (int i = 0; i < dt.Count; i++)
            {
                if (dt[i].Parent_ID.ToString() == "-1")
                {
                    str += "<option value=\"" + dt[i].ID.ToString() + "\">" + dt[i].Name.ToString() + "</option>";
                }
            }
            str += "</select>";
            return str;
        }
        protected string Bind_ddlState(int CountryId)
        {
            string str = "";
            str += "<option value=\"0\">Chọn quận/huyện</option>";
            List<Tinhthanh> dt = db.Tinhthanhs.Where(p => p.Parent_ID == CountryId && p.capp == "TT").OrderByDescending(s => s.Orders).ToList();
            for (int i = 0; i < dt.Count; i++)
            {
                str += "<option value=\"" + dt[i].ID.ToString() + "\">" + dt[i].Name.ToString() + "</option>";
            }
            return str;
        }

        protected string PhuongXa(int CountryId)
        {
            string str = "";
            str += "<option value=\"0\">Chọn phường/xã</option>";
            List<Tinhthanh> dt = db.Tinhthanhs.Where(p => p.Parent_ID == CountryId && p.capp == "TT").OrderByDescending(s => s.Orders).ToList();
            for (int i = 0; i < dt.Count; i++)
            {
                str += "<option value=\"" + dt[i].ID.ToString() + "\">" + dt[i].Name.ToString() + "</option>";
            }
            return str;
        }
        [HttpGet]
        public string StateDetails(int CountryId)
        {
            return Bind_ddlState(CountryId);
        }

        [HttpGet]
        public string StatePhuongXa(int CountryId)
        {
            return PhuongXa(CountryId);
        }
        #endregion
        #region Control Nav_conten
        public ActionResult Nav_conten()
        {
            ViewBag.ltrnav = ShowLoadNav_conten();
            return PartialView();
        }

        private string ShowLoadNav_conten()
        {
            string strReturn = "";
            strReturn += "";
            var curURL = Request.RawUrl;
            u = curURL.Substring(curURL.LastIndexOf("/") + 1);
            hp = u.Replace(".html", "");
            hp = Removelink.RemoveUrl(hp);

            #region Nhóm danh mục
            // nhóm
            if (Request.RawUrl.Contains("/page/"))
            {
                strReturn += LoadNavPage("page", hp);
            }
            if (Request.RawUrl.Contains("/danh-muc-tin/"))
            {
                if (int.TryParse(More.TangNameicid(hp), out _cid))
                {
                    strReturn += "<li><a href=\"/tin-tuc-new.html\">" + Commond.label("l_news") + "</a><span> <i class=\"fa fa-angle-right\"></i> </span> </li>";
                    strReturn += LoadNav("danh-muc-tin", _cid);
                }
            }
            //case "3":// nhom chan trang
            //    if (int.TryParse(More.TangNameicid(hp), out _cid))
            //    {
            //        strReturn += LoadNav(_cid);
            //    }
            //    break;
            if (Request.RawUrl.Contains("/danh-muc-anh/"))
            {
                if (int.TryParse(More.TangNameicid(hp), out _cid))
                {
                    strReturn += "<li><a href=\"/thu-vien-anh.html\">" + Commond.label("Thuvienanh") + "</a><span> <i class=\"fa fa-angle-right\"></i> </span> </li>";
                    strReturn += LoadNav("danh-muc-anh", _cid);
                }
            }
            if (Request.RawUrl.Contains("/danh-muc-video/"))
            {
                if (int.TryParse(More.TangNameicid(hp), out _cid))
                {
                    strReturn += "<li><a href=\"/thu-vien-video.html\">" + Commond.label("Thuvienvideo") + "</a><span> <i class=\"fa fa-angle-right\"></i> </span> </li>";
                    strReturn += LoadNav("danh-muc-video", _cid);
                }
            }
            if (Request.RawUrl.Contains("/danh-muc/"))
            {
                if (int.TryParse(More.TangNameicid(hp), out _cid))
                {
                    strReturn += "<li><a href=\"/san-pham-news.html\">" + Commond.label("lproducts") + "</a><span> <i class=\"fa fa-angle-right\"></i> </span> </li>";
                    strReturn += LoadNav("danh-muc", _cid);
                }
            }
            #endregion

            //// Chi tiet
            #region Chi tiet
            if (Request.RawUrl.Contains("/tin-tuc/"))
            {
                strReturn += "<li><a href=\"/tin-tuc-new.html\">" + Commond.label("l_news") + "</a><span> <i class=\"fa fa-angle-right\"></i> </span> </li>";
                strReturn += LoadNavNews("danh-muc-tin", hp);
            }
            //case "4":
            //    strReturn += LoadNavNewsFooter(hp);
            //    break;
            if (Request.RawUrl.Contains("/album/"))
            {
                strReturn += "<li><a href=\"/thu-vien-anh.html\">" + Commond.label("Thuvienanh") + "</a><span> <i class=\"fa fa-angle-right\"></i> </span> </li>";
                strReturn += LoadNavAllbums("danh-muc-anh", hp);
            }
            if (Request.RawUrl.Contains("/video/"))
            {
                strReturn += "<li><a href=\"/thu-vien-video.html\">" + Commond.label("Thuvienvideo") + "</a><span> <i class=\"fa fa-angle-right\"></i> </span> </li>";
                strReturn += LoadNavVideos("danh-muc-video", hp);
            }
            if (Request.RawUrl.Contains("/san-pham/"))
            {
                strReturn += "<li><a href=\"/san-pham.html\">" + Commond.label("lproducts") + "</a><span> <i class=\"fa fa-angle-right\"></i> </span> </li>";
                strReturn += LoadNavProduts("danh-muc", hp);
            }
            #endregion

            if (Request.RawUrl.Contains("gio-hang.html"))
            {
                strReturn += "<li><a href=\"/gio-hang.html\">" + Commond.label("lt_cartbox") + "</a></li>";
            }
            if (Request.RawUrl.Contains("dat-hang.html"))
            {
                strReturn += "<li><a href=\"/dat-hang.html\">" + Commond.label("lt_cartbox") + "</a></li>";
            }
            if (Request.RawUrl.Contains("Message-removecart.html"))
            {
                strReturn += "<li><a href=\"/Message-removecart.html\">" + Commond.label("lt_cartbox") + "</a></li>";
            }
            if (Request.RawUrl.Contains("Message-Ordersucess.html"))
            {
                strReturn += "<li><a href=\"/Message-Ordersucess.html\">" + Commond.label("lt_cartbox") + "</a></li>";
            }
            if (Request.RawUrl.Contains("lien-he.html"))
            {
                strReturn += "<li><a href=\"/lien-he.html\">" + Commond.label("l_contact") + "</a></li>";
            }
            if (Request.RawUrl.Contains("tin-tuc-new.html"))
            {
                strReturn += "<li><a href=\"/tin-tuc-new.html\">" + Commond.label("l_news") + "</a></li>";
            }
            if (Request.RawUrl.Contains("thu-vien-anh.html"))
            {
                strReturn += "<li><a href=\"/thu-vien-anh.html\">" + Commond.label("Thuvienanh") + "</a></li>";
            }
            if (Request.RawUrl.Contains("thu-vien-video.html"))
            {
                strReturn += "<li><a href=\"/thu-vien-video.html\">" + Commond.label("Thuvienvideo") + "</a></li>";
            }
            if (Request.RawUrl.Contains("san-pham-news.html"))
            {
                strReturn += "<li><a href=\"/san-pham-news.html\">" + Commond.label("lproducts") + "</a></li>";
            }
            if (Request.RawUrl.Contains("Search.html"))
            {
                strReturn += "<li><a href=\"#\">" + Commond.label("l_search") + "</a></li>";
            }
            if (Request.RawUrl.Contains("Dang-ky.html"))
            {
                strReturn += "<li><a href=\"/Dang-ky.html\">" + Commond.label("Thanhvien") + "</a></li>";
            }
            if (Request.RawUrl.Contains("Dang-nhap.html"))
            {
                strReturn += "<li><a href=\"/Dang-nhap.html\">" + Commond.label("l_login") + "</a></li>";
            }
            if (Request.RawUrl.Contains("doi-mat-khau.html"))
            {
                strReturn += "<li><a href=\"/doi-mat-khau.html\">" + Commond.label("lt_changepassword") + "</a></li>";
            }
            if (Request.RawUrl.Contains("ho-so-thanh-vien.html"))
            {
                strReturn += "<li><a href=\"/ho-so-thanh-vien.html\">" + Commond.label("ttthanhvien") + "</a></li>";
            }
            if (Request.RawUrl.Contains("Quen-mat-khau.html"))
            {
                strReturn += "<li><a href=\"/Quen-mat-khau.html\">" + Commond.label("thaydoimk") + "</a></li>";
            }
            if (Request.RawUrl.Contains("lich-su-mua-hang.html"))
            {
                strReturn += "<li><a href=\"/lich-su-mua-hang.html\">Lịch sử mua hàng</a></li>";
            }
            if (Request.RawUrl.Contains("link-affiliate.html"))
            {
                strReturn += "<li><a href=\"/link-affiliate.html\">Affiliate</a></li>";
            }
            if (Request.RawUrl.Contains("wallet.html"))
            {
                strReturn += "<li><a href=\"/wallet.html\"> Ví tiền</a></li>";
            }
            if (Request.RawUrl.Contains("lich-su-hoa-hong.html"))
            {
                strReturn += "<li><a href=\"/lich-su-hoa-hong.html\"> Lịch sử hoa hồng</a></li>";
            }
            if (Request.RawUrl.Contains("danh-sach-thanh-vien.html"))
            {
                strReturn += "<li><a href=\"/danh-sach-thanh-vien.html\"> Danh sách thành viên</a></li>";
            }
            if (Request.RawUrl.Contains("lich-su-thanh-toan.html"))
            {
                strReturn += "<li><a href=\"/lich-su-thanh-toan.html\"> Lịch sử thanh toán</a></li>";
            }
            if (Request.RawUrl.Contains("rut-tien.html"))
            {
                strReturn += "<li><a href=\"/rut-tien.html\"> Thanh toán</a></li>";
            }
            return strReturn;
        }
        private string LoadNavNews(string url, string hp)
        {
            New dt = db.News.SingleOrDefault(p => p.TangName == hp);
            if (dt != null)
            {
                var item = db.Menus.FirstOrDefault(s => s.ID == int.Parse(dt.icid.ToString()));
                nav = "<li><a href=\"/" + url + "/" + item.TangName.ToString() + ".html\">" + item.Name + "</a><span> <i class=\"fa fa-angle-right\"></i> </span> </li>" + nav;
                if (item.Parent_ID != -1)
                {
                    LoadNav(url, Convert.ToInt32(item.Parent_ID));
                }
            }
            return nav;
        }

        private string LoadNavNewsFooter(string url, string hp)
        {
            Nfooter dt = db.Nfooters.SingleOrDefault(p => p.TangName == hp);
            if (dt != null)
            {
                var item = db.Menus.FirstOrDefault(s => s.ID == int.Parse(dt.icid.ToString()));
                nav = "<li><a href=\"/" + url + "/" + item.TangName.ToString() + ".html\">" + item.Name + "</a><span> <i class=\"fa fa-angle-right\"></i> </span> </li>" + nav;
                if (item.Parent_ID != -1)
                {
                    LoadNav(url, Convert.ToInt32(item.Parent_ID));
                }
            }
            return nav;
        }

        private string LoadNavAllbums(string url, string hp)
        {
            LAlbum dt = db.LAlbums.SingleOrDefault(p => p.TangName == hp);
            if (dt != null)
            {
                var item = db.Menus.FirstOrDefault(s => s.ID == int.Parse(dt.Menu_ID.ToString()));
                nav = "<li><a href=\"/" + url + "/" + item.TangName.ToString() + ".html\">" + item.Name + "</a><span> <i class=\"fa fa-angle-right\"></i> </span> </li>" + nav;
                if (item.Parent_ID != -1)
                {
                    LoadNav(url, Convert.ToInt32(item.Parent_ID));
                }
            }
            return nav;
        }

        private string LoadNavVideos(string url, string hp)
        {
            VideoClip dt = db.VideoClips.SingleOrDefault(p => p.TangName == hp);
            if (dt != null)
            {
                var item = db.Menus.FirstOrDefault(s => s.ID == int.Parse(dt.Menu_ID.ToString()));
                nav = "<li><a href=\"/" + url + "/" + item.TangName.ToString() + ".html\">" + item.Name + "</a><span> <i class=\"fa fa-angle-right\"></i> </span> </li>" + nav;
                if (item.Parent_ID != -1)
                {
                    LoadNav(url, Convert.ToInt32(item.Parent_ID));
                }
            }
            return nav;
        }

        private string LoadNavProduts(string url, string hp)
        {
            product dt = db.products.SingleOrDefault(p => p.TangName == hp);
            if (dt != null)
            {
                string[] Nhom = dt.icid.ToString().Split(new char[] { ',' });
                string cid = Nhom[0].ToString();

                var item = db.Menus.FirstOrDefault(s => s.ID == int.Parse(cid.ToString()));
                nav = "<li><a href=\"/" + url + "/" + item.TangName.ToString() + ".html\">" + item.Name + "</a><span> <i class=\"fa fa-angle-right\"></i> </span> </li>" + nav;
                if (item.Parent_ID != -1)
                {
                    LoadNav(url, Convert.ToInt32(item.Parent_ID));
                }
            }
            return nav;
        }

        private string LoadNav(string url, int ID)
        {
            var item = db.Menus.FirstOrDefault(s => s.ID == ID);
            if (item != null)
            {
                nav = "<li><a href=\"/" + url + "/" + item.TangName.ToString() + ".html\">" + item.Name + "</a><span> <i class=\"fa fa-angle-right\"></i> </span> </li>" + nav;
                if (item.Parent_ID != -1)
                {
                    LoadNav(url, Convert.ToInt32(item.Parent_ID));
                }
            }
            return nav;
        }
        private string LoadNavPage(string url, string TangName)
        {
            var item = db.Menus.FirstOrDefault(s => s.TangName == TangName & s.capp == More.MN);
            if (item != null)
            {
                nav = "<li><a href=\"/page/" + item.TangName.ToString() + ".html\">" + item.Name + "</a><span> <i class=\"fa fa-angle-right\"></i> </span> </li>" + nav;
                if (item.Parent_ID != -1)
                {
                    LoadNav(url, Convert.ToInt32(item.Parent_ID));
                }
            }
            return nav;
        }
        #endregion

        public ActionResult TinhThanhMenu()
        {
            ViewBag.TinhThanh = TinhThanh();
            return PartialView();
        }
        protected string TinhThanh()
        {
            string str = "";
            List<Tinhthanh> dt = db.Tinhthanhs.Where(p => p.Parent_ID.ToString() == "-1" && p.capp == "TT").OrderBy(s => s.ID).Take(10).ToList();
            foreach (var item in dt)
            {
                str += "<li> <a title=\"" + item.Name.ToString() + "\" href=\"/tai/" + item.TangName.ToString() + ".html\"> <i class=\"fas fa-chevron-right\"></i> " + item.Name.ToString() + " </a> </li>";
            }
            return str;
        }

      

    }
}