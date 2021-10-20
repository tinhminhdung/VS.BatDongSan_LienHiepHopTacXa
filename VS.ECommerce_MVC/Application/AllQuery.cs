using Entity;
using MoreAll;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using VS.ECommerce_MVC;


public class AllQuery
{
    #region Banner
    public class Banner
    {
        public static string Banners()
        {
            string item = "";
            string str = Commond.Setting("bannerwidth");
            string str2 = Commond.Setting("bannerheight");
            string str3 = Commond.Setting("bannerpath");
            if (str3.Equals(""))
            {
            }
            else if (str3.Length > 4)
            {
                string str4 = str3.Substring(str3.IndexOf(".")).ToLower();
                if ((str4.Equals(".jpg") || str4.Equals(".gif")) || str4.Equals(".png"))
                {
                    item = "<a title=\"" + Commond.Setting("webname") + "\" href='/'><img src='" + str3 + "' border=0 style='" + MoreAll.MoreAll.Style_Width((str)) + ";" + MoreAll.MoreAll.Style_Height((str2)) + "'   title=\"" + Commond.Setting("webname") + "\" alt=\"" + Commond.Setting("webname") + "\"/></a>";
                }
                else if (str4.Equals(".swf"))
                {
                    item = "<embed style='" + MoreAll.MoreAll.Style_Width(str) + ";" + MoreAll.MoreAll.Style_Height((str2)) + "' align='middle'  quality='high' wmode='transparent' allowscriptaccess='always'  type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer'  src='" + str3 + "'>";
                }
            }
            return item.ToString();
        }
    }
    #endregion

    #region MoreNews
    public class MoreNews
    {
        #region Width Height
        public static string Width()
        {
            string Width = Commond.Setting("newswidth");
            return Width;
        }

        public static string Height()
        {
            string Height = Commond.Setting("newsheight");
            return Height;
        }
        #endregion

        #region Substring
        public static string Substring_Title(string input)
        {
            string number = Commond.Setting("News_titile_Substring");
            return MoreAll.MoreAll.Substring_Length_setup(number, input, Convert.ToInt32(number));
        }

        public static string Substring_Mota(string input)
        {
            string number = Commond.Setting("News_Mota_Substring");
            return MoreAll.MoreAll.Substring_Length_setup(number, input, Convert.ToInt32(number));
        }
        #endregion

        #region image
        public static string ImageDisplay(string image)
        {
            if (image.Length > 0)
            {
                return "<img  src='" + image + "' style='" + MoreAll.MoreAll.Style_Width(Width()) + ";" + MoreAll.MoreAll.Style_Height((Height())) + "'  border=0>";
            }
            return MoreNoimg.Noimg(MoreNews.Width(), MoreNews.Height());
        }
        public static string Image_Title_Alt(string image, string Title, string Alt)
        {
            if (image.Length > 0)
            {
                if (Alt.Length > 0)
                {
                    return "<img class=\"attachment-original size-original wp-post-image\" alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"  src='" + image + "' style='" + MoreAll.MoreAll.Style_Width(Width()) + ";" + MoreAll.MoreAll.Style_Height((Height())) + "'  border=0>";
                }
                else
                {
                    return "<img class=\"attachment-original size-original wp-post-image\" alt=\"" + Title.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"  src='" + image + "' style='" + MoreAll.MoreAll.Style_Width(Width()) + ";" + MoreAll.MoreAll.Style_Height((Height())) + "'  border=0>";
                }
            }
            return MoreNoimg.Noimg(MoreNews.Width(), MoreNews.Height());
        }
        public static string Image_Title_Alts_Css(string css, string image, string Title, string Alt)
        {
            if (image.Length > 0)
            {
                if (Alt.Length > 0)
                {
                    return "<img  class=\"" + css + "\"  alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"    src='" + image + "'   border=0>";
                }
                else
                {
                    return "<img  class=\"" + css + "\"  alt=\"" + Title.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"    src='" + image + "' border=0>";
                }
            }
            return MoreNoimg.Noimg(MorePro.Width(), MorePro.Height());
        }

        public static string Image_Title_Alts_Css_NWH(string css, string image, string Title, string Alt)
        {
            if (image.Length > 0)
            {
                if (Alt.Length > 0)
                {
                    return "<img class=\"" + css + "\"    alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"    src='" + image + "'   border=0>";
                }
                else
                {
                    return "<img   class=\"" + css + "\"  alt=\"" + Title.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"    src='" + image + "' border=0>";
                }
            }
            return MoreNoimg.Noimg(MorePro.Width(), MorePro.Height());
        }

