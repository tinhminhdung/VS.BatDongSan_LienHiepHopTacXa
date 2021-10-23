using MoreAll;
using Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VS.ECommerce_MVC;

public class Commond
{
   
    public static string ShowCapbac(string status)
    {
        if (status.Equals("1"))
        {
            return "<span class='ShowCapbac1'>Nhân viên</span>";
        }
        else if (status.Equals("2"))
        {
            return "<span class='ShowCapbac2'>Trưởng nhóm kinh doanh</span>";
        }
        else if (status.Equals("3"))
        {
            return "<span class='ShowCapbac3'>Trưởng phòng kinh doanh</span>";
        }
        else if (status.Equals("4"))
        {
            return "<span class='ShowCapbac4'>Phó giám đốc</span>";
        }
        else if (status.Equals("5"))
        {
            return "<span class='ShowCapbac5'>Giám đốc kinh doanh</span>";
        }
        return "<span class='chuakh'>Cộng tác viên</span>";
    }
    public static string ShowCapbacView(string status)
    {
        if (status.Equals("1"))
        {
            return "<div class='ShowCapbac1'>Nhân viên</div>";
        }
        else if (status.Equals("2"))
        {
            return "<div class='ShowCapbac2'>Trưởng nhóm kinh doanh</div>";
        }
        else if (status.Equals("3"))
        {
            return "<div class='ShowCapbac3'>Trưởng phòng kinh doanh</div>";
        }
        else if (status.Equals("4"))
        {
            return "<div class='ShowCapbac4'>Phó giám đốc</div>";
        }
        else if (status.Equals("5"))
        {
            return "<div class='ShowCapbac5'>Giám đốc kinh doanh</div>";
        }
        return "<div class='chuakh'>Cộng tác viên</div>";
    }

