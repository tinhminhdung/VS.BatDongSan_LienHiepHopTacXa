using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Services;
using Entity;
using Framework;
using System.Xml;
using System.IO;

namespace VS.ECommerce_MVC.cms.Admin.settings
{
    public partial class u_adm_systemsetting : System.Web.UI.UserControl
    {
        private string lang = Captionlanguage.Language;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["lang"] != null)
            {
                this.lang = System.Web.HttpContext.Current.Session["lang"].ToString();
            }
            else
            {
                System.Web.HttpContext.Current.Session["lang"] = this.lang;
                this.lang = System.Web.HttpContext.Current.Session["lang"].ToString();
            }
            this.Page.Form.DefaultButton = btnsetup.UniqueID;
            if (!base.IsPostBack)
            {
                try
                {
                    if (MoreAll.MoreAll.RequestUrl(Request.Url.Authority).Substring(0, 9) != "localhost")
                    {
                        ShowSitemap();
                    }
                }
                catch (Exception)
                { }
                this.binddata();

            }
        }

        public void binddata()
        {
            RemoveCache.Home();

            string Sitemap = "";
            string SSL = "";
            string Width = "";
            string Height = "";
            string str5 = "";
            FSetting DB = new FSetting();
            List<Entity.Setting> str = DB.GETBYALL(lang);
            ltmsg.Text = string.Empty;
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "smtpport")
                    {
                        this.txtsmtpport.Text = its.Value;
                    }
                    else if (its.Properties == "smtp")
                    {
                        this.txtsmtp.Text = its.Value;
                    }
                    else if (its.Properties == "sysemail")
                    {
                        this.txtsysemail.Text = its.Value;
                    }
                    else if (its.Properties == "sysemailpass")
                    {
                        this.txtsysemailpass.Text = its.Value;
                    }
                    else if (its.Properties == "searchkeyword")
                    {
                        this.txtsearchkeyword.Text = its.Value;
                    }
                    else if (its.Properties == "keyworddescription")
                    {
                        this.txtsitekeyworddescription.Text = its.Value;
                    }
                    else if (its.Properties == "webname")
                    {
                        this.txtwebname.Text = its.Value;
                    }
                    else if (its.Properties == "Facebook")
                    {
                        this.txtfacebook.Text = its.Value;
                    }
                    else if (its.Properties == "Hotline")
                    {
                        this.txthostline.Text = its.Value;
                    }
                    else if (its.Properties == "Livechat")
                    {
                        this.txtLivechat.Text = its.Value;
                    }
                    else if (its.Properties == "Sitem")
                    {
                        Sitemap = its.Value;
                    }
                    else if (its.Properties == "SSL")
                    {
                        SSL = its.Value;
                    }
                    else if (its.Properties == "txtfbapp_id")
                    {
                        this.txtfbapp_id.Text = its.Value;
                        if (txtfbapp_id.Text.Length > 5)
                        {
                            ltshowfacebook.Text = "<div style=\"height: 42px;color:#0b98ea;padding-top: 10px;font-size: 15px;\">Kích vào đây để vào quản trị Comments facebook <a style='color:#ed1c24' href=\"https://developers.facebook.com/tools/comments/" + txtfbapp_id.Text + "\" target=\"_blank\">Click vào đây</a></div>";
                        }
                    }
                    else if (its.Properties == "txtfbwidth")
                    {
                        this.txtfbwidth.Text = its.Value;
                    }
                    else if (its.Properties == "txtfbheight")
                    {
                        this.txtfbheight.Text = its.Value;
                    }
                    else if (its.Properties == "Emailden")
                    {
                        this.txtEmailden.Text = its.Value;
                    }
                    else if (its.Properties == "ImagesFacebook")
                    {
                        this.txtImage.Text = its.Value;
                        this.ltimgs.Text = "<img src='" + its.Value + "' border=0 style='height: 100px;'/><br>";
                    }
                    else if (its.Properties == "bannerwidth")
                    {
                        Width = its.Value;
                        this.txtbannerwidth.Text = its.Value;
                    }
                    else if (its.Properties == "Icon")
                    {
                        this.txticon.Text = its.Value;
                        this.lticon.Text = "<img src='" + its.Value + "' border=0 style='border:1px solid #9EC3CB;width: 50px;'/><br>";
                    }
                    else if (its.Properties == "bannerpath")
                    {
                        try
                        {
                            this.txtlogo.Text = its.Value;
                            string str6 = its.Value.Substring(its.Value.IndexOf(".")).ToLower();
                            if ((str6.Equals(".jpg") || str6.Equals(".gif")) || str6.Equals(".png"))
                            {
                                this.ltcurrentpic.Text = "<img src='" + its.Value + "' border=0 style='border:1px solid #9EC3CB;width: 100px;' /><br>";
                            }
                            else if (str6.Equals(".swf"))
                            {
                                this.ltcurrentpic.Text = "<embed style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "' align='middle'  quality='high' wmode='transparent' allowscriptaccess='always'  type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer'  src='" + its.Value + "'>";
                            }
                        }
                        catch (Exception)
                        { }
                    }
                    else if (its.Properties == "NoImages")
                    {
                        this.txtnoimgaes.Text = its.Value;
                        this.ltnoimgaes.Text = "<img src='" + its.Value + "' border=0 style='border:1px solid #9EC3CB;width: 100px;' /><br>";
                    }
                    else if (its.Properties == "bannerheight")
                    {
                        Height = its.Value;
                        this.txtbannerheight.Text = its.Value;
                    }

                    else if (its.Properties == "txtGooglePlus")
                    {
                        this.txtGooglePlus.Text = its.Value;
                    }
                    else if (its.Properties == "txtTwitter")
                    {
                        this.txtTwitter.Text = its.Value;
                    }
                    else if (its.Properties == "txtFacebookpage")
                    {
                        this.txtFacebookpage.Text = its.Value;
                    }
                    else if (its.Properties == "txtLinkedin")
                    {
                        this.txtLinkedin.Text = its.Value;
                    }


                    #region MyRegion
                    if (Sitemap.Equals("0"))
                    {
                        this.Radio_Bat.Checked = false;
                        this.Radio_Tat.Checked = true;
                    }
                    else if (Sitemap.Equals("1"))
                    {
                        this.Radio_Bat.Checked = true;
                        this.Radio_Tat.Checked = false;
                    }
                    #endregion

                    #region MyRegion
                    if (SSL.Equals("0"))
                    {
                        this.Radio_Batssl.Checked = false;
                        this.Radio_Tatssl.Checked = true;
                    }
                    else if (SSL.Equals("1"))
                    {
                        this.Radio_Batssl.Checked = true;
                        this.Radio_Tatssl.Checked = false;
                    }
                    #endregion
                }
            }
            this.btnsetup.Text = "Cập nhật";
        }
        protected void btnsetup_Click(object sender, EventArgs e)
        {
            int SSL = 0;
            if (this.Radio_Batssl.Checked)
            {
                SSL = 1;
            }


            int Sitem = 0;
            if (this.Radio_Bat.Checked)
            {
                Sitem = 1;
            }

            if (Page.IsValid)
            {
                Entity.Setting obj = new Entity.Setting();
                obj.Lang = lang;
                obj.Properties = "sysemailpass";
                obj.Value = txtsysemailpass.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "Icon";
                obj.Value = txticon.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "bannerpath";
                obj.Value = txtlogo.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "NoImages";
                obj.Value = txtnoimgaes.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "bannerwidth";
                obj.Value = txtbannerwidth.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "bannerheight";
                obj.Value = txtbannerheight.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "webname";
                obj.Value = txtwebname.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "searchkeyword";
                obj.Value = txtsearchkeyword.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "keyworddescription";
                obj.Value = txtsitekeyworddescription.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "smtp";
                obj.Value = txtsmtp.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "smtpport";
                obj.Value = txtsmtpport.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "sysemail";
                obj.Value = txtsysemail.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "Hotline";
                obj.Value = txthostline.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "Facebook";
                obj.Value = txtfacebook.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "Livechat";
                obj.Value = txtLivechat.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "txtfbapp_id";
                obj.Value = txtfbapp_id.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "txtfbwidth";
                obj.Value = txtfbwidth.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "txtfbheight";
                obj.Value = txtfbheight.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "Emailden";
                obj.Value = txtEmailden.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "ImagesFacebook";
                obj.Value = txtImage.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "Sitem";
                obj.Value = Sitem.ToString();
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "SSL";
                obj.Value = SSL.ToString();
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "txtGooglePlus";
                obj.Value = txtGooglePlus.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "txtTwitter";
                obj.Value = txtTwitter.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "txtFacebookpage";
                obj.Value = txtFacebookpage.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "txtLinkedin";
                obj.Value = txtLinkedin.Text;
                SSetting.UPDATE(obj);

                this.binddata();
                this.ltmsg.Text = "Thiết lập th\x00e0nh c\x00f4ng!";
            }
        }

        protected void btsitemap_Click(object sender, EventArgs e)
        {
            ShowSitemap();
            this.ltmsg.Text = "Bạn đã cập nhật sitemap thành công!";
        }

        void ShowSitemap()
        {
            try
            {
                string ssl = "http://";
                if (Commond.Setting("SSL").Equals("1"))
                {
                    ssl = "https://";
                }
                string dsd = Server.MapPath("~");
                string Url = ssl + MoreAll.MoreAll.RequestUrl(Request.Url.Authority) + "/";
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
                    List<Entity.Products> list1 = SProducts.GetByAll(lang);
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
                    List<Entity.News> list45 = SNews.GETBYALL(lang);
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
                    List<Entity.VideoClip> list6 = SVideoClip.GET_BY_ALL(lang);
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
                    List<Entity.Album> list16 = SAlbum.GET_GY_ALL(lang);
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
                    List<Entity.Menu> list = SMenu.Name_Text("SELECT * FROM [Menu]  where capp='" + More.NS + "' and Lang='" + lang + "'  and Status=1 order by Orders asc");
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
                    List<Entity.Menu> list2 = SMenu.Name_Text("SELECT * FROM [Menu]  where capp='" + More.PR + "' and Lang='" + lang + "'  and Status=1 order by Orders asc");
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
                    //   writer.WriteString(Url + "danh-muc-hang/" +  item.TangName.ToString() + ".html");
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
                    List<Entity.Menu> list4 = SMenu.Name_Text("SELECT * FROM [Menu]  where capp='" + More.VD + "' and Lang='" + lang + "'  and Status=1 order by Orders asc");
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

                    List<Entity.Menu> list14 = SMenu.Name_Text("SELECT * FROM [Menu]  where capp='" + More.AB + "' and Lang='" + lang + "'  and Status=1 order by Orders asc");
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
                    List<Entity.Menu> listMN = SMenu.Name_Text("SELECT * FROM [Menu]  where capp='" + More.MN + "'  and Module='99' and type=2 and Lang='" + lang + "'  and Status=1 order by Orders asc");
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
                this.ltmsg.Text = " Yêu cầu thiết lập quyền nghi file (Sitemap.xml)";
            }
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }
    }
}