        public static string Image_Title_Alt_Css(string css, string image, string Title, string Alt)
        {
            if (image.Length > 0)
            {
                if (Alt.Length > 0)
                {
                    return "<img class=\"" + css + "\"    alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"    src='" + image + "'  style='" + MoreAll.MoreAll.Style_Width(Width()) + ";" + MoreAll.MoreAll.Style_Height((Height())) + "'  border=0>";
                }
                else
                {
                    return "<img   class=\"" + css + "\"  alt=\"" + Title.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"    src='" + image + "'  style='" + MoreAll.MoreAll.Style_Width(Width()) + ";" + MoreAll.MoreAll.Style_Height((Height())) + "' border=0>";
                }
            }
            return MoreNoimg.Noimg(MoreNews.Width(), MoreNews.Height());
        }
        #endregion


        #region AllRelated
        public static string AllRelated(string Url, string nid)
        {
            string str = "";
            List<News> table = SNews.DETAIL_NEWS_RELATED(Sub_MenuRelated(nid));
            for (int i = 0; i < table.Count; i++)
            {
                string str2 = str;
                str = str2 + " > <a href='/" + Url + "/" + table[i].icid.ToString() + "/" + table[i].inid.ToString() + "/" + RewriteURLNew.NameToTag(table[i].Title.ToString()) + "'>" + table[i].Title.ToString() + "</a></br>";
            }
            return str;
        }
        public static string Sub_MenuRelated(string nid)
        {
            string submn = "0";
            List<Entity.News_Related> dt = SNews_Related.DETAIL_INID(nid);
            for (int i = 0; i < dt.Count; i++)
            {
                submn = submn + "," + dt[i].irelated.ToString();
            }
            return submn;
        }
        #endregion

        #region AllComments
        public static string AllComments(string nid, string status)
        {
            List<Comments> table = SComments.NEWS_TOTALS(nid, status);
            if (table.Count > 0)
            {
                return table.Count.ToString();
            }
            else return "0";
        }
        #endregion
        public static string Image_Title_Alt_NWH(string image, string Title, string Alt)
        {
            if (image.Length > 0)
            {
                if (Alt.Length > 0)
                {
                    return "<img class=\"img-responsive Image_Title_Alt_NWH\" alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"  src='" + image + "'  border=0>";
                }
                else
                {
                    return "<img class=\"img-responsive Image_Title_Alt_NWH\" alt=\"" + Title.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"  src='" + image + "'  border=0>";
                }
            }
            return MoreNoimg.Noimg(MoreNews.Width(), MoreNews.Height());
        }
    }

    #endregion

    #region MorePro
    public class MorePro
    {
        public static string Codes(string id)
        {
            string str = "";
            List<Entity.Products> dt = SProducts.GetById(id);
            if (dt.Count > 0)
            {
                str = dt[0].Code.ToString();
            }
            return str.ToString();
        }

        public static string FormatMoneyCart(string money)
        {
            if (money.Length > 0)
            {
                double value = Convert.ToDouble(money.ToString());
                string str = value.ToString("#,##,##");
                if (str.Length > 0)
                {
                    return str.Replace(",", ",") + " đ";
                }
                else { return "0 đ"; }
            }
            else
            {
                return "";
            }
        }
        public static string Giamgia(string ID)
        {
            string Width = "";
            DatalinqDataContext db = new DatalinqDataContext();
            product str = db.products.SingleOrDefault(p => p.ipid == int.Parse(ID));
            if (str != null)
            {
                if (str.Price.ToString() == "" || str.OldPrice.ToString() == "")
                {
                }
                else if (Convert.ToDouble(str.OldPrice.ToString()) > Convert.ToDouble(str.Price.ToString()))
                {
                    double cu = Convert.ToDouble(str.OldPrice.ToString());
                    double hientai = Convert.ToDouble(str.Price.ToString());
                    double Tong = (((cu - hientai) / cu) * 100);
                    Tong = System.Math.Round(Tong, 0);
                    if (Tong != 0)
                    {
                        Width += "    <div class=\"sale-flash\">";
                        Width += "      <div class=\"before\"></div> - " + Tong.ToString() + "%";
                        Width += "    </div>";
                    }
                }
            }
            return Width.ToString();
        }