    public static string ShowMTree(string id)
    {
        string str = "";
        try
        {
            if (id != "0" || id != "")
            {
                List<Entity.Member> dt = SMember.GET_BY_ID(id);
                if (dt.Count >= 1)
                {
                    str = dt[0].MTRee;
                }
            }
        }
        catch (Exception)
        { }
        return str;
    }
    public static string TongThanhVien_Tree(string id)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        string str = "0";
        try
        {
            var dt = db.S_Members_List_TongThanhVien_Tree(int.Parse(id)).ToList();
            if (dt.Count > 0)
            {
                str = dt[0].Tong.ToString();
            }
        }
        catch (Exception)
        { }
        Double Tong = 0;
        if (str != "0")
        {
            Tong = Convert.ToDouble(str) - 1;
        }
        return Tong.ToString();
    }

    public static string SearchThanhVien(string keyword)
    {
        string str = "0";
        List<Entity.Member> dt = SMember.Name_Text("select * from Members where (HoVaTen like N'%" + keyword + "%')");
        if (dt.Count >= 1)
        {
            for (int i = 0; i < dt.Count; i++)
            {
                str = str + "," + dt[i].ID.ToString();
            }
        }
        return str.Replace("0,", "");
    }
   
    public static string ShowThanhVien(string id)
    {
        string str = "";
        List<Entity.Member> dt = SMember.GET_BY_ID(id);
        if (dt.Count >= 1)
        {
            str += "<span id=" + dt[0].ID.ToString() + " style=\" color:red\">";
            if (dt[0].HoVaTen.ToString().Length > 0) 
            {
                str += "<a target=\"_blank\" href=\"/admin.aspx?u=Thanhvien&IDThanhVien=" + dt[0].ID.ToString() + "\"><span style='color:red'>" + dt[0].HoVaTen + " [Level " + dt[0].CapBac + "]" + "</span></a>";
            }
            str += "</span><br>";
            if (dt[0].DienThoai.ToString().Length > 0)
            {
                str += dt[0].DienThoai;
            }
        }
        else
        {
            str = "Không tìm thấy thành viên";
        }
        return str;
    }
    public static string ShowThanhVien_Member(string id)
    {
        string str = "";
        List<Entity.Member> dt = SMember.GET_BY_ID(id);
        if (dt.Count >= 1)
        {
            if (dt[0].HoVaTen.ToString().Length > 0)
            {
                str += "<a target=\"_blank\" href=\"/admin.aspx?u=Thanhvien&IDThanhVien=" + dt[0].ID.ToString() + "\"><span style='color:#008bca'>" + dt[0].HoVaTen + " [Level " + dt[0].CapBac + "]" + "</span></a>";
            }
        }
        else
        {
            str = "Không tìm thấy thành viên";
        }
        return str;
    }

    public static string ShowThanhVien_Display(string id)
    {
        string str = "";
        List<Entity.Member> dt = SMember.GET_BY_ID(id);
        if (dt.Count >= 1)
        {
            str += "<span id=" + dt[0].ID.ToString() + " style=\" color:red\">";
            if (dt[0].HoVaTen.ToString().Length > 0)
            {
                str += dt[0].HoVaTen;
            }
            str += "</span><br>";
            if (dt[0].DienThoai.ToString().Length > 0)
            {
                str += dt[0].DienThoai;
            }
        }
        else
        {
            str = "Không tìm thấy thành viên";
        }
        return str;
    }

    public static string CatAnhSP(string strImg)
    {
        if (strImg.ToString().Length > 5)
        {
            string[] strArray = strImg.ToString().Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                if (i == 0)
                    return strArray[i].ToString();
            }
        }
        return "";
    }

    public const string SessionCart = "SessionCart";

    #region Modul Product
    public static string ShowDonGia(string ID)
    {
        switch (ID)
        {
            case "1":
                return "VNĐ";
            case "2":
                return "VNĐ/tháng";
            case "3":
                return "VNĐ/m<sup>2</sup>";
            case "4":
                return "Thỏa thuận";
        }
        return "";
    }
    public static string ShowHuongNha(string ID)
    {
        switch (ID)
        {
            case "1":
                return "Đông";
            case "2":
                return "Tây";
            case "3":
                return "Nam";
            case "4":
                return "Bắc";
            case "5":
                return "Đông bắc";
            case "6":
                return "Đông nam";
            case "7":
                return "Tây bắc";
            case "8":
                return "Tây nam";
        }
        return "";
    }
    public static string ShowGia(string ID)
    {
        if (ID != "0" && ID != "")
        {
            try
            {
                return AllQuery.MorePro.FormatMoney_NO(ID);
            }
            catch (Exception)
            { }
        }
        return "";
    }

    public static string ShowVideo(string ID)
    {
        if (ID != "0")
        {
            return ID;
        }
        return "";
    }
    public static string ShowNamePro(string ID)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        product str = db.products.SingleOrDefault(p => p.ipid == int.Parse(ID));
        if (str != null)
        {
            return str.Name.ToString();
        }
        return "";
    }
    public static string ShowNhom(string ID)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        string choi = "";
        Menu str = db.Menus.SingleOrDefault(p => p.ID == int.Parse(ID));
        if (str != null)
        {
            choi += "<a class=\"text-body\" href=\"/danh-muc/" + str.TangName.ToString() + ".htmml\">";
            choi += "<i class=\"fas fa-home fa-fw mr-1\"></i>" + str.Name.ToString() + "";
            choi += "</a>";
        }
        return choi;
    }

    public static string ShowTinhThanh(string ID)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        var str = STinhthanh.Name_Text("select * from TinhThanh where ID=" + ID + "");
        if (str != null)
        {
            return str[0].Name.ToString();
        }
        return "";
    }
    public static string ShowTinhThanhID(string ID)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        var str = STinhthanh.Name_Text("select * from TinhThanh where TangName='" + ID + "'");
        if (str != null)
        {
            return str[0].ID.ToString();
        }
        return "";
    }
    public static string ShowDanhMuc(string ID)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        var str = SMenu.Name_Text("select * from Menu where id='" + (ID) + "'");
        if (str != null)
        {
            return str[0].Name.ToString();
        }
        return "";
    }
    public static string ShowNhuCau(string ID)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        var str = SMenu.Name_Text("select * from Menu where id='" + More.MenuDacap(ID) + "'");
        if (str != null)
        {
            return str[0].Name.ToString();
        }
        return "";
    }
    public static string Sql_Product()
    {
        return "DonGia,Quanhuyen,DienTich,Alt,ipid,icid,TangName,Name,Images,ImagesSmall,Brief,Create_Date,Price,OldPrice,ID_Hang,sanxuat,Code";
    }

    #region Hiển thị bao nhiêu sản phẩm ở nhóm trang chủ
    public static string HomePage()
    {
        return Commond.Setting("HomePage");
    }
    #endregion
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
    public static string LoadProductList_Home(IEnumerable<Entity.Category_Product> product)
    {
        string str = "";
        foreach (Entity.Category_Product item in product)
        {
            str += " <div class=\"col medium-6 small-12 large-12\">";
            str += " <div class=\"col-inner\">";
            str += "     <div class=\"box box-vertical box-text-bottom mh-box-re-vertical\">";
            str += "         <div class=\"box-image\" style=\"width: 30%;\">";
            str += "             <a href=\"/san-pham/" + item.TangName + ".html\">";
            str += "                 <div class=\"image-cover\" style=\"padding-top: 60%;\">";
            str += AllQuery.MorePro.Image_Title_Alts(item.ImagesSmall.ToString(), item.Name.ToString(), item.Alt.ToString());
            str += "                 </div>";
            str += "             </a>";
            str += "         </div>";
            str += "         <div class=\"box-text text-left relative\">";
            str += "             <div class=\"box-text-inner blog-post-inner\">";
            str += "                 <div class=\"title-wrapper\">";
            str += "                     <div class=\"name re-title\">";
            str += "                         <a href=\"/san-pham/" + item.TangName + ".html\" title=\"" + item.Name.ToString() + "\">" + AllQuery.MorePro.Substring_Title(item.Name.ToString()) + "</a>";
            str += "                     </div>";
            str += "                 </div>";
            str += "                 <div class=\"re-info row row-collapse\">";
            str += "                     <div class=\"col medium-12 small-12 large-6\">";
            str += ShowNhom(item.icid.ToString());
            str += "                     </div>";
            str += "                     <div class=\"col medium-12 small-12 large-6\">";
            str += "                         <i class=\"fas fa-ruler-combined\"></i> " + item.DienTich + "m<sup>2</sup>";
            str += "                     </div>";
            str += "                     <div class=\"col medium-12 small-12 large-6\">";
            str += "                         <i class=\"fas fa-map-marker-alt fa-fw mr-1\"></i>" + ShowTinhThanh(item.Quanhuyen.ToString()) + "";
            str += "                     </div>";
            str += "                     <div class=\"col medium-12 small-12 large-6\">";
            str += "                         <i class=\"fas fa-calendar-alt\"></i> " + MoreAll.MoreAll.Date_Thangs(item.Create_Date) + "/" + MoreAll.MoreAll.NamNam(item.Create_Date) + "";
            str += "                     </div>";
            str += "                 </div>";
            str += "                 <div class=\"mh-price-re uppercase\">";
            str += "                     <div class=\"mh-price-re-inner\">";
            str += "Giá:<strong>" + ShowGia(item.Price.ToString()) + "</strong> " + ShowDonGia(item.DonGia.ToString()) + "";
            str += "                     </div>";
            str += "                 </div>";
            str += "             </div>";
            str += "         </div>";
            str += "     </div>";
            str += " </div>";
            str += " </div>";
        }
        return str;
    }
    public static string LoadProductList(IEnumerable<Entity.Category_Product> product)
    {
        string str = "";
        foreach (Entity.Category_Product item in product)
        {
            str += " <div class=\"col medium-6 small-12 large-4\">";
            str += " <div class=\"col-inner\">";
            str += " <div class=\"product-small box has-hover box-normal box-text-bottom mh-re-small\">";
            str += " <div class=\"box-image relative\">";
            str += " <a href=\"/san-pham/" + item.TangName + ".html\">";
            str += AllQuery.MorePro.Image_Title_Alts(item.ImagesSmall.ToString(), item.Name.ToString(), item.Alt.ToString());
            str += " </a>";
            str += " <div class=\"mh-map uppercase\">";
            str += " <div class=\"mh-map-inner\">";
            str += "     <i class=\"fas fa-map-marker-alt fa-fw mr-1\"></i>";
            str += ShowTinhThanh(item.Quanhuyen.ToString()) + "";
            str += " </div>";
            str += " </div>";
            str += " <div class=\"mh-price-re uppercase\">";
            str += " <div class=\"mh-price-re-inner\">";
            str += "Giá:<strong>" + ShowGia(item.Price.ToString()) + "</strong> " + ShowDonGia(item.DonGia.ToString()) + "";
            str += " </div>";
            str += " </div>";
            str += " </div>";
            str += " <div class=\"box-text text-left\">";
            str += " <div class=\"title-wrapper\">";
            str += " <div class=\"name re-title\">";
            str += "     <a href=\"/san-pham/" + item.TangName + ".html\" title=\"" + item.Name.ToString() + "\">" + AllQuery.MorePro.Substring_Title(item.Name.ToString()) + "</a>";
            str += " </div>";
            str += " </div>";
            str += " <div class=\"re-info\">";
            str += " <span>";
            str += ShowNhom(item.icid.ToString());
            str += " </span>";
            str += " <span>";
            str += "     <i class=\"fas fa-ruler-combined\"></i>";
            str += item.DienTich + "m<sup>2</sup>";
            str += " </span>";
            str += " </div>";
            str += " <div class=\"mh-re-action\">";
            str += " <div class=\"mh-re-time\">";
            str += "     <i class=\"fas fa-calendar-alt fa-fw mr-1\"></i>";
            str += MoreAll.MoreAll.Date_Thangs(item.Create_Date) + "/" + MoreAll.MoreAll.NamNam(item.Create_Date) + "";
            str += " </div>";
            str += " <div class=\"mh-re-detail\">";
            str += "     <a href=\"/san-pham/" + item.TangName + ".html\" class=\"button secondary is-outline\">";
            str += "         <span>Chi tiết</span>";
            str += "         <i class=\"fas fa-chevron-right\"></i>";
            str += "     </a>";
            str += "     </a>";
            str += " </div>";
            str += " </div>";
            str += " </div>";
            str += " </div>";
            str += " </div>";
            str += " </div>";
        }
        return str;
    }
    #endregion

    #region Modul News
    public static string Sql_News()
    {
        return "inid,Alt,TangName,Title,Images,ImagesSmall,Brief,Create_Date";
    }
    public static string LoadNewsListHome(IEnumerable<Entity.Category_News> news, string language)
    {
        string str = "";
        foreach (Entity.Category_News item in news)
        {
            str += " <div class=\"col post-item\">";
            str += " <div class=\"col-inner\">";
            str += " <a href=\"/tin-tuc/" + item.TangName + ".html\" title=\"" + item.Title + "\" class=\"plain\">";
            str += " <div class=\"box box-vertical box-text-bottom box-blog-post has-hover\">";
            str += " <div class=\"box-image\" style=\"width:25%;\">";
            str += " <div class=\"image-cover\" style=\"padding-top:75%;\">";
            str += AllQuery.MoreNews.Image_Title_Alt_Css("attachment-original size-original wp-post-image", item.ImagesSmall.ToString(), item.Title.ToString(), item.Alt.ToString());
            str += " </div>";
            str += " </div>";
            str += " <div class=\"box-text text-left\" style=\"padding:0px 0px 0px 10px;\">";
            str += " <div class=\"box-text-inner blog-post-inner\">";
            str += "     <h5 class=\"post-title is-large \">" + item.Title + "</h5>";
            str += "     <div class=\"is-divider\"></div>";
            str += " </div>";
            str += " </div>";
            str += " </div>";
            str += " </a>";
            str += " </div>";
            str += " </div>";

            //str += "<div class=\"item_blog_owl\">";
            //str += " <article class=\"blog-item blog-item-grid row\">";
            //str += "  <div class=\"wrap_blg\">";
            //str += "   <div class=\"blog-item-thumbnail img1 col-lg-12 col-md-12 col-sm-12 col-xs-12\">";
            //str += "<a href=\"/tin-tuc/" + item.TangName + ".html\" title=\"" + item.Title + "\">" + AllQuery.MoreNews.Image_Title_Alt(item.ImagesSmall.ToString(), item.Title.ToString(), item.Alt.ToString()) + "</a>";
            //str += "   </div>";
            //str += "   <div class=\"col-lg-12 col-md-12 col-sm-12 col-xs-12 content_ar blog_large_item\">";
            //// str += "       <span class=\"blog_name\">Tin tức</span>";
            //str += "       <h3 class=\"blog-item-name large_name\">";
            //str += "<a class=\"text1line\"  href=\"/tin-tuc/" + item.TangName + ".html\"  title=\"" + item.Title + "\">" + AllQuery.MoreNews.Substring_Title(item.Title.ToString()) + "</a>";
            //str += "</h3>";
            //str += " <div class=\"summary_ text3line\">";
            //str += AllQuery.MoreNews.Substring_Mota(item.Brief.ToString());
            //str += "</div>";
            //str += "   </div>";
            //str += "  </div>";
            //str += " </article>";
            //str += "  </div>";
        }
        return str;
    }
    public static string LoadNewsList(IEnumerable<Entity.Category_News> news, string language)
    {
        string str = "";
        foreach (Entity.Category_News item in news)
        {
            str += "<div class=\"col post-item chieucao\">";
            str += "<div class=\"col-inner \">";
            str += "<a href=\"/tin-tuc/" + item.TangName + ".html\"  title=\"" + item.Title + " class=\"plain\">";
            str += "<div class=\"box box-text-bottom box-blog-post has-hover\">";
            str += "<div class=\"box-image\">";
            str += "<div class=\"image-cover\" style=\"padding-top:56.25%;\">";
            str += AllQuery.MoreNews.Image_Title_Alts_Css("attachment-original size-original wp-post-image tooo", item.ImagesSmall.ToString(), item.Title.ToString(), item.Alt.ToString());
            str += "</div>";
            str += "</div>";
            str += "<div class=\"box-text text-left chieucaos\" style=\"padding:8px 0px 0px 0px;\">";
            str += "<div class=\"box-text-inner blog-post-inner\">";
            str += "<h5 class=\"post-title is-large \">" + AllQuery.MoreNews.Substring_Title(item.Title.ToString()) + "</h5>";
            str += "<div class=\"is-divider\"></div>";
            str += "<p class=\"from_the_blog_excerpt \">" + AllQuery.MoreNews.Substring_Mota(item.Brief.ToString()) + "</p>";
            str += "</div>";
            str += "</div>";
            str += "</div>";
            str += "</a>";
            str += "</div>";
            str += "</div>";
        }
        return str;
    }

    //public static string LoadNewsList(IEnumerable<Entity.Category_News> news, string language)
    //{
    //    string str = "";
    //    foreach (Entity.Category_News item in news)
    //    {
    //        str += "<div class=\"col-lg-4 col-md-4 col-sm-6 col-xs-12\">";
    //        str += "<div class=\"item_blog_owl\">";
    //        str += "<article class=\"blog-item blog-item-grid row\">";
    //        str += "<div class=\"wrap_blg\">";
    //        str += "<div class=\"blog-item-thumbnail img1 col-lg-12 col-md-12 col-sm-12 col-xs-12\" >";
    //        str += "<a href=\"\" title=\"" + item.Title + "\">" + AllQuery.MoreNews.Image_Title_Alt(item.ImagesSmall.ToString(), item.Title.ToString(), item.Alt.ToString()) + "</a>";
    //        str += "</div>";
    //        str += "<div class=\"col-lg-12 col-md-12 col-sm-12 col-xs-12 content_ar blog_large_item\">";
    //        //str += "<span class=\"blog_name\">Tin tức</span>";
    //        str += "<h3 class=\"blog-item-name\"><a class=\"text2line\"  href=\"/tin-tuc/" + item.TangName + ".html\"  title=\"" + item.Title + "\">" + AllQuery.MoreNews.Substring_Title(item.Title.ToString()) + "</a></h3>";
    //        str += "<div class=\"summary_ sum text4line\">";
    //        str += AllQuery.MoreNews.Substring_Mota(item.Brief.ToString());
    //        str += "</div>";
    //        str += "</div>";
    //        str += "</div>";
    //        str += "</article>";
    //        str += "</div>";
    //        str += "</div>";
    //    }
    //    return str;
    //}
    #endregion

    #region ALbum
    public static string LoadALbum_Home(IEnumerable<Entity.Album_RutGon> product)
    {
        string str = "";
        foreach (Entity.Album_RutGon item in product)
        {
            str += "        <li class=\" abcolmd\">";
            str += "            <div class=\"abitem\">";
            str += "                <div class=\"img\">";
            str += "                    <a title=\"" + item.Title + "\" href='/album/" + item.TangName + ".html'>" + MoreAll.MoreImage.Image_width_height_Title_Alt(item.ImagesSmall.ToString(), "195", "146", item.Title.ToString(), item.Alt.ToString()) + " <div class=\"imghover\"></div>";
            str += "                    </a>";
            str += "                </div>";
            str += "                <div class=\"tiemtitle\">";
            str += "                    <h2><a title=\"" + item.Title + "\" href='/album//item.TangName.html'>" + item.Title + "</a></h2>";
            str += "                </div>";
            str += "            </div>";
            str += "        </li>";
        }
        return str;
    }

    #endregion

    #region Video
    public static string LoadVideo_Home(IEnumerable<Entity.VideoClip_RutGon> product)
    {
        string str = "";
        foreach (Entity.VideoClip_RutGon item in product)
        {

            str += "<div class=\"col-xs-12 col-md-6 col-sm-6\">";
            str += "<div class=\"artitle-item \">";
            str += "<div class=\"video-container\">";
            str += "<iframe width=\"100%\" class='Videoyoutube' src=\"https://www.youtube.com/embed/" + item.Youtube + "\" frameborder=\"0\" allowfullscreen=\"\"></iframe>";
            str += "</div>";
            str += "<div class=\"article-info-box\">";
            str += "<a title=\"" + item.Title + "\" href=\"/video/" + item.TangName + ".html\" class='title'><h2>" + item.Title + "</h2></a>";

            str += "<div class=\"description\">" + item.Brief + "</div>";
            str += "<a title=\"" + item.Title + "\" href=\"/video/" + item.TangName + ".html\" class=\"viewmore\"> Xem thêm <i class=\"fa fa-angle-right\"></i>";
            str += "</a>";
            str += "</div>";
            str += "</div>";
            str += "</div>";

            //str += "<div class=\"vd-item\">";
            //str += "<div class=\"img\">";
            //str += "    <a title=\"" + item.Title + "\" href=\"/video/" + item.TangName + ".html\">" + MoreAll.MoreImage.Image_width_height_Title_Alt(item.ImagesSmall.ToString(), "195", "146", item.Title.ToString(), item.Alt.ToString()) + "</a>";
            //str += "    <div class=\"pl\"><a title=\"" + item.Title + "\" href=\"/video/" + item.TangName + ".html\">";
            //str += "        <img src=\"/Resources/images/play.png\" /></a></div>";
            //str += "</div>";
            //str += "<span><a title=\"" + item.Title + "\" href=\"/video/" + item.TangName + ".html\">" + item.Title + "</a></span>";
            //str += "</div>";
        }
        return str;
    }
    #endregion

    #region All More
    public static string Name(string ID) //// Tăng và giảm thứ tự trong ô txtOrders
    {
        DatalinqDataContext db = new DatalinqDataContext();
        Menu table = db.Menus.SingleOrDefault(p => p.ID == int.Parse(ID));
        if (table != null)
        {
            return table.Name.ToString();
        }
        return "";
    }

    public static string RequestMenu(string Request)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        string Modul = "";
        ModulControl str = db.ModulControls.SingleOrDefault(p => p.TangName == Request);
        if (str != null)
        {
            Modul = str.Module.ToString();
        }
        return Modul;
    }
    public static string Setting(string giatri)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        string item = "";
        Setting str = db.Settings.SingleOrDefault(p => p.Properties == giatri && p.Lang == MoreAll.MoreAll.Language);
        if (str != null)
        {
            item = str.Value;
        }
        return item.ToString();
    }
    public static string SubMenu(string Capp, string cid)
    {
        string submn = cid;
        List<Entity.MenuID> dt = SMenu.Menu_ID(cid, Capp);
        for (int i = 0; i < dt.Count; i++)
        {
            submn = submn + "," + SubMenu(Capp, dt[i].ID.ToString());
        }
        return submn;
    }

    #endregion

    #region Phân trang
    //Old
    //public static string Phantrang(string Url, int Tongsobanghi, Int16 pages)
    //{
    //    string str = "<div class='Phantrang'>";
    //    if (Tongsobanghi > 1)
    //    {
    //        str += "<a href='" + Url + "?page=1'><< Trang đầu</a>";
    //        for (int i = 1; i <= Tongsobanghi; i++)
    //        {
    //            if (i == pages)
    //            {
    //                str += "<a class='pageactive' href=\"" + Url + "?page=" + i + "\">" + i + "</a>";
    //            }
    //            else
    //            {
    //                str += "<a class='page' href=\"" + Url + "?page=" + i + "\">" + i + "</a>";
    //            }
    //        }
    //        str += "<a href='" + Url + "?page=" + Tongsobanghi + "'>Cuối cùng >></a>";
    //    }
    //    str += "</div>";
    //    return str;
    //}
    //News
    public static string PhantrangAdmin(string Url, int Tongsobanghi, int pages)
    {
        string str = "<div class='PhantrangAD'>";
        if (Tongsobanghi > 1)
        {
            str += "<a href='" + Url + "&page=1'><< Trang đầu</a>";
            int startPage;
            if (Tongsobanghi <= 7)
                startPage = 1;
            else if (pages <= 4)
                startPage = 1;
            else if ((Tongsobanghi - pages) >= 3)
                startPage = pages - 3;
            else startPage = Tongsobanghi - 6;
            if (startPage > 1)
                str += string.Format("<a class=\"aso\">...</a>");
            for (int i = startPage; i <= (Tongsobanghi <= 7 ? Tongsobanghi : startPage + 6); i++)
            {
                if (i == pages)
                {
                    str += "<a class='pageactive' href=\"" + Url + "&page=" + i + "\">" + i + "</a>";
                }
                else
                {
                    str += "<a class='page' href=\"" + Url + "&page=" + i + "\">" + i + "</a>";
                }
            }
            if ((Tongsobanghi - pages > 3) && (Tongsobanghi > 7))
                str += string.Format("<a class=\"aso\">...</a>");
            str += "<a href='" + Url + "&page=" + Tongsobanghi + "'>Cuối cùng >></a>";
        }
        str += "</div>";
        return str;
    }
    public static string Phantrang_loc(string Url, string UrlLoc, int Tongsobanghi, Int16 pages)
    {
        // Bổ xung id vào để phục vụ phần lọc js,  theo mầu , kích thước, giá, ... ko bị lỗi
        string str = "<div class='Phantrang'>";
        if (Tongsobanghi > 1)
        {
            str += "<a id=\"1\" href='" + Url + "?page=1" + UrlLoc + "'><< Trang đầu</a>";
            for (int i = 1; i <= Tongsobanghi; i++)
            {
                if (i == pages)
                {
                    str += "<a class='pageactive' id=\"" + i + "\" href=\"" + Url + "?page=" + i + "" + UrlLoc + "\">" + i + "</a>";
                }
                else
                {
                    str += "<a class='page' id=\"" + i + "\" href=\"" + Url + "?page=" + i + "" + UrlLoc + "\">" + i + "</a>";
                }
            }
            str += "<a id=\"" + Tongsobanghi + "\" href='" + Url + "?page=" + Tongsobanghi + "" + UrlLoc + "'>Cuối cùng >></a>";
        }
        str += "</div>";
        return str;
    }
    public static string Phantrang(string Url, int Tongsobanghi, int pages)
    {
        string str = "<div class='Phantrang'>";
        if (Tongsobanghi > 1)
        {
            str += "<a href='" + Url + "?page=1'><< Trang đầu</a>";
            int startPage;
            if (Tongsobanghi <= 7)
                startPage = 1;
            else if (pages <= 4)
                startPage = 1;
            else if ((Tongsobanghi - pages) >= 3)
                startPage = pages - 3;
            else startPage = Tongsobanghi - 6;
            if (startPage > 1)
                str += string.Format("<a class=\"aso\">...</a>");
            for (int i = startPage; i <= (Tongsobanghi <= 7 ? Tongsobanghi : startPage + 6); i++)
            {
                if (i == pages)
                {
                    str += "<a class='pageactive' href=\"" + Url + "?page=" + i + "\">" + i + "</a>";
                }
                else
                {
                    str += "<a class='page' href=\"" + Url + "?page=" + i + "\">" + i + "</a>";
                }
            }
            if ((Tongsobanghi - pages > 3) && (Tongsobanghi > 7))
                str += string.Format("<a class=\"aso\">...</a>");
            str += "<a href='" + Url + "?page=" + Tongsobanghi + "'>Cuối cùng >></a>";
        }
        str += "</div>";
        return str;
    }
    #endregion

    #region Truy Vấn Linq
    public static IEnumerable<Menu> Name_Text_Menu(string sql)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        return db.ExecuteQuery<Menu>(@"" + sql + "");
    }
    public static IEnumerable<product> Name_Text_Pro(string sql)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        return db.ExecuteQuery<product>(@"" + sql + "");
    }
    public static IEnumerable<New> Name_Text_News(string sql)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        return db.ExecuteQuery<New>(@"" + sql + "");
    }

    #endregion

    #region All Tổng hợp
    public static string Link301()
    {
        string ssl = "";
        if (Commond.Setting("SSL").Equals("1"))
        {
            ssl = "https://";
        }
        string bc = System.Web.HttpContext.Current.Request.Url.Authority + System.Web.HttpContext.Current.Request.RawUrl.ToString();
        if (!bc.Contains("localhost"))
        {
            List<Entity.Menu> dt = SMenu.Name_Text("SELECT * FROM [Menu] where capp='" + More.SC + "'  and Status=1  and Name like N'%" + bc.Replace("/Page/Error?aspxerrorpath=", "") + "'");
            if (dt.Count > 0)
            {
                System.Web.HttpContext.Current.Response.Redirect(dt[0].Description);
            }
        }
        System.Web.HttpContext.Current.Response.Redirect("/page-404.html");
        return "";
    }
    public static string label(string id)
    {
        string language = Captionlanguage.Language;
        if (System.Web.HttpContext.Current.Session["language"] != null)
        {
            language = System.Web.HttpContext.Current.Session["language"].ToString();
        }
        else
        {
            System.Web.HttpContext.Current.Session["language"] = language;
            language = System.Web.HttpContext.Current.Session["language"].ToString();
        }
        return Captionlanguage.GetLabel(id, language);
    }
    #endregion

    public static bool Sql(string sql)
    {
        using (SqlConnection dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
        {
            using (SqlCommand dbCmd = new SqlCommand(sql, dbConn))
            {
                dbCmd.CommandType = CommandType.Text;
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
                dbConn.Close();
            }
        }
        return true;
    }

    // Tìm kiếm theo ngày , từ ngày đến ngày
    //    DateTime fDate, tDate;
    //if (Commond.Check(txtNgayThangNam.Text))
    //    fDate = Commond.ConvertStringToDate(txtNgayThangNam.Text, "dd/MM/yyyy");
    //if (Commond.Check(txtDenNgayThangNam.Text))
    //    tDate = Commond.ConvertStringToDate(txtDenNgayThangNam.Text, "dd/MM/yyyy");

    //if (txtNgayThangNam.Text != "" && txtDenNgayThangNam.Text != "")
    //{
    //    sql += " AND NgayTao IS NOT NULL AND ((DATEADD(dd,-31,NgayTao)>='" + Commond.FormatDate(fDate.Date) + " 00:00:00.000' OR NgayTao>='" + Commond.FormatDate(fDate.Date) + " 00:00:00.000') AND NgayTao <='" + Commond.FormatDate(tDate.Date) + " 23:59:59.999')";
    //}
    //else if (txtNgayThangNam.Text == "" && txtDenNgayThangNam.Text != "")
    //{
    //    sql += " AND NgayTao IS NOT NULL AND NgayTao <='" + Commond.FormatDate(tDate.Date) + " 23:59:59.999'";
    //}
    //else if (txtNgayThangNam.Text != "" && txtDenNgayThangNam.Text == "")
    //{
    //    sql += " AND NgayTao IS NOT NULL AND (DATEADD(dd,-31,NgayTao)>='" + Commond.FormatDate(fDate.Date) + " 00:00:00.000' OR NgayTao>='" + Commond.FormatDate(fDate.Date) + " 00:00:00.000')";
    //}

    public static bool Check(object String)
    {
        return ((String != null) && (String.ToString().Trim().Length > 0));
    }
    public static DateTime ConvertStringToDate(string Date, string FromFormat)
    {
        return DateTime.ParseExact(Date, FromFormat, null);
    }
    public static string FormatDate(object date)
    {
        if (date != null)
        {
            if (date.ToString().Trim().Length > 0 && date != null)
            {
                if (DateTime.Parse(date.ToString()).Year != 1900)
                {
                    DateTime dNgay = Convert.ToDateTime(date.ToString());
                    return ((DateTime)dNgay).ToString("yyyy-MM-dd");
                }
            }

        }
        return "";
    }


}
