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
using System.Drawing.Imaging;
using Framwork;

namespace VS.ECommerce_MVC.cms.Admin.Album
{
    public partial class MAlbum : System.Web.UI.UserControl
    {
        private string status = "";
        private string lang = Captionlanguage.Language;
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
            if (Request["st"] != null && !Request["st"].Equals(""))
            {
                ddlstatus.SelectedValue = Request["st"];
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
            this.Page.Form.DefaultButton = lnksearch.UniqueID;
            if (!IsPostBack)
            {
                #region UpdatePanel
                this.Page.Form.Enctype = "multipart/form-data";
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnsave);
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(btkiemtra);
                #endregion
                if (Request["st"] != null && !Request["st"].Equals(""))
                {
                    ddlstatus.SelectedValue = Request["st"];
                    WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlstatus, this.status);
                }
                LoadCategories();
                LoadItems();
            }
        }

        #region Menu
        protected void LoadCategories()
        {
            if (Request["id"] != null && !Request["id"].Equals(""))
            {
                ddlcategories.SelectedValue = Request["id"];
            }
            int str = 0;
            List<Entity.Menu> dt = SMenu.LOAD_CATESPARENT_ID(More.AB, this.lang, "-1", "1");
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
            List<Entity.Menu> dt = SMenu.LOAD_CATESPARENT_ID(More.AB, this.lang, id, "1");
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
        //        List<Entity.Album> dt = SAlbum.CATEGORY_ADMIN(orderby, this.txtkeyword.Text.Trim().Replace("&nbsp;", ""), searchfields, ddlcategories.SelectedValue, More.Sub_Menu(More.AB, ddlcategories.SelectedValue), lang, ddlstatus.SelectedValue);
        //        CollectionPager1.DataSource = dt;
        //        CollectionPager1.BindToControl = rpitems;
        //        CollectionPager1.MaxPages = 10000;
        //        CollectionPager1.PageSize = 10;
        //        rpitems.DataSource = CollectionPager1.DataSourcePaged;
        //        rpitems.DataBind();
        //        RemoveCache.Album();
        //    }
        //    catch (Exception) { }
        //}
        public void LoadItems()
        {
            RemoveCache.Album();
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
            List<Entity.Album> iitem = SAlbum.CATEGORY_PHANTRANG_ADMIN1(Commond.SubMenu(More.AB, ddlcategories.SelectedValue), Vitri, lang);
            if (iitem.Count() > 0)
            {
                Tongsobanghi = iitem.Count();
            }
            List<Entity.Album> dt = SAlbum.CATEGORY_PHANTRANG_ADMIN2(Commond.SubMenu(More.AB, ddlcategories.SelectedValue), Vitri, lang, sapxep, (pages - 1), Tongsotrang);
            //if (dt.Count >= 1)
            //{
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
            ltpage.Text = Commond.PhantrangAdmin("/admin.aspx?u=Album&su=items&id=" + ddlcategories.SelectedValue + "&st=" + ddlstatus.SelectedValue + "&us=" + ddlorderby.SelectedValue + "&ds=" + ddlordertype.SelectedValue + "&kw=" + txtkeyword.Text + "", Tongsobanghi, pages);
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
            // try
            {
                WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlcategories, this.ddlcategoriesdetail.SelectedValue);
                if (this.txtname.Text.Trim().Length < 1)
                {
                    this.lbl_msg.Text = "Xin vui lòng kiểm tra dữ liệu đầu vào của bạn";
                }
                else
                {
                    int status = 0;
                    if (this.chkstatus.Checked)
                    {
                        status = 1;
                    }
                    int news = 0;
                    if (this.chknews.Checked)
                    {
                        news = 1;
                    }
                    #region date
                    int Chek = 0;
                    string cdate = DateTime.Now.ToString();
                    string edate = DateTime.Now.AddYears(10).ToString();
                    DateTime dcreatedate = Convert.ToDateTime(cdate.ToString());
                    DateTime denddate = Convert.ToDateTime(edate.ToString());
                    if (this.chkdaytype.Checked)
                    {
                        Chek = 0;
                        dcreatedate = Convert.ToDateTime(this.txtfromday.Text);
                        denddate = dcreatedate.AddDays((double)Convert.ToInt32(this.txtindays.Text));
                    }
                    #endregion

                    Entity.Album obj = new Entity.Album();
                    if (hdinsertupdate.Value.Equals("insert"))
                    {
                        //#region InsertMenu
                        //int cong = 0;
                        //string TangName = "";
                        //Menu obm = new Menu();
                        //obm.Name = txtname.Text;
                        //obm.Module = 6;
                        //List<Entity.Menu> curItem = SMenu.Name_Text("SELECT top 1 * FROM Menu order by ID desc");
                        //int tong = int.Parse(curItem[0].ID.ToString()); cong = tong + 1; var hasTagName = db.LAlbums.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtname.Text)).FirstOrDefault(); TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtname.Text) + "-" + cong : MoreAll.AddURL.SeoURL(txtname.Text);
                        //obm.TangName = TangName;
                        //db.Menus.InsertOnSubmit(obm);
                        //db.SubmitChanges();
                        //#endregion

                        #region RewriteUrl
                        int cong = 0;
                        string TangName = "";
                        if (txtRewriteUrl.Text.Length > 0)
                        {
                            #region InsertMenu
                            List<Entity.Album> curItem = SAlbum.Name_Text("SELECT top 1 * FROM Album order by ID desc");
                            if (curItem.Count > 0) { int tong = int.Parse(curItem[0].ID.ToString()); cong = tong + 1; } var hasTagName = db.LAlbums.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)).FirstOrDefault(); TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtRewriteUrl.Text) + "-" + cong : MoreAll.AddURL.SeoURL(txtRewriteUrl.Text);
                            #endregion
                        }
                        else
                        {
                            #region InsertMenu
                            List<Entity.Album> curItem = SAlbum.Name_Text("SELECT top 1 * FROM Album order by ID desc");
                            if (curItem.Count > 0) { int tong = int.Parse(curItem[0].ID.ToString()); cong = tong + 1; }
                            var hasTagName = db.LAlbums.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtname.Text)).FirstOrDefault();
                            TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtname.Text) + "-" + cong : MoreAll.AddURL.SeoURL(txtname.Text);
                            #endregion
                        }
                        #endregion

                        #region Insert
                        obj.Menu_ID = int.Parse(ddlcategoriesdetail.SelectedValue);
                        obj.Title = txtname.Text;
                        obj.Brief = txtdesc.Text;
                        obj.Contents = txtcontent.Text;
                        obj.Keywords = txtauthor.Text;
                        obj.search = RewriteURLNew.NameSearch(txtname.Text);
                        //obj.Images = vimg;
                        //obj.ImagesSmall = small;
                        obj.Images = txtImages.Text;
                        obj.ImagesSmall = txtImages.Text.Replace("uploads", "uploads/_thumbs");

                        obj.Equals = 0;
                        obj.Chekdata = Chek;
                        obj.Create_Date = dcreatedate;
                        obj.Modified_Date = denddate;
                        obj.Views = 0;
                        obj.lang = this.lang;
                        obj.News = news;
                        obj.Status = status;
                        obj.Titleseo = txttitleseo.Text;
                        obj.Meta = txtmeta.Text;
                        obj.Keyword = txtKeywordS.Text;
                        obj.TangName = TangName;
                        obj.Anhnhieu = txtMImage.Text.TrimEnd(',');
                        obj.Alt = txtAlt.Text;
                        #endregion
                        SAlbum.INSERT(obj);
                    }
                    else
                    {
                        //#region UpdateMenu
                        //string TagName = "";
                        //List<Entity.Album> item = SAlbum.GETBYID(this.hdid.Value);
                        //if (item.Count > 0)
                        //{
                        //    Menu item[0] = db.Menus.SingleOrDefault(p => p.TangName == item[0].TangName);
                        //    item[0].Name = txtname.Text;
                        //    item[0].Module = 6;
                        //    List<Menu> list = (from p in db.Menus where p.TangName == item[0].TangName orderby p.ID descending select p).ToList();
                        //    if (list.Count > 2)
                        //    {
                        //        var hasTagName = db.LAlbums.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtname.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtname.Text) + "-" + item[0].ID : MoreAll.AddURL.SeoURL(txtname.Text);
                        //    }
                        //    else
                        //    {
                        //        if (MoreAll.AddURL.SeoURL(item[0].Title) != MoreAll.AddURL.SeoURL(txtname.Text)) { var hasTagName = db.LAlbums.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtname.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtname.Text) + "-" + item[0].ID : MoreAll.AddURL.SeoURL(txtname.Text); } else { TagName = item[0].TangName; }
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
                            List<Entity.Album> item = SAlbum.GETBYID(this.hdid.Value);
                            if (item.Count > 0)
                            {
                                List<LAlbum> list = (from p in db.LAlbums where p.TangName == item[0].TangName orderby p.ID descending select p).ToList();
                                if (list.Count > 2)
                                {
                                    var hasTagName = db.LAlbums.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtRewriteUrl.Text) + "-" + item[0].ID : MoreAll.AddURL.SeoURL(txtRewriteUrl.Text);
                                }
                                else
                                {
                                    if (MoreAll.AddURL.SeoURL(item[0].TangName) != MoreAll.AddURL.SeoURL(txtRewriteUrl.Text))
                                    {
                                        var hasTagName = db.LAlbums.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)).FirstOrDefault();
                                        TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtRewriteUrl.Text) + "-" + item[0].ID : MoreAll.AddURL.SeoURL(txtRewriteUrl.Text);
                                    }
                                    else
                                    {
                                        TagName = item[0].TangName;
                                    }
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            #region UpdateMenu
                            List<Entity.Album> item = SAlbum.GETBYID(this.hdid.Value);
                            if (item.Count > 0)
                            {
                                List<LAlbum> list = (from p in db.LAlbums where p.TangName == item[0].TangName orderby p.ID descending select p).ToList();
                                if (list.Count > 2)
                                {
                                    var hasTagName = db.LAlbums.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtname.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtname.Text) + "-" + item[0].ID : MoreAll.AddURL.SeoURL(txtname.Text);
                                }
                                else
                                {
                                    if (MoreAll.AddURL.SeoURL(item[0].TangName) != MoreAll.AddURL.SeoURL(txtname.Text)) { var hasTagName = db.LAlbums.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtname.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtname.Text) + "-" + item[0].ID : MoreAll.AddURL.SeoURL(txtname.Text); } else { TagName = item[0].TangName; }
                                }
                            }
                            #endregion
                        }
                        #endregion

                        #region Update
                        obj.ID = int.Parse(hdid.Value);
                        obj.Menu_ID = int.Parse(ddlcategoriesdetail.SelectedValue);
                        obj.Title = txtname.Text;
                        obj.Brief = txtdesc.Text;
                        obj.Contents = txtcontent.Text;
                        obj.Keywords = txtauthor.Text;
                        obj.search = RewriteURLNew.NameSearch(txtname.Text);
                        //obj.Images = vimg;
                        //obj.ImagesSmall = small;
                        obj.Images = txtImages.Text;
                        obj.ImagesSmall = txtImages.Text.Replace("uploads", "uploads/_thumbs");

                        obj.Equals = 0;
                        obj.Chekdata = Chek;
                        //obj.Create_Date = dcreatedate;
                        //obj.Modified_Date = denddate;
                        obj.Views = 0;
                        obj.lang = this.lang;
                        obj.News = news;
                        obj.Status = status;
                        obj.Titleseo = txttitleseo.Text;
                        obj.Meta = txtmeta.Text;
                        obj.Keyword = txtKeywordS.Text;
                        obj.TangName = TagName;
                        obj.Anhnhieu = txtMImage.Text.TrimEnd(',');
                        obj.Alt = txtAlt.Text;
                        #endregion
                        SAlbum.UPDATE(obj);
                    }
                    base.Response.Redirect(base.Request.Url.ToString().Trim());
                    MultiView1.ActiveViewIndex = 0;
                    DeleteFormValue();
                }
            }
            //catch (Exception) { }
        }

        public bool ThumbnailCallback()
        {
            return false;
        }

        void DeleteFormValue()
        {
            txtdesc.Text = "";
            txtcontent.Text = "";
            hdialb.Value = "";
            txtname.Text = "";
            txtcontent.Text = "";
            txtauthor.Text = "";
            this.hdFileName.Value = "";
            this.lbl_msg.Text = "";
            hdimgMax.Value = "";
            hdimgsmallEdit.Value = "";
            hdimgMaxEdit.Value = "";
            txttitleseo.Text = "";
            txtmeta.Text = "";
            txtKeywordS.Text = "";
            txtMImage.Text = "";
            txtImages.Text = "";
            hdimgnews.Value = "";
            txtAlt.Text = "";
            txtRewriteUrl.Text = "";
            ltshowurl.Text = "";
        }

        protected void Delete_Load(object sender, System.EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Xóa tin được lựa chọn ?.')";
        }

        protected void rpitems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            List<Entity.Album> dtdetail = new List<Entity.Album>();
            switch (e.CommandName)
            {
                #region EditDetail
                case "EditDetail":
                    dtdetail = SAlbum.GET_DETAIL_BYID(e.CommandArgument.ToString());
                    if (dtdetail.Count > 0)
                    {
                        txtname.Text = dtdetail[0].Title;
                        txtdesc.Text = dtdetail[0].Brief;
                        txtcontent.Text = dtdetail[0].Contents;
                        txtauthor.Text = dtdetail[0].Keywords;

                        hdimgMaxEdit.Value = dtdetail[0].Images;
                        hdimgsmallEdit.Value = dtdetail[0].ImagesSmall.ToString();
                        //ltimg.Text = MoreImage.Image(dtdetail[0].ImagesSmall.ToString());

                        txtAlt.Text = dtdetail[0].Alt;

                        txtImages.Text = dtdetail[0].Images;
                        ltimgs.Text = MoreImage.Image(dtdetail[0].ImagesSmall);
                        hdimgnews.Value = dtdetail[0].Images;

                        txtRewriteUrl.Text = dtdetail[0].TangName.ToString();
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

                        if (dtdetail[0].Anhnhieu.Length > 0)
                        {
                            txtMImage.Text = dtdetail[0].Anhnhieu;
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "LoadImage", @"<script type='text/javascript'>LoadStringImg('" + dtdetail[0].Anhnhieu + "','" + txtMImage.ClientID + "');</script>", false);
                        }
                        else
                        {
                            txtMImage.Text = "";
                        }

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
                        hdialb.Value = dtdetail[0].Menu_ID.ToString();
                        ddlcategoriesdetail.SelectedValue = hdialb.Value;
                    }
                    break;
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
                        SAlbum.Name_Text("update Album set News=" + str3 + "  where ID=" + str21 + "");
                        this.LoadItems();
                        return;
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
                        SAlbum.Album_UpdateStatus(str2, str3);
                        this.LoadItems();
                        base.Response.Redirect(base.Request.Url.ToString().Trim());
                        return;
                    }
                    return;
                #endregion
                #region updat_date
                case "updat_date":
                    SAlbum.UPDATE_DATETIME(e.CommandArgument.ToString(), Convert.ToDateTime(DateTime.Now.ToString()), Convert.ToDateTime(DateTime.Now.AddYears(20).ToString()));
                    this.LoadItems();
                    MultiView1.ActiveViewIndex = 0;
                    base.Response.Redirect(base.Request.Url.ToString().Trim());
                    return;
                case "Chekdata":
                    SAlbum.CHECKDATA(e.CommandArgument.ToString(), "0", Convert.ToDateTime(DateTime.Now.ToString()), Convert.ToDateTime(DateTime.Now.AddYears(20).ToString()));
                    this.LoadItems();
                    MultiView1.ActiveViewIndex = 0;
                    base.Response.Redirect(base.Request.Url.ToString().Trim());
                    return;
                #endregion
                #region Delete
                case "Delete":
                    // xoa bang prods_images
                    int j;
                    //List<Album_Images> dlt = new List<Album_Images>();
                    //dlt = SAlbum_Images.GET_BY_ID(e.CommandArgument.ToString());
                    //for (j = 0; j < dlt.Count; j++)
                    //{
                    //    try
                    //    {
                    //        ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
                    //        System.IO.File.Delete(utlitities.APPL_PHYSICAL_PATH + dlt[j].Images.ToString());
                    //        System.IO.File.Delete(utlitities.APPL_PHYSICAL_PATH + dlt[j].ImagesSmall.ToString());
                    //    }
                    //    catch (Exception) { }
                    //}
                    List<Entity.Album> str5 = new List<Entity.Album>();
                    str5 = SAlbum.GET_DETAIL_BYID(e.CommandArgument.ToString());
                    if (str5.Count > 0)
                    {
                        //try
                        //{
                        //    ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
                        //    File.Delete(utlitities.APPL_PHYSICAL_PATH + str5[0].Images.ToString());
                        //    File.Delete(utlitities.APPL_PHYSICAL_PATH + str5[0].ImagesSmall.ToString());

                        //}
                        //catch (Exception) { }
                        try
                        {
                            SAlbum.Name_Text("DELETE FROM Album WHERE TangName=N'" + str5[0].TangName + "'");
                        }
                        catch (Exception)
                        { }
                    }
                    SAlbum_Images.GET_DETAIL_BY_MENUALB(e.CommandArgument.ToString());
                    SAlbum.DELETE(e.CommandArgument.ToString());
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
                        #region Delete
                        //List<Album_Images> str = SAlbum_Images.GET_DETAIL_BY_MENUALB(id.Value);
                        //for (int k = 0; k < str.Count; k++)
                        //{
                        //    //try
                        //    //{
                        //    //    ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
                        //    //    System.IO.File.Delete(utlitities.APPL_PHYSICAL_PATH + str[k].Images.ToString());
                        //    //    System.IO.File.Delete(utlitities.APPL_PHYSICAL_PATH + str[k].ImagesSmall.ToString());
                        //    //}
                        //    //catch (Exception) { }
                        //}
                        List<Entity.Album> dlt = SAlbum.GETBYID(id.Value);
                        for (int j = 0; j < dlt.Count; j++)
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
                                SAlbum.Name_Text("DELETE FROM Album WHERE TangName=N'" + dlt[j].TangName + "'");
                            }
                            catch (Exception)
                            { }
                        }
                        #endregion
                        SAlbum_Images.CATE_DELETE_MENU_ALB(id.Value);
                        SAlbum.DELETE(id.Value);
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

        protected string MoreImages(string ID, string Menu_ID)
        {
            return ("<a href='admin.aspx?u=Album&su=images&iphoto=" + ID + "&ialb=" + Menu_ID + "'><img src='Resources/admin/images/Moreimgaes1.png' border=0 /></a>");
        }
        protected void LoadRequest()
        {
            Response.Redirect("admin.aspx?u=Album&su=items&id=" + ddlcategories.SelectedValue + "&st=" + ddlstatus.SelectedValue + "&us=" + ddlorderby.SelectedValue + "&ds=" + ddlordertype.SelectedValue + "&kw=" + txtkeyword.Text + "");
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
                List<Entity.Album> item = SAlbum.GETBYID(b.Value);
                if (item.Count > 0)
                {
                    List<LAlbum> list = (from p in db.LAlbums where p.TangName == item[0].TangName orderby p.ID descending select p).ToList();
                    if (list.Count > 2)
                    {
                        var hasTagName = db.LAlbums.Where(s => s.TangName == MoreAll.AddURL.SeoURL(Tieude.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(Tieude.Text) + "-" + item[0].ID : MoreAll.AddURL.SeoURL(Tieude.Text);
                    }
                    else
                    {
                        if (MoreAll.AddURL.SeoURL(item[0].Title) != MoreAll.AddURL.SeoURL(Tieude.Text)) { var hasTagName = db.LAlbums.Where(s => s.TangName == MoreAll.AddURL.SeoURL(Tieude.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(Tieude.Text) + "-" + item[0].ID : MoreAll.AddURL.SeoURL(Tieude.Text); } else { TagName = item[0].TangName; }
                    }
                    SAlbum.Name_Text("UPDATE [Album] SET Title=N'" + Tieude.Text + "',TangName=N'" + TagName + "'  WHERE ID=" + b.Value + "");
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
                if (txtMImage.Text.Length > 0)
                {
                    ltshowiavascrip.Text = "<script type='text/javascript'>$(function() { LoadStringImg('" + txtMImage.Text + "','" + txtMImage.ClientID + "');}); </script>";
                }
                else
                {
                    txtMImage.Text = "";
                }

                #region RewriteUrl
                int cong = 0;
                string TangName = "";
                if (txtRewriteUrl.Text.Length > 0)
                {
                    #region InsertMenu
                    List<Entity.Album> curItem = SAlbum.Name_Text("SELECT top 1 * FROM Album order by ID desc");
                    int tong = int.Parse(curItem[0].ID.ToString()); cong = tong + 1; var hasTagName = db.LAlbums.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)).FirstOrDefault(); TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtRewriteUrl.Text) + "-" + cong : MoreAll.AddURL.SeoURL(txtRewriteUrl.Text);
                    #endregion
                }
                else
                {
                    #region InsertMenu
                    List<Entity.Album> curItem = SAlbum.Name_Text("SELECT top 1 * FROM Album order by ID desc");
                    int tong = int.Parse(curItem[0].ID.ToString()); cong = tong + 1; var hasTagName = db.LAlbums.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtname.Text)).FirstOrDefault(); TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtname.Text) + "-" + cong : MoreAll.AddURL.SeoURL(txtname.Text);
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
                    List<Entity.Album> item = SAlbum.GETBYID(this.hdid.Value);
                    if (item.Count > 0)
                    {
                        if (item[0].Anhnhieu.Length > 0)
                        {
                            txtMImage.Text = item[0].Anhnhieu;
                            ltshowiavascrip.Text = "<script type='text/javascript'>$(function() { LoadStringImg('" + item[0].Anhnhieu + "','" + txtMImage.ClientID + "');}); </script>";
                        }
                        else
                        {
                            txtMImage.Text = "";
                        }

                        List<LAlbum> list = (from p in db.LAlbums where p.TangName == item[0].TangName orderby p.ID descending select p).ToList();
                        if (list.Count > 2)
                        {
                            var hasTagName = db.LAlbums.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)).FirstOrDefault();
                            TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtRewriteUrl.Text) + "-" + item[0].ID : MoreAll.AddURL.SeoURL(txtRewriteUrl.Text);
                        }
                        else
                        {
                            if (MoreAll.AddURL.SeoURL(item[0].TangName) != MoreAll.AddURL.SeoURL(txtRewriteUrl.Text))
                            {
                                var hasTagName = db.LAlbums.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)).FirstOrDefault();
                                TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtRewriteUrl.Text) + "-" + item[0].ID : MoreAll.AddURL.SeoURL(txtRewriteUrl.Text);
                            }
                            else
                            {
                                TagName = item[0].TangName;
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    #region UpdateMenu
                    List<Entity.Album> item = SAlbum.GETBYID(this.hdid.Value);
                    if (item.Count > 0)
                    {
                        if (item[0].Anhnhieu.Length > 0)
                        {
                            txtMImage.Text = item[0].Anhnhieu;
                            ltshowiavascrip.Text = "<script type='text/javascript'>$(function() { LoadStringImg('" + item[0].Anhnhieu + "','" + txtMImage.ClientID + "');}); </script>";
                        }
                        else
                        {
                            txtMImage.Text = "";
                        }
                        List<LAlbum> list = (from p in db.LAlbums where p.TangName == item[0].TangName orderby p.ID descending select p).ToList();
                        if (list.Count > 2)
                        {
                            var hasTagName = db.LAlbums.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtname.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtname.Text) + "-" + item[0].ID : MoreAll.AddURL.SeoURL(txtname.Text);
                        }
                        else
                        {
                            if (MoreAll.AddURL.SeoURL(item[0].TangName) != MoreAll.AddURL.SeoURL(txtname.Text)) { var hasTagName = db.LAlbums.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtname.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtname.Text) + "-" + item[0].ID : MoreAll.AddURL.SeoURL(txtname.Text); } else { TagName = item[0].TangName; }
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