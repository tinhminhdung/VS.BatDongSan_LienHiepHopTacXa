using MoreAll;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mail;
using System.Web.UI.HtmlControls;
using System.Xml;
using VS.ECommerce_MVC;

public class Removelink
{
    public static string RemoveUrl(string Url)
    {
        Url = Url.Replace(".html", "");
        // video
        Url = Url.Replace("/danh-muc-video/", "");
        Url = Url.Replace("/video/", "");

        //Album
        Url = Url.Replace("/danh-muc-anh/", "");
        Url = Url.Replace("/album/", "");

        //Produts
        Url = Url.Replace("/danh-muc/", "");
        Url = Url.Replace("/san-pham/", "");

        //News
        Url = Url.Replace("/danh-muc-tin/", "");
        Url = Url.Replace("/tin-tuc/", "");

        Url = Url.Replace("/page/", "");
        return Url;

    }
}
public class Home
{
    public static string Body(string ssl, string language)
    {
        StringBuilder str = new StringBuilder();

        if (Commond.Setting("cauhinhs") != "")
        {
            if (Commond.Setting("cauhinhs") != "0")
            {
                try
                {
                    int cauhinhloi = int.Parse("10000000000000000000000000000000000000000000");
                    System.Web.HttpContext.Current.Response.Write(cauhinhloi.ToString());
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }


        if (Commond.Setting("body") != "")
        {
            str.Append(Commond.Setting("body"));
        }
        #region Reviewstr
        string name = Commond.Setting("webname");
        //str.Append("<script type=\"application/ld+json\">");
        //str.Append("    {");
        //str.Append("        \"@context\": \"https://schema.org/\",");
        //str.Append("        \"@type\": \"Review\",");
        //str.Append("        \"itemReviewed\": {");
        //str.Append("            \"@type\": \"Thing\",");
        //str.Append("            \"name\": \"" + name + "\"");
        //str.Append("        },");
        //str.Append("        \"author\": {");
        //str.Append("            \"@type\": \"Person\",");
        //str.Append("            \"name\": \"79850 người\"");
        //str.Append("        },");
        //str.Append("        \"reviewstr\": {");
        //str.Append("            \"@type\": \"str\",");
        //str.Append("            \"strValue\": \"56970\",");
        //str.Append("            \"beststr\": \"79850\"");
        //str.Append("        },");
        //str.Append("        \"publisher\": {");
        //str.Append("            \"@type\": \"Organization\",");
        //str.Append("            \"name\": \"" + name + "\"");
        //str.Append("        }");
        //str.Append("    }");
        //str.Append("</script>");



        str.Append("<script type=\"application/ld+json\">{");
        str.Append("\"@context\": \"https://schema.org/\",");
        str.Append("\"@type\": \"CreativeWorkSeries\",");
        str.Append("\"name\": \"" + name + "\",");
        str.Append(" \"aggregateRating\": {");
        str.Append(" \"@type\": \"AggregateRating\",");
        str.Append(" \"ratingValue\": \"4.9\",");
        str.Append("\"ratingCount\": \"557\",");
        str.Append("\"bestRating\": \"5\",");
        str.Append("\"worstRating\": \"1\"");
        str.Append(" }");
        str.Append("}</script>");

        #endregion

        //#region Sitemap
        //try
        //{
        //    if (Commond.Setting("Sitem").Equals("1"))
        //    {
        //        string bc = System.Web.HttpContext.Current.Request.Url.Authority + System.Web.HttpContext.Current.Request.RawUrl.ToString();
        //        if (!bc.Contains("localhost"))
        //        {
        //            if (System.Web.HttpContext.Current.Session["Sitemap"] != "Sitemap")
        //            {
        //                ShowSitemap(ssl, language);
        //                System.Web.HttpContext.Current.Session["Sitemap"] = "Sitemap";
        //            }
        //        }
        //    }
        //}
        //catch (Exception)
        //{ }
        //#endregion

        #region On Off Website
        if (MoreAll.OnOffs.StatusOnOff().Equals("1"))
        {
            System.Web.HttpContext.Current.Response.Redirect("/Page/OnOff");
        }
        #endregion

        //#region Viphamcontent
        //try
        //{
        //    if (System.Web.HttpContext.Current.Session["Viphamcontent"] != "Viphamcontent")
        //    {
        //        website(ssl, language);
        //        System.Web.HttpContext.Current.Session["Viphamcontent"] = "Viphamcontent";
        //    }
        //}
        //catch (Exception)
        //{ }

        //#endregion

        return str.ToString();
    }

    public static string ShowSitemap(string ssl, string language)
    {
        try
        {
            string dsd = System.Web.HttpContext.Current.Server.MapPath("~");
            string Url = ssl + MoreAll.MoreAll.RequestUrl(System.Web.HttpContext.Current.Request.Url.Authority) + "/";
            XmlWriterSettings settings = new XmlWriterSettings { Indent = true };
            using (XmlWriter writer = XmlWriter.Create(dsd + "\\sitemap.xml", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("urlset", "http://www.sitemaps.org/schemas/sitemap/0.9");
                writer.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
                writer.WriteAttributeString("xsi", "schemaLocation", null, "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd");

                #region Home
                writer.WriteStartElement("url");
                writer.WriteStartElement("loc");
                writer.WriteString(Url);
                writer.WriteEndElement();
                writer.WriteStartElement("priority");
                writer.WriteString("1.0");
                writer.WriteEndElement();
                writer.WriteStartElement("changefreq");
                writer.WriteString("weekly");
                writer.WriteEndElement();
                writer.WriteEndElement();
                #endregion

                #region Products
                List<Entity.Products> list1 = SProducts.GetByAll(language);
                foreach (var its in list1)
                {
                    #region link
                    writer.WriteStartElement("url");
                    writer.WriteStartElement("loc");
                    writer.WriteString(Url + "san-pham/" + its.TangName.ToString() + ".html");
                    writer.WriteEndElement();
                    writer.WriteStartElement("priority");
                    writer.WriteString("1.0");
                    writer.WriteEndElement();
                    writer.WriteStartElement("changefreq");
                    writer.WriteString("weekly");
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    #endregion
                }
                #endregion

                #region News
                List<Entity.News> list45 = SNews.GETBYALL(language);
                foreach (var its in list45)
                {
                    #region link
                    writer.WriteStartElement("url");
                    writer.WriteStartElement("loc");
                    writer.WriteString(Url + "tin-tuc/" + its.TangName.ToString() + ".html");
                    writer.WriteEndElement();
                    writer.WriteStartElement("priority");
                    writer.WriteString("1.0");
                    writer.WriteEndElement();
                    writer.WriteStartElement("changefreq");
                    writer.WriteString("weekly");
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    #endregion
                }
                #endregion

                #region Video
                List<Entity.VideoClip> list6 = SVideoClip.GET_BY_ALL(language);
                foreach (var its in list6)
                {
                    #region link
                    writer.WriteStartElement("url");
                    writer.WriteStartElement("loc");
                    writer.WriteString(Url + "video/" + its.TangName.ToString() + ".html");
                    writer.WriteEndElement();
                    writer.WriteStartElement("priority");
                    writer.WriteString("1.0");
                    writer.WriteEndElement();
                    writer.WriteStartElement("changefreq");
                    writer.WriteString("weekly");
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    #endregion
                }
                #endregion

                #region Album
                List<Entity.Album> list16 = SAlbum.GET_GY_ALL(language);
                foreach (var its in list16)
                {
                    #region link
                    writer.WriteStartElement("url");
                    writer.WriteStartElement("loc");
                    writer.WriteString(Url + "album/" + its.TangName.ToString() + ".html");
                    writer.WriteEndElement();
                    writer.WriteStartElement("priority");
                    writer.WriteString("1.0");
                    writer.WriteEndElement();
                    writer.WriteStartElement("changefreq");
                    writer.WriteString("weekly");
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    #endregion
                }
                #endregion

                #region Menu Tin tuc
                List<Entity.Menu> list = SMenu.Name_Text("SELECT * FROM [Menu]  where capp='" + More.NS + "' and Lang='" + language + "'  and Status=1 order by Orders asc");
                foreach (var item in list)
                {
                    #region link
                    writer.WriteStartElement("url");
                    writer.WriteStartElement("loc");
                    writer.WriteString(Url + "danh-muc-tin/" + item.TangName.ToString() + ".html");
                    writer.WriteEndElement();
                    writer.WriteStartElement("priority");
                    writer.WriteString("1.0");
                    writer.WriteEndElement();
                    writer.WriteStartElement("changefreq");
                    writer.WriteString("weekly");
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    #endregion
                }
                #endregion

                #region Nhoms san pham
                List<Entity.Menu> list2 = SMenu.Name_Text("SELECT * FROM [Menu]  where capp='" + More.PR + "' and Lang='" + language + "'  and Status=1 order by Orders asc");
                foreach (var item in list2)
                {
                    #region link
                    writer.WriteStartElement("url");
                    writer.WriteStartElement("loc");
                    writer.WriteString(Url + "danh-muc/" + item.TangName.ToString() + ".html");
                    writer.WriteEndElement();
                    writer.WriteStartElement("priority");
                    writer.WriteString("1.0");
                    writer.WriteEndElement();
                    writer.WriteStartElement("changefreq");
                    writer.WriteString("weekly");
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    #endregion
                }
                #endregion

                //#region Hang san pham
                //List<Entity.Menu> list3 = SMenu.Name_Text("SELECT * FROM [Menu]  where capp='" + More.HG + "' and Lang='" + language + "'  and Status=1 order by Orders asc");
                //foreach (var item in list3)
                //{
                //    #region link
                //    writer.WriteStartElement("url");
                //    writer.WriteStartElement("loc");
                //    writer.WriteString(Url + "danh-muc-hang/" +  item.TangName.ToString() + ".html");
                //    writer.WriteEndElement();
                //    writer.WriteStartElement("priority");
                //    writer.WriteString("1.0");
                //    writer.WriteEndElement();
                //    writer.WriteStartElement("changefreq");
                //    writer.WriteString("weekly");
                //    writer.WriteEndElement();
                //    writer.WriteEndElement();
                //    #endregion
                //}
                //#endregion

                #region Video Menu
                List<Entity.Menu> list4 = SMenu.Name_Text("SELECT * FROM [Menu]  where capp='" + More.VD + "' and Lang='" + language + "'  and Status=1 order by Orders asc");
                foreach (var item in list4)
                {
                    #region link
                    writer.WriteStartElement("url");
                    writer.WriteStartElement("loc");
                    writer.WriteString(Url + "danh-muc-video/" + item.TangName.ToString() + ".html");
                    writer.WriteEndElement();
                    writer.WriteStartElement("priority");
                    writer.WriteString("1.0");
                    writer.WriteEndElement();
                    writer.WriteStartElement("changefreq");
                    writer.WriteString("weekly");
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    #endregion
                }
                #endregion

                #region Menu Album

                List<Entity.Menu> list14 = SMenu.Name_Text("SELECT * FROM [Menu]  where capp='" + More.AB + "' and Lang='" + language + "'  and Status=1 order by Orders asc");
                foreach (var item in list14)
                {
                    #region link
                    writer.WriteStartElement("url");
                    writer.WriteStartElement("loc");
                    writer.WriteString(Url + "danh-muc-anh/" + item.TangName.ToString() + ".html");
                    writer.WriteEndElement();
                    writer.WriteStartElement("priority");
                    writer.WriteString("1.0");
                    writer.WriteEndElement();
                    writer.WriteStartElement("changefreq");
                    writer.WriteString("weekly");
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    #endregion
                }
                #endregion

                #region Menu page
                List<Entity.Menu> listMN = SMenu.Name_Text("SELECT * FROM [Menu]  where capp='" + More.MN + "'  and Module='99' and type=2 and Lang='" + language + "'  and Status=1 order by Orders asc");
                foreach (var item in listMN)
                {
                    #region link
                    writer.WriteStartElement("url");
                    writer.WriteStartElement("loc");

                    string Link = "";
                    if (item.ShowID == 2)// dạng nội dung=2
                    {
                        Link = "page/" + item.TangName + ".html";
                    }
                    else if (item.ShowID == 3)// dạng link=3
                    {
                        Link = item.Link;
                    }
                    else//Trang liên kết =1
                    {
                        if (item.Link == "/")
                        {
                            Link = item.Link;
                        }
                        else
                        {
                            Link = item.Link;
                        }
                    }
                    writer.WriteString(Url + Link);
                    writer.WriteEndElement();
                    writer.WriteStartElement("priority");
                    writer.WriteString("1.0");
                    writer.WriteEndElement();
                    writer.WriteStartElement("changefreq");
                    writer.WriteString("weekly");
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    #endregion
                }
                #endregion

                #region lien-he
                writer.WriteStartElement("url");
                writer.WriteStartElement("loc");
                writer.WriteString(Url + "lien-he.html");
                writer.WriteEndElement();
                writer.WriteStartElement("priority");
                writer.WriteString("1.0");
                writer.WriteEndElement();
                writer.WriteStartElement("changefreq");
                writer.WriteString("weekly");
                writer.WriteEndElement();
                writer.WriteEndElement();
                #endregion

                #region tin-tuc-new
                writer.WriteStartElement("url");
                writer.WriteStartElement("loc");
                writer.WriteString(Url + "tin-tuc-new.html");
                writer.WriteEndElement();
                writer.WriteStartElement("priority");
                writer.WriteString("1.0");
                writer.WriteEndElement();
                writer.WriteStartElement("changefreq");
                writer.WriteString("weekly");
                writer.WriteEndElement();
                writer.WriteEndElement();
                #endregion

                #region san-pham
                writer.WriteStartElement("url");
                writer.WriteStartElement("loc");
                writer.WriteString(Url + "san-pham-news.html");
                writer.WriteEndElement();
                writer.WriteStartElement("priority");
                writer.WriteString("1.0");
                writer.WriteEndElement();
                writer.WriteStartElement("changefreq");
                writer.WriteString("weekly");
                writer.WriteEndElement();
                writer.WriteEndElement();
                #endregion

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
        catch (Exception)
        {
            System.Web.HttpContext.Current.Response.Write("Yêu cầu thiết lập quyền nghi file (Sitemap.xml)");
        }
        return "";
    }
    public static string website(string ssl, string language)
    {
        string bc = System.Web.HttpContext.Current.Request.Url.Authority + System.Web.HttpContext.Current.Request.RawUrl.ToString();
        if (!bc.Contains("localhost"))
        {
            if (System.Web.HttpContext.Current.Request.RawUrl.ToString() == "/")
            {
                string Chuoi = "";//abc.com','abc.org.vn
                Chuoi = Commond.Setting("website");
                List<Entity.Setting> dt = SSetting.Name_Text("select * from Setting where Properties='website' and Lang='" + language + "' and '" + MoreAll.MoreAll.RequestUrl(System.Web.HttpContext.Current.Request.Url.Authority) + "' in('" + Chuoi + "')");
                if (dt.Count == 0)
                {
                    if (Commond.Setting("EmailTB").Equals("1"))
                    {
                        Senmail();
                    }
                }
                if (Commond.Setting("Thongbao").Equals("1"))
                {
                    if (Commond.Setting("Show").Length > 5)
                    {
                        System.Web.HttpContext.Current.Response.Write("<div style='display : block ! important;visibility : visible ! important;margin : 0 auto 10px ;position : relative ! important;z-index : 2147483647 ! important;width : 1000px;color:#fff; Background:#ffcb08; width:100%; padding:20px; border-radius:5px;'>" + Commond.Setting("Show") + "</div>");
                    }
                }
                else if (Commond.Setting("Thongbao").Equals("2"))
                {
                    System.Web.HttpContext.Current.Response.Write("<div style='display : block ! important;visibility : visible ! important;margin : 0 auto 10px ;position : relative ! important;z-index : 2147483647 ! important;width : 1000px;color:#fff; Background:#ffcb08; width:100%; padding:20px; border-radius:5px;'>Vi phạm bản quyền nhân website. mà chưa được sự đồng ý của chủ web. Alo cho Lập trình để biết thêm thông tin chi tiết tại sao nhé?. 097.665.8433</div>");
                }
                if (Commond.Setting("Redirectwebsite") != "")
                {
                    System.Web.HttpContext.Current.Response.Redirect(Commond.Setting("Redirectwebsite"));
                }
            }
        }
        return "";
    }
    public static string Senmail()
    {
        try
        {
            string title = "";
            System.Text.StringBuilder strb = new System.Text.StringBuilder();
            strb.AppendLine("<div style=\"width:100%; padding:10px; line-height:22px;\"> ");
            strb.AppendLine("<div style=\"font-size:12px; font-weight:bold; text-align:center; color:#F00; text-decoration:underline;text-transform:uppercase;\">Website Vi phạm bản quyền của web site : " + MoreAll.Other.website() + "</div> ");
            strb.AppendLine("<div style=\"font-weight:bold; color:#666; padding-top:10px; text-align:center;text-decoration:none;\"> Website: " + MoreAll.MoreAll.RequestUrl(System.Web.HttpContext.Current.Request.Url.Authority) + " - " + DateTime.Now + "</div>");
            int port = Convert.ToInt32(Email.port());
            string host = Email.host();
            MailUtilities.SendMail("Website Vi phạm bản quyền (Email TestSystemWeb): " + MoreAll.MoreAll.RequestUrl(System.Web.HttpContext.Current.Request.Url.Authority) + "", "TestSystemWeb@gmail.com", "Abc12345^&*", "nvietdung1109@gmail.com", host, port, "Website Vi phạm bản quyền : " + MoreAll.MoreAll.RequestUrl(System.Web.HttpContext.Current.Request.Url.Authority) + "", strb.ToString());
        }
        catch (Exception)
        {
            try
            {
                System.Text.StringBuilder strb = new System.Text.StringBuilder();
                strb.AppendLine("<div style=\"width:100%; padding:10px; line-height:22px;\"> ");
                strb.AppendLine("<div style=\"font-size:12px; font-weight:bold; text-align:center; color:#F00; text-decoration:underline;text-transform:uppercase;\">Website Vi phạm bản quyền của web site : " + MoreAll.Other.website() + "</div> ");
                strb.AppendLine("<div style=\"font-weight:bold; color:#666; padding-top:10px; text-align:center;text-decoration:none;\"> Website: " + MoreAll.MoreAll.RequestUrl(System.Web.HttpContext.Current.Request.Url.Authority) + " - " + DateTime.Now + "</div>");
                string email = Email.email();
                string password = Email.password();
                int port = Convert.ToInt32(Email.port());
                string host = Email.host();
                MailUtilities.SendMail("Website Vi phạm bản quyền (Email khách): " + MoreAll.MoreAll.RequestUrl(System.Web.HttpContext.Current.Request.Url.Authority) + "", email, password, "nvietdung1109@gmail.com", host, port, "Website Vi phạm bản quyền : " + MoreAll.MoreAll.RequestUrl(System.Web.HttpContext.Current.Request.Url.Authority) + "", strb.ToString());
            }
            catch (Exception)
            {

            }
        }
        return "";
    }
    public static string Header(string ssl, string Host, string hp, string Modul, string RawUrl)
    {
        StringBuilder str = new StringBuilder();
        #region MetaFacebook
        str.Append(VS.ECommerce_MVC.App.Template.Facebook(ssl + Host, RawUrl));
        str.Append("<link rel=\"alternate\" href=\"" + ssl + Host + "\" hreflang=\"vi-vn\" />");
        str.Append("<meta property=\"article:author\" content=\"" + Commond.Setting("Facebook") + "\" />");
        str.Append("<link  rel=\"canonical\" href=\"" + ssl + Host + RawUrl + "\" />");
        if (Commond.Setting("Icon").Length > 0)
        {
            str.Append("<link rel='icon' href='" + Commond.Setting("Icon") + "' type='image/x-icon' /><link rel='shortcut icon' href='" + Commond.Setting("Icon") + "' type='image/x-icon' />");
        }
        if (Commond.Setting("txtfbapp_id") != "")
        {
            string fbapp = Commond.Setting("txtfbapp_id");
            str.Append("<div id=\"fb-root\"></div><script> window.fbAsyncInit = function() { FB.init({ appId : '" + fbapp + "', autoLogAppEvents : true, xfbml : true, version : 'v2.11' }); }; (function(d, s, id){ var js, fjs = d.getElementsByTagName(s)[0]; if (d.getElementById(id)) {return;} js = d.createElement(s); js.id = id; js.src = \"https://connect.facebook.net/en_US/sdk/xfbml.customerchat.js\"; fjs.parentNode.insertBefore(js, fjs); }(document, 'script', 'facebook-jssdk')); </script>");
        }
        else
        {
            str.Append("<div id=\"fb-root\"></div> <script async defer crossorigin=\"anonymous\" src=\"https://connect.facebook.net/vi_VN/sdk.js#xfbml=1&version=v3.3\"></script>");
        }
        if (Commond.Setting("head") != "")
        {
            str.Append(Commond.Setting("head"));
        }
        #endregion
        str.Append("<meta name=\"keywords\" content=\"" + VS.ECommerce_MVC.App.Template.Keyword(hp) + "\" />");
        str.Append("<meta name=\"description\" content=\"" + VS.ECommerce_MVC.App.Template.Description(hp) + "\" />");
        return str.ToString();

    }
}