        #region Width Height
        public static string Width()
        {
            string Width = Commond.Setting("prowidth");
            return Width.ToString();
        }
        public static string Height()
        {
            string Height = Commond.Setting("proheight");
            return Height.ToString();
        }
        #endregion
        #region Width Height Thumbnail
        public static string WidthThumbnail()
        {
            string Width = Commond.Setting("prowidthThumbnail");
            return Width.ToString();
        }
        public static string HeightThumbnail()
        {
            string Height = Commond.Setting("proheightThumbnail");
            return Height.ToString();
        }
        #endregion
        #region Dongiapro
        public static string Dongiapro()
        {
            string Dongia = Commond.Setting("Dongiapro");
            return Dongia.ToString();
        }
        #endregion
        #region TieudeGia
        public static string TieudeGia()
        {
            string TieudeGia = Commond.Setting("TieudeGia");
            return TieudeGia.ToString();
        }
        #endregion
        #region color
        public static string color()
        {
            string color = Commond.Setting("color");
            return color.ToString();
        }

        #endregion
        #region Pro_titile_Substring
        public static string Pro_titile_Substring()
        {
            string Pro_titile_Substring = Commond.Setting("Pro_titile_Substring");
            return Pro_titile_Substring.ToString();
        }

        #endregion

        #region Substring_Title
        public static string Substring_Title(string input)
        {
            string number = Pro_titile_Substring().ToString();
            return MoreAll.MoreAll.Substring_Length_setup(number, input, Convert.ToInt32(number));
        }

        #endregion
        #region FormatMoney
        public static string FormatMoney(string money)
        {
            if (money.Length > 0)
            {
                double value = Convert.ToDouble(money.ToString());
                string str = value.ToString("#,##,##");
                return TieudeGia().ToString() + str.Replace(",", ",") + MorePro.Dongiapro();
            }
            else
            {
                return Lienhevnd().ToString();
            }
        }
        #endregion
        #region Lienhevnd
        public static string Lienhevnd()
        {
            string Lienhevnd = Commond.Setting("Lienhevnd");
            return Lienhevnd.ToString();
        }
        #endregion
        #region FormatMoney_Detail
        public static string FormatMoney_Detail(string money)
        {
            if (money.Length > 0)
            {
                double value = Convert.ToDouble(money.ToString());
                string str = value.ToString("#,##,##");
                return TieudeGia() + str.Replace(",", ",") + MorePro.Dongiapro();
            }
            else
            {
                return "";
            }
        }
        public static string ShowTrangThai(string enable)
        {
            if (enable.Trim().Equals("0"))
            {
                return "Đơn hàng chưa duyệt";
            }
            else if (enable.Trim().Equals("1"))
            {
                return "Đơn hàng đã duyệt";
            }
            else if (enable.Trim().Equals("2"))
            {
                return "Đơn hàng đang chờ xử lý";
            }
            else if (enable.Trim().Equals("3"))
            {
                return "Đơn hàng đang vận chuyển";
            }
            return "";
        }
        public static string Detail_Price(string money)
        {
            if (money.Length > 0)
            {
                double value = Convert.ToDouble(money.ToString());
                string str = value.ToString("#,##,##");
                return str.Replace(",", ",");
            }
            else
            {
                return "";
            }
        }

