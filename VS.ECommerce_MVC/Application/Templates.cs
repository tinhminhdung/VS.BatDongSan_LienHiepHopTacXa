using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using Services;
using MoreAll;

namespace VS.ECommerce_MVC.App
{
    public class Template
    {
        public static string WebTitle(string hp)
        {
            DatalinqDataContext db = new DatalinqDataContext();
            #region MyRegion
            if (hp.Contains("/san-pham/"))
            {
                hp = Removelink.RemoveUrl(hp);
                product dt = db.products.SingleOrDefault(p => p.TangName == hp);
                if (dt != null)
                {
                    if (dt.Titleseo.Length > 0)
                    {
                        return dt.Titleseo;
                    }
                    return dt.Name;
                }
            }
            else if (hp.Contains("/tin-tuc/"))
            {
                hp = Removelink.RemoveUrl(hp);
                New dt = db.News.SingleOrDefault(p => p.TangName == hp);
                if (dt != null)
                {
                    if (dt.Titleseo.Length > 0)
                    {
                        return dt.Titleseo;
                    }
                    return dt.Title;
                }
            }
            //else if (Modul == "4")
            //{
            //    Nfooter dt = db.Nfooters.SingleOrDefault(p => p.TangName == hp);
            //    if (dt != null)
            //    {
            //        if (dt.Titleseo.Length > 0)
            //        {
            //            return dt.Titleseo;
            //        }
            //        return dt.Title;
            //    }
            //}
            else if (hp.Contains("/album/"))
            {
                hp = Removelink.RemoveUrl(hp);
                LAlbum dt = db.LAlbums.SingleOrDefault(p => p.TangName == hp);
                if (dt != null)
                {
                    if (dt.Titleseo.Length > 0)
                    {
                        return dt.Titleseo;
                    }
                    return dt.Title;
                }
            }
            else if (hp.Contains("/video/"))
            {
                hp = Removelink.RemoveUrl(hp);
                VideoClip dt = db.VideoClips.SingleOrDefault(p => p.TangName == hp);
                if (dt != null)
                {
                    if (dt.Titleseo.Length > 0)
                    {
                        return dt.Titleseo;
                    }
                    return dt.Title;
                }
            }
            //else if (Modul == "11")
            //{
            //    Gioithieu dt = db.Gioithieus.SingleOrDefault(p => p.TangName == hp);
            //    if (dt != null)
            //    {
            //        if (dt.Titleseo.Length > 0)
            //        {
            //            return dt.Titleseo;
            //        }
            //        return dt.Title;
            //    }
            //}
            else if (hp.Contains("/danh-muc-tin/") || hp.Contains("/danh-muc/") || hp.Contains("/danh-muc-video/") || hp.Contains("/danh-muc-anh/") || hp.Contains("/page/"))
            {
                hp = Removelink.RemoveUrl(hp);
                if (hp != "")
                {
                    Menu dt = db.Menus.SingleOrDefault(p => p.TangName == hp);
                    if (dt != null)
                    {
                        if (dt.Titleseo.Length > 0)
                        {
                            return dt.Titleseo;
                        }
                        return dt.Name;
                    }
                    else
                    {
                        try
                        {
                            Menu dts = db.Menus.SingleOrDefault(p => p.Link.Contains(hp));
                            if (dts != null)
                            {
                                if (dts.Titleseo.Length > 0)
                                {
                                    return dts.Titleseo;
                                }
                                return dts.Name;
                            }
                        }
                        catch (Exception)
                        {
                            return (Commond.Setting("webname"));
                        }
                    }
                }
            }
            else
            {
                if (hp == "/")// Nếu là trang chủ
                {
                    return (Commond.Setting("webname"));
                }
                else
                {
                    try
                    {
                        Menu dts = db.Menus.SingleOrDefault(p => p.Link.Contains(hp));
                        if (dts != null)
                        {
                            if (dts.Titleseo.Length > 0)
                            {
                                return dts.Titleseo;
                            }
                            return dts.Name;
                        }
                    }
                    catch (Exception)
                    {
                        return (Commond.Setting("webname"));
                    }
                }
            }
            return (Commond.Setting("webname"));
            #endregion
        }

