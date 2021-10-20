using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using VS.ECommerce_MVC;


public class SQLCart
{
    public static IEnumerable<LCart> ListLichSu(int page, int pageSize, string IDThanhVien)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        IQueryable<LCart> model = db.LCarts.Where(x => x.IDThanhVien == int.Parse(IDThanhVien));
        return model.OrderByDescending(x => x.Create_Date).ToPagedList(page, pageSize);
    }
}
public class SQLNews
{
    public static IEnumerable<New> ListNewsindex(int page, int pageSize)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        IQueryable<New> model = db.News;
        return model.OrderByDescending(x => x.Create_Date).ToPagedList(page, pageSize);
    }
    public static New ViewDetail(int? id)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        return db.News.SingleOrDefault(p => p.inid == id);
    }
    public static New Detail(string hp)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        return db.News.SingleOrDefault(p => p.TangName == hp);
    }
    public static VideoClip VideoDetail(string hp)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        return db.VideoClips.SingleOrDefault(p => p.TangName == hp);
    }
}