        #endregion
        #region FormatMoney_Cart
        public static string FormatMoney_Cart(string money)
        {
            if (money.Length > 0)
            {
                double value = Convert.ToDouble(money.ToString());
                string str = value.ToString("#,##,##");
                return str.Replace(",", ",");
            }
            else
            {
                return "";
            }
        }
        #endregion
        #region FormatMoney_Cart_Total
        public static string FormatMoney_Cart_Total(string money)
        {
            if (money.Length > 0)
            {
                double value = Convert.ToDouble(money.ToString());
                string str = value.ToString("#,##,##");
                if (str.Length > 0)
                {
                    return str.Replace(",", ",") + " " + Dongiapro();
                }
                else { return "0 đ"; }

            }
            else
            {
                return "";
            }
        }
        #endregion
        //News
        #region FormatMoney_NO
        public static string FormatMoney_NO(string money)
        {
            if (money.Length > 0)
            {
                double value = Convert.ToDouble(money.ToString());
                string str = value.ToString("#,##,##");
                return str.Replace(",", ",");
            }
            else
            {
                return "";
            }
        }
        #endregion
        #region FormatMoney_VND
        public static string FormatMoney_VND(string money)
        {
            if (money != "0" && money != "")
            {
                double value = Convert.ToDouble(money.ToString());
                string str = value.ToString("#,##,##");
                return str.Replace(",", ",") + " " + Dongiapro();
            }
            else
            {
                return "0" + " " + Dongiapro();
            }
        }
        #endregion
        public static string FormatMoney_Full(string money)
        {
            if (money.Length > 0)
            {
                double value = Convert.ToDouble(money.ToString());
                string str = value.ToString("#,##,##");
                return TieudeGia() + str.Replace(",", ",") + MorePro.Dongiapro();
            }
            else
            {
                return "";
            }
        }
        public static string FormatMoney_Full_lh(string money)
        {
            if (money.Length > 0)
            {
                double value = Convert.ToDouble(money.ToString());
                string str = value.ToString("#,##,##");
                return TieudeGia().ToString() + str.Replace(",", ",") + MorePro.Dongiapro();
            }
            else
            {
                return Lienhevnd().ToString();
            }
        }
        public static string Fo_rmat_Price(string strTemp)
        {
            string strTextPrice = "";
            strTemp = strTemp.Replace("/,/g", "");
            if (strTemp == "" || strTemp == "0")
            { }
            else
            {
                try
                {

                    Double priceTy = (Convert.ToDouble(strTemp) / Convert.ToDouble("1000000000"));
                    priceTy = Math.Truncate(priceTy);
                    Double priceTrieu = ((Convert.ToDouble(strTemp) % Convert.ToDouble("1000000000")) / Convert.ToDouble("1000000"));
                    priceTrieu = Math.Truncate(priceTrieu);
                    Double priceNgan = (((Convert.ToDouble(strTemp) % Convert.ToDouble("1000000000"))) % Convert.ToDouble("1000000") / Convert.ToDouble("1000"));
                    priceNgan = Math.Round(priceNgan, 0);
                    Double priceDong = (((Convert.ToDouble(strTemp) % Convert.ToDouble("1000000000"))) % Convert.ToDouble("1000000") % Convert.ToDouble("1000"));
                    priceDong = Math.Round(priceDong, 0);
                    string getTrieu = "";
                    string getNgan = "";
                    string getDong = "";
                    if (priceTy > 0 && Convert.ToDouble(strTemp) > Convert.ToDouble("900000000"))
                    {
                        if (priceTrieu > 0)
                        {
                            getTrieu = "," + priceTrieu / Convert.ToDouble("100");
                        }
                        else
                        {
                            getTrieu = "";
                        }
                        strTextPrice = strTextPrice + priceTy + getTrieu + " Tỷ VNĐ";
                    }
                    if (priceTy == 0 && priceTrieu > 0)
                    {
                        if (priceNgan > 0)
                        {
                            getNgan = "," + priceNgan / Convert.ToDouble("100");
                        }
                        else
                        {
                            getNgan = "";
                        }
                        strTextPrice = strTextPrice + priceTrieu + getNgan + " Triệu VNĐ";
                    }
                    if (priceTrieu == 0 && priceNgan > 0)
                    {
                        if (priceDong > 0)
                        {
                            getDong = "," + priceDong / Convert.ToDouble("100");
                        }
                        else
                        {
                            getDong = "";
                        }
                        strTextPrice = strTextPrice + priceNgan + getDong + " Ngàn VNĐ";
                    }
                    if (priceNgan == 0 && priceDong > 0)
                    {
                        strTextPrice = strTextPrice + priceDong + " Đồng VNĐ";
                    }
                }
                catch (Exception)
                {
                }
            }
            return strTextPrice;

        }
        //End
        #region ToolTip
        public static string ToolTip(string lang)
        {
            #region Seting ToolTip
            string ToolTip = Commond.Setting("ToolTip");
            #endregion
            List<Products> dt = SProducts.List_ToolTip(lang);
            string str = "<script type=\"text/javascript\" src=\"/cms/Display/Products/Resources/js/stickytooltip.js\"></script>";
            str += "<link rel=\"stylesheet\" type=\"text/css\" href=\"/cms/Display/Products/Resources/css/stickytooltip.css\" />";
            str += "<div id=\"mystickytooltip\" class=\"stickytooltip\">";
            if (dt.Count > 0)
            {
                for (int i = 0; i < dt.Count; i++)
                {
                    if (ToolTip.Equals("1"))
                    {
                        str += "<div id=\"sticky" + dt[i].ipid.ToString() + "\" class=\"atip\">";
                        str += "<div class=\"protip-img\">";
                        str += MoreImage.Image_width_height(dt[i].Images.ToString(), "350", "0");
                        str += "</div>";
                        str += "</div>";
                    }
                    else if (ToolTip.Equals("2"))
                    {
                        str += "<div id=\"sticky" + dt[i].ipid.ToString() + "\" class=\"atip\">";
                        str += "<div class=\"Tooltip\">";
                        str += "<div class=\"protip-title\">" + dt[i].Name.ToString() + "</div>";
                        str += "<div class=\"protip-content\">";
                        str += "<p class=\"protip-summary\">";
                        str += "<b  class=\"icon\">Tính năng cơ bản:</b><br></p><div style=\" padding-left:5px; padding-right:5px; line-height:20px;\">" + dt[i].Brief.ToString() + "</div>";
                        str += "</div>";
                        str += "</div>";
                        str += "</div>";
                    }
                }
            }
            str += "<div class=\"stickystatus\"></div>";
            str += "</div>";
            return str.ToString();
        }
        #endregion

