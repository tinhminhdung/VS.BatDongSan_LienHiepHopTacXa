using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VS.ECommerce_MVC
{
    public class RouteConfig
    {
        //string sss = System.Web.HttpContext.Current.Request.ToString();
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Thành viên
            routes.MapRoute(name: "Members-dang-ky", url: "dang-ky.html", defaults: new { controller = "Members", action = "Dang_Ky" });
            routes.MapRoute(name: "Members-dang-nhap", url: "dang-nhap.html", defaults: new { controller = "Members", action = "Dang_Nhap" });
            routes.MapRoute(name: "Members-ho-so", url: "ho-so-thanh-vien.html", defaults: new { controller = "Members", action = "HoSoThanhVien" });
            routes.MapRoute(name: "Members-doi-mat-khau", url: "doi-mat-khau.html", defaults: new { controller = "Members", action = "DoiMatKhau" });
            routes.MapRoute(name: "Members-Quen-mat-khau", url: "Quen-mat-khau.html", defaults: new { controller = "Members", action = "QuenMatKhau" });
            routes.MapRoute(name: "Members-lich-su-mua-hang", url: "lich-su-mua-hang.html", defaults: new { controller = "Members", action = "LichSuMuaHang" });
            routes.MapRoute("Members-chi-tiet-lich-su-mua-hang", "account/orders/{id}/{*catchall}", new { controller = "Members", action = "ChiTietDonHang", id = UrlParameter.Optional }, new { controller = "^M.*", action = "^ChiTietDonHang" });

            routes.MapRoute(name: "Members-DangTin", url: "dang-tin.html", defaults: new { controller = "Members", action = "DangTin" });
            routes.MapRoute(name: "Members-danh-sach-dang-tin", url: "danh-sach-tin-dang.html", defaults: new { controller = "Members", action = "DanhSachDangTin" });

            routes.MapRoute(name: "Members-XoaBaiViet", url: "XoaBaiViet.html", defaults: new { controller = "Members", action = "XoaBaiViet" });
            routes.MapRoute(name: "Members-edit", url: "edit-dang-tin.html", defaults: new { controller = "Members", action = "EditDangTin" });

            routes.MapRoute(name: "LinkGioiThieu", url: "link-affiliate.html", defaults: new { controller = "Members", action = "LinkGioiThieu" });
            routes.MapRoute(name: "danh-sach-thanh-vien", url: "danh-sach-thanh-vien.html", defaults: new { controller = "Members", action = "MThanhVien" });

            routes.MapRoute(name: "vi-tien", url: "wallet.html", defaults: new { controller = "Members", action = "Vidiem" });
            routes.MapRoute(name: "lich-su-hoa-hong", url: "lich-su-hoa-hong.html", defaults: new { controller = "Members", action = "MHoaHong" });
            routes.MapRoute(name: "thanh-toan", url: "rut-tien.html", defaults: new { controller = "Members", action = "ThanhToan" });
            routes.MapRoute(name: "Thanh-Toan-LS", url: "lich-su-thanh-toan.html", defaults: new { controller = "Members", action = "MLichSuThanhToan" });

            //Page404
            routes.MapRoute(name: "Page404", url: "page-404.html", defaults: new { controller = "AllPage", action = "NotFound" });

            //Page
            routes.MapRoute("Page", "page/{hp}.html/{*catchall}", new { controller = "Page", action = "index", hp = UrlParameter.Optional }, new { controller = "^Page.*", action = "^index" });

            // Liên hệ
            // routes.MapRoute(name: "Contact", url: "lien-he.html", defaults: new { controller = "Contact", action = "Index" });
            routes.MapRoute(name: "Contact", url: "lien-he.html", defaults: new { controller = "Contact", action = "Index" });


            // Code mẫu
            routes.MapRoute(name: "feedback", url: "feedback.html", defaults: new { controller = "CodeMau", action = "LienHe" });


            //Album
            routes.MapRoute(name: "Album", url: "thu-vien-anh.html", defaults: new { controller = "Album", action = "Index" });
            routes.MapRoute("CateAlbum", "danh-muc-anh/{hp}.html/{*catchall}", new { controller = "Album", action = "Category", hp = UrlParameter.Optional }, new { controller = "^A.*", action = "^Category$" });
            routes.MapRoute("DetailAlbum", "album/{hp}.html/{*catchall}", new { controller = "Album", action = "Detail", hp = UrlParameter.Optional }, new { controller = "^A.*", action = "^Detail$" });

            //Video
            routes.MapRoute(name: "Video", url: "thu-vien-video.html", defaults: new { controller = "Video", action = "Index" });
            routes.MapRoute("CateVideo", "danh-muc-video/{hp}.html/{*catchall}", new { controller = "Video", action = "Category", hp = UrlParameter.Optional }, new { controller = "^V.*", action = "^Category$" });
            routes.MapRoute("DetailVideo", "video/{hp}.html/{*catchall}", new { controller = "Video", action = "Detail", hp = UrlParameter.Optional }, new { controller = "^V.*", action = "^Detail$" });

            //Tin tức
            routes.MapRoute(name: "Tintuc", url: "tin-tuc-new.html", defaults: new { controller = "News", action = "Index" });
            //routes.MapRoute("Tintuc", "tin-tuc-new", new { controller = "News", action = "Index"}, new { controller = "^N.*", action = "^Index" });
            routes.MapRoute("News", "danh-muc-tin/{hp}.html/{*catchall}", new { controller = "News", action = "Category", hp = UrlParameter.Optional }, new { controller = "^N.*", action = "^Category$" });
            routes.MapRoute("DetailNews", "tin-tuc/{hp}.html/{*catchall}", new { controller = "News", action = "Detail", hp = UrlParameter.Optional }, new { controller = "^N.*", action = "^Detail$" });

            //San phẩm
            routes.MapRoute(name: "san-pham", url: "san-pham-news.html", defaults: new { controller = "Products", action = "Index" });
            //routes.MapRoute("san-pham", "san-pham-news", new { controller = "Products", action = "Index" }, new { controller = "^P.*", action = "^Index" });
            routes.MapRoute("Products", "danh-muc/{hp}.html/{*catchall}", new { controller = "Products", action = "Category", hp = UrlParameter.Optional }, new { controller = "^P.*", action = "^Category$" });
            routes.MapRoute("DetailProducts", "san-pham/{hp}.html/{*catchall}", new { controller = "Products", action = "Detail", hp = UrlParameter.Optional }, new { controller = "^P.*", action = "^Detail$" });
            routes.MapRoute("SearchProducts", "Search.html/{*catchall}", new { controller = "Products", action = "Search", hp = UrlParameter.Optional }, new { controller = "^P.*", action = "^Search" });
            routes.MapRoute("TimKiem", "tim-kiem.html/{*catchall}", new { controller = "Products", action = "TimKiem", hp = UrlParameter.Optional }, new { controller = "^P.*", action = "^TimKiem" });
            routes.MapRoute("TinhThanh", "tai/{hp}.html", new { controller = "Products", action = "TinhThanh", hp = UrlParameter.Optional }, new { controller = "^P.*", action = "^TinhThanh" });

            
            // Cart
            routes.MapRoute(name: "XemGioHang", url: "gio-hang.html", defaults: new { controller = "Cart", action = "XemGioHang" });
            routes.MapRoute(name: "DatHang", url: "dat-hang.html", defaults: new { controller = "Cart", action = "DatHang" });

            routes.MapRoute(name: "Confirm Order", url: "xac-nhan-don-hang.html", defaults: new { controller = "Cart", action = "ConfirmOrder" });
            routes.MapRoute(name: "Cancel Order", url: "huy-don-hang.html", defaults: new { controller = "Cart", action = "CancelOrder" });

            // Message Cart
            routes.MapRoute("Removecart", "Message-{msg}.html", new { controller = "Cart", action = "Message", msg = UrlParameter.Optional }, new { controller = "^C.*", action = "^Message" });

            //// Add this code to handle non-existing urls
            //routes.MapRoute(name: "404-PageNotFound", // This will handle any non-existing urls
            //    url: "{*url}", // "Shared" is the name of your error controller, and "Error" is the action/page // that handles all your custom errors
            //    defaults: new { controller = "Shared", action = "Error" });

            //Default
            routes.MapRoute(name: "Default", url: "{controller}/{action}/{id}", defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}

//{*catchall} để chuẩn định dạng chữ và số
// controller = "^P.*", action = "^Detail$" } để truyền đúng trang detail ko sợ bị nhầm nó lấy trang khác
//hp, id  truyền requet bên này như thế nào thì phải hứng bên kia tên trùng như thế (hp= UrlParameter.Optional) hoặc (id= UrlParameter.Optional)
