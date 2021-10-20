using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Services;
using System.IO;
using Entity;
using Framework;
using System.Drawing.Imaging;
using Framwork;

namespace VS.ECommerce_MVC.cms.Admin.M_News
{
    public partial class MNews : System.Web.UI.UserControl
    {
        DatalinqDataContext db = new DatalinqDataContext();
        private string status = "";
        private string lang = Captionlanguage.Language;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region MyRegion
            if (System.Web.HttpContext.Current.Session["lang"] != null)
            {
                this.lang = System.Web.HttpContext.Current.Session["lang"].ToString();
            }
            else
            {
                System.Web.HttpContext.Current.Session["lang"] = this.lang;
                this.lang = System.Web.HttpContext.Current.Session["lang"].ToString();
            }
            if (Request["us"] != null && !Request["us"].Equals(""))
            {
                ddlorderby.SelectedValue = Request["us"];
            }
            if (Request["ds"] != null && !Request["ds"].Equals(""))
            {
                ddlordertype.SelectedValue = Request["ds"];
            }
            if (Request["kw"] != null && !Request["kw"].Equals(""))
            {
                txtkeyword.Text = Request["kw"];
            }
            #endregion
            this.Page.Form.DefaultButton = lnksearch.UniqueID;
            if (!IsPostBack)
            {
                #region UpdatePanel
                this.Page.Form.Enctype = "multipart/form-data";
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnsave);
                #endregion
                #region #
                try
                {
                    if (Request["st"] != null && !Request["st"].Equals(""))
                    {
                        ddlstatus.SelectedValue = Request["st"];
                        WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlstatus, this.status);
                    }
                    LoadCategories();
                    LoadItems();
                }
                catch (Exception) { }
                #endregion
            }
        }

        #region Menu
        protected void LoadCategories()
        {
            try
            {
                if (Request["id"] != null && !Request["id"].Equals(""))
                {
                    ddlcategories.SelectedValue = Request["id"];
                }
                int str = 0;
                List<Entity.Menu> dt = SMenu.LOAD_CATESPARENT_ID(More.NS, this.lang, "-1", "1");
                for (int i = 0; i < dt.Count; i++)
                {
                    if (dt[i].Parent_ID.ToString() == "-1")
                    {
                        ddlcategories.Items.Insert(str, new ListItem(dt[i].Name.ToString(), dt[i].ID.ToString()));
                        ddlcategoriesdetail.Items.Insert(str, new ListItem(dt[i].Name.ToString(), dt[i].ID.ToString()));
                        str = str + 1;
                        str = Categories(dt[i].ID.ToString(), str, "===");
                    }
                }
                this.ddlcategories.Items.Insert(0, new ListItem("Tất cả các mục", "-1"));
                this.ddlcategories.DataBind();
                this.ddlcategoriesdetail.DataBind();
            }
            catch (Exception) { }
        }
        protected int Categories(string id, int str, string j)
        {
            List<Entity.Menu> dt = SMenu.LOAD_CATESPARENT_ID(More.NS, this.lang, id, "1");
            for (int i = 0; i < dt.Count; i++)
            {
                if (dt[i].Parent_ID.ToString() == id)
                {
                    ddlcategories.Items.Insert(str, new ListItem(j + dt[i].Name.ToString(), dt[i].ID.ToString()));
                    ddlcategoriesdetail.Items.Insert(str, new ListItem(j + dt[i].Name.ToString(), dt[i].ID.ToString()));
                    str = str + 1;
                    str = Categories(dt[i].ID.ToString(), str, j + j);
                }
            }
            return str;
        }
        #endregion

        //void LoadItems()
        //{
        //    try
        //    {
        //        FNews DB = new FNews();
        //        string[] searchfields = new string[] { "Title", "Brief", "Contents", "search" };
        //        string orderby = this.ddlorderby.SelectedValue + " " + this.ddlordertype.SelectedValue;
        //        List<News> dt = DB.CATEGORYADMIN(orderby, this.txtkeyword.Text.Trim().Replace("&nbsp;", ""), searchfields, More.Sub_Menu(More.NS, ddlcategories.SelectedValue), lang, ddlstatus.SelectedValue);
        //        CollectionPager1.DataSource = dt;
        //        CollectionPager1.BindToControl = rpitems;
        //        CollectionPager1.MaxPages = 10000;
        //        CollectionPager1.PageSize = 10;
        //        rpitems.DataSource = CollectionPager1.DataSourcePaged;
        //        rpitems.DataBind();
        //        RemoveCache.News();
        //    }
        //    catch (Exception) { }
        //}

        public void LoadItems()
        {
            RemoveCache.News();
            string sapxep = "";
            string orderby = this.ddlorderby.SelectedValue + " " + this.ddlordertype.SelectedValue;
            string Vitri = "";
            if (txtkeyword.Text.Trim().Length > 0)
            {
                Vitri += " and (search LIKE N'" + Fproducts.SearchApproximate.Exec(Fproducts.ConvertVN.Convert(txtkeyword.Text.Trim())) + "' OR Brief LIKE N'" + FNews.SearchApproximate.Exec(txtkeyword.Text.Trim()) + "' OR search LIKE N'" + FNews.SearchApproximate.Exec(txtkeyword.Text.Trim()) + "')";
            }
            if (orderby.Length < 1)
            {
                sapxep = "order by Create_Date desc";
            }
            else
            {
                sapxep = "order by " + orderby;
            }
            if (ddlstatus.SelectedValue != "-1")
            {
                Vitri += " and Status =" + ddlstatus.SelectedValue + "";
            }
            int Tongsobanghi = 0;
            Int16 pages = 1;
            int Tongsotrang = int.Parse("20");
            if ((Request.QueryString["page"] != null) && (Request.QueryString["page"] != ""))
            {
                pages = Convert.ToInt16(Request.QueryString["page"].Trim());
            }
            List<Entity.News> iitem = SNews.CATEGORY_PHANTRANG_ADMIN1(Commond.SubMenu(More.NS, ddlcategories.SelectedValue), Vitri, lang);
            if (iitem.Count() > 0)
            {
                Tongsobanghi = iitem.Count();
            }
            List<Entity.News> dt = SNews.CATEGORY_PHANTRANG_ADMIN2(Commond.SubMenu(More.NS, ddlcategories.SelectedValue), Vitri, lang, sapxep, (pages - 1), Tongsotrang);
           // if (dt.Count >= 1)
            {
                rpitems.DataSource = dt;
                rpitems.DataBind();
            }
            //else
            //{
            //    lterr.Text = "<div class='Checkdata' style='text-align: center; padding: 50px;'>Dữ liệu trống</div>";
            //}
            if (Tongsobanghi % Tongsotrang > 0)
            {
                Tongsobanghi = (Tongsobanghi / Tongsotrang) + 1;
            }
            else
            {
                Tongsobanghi = Tongsobanghi / Tongsotrang;
            }
            ltpage.Text = Commond.PhantrangAdmin("/admin.aspx?u=news&su=Tintuc&id=" + ddlcategories.SelectedValue + "&st=" + ddlstatus.SelectedValue + "&us=" + ddlorderby.SelectedValue + "&ds=" + ddlordertype.SelectedValue + "&kw=" + txtkeyword.Text + "", Tongsobanghi, pages);
        }

        protected void lnkcreatenew_Click(object sender, EventArgs e)
        {
            hdinsertupdate.Value = "insert";
            MultiView1.ActiveViewIndex = 1;
            DeleteFormValue();
            this.txtfromday.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlcategoriesdetail, this.ddlcategories.SelectedValue);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            DeleteFormValue();
            base.Response.Redirect(base.Request.Url.ToString().Trim());
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //  try
            {
                WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlcategories, this.ddlcategoriesdetail.SelectedValue);
                if (this.txtname.Text.Trim().Length < 1)
                {
                    this.lbl_msg.Text = "Xin vui lòng kiểm tra dữ liệu đầu vào của bạn";
                }
                else
                {
                    #region date
                    string Chek = "0";
                    string cdate = DateTime.Now.ToString();
                    string edate = DateTime.Now.AddYears(10).ToString();
                    DateTime dcreatedate = Convert.ToDateTime(cdate.ToString());
                    DateTime denddate = Convert.ToDateTime(edate.ToString());
                    if (this.chkdaytype.Checked)
                    {
                        Chek = "1";
                        dcreatedate = Convert.ToDateTime(this.txtfromday.Text);
                        denddate = dcreatedate.AddDays((double)Convert.ToInt32(this.txtindays.Text));
                    }
                    #endregion
                    News obj = new News();
                    if (hdinsertupdate.Value.Equals("insert"))
                    {
                        #region RewriteUrl
                        int cong = 0;
                        string TangName = "";
                        if (txtRewriteUrl.Text.Length > 0)
                        {
                            #region InsertMenu
                            List<Entity.News> curItem = SNews.Name_Text("SELECT top 1 * FROM News order by inid desc");
                             if (curItem.Count > 0) { int tong = int.Parse(curItem[0].inid.ToString()); cong = tong + 1; } var hasTagName = db.News.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)).FirstOrDefault(); TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtRewriteUrl.Text) + "-" + cong : MoreAll.AddURL.SeoURL(txtRewriteUrl.Text);

                            #endregion
                        }
                        else
                        {
                            #region InsertMenu
                            List<Entity.News> curItem = SNews.Name_Text("SELECT top 1 * FROM News order by inid desc");
                            if (curItem.Count > 0) { int tong = int.Parse(curItem[0].inid.ToString()); cong = tong + 1; } var hasTagName = db.News.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtname.Text)).FirstOrDefault(); TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtname.Text) + "-" + cong : MoreAll.AddURL.SeoURL(txtname.Text);
                            #endregion
                        }
                        #endregion

                        #region MyRegion
                        obj.icid = int.Parse(this.ddlcategoriesdetail.SelectedValue);
                        obj.Title = this.txtname.Text;
                        obj.Brief = this.txtdesc.Text;
                        obj.Contents = this.txtcontent.Text;
                        obj.Keywords = this.txtauthor.Text;
                        obj.search = RewriteURLNew.NameSearch(txtname.Text);
                        //obj.Images = vimg;
                        //obj.ImagesSmall = small;

                        obj.Images = txtImage.Text;
                        obj.ImagesSmall = txtImage.Text.Replace("uploads", "uploads/_thumbs");

                        obj.Equals = 0;
                        obj.Chekdata = int.Parse(Chek);
                        obj.Create_Date = dcreatedate;
                        obj.Modified_Date = denddate;
                        obj.Views = 0;
                        obj.Tags = this.txttags.Text;
                        obj.lang = this.lang;
                        obj.New = int.Parse(this.chknews.Checked ? "1" : "0");
                        obj.CheckBox1 = int.Parse(this.CheckBox1.Checked ? "1" : "0");
                        obj.CheckBox2 = int.Parse(this.CheckBox2.Checked ? "1" : "0");
                        obj.CheckBox3 = int.Parse(this.CheckBox3.Checked ? "1" : "0");
                        obj.CheckBox4 = int.Parse(this.CheckBox4.Checked ? "1" : "0");
                        obj.CheckBox5 = int.Parse(this.CheckBox5.Checked ? "1" : "0");
                        obj.CheckBox6 = int.Parse(this.CheckBox6.Checked ? "1" : "0");
                        obj.Status = int.Parse(this.chkstatus.Checked ? "1" : "0");
                        obj.Titleseo = this.txttitleseo.Text;
                        obj.Meta = this.txtmeta.Text;
                        obj.Keyword = this.txtKeywordS.Text;
                        obj.TangName = TangName;
                        obj.Alt = this.txAlt.Text;
                        SNews.News_INSERT(obj);
                        #endregion

                    }
                    else
                    {
                        #region RewriteUrl
                        string TagName = "";
                        if (txtRewriteUrl.Text.Length > 0)
                        {
                            #region UpdateMenu
                            List<Entity.News> item = SNews.GETBYID(this.hdid.Value);
                            if (item.Count > 0)
                            {
                                List<New> list = (from p in db.News where p.TangName == item[0].TangName orderby p.inid descending select p).ToList();
                                if (list.Count > 2)
                                {
                                    var hasTagName = db.News.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtRewriteUrl.Text) + "-" + item[0].inid : MoreAll.AddURL.SeoURL(txtRewriteUrl.Text);
                                }
                                else
                                {
                                    if (MoreAll.AddURL.SeoURL(item[0].TangName) != MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)) { var hasTagName = db.News.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtRewriteUrl.Text) + "-" + item[0].inid : MoreAll.AddURL.SeoURL(txtRewriteUrl.Text); } else { TagName = item[0].TangName; }
                                }

                            }
                            #endregion
                        }
                        else
                        {
                            #region UpdateMenu
                            List<News> item = SNews.GETBYID(this.hdid.Value);
                            if (item.Count > 0)
                            {
                                List<New> list = (from p in db.News where p.TangName == item[0].TangName orderby p.inid descending select p).ToList();
                                if (list.Count > 2)
                                {
                                    var hasTagName = db.News.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtname.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtname.Text) + "-" + item[0].inid : MoreAll.AddURL.SeoURL(txtname.Text);
                                }
                                else
                                {
                                    if (MoreAll.AddURL.SeoURL(item[0].TangName) != MoreAll.AddURL.SeoURL(txtname.Text)) { var hasTagName = db.News.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtname.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtname.Text) + "-" + item[0].inid : MoreAll.AddURL.SeoURL(txtname.Text); } else { TagName = item[0].TangName; }
                                }

                            }
                            #endregion
                        }
                        #endregion

                        #region MyRegion
                        obj.inid = int.Parse(this.hdid.Value);
                        obj.icid = int.Parse(this.ddlcategoriesdetail.SelectedValue);
                        obj.Title = this.txtname.Text;
                        obj.Brief = this.txtdesc.Text;
                        obj.Contents = this.txtcontent.Text;
                        obj.Keywords = this.txtauthor.Text;
                        obj.search = RewriteURLNew.NameSearch(txtname.Text);
                        //obj.Images = vimg;
                        //obj.ImagesSmall = small;
                        obj.Images = txtImage.Text;
                        obj.ImagesSmall = txtImage.Text.Replace("uploads", "uploads/_thumbs");
                        obj.Equals = 0;
                        obj.Chekdata = int.Parse(Chek);
                        //obj.Create_Date = dcreatedate;
                        // obj.Modified_Date = denddate;
                        obj.Views = 0;
                        obj.Tags = this.txttags.Text;
                        obj.lang = this.lang;
                        obj.New = int.Parse(this.chknews.Checked ? "1" : "0");
                        obj.CheckBox1 = int.Parse(this.CheckBox1.Checked ? "1" : "0");
                        obj.CheckBox2 = int.Parse(this.CheckBox2.Checked ? "1" : "0");
                        obj.CheckBox3 = int.Parse(this.CheckBox3.Checked ? "1" : "0");
                        obj.CheckBox4 = int.Parse(this.CheckBox4.Checked ? "1" : "0");
                        obj.CheckBox5 = int.Parse(this.CheckBox5.Checked ? "1" : "0");
                        obj.CheckBox6 = int.Parse(this.CheckBox6.Checked ? "1" : "0");
                        obj.Status = int.Parse(this.chkstatus.Checked ? "1" : "0");
                        obj.Titleseo = this.txttitleseo.Text;
                        obj.Meta = this.txtmeta.Text;
                        obj.Keyword = this.txtKeywordS.Text;
                        obj.TangName = TagName;
                        obj.Alt = this.txAlt.Text;
                        #endregion
                        SNews.News_UPDATE(obj);
                    }
                    base.Response.Redirect(base.Request.Url.ToString().Trim());
                    //  LoadItems();
                    MultiView1.ActiveViewIndex = 0;
                    DeleteFormValue();
                }
            }
            //  catch (Exception) { }
        }

        public bool ThumbnailCallback()
        {
            return false;
        }

        void DeleteFormValue()
        {
            this.txtdesc.Text = "";
            this.txtcontent.Text = "";
            this.hdcid.Value = "";
            this.txtname.Text = "";
            this.txtcontent.Text = "";
            this.txtauthor.Text = "";
            this.hdFileName.Value = "";
            this.lbl_msg.Text = "";
            this.hdimgMax.Value = "";
            this.hdimgsmallEdit.Value = "";
            this.hdimgMaxEdit.Value = "";
            this.txttags.Text = "";
            this.txttitleseo.Text = "";
            this.txtmeta.Text = "";
            this.txtKeywordS.Text = "";
            txtImage.Text = "";
            hdimgnews.Value = "";
            txtRewriteUrl.Text = "";
            ltshowurl.Text = "";
            this.txAlt.Text = "";
        }

        protected void Delete_Load(object sender, System.EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Xóa tin được lựa chọn ?.')";
        }

        protected void rpitems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EditDetail":
                    List<News> dtdetail = SNews.GETBYID(e.CommandArgument.ToString());
                    if (dtdetail.Count > 0)
                    {
                        txtname.Text = dtdetail[0].Title;
                        txtdesc.Text = dtdetail[0].Brief;
                        txtcontent.Text = dtdetail[0].Contents;
                        txtauthor.Text = dtdetail[0].Keywords;
                        hdimgMaxEdit.Value = dtdetail[0].Images;
                        txttags.Text = dtdetail[0].Tags;
                        txtRewriteUrl.Text = dtdetail[0].TangName;
                        string ssl = "http://" + Request.Url.Host + "/";
                        if (Commond.Setting("SSL").Equals("1"))
                        {
                            ssl = "https://" + Request.Url.Host + "/";
                        }
                        ltshowurl.Text = ssl + dtdetail[0].TangName + ".html";
                        txAlt.Text = dtdetail[0].Alt;

                        #region Seowwebsite
                        txttitleseo.Text = dtdetail[0].Titleseo;
                        txtmeta.Text = dtdetail[0].Meta;
                        txtKeywordS.Text = dtdetail[0].Keyword;
                        #endregion
                        txtImage.Text = dtdetail[0].Images;
                        ltimgs.Text = MoreImage.Image(dtdetail[0].ImagesSmall);
                        hdimgnews.Value = dtdetail[0].Images;
                        hdimgsmallEdit.Value = dtdetail[0].ImagesSmall;
                        WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlcategoriesdetail, dtdetail[0].icid.ToString());
                        chknews.Checked = (dtdetail[0].New == 1);
                        chkstatus.Checked = (dtdetail[0].Status == 1);
                        CheckBox1.Checked = (dtdetail[0].CheckBox1 == 1);
                        CheckBox2.Checked = (dtdetail[0].CheckBox2 == 1);
                        CheckBox3.Checked = (dtdetail[0].CheckBox3 == 1);
                        CheckBox4.Checked = (dtdetail[0].CheckBox4 == 1);
                        CheckBox5.Checked = (dtdetail[0].CheckBox5 == 1);
                        CheckBox6.Checked = (dtdetail[0].CheckBox6 == 1);
                        #region Update
                        this.txtfromday.Text = Convert.ToDateTime(dtdetail[0].Create_Date).ToString("MM/dd/yyyy HH:mm");
                        this.txtindays.Text = ((Convert.ToDateTime(dtdetail[0].Modified_Date).Ticks - Convert.ToDateTime(dtdetail[0].Create_Date).Ticks) / 0xc92a69c000L).ToString();
                        if (dtdetail[0].Chekdata.ToString().Equals("1"))
                        {
                            this.chkdaytype.Checked = true;
                            this.pnadddate.Visible = true;
                        }
                        else
                        {
                            this.chkdaytype.Checked = false;
                            this.pnadddate.Visible = false;
                        }
                        #endregion

                        MultiView1.ActiveViewIndex = 1;
                        hdinsertupdate.Value = "update";
                        hdid.Value = dtdetail[0].inid.ToString();
                        // giu gia tri cua nhom thông tin cu: su dung khi thay doi nhom thông tin.
                        hdcid.Value = dtdetail[0].icid.ToString();
                        ddlcategoriesdetail.SelectedValue = hdcid.Value;
                    }
                    break;
                case "ChangeStatus":
                    string str = e.CommandName.Trim();
                    string str2 = e.CommandArgument.ToString().Trim();
                    string str4 = str;
                    if (str4 != null)
                    {
                        string str3;
                        str2 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                        if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                        {
                            str3 = "0";
                        }
                        else
                        {
                            str3 = "1";
                        }
                        SNews.UPDATESTATUS(str3, str2);
                        this.LoadItems();
                        base.Response.Redirect(base.Request.Url.ToString().Trim());
                        return;
                    }
                    return;
                case "ChangeNews":
                    string str1 = e.CommandName.Trim();
                    string str21 = e.CommandArgument.ToString().Trim();
                    string str41 = str1;
                    if (str41 != null)
                    {
                        string str3;
                        str21 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                        if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                        {
                            str3 = "0";
                        }
                        else
                        {
                            str3 = "1";
                        }
                        SNews.UPDATE_News(str3, str21);
                        this.LoadItems();
                        base.Response.Redirect(base.Request.Url.ToString().Trim());
                        return;
                    }
                    return;
                case "CheckBox1":
                    string str11 = e.CommandName.Trim();
                    string str211 = e.CommandArgument.ToString().Trim();
                    string str411 = str11;
                    if (str411 != null)
                    {
                        string str3;
                        str211 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                        if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                        {
                            str3 = "0";
                        }
                        else
                        {
                            str3 = "1";
                        }
                        SNews.Name_Text("update News set CheckBox1= " + str3 + " where inid=" + str211 + "");
                        this.LoadItems();
                        base.Response.Redirect(base.Request.Url.ToString().Trim());
                        return;
                    }
                    return;
                case "CheckBox2":
                    string str112 = e.CommandName.Trim();
                    string str2112 = e.CommandArgument.ToString().Trim();
                    string str4112 = str112;
                    if (str4112 != null)
                    {
                        string str3;
                        str2112 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                        if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                        {
                            str3 = "0";
                        }
                        else
                        {
                            str3 = "1";
                        }
                        SNews.Name_Text("update News set CheckBox2= " + str3 + " where inid=" + str2112 + "");
                        this.LoadItems();
                        base.Response.Redirect(base.Request.Url.ToString().Trim());
                        return;
                    }
                    return;
                case "CheckBox3":
                    string str1123 = e.CommandName.Trim();
                    string str21123 = e.CommandArgument.ToString().Trim();
                    string str41123 = str1123;
                    if (str41123 != null)
                    {
                        string str3;
                        str21123 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                        if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                        {
                            str3 = "0";
                        }
                        else
                        {
                            str3 = "1";
                        }
                        SNews.Name_Text("update News set CheckBox3= " + str3 + " where inid=" + str21123 + "");
                        this.LoadItems();
                        base.Response.Redirect(base.Request.Url.ToString().Trim());
                        return;
                    }
                    return;
                case "CheckBox4":
                    string str11234 = e.CommandName.Trim();
                    string str211234 = e.CommandArgument.ToString().Trim();
                    string str411234 = str11234;
                    if (str411234 != null)
                    {
                        string str3;
                        str211234 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                        if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                        {
                            str3 = "0";
                        }
                        else
                        {
                            str3 = "1";
                        }
                        SNews.Name_Text("update News set CheckBox4= " + str3 + " where inid=" + str211234 + "");
                        this.LoadItems();
                        base.Response.Redirect(base.Request.Url.ToString().Trim());
                        return;
                    }
                    return;
                case "CheckBox5":
                    string str112345 = e.CommandName.Trim();
                    string str2112345 = e.CommandArgument.ToString().Trim();
                    string str4112345 = str112345;
                    if (str4112345 != null)
                    {
                        string str3;
                        str2112345 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                        if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                        {
                            str3 = "0";
                        }
                        else
                        {
                            str3 = "1";
                        }
                        SNews.Name_Text("update News set CheckBox5= " + str3 + " where inid=" + str2112345 + "");
                        this.LoadItems();
                        base.Response.Redirect(base.Request.Url.ToString().Trim());
                        return;
                    }
                    return;
                case "CheckBox6":
                    string str1123456 = e.CommandName.Trim();
                    string str21123456 = e.CommandArgument.ToString().Trim();
                    string str41123456 = str1123456;
                    if (str41123456 != null)
                    {
                        string str3;
                        str21123456 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                        if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                        {
                            str3 = "0";
                        }
                        else
                        {
                            str3 = "1";
                        }
                        SNews.Name_Text("update News set CheckBox6= " + str3 + " where inid=" + str21123456 + "");
                        this.LoadItems();
                        base.Response.Redirect(base.Request.Url.ToString().Trim());
                        return;
                    }
                    return;
                case "UpDate":
                    SNews.UPDATE_DATETIME(e.CommandArgument.ToString(), Convert.ToDateTime(DateTime.Now.ToString()), Convert.ToDateTime(DateTime.Now.AddYears(20).ToString()));
                    this.LoadItems();
                    MultiView1.ActiveViewIndex = 0;
                    base.Response.Redirect(base.Request.Url.ToString().Trim());
                    return;
                case "Chekdata":
                    SNews.CHECKDATA(e.CommandArgument.ToString(), "0", Convert.ToDateTime(DateTime.Now.ToString()), Convert.ToDateTime(DateTime.Now.AddYears(20).ToString()));
                    this.LoadItems();
                    MultiView1.ActiveViewIndex = 0;
                    base.Response.Redirect(base.Request.Url.ToString().Trim());
                    return;
                case "Delete":
                    List<News> str5 = SNews.GETBYID(e.CommandArgument.ToString());
                    if (str5.Count > 0)
                    {
                        try
                        {
                            SNews.Name_Text("DELETE FROM News WHERE TangName ='" + str5[0].TangName + "'");
                        }
                        catch (Exception)
                        { }
                    }
                    SComments.DELETE_Parent_ID(e.CommandArgument.ToString());
                    SNews_Related.DELETE_RELATED(e.CommandArgument.ToString());
                    SNews.News_DELETE(e.CommandArgument.ToString());
                    LoadItems();
                    base.Response.Redirect(base.Request.Url.ToString().Trim());
                    break;
            }
        }

        protected void ddlcategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItems();
            LoadRequest();
        }

        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItems();
            LoadRequest();
        }

        protected void ddlClassBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItems();
            LoadRequest();
        }

        protected void ddlordertype_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItems();
            LoadRequest();
        }

        protected void ddlorderby_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItems();
            LoadRequest();
        }

        protected void btDeleteall_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < rpitems.Items.Count; i++)
                {
                    CheckBox chk = (CheckBox)rpitems.Items[i].FindControl("chkid");
                    HiddenField id = (HiddenField)rpitems.Items[i].FindControl("hiID");
                    if (chk.Checked)
                    {
                        int j;
                        List<News> dlt = new List<News>();
                        dlt = SNews.GETBYID(id.Value);
                        for (j = 0; j < dlt.Count; j++)
                        {
                            //try
                            //{
                            //    ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
                            //    File.Delete(utlitities.APPL_PHYSICAL_PATH + dlt[j].Images.ToString());
                            //    File.Delete(utlitities.APPL_PHYSICAL_PATH + dlt[j].ImagesSmall.ToString());
                            //}
                            //catch (Exception) { }
                            try
                            {
                                SNews.Name_Text("DELETE FROM News WHERE TangName=N'" + dlt[j].TangName + "'");
                            }
                            catch (Exception)
                            { }

                        }
                        SComments.DELETE_Parent_ID(id.Value);
                        SNews_Related.DELETE_RELATED(id.Value);
                        SNews.News_DELETE(id.Value);
                    }
                }
                LoadItems();
                base.Response.Redirect(base.Request.Url.ToString().Trim());
            }
            catch (Exception) { }
        }

        protected void lnksearch_Click(object sender, EventArgs e)
        {
            LoadItems();
            LoadRequest();
        }

        protected void btthemmoi_Click(object sender, EventArgs e)
        {
            hdinsertupdate.Value = "insert";
            MultiView1.ActiveViewIndex = 1;
            DeleteFormValue();
            this.txtfromday.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlcategoriesdetail, this.ddlcategories.SelectedValue);
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void bthienthi_Click(object sender, EventArgs e)
        {
            LoadItems();
            LoadRequest();
        }

        protected string More_Related(string inid, string icid)
        {
            return ("<a href='admin.aspx?u=news&su=News_Related&inid=" + inid + "&icid=" + icid + "'><img src='Uploads/pic/web/icon/add.png' border=0 /></a>");
        }

        protected string Comments(string inid)
        {
            return ("<a href='admin.aspx?u=news&su=Comments&nid=" + inid + "'><img Title=\"Bình luận\" src=\"Uploads/pic/web/icon/comment.png\" border=0 /></a>");
        }
        protected void LoadRequest()
        {
            Response.Redirect("admin.aspx?u=news&su=Tintuc&id=" + ddlcategories.SelectedValue + "&st=" + ddlstatus.SelectedValue + "&us=" + ddlorderby.SelectedValue + "&ds=" + ddlordertype.SelectedValue + "&kw=" + txtkeyword.Text + "");
        }

        protected void chkdaytype_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkdaytype.Checked)
            {
                this.pnadddate.Visible = true;
            }
            else
            {
                this.pnadddate.Visible = false;
            }
        }
        protected void txtTieude_TextChanged(object sender, EventArgs e)
        {
            TextBox Tieude = (TextBox)sender;
            var b = (HiddenField)Tieude.FindControl("hiID");
            #region UpdateMenu
            string TagName = "";
            if (Tieude.Text.Length > 0)
            {
                List<News> item = SNews.GETBYID(b.Value);
                if (item.Count > 0)
                {
                    List<New> list = (from p in db.News where p.TangName == item[0].TangName orderby p.inid descending select p).ToList();
                    if (list.Count > 2)
                    {
                        var hasTagName = db.News.Where(s => s.TangName == MoreAll.AddURL.SeoURL(Tieude.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(Tieude.Text) + "-" + item[0].inid : MoreAll.AddURL.SeoURL(Tieude.Text);
                    }
                    else
                    {
                        if (MoreAll.AddURL.SeoURL(item[0].Title) != MoreAll.AddURL.SeoURL(Tieude.Text)) { var hasTagName = db.News.Where(s => s.TangName == MoreAll.AddURL.SeoURL(Tieude.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(Tieude.Text) + "-" + item[0].inid : MoreAll.AddURL.SeoURL(Tieude.Text); } else { TagName = item[0].TangName; }
                    }
                    SNews.Name_Text("UPDATE [News] SET Title=N'" + Tieude.Text + "',TangName=N'" + TagName + "'  WHERE inid=" + b.Value + "");
                    LoadItems();
                    this.ltmsg.Text = "<span class=alert>Cập nhật tiêu đề thành công !!</span>";
                }
            }
            else
            {
                LoadItems();
                ltmsg.Text = "<span class=alert>Bạn chưa nhập tiêu đề !!</span>";
            }
            #endregion

        }

        protected void btkiemtra_Click(object sender, EventArgs e)
        {
            string ssl = "http://" + Request.Url.Host + "/";
            if (Commond.Setting("SSL").Equals("1"))
            {
                ssl = "https://" + Request.Url.Host + "/";
            }
            if (hdinsertupdate.Value.Equals("insert"))
            {
                #region RewriteUrl
                int cong = 0;
                string TangName = "";
                if (txtRewriteUrl.Text.Length > 0)
                {
                    #region InsertMenu
                    List<Entity.News> curItem = SNews.Name_Text("SELECT top 1 * FROM News order by inid desc");
                     if (curItem.Count > 0) { int tong = int.Parse(curItem[0].inid.ToString()); cong = tong + 1; } var hasTagName = db.News.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)).FirstOrDefault(); TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtRewriteUrl.Text) + "-" + cong : MoreAll.AddURL.SeoURL(txtRewriteUrl.Text);
                    #endregion
                }
                else
                {
                    #region InsertMenu
                    List<Entity.News> curItem = SNews.Name_Text("SELECT top 1 * FROM News order by inid desc");
                    if (curItem.Count > 0) { int tong = int.Parse(curItem[0].inid.ToString()); cong = tong + 1; } var hasTagName = db.News.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtname.Text)).FirstOrDefault(); TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtname.Text) + "-" + cong : MoreAll.AddURL.SeoURL(txtname.Text);
                    #endregion
                }
                ltshowurl.Text = ssl + TangName + ".html";
                #endregion
            }
            else
            {
                #region RewriteUrl
                string TagName = "";
                if (txtRewriteUrl.Text.Length > 0)
                {
                    #region UpdateMenu
                    List<News> item = SNews.GETBYID(this.hdid.Value);
                    if (item.Count > 0)
                    {
                        List<New> list = (from p in db.News where p.TangName == item[0].TangName orderby p.inid descending select p).ToList();
                        if (list.Count > 2)
                        {
                            var hasTagName = db.News.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtRewriteUrl.Text) + "-" + item[0].inid : MoreAll.AddURL.SeoURL(txtRewriteUrl.Text);
                        }
                        else
                        {
                            if (MoreAll.AddURL.SeoURL(item[0].TangName) != MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)) { var hasTagName = db.News.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtRewriteUrl.Text) + "-" + item[0].inid : MoreAll.AddURL.SeoURL(txtRewriteUrl.Text); } else { TagName = item[0].TangName; }
                        }
                    }
                    #endregion
                }
                else
                {
                    #region UpdateMenu
                    List<News> item = SNews.GETBYID(this.hdid.Value);
                    if (item.Count > 0)
                    {
                        List<New> list = (from p in db.News where p.TangName == item[0].TangName orderby p.inid descending select p).ToList();
                        if (list.Count > 2)
                        {
                            var hasTagName = db.News.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtname.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtname.Text) + "-" + item[0].inid : MoreAll.AddURL.SeoURL(txtname.Text);
                        }
                        else
                        {
                            if (MoreAll.AddURL.SeoURL(item[0].TangName) != MoreAll.AddURL.SeoURL(txtname.Text)) { var hasTagName = db.News.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtname.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtname.Text) + "-" + item[0].inid : MoreAll.AddURL.SeoURL(txtname.Text); } else { TagName = item[0].TangName; }
                        }
                    }
                    #endregion
                }
                ltshowurl.Text = ssl + TagName + ".html";
                #endregion
            }
        }
    }
}