        public static string Keyword(string hp)
        {
            DatalinqDataContext db = new DatalinqDataContext();
            #region MyRegion
            if (hp.Contains("/san-pham/"))
            {
                hp = Removelink.RemoveUrl(hp);
                product dt = db.products.SingleOrDefault(p => p.TangName == hp);
                if (dt != null)
                {
                    if (dt.Keyword.Length > 0)
                    {
                        return dt.Keyword;
                    }
                    return dt.Brief;
                }
            }
            else if (hp.Contains("/tin-tuc/"))
            {
                hp = Removelink.RemoveUrl(hp);
                New dt = db.News.SingleOrDefault(p => p.TangName == hp);
                if (dt != null)
                {
                    if (dt.Keyword.Length > 0)
                    {
                        return dt.Keyword;
                    }
                    return dt.Brief;
                }
            }
            //else if (Modul == "4")
            //{
            //    Nfooter dt = db.Nfooters.SingleOrDefault(p => p.TangName == hp);
            //    if (dt != null)
            //    {
            //        if (dt.Keyword.Length > 0)
            //        {
            //            return dt.Keyword;
            //        }
            //        return dt.Brief;
            //    }
            //}
            else if (hp.Contains("/album/"))
            {
                hp = Removelink.RemoveUrl(hp);
                LAlbum dt = db.LAlbums.SingleOrDefault(p => p.TangName == hp);
                if (dt != null)
                {
                    if (dt.Keyword.Length > 0)
                    {
                        return dt.Keyword;
                    }
                    return dt.Brief;
                }
            }
            else if (hp.Contains("/video/"))
            {
                hp = Removelink.RemoveUrl(hp);
                VideoClip dt = db.VideoClips.SingleOrDefault(p => p.TangName == hp);
                if (dt != null)
                {
                    if (dt.Keyword.Length > 0)
                    {
                        return dt.Keyword;
                    }
                    return dt.Brief;
                }
            }
            //else if (Modul == "11")
            //{
            //    Gioithieu dt = db.Gioithieus.SingleOrDefault(p => p.TangName == hp);
            //    if (dt != null)
            //    {
            //        if (dt.Keyword.Length > 0)
            //        {
            //            return dt.Keyword;
            //        }
            //        return dt.Brief;
            //    }
            //}
            else if (hp.Contains("/danh-muc-tin/") || hp.Contains("/danh-muc/") || hp.Contains("/danh-muc-video/") || hp.Contains("/danh-muc-anh/") || hp.Contains("/page/"))
            {
                hp = Removelink.RemoveUrl(hp);
                if (hp != "")
                {
                    Menu dt = db.Menus.SingleOrDefault(p => p.TangName == hp);
                    if (dt != null)
                    {
                        if (dt.Titleseo.Length > 0)
                        {
                            return dt.Keyword;
                        }
                        return dt.Name;
                    }
                    else
                    {
                        try
                        {
                            Menu dts = db.Menus.SingleOrDefault(p => p.Link.Contains(hp));
                            if (dts != null)
                            {
                                if (dts.Titleseo.Length > 0)
                                {
                                    return dts.Keyword;
                                }
                                return dts.Name;
                            }
                        }
                        catch (Exception)
                        {
                            return (Commond.Setting("searchkeyword"));
                        }
                    }
                }
            }
            else
            {
                if (hp == "/")// Nếu là trang chủ
                {
                    return (Commond.Setting("searchkeyword"));
                }
                else
                {
                    try
                    {
                        Menu dts = db.Menus.SingleOrDefault(p => p.Link.Contains(hp));
                        if (dts != null)
                        {
                            if (dts.Titleseo.Length > 0)
                            {
                                return dts.Keyword;
                            }
                            return dts.Name;
                        }
                    }
                    catch (Exception)
                    {
                        return (Commond.Setting("searchkeyword"));
                    }
                }
            }
            return (Commond.Setting("searchkeyword"));
            #endregion
        }

