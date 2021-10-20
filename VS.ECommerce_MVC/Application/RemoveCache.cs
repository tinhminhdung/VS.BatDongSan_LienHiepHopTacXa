using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

public class RemoveCache
{

    public static string Home()
    {
        HttpContext.Current.Cache.Remove("Title");
        HttpContext.Current.Cache.Remove("Header");
        return "";
    }
    public static string Menu()
    {
        HttpContext.Current.Cache.Remove("MenuTop");
        HttpContext.Current.Cache.Remove("ShowMenuPage");
        HttpContext.Current.Cache.Remove("MenuBottom");
        HttpContext.Current.Cache.Remove("ShowMenuMobile");
        return "";
    }
    public static string Products()
    {
        HttpContext.Current.Cache.Remove("ShowNhomsanpham");
        // Xóa cache Dạng MVC
        ///Home/ShowDemo  
        //--> Home-> là thư mục
        //--> ShowDemo-> là ShowDemo.cshtml
        //HttpResponse.RemoveOutputCacheItem("/Home/ShowDemo");
        // HttpResponse.RemoveOutputCacheItem("/Products/Detail");
        // HttpResponse.RemoveOutputCacheItem("/Products/Category");
        return "";
    }
    public static string News()
    {
       HttpContext.Current.Cache.Remove("Top1News");
       HttpContext.Current.Cache.Remove("Top2News");
       HttpContext.Current.Cache.Remove("TuVan");
       HttpContext.Current.Cache.Remove("PhongThuy");
        return "";
    }
    public static string Album()
    {
        //HttpContext.Current.Cache.Remove("ShowNhomsanpham");
        return "";
    }
    public static string Video()
    {
        //HttpContext.Current.Cache.Remove("ShowNhomsanpham");

        // Cache Database 
        MemoryCache.Default.Remove("DanhMuc");
        return "";
    }

    public static string NewsFooter()
    {
        //HttpContext.Current.Cache.Remove("ShowNhomsanpham");
        return "";
    }
    public static string QuangCao()
    {
        HttpContext.Current.Cache.Remove("PhuongThucVanChuyen");
        return "";
    }
}
