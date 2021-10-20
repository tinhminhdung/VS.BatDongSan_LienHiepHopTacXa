using Common;
using Entity;
using Framwork;
using MoreAll;
using NganLuongAPI;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VS.ECommerce_MVC.Controllers
{
    public class CartController : Controller
    {
        DataTable dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
        private string language = Captionlanguage.SetLanguage();
        DatalinqDataContext db = new DatalinqDataContext();

        private string merchantId = ConfigHelper.GetByKey("MerchantId");
        private string merchantPassword = ConfigHelper.GetByKey("MerchantPassword");
        private string merchantEmail = ConfigHelper.GetByKey("MerchantEmail");

        public ActionResult BillMail()
        {
            return View();
        }

        [HttpGet]
        public ActionResult demo()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult demo(FormCollection collect)
        {
            string MyModelData = "";
            var content = RenderPartialViewToString("BillMail", MyModelData);
            //content = content.Replace("{{CustomerName}}", shipName);
            //content = content.Replace("{{Phone}}", mobile);
            //content = content.Replace("{{Email}}", email);
            //content = content.Replace("{{Address}}", address);
            //content = content.Replace("{{Total}}", total.ToString("N0"));
            var toEmail = "nvietdung1109@gmail.com";
            // new MailHelper().SendMail(email, "Đơn hàng mới từ OnlineShop", content);
            new MailHelper().SendMail(toEmail, "Đơn hàng mới từ OnlineShop", content);
            return View();
        }
        protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");
            ViewData.Model = model;
            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                return sw.GetStringBuilder().ToString();
            }
        }


        #region Trang gio hang.html
        public ActionResult XemGioHang()
        {
            if (System.Web.HttpContext.Current.Session["language"] != null)
            {
                this.language = System.Web.HttpContext.Current.Session["language"].ToString();
            }
            else
            {
                System.Web.HttpContext.Current.Session["language"] = this.language;
                this.language = System.Web.HttpContext.Current.Session["language"].ToString();
            }
            LoadCart();
            return View();
        }
        #endregion

        public string LoadCart()
        {
            if (Session["cart"] != null)
            {
                DataTable dtcart = (DataTable)Session["cart"];
                if (dtcart.Rows.Count > 0)
                {
                    string inumofproducts = "";
                    string totalvnd = "";
                    if (dtcart.Rows.Count > 0)
                    {
                        double num = 0.0;
                        int num2 = 0;
                        for (int i = 0; i < dtcart.Rows.Count; i++)
                        {
                            num += Convert.ToDouble(dtcart.Rows[i]["money"].ToString());
                            num2 += Convert.ToInt32(dtcart.Rows[i]["Quantity"].ToString());
                        }
                        totalvnd = num.ToString();
                        inumofproducts = num2.ToString();
                    }
                    ViewBag.TongTien = totalvnd.ToString();
                    ViewBag.totalvnd = AllQuery.MorePro.FormatMoney_Cart_Total(totalvnd.ToString());
                    ViewBag.numberofproducts = inumofproducts;
                    float total = 0;
                    for (int i = 0; i < dtcart.Rows.Count; i++)
                    {
                        total += Convert.ToSingle(dtcart.Rows[i]["Money"]);
                    }
                    ViewBag.pncart = "display: block";
                    // this.pnOrder.Visible = false;
                    ViewBag.pnmessage = "display: none";
                }
                else
                {
                    // this.pnOrder.Visible = false;
                    ViewBag.pncart = "display: none";
                    ViewBag.pnmessage = "display: block";
                }
            }
            else
            {
                // this.pnOrder.Visible = false;
                ViewBag.pncart = "display: none";
                ViewBag.pnmessage = "display: block";
            }
            return "";
        }

        public ActionResult ThemSoLuong(string id, string SoLuong)
        {
            dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
            SessionCarts.Cart_Updatequantity(ref dtcart, id, SoLuong);
            System.Web.HttpContext.Current.Session["cart"] = dtcart;
            return RedirectToAction("index");
        }

        public ActionResult XoaToanBoGioHang()
        {
            System.Web.HttpContext.Current.Session["cart"] = null;
            //  base.Response.Redirect("/Message.html");
            return Redirect("/Message-removecart.html");
        }

        public ActionResult XoaGioHang(string id)
        {
            dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
            SessionCarts.ShoppingCart_RemoveProduct(id);
            System.Web.HttpContext.Current.Session["cart"] = dtcart;
            return Redirect("/gio-hang.html");
        }

        #region Trang Đặt hàng
        [HttpGet]
        public ActionResult DatHang()
        {
            try
            {
                if (MoreAll.MoreAll.GetCookies("MembersID").ToString() != "")
                {
                    List<Member> dt = db.Members.Where(p => p.ID == int.Parse(MoreAll.MoreAll.GetCookies("MembersID").ToString())).ToList();
                    if (dt != null)
                    {
                        ViewBag.Name = dt[0].HoVaTen;
                        ViewBag.Address = dt[0].DiaChi;
                        ViewBag.Email = dt[0].Email;
                        ViewBag.Phone = dt[0].DienThoai;
                        ViewBag.IDThanhVien = dt[0].ID.ToString();
                    }
                }
            }
            catch (Exception)
            {

            }
            LoadCart();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult DatHang(FormCollection collect)
        {
            string TenKH = collect["TenKH"];
            string DiaChi = collect["DiaChi"];
            string SoDienThoai = collect["SoDienThoai"];
            string Email = collect["Email"];
            string Noidung = collect["Noidung"];
            string IDThanhVien = collect["hdIDThanhVien"];
            LoadCart();
            try
            {
                if (!Commond.Setting("Emailden").Equals(""))
                {
                    Senmail(TenKH, DiaChi, SoDienThoai, Email, Noidung);
                }
            }
            catch (Exception)
            { }
            ThanhtoanGiohang(TenKH, DiaChi, SoDienThoai, Email, Noidung, IDThanhVien);

            System.Web.HttpContext.Current.Session["cartid"] = null;
            System.Web.HttpContext.Current.Session["cart"] = null;
            System.Web.HttpContext.Current.Session["Session_Size"] = null;
            System.Web.HttpContext.Current.Session["Session_MauSac"] = null;
            return Redirect("/Message-Ordersucess.html");
        }
        protected void ThanhtoanGiohang(string TenKH, string DiaChi, string SoDienThoai, string Email, string Noidung, string IDThanhVien)
        {
            string thanhvien = "0";
            if (IDThanhVien != "")
            {
                thanhvien = IDThanhVien;
            }
            // 1. them gio hang
            string inumofproducts = "0";
            string totalvnd = "0";
            DataTable dtcart = new DataTable();
            dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
            if (dtcart.Rows.Count > 0)
            {
                double num = 0.0;
                int num2 = 0;
                for (int i = 0; i < dtcart.Rows.Count; i++)
                {
                    num += Convert.ToDouble(dtcart.Rows[i]["money"].ToString());
                    num2 += Convert.ToInt32(dtcart.Rows[i]["Quantity"].ToString());
                }
                totalvnd = num.ToString();
                inumofproducts = num2.ToString();
            }

            string chuoi1 = "";
            string chuoi2 = "";
            // 2. them chi tiet gio hang
            Carts obj = new Carts();
            #region MyRegion
            //TenKH,DiaChi,SoDienThoai,Email,Noidung
            obj.Name = TenKH.Trim();
            obj.Address = DiaChi.Trim();
            obj.Phone = SoDienThoai.Trim();
            obj.Email = Email.Trim();
            obj.Contents = Noidung.Trim();
            obj.Create_Date = Convert.ToDateTime(DateTime.Now.ToString());
            obj.Money = int.Parse(totalvnd);
            obj.lang = language;
            obj.Status = 0;
            #endregion

            int cartid = FCarts.Insert(TenKH.Trim(), DiaChi.Trim(), SoDienThoai.Trim(), Email.Trim(), Noidung.Trim(), totalvnd, language, "0", chuoi1, chuoi2, "0", thanhvien);
            Entity.CartDetail oj = new Entity.CartDetail();
            if (Session["cart"] != null)
            {
                for (int i = 0; i < dtcart.Rows.Count; i++)
                {
                    #region MyRegion
                    oj.ID_Cart = int.Parse(cartid.ToString());
                    oj.ipid = int.Parse(dtcart.Rows[i]["PID"].ToString());
                    oj.Price = Convert.ToSingle(dtcart.Rows[i]["Price"].ToString());
                    oj.Quantity = int.Parse(dtcart.Rows[i]["Quantity"].ToString());
                    oj.Money = Convert.ToSingle(dtcart.Rows[i]["Money"].ToString());
                    oj.Mausac = int.Parse(dtcart.Rows[i]["Mausac"].ToString());
                    oj.Kichco = int.Parse(dtcart.Rows[i]["Kichco"].ToString());
                    oj.IDThanhVien = int.Parse(thanhvien);
                    #endregion
                    SCartDetail.CartDetail_Insert(oj);
                }
            }

            Session["cartid"] = cartid;

            //System.Web.HttpContext.Current.Session["cart"] = null;
            //System.Web.HttpContext.Current.Session["Session_Size"] = null;
            //System.Web.HttpContext.Current.Session["Session_MauSac"] = null;
            //base.Response.Redirect("/Message-Ordersucess.html");
        }
        protected void Senmail(string TenKH, string DiaChi, string SoDienThoai, string EEmail, string Noidung)
        {
            try
            {
                System.Text.StringBuilder strb = new System.Text.StringBuilder();
                strb.AppendLine("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"color: rgb(0, 0, 0); font-family: &quot;Times New Roman&quot;; font-size: medium; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial; border-collapse: collapse; width: 569pt;\" width=\"758\">");
                strb.AppendLine("   <tr height=\"32\" style=\"height: 24pt;\">");
                strb.AppendLine("       <td colspan=\"7\" height=\"32\" style=\"border-style: none; border-color: inherit; border-width: medium; padding: 0px; color: black; font-size: 12pt; font-weight: 700; font-style: normal; text-decoration: none; ; vertical-align: middle; white-space: nowrap; text-align: center; height: 24pt;\"></td>");
                strb.AppendLine("   </tr>");
                strb.AppendLine("   <tr height=\"32\" style=\"height: 24pt;\">");
                strb.AppendLine("       <td colspan=\"7\" height=\"32\" style=\"border-style: none; border-color: inherit; border-width: medium; padding: 0px; color: black; font-size: 12pt; font-weight: 700; font-style: normal; text-decoration: none; ; vertical-align: middle; white-space: nowrap; text-align: center; height: 24pt;\">BẢNG CHI TIẾT ĐƠN HÀNG (" + DateTime.Now + ")</td>");
                strb.AppendLine("   </tr>");
                strb.AppendLine("   <tr height=\"32\" style=\"height: 24pt;\">");
                strb.AppendLine("       <td colspan=\"7\" height=\"32\" style=\"border-style: none; border-color: inherit; border-width: medium; padding: 0px; color: black; font-size: 12pt; font-weight: 700; font-style: normal; text-decoration: none; ; vertical-align: middle; white-space: nowrap; text-align: left; height: 24pt;\"><b>Website</b>: <span style=\"color:red\">" + MoreAll.MoreAll.RequestUrl(Request.Url.Authority) + "</span><br /></td>");
                strb.AppendLine("   </tr>");
                strb.AppendLine("   <tr height=\"26\" style=\"height: 19.5pt;\">");
                strb.AppendLine("       <td colspan=\"7\" height=\"26\" style=\"border-style: none; border-color: inherit; border-width: medium; padding: 0px; color: black; font-size: 10pt; font-weight: 400; font-style: normal; text-decoration: none; ; vertical-align: middle; white-space: nowrap; text-align: left; height: 19.5pt;\"><b>Khách hàng</b>: " + TenKH + "</td>");
                strb.AppendLine("   </tr>");
                strb.AppendLine("   <tr height=\"26\" style=\"height: 19.5pt;\">");
                strb.AppendLine("       <td colspan=\"7\" height=\"26\" style=\"border-style: none; border-color: inherit; border-width: medium; padding: 0px; color: black; font-size: 10pt; font-weight: 400; font-style: normal; text-decoration: none; ; vertical-align: middle; white-space: nowrap; text-align: left; height: 19.5pt;\"><b>Địa chỉ</b>: " + DiaChi + "</td>");
                strb.AppendLine("   </tr>");
                strb.AppendLine("   <tr height=\"26\" style=\"height: 19.5pt;\">");
                strb.AppendLine("       <td colspan=\"7\" height=\"26\" style=\"border-style: none; border-color: inherit; border-width: medium; padding: 0px; color: black; font-size: 10pt; font-weight: 400; font-style: normal; text-decoration: none; ; vertical-align: middle; white-space: nowrap; text-align: left; height: 19.5pt;\"><b>Điện thoại</b>: " + SoDienThoai + "</td>");
                strb.AppendLine("   </tr>");
                strb.AppendLine("   <tr height=\"26\" style=\"height: 19.5pt;\">");
                strb.AppendLine("       <td  colspan=\"7\" height=\"26\" style=\"border-style: none; border-color: inherit; border-width: medium; padding: 0px; color: black; font-size: 10pt; font-weight: 400; font-style: normal; text-decoration: none; ; vertical-align: middle; white-space: nowrap; text-align: left; height: 19.5pt;\"><b>Email</b>: " + EEmail + "</td>");
                strb.AppendLine("   </tr>");
                //try
                //{
                //    strb.AppendLine("    <tr height=\"26\" style=\"height: 19.5pt;\">");
                //    strb.AppendLine("       <td  colspan=\"7\" height=\"26\" style=\"border-style: none; border-color: inherit; border-width: medium; padding: 0px; color: black; font-size: 10pt; font-weight: 400; font-style: normal; text-decoration: none; ; vertical-align: middle; white-space: nowrap; text-align: left; height: 19.5pt;\"><b>Phương thức vận chuyển</b>: " + Session["Phuongthucvanchuyen"] + "</td>");
                //    strb.AppendLine("   </tr>");

                //    strb.AppendLine("    <tr height=\"26\" style=\"height: 19.5pt;\">");
                //    strb.AppendLine("       <td  colspan=\"7\" height=\"26\" style=\"border-style: none; border-color: inherit; border-width: medium; padding: 0px; color: black; font-size: 10pt; font-weight: 400; font-style: normal; text-decoration: none; ; vertical-align: middle; white-space: nowrap; text-align: left; height: 19.5pt;\"><b>Hình thức vận chuyển</b>: " + Session["Hinhthucthanhtoan"] + "</td>");
                //    strb.AppendLine("   </tr>");
                //}
                //catch (Exception)
                //{ }
                strb.AppendLine("      <tr height=\"26\" style=\"height: 19.5pt;\">");
                strb.AppendLine("       <td  colspan=\"7\" height=\"26\" style=\"border-style: none; border-color: inherit; border-width: medium; padding: 0px; color: black; font-size: 10pt; font-weight: 400; font-style: normal; text-decoration: none; ; vertical-align: middle; white-space: nowrap; text-align: left; height: 19.5pt;\"><b>Nội dung</b> : " + Noidung + "</td>");
                strb.AppendLine("   </tr>");
                strb.AppendLine("      <tr height=\"26\" style=\"height: 19.5pt;\">");
                strb.AppendLine("       <td  colspan=\"7\" height=\"26\" style=\"border-style: none; border-color: inherit; border-width: medium; padding: 0px; color: black; font-size: 10pt; font-weight: 400; font-style: normal; text-decoration: none; ; vertical-align: middle; white-space: nowrap; text-align: left; height: 19.5pt; color:red; font-weight:bold; text-transform:uppercase\">Thông tin đơn hàng:</td>");
                strb.AppendLine("   </tr>");
                strb.AppendLine("   <tr height=\"45\" style=\"height: 33.75pt;\">");
                strb.AppendLine("       <td height=\"45\" style=\"border-style: solid; border-color: windowtext; border-width: 1pt 0.5pt 1pt 1pt; padding: 0px; color: black; font-size: 10pt; font-weight: 700; font-style: normal; text-decoration: none; ; vertical-align: middle; white-space: nowrap; text-align: center; height: 33.75pt;\">STT</td>");
                strb.AppendLine("       <td  style=\"border-style: solid none; border-top-color: windowtext; border-right-color: inherit; border-bottom-color: windowtext; border-left-color: inherit; border-width: 1pt medium; padding: 0px; color: black; font-size: 10pt; font-weight: 700; font-style: normal; text-decoration: none; ; vertical-align: middle; white-space: nowrap; text-align: center;\">Mã SP</td>");
                strb.AppendLine("       <td style=\"border-style: solid none solid solid; border-top-color: windowtext; border-right-color: inherit; border-bottom-color: windowtext; border-left-color: windowtext; border-width: 1pt medium 1pt 0.5pt; padding: 0px; color: black; font-size: 10pt; font-weight: 700; font-style: normal; text-decoration: none; ; vertical-align: middle; white-space: normal; text-align: center; width: 210pt;\" width=\"280\">Tên sản phẩm</td>");
                strb.AppendLine("       <td style=\"border-style: solid; border-color: windowtext; border-width: 1pt 0.5pt; padding: 0px; color: black; font-size: 10pt; font-weight: 700; font-style: normal; text-decoration: none; ; vertical-align: middle; white-space: normal; text-align: center; width: 100px;\" width=\"53\">Số lượng</td>");
                strb.AppendLine("       <td style=\"border-style: solid; border-color: windowtext; border-width: 1pt 0.5pt; padding: 0px; color: black; font-size: 10pt; font-weight: 700; font-style: normal; text-decoration: none; ; vertical-align: middle; white-space: normal; text-align: center; width: 100px;\" width=\"50\">Đ.Vtính</td>");
                strb.AppendLine("       <td style=\"border-style: solid; border-color: windowtext; border-width: 1pt 0.5pt; padding: 0px; color: black; font-size: 10pt; font-weight: 700; font-style: normal; text-decoration: none; ; vertical-align: middle; white-space: normal; text-align: center; width: 100px;\" width=\"65\">Đơn giá</td>");
                strb.AppendLine("       <td style=\"border-style: solid; border-color: windowtext; border-width: 1pt 1pt 1pt 0.5pt; padding: 0px; color: black; font-size: 10pt; font-weight: 700; font-style: normal; text-decoration: none; ; vertical-align: middle; white-space: normal; text-align: center; width: 150pt;\">Thành tiền</td>");
                strb.AppendLine("   </tr>");
                DataTable dtcart = new DataTable();
                dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
                if (Session["cart"] != null)
                {
                    if (dtcart.Rows.Count > 0)
                    {
                        int j = 1;
                        for (int i = 0; i < dtcart.Rows.Count; i++)
                        {
                            strb.AppendLine("   <tr height=\"28\" style=\"height: 21pt;\">");
                            strb.AppendLine("       <td height=\"28\" style=\"border: 1px solid rgb(0, 0, 0); padding: 0px; color: black; font-size: 10pt; font-weight: 400; font-style: normal; text-decoration: none; ; vertical-align: middle; white-space: nowrap; text-align: center; height: 21pt;\">" + j++ + "</td>");
                            strb.AppendLine("       <td style=\"border: 1px solid rgb(0, 0, 0); padding: 0px; color: black; font-size: 10pt; font-weight: 400; font-style: normal; text-decoration: none; ; vertical-align: middle; white-space: nowrap; text-align: center;\">" + Name_Code(dtcart.Rows[i]["PID"].ToString(), i) + "</td>");
                            strb.AppendLine("       <td style=\"border: 1px solid rgb(0, 0, 0); padding: 0px; color: black; font-size: 10pt; font-weight: 400; font-style: normal; text-decoration: none; ; vertical-align: middle; white-space: nowrap; text-align: left;\">" + Name_Product(dtcart.Rows[i]["PID"].ToString(), i) + "</td>");
                            strb.AppendLine("       <td style=\"border: 1px solid rgb(0, 0, 0); padding: 0px; color: black; font-size: 10pt; font-weight: 400; font-style: normal; text-decoration: none; ; vertical-align: middle; white-space: nowrap; text-align: center;\">" + dtcart.Rows[i]["Quantity"].ToString() + "</td>");
                            strb.AppendLine("       <td style=\"border: 1px solid rgb(0, 0, 0); padding: 0px; color: black; font-size: 10pt; font-weight: 400; font-style: normal; text-decoration: none; ; vertical-align: middle; white-space: nowrap; text-align: center;\">VNĐ</td>");
                            strb.AppendLine("       <td  style=\"border: 1px solid rgb(0, 0, 0); padding: 0px; color: black; font-size: 10pt; font-weight: 400; font-style: normal; text-decoration: none; ; vertical-align: middle; white-space: normal; text-align: center; width: 49pt;\" width=\"65\">" + AllQuery.MorePro.FormatMoney_NO(dtcart.Rows[i]["Price"].ToString()) + "</td>");
                            strb.AppendLine("       <td style=\"border: 1px solid rgb(0, 0, 0); padding: 0px; color: black; font-size: 11pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; vertical-align: bottom; white-space: nowrap; text-align: center;\" width=\"76\">" + AllQuery.MorePro.FormatMoney_NO(dtcart.Rows[i]["Money"].ToString()) + "</td>");
                            strb.AppendLine("   </tr>");
                        }
                    }
                }
                string Soluong = "0";
                string Tongtien = "0";
                dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
                if (dtcart.Rows.Count > 0)
                {
                    double num = 0.0;
                    int num2 = 0;
                    for (int i = 0; i < dtcart.Rows.Count; i++)
                    {
                        num += Convert.ToDouble(dtcart.Rows[i]["money"].ToString());
                        num2 += Convert.ToInt32(dtcart.Rows[i]["Quantity"].ToString());
                    }
                    Tongtien = num.ToString();
                    Soluong = num2.ToString();
                }
                strb.AppendLine("   <tr height=\"33\" style=\"height: 24.75pt;\">");
                strb.AppendLine("       <td height=\"33\" style=\"border-style: solid none solid solid; border-top-color: windowtext; border-right-color: inherit; border-bottom-color: windowtext; border-left-color: windowtext; border-width: 0.5pt medium 0.5pt 1pt; padding: 0px; color: black; font-size: 10pt; font-weight: 700; font-style: normal; text-decoration: none; ; vertical-align: middle; white-space: nowrap; text-align: center; height: 24.75pt;\">&nbsp;</td>");
                strb.AppendLine("       <td  colspan=\"2\" style=\"border: 1px solid rgb(0, 0, 0); font-size: 10pt; font-weight: 700; font-style: normal; text-align: center;\">Tổng cộng</td>");
                strb.AppendLine("       <td style=\"border: 0.5pt solid windowtext; padding: 0px; color: black; font-size: 10pt; font-weight: 700; font-style: normal; text-decoration: none; ; vertical-align: middle; white-space: nowrap; text-align: center;\">" + Soluong + "</td>");
                strb.AppendLine("       <td colspan=\"2\" style=\"border: 0.5pt solid windowtext; padding: 0px; color: black; font-size: 10pt; font-weight: 700; font-style: normal; text-decoration: none; ; vertical-align: middle; white-space: nowrap; text-align: center;\">&nbsp;</td>");
                strb.AppendLine("       <td  colspan=\"1\" style=\"border-style: solid; border-color: windowtext; border-width: 0.5pt 1px 0.5pt 0.5pt; padding: 0px; color: black; font-size: 10pt; font-weight: 700; font-style: normal; text-decoration: none; ; vertical-align: middle; white-space: nowrap; text-align: center; border-image: initial;\">" + AllQuery.MorePro.FormatMoney_NO(Tongtien) + " VNĐ</td>");
                strb.AppendLine("   </tr>");
                strb.AppendLine("   <tr height=\"39\" style=\"height: 29.25pt;\">");
                strb.AppendLine("       <td  colspan=\"7\" style=\"font-size: 10pt; font-weight: 700; font-style: normal; border: 1px solid rgb(0, 0, 0);  text-align: center;color:red\">Tổng số tiền (viết bằng chữ): " + MoreAll.Hamdoisorachu.So_chu(Convert.ToDouble(Tongtien)) + ".</td>");
                strb.AppendLine("   </tr>");
                strb.AppendLine("</table>");

                string email = Email.email();
                string password = Email.password();
                int port = Convert.ToInt32(Email.port());
                string host = Email.host();
                MailUtilities.SendMail("Thông tin đặt hàng trên website " + Request.Url.Host + " từ: " + TenKH, email, password, Commond.Setting("Emailden"), host, port, "Thông tin đặt hàng trên website " + Request.Url.Host + " từ: " + TenKH, strb.ToString());
                // MailUtilities.SendMail("Thông tin đặt hàng trên website " + Request.Url.Host + " từ: " + txtName.Text, email, password, txtEmail.Text.Trim(), host, port, "Thông tin đặt hàng trên website " + Request.Url.Host + " từ: " + txtName.Text, strb.ToString());
            }
            catch (Exception)
            { }
        }
        public string Name_Product(string pid, int i)
        {
            string code = "";
            DataTable dt = new DataTable();
            SProducts.Detail_ID(dt, pid);
            if (dt.Rows.Count > 0)
            {
                code = dt.Rows[0]["Name"].ToString();
            }
            return code;
        }
        public string Name_Code(string pid, int i)
        {
            string code = "";
            DataTable dt = new DataTable();
            SProducts.Detail_ID(dt, pid);
            if (dt.Rows.Count > 0)
            {
                code = dt.Rows[0]["Code"].ToString();
            }
            return code;
        }
        #endregion

        #region Trang Thông báo
        public ActionResult Message(string msg)
        {
            if (msg == "Ordersucess")// Cảm ơn bạn đặt đặt hàng
            {
                ViewBag.Message = Commond.label("l_produc_our_place");
            }
            else if (msg == "removecart")// bị xóa
            {
                ViewBag.Message = Commond.label("l_produc_Canceled_order");
            }
            else if (msg == "successful")// Đặt hàng thành công 
            {
                ViewBag.Message = Commond.label("l_produc_Order_successful");
            }
            return View();
        }
        #endregion

        public ActionResult ConfirmOrder()
        {
            string token = Request["token"];
            RequestCheckOrder info = new RequestCheckOrder();
            info.Merchant_id = merchantId;
            info.Merchant_password = merchantPassword;
            info.Token = token;
            APICheckoutV3 objNLChecout = new APICheckoutV3();
            ResponseCheckOrder result = objNLChecout.GetTransactionDetail(info);
            if (result.errorCode == "00")
            {

                // xem 3mpic.vn
                // StatusGiaoDich chưa làm trong admin và chưa tét nhé
                SCarts.Name_Text("UPDATE [Carts] SET [Status]=1,StatusGiaoDich=1  WHERE ID=" + result.order_code + "");
                //update status order
                //_orderService.UpdateStatus(int.Parse(result.order_code));
                //_orderService.Save();

                ViewBag.IsSuccess = true;
                ViewBag.Result = "Thanh toán thành công. Chúng tôi sẽ liên hệ lại sớm nhất.";
            }
            else
            {
                ViewBag.IsSuccess = true;
                ViewBag.Result = "Có lỗi xảy ra. Vui lòng liên hệ admin.";
            }
            return View();
        }
        public ActionResult CancelOrder()
        {
            return View();
        }
    }
}