        #region image
        public static string ImageDisplay(string image)
        {
            if (image.Length > 0)
            {
                return "<img src='" + image + "' style='" + MoreAll.MoreAll.Style_Width(Width()) + ";" + MoreAll.MoreAll.Style_Height((Height())) + "'  border=0>";
            }
            return MoreNoimg.Noimg(Width(), Height());
        }
        public static string Image_Title_Alt(string image, string Title, string Alt)
        {
            if (image.Length > 0)
            {
                return "<img   alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"    src='" + image + "' style='" + MoreAll.MoreAll.Style_Width(Width()) + ";" + MoreAll.MoreAll.Style_Height((Height())) + "'  border=0>";
            }
            return MoreNoimg.Noimg(MorePro.Width(), MorePro.Height());
        }
        public static string Image_Title_Alts(string image, string Title, string Alt)
        {
            if (image.Length > 0)
            {
                if (Alt.Length > 0)
                {
                    return "<img   alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"    src='" + image + "' style='" + MoreAll.MoreAll.Style_Width(Width()) + ";" + MoreAll.MoreAll.Style_Height((Height())) + "'  border=0>";
                }
                else
                {
                    return "<img   alt=\"" + Title.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"    src='" + image + "' style='" + MoreAll.MoreAll.Style_Width(Width()) + ";" + MoreAll.MoreAll.Style_Height((Height())) + "'  border=0>";
                }
            }
            return MoreNoimg.Noimg(MorePro.Width(), MorePro.Height());
        }
        public static string Image_Title_Alts_Css(string css, string image, string Title, string Alt)
        {
            if (image.Length > 0)
            {
                if (Alt.Length > 0)
                {
                    return "<img  class='" + css + "' alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"    src='" + image + "'   border=0>";
                }
                else
                {
                    return "<img  class='" + css + "'  alt=\"" + Title.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"    src='" + image + "' border=0>";
                }
            }
            return MoreNoimg.Noimg(MorePro.Width(), MorePro.Height());
        }

        public static string Image_Title_Alts_Css_NWH(string css, string image, string Title, string Alt)
        {
            if (image.Length > 0)
            {
                if (Alt.Length > 0)
                {
                    return "<img class=\"" + css + "\"    alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"    src='" + image + "'   border=0>";
                }
                else
                {
                    return "<img   class=\"" + css + "\"  alt=\"" + Title.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"    src='" + image + "' border=0>";
                }
            }
            return MoreNoimg.Noimg(MorePro.Width(), MorePro.Height());
        }

        #endregion
        public static string Image_width_height_Title_Alt_css(string css, string image, string width, string height, string Title, string Alt)
        {
            if (image.Length > 0)
            {
                return "<img class=\"" + css + "\"  alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"    src='" + image + "' style='" + MoreAll.MoreAll.Style_Width(Width()) + ";" + MoreAll.MoreAll.Style_Height((Height())) + "'  border=0>";
            }
            return MoreNoimg.Noimg(Width(), Height());
        }
        public static string CC_Image_Title_Alt(string css, string image, string Title, string Alt)
        {
            if (image.Length > 0)
            {
                return "<img  class=\"" + css + "\"  alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"    src='" + image + "' style='" + MoreAll.MoreAll.Style_Width(Width()) + ";" + MoreAll.MoreAll.Style_Height((Height())) + "'  border=0>";
            }
            return MoreNoimg.Noimg(Width(), Height());
        }
        public static string Image_width_height_gallery(string image, string title)
        {
            if (image.Length > 0)
            {
                return "<img src='" + image + "'  style='" + MoreAll.MoreAll.Style_Width(WidthThumbnail()) + ";" + MoreAll.MoreAll.Style_Height(HeightThumbnail()) + "' border=0>";
            }
            return MoreNoimg.Noimg(Width(), Height());
        }

