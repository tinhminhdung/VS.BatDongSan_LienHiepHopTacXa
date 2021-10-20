using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using System.IO;
using MoreAll;
using Entity;
using System.Drawing.Imaging;
using Framwork;

namespace VS.ECommerce_MVC.cms.Admin.Video
{
    public partial class Videos : System.Web.UI.UserControl
    {
        private string lang = Captionlanguage.Language;
        private string status = "";
        ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
        DatalinqDataContext db = new DatalinqDataContext();
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
            this.Page.Form.DefaultButton = lnksearch.UniqueID;
            if (!IsPostBack)
            {
                if (Request["st"] != null && !Request["st"].Equals(""))
                {
                    ddlstatus.SelectedValue = Request["st"];
                    WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlstatus, this.status);
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
                LoadCategories();
                LoadItems();
            }
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        #region Menu
        protected void LoadCategories()
        {
            if (Request["id"] != null && !Request["id"].Equals(""))
            {
                ddlcategories.SelectedValue = Request["id"];
            }
            int str = 0;
            List<Entity.Menu> dt = SMenu.LOAD_CATESPARENT_ID(More.VD, this.lang, "-1", "1");
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
        protected int Categories(string id, int str, string j)
        {
            List<Entity.Menu> dt = SMenu.LOAD_CATESPARENT_ID(More.VD, this.lang, id, "1");
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
        //        string[] searchfields = new string[] { "Title", "Brief", "Contents", "search" };
        //        string orderby = this.ddlorderby.SelectedValue + " " + this.ddlordertype.SelectedValue;
        //        List<Entity.VideoClip> dt = SVideoClip.CATEGORY_ADMIN(orderby, this.txtkeyword.Text.Replace("&nbsp;", ""), searchfields, ddlcategories.SelectedValue, More.Sub_Menu(More.VD, ddlcategories.SelectedValue), lang, ddlstatus.SelectedValue);
        //        CollectionPager1.DataSource = dt;
        //        CollectionPager1.BindToControl = rpitems;
        //        CollectionPager1.MaxPages = 10000;
        //        CollectionPager1.PageSize = 10;
        //        rpitems.DataSource = CollectionPager1.DataSourcePaged;
        //        rpitems.DataBind();
        //        RemoveCache.Video();
        //    }
        //    catch (Exception) { }
        //}
        public void LoadItems()
        {
            RemoveCache.Video();
            string sapxep = "";
            string orderby = this.ddlorderby.SelectedValue + " " + this.ddlordertype.SelectedValue;
            string Vitri = "";
            if (txtkeyword.Text.Trim().Length > 0)
            {
                Vitri += " and (search LIKE N'" + Fproducts.SearchApproximate.Exec(Fproducts.ConvertVN.Convert(txtkeyword.Text.Trim())) + "' OR Brief LIKE N'" + Fproducts.SearchApproximate.Exec(txtkeyword.Text.Trim()) + "' OR search LIKE N'" + Fproducts.SearchApproximate.Exec(txtkeyword.Text.Trim()) + "')";
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
            List<Entity.VideoClip> iitem = SVideoClip.CATEGORY_PHANTRANG_ADMIN1(Commond.SubMenu(More.VD, ddlcategories.SelectedValue), Vitri, lang);
            if (iitem.Count() > 0)
            {
                Tongsobanghi = iitem.Count();
            }
            List<Entity.VideoClip> dt = SVideoClip.CATEGORY_PHANTRANG_ADMIN2(Commond.SubMenu(More.VD, ddlcategories.SelectedValue), Vitri, lang, sapxep, (pages - 1), Tongsotrang);
            //if (dt.Count >= 1)
            // {
            rpitems.DataSource = dt;
            rpitems.DataBind();
            //}
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
            ltpage.Text = Commond.PhantrangAdmin("/admin.aspx?u=Video&su=items&id=" + ddlcategories.SelectedValue + "&st=" + ddlstatus.SelectedValue + "&us=" + ddlorderby.SelectedValue + "&ds=" + ddlordertype.SelectedValue + "&kw=" + txtkeyword.Text + "", Tongsobanghi, pages);
        }
        protected void lnkcreatenew_Click(object sender, EventArgs e)
        {
            hdinsertupdate.Value = "insert";
            MultiView1.ActiveViewIndex = 1;
            DeleteFormValue();
            this.txtfromday.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlcategoriesdetail, this.ddlcategories.SelectedValue);
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            DeleteFormValue();
            LoadItems();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlcategories, this.ddlcategoriesdetail.SelectedValue);
                if (this.txtname.Text.Trim().Length < 1)
                {
                    this.lbl_msg.Text = "Xin vui lòng kiểm tra dữ liệu đầu vào của bạn";
                }
                else
                {
                    string status = "0";
                    if (this.chkstatus.Checked)
                    {
                        status = "1";
                    }
                    string news = "0";
                    if (this.chknews.Checked)
                    {
                        news = "1";
                    }
                    #region Chekdata
                    string Chekdata = "0";
                    string cdate = DateTime.Now.ToString();
                    string edate = DateTime.Now.AddYears(10).ToString();
                    DateTime dcreatedate = Convert.ToDateTime(cdate.ToString());
                    DateTime denddate = Convert.ToDateTime(edate.ToString());
                    if (this.chkdaytype.Checked)
                    {
                        Chekdata = "1";
                        dcreatedate = Convert.ToDateTime(this.txtfromday.Text);
                        denddate = dcreatedate.AddDays((double)Convert.ToInt32(this.txtindays.Text));
                    }
                    #endregion

                    Entity.VideoClip obj = new Entity.VideoClip();
                    if (hdinsertupdate.Value.Equals("insert"))
                    {
                        #region RewriteUrl
                        int cong = 0;
                        string TangName = "";
                        if (txtRewriteUrl.Text.Length > 0)
                        {
                            #region InsertMenu
                            List<Entity.VideoClip> curItem = SVideoClip.Name_Text("SELECT top 1 * FROM VideoClip order by ID desc");
                            if (curItem.Count > 0) { int tong = int.Parse(curItem[0].ID.ToString()); cong = tong + 1; } var hasTagName = db.VideoClips.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)).FirstOrDefault(); TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtRewriteUrl.Text) + "-" + cong : MoreAll.AddURL.SeoURL(txtRewriteUrl.Text);
                            #endregion
                        }
                        else
                        {
                            #region InsertMenu
                            List<Entity.VideoClip> curItem = SVideoClip.Name_Text("SELECT top 1 * FROM VideoClip order by ID desc");
                            if (curItem.Count > 0) { int tong = int.Parse(curItem[0].ID.ToString()); cong = tong + 1; } var hasTagName = db.VideoClips.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtname.Text)).FirstOrDefault(); TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtname.Text) + "-" + cong : MoreAll.AddURL.SeoURL(txtname.Text);
                            #endregion
                        }
                        #endregion

                        #region MyRegion
                        obj.Menu_ID = int.Parse(ddlcategoriesdetail.SelectedValue);
                        obj.Title = txtname.Text;
                        obj.Brief = txtdesc.Text;
                        obj.Contents = txtcontent.Text;
                        obj.Keywords = txtauthor.Text;
                        obj.search = RewriteURLNew.NameSearch(txtname.Text);
                        //obj.Images = vimg;
                        //obj.ImagesSmall = small;
                        obj.Images = txtImage.Text;
                        obj.ImagesSmall = txtImage.Text.Replace("uploads", "uploads/_thumbs");
                        obj.Equals = 0;
                        obj.Chekdata = int.Parse(Chekdata);
                        obj.Create_Date = dcreatedate;
                        obj.Modified_Date = denddate;
                        obj.Views = 0;
                        obj.lang = this.lang;
                        obj.News = int.Parse(news);
                        obj.Status = int.Parse(status);
                        obj.Titleseo = txttitleseo.Text;
                        obj.Meta = txtmeta.Text;
                        obj.Keyword = txtKeywordS.Text;
                        obj.TangName = TangName;
                        obj.Alt = txtAlt.Text;
                        obj.Youtube = txtYoutube.Text;

                        #endregion
                        SVideoClip.INSERT(obj);
                    }
                    else
                    {
                        //#region UpdateMenu
                        //string TagName = "";
                        //List<Entity.VideoClip> item = SVideoClip.GET_BY_ID(this.hdid.Value);
                        //if (item.Count > 0)
                        //{
                        //    Menu item[0] = db.Menus.SingleOrDefault(p => p.TangName == item[0].TangName);
                        //    item[0].Name = txtname.Text;
                        //    item[0].Module = 8;
                        //    List<Menu> list = (from p in db.Menus where p.TangName == item[0].TangName orderby p.ID descending select p).ToList();
                        //    if (list.Count > 2)
                        //    {
                        //        var hasTagName = db.VideoClips.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtname.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtname.Text) + "-" + item[0].ID : MoreAll.AddURL.SeoURL(txtname.Text);
                        //    }
                        //    else
                        //    {
                        //        if (MoreAll.AddURL.SeoURL(item[0].Title) != MoreAll.AddURL.SeoURL(txtname.Text)) { var hasTagName = db.VideoClips.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtname.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtname.Text) + "-" + item[0].ID : MoreAll.AddURL.SeoURL(txtname.Text); } else { TagName = item[0].TangName; }
                        //    }
                        //    item[0].TangName = TagName;
                        //    db.SubmitChanges();
                        //}
                        //#endregion


                        #region RewriteUrl
                        string TagName = "";
                        if (txtRewriteUrl.Text.Length > 0)
                        {
                            #region UpdateMenu
                            List<Entity.VideoClip> item = SVideoClip.GET_BY_ID(this.hdid.Value);
                            if (item.Count > 0)
                            {
                                List<VideoClip> list = (from p in db.VideoClips where p.TangName == item[0].TangName orderby p.ID descending select p).ToList();
                                if (list.Count > 2)
                                {
                                    var hasTagName = db.VideoClips.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtRewriteUrl.Text) + "-" + item[0].ID : MoreAll.AddURL.SeoURL(txtRewriteUrl.Text);
                                }
                                else
                                {
                                    if (MoreAll.AddURL.SeoURL(item[0].TangName) != MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)) { var hasTagName = db.VideoClips.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtRewriteUrl.Text) + "-" + item[0].ID : MoreAll.AddURL.SeoURL(txtRewriteUrl.Text); } else { TagName = item[0].TangName; }
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            #region UpdateMenu
                            List<Entity.VideoClip> item = SVideoClip.GET_BY_ID(this.hdid.Value);
                            if (item.Count > 0)
                            {
                                List<VideoClip> list = (from p in db.VideoClips where p.TangName == item[0].TangName orderby p.ID descending select p).ToList();
                                if (list.Count > 2)
                                {
                                    var hasTagName = db.VideoClips.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtname.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtname.Text) + "-" + item[0].ID : MoreAll.AddURL.SeoURL(txtname.Text);
                                }
                                else
                                {
                                    if (MoreAll.AddURL.SeoURL(item[0].TangName) != MoreAll.AddURL.SeoURL(txtname.Text)) { var hasTagName = db.VideoClips.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtname.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtname.Text) + "-" + item[0].ID : MoreAll.AddURL.SeoURL(txtname.Text); } else { TagName = item[0].TangName; }
                                }
                            }
                            #endregion
                        }
                        #endregion

                        #region MyRegion
                        obj.ID = int.Parse(hdid.Value);
                        obj.Menu_ID = int.Parse(ddlcategoriesdetail.SelectedValue);
                        obj.Title = txtname.Text;
                        obj.Brief = txtdesc.Text;
                        obj.Contents = txtcontent.Text;
                        obj.Keywords = txtauthor.Text;
                        obj.search = RewriteURLNew.NameSearch(txtname.Text);
                        //obj.Images = vimg;
                        //obj.ImagesSmall = small;
                        obj.Images = txtImage.Text;
                        obj.ImagesSmall = txtImage.Text.Replace("uploads", "uploads/_thumbs");
                        obj.Equals = 0;
                        obj.Chekdata = int.Parse(Chekdata);
                        //obj.Create_Date = dcreatedate;
                        //obj.Modified_Date = denddate;
                        obj.Views = 0;
                        obj.lang = this.lang;
                        obj.News = int.Parse(news);
                        obj.Status = int.Parse(status);
                        obj.Titleseo = txttitleseo.Text;
                        obj.Meta = txtmeta.Text;
                        obj.Keyword = txtKeywordS.Text;
                        obj.TangName = TagName;
                        obj.Alt = txtAlt.Text;
                        obj.Youtube = txtYoutube.Text;
                        #endregion
                        SVideoClip.UPDATE(obj);
                    }
                    base.Response.Redirect(base.Request.Url.ToString().Trim());
                    MultiView1.ActiveViewIndex = 0;
                    DeleteFormValue();
                }
            }
            catch (Exception) { }
        }

        public bool ThumbnailCallback()
        {
            return false;
        }

        void DeleteFormValue()
        {
            txtdesc.Text = "";
            txtcontent.Text = "";
            hdivd.Value = "";
            txtname.Text = "";
            txtcontent.Text = "";
            txtauthor.Text = "";
            this.hdFileName.Value = "";
            this.lbl_msg.Text = "";
            hdimg.Value = "";
            hdimgMax.Value = "";
            hdimgsmallEdit.Value = "";
            hdimgMaxEdit.Value = "";
            txttitleseo.Text = "";
            txtmeta.Text = "";
            txtKeywordS.Text = "";
            txtImage.Text = "";
            hdimgnews.Value = "";
            txtRewriteUrl.Text = "";
            ltshowurl.Text = "";
            ltimgs.Text = "";
            txtAlt.Text = "";
            txtYoutube.Text = "";
        }

        protected void Delete_Load(object sender, System.EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Xóa tin được lựa chọn ?.')";
        }

        protected void rpitems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            List<Entity.VideoClip> dtdetail = new List<Entity.VideoClip>();
            switch (e.CommandName)
            {
                #region EditDetail
                case "EditDetail":
                    dtdetail = SVideoClip.GET_BY_ID(e.CommandArgument.ToString());
                    if (dtdetail.Count > 0)
                    {
                        txtname.Text = dtdetail[0].Title.ToString();
                        txtdesc.Text = dtdetail[0].Brief.ToString();
                        txtcontent.Text = dtdetail[0].Contents.ToString();
                        txtauthor.Text = dtdetail[0].Keywords.ToString();
                        txtAlt.Text = dtdetail[0].Alt;
                        txtImage.Text = dtdetail[0].Images;
                        ltimgs.Text = MoreImage.Image(dtdetail[0].ImagesSmall);
                        hdimgnews.Value = dtdetail[0].Images;
                        txtYoutube.Text = dtdetail[0].Youtube;

                        txtRewriteUrl.Text = dtdetail[0].TangName;
                        string ssl = "http://" + Request.Url.Host + "/";
                        if (Commond.Setting("SSL").Equals("1"))
                        {
                            ssl = "https://" + Request.Url.Host + "/";
                        }
                        ltshowurl.Text = ssl + dtdetail[0].TangName + ".html";
                        #region Seowwebsite
                        txttitleseo.Text = dtdetail[0].Titleseo.ToString().Trim();
                        txtmeta.Text = dtdetail[0].Meta.ToString().Trim();
                        txtKeywordS.Text = dtdetail[0].Keyword.ToString().Trim();
                        #endregion

                        hdimgMaxEdit.Value = dtdetail[0].Images.ToString();
                        hdimgsmallEdit.Value = dtdetail[0].ImagesSmall.ToString();
                        // ltimg.Text = MoreImage.Image(dtdetail[0].ImagesSmall.ToString());

                        WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlcategoriesdetail, dtdetail[0].Menu_ID.ToString());
                        if (dtdetail[0].Status.ToString().Trim().Equals("0"))
                        {
                            this.chkstatus.Checked = false;
                        }
                        else if (dtdetail[0].Status.ToString().Equals("1"))
                        {
                            this.chkstatus.Checked = true;
                        }
                        this.chkstatus.Checked = true;

                        if (dtdetail[0].News.ToString().Trim().Equals("0"))
                        {
                            this.chknews.Checked = false;
                        }
                        else if (dtdetail[0].News.ToString().Equals("1"))
                        {
                            this.chknews.Checked = true;
                        }
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
                        hdid.Value = dtdetail[0].ID.ToString();
                        // giu gia tri cua nhom thông tin cu: su dung khi thay doi nhom thông tin.
                        hdivd.Value = dtdetail[0].Menu_ID.ToString();
                        ddlcategoriesdetail.SelectedValue = hdivd.Value;
                    }
                    break;
                #endregion
                #region ChangeStatus
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
                        SVideoClip.VIDeo_UpdateStatus(str2, str3);
                        this.LoadItems();
                        base.Response.Redirect(base.Request.Url.ToString().Trim());
                        return;
                    }
                    return;
                #endregion
                #region ChangeStatus
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
                        SVideoClip.Name_Text("update VideoClip set News=" + str3 + " where ID=" + str21 + "");
                        this.LoadItems();
                        base.Response.Redirect(base.Request.Url.ToString().Trim());
                        return;
                    }
                    return;
                #endregion
                #region updat_date
                case "updat_date":
                    SVideoClip.UPDATE_DATETIME(e.CommandArgument.ToString(), Convert.ToDateTime(DateTime.Now.ToString()), Convert.ToDateTime(DateTime.Now.AddYears(20).ToString()));
                    this.LoadItems();
                    MultiView1.ActiveViewIndex = 0;
                    base.Response.Redirect(base.Request.Url.ToString().Trim());
                    return;
                case "Chekdata":
                    SVideoClip.CHECKDATA(e.CommandArgument.ToString(), "0", Convert.ToDateTime(DateTime.Now.ToString()), Convert.ToDateTime(DateTime.Now.AddYears(20).ToString()));
                    this.LoadItems();
                    MultiView1.ActiveViewIndex = 0;
                    base.Response.Redirect(base.Request.Url.ToString().Trim());
                    return;
                #endregion
                #region Delete
                case "Delete":
                    List<Entity.VideoClip> str5 = SVideoClip.GET_DETAIL_BYID(e.CommandArgument.ToString());
                    if (str5.Count > 0)
                    {
                        try
                        {
                            SVideoClip.Name_Text("DELETE FROM VideoClip WHERE TangName=N'" + str5[0].TangName + "'");
                        }
                        catch (Exception)
                        { }
                    }
                    SVideoClip.DELETE(e.CommandArgument.ToString());
                    LoadItems();
                    base.Response.Redirect(base.Request.Url.ToString().Trim());
                    break;
                #endregion
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
        protected void LoadRequest()
        {
            Response.Redirect("admin.aspx?u=Video&su=items&id=" + ddlcategories.SelectedValue + "&st=" + ddlstatus.SelectedValue + "&us=" + ddlorderby.SelectedValue + "&ds=" + ddlordertype.SelectedValue + "&kw=" + txtkeyword.Text + "");
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
                        List<Entity.VideoClip> dlt = SVideoClip.GET_DETAIL_BYID(id.Value);
                        for (j = 0; j < dlt.Count; j++)
                        {
                            //    try
                            //    {
                            //        ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
                            //        File.Delete(utlitities.APPL_PHYSICAL_PATH + dlt[j].Images.ToString());

                            //    }
                            //    catch (Exception) { }
                            try
                            {
                                SVideoClip.Name_Text("DELETE FROM VideoClip WHERE TangName=N'" + dlt[j].TangName + "'");
                            }
                            catch (Exception)
                            {
                            }
                        }
                        SVideoClip.DELETE(id.Value);
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

        protected void Button1_Click1(object sender, EventArgs e)
        {
            this.LoadItems();
            LoadRequest();
        }

        protected void bthienthi_Click(object sender, EventArgs e)
        {
            this.LoadItems();
            LoadRequest();
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
            if (Tieude.Text.Length > 0)
            {
                #region UpdateMenu
                string TagName = "";
                List<Entity.VideoClip> item = SVideoClip.GET_BY_ID(b.Value);
                if (item.Count > 0)
                {
                    List<VideoClip> list = (from p in db.VideoClips where p.TangName == item[0].TangName orderby p.ID descending select p).ToList();
                    if (list.Count > 2)
                    {
                        var hasTagName = db.VideoClips.Where(s => s.TangName == MoreAll.AddURL.SeoURL(Tieude.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(Tieude.Text) + "-" + item[0].ID : MoreAll.AddURL.SeoURL(Tieude.Text);
                    }
                    else
                    {
                        if (MoreAll.AddURL.SeoURL(item[0].Title) != MoreAll.AddURL.SeoURL(Tieude.Text)) { var hasTagName = db.VideoClips.Where(s => s.TangName == MoreAll.AddURL.SeoURL(Tieude.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(Tieude.Text) + "-" + item[0].ID : MoreAll.AddURL.SeoURL(Tieude.Text); } else { TagName = item[0].TangName; }
                    }
                    SVideoClip.Name_Text("UPDATE [VideoClip] SET Title=N'" + Tieude.Text + "',TangName=N'" + TagName + "'  WHERE ID=" + b.Value + "");
                    LoadItems();
                    this.ltmsg.Text = "<span class=alert>Cập nhật tiêu đề thành công !!</span>";
                }
                #endregion
            }
            else
            {
                LoadItems();
                ltmsg.Text = "<span class=alert>Bạn chưa nhập tiêu đề !!</span>";
            }
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
                    List<Entity.VideoClip> curItem = SVideoClip.Name_Text("SELECT top 1 * FROM VideoClip order by ID desc");
                    int tong = int.Parse(curItem[0].ID.ToString()); cong = tong + 1; var hasTagName = db.VideoClips.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)).FirstOrDefault(); TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtRewriteUrl.Text) + "-" + cong : MoreAll.AddURL.SeoURL(txtRewriteUrl.Text);
                    #endregion
                }
                else
                {
                    #region InsertMenu
                    List<Entity.VideoClip> curItem = SVideoClip.Name_Text("SELECT top 1 * FROM VideoClip order by ID desc");
                    int tong = int.Parse(curItem[0].ID.ToString()); cong = tong + 1; var hasTagName = db.VideoClips.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtname.Text)).FirstOrDefault(); TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtname.Text) + "-" + cong : MoreAll.AddURL.SeoURL(txtname.Text);
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
                    List<Entity.VideoClip> item = SVideoClip.GET_BY_ID(this.hdid.Value);
                    if (item.Count > 0)
                    {
                        List<VideoClip> list = (from p in db.VideoClips where p.TangName == item[0].TangName orderby p.ID descending select p).ToList();
                        if (list.Count > 2)
                        {
                            var hasTagName = db.VideoClips.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtRewriteUrl.Text) + "-" + item[0].ID : MoreAll.AddURL.SeoURL(txtRewriteUrl.Text);
                        }
                        else
                        {
                            if (MoreAll.AddURL.SeoURL(item[0].TangName) != MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)) { var hasTagName = db.VideoClips.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtRewriteUrl.Text) + "-" + item[0].ID : MoreAll.AddURL.SeoURL(txtRewriteUrl.Text); } else { TagName = item[0].TangName; }
                        }
                    }
                    #endregion
                }
                else
                {
                    #region UpdateMenu
                    List<Entity.VideoClip> item = SVideoClip.GET_BY_ID(this.hdid.Value);
                    if (item.Count > 0)
                    {
                        List<VideoClip> list = (from p in db.VideoClips where p.TangName == item[0].TangName orderby p.ID descending select p).ToList();
                        if (list.Count > 2)
                        {
                            var hasTagName = db.VideoClips.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtname.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtname.Text) + "-" + item[0].ID : MoreAll.AddURL.SeoURL(txtname.Text);
                        }
                        else
                        {
                            if (MoreAll.AddURL.SeoURL(item[0].TangName) != MoreAll.AddURL.SeoURL(txtname.Text))
                            {
                                var hasTagName = db.VideoClips.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtname.Text)).FirstOrDefault();
                                TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtname.Text) + "-" + item[0].ID : MoreAll.AddURL.SeoURL(txtname.Text);
                            }
                            else
                            {
                                TagName = item[0].TangName;
                            }
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