using MoreAll;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace VS.ECommerce_MVC.Controllers
{
    public class ProductsController : Controller
    {
        // GET: /Products/
        DatalinqDataContext db = new DatalinqDataContext();
        private string language = Captionlanguage.SetLanguage();
        public ActionResult Index()
        {
            int Tongsobanghi = 0;
            Int16 pages = 1;
            int Tongsotrang = int.Parse(Commond.Setting("pagepro"));
            if ((Request.QueryString["page"] != null) && (Request.QueryString["page"] != ""))
            {
                pages = Convert.ToInt16(Request.QueryString["page"].Trim());
            }
            List<Entity.Category_Product> dt = SProducts.Product_All(language, "1", (pages - 1), ref Tongsobanghi, Tongsotrang);
            if (dt.Count >= 1)
            {
                ViewBag.ShowList = Commond.LoadProductList(dt);
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
            ViewBag.Phantrang = Commond.Phantrang("/san-pham-news.html", Tongsobanghi, pages);
            return View();
        }

        // [OutputCache(Duration = int.MaxValue, VaryByParam = "hp", Location = OutputCacheLocation.Server)]
        public ActionResult Detail(string hp)
        {
            //Kiểm tra tham số truyền vào có rổng hay không
            if (hp == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Nếu không thì truy xuất csdl lấy ra sản phẩm tương ứng
            string bReturn = "";
            string Thum = "";
            product dt = db.products.SingleOrDefault(p => p.TangName == hp);
            if (dt == null)
            {
                //Thông báo nếu như không có sản phẩm đó
                Commond.Link301();
                return HttpNotFound();
            }
            else if (dt != null)
            {
                //string cid = dt.icid.ToString();
                string pid = dt.ipid.ToString();

                // string[] Nhom = dt.icid.ToString().Split(new char[] { ',' });
                string cid = dt.icid.ToString();
                ViewBag.ShowNhom = Commond.ShowNhom(cid.ToString());
                #region Show ảnh đại diện và nhiều ảnh thum
                if (dt != null)
                {
                    // bReturn += " <a href=\"" + dt.Images + "\"><img src=\"" + dt.Images + "\" alt=\"" + dt.Name + "\"  /></a>";
                    if (dt.Anh.ToString().Length > 5)
                    {
                        string[] strArray = dt.Anh.ToString().Split(new char[] { ',' });
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            bReturn += "<div class=\"col medium-12 small-12 large-12\">";
                            bReturn += " <div class=\"col-inner\">";
                            bReturn += " <a class=\"image-lightbox lightbox-gallery\" href=\"" + strArray[i].ToString() + "\">";
                            bReturn += "<img width=\"765\" height=\"470\" src=\"" + strArray[i].ToString() + "\" class=\"attachment-full size-full\" alt=\"\" loading=\"lazy\" />";
                            bReturn += "  </a>";
                            bReturn += " </div>";
                            bReturn += " </div>";



                            Thum += "<div class=\"col\">";
                            Thum += " <div class=\"col-inner\">";
                            Thum += " <img width=\"100\" height=\"100\" src=\"" + strArray[i].ToString().Replace("uploads", "uploads/_thumbs") + "\" class=\"attachment-thumbnail size-thumbnail\" alt=\"\" loading=\"lazy\" />";
                            Thum += "</div>";
                            Thum += "</div>";

                        }
                    }
                }
                ViewBag.Showimages = bReturn;
                ViewBag.Thum = Thum;

                #endregion

                #region Other
                //icid= " + cid + " and
                List<Entity.Category_Product> table = SProducts.Name_Text_Rg("select top " + int.Parse(Commond.Setting("proother")) + "DonGia,Quanhuyen,DienTich,ipid,icid,TangName,Alt,Name,Images,ImagesSmall,Brief,Create_Date,Price,OldPrice,ID_Hang,sanxuat,Code from products where  ipid!= " + pid + "  and lang= '" + language + "'  and Status=1 order by Create_Date desc");
                // table = table.Where(s => s.icid.ToString().Split(',').Any(a => cid.Contains(a))).OrderBy(s => s.Create_Date).ThenByDescending(s => s.ipid).ToList();
                if (table.Count >= 1)
                {
                    ViewBag.Other += Commond.LoadProductList(table);
                }

                #endregion

                #region UpdateViewTimes
                if (MoreAll.MoreAll.GetCookies("views").Equals("") || !MoreAll.MoreAll.GetCookies("views").Equals(pid))
                {
                    SProducts.UpdateViewTimes(pid);
                    MoreAll.MoreAll.SetCookie("views", pid);
                }

                #endregion
                return View(dt);
            }
            return View();
        }

        // [OutputCache(Duration = int.MaxValue, VaryByParam = "hp", Location = OutputCacheLocation.Server)]
        //public ActionResult Category(string hp)
        //{
        //    if (hp == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    #region Menu
        //    Menu table = db.Menus.SingleOrDefault(p => p.ID == int.Parse(More.TangNameicid(hp)));
        //    if (table == null)
        //    {
        //        Commond.Link301();
        //    }
        //    else if (table != null)
        //    {
        //        ViewBag.Name = table.Name.ToString();
        //        ViewBag.ShowConten = table.Description;
        //    }
        //    #endregion

        //    #region Category
        //    int Tongsobanghi = 0;
        //    Int16 pages = 1;
        //    int Tongsotrang = int.Parse(Commond.Setting("pagepro"));
        //    if ((Request.QueryString["page"] != null) && (Request.QueryString["page"] != ""))
        //    {
        //        pages = Convert.ToInt16(Request.QueryString["page"].Trim());
        //    }
        //    List<Entity.Category_Product> dt = SProducts.CATEGORY_PHANTRANG("", "VIE", "1", (pages - 1), ref Tongsobanghi, Tongsotrang);
        //    if (dt.Count >= 1)
        //    {
        //        string strChild = Commond.SubMenu(More.PR, More.TangNameicid(hp));
        //        dt = dt.Where(s => s.icid.ToString().Split(',').Any(a => strChild.Contains(a))).OrderBy(s => s.Create_Date).ThenByDescending(s => s.ipid).ToList();

        //        ViewBag.ShowList = Commond.LoadProductList(dt);
        //    }
        //    else
        //    {
        //        ViewBag.ShowList = "<div class='Checkdata'>" + Commond.label("I_dulieuchuadccapnhat") + "</div>";
        //    }
        //    if (Tongsobanghi % Tongsotrang > 0)
        //    {
        //        Tongsobanghi = (Tongsobanghi / Tongsotrang) + 1;
        //    }
        //    else
        //    {
        //        Tongsobanghi = Tongsobanghi / Tongsotrang;
        //    }
        //    ViewBag.Phantrang = Commond.Phantrang("/danh-muc/" + hp + ".html", Tongsobanghi, pages);

        //    #endregion
        //    return View();
        //}

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
                ViewBag.ShowConten = table.Description;
            }
            #endregion

            int Tongsobanghi = 0;
            Int16 pages = 1;
            int Tongsotrang = int.Parse(Commond.Setting("pagepro"));
            if ((Request.QueryString["page"] != null) && (Request.QueryString["page"] != ""))
            {
                pages = Convert.ToInt16(Request.QueryString["page"].Trim());
            }
            string sapxep = "order by Create_Date desc";
            List<Entity.Category_Product> iitem = SProducts.CATEGORY_PHANTRANG1(Commond.SubMenu(More.PR, More.TangNameicid(hp)), language);
            if (iitem.Count() > 0)
            {
                // iitem = iitem.Where(s => s.icid.ToString().Split(',').Any(a => strChild.Contains(a))).OrderBy(s => s.Create_Date).ThenByDescending(s => s.ipid).ToList();
                Tongsobanghi = iitem.Count();
            }
            List<Entity.Category_Product> dt = SProducts.CATEGORY_PHANTRANG2(Commond.SubMenu(More.PR, More.TangNameicid(hp)), language, sapxep, (pages - 1), Tongsotrang);
            if (dt.Count > 0)
            {
                // dt = dt.Where(s => s.icid.ToString().Split(',').Any(a => strChild.Contains(a))).OrderBy(s => s.Create_Date).ThenByDescending(s => s.ipid).ToList();
                ViewBag.ShowList = Commond.LoadProductList(dt);
            }
            else
            {
                ViewBag.ShowList = "<div class='Checkdata'>" + this.label("I_dulieuchuadccapnhat") + "</div>";
            }
            if (Tongsobanghi % Tongsotrang > 0)
            {
                Tongsobanghi = (Tongsobanghi / Tongsotrang) + 1;
            }
            else
            {
                Tongsobanghi = Tongsobanghi / Tongsotrang;
            }
            ViewBag.Phantrang = Commond.Phantrang("/danh-muc/" + hp + ".html", Tongsobanghi, pages);
            return View();
        }
        public ActionResult Search()
        {
            string keywordvv = "";
            keywordvv = MoreAll.MoreAll.GetCookies("Search").ToString();
            //string keywordvv = "";
            //{
            //    keywordvv = Request.RawUrl.ToString().Replace("/Search/", "").Replace("-", " ").Replace(".html", "");
            //    int iEmpty = 0;
            //    iEmpty = keywordvv.IndexOf("?");
            //    if (iEmpty != -1)
            //    {
            //        keywordvv = keywordvv.Substring(0, iEmpty);
            //    }
            //    if (keywordvv == "")
            //    {
            //        MoreAll.MoreAll.SetCookie("Search", "", 5000);
            //        Response.Redirect("/");
            //    }
            //}

            //#region Boloc
            String chuois = "";
            String chuoi = "";
            //#region Boloc
            //if (produce != "0")
            //{
            //    chuois += " and ID_Hang in(" + produce + ")";
            //}
            //if (price != "0")
            //{
            //    string Gia = " and (";
            //    string[] strArray = price.ToString().Split(new char[] { ',' });
            //    for (int i = 0; i < strArray.Length; i++)
            //    {
            //        Gia += (i == 0 ? "" : " OR ") + "(Price between (" + Commond.GiaTu(strArray[i].ToString()) + ") and (" + Commond.GiaDen(strArray[i].ToString()) + ")) ";
            //    }
            //    chuois += Gia + ")";
            //}
            //#endregion
            //#endregion
            int Tongsobanghi = 0;
            Int16 pages = 1;
            int Tongsotrang = int.Parse(Commond.Setting("pagepro"));

            if ((Request.QueryString["page"] != null) && (Request.QueryString["page"] != ""))
            {
                pages = Convert.ToInt16(Request.QueryString["page"].Trim());
            }
            List<Entity.Category_Product> iitem = SProducts.SearchPro_locTongbanghi(keywordvv, "", chuois, language, "1");
            if (iitem.Count() > 0)
            {
                Tongsobanghi = iitem.Count();
            }
            List<Entity.Category_Product> dt = SProducts.SearchPro_loc(keywordvv, "", chuois, language, "1", (pages - 1), Tongsotrang);
            if (dt.Count >= 1)
            {
                ViewBag.ShowList = Commond.LoadProductList(dt);
            }
            else
            {
                ViewBag.ShowList = "<div class='Checkdata'>Không tìm thấy dữ liệu</div>";
            }
            if (Tongsobanghi % Tongsotrang > 0)
            {
                Tongsobanghi = (Tongsobanghi / Tongsotrang) + 1;
            }
            else
            {
                Tongsobanghi = Tongsobanghi / Tongsotrang;
            }
            ViewBag.Phantrang = Commond.Phantrang("/search.html", Tongsobanghi, pages);
            return View();
        }
        public ActionResult TimKiem()
        {
            string demand = "0";
            string key_word = "";
            string category = "0";
            string ddlcountry = "0";
            string ddlState = "0";
            string PhuongXa = "0";
            string building_orientation = "0";
            string min_price = "0";
            string max_price = "0";

            string loc = "";
            if ((Request.QueryString["demand"] != null) && (Request.QueryString["demand"] != ""))
            {
                demand = Request.QueryString["demand"].Trim();
                loc += "&demand=" + demand + "";
            }
            if ((Request.QueryString["key_word"] != null) && (Request.QueryString["key_word"] != ""))
            {
                key_word = Request.QueryString["key_word"].Trim();
                loc += "&key_word=" + key_word + "";
            }
            if ((Request.QueryString["category"] != null) && (Request.QueryString["category"] != ""))
            {
                category = Request.QueryString["category"].Trim();
                loc += "&category=" + category + "";
            }
            if ((Request.QueryString["ddlcountry"] != null) && (Request.QueryString["ddlcountry"] != ""))
            {
                ddlcountry = Request.QueryString["ddlcountry"].Trim();
                loc += "&ddlcountry=" + ddlcountry + "";
            }
            if ((Request.QueryString["ddlState"] != null) && (Request.QueryString["ddlState"] != ""))
            {
                ddlState = Request.QueryString["ddlState"].Trim();
                loc += "&ddlState=" + ddlState + "";
            }
            if ((Request.QueryString["PhuongXa"] != null) && (Request.QueryString["PhuongXa"] != ""))
            {
                PhuongXa = Request.QueryString["PhuongXa"].Trim();
                loc += "&PhuongXa=" + PhuongXa + "";
            }
            if ((Request.QueryString["building_orientation"] != null) && (Request.QueryString["building_orientation"] != ""))
            {
                building_orientation = Request.QueryString["building_orientation"].Trim();
                loc += "&building_orientation=" + building_orientation + "";
            }
            if ((Request.QueryString["min_price"] != null) && (Request.QueryString["min_price"] != ""))
            {
                min_price = Request.QueryString["min_price"].Trim();
                loc += "&min_price=" + min_price + "";
            }
            if ((Request.QueryString["max_price"] != null) && (Request.QueryString["max_price"] != ""))
            {
                max_price = Request.QueryString["max_price"].Trim();
                loc += "&max_price=" + max_price + "";
            }
            //  Response.Write("aaaa:" + key_word + category + ddlcountry);
            String chuois = "";
            //if (demand != "0" && category == "0")
            //{
            //    chuois = " and icid in (" + More.MenuDacap(demand) + ") ";
            //}
            //else

            if (demand != "0" && category != "0")
            {
                chuois = " and icid in (" + Commond.SubMenu(More.PR, category) + ") ";
            }
            if (ddlcountry != "0")
            {
                chuois = " and Thanhpho = " + ddlcountry + " ";
            }
            if (ddlState != "0")
            {
                chuois = " and Quanhuyen = " + ddlState + " ";
            }
            if (PhuongXa != "0")
            {
                chuois = " and Phuongxa = " + PhuongXa + " ";
            }
            if (building_orientation != "0")
            {
                chuois = " and HuongNha = " + building_orientation + " ";
            }
            if (min_price != "0" && max_price != "0")
            {
                // and ((Price between (112000) and (112000)) OR (Price between (00000) and (00000)) )
                chuois += "  and ((Price between (" + min_price + ") and (" + max_price + ")) )";
            }
            if (min_price != "0" && max_price == "0")
            {
                chuois += "  and (Price >= '" + min_price + "' )";
            }
            if (min_price == "0" && max_price != "0")
            {
                chuois += "  and (Price <= '" + max_price + "' )";
            }

            // Response.Write("SELECT " + Commond.Sql_Product() + " FROM products WHERE (search LIKE N'" + VS.ECommerce_MVC.cms.View.ExecuteSQL.SearchApproximate.Exec(VS.ECommerce_MVC.cms.View.ExecuteSQL.ConvertVN.Convert(key_word.Replace("All", ""))) + "') " + chuois + " and lang='" + language + "' and Status=1");
            int Tongsobanghi = 0;
            Int16 pages = 1;
            int Tongsotrang = int.Parse(Commond.Setting("pagepro"));

            if ((Request.QueryString["page"] != null) && (Request.QueryString["page"] != ""))
            {
                pages = Convert.ToInt16(Request.QueryString["page"].Trim());
            }
            List<Entity.Category_Product> iitem = SProducts.SearchPro_locTongbanghi(key_word, Commond.SubMenu(More.PR, category), chuois, language, "1");
            if (iitem.Count() > 0)
            {
                Tongsobanghi = iitem.Count();
            }
            List<Entity.Category_Product> dt = SProducts.SearchPro_loc(key_word, Commond.SubMenu(More.PR, category), chuois, language, "1", (pages - 1), Tongsotrang);
            if (dt.Count >= 1)
            {
                ViewBag.ShowList = Commond.LoadProductList(dt);
            }
            else
            {
                ViewBag.ShowList = "<div class='Checkdata'>Không tìm thấy dữ liệu</div>";
            }
            if (Tongsobanghi % Tongsotrang > 0)
            {
                Tongsobanghi = (Tongsobanghi / Tongsotrang) + 1;
            }
            else
            {
                Tongsobanghi = Tongsobanghi / Tongsotrang;
            }
            ViewBag.Phantrang = Commond.Phantrang_loc("/tim-kiem.html", loc, Tongsobanghi, pages);
            return View();
        }

        public ActionResult TinhThanh(string hp)
        {
            string TinhThanh = "";
            if (hp == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            #region Menu
            var table = db.Tinhthanhs.SingleOrDefault(p => p.TangName == hp);
            if (table == null)
            {
                Commond.Link301();
            }
            else if (table != null)
            {
                ViewBag.Name = table.Name.ToString();
            }
            #endregion

            if (hp != "0")
            {
                TinhThanh = " and Thanhpho = " + Commond.ShowTinhThanhID(hp) + " ";
            }
            int Tongsobanghi = 0;
            Int16 pages = 1;
            int Tongsotrang = int.Parse(Commond.Setting("pagepro"));

            if ((Request.QueryString["page"] != null) && (Request.QueryString["page"] != ""))
            {
                pages = Convert.ToInt16(Request.QueryString["page"].Trim());
            }
            List<Entity.Category_Product> iitem = SProducts.SearchPro_locTongbanghi("", "", TinhThanh, language, "1");
            if (iitem.Count() > 0)
            {
                Tongsobanghi = iitem.Count();
            }
            List<Entity.Category_Product> dt = SProducts.SearchPro_loc("", "", TinhThanh, language, "1", (pages - 1), Tongsotrang);
            if (dt.Count >= 1)
            {
                ViewBag.ShowList = Commond.LoadProductList(dt);
            }
            else
            {
                ViewBag.ShowList = "<div class='Checkdata'>Không tìm thấy dữ liệu</div>";
            }
            if (Tongsobanghi % Tongsotrang > 0)
            {
                Tongsobanghi = (Tongsobanghi / Tongsotrang) + 1;
            }
            else
            {
                Tongsobanghi = Tongsobanghi / Tongsotrang;
            }
            ViewBag.Phantrang = Commond.Phantrang("/tinh-thanh.html", Tongsobanghi, pages);
            return View();
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}