        public static string Description(string hp)
        {
            DatalinqDataContext db = new DatalinqDataContext();
            #region MyRegion
            if (hp.Contains("/san-pham/"))
            {
                hp = Removelink.RemoveUrl(hp);
                product dt = db.products.SingleOrDefault(p => p.TangName == hp);
                if (dt != null)
                {
                    if (dt.Meta.Length > 0)
                    {
                        return dt.Meta;
                    }
                    return dt.Brief;
                }
            }
            else if (hp.Contains("/tin-tuc/"))
            {
                hp = Removelink.RemoveUrl(hp);
                New dt = db.News.SingleOrDefault(p => p.TangName == hp);
                if (dt != null)
                {
                    if (dt.Meta.Length > 0)
                    {
                        return dt.Meta;
                    }
                    return dt.Brief;
                }
            }
            //else if (Modul == "4")
            //{
            //    Nfooter dt = db.Nfooters.SingleOrDefault(p => p.TangName == hp);
            //    if (dt != null)
            //    {
            //        if (dt.Meta.Length > 0)
            //        {
            //            return dt.Meta;
            //        }
            //        return dt.Brief;
            //    }
            //}
            else if (hp.Contains("/album/"))
            {
                hp = Removelink.RemoveUrl(hp);
                LAlbum dt = db.LAlbums.SingleOrDefault(p => p.TangName == hp);
                if (dt != null)
                {
                    if (dt.Meta.Length > 0)
                    {
                        return dt.Meta;
                    }
                    return dt.Brief;
                }
            }
            else if (hp.Contains("/video/"))
            {
                hp = Removelink.RemoveUrl(hp);
                VideoClip dt = db.VideoClips.SingleOrDefault(p => p.TangName == hp);
                if (dt != null)
                {
                    if (dt.Meta.Length > 0)
                    {
                        return dt.Meta;
                    }
                    return dt.Brief;
                }
            }
            //else if (Modul == "11")
            //{
            //    Gioithieu dt = db.Gioithieus.SingleOrDefault(p => p.TangName == hp);
            //    if (dt != null)
            //    {
            //        if (dt.Meta.Length > 0)
            //        {
            //            return dt.Meta;
            //        }
            //        return dt.Brief;
            //    }
            //}
            else if (hp.Contains("/danh-muc-tin/") || hp.Contains("/danh-muc/") || hp.Contains("/danh-muc-video/") || hp.Contains("/danh-muc-anh/") || hp.Contains("/page/"))
            {
                hp = Removelink.RemoveUrl(hp);
                if (hp != "")
                {
                    Menu dt = db.Menus.SingleOrDefault(p => p.TangName == hp);
                    if (dt != null)
                    {
                        if (dt.Titleseo.Length > 0)
                        {
                            return dt.Meta;
                        }
                        return dt.Name;
                    }
                    else
                    {
                        try
                        {
                            Menu dts = db.Menus.SingleOrDefault(p => p.Link.Contains(hp));
                            if (dts != null)
                            {
                                if (dts.Titleseo.Length > 0)
                                {
                                    return dts.Meta;
                                }
                                return dts.Name;
                            }
                        }
                        catch (Exception)
                        {
                            return (Commond.Setting("keyworddescription"));
                        }
                    }
                }
                else
                {
                    if (hp == "/")// Nếu là trang chủ
                    {
                        return (Commond.Setting("keyworddescription"));
                    }
                    else
                    {
                        try
                        {
                            Menu dts = db.Menus.SingleOrDefault(p => p.Link.Contains(hp));
                            if (dts != null)
                            {
                                if (dts.Titleseo.Length > 0)
                                {
                                    return dts.Meta;
                                }
                                return dts.Name;
                            }
                        }
                        catch (Exception)
                        {
                            return (Commond.Setting("keyworddescription"));
                        }
                    }
                }
            }
            return (Commond.Setting("keyworddescription"));
            #endregion
        }