        public static string ImageDetail(string image)
        {
            if (image.Length > 0)
            {
                return "<a id=\"gdBigImg\" rel=\"imgEx\" href=\"" + image + "\"><img alt=\"imgEx\" src='" + image + "'  style='" + MoreAll.MoreAll.Style_Width(WidthThumbnail()) + ";" + MoreAll.MoreAll.Style_Height(HeightThumbnail()) + "' border=0></a>";
            }
            return MoreNoimg.Noimg(Width(), Height());
        }

        public static string Tinhphamtramgiamgia(string ID)
        {
            string Width = "";
            // chưa code đâu, đây chỉ là show ra demo thôi. lúc nào làm thì code nhé
            //Chúng ta sẽ có số tiền giảm = Số phần trăm * Giá / 100
            Double phantram = 18;// 18%
            Double Price = 700000;// 7 triệu
            Double tong = (phantram * Price) / 100;
            //Response.Write("Giảm giá:" + tong + "<br>");
            Double tongtatca = (Price - tong);
            //Response.Write("tong:" + tongtatca + "<br>");
            return Width.ToString();
        }
        public static string Tietkiem(string ID)
        {
            string Width = "";
            List<Entity.Products> str = SProducts.GetById(ID);
            if (str.Count >= 1)
            {
                if (str[0].Price.ToString() == "" || str[0].OldPrice.ToString() == "")
                {

                }
                else if (Convert.ToDouble(str[0].OldPrice.ToString()) > Convert.ToDouble(str[0].Price.ToString()))
                {
                    double cu = Convert.ToDouble(str[0].OldPrice.ToString());
                    double hientai = Convert.ToDouble(str[0].Price.ToString());
                    double Tong = (((cu - hientai)));
                    Tong = System.Math.Round(Tong, 0);
                    Width += "<span class=\"Tietkiem\">-" + MorePro.Detail_Price(Tong.ToString()) + " đ</span>";
                }
            }
            return Width.ToString();
        }
        public static string Tietkiems(string ID)
        {
            string Width = "";
            List<Entity.Products> str = SProducts.GetById(ID);
            if (str.Count >= 1)
            {
                if (str[0].Price.ToString() == "" || str[0].OldPrice.ToString() == "")
                {

                }
                else if (Convert.ToDouble(str[0].OldPrice.ToString()) > Convert.ToDouble(str[0].Price.ToString()))
                {
                    double cu = Convert.ToDouble(str[0].OldPrice.ToString());
                    double hientai = Convert.ToDouble(str[0].Price.ToString());
                    double Tong = (((cu - hientai)));
                    Tong = System.Math.Round(Tong, 0);
                    Width += "<span class=\"Tietkiem\">Tiết kiệm: " + MorePro.Detail_Price(Tong.ToString()) + " đ</span>";
                }
            }
            return Width.ToString();
        }

        public string NameMenu(string ID)
        {
            string Width = "";
            List<Entity.Menu> dts = SMenu.Detail(ID);
            if (dts.Count > 0)
            {
                Width += dts[0].Name;
            }
            return Width.ToString();
        }
        public static string LoadLink(string ID)
        {
            string Width = "";
            List<Entity.Products> dts = SProducts.GetById(ID);
            if (dts.Count > 0)
            {
                Width += "/san-pham/" + dts[0].TangName.ToString() + ".html";
            }
            return Width.ToString();
        }
    }
    #endregion

