using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using VS.ECommerce_MVC;

public class SQLProducts
{
    public static IEnumerable<product> ListNewsindex(int page, int pageSize)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        IQueryable<product> model = db.products;
        return model.OrderByDescending(x => x.Create_Date).ToPagedList(page, pageSize);
    }
    public static product ViewDetail(int? id)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        return db.products.SingleOrDefault(p => p.ipid == id);
    }
    public static product ViewDetail_TangName(string TangName)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        return db.products.SingleOrDefault(p => p.TangName == TangName);
    }
    
}