        public static string Facebook(string url, string hp)
        {
            DatalinqDataContext db = new DatalinqDataContext();
            #region MyRegion
            if (hp.Contains("/tin-tuc/"))
            {
                hp = Removelink.RemoveUrl(hp);
                New dt = db.News.SingleOrDefault(p => p.TangName == hp);
                StringBuilder str = new StringBuilder();
                if (dt != null)
                {
                    string Images = "";
                    string Brief = "";
                    if (dt.Images.Length > 0)
                    {
                        Images = dt.Images;
                    }
                    if (dt.Keyword.Length > 0) { Brief = MoreAll.MoreAll.RemoveHTMLTags(MoreAll.MoreAll.Substring(dt.Keyword, 250)); } else { if (dt.Brief.Length > 0) { Brief = MoreAll.MoreAll.RemoveHTMLTags(MoreAll.MoreAll.Substring(dt.Brief, 250)); } }
                    str.Append("<meta property=\"fb:app_id\" content=\"" + Commond.Setting("txtfbapp_id") + "\" />");
                    str.Append("<meta property=\"og:site_name\" content=\"" + url.Replace("http://", "").Replace("https://", "") + "\" />");
                    //str.Append( "<meta property=\"article:publisher\" content=\"" + Other.Giatri("txtfacebook") + "\" />");
                    str.Append("<meta property=\"og:rich_attachment\" content=\"true\" />");
                    str.Append("<meta property=\"og:type\" content=\"article\" />");
                    str.Append("<meta property=\"og:url\" content=\"" + url + "/tin-tuc/" + hp + ".html\" />");
                    str.Append("<meta property=\"og:title\" content=\"" + dt.Title + "\" />");
                    str.Append("<meta property=\"og:description\" content=\"" + Brief + "\" />");
                    str.Append("<meta property=\"og:image\" content=\"" + url + Images + "\" />");
                    str.Append("<meta property=\"og:image:width\" content=\"720\" />");
                    str.Append("<meta property=\"og:image:height\" content=\"480\" />");
                    str.Append("<meta property=\"article:published_time\" content=\"" + MoreAll.MoreAll.FormatDate(dt.Create_Date) + "\" />");
                    str.Append("<meta property=\"article:modified_time\" content=\"" + MoreAll.MoreAll.FormatDate(dt.Modified_Date) + "\" />");
                    //str.Append( " <meta property=\"article:section\" content=\"" + More.DetaiName(dt.icid.ToString()) + "\" />");

                    str.Append("<meta name=\"twitter:card\" content=\"summary_large_image\">");
                    str.Append("<meta name=\"twitter:site\" content=\"" + url + "/tin-tuc/" + hp + ".html\"> ");
                    str.Append(" <meta name=\"twitter:title\" content=\"" + dt.Title + "\">");
                    str.Append(" <meta name=\"twitter:description\" content=\"" + Brief + "\">");
                    str.Append("<meta name=\"twitter:image:src\" content=\"" + url + Images + "\">");

                }
                return str.ToString();
            }
            else if (hp.Contains("/san-pham/"))
            {
                hp = Removelink.RemoveUrl(hp);
                product dt = db.products.SingleOrDefault(p => p.TangName == hp);
                StringBuilder str = new StringBuilder();
                if (dt != null)
                {
                    string Images = "";
                    string Brief = "";
                    if (dt.Images.Length > 0)
                    {
                        Images = dt.Images;
                    }
                    if (dt.Keyword.Length > 0) { Brief = MoreAll.MoreAll.RemoveHTMLTags(MoreAll.MoreAll.Substring(dt.Keyword, 250)); } else { if (dt.Brief.Length > 0) { Brief = MoreAll.MoreAll.RemoveHTMLTags(MoreAll.MoreAll.Substring(dt.Brief, 250)); } }
                    str.Append("<meta property=\"fb:app_id\" content=\"" + Commond.Setting("txtfbapp_id") + "\" />");
                    str.Append("<meta property=\"og:site_name\" content=\"" + url.Replace("http://", "").Replace("https://", "") + "\" />");
                    str.Append("<meta property=\"og:rich_attachment\" content=\"true\" />");
                    // str.Append( "<meta property=\"article:publisher\" content=\"" + Other.Giatri("txtfacebook") + "\" />");
                    str.Append("<meta property=\"og:type\" content=\"article\" />");
                    str.Append("<meta property=\"og:url\" content=\"" + url + "/san-pham/" + hp + ".html\" />");
                    str.Append("<meta property=\"og:title\" content=\"" + dt.Name + "\" />");
                    str.Append("<meta property=\"og:description\" content=\"" + Brief + "\" />");
                    str.Append("<meta property=\"og:image\" content=\"" + url + Images + "\" />");
                    str.Append("<meta property=\"og:image:width\" content=\"720\" />");
                    str.Append("<meta property=\"og:image:height\" content=\"480\" />");
                    str.Append("<meta property=\"article:published_time\" content=\"" + MoreAll.MoreAll.FormatDate(dt.Create_Date) + "\" />");
                    str.Append("<meta property=\"article:modified_time\" content=\"" + MoreAll.MoreAll.FormatDate(dt.Modified_Date) + "\" />");
                    // str.Append( " <meta property=\"article:section\" content=\"" + More.DetaiName(dt.icid) + "\" />");

                    str.Append("<meta name=\"twitter:card\" content=\"summary_large_image\">");
                    str.Append("<meta name=\"twitter:site\" content=\"" + url + "/san-pham/" + hp + ".html\"> ");
                    str.Append(" <meta name=\"twitter:title\" content=\"" + dt.Name + "\">");
                    str.Append(" <meta name=\"twitter:description\" content=\"" + Brief + "\">");
                    str.Append("<meta name=\"twitter:image:src\" content=\"" + url + Images + "\">");

                }
                return str.ToString();
            }
            else if (hp.Contains("/video/"))
            {
                hp = Removelink.RemoveUrl(hp);
                VideoClip dt = db.VideoClips.SingleOrDefault(p => p.TangName == hp);
                StringBuilder str = new StringBuilder();
                if (dt != null)
                {
                    string Images = "";
                    string Brief = "";
                    if (dt.Images.Length > 0)
                    {
                        Images = dt.Images;
                    }
                    if (dt.Keyword.Length > 0) { Brief = MoreAll.MoreAll.RemoveHTMLTags(MoreAll.MoreAll.Substring(dt.Keyword, 250)); } else { if (dt.Brief.Length > 0) { Brief = MoreAll.MoreAll.RemoveHTMLTags(MoreAll.MoreAll.Substring(dt.Brief, 250)); } }
                    str.Append("<meta property=\"fb:app_id\" content=\"" + Commond.Setting("txtfbapp_id") + "\" />");
                    str.Append("<meta property=\"og:site_name\" content=\"" + url.Replace("http://", "").Replace("https://", "") + "\" />");
                    str.Append("<meta property=\"og:rich_attachment\" content=\"true\" />");
                    //str.Append( "<meta property=\"article:publisher\" content=\"" + Other.Giatri("txtfacebook") + "\" />");
                    str.Append("<meta property=\"og:type\" content=\"article\" />");
                    str.Append("<meta property=\"og:url\" content=\"" + url + "/video/" + hp + ".html\" />");
                    str.Append("<meta property=\"og:title\" content=\"" + dt.Title + "\" />");
                    str.Append("<meta property=\"og:description\" content=\"" + Brief + "\" />");
                    str.Append("<meta property=\"og:image\" content=\"" + url + Images + "\" />");
                    str.Append("<meta property=\"og:image:width\" content=\"720\" />");
                    str.Append("<meta property=\"og:image:height\" content=\"480\" />");
                    str.Append("<meta property=\"article:published_time\" content=\"" + MoreAll.MoreAll.FormatDate(dt.Create_Date) + "\" />");
                    str.Append("<meta property=\"article:modified_time\" content=\"" + MoreAll.MoreAll.FormatDate(dt.Modified_Date) + "\" />");
                    // str.Append( " <meta property=\"article:section\" content=\"" + More.DetaiName(dt.Menu_ID) + "\" />");

                    str.Append("<meta name=\"twitter:card\" content=\"summary_large_image\">");
                    str.Append("<meta name=\"twitter:site\" content=\"" + url + "/video/" + hp + ".html\"> ");
                    str.Append(" <meta name=\"twitter:title\" content=\"" + dt.Title + "\">");
                    str.Append(" <meta name=\"twitter:description\" content=\"" + Brief + "\">");
                    str.Append("<meta name=\"twitter:image:src\" content=\"" + url + Images + "\">");

                }
                return str.ToString();
            }
            else if (hp.Contains("/album/"))
            {
                hp = Removelink.RemoveUrl(hp);
                LAlbum dt = db.LAlbums.SingleOrDefault(p => p.TangName == hp);
                StringBuilder str = new StringBuilder();
                if (dt != null)
                {
                    string Images = "";
                    string Brief = "";
                    if (dt.Images.Length > 0)
                    {
                        Images = dt.Images;
                    }
                    if (dt.Keyword.Length > 0) { Brief = MoreAll.MoreAll.RemoveHTMLTags(MoreAll.MoreAll.Substring(dt.Keyword, 250)); } else { if (dt.Brief.Length > 0) { Brief = MoreAll.MoreAll.RemoveHTMLTags(MoreAll.MoreAll.Substring(dt.Brief, 250)); } }
                    str.Append("<meta property=\"fb:app_id\" content=\"" + Commond.Setting("txtfbapp_id") + "\" />");
                    str.Append("<meta property=\"og:site_name\" content=\"" + url.Replace("http://", "").Replace("https://", "") + "\" />");
                    str.Append("<meta property=\"og:rich_attachment\" content=\"true\" />");
                    //str.Append( "<meta property=\"article:publisher\" content=\"" + Other.Giatri("txtfacebook") + "\" />");
                    str.Append("<meta property=\"og:type\" content=\"article\" />");
                    str.Append("<meta property=\"og:url\" content=\"" + url + "/album/" + hp + ".html\" />");
                    str.Append("<meta property=\"og:title\" content=\"" + dt.Title + "\" />");
                    str.Append("<meta property=\"og:description\" content=\"" + Brief + "\" />");
                    str.Append("<meta property=\"og:image\" content=\"" + url + Images + "\" />");
                    str.Append("<meta property=\"og:image:width\" content=\"720\" />");
                    str.Append("<meta property=\"og:image:height\" content=\"480\" />");
                    str.Append("<meta property=\"article:published_time\" content=\"" + MoreAll.MoreAll.FormatDate(dt.Create_Date) + "\" />");
                    str.Append("<meta property=\"article:modified_time\" content=\"" + MoreAll.MoreAll.FormatDate(dt.Modified_Date) + "\" />");
                    // str.Append( " <meta property=\"article:section\" content=\"" + More.DetaiName(dt.Menu_ID) + "\" />");

                    str.Append("<meta name=\"twitter:card\" content=\"summary_large_image\">");
                    str.Append("<meta name=\"twitter:site\" content=\"" + url + "/album/" + hp + ".html\"> ");
                    str.Append(" <meta name=\"twitter:title\" content=\"" + dt.Title + "\">");
                    str.Append(" <meta name=\"twitter:description\" content=\"" + Brief + "\">");
                    str.Append("<meta name=\"twitter:image:src\" content=\"" + url + Images + "\">");
                }
                return str.ToString();
            }
            else if (hp.Contains("/danh-muc-tin/") || hp.Contains("/danh-muc/") || hp.Contains("/danh-muc-video/") || hp.Contains("/danh-muc-anh/"))
            {
                hp = Removelink.RemoveUrl(hp);
                StringBuilder str = new StringBuilder();
                Menu dt = db.Menus.SingleOrDefault(p => p.TangName == hp);
                if (dt != null)
                {
                    string Images = "";
                    string Brief = "";
                    if (dt.Images.Length > 0)
                    {
                        Images = dt.Images;
                    }
                    if (dt.Keyword.Length > 0) { Brief = MoreAll.MoreAll.RemoveHTMLTags(MoreAll.MoreAll.Substring(dt.Keyword, 250)); } else { if (dt.Description.Length > 0) { Brief = MoreAll.MoreAll.RemoveHTMLTags(MoreAll.MoreAll.Substring(dt.Description, 250)); } }
                    str.Append("<meta property=\"fb:app_id\" content=\"" + Commond.Setting("txtfbapp_id") + "\" />");
                    str.Append("<meta property=\"og:site_name\" content=\"" + url.Replace("http://", "").Replace("https://", "") + "\" />");
                    str.Append("<meta property=\"og:rich_attachment\" content=\"true\" />");
                    // str.Append( "<meta property=\"article:publisher\" content=\"" + Other.Giatri("txtfacebook") + "\" />");
                    str.Append("<meta property=\"og:type\" content=\"article\" />");
                    str.Append("<meta property=\"og:url\" content=\"" + System.Web.HttpContext.Current.Request.RawUrl.ToString() + "\" />");
                    str.Append("<meta property=\"og:title\" content=\"" + dt.Name + "\" />");
                    str.Append("<meta property=\"og:description\" content=\"" + Brief + "\" />");
                    str.Append("<meta property=\"og:image\" content=\"" + url + Images + "\" />");
                    str.Append("<meta property=\"og:image:width\" content=\"720\" />");
                    str.Append("<meta property=\"og:image:height\" content=\"480\" />");

                    str.Append("<meta name=\"twitter:card\" content=\"summary_large_image\">");
                    str.Append("<meta name=\"twitter:site\" content=\"" + System.Web.HttpContext.Current.Request.RawUrl.ToString() + "\"> ");
                    str.Append(" <meta name=\"twitter:title\" content=\"" + dt.Name + "\">");
                    str.Append(" <meta name=\"twitter:description\" content=\"" + Brief + "\">");
                    str.Append("<meta name=\"twitter:image:src\" content=\"" + url + Images + "\">");
                }
                return str.ToString();
            }
            //else if (Modul == "11")
            //{
            // hp = Removelink.RemoveUrl(hp);
            //    Gioithieu dt = db.Gioithieus.SingleOrDefault(p => p.TangName == hp);
            //    StringBuilder str = new StringBuilder();
            //    string Images = "";
            //    string Brief = "";
            //    if (dt != null)
            //    {
            //        if (dt.Images.Length > 0)
            //        {
            //            Images = dt.Images;
            //        }
            //        if (dt.Keyword.Length > 0) { Brief = MoreAll.MoreAll.RemoveHTMLTags(MoreAll.MoreAll.Substring(dt.Keyword, 250)); } else { if (dt.Brief.Length > 0) { Brief = MoreAll.MoreAll.RemoveHTMLTags(MoreAll.MoreAll.Substring(dt.Brief, 250)); } }
            //        str.Append( "<meta property=\"fb:app_id\" content=\"" + Commond.Setting("txtfbapp_id") + "\" />");
            //        str.Append( "<meta property=\"og:site_name\" content=\"" + url.Replace("http://", "").Replace("https://", "") + "\" />");
            //        str.Append( "<meta property=\"og:rich_attachment\" content=\"true\" />");
            //        //str.Append( "<meta property=\"article:publisher\" content=\"" + Other.Giatri("txtfacebook") + "\" />");
            //        str.Append( "<meta property=\"og:type\" content=\"article\" />");
            //        str.Append( "<meta property=\"og:url\" content=\"" + url + "/" + hp + ".html\" />");
            //        str.Append( "<meta property=\"og:title\" content=\"" + dt.Title + "\" />");
            //        str.Append( "<meta property=\"og:description\" content=\"" + Brief + "\" />");
            //        str.Append( "<meta property=\"og:image\" content=\"" + url + Images + "\" />");
            //        str.Append( "<meta property=\"og:image:width\" content=\"720\" />");
            //        str.Append( "<meta property=\"og:image:height\" content=\"480\" />");
            //        str.Append( "<meta property=\"article:published_time\" content=\"" + MoreAll.MoreAll.FormatDate(dt.Create_Date) + "\" />");
            //        str.Append( "<meta property=\"article:modified_time\" content=\"" + MoreAll.MoreAll.FormatDate(dt.Modified_Date) + "\" />");

            //        str.Append( "<meta name=\"twitter:card\" content=\"summary_large_image\>");
            //        str.Append( "<meta name=\"twitter:site\" content=\"" + url + "/" + hp + ".html\"> ");
            //        str.Append( " <meta name=\"twitter:title\" content=\"" + dt.Title + "\>");
            //        str.Append( " <meta name=\"twitter:description\" content=\"" + Brief + "\>");
            //        str.Append( "<meta name=\"twitter:image:src\" content=\"" + url + Images + "\>");

            //    }
            //    return str.ToString();
            //}
            else if (hp.Contains("/page/"))
            {
                hp = Removelink.RemoveUrl(hp);
                Menu dt = db.Menus.SingleOrDefault(p => p.TangName == hp);
                StringBuilder str = new StringBuilder();
                string Images = "";
                string Brief = "";
                string str3 = Commond.Setting("bannerpath");
                if (dt != null)
                {
                    if (dt.Images.Length > 0)
                    {
                        Images = dt.Images;
                    }
                    else
                    {
                        if (str3.Length > 4)
                        {
                            string str4 = str3.Substring(str3.IndexOf(".")).ToLower();
                            if ((str4.Equals(".jpg") || str4.Equals(".gif")) || str4.Equals(".png"))
                            {
                                Images = str3;
                            }
                        }
                    }
                    if (dt.Description.Length > 0) { Brief = MoreAll.MoreAll.RemoveHTMLTags(MoreAll.MoreAll.Substring(dt.Description, 250)); } else { if (dt.Name.Length > 0) { Brief = MoreAll.MoreAll.RemoveHTMLTags(MoreAll.MoreAll.Substring(dt.Name, 250)); } }
                    str.Append("<meta property=\"fb:app_id\" content=\"" + Commond.Setting("txtfbapp_id") + "\" />");
                    str.Append("<meta property=\"og:site_name\" content=\"" + url.Replace("http://", "").Replace("https://", "") + "\" />");
                    str.Append("<meta property=\"og:rich_attachment\" content=\"true\" />");
                    str.Append("<meta property=\"og:type\" content=\"article\" />");
                    str.Append("<meta property=\"og:url\" content=\"" + url + "/page/" + hp + ".html\" />");
                    str.Append("<meta property=\"og:title\" content=\"" + dt.Name + "\" />");
                    str.Append("<meta property=\"og:description\" content=\"" + Brief + "\" />");
                    str.Append("<meta property=\"og:image\" content=\"" + url + Images + "\" />");
                    str.Append("<meta property=\"og:image:height\" content=\"480\" />");

                    str.Append("<meta name=\"twitter:card\" content=\"summary_large_image\">");
                    str.Append("<meta name=\"twitter:site\" content=\"" + url + "/page/" + hp + ".html\"> ");
                    str.Append(" <meta name=\"twitter:title\" content=\"" + dt.Name + "\">");
                    str.Append(" <meta name=\"twitter:description\" content=\"" + Brief + "\">");
                    str.Append("<meta name=\"twitter:image:src\" content=\"" + url + Images + "\">");
                }
                return str.ToString();
            }
            else
            {
                StringBuilder str = new StringBuilder();
                string item = Commond.Setting("ImagesFacebook");

                str.Append("<meta name=\"twitter:card\" content=\"summary_large_image\">");
                str.Append("<meta name=\"twitter:site\" content=\"" + url.Replace("http://", "").Replace("https://", "") + "\"> ");
                str.Append(" <meta name=\"twitter:title\" content=\"" + Commond.Setting("webname") + "\">");
                str.Append(" <meta name=\"twitter:description\" content=\"" + MoreAll.MoreAll.RemoveHTMLTags(Commond.Setting("keyworddescription")) + "\">");
                str.Append("<meta name=\"twitter:image:src\" content=\"" + url + item + "\">");

                str.Append("<meta property=\"fb:app_id\" content=\"" + Commond.Setting("txtfbapp_id") + "\" />");
                str.Append("<meta property=\"og:site_name\" content=\"" + url.Replace("http://", "").Replace("https://", "") + "\" />");
                str.Append("<meta property=\"og:rich_attachment\" content=\"true\" />");
                //str.Append( "<meta property=\"article:publisher\" content=\"" + Other.Giatri("txtfacebook") + "\" />");
                str.Append("<meta property=\"og:type\" content=\"article\" />");
                str.Append("<meta property=\"og:url\" content=\"" + url + "\" />");
                str.Append("<meta property=\"og:title\" content=\"" + Commond.Setting("webname") + "\" />");
                str.Append("<meta property=\"og:description\" content=\"" + MoreAll.MoreAll.RemoveHTMLTags(Commond.Setting("keyworddescription")) + "\" />");
                str.Append("<meta property=\"og:image\" content=\"" + url + item + "\" />");
                str.Append("<meta property=\"og:image:width\" content=\"720\" />");
                str.Append("<meta property=\"og:image:height\" content=\"480\" />");
                return str.ToString();
            }
            return "";
            #endregion
        }
    }
}
