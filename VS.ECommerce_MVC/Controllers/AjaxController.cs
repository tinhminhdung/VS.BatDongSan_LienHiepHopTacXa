using Entity;
using Framwork;
using MoreAll;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VS.ECommerce_MVC.Controllers
{
    public class AjaxController : Controller
    {
        private string language = Captionlanguage.SetLanguage();
        DatalinqDataContext db = new DatalinqDataContext();
        public const string PARTIAL_VIEW_FOLDER = "~/Views/Partials/Contact/";
        // link sẽ là http://localhost:63136/Ajax/AddToCart
        /// link -> Ajax/AddToCart

        [HttpGet]
        public ActionResult AddToCart(string ipid)
        {
            if (ipid != "")
            {
                List<Entity.Products> dt = SProducts.GetById(ipid);
                if (dt.Count > 0)
                {
                    SessionCarts.ShoppingCart_AddProduct_Sesion(ipid.ToString(), Convert.ToInt32("1"), "0", "0");
                }
                Response.Redirect("/gio-hang.html");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Box_TimKiem(FormCollection collect)
        {
            string txtkeyword = collect["txtkeyword"];
            MoreAll.MoreAll.SetCookie("Search", txtkeyword, 5000);
            Response.Redirect("/Search.html");
            return View();
        }

        [HttpPost]
        public ActionResult MuaHangTheoSoLuong(string Quantity, string ID)
        {
            if (ID != "")
            {
                List<Entity.Products> dt = SProducts.GetById(ID);
                if (dt.Count > 0)
                {
                    SessionCarts.ShoppingCart_AddProduct_Sesion(ID.ToString(), Convert.ToInt32(Quantity), "0", "0");
                }
                Response.Redirect("/gio-hang.html");
            }
            return View();
        }

        //Đặt hàng nhanh ở trang chi tiết
        [HttpPost]
        public ActionResult DatHangNhanh(FormCollection collect)
        {
            string txtQuantitys = collect["txtQuantitys"];
            string hdipid = collect["hdipid"];
            List<Entity.Products> dt = SProducts.GetById(hdipid);
            if (dt.Count > 0)
            {
                SessionCarts.ShoppingCart_AddProduct_Sesion(hdipid.ToString(), Convert.ToInt32(txtQuantitys), "0", "0");
            }
            Response.Redirect("/gio-hang.html");

            return View();
        }


        [HttpGet]
        public ActionResult NgonNgu(string language)
        {
            string value = Request["language"].ToString();
            System.Web.HttpContext.Current.Session["language"] = value;
            System.Web.HttpContext.Current.Response.Redirect("/");
            return View();
        }

        [HttpPost]
        public ActionResult CapNhatSoLuong(string productId, string quantity)
        {
            DataTable dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
            dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
            SessionCarts.Cart_Updatequantity(ref dtcart, productId, quantity);
            System.Web.HttpContext.Current.Session["cart"] = dtcart;
            Response.Redirect("/gio-hang.html");
            return View();
        }

        public ActionResult LoadAjaxActionLink()
        {
            return Content("Hello Ajax");
        }

        #region Gio hang PopUp


        [HttpGet]
        public string ShowCart()
        {
            string str = "";
            string tongien = "0";
            string sosp = "0";
            string inumofproducts = "0";
            string totalvnd = "0";
            if (System.Web.HttpContext.Current.Session["cart"] != null)
            {
                DataTable dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
                if (dtcart.Rows.Count > 0)
                {
                    str += "<div class=\"shop_cart ajax\">";
                    str += "<div id=\"Loadingshop\">";
                    str += "<div class=\"inner\"><img src=\"/Resources/ShopCart/images/ajax-loader_2.gif\"><p>Đang xử lý...</p></div>";
                    str += "</div>";
                    str += "<div class=\"title\">";
                    str += "<div class=\"tl txt_b\">Giỏ hàng của bạn (<span class=\"shopping_cart_item\">" + Services.SessionCarts.LoadCart() + "</span> sản phẩm)</div>";
                    str += "<input id=\"temp_total\" value=\"0\" type=\"hidden\">";
                    str += "</div>";


                    str += " <div id=\"popupCart\" class=\"clearfix\">";
                     str += "  <div class=\"content-popup-cart\">";
                     str += "    <div class=\"thead-popup\">";
                     str += "      <div style=\"width: 49.75%;\" class=\"text-left\">Sản phẩm</div>";
                     str += "      <div style=\"width: 15%;\" class=\"text-center\">Giá</div>";
                     str += "      <div style=\"width: 20%;\" class=\"text-center\">Số lượng</div>";
                     str += "      <div style=\"width: 15%;\" class=\"text-right\">Tổng tiền</div>";
                     str += "    </div>";

                     str += "    <div class=\"tbody-popup scrollbar-dynamic\">";

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
                     tongien = AllQuery.MorePro.FormatMoney_Cart_Total(totalvnd.ToString());
                     sosp = inumofproducts;
                     for (int i = 0; i < dtcart.Rows.Count; i++)
                     {
                         str += "      <div class=\"item-popup \">";
                         str += "        <div style=\"width: 15%;\" class=\"border height image_ text-left\">";
                         str += "          <div class=\"item-image\">";
                         str += "<img src=\"" + dtcart.Rows[i]["Vimg"].ToString() + "\" class='anhdaidienpop'>";
                         str += "          </div>";
                         str += "        </div>";
                         str += "        <div style=\"width:35%;\" class=\"height text-left\">";
                         str += "          <div class=\"item-info\">";
                         str += "            <p class=\"item-name\">";
                         str += "<a class=\"\" target=_blank href=\"" + AllQuery.MorePro.LoadLink(dtcart.Rows[i]["PID"].ToString()) + "\"><b>" + dtcart.Rows[i]["Name"].ToString() + "</b></a>";
                         str += "            </p>";
                         str += "<a class=\"i-del shows\" onclick=\"AJdeleteShoppingCartItem(" + dtcart.Rows[i]["PID"].ToString() + ",'" + dtcart.Rows[i]["Name"].ToString() + "')\"><img src=\"/Resources/ShopCart/images/xoa.png\" /> Bỏ sản phẩm</a>";
                         str += "          </div>";
                         str += "        </div>";
                         str += "        <div style=\"width: 15%;\" class=\"border height text-center\">";
                         str += "<div id=\"sell_price_pro_17876\">" + AllQuery.MorePro.FormatMoneyCart(dtcart.Rows[i]["Price"].ToString()) + "</div>";
                         str += "<div class=\"txt_d\">" + ShopGiacu(dtcart.Rows[i]["PID"].ToString()) + "</div>";
                       //  str += "<div class=\"txt_pink\">" + AllQuery.MorePro.Tietkiem(dtcart.Rows[i]["PID"].ToString()) + "</div>";
                         str += "        </div>";
                         str += "        <div style=\"width: 20%;\" class=\"border height text-center\">";
                         str += "          <div class=\"qty_thuongdq check_\">";
                         str += "<input type=\"number\" max=\"999\" min=\"0\" style=\" width:50px\"  value=\"" + dtcart.Rows[i]["Quantity"].ToString() + "\" onchange=\"AddShoppingCartItem(" + dtcart.Rows[i]["PID"].ToString() + ",'" + dtcart.Rows[i]["Name"].ToString() + "',$(this))\" class=\"txt_center cor3px shows\">";
                         str += "          </div>";
                         str += "        </div>";
                         str += "        <div style=\"width: 15%;\" class=\"border height text-right\">";
                         str += "          <span class=\"cart-price\">";
                         str += "            <span class=\"price\">" + AllQuery.MorePro.FormatMoneyCart(dtcart.Rows[i]["Money"].ToString()) + "</span>";
                         str += "          </span>";
                         str += "        </div>";

                         str += "        </div>";
                       
                     }
                     str += "      </div>";
                     str += "    </div>";
                     str += "  </div>";
                   
                    str += "<table class=\"tbl_cart\" style=\"\" cellpadding=\"5\">";
                    str += "<tbody>";
                    str += "<tr>";
                    str += "<td colspan=\"5\" class=\"txt_right\">";
                    str += "<div style=\"line-height: 26px;\">";
                    str += "Tổng cộng : <span class=\"sub1 txt_18 txt_pink total_value_step txt_b\" id=\"total_value\" data-value=\"" + tongien + "\">" + tongien + "</span><br>";
                    str += "<span id=\"other-discount\">Tổng số sản phẩm: <span data-discount=\"0\" id=\"price-discount\" class=\"txt_pink\">" + sosp + "</span></span><br>";
                    str += "<span>Thanh toán: <span id=\"total_shopping_price\" class=\"txt_pink txt_b total_value_step\">" + tongien + "</span></span>";
                    str += "<br>Giá đã bao gồm VAT";
                    str += "</div>";
                    str += "</td>";
                    str += "</tr>";
                    str += "<tr>";
                    str += "<td colspan=\"4\" class=\"txt_right\">";
                    str += "<a href=\"/\" class=\"txt_pink txt_18 txt_b\" style=\"float:left;\"><i class=\"fa fa-angle-left\"></i> Tiếp tục mua hàng</a>";
                    str += "<div style=\"float:right;\">";
                    //str += "<a class=\"btn bg_pink txt_center txt_20 txt_u\" href=\"/gio-hang.html\" style=\"padding:5px 50px;\">";
                    //str += "MUA ONLINE<br> <span class=\"txt_12\" style=\"text-transform: none;\">(giao hàng tận nơi)</span>";
                    //str += "</a>";
                    str += "<a class=\"adrbutton tienhanh\" href=\"/gio-hang.html\" >Tiến hành đặt hàng</a>";
                    str += "</div>";
                    str += "</td>";
                    str += "</tr>";
                    str += "</tbody>";
                    str += "</table>";
                    str += "</div> ";

                }
                else
                {
                    str += "<div class=\"shop_cart ajax\">";
                    str += "  <div class=\"num0\">";
                    str += " <div class=\"modalbodys cart_body\">";
                    str += "<i class=\"icon_cart\"></i>";
                    str += "<h2>Giỏ hàng của bạn hiện đang trống</h2>";
                    str += "<p>Hãy nhanh tay sở hữu những sản phẩm yêu thích của bạn</p>";
                    str += "<a class=\"adrbutton\" href=\"/\">Tiếp tục mua sắm</a>";
                    str += " </div>";
                    str += "  </div>";
                    str += "</div> ";
                }
            }
            else
            {
                str += "<div class=\"shop_cart ajax\">";
                str += "  <div class=\"num0\">";
                str += " <div class=\"modalbodys cart_body\">";
                str += "<i class=\"icon_cart\"></i>";
                str += "<h2>Giỏ hàng của bạn hiện đang trống</h2>";
                str += "<p>Hãy nhanh tay sở hữu những sản phẩm yêu thích của bạn</p>";
                str += "<a class=\"adrbutton\" href=\"/\">Tiếp tục mua sắm</a>";
                str += " </div>";
                str += "  </div>";
                str += "</div> ";
            }
            return (str.ToString());
        }



        //[HttpGet]
        //public string ShowCart()
        //{
        //    string str = "";
        //    string tongien = "0";
        //    string sosp = "0";
        //    string inumofproducts = "0";
        //    string totalvnd = "0";
        //    if (System.Web.HttpContext.Current.Session["cart"] != null)
        //    {
        //        DataTable dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
        //        if (dtcart.Rows.Count > 0)
        //        {
        //            str += "<div class=\"shop_cart ajax\">";
        //            str += "<div id=\"Loadingshop\">";
        //            str += "<div class=\"inner\"><img src=\"/Resources/ShopCart/images/ajax-loader_2.gif\"><p>Đang xử lý...</p></div>";
        //            str += "</div>";
        //            str += "<div class=\"title\">";
        //            str += "<div class=\"tl txt_b\">Giỏ hàng của bạn (<span class=\"shopping_cart_item\">" + Services.SessionCarts.LoadCart() + "</span> sản phẩm)</div>";
        //            str += "<input id=\"temp_total\" value=\"0\" type=\"hidden\">";
        //            str += "</div>";


        //            str += "<table class=\"tbl_cart\" style=\"\" cellpadding=\"5\">";
        //            str += "<tbody>";
        //            str += "<tr id=\"shopping-cart-first-row\" class=\"txt_u txt_14 txt_b\">";
        //            str += "<td  style=\"width: 367px;\">Sản phẩm</td>";
        //            str += "<td style=\"width: 174px;\" class=\"shopping-cart-price-col\">Đơn giá</td>";
        //            str += "<td style='width: 128px;' class=\"shopping-cart-quantity-col center\">Số lượng</td>";
        //            str += "<td style=\"text-align: right;width: 190px;\" class=\"shopping-cart-sum-col\">Thành tiền</td>";
        //            str += "</tr>";
                 
        //            if (dtcart.Rows.Count > 0)
        //            {
        //                double num = 0.0;
        //                int num2 = 0;
        //                for (int i = 0; i < dtcart.Rows.Count; i++)
        //                {
        //                    num += Convert.ToDouble(dtcart.Rows[i]["money"].ToString());
        //                    num2 += Convert.ToInt32(dtcart.Rows[i]["Quantity"].ToString());
        //                }
        //                totalvnd = num.ToString();
        //                inumofproducts = num2.ToString();
        //            }
        //            tongien = AllQuery.MorePro.FormatMoney_Cart_Total(totalvnd.ToString());
        //            sosp = inumofproducts;
        //            for (int i = 0; i < dtcart.Rows.Count; i++)
        //            {
        //                str += "<tr id=\"itm17876\">";
        //                str += "<td style=\"text-align: left;\">";
        //                str += "<div class=\"cartInfo-img fl\">";
        //                str += "<img src=\"" + dtcart.Rows[i]["Vimg"].ToString() + "\" style=\"vertical-align: middle; margin-right: 10px;width:60px;\">";
        //                str += "</div>";
        //                str += "<div class=\"sum\">";
        //                str += "<div class=\"cartInfo-name\">";
        //                str += "<a class=\"\" target=_blank href=\"" + AllQuery.MorePro.LoadLink(dtcart.Rows[i]["PID"].ToString()) + "\"><b>" + dtcart.Rows[i]["Name"].ToString() + "</b></a>";
        //                str += "<br>";
        //                str += "</div>";
        //                str += "<a class=\"i-del shows\" onclick=\"AJdeleteShoppingCartItem(" + dtcart.Rows[i]["PID"].ToString() + ",'" + dtcart.Rows[i]["Name"].ToString() + "')\"><img src=\"/Resources/ShopCart/images/xoa.png\" /> Bỏ sản phẩm</a>";
        //                str += "</div>";
        //                str += "</td>";
        //                str += "<td style=\"\">";
        //                str += "<span id=\"sell_price_pro_17876\">" + AllQuery.MorePro.FormatMoneyCart(dtcart.Rows[i]["Price"].ToString()) + "</span>";
        //                str += "<br><span class=\"txt_d\">" + ShopGiacu(dtcart.Rows[i]["PID"].ToString()) + "</span>";
        //                str += "<br><span class=\"txt_pink\">" + AllQuery.MorePro.Tietkiem(dtcart.Rows[i]["PID"].ToString()) + "</span>";
        //                str += "</td>";
        //                str += "<td class=\"center\">";
        //                //data-abc='123'
        //                str += "<input type=\"number\" max=\"999\" min=\"0\" style=\" width:50px\"  value=\"" + dtcart.Rows[i]["Quantity"].ToString() + "\" onchange=\"AddShoppingCartItem(" + dtcart.Rows[i]["PID"].ToString() + ",'" + dtcart.Rows[i]["Name"].ToString() + "',$(this))\" class=\"txt_center cor3px shows\">";
        //                str += "</td>";
        //                str += "<td style=\"text-align: right;\">";
        //                str += "<span id=\"price_pro_17876\">" + AllQuery.MorePro.FormatMoneyCart(dtcart.Rows[i]["Money"].ToString()) + "</span>";
        //                str += "</td>";
        //                str += "</tr>";
        //            }
                 
        //            str += "<tr>";
        //            str += "<td colspan=\"5\" class=\"txt_right\">";
        //            str += "<div style=\"line-height: 26px;\">";
        //            str += "Tổng cộng : <span class=\"sub1 txt_18 txt_pink total_value_step txt_b\" id=\"total_value\" data-value=\"" + tongien + "\">" + tongien + "</span><br>";
        //            str += "<span id=\"other-discount\">Tổng số sản phẩm: <span data-discount=\"0\" id=\"price-discount\" class=\"txt_pink\">" + sosp + "</span></span><br>";
        //            str += "<span>Thanh toán: <span id=\"total_shopping_price\" class=\"txt_pink txt_b total_value_step\">" + tongien + "</span></span>";
        //            str += "<br>Giá đã bao gồm VAT";
        //            str += "</div>";
        //            str += "</td>";
        //            str += "</tr>";
        //            str += "<tr>";
        //            str += "<td colspan=\"4\" class=\"txt_right\">";
        //            str += "<a href=\"/\" class=\"txt_pink txt_18 txt_b\" style=\"float:left;\"><i class=\"fa fa-angle-left\"></i> Tiếp tục mua hàng</a>";
        //            str += "<div style=\"float:right;\">";
        //            //str += "<a class=\"btn bg_pink txt_center txt_20 txt_u\" href=\"/gio-hang.html\" style=\"padding:5px 50px;\">";
        //            //str += "MUA ONLINE<br> <span class=\"txt_12\" style=\"text-transform: none;\">(giao hàng tận nơi)</span>";
        //            //str += "</a>";
        //            str += "<a class=\"adrbutton tienhanh\" href=\"/gio-hang.html\" >Tiến hành đặt hàng</a>";
        //            str += "</div>";
        //            str += "</td>";
        //            str += "</tr>";
        //            str += "</tbody>";
        //            str += "</table>";
        //            str += "</div> ";

        //        }
        //        else
        //        {
        //            str += "<div class=\"shop_cart ajax\">";
        //            str += "  <div class=\"num0\">";
        //            str += " <div class=\"modalbodys cart_body\">";
        //            str += "<i class=\"icon_cart\"></i>";
        //            str += "<h2>Giỏ hàng của bạn hiện đang trống</h2>";
        //            str += "<p>Hãy nhanh tay sở hữu những sản phẩm yêu thích của bạn</p>";
        //            str += "<a class=\"adrbutton\" href=\"/\">Tiếp tục mua sắm</a>";
        //            str += " </div>";
        //            str += "  </div>";
        //            str += "</div> ";
        //        }
        //    }
        //    else
        //    {
        //        str += "<div class=\"shop_cart ajax\">";
        //        str += "  <div class=\"num0\">";
        //        str += " <div class=\"modalbodys cart_body\">";
        //        str += "<i class=\"icon_cart\"></i>";
        //        str += "<h2>Giỏ hàng của bạn hiện đang trống</h2>";
        //        str += "<p>Hãy nhanh tay sở hữu những sản phẩm yêu thích của bạn</p>";
        //        str += "<a class=\"adrbutton\" href=\"/\">Tiếp tục mua sắm</a>";
        //        str += " </div>";
        //        str += "  </div>";
        //        str += "</div> ";
        //    }
        //    return (str.ToString());
        //}

        [HttpPost]
        public string Up_Order(string id, string quantity)
        {
            return ShoppingCart_AddProduct(id.ToString(), int.Parse(quantity));
        }

        public string ShoppingCart_AddProduct(string pid, int quantity)
        {
            if (System.Web.HttpContext.Current.Session["cart"] == null)
            {
                // create session cart.
                SessionCarts.ShoppingCreateCart();
                ShoppingCart_AddProduct(pid, quantity);
            }
            else
            {
                List<Products> dt = new List<Products>();
                // lay chi tiet san pham.
                dt = SProducts.GetById(pid);
                if (dt.Count > 0)
                {
                    string vimg = dt[0].Images.ToString();
                    string name = dt[0].Name.ToString();
                    string Mausac = "0";
                    string Kichco = "0";
                    try
                    {
                        if (System.Web.HttpContext.Current.Session["Session_Size"].ToString() != null && !System.Web.HttpContext.Current.Session["Session_Size"].ToString().Equals(""))
                        {
                            Kichco = System.Web.HttpContext.Current.Session["Session_Size"].ToString();
                        }
                    }
                    catch (Exception)
                    { }
                    try
                    {
                        if (System.Web.HttpContext.Current.Session["Session_MauSac"].ToString() != null && !System.Web.HttpContext.Current.Session["Session_MauSac"].ToString().Equals(""))
                        {
                            Mausac = System.Web.HttpContext.Current.Session["Session_MauSac"].ToString();
                        }
                    }
                    catch (Exception)
                    { }
                    if (!dt[0].Price.ToString().Equals(""))
                    {
                        float prices = 0;
                        float pricesi = 0;
                        if (dt[0].Price > 0)
                        {
                            prices = Convert.ToSingle(dt[0].Price);
                        }
                        float money = prices * quantity;
                        DataTable dtcart = new DataTable();
                        dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
                        bool hasincart = false;
                        for (int i = 0; i < dtcart.Rows.Count; i++)
                        {
                            if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
                            {
                                if (dtcart.Rows[i]["Price"].ToString().Length > 0)
                                {
                                    pricesi = Convert.ToSingle(dtcart.Rows[i]["Price"]);
                                }
                                hasincart = true;
                                // cap nhat thong tin cua cart.
                                quantity += Convert.ToInt32(dtcart.Rows[i]["Quantity"]);
                                dtcart.Rows[i]["Quantity"] = quantity;
                                dtcart.Rows[i]["Money"] = quantity * Convert.ToSingle(pricesi);
                                dtcart.Rows[i]["Mausac"] = Mausac;
                                dtcart.Rows[i]["Kichco"] = Kichco;
                                System.Web.HttpContext.Current.Session["cart"] = dtcart;
                                break;
                            }
                        }
                        if (hasincart == false)
                        {
                            if (dtcart != null)
                            {
                                DataRow dr = dtcart.NewRow();
                                dr["PID"] = pid;
                                dr["Vimg"] = vimg;
                                dr["Name"] = name;
                                dr["Price"] = prices;
                                dr["Quantity"] = quantity;
                                dr["Money"] = money;
                                dr["Mausac"] = Mausac;
                                dr["Kichco"] = Kichco;
                                dtcart.Rows.Add(dr);
                                System.Web.HttpContext.Current.Session["cart"] = dtcart;
                            }
                        }
                    }
                    else
                    {
                        float prices = 0; float pricesi = 0;
                        if (dt[0].Price > 0)
                        {
                            prices = Convert.ToSingle(dt[0].Price);
                        }
                        float money = prices * quantity;
                        DataTable dtcart = new DataTable();
                        dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
                        bool hasincart = false;
                        for (int i = 0; i < dtcart.Rows.Count; i++)
                        {
                            if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
                            {
                                if (dtcart.Rows[i]["Price"].ToString().Length > 0)
                                {
                                    pricesi = Convert.ToSingle(dtcart.Rows[i]["Price"]);
                                }
                                hasincart = true;
                                // cap nhat thong tin cua cart.
                                quantity += Convert.ToInt32(dtcart.Rows[i]["Quantity"]);
                                dtcart.Rows[i]["Quantity"] = quantity;
                                dtcart.Rows[i]["Money"] = quantity * Convert.ToSingle(pricesi);
                                dtcart.Rows[i]["Mausac"] = Mausac;
                                dtcart.Rows[i]["Kichco"] = Kichco;
                                System.Web.HttpContext.Current.Session["cart"] = dtcart;
                                break;
                            }
                        }
                        if (hasincart == false)
                        {
                            if (dtcart != null)
                            {
                                DataRow dr = dtcart.NewRow();
                                dr["PID"] = pid;
                                dr["Vimg"] = vimg;
                                dr["Name"] = name;
                                dr["Price"] = prices;
                                dr["Quantity"] = quantity;
                                dr["Money"] = money;
                                dr["Mausac"] = Mausac;
                                dr["Kichco"] = Kichco;
                                dtcart.Rows.Add(dr);
                                System.Web.HttpContext.Current.Session["cart"] = dtcart;
                            }
                        }
                    }
                }
            }
            System.Web.HttpContext.Current.Session["Session_Size"] = null;
            System.Web.HttpContext.Current.Session["Session_MauSac"] = null;
            System.Web.HttpContext.Current.Session["GSession_MauSac"] = null;
            System.Web.HttpContext.Current.Session["GSession_Size"] = null;
            return "";
        }

        [HttpPost]
        public string Updatequantity(string id, string quantity)
        {
            if (System.Web.HttpContext.Current.Session["cart"] != null)
            {
                DataTable dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
                return Cart_Updatequantity(ref dtcart, id, quantity);
            }
            return "";
        }
        protected static string Cart_Updatequantity(ref DataTable dtcart, string pid, string quantity)
        {
            if (dtcart.Rows.Count > 0)
            {
                for (int i = 0; i < dtcart.Rows.Count; i++)
                {
                    if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
                    {
                        dtcart.Rows[i]["quantity"] = quantity;
                        dtcart.Rows[i]["Money"] = Convert.ToInt32(quantity) * Convert.ToDouble(dtcart.Rows[i]["Price"].ToString());
                        // return "";
                    }
                }
            }
            return "";
        }

        [HttpPost]
        public string DeleteShopCart(string id, string quantity)
        {
            return ShoppingCart_RemoveProduct(id.ToString());
        }

        protected static string ShoppingCart_RemoveProduct(string pid)
        {
            DataTable dtcart = new DataTable();
            dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];

            for (int i = 0; i < dtcart.Rows.Count; i++)
            {
                if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
                {
                    dtcart.Rows.RemoveAt(i);
                    break;
                }
            }
            System.Web.HttpContext.Current.Session["cart"] = dtcart;
            return "";
        }

        [HttpPost]
        public string Up_KichCo(string id, string quantity)
        {
            return Session_Size(id.ToString());
        }

        protected static string Session_Size(string pid)
        {
            System.Web.HttpContext.Current.Session["Session_Size"] = pid.ToString();
            System.Web.HttpContext.Current.Session["GSession_Size"] = pid.ToString();
            return "";
        }

        [HttpPost]
        public string Up_MauSac(string id, string quantity)
        {
            return Session_MauSac(id.ToString());
        }

        protected static string Session_MauSac(string pid)
        {
            System.Web.HttpContext.Current.Session["Session_MauSac"] = pid.ToString();
            System.Web.HttpContext.Current.Session["GSession_MauSac"] = pid.ToString();
            return "";
        }

        [HttpGet]
        public string Loadinfo()
        {
            string str = "";
            List<Entity.Products> dt = SProducts.Name_Text("Select top 1 * from products ORDER BY NEWID()");
            if (dt.Count > 0)
            {
                str += " <div class=\"wpfomo-product-thumb-container\">";
                str += " <img src=\"" + dt[0].Images.ToString() + "\" class=\"wpfomo-product-thumb\"></div>";
                str += "<div class=\"wpfomo-content-wrapper\">";
                str += " <p><span class=\"wpfomo-buyer-name\">Chị Tuyết ở Cầu Giấy, Hn</span></p>";
                str += " <a href=\"\" target=\"_blank\" class=\"wpfomo-product-name\">Mua Thành Công " + dt[0].Name.ToString() + "</a><div class=\"time\">";
                str += " <span class=\"wpfomo-secondary-text\">Đã mua " + dt[0].Price.ToString() + " phút trước</span>";
                str += "</div>";
                str += "</div>";
            }
            return (str.ToString());
        }
        [HttpGet]
        public string LoadCart()
        {
            if (System.Web.HttpContext.Current.Session["cart"] != null)
            {
                DataTable cartdetail = (DataTable)System.Web.HttpContext.Current.Session["cart"];
                if (cartdetail.Rows.Count > 0)
                {
                    string inumofproducts = "";
                    string totalvnd = "";
                    if (cartdetail.Rows.Count > 0)
                    {
                        double num = 0.0;
                        int num2 = 0;
                        for (int i = 0; i < cartdetail.Rows.Count; i++)
                        {
                            num += Convert.ToDouble(cartdetail.Rows[i]["Money"].ToString());
                            num2 += Convert.ToInt32(cartdetail.Rows[i]["Quantity"].ToString());
                        }
                        totalvnd = num.ToString();
                        inumofproducts = num2.ToString();
                    }
                    return inumofproducts;
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                return "0";
            }
        }
        public static string ShopGiacu(string id)
        {
            string str = "";
            List<Entity.Products> dt = SProducts.GetById(id);
            if (dt.Count > 0)
            {
                if (dt[0].OldPrice.ToString().Length > 0)
                {
                    str = AllQuery.MorePro.Detail_Price(dt[0].OldPrice.ToString()) + " đ";
                }
            }
            return str.ToString();
        } 
        #endregion

        // ví dụ của code thầy bên myclass
        //public ActionResult DemoAjax()
        //{
        //    DonDatHang ddh = db.DonDatHangs.First();

        //    return View();
        //}
        ////Xử lý ajax action link
        //public ActionResult LoadAjaxActionLink()
        //{
        //    System.Threading.Thread.Sleep(2000);
        //    return Content("Hello Ajax");
        //}
        ////Xử lý ajax BeginForm
        //public ActionResult LoadAjaxBeginForm(FormCollection f)
        //{
        //    System.Threading.Thread.Sleep(2000);
        //    string KQ = f["txt1"].ToString();
        //    return Content(KQ);

        //}
        ////Xử lý Ajax Jquery
        //public ActionResult LoadAjaxJQuery(int a, int b)
        //{
        //    System.Threading.Thread.Sleep(2000);
        //    return Content((a + b).ToString());
        //}

        ////Sử dụng load ajax trả về kết quả 1 partialview

        ////Tạo partialview
        //public ActionResult LoadSanPhamAjax()
        //{
        //    var lstSanPham = db.SanPhams;
        //    return PartialView("LoadSanPhamAjax",lstSanPham);
        //}
    }
}