    #region MoreDownload
    public class MoreDownload
    {
        #region Width Height
        public static string Width()
        {
            string Width = Commond.Setting("Downloadwidth");
            return Width.ToString();
        }
        public static string Height()
        {
            string Height = Commond.Setting("Downloadheight");
            return Height.ToString();
        }
        #endregion
        #region ImagesDisplay
        public static string ImagesDisplay(string Images)
        {
            if (Images.Length > 4)
            {
                string str = Images.Substring(Images.IndexOf(".")).ToLower();
                if (str.Equals(".doc"))
                {
                    return "<img src='/Uploads/Download/Icon/Word.png' style='border:1px solid #9EC3CB;" + MoreAll.MoreAll.Style_Width((Width())) + ";" + MoreAll.MoreAll.Style_Height((Height())) + "' />";
                }
                else if (str.Equals(".rar"))
                {
                    return "<img src='/Uploads/Download/Icon/rar.png' style='border:1px solid #9EC3CB;" + MoreAll.MoreAll.Style_Width((Width())) + ";" + MoreAll.MoreAll.Style_Height((Height())) + "' />";
                }
                else if (str.Equals(".xls"))
                {
                    return "<img src='/Uploads/Download/Icon/Exel.png' style='border:1px solid #9EC3CB;" + MoreAll.MoreAll.Style_Width((Width())) + ";" + MoreAll.MoreAll.Style_Height((Height())) + "' />";
                }
                else if (str.Equals(".pdf"))
                {
                    return "<img src='/Uploads/Download/Icon/pdf.png' style='border:1px solid #9EC3CB;" + MoreAll.MoreAll.Style_Width((Width())) + ";" + MoreAll.MoreAll.Style_Height((Height())) + "' />";
                }
                else if (str.Equals(".ppt"))
                {
                    return "<img src='Uploads/Download/Icon/power.png' style='border:1px solid #9EC3CB;" + MoreAll.MoreAll.Style_Width((Width())) + ";" + MoreAll.MoreAll.Style_Height((Height())) + "' />";
                }
            }
            return "<img src='/Uploads/Noimg/titleNoimg4.gif'  style='border:1px solid #9EC3CB;" + MoreAll.MoreAll.Style_Width((Width())) + ";" + MoreAll.MoreAll.Style_Height((Height())) + "' />";
        }
        #endregion
        #region ImagesDownload
        public static string ImagesDownload(string Images)
        {
            if (Images.Length > 4)
            {
                string str = Images.Substring(Images.IndexOf(".")).ToLower();
                if (str.Equals(".doc"))
                {
                    return "<img src='/Uploads/Download/Icon/Word.png' style='border:1px solid #9EC3CB;' width=100px  height=65px />";
                }
                else if (str.Equals(".rar"))
                {
                    return "<img src='/Uploads/Download/Icon/rar.png' style='border:1px solid #9EC3CB;' width=100px  height=65px />";
                }
                else if (str.Equals(".xls"))
                {
                    return "<img src='/Uploads/Download/Icon/Exel.png' style='border:1px solid #9EC3CB;' width=100px  height=65px />";
                }
                else if (str.Equals(".pdf"))
                {
                    return "<img src='/Uploads/Download/Icon/pdf.png' style='border:1px solid #9EC3CB;' width=100px  height=65px />";
                }
                else if (str.Equals(".ppt"))
                {
                    return "<img src='Uploads/Download/Icon/power.png' style='border:1px solid #9EC3CB;' width=100px  height=65px />";
                }
            }
            return "<img src='/Uploads/Noimg/titleNoimg4.gif'  style='border:1px solid #9EC3CB;' width=100px  height=65px />";
        }
        #endregion
        #region Pagedownload
        public static string Pagedownload()
        {
            string Pagedownload = Commond.Setting("pageDownload");
            return Pagedownload.ToString();
        }
        #endregion
    }
    #endregion

    #region MoreAllBum
    public class MoreAllBum
    {
        #region Width Height
        public static string Width()
        {
            string Width = Commond.Setting("Photowidth");
            return Width.ToString();
        }
        public static string Height()
        {
            string Height = Commond.Setting("Photoheight");
            return Height.ToString();
        }
        #endregion
        #region ImageDisplay
        public static string ImageDisplay(string image)
        {
            if (image.Length > 0)
            {
                return "<img src='" + image + "' style='" + MoreAll.MoreAll.Style_Width((Width())) + ";" + MoreAll.MoreAll.Style_Height((Height())) + "' border=0  align=left>";
            }
            return MoreNoimg.Noimg(MoreAll.MoreAll.Style_Width((Width())), MoreAll.MoreAll.Style_Height((Height())));
        }
        public static string Image_Title_Alt(string image, string Title, string Alt)
        {
            if (image.Length > 0)
            {
                return "<img  alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"    src='" + image + "' style='" + MoreAll.MoreAll.Style_Width(Width()) + ";" + MoreAll.MoreAll.Style_Height((Height())) + "'  border=0>";
            }
            return MoreNoimg.Noimg(Width(), Height());
        }
        public static string Image_Title_Alts_Css(string css, string image, string Title, string Alt)
        {
            if (image.Length > 0)
            {
                if (Alt.Length > 0)
                {
                    return "<img   alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"    src='" + image + "'   border=0>";
                }
                else
                {
                    return "<img   alt=\"" + Title.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"    src='" + image + "' border=0>";
                }
            }
            return MoreNoimg.Noimg(MorePro.Width(), MorePro.Height());
        }
        #endregion
        #region Image_AllBum
        public static string Image_AllBum(string Thumbnail, string image, string id, string title, string alt)
        {
            if (image.Length > 0)
            {
                return "<a href='" + image + "'><img title='" + title + "' alt='" + alt + "' src='" + Thumbnail + "' class='image" + id + "'></a>";
            }
            return MoreNoimg.Noimg(MoreAllBum.Width(), MoreAllBum.Height());
        }
        public static string Image_DTAllBum(string image, string title, string alt)
        {
            if (image.Length > 0)
            {
                return "<img title='" + title + "' alt='" + alt + "' src='" + image + "' />";
            }
            return MoreNoimg.Noimg(MoreAllBum.Width(), MoreAllBum.Height());
        }
        #endregion
    }
    #endregion

    #region MoreVideoClip
    public class MoreVideoClip
    {
        #region Width Height
        public static string Width()
        {
            string Widths = Commond.Setting("videowidth");
            return Widths.ToString();
        }
        public static string Height()
        {
            string Heights = Commond.Setting("videoheight");
            return Heights.ToString();
        }
        #endregion
        #region Width Height
        public static string Width_Img()
        {
            string Widths = Commond.Setting("videoimgwidth");
            return Widths.ToString();
        }
        public static string Height_Img()
        {
            string Heights = Commond.Setting("videoimgheight");
            return Heights.ToString();
        }
        #endregion
        #region ImageDisplay
        public static string ImageDisplay(string image)
        {
            if (image.Length > 0)
            {
                return "<img src='" + image + "' style='" + MoreAll.MoreAll.Style_Width((Width_Img())) + ";" + MoreAll.MoreAll.Style_Height((Height_Img())) + "' border=0  align=left>";
            }
            return MoreNoimg.Noimg(MoreVideoClip.Width_Img(), MoreVideoClip.Height_Img());
        }
        public static string Image_Title_Alts_Css(string css, string image, string Title, string Alt)
        {
            if (image.Length > 0)
            {
                if (Alt.Length > 0)
                {
                    return "<img   alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"    src='" + image + "'   border=0>";
                }
                else
                {
                    return "<img   alt=\"" + Title.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"    src='" + image + "' border=0>";
                }
            }
            return MoreNoimg.Noimg(MorePro.Width(), MorePro.Height());
        }
        public static string Image_Title_Alt(string image, string Title, string Alt)
        {
            if (image.Length > 0)
            {
                return "<img src='" + image + "' style='" + MoreAll.MoreAll.Style_Width(Width()) + ";" + MoreAll.MoreAll.Style_Height((Height())) + "'  alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"     border=0>";
            }
            return MoreNoimg.Noimg(Width(), Height());
        }
        #endregion
        #region Pagevideo
        public static string Pagevideo()
        {
            string page = Commond.Setting("pagevideo");
            return page.ToString();
        }
        #endregion
        #region Videoother
        public static string Videoother()
        {
            string Video = Commond.Setting("videoother");
            return Video.ToString();
        }
        #endregion
        #region Videochiase
        public static string Videochiase()
        {
            string chiase = Commond.Setting("videochiase");
            return chiase.ToString();
        }
        #endregion
        public static string GetYouTubeID(string youTubeUrl)
        {
            //RegEx to Find YouTube ID
            Match regexMatch = Regex.Match(youTubeUrl, "^[^v]+v=(.{11}).*", RegexOptions.IgnoreCase);
            if (regexMatch.Success)
            {
                return "http://www.youtube.com/v/" + regexMatch.Groups[1].Value + "&hl=en&fs=1";
            }
            return youTubeUrl;
        }
    }
    #endregion
}
