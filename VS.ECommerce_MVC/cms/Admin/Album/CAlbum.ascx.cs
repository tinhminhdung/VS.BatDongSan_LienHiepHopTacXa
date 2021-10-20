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

namespace VS.ECommerce_MVC.cms.Admin.Album
{
    public partial class CAlbum : System.Web.UI.UserControl
    {
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
            if (!base.IsPostBack)
            {
                #region UpdatePanel
                this.Page.Form.Enctype = "multipart/form-data";
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(btn_InsertUpdate);
                #endregion
                if (!Commond.Setting("PageCateAlbum").Equals(""))
                {
                    ddlPage.SelectedValue = Commond.Setting("PageCateAlbum");
                }
                this.LoadItems();
            }
        }

        protected void btn_InsertUpdate_Click(object sender, EventArgs e)
        {
            // try
            //{
            if (this.txt_title.Text.Trim().Length < 1)
            {
                this.lblmsg.Text = "Xin vui lòng kiểm tra dữ liệu đầu vào của bạn";
            }
            else if (!ValidateUtilities.IsValidInt(this.txt_order.Text.Trim()))
            {
                this.lblmsg.Text = "Xin vui lòng kiểm tra dữ liệu đầu vào của bạn!";
            }
            else
            {
                string sgrnlevel = hidLevel.Value;
                ServerInfoUtlitities utlitities = new ServerInfoUtlitities();

                Entity.Menu obj = new Entity.Menu();
                string str5 = this.hd_insertupdate.Value.Trim();
                if (str5 != null)
                {
                    if (!(str5 == "update"))
                    {
                        if (str5 == "insert")
                        {
                            #region RewriteUrl
                            int cong = 0;
                            string TangName = "";
                            if (txtRewriteUrl.Text.Length > 0)
                            {
                                #region InsertMenu
                                List<Entity.Menu> curItem = SMenu.Name_Text("SELECT top 1 * FROM Menu order by ID desc");
                                int tong = int.Parse(curItem[0].ID.ToString()); cong = tong + 1; var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)).FirstOrDefault(); TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtRewriteUrl.Text) + "-" + cong : MoreAll.AddURL.SeoURL(txtRewriteUrl.Text);

                                #endregion
                            }
                            else
                            {
                                #region InsertMenu
                                List<Entity.Menu> curItem = SMenu.Name_Text("SELECT top 1 * FROM Menu order by ID desc");
                                int tong = int.Parse(curItem[0].ID.ToString()); cong = tong + 1; var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txt_title.Text)).FirstOrDefault(); TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(txt_title.Text) + "-" + cong : MoreAll.AddURL.SeoURL(txt_title.Text);
                                #endregion
                            }
                            #endregion
                            #region MyRegion
                            obj.Parent_ID = Convert.ToInt16(this.hd_id.Value.Trim());
                            obj.capp = More.AB;
                            obj.Type = 0;
                            obj.Lang = lang;
                            obj.Name = txt_title.Text.Trim();
                            obj.Url_Name = RewriteURLNew.NameToTag(this.txt_title.Text.Trim());
                            obj.Link = "";
                            obj.Styleshow = "";
                            obj.Equals = 0;
                            obj.Images = txtImage.Text;
                            obj.Description = txtcontent.Text;
                            obj.Create_Date = DateTime.Now;
                            obj.Views = 0;
                            obj.ShowID = 0;
                            obj.Orders = Convert.ToInt16(txt_order.Text);
                            if (sgrnlevel.Length > 0)
                            {
                                obj.Level = sgrnlevel + "00000";
                            }
                            else
                            {
                                obj.Level = "00000";
                            }
                            obj.News = Convert.ToInt16(chknews.Checked ? "1" : "0");
                            obj.page_Home = Convert.ToInt16(chkTrangChu.Checked ? "1" : "0");
                            obj.Status = Convert.ToInt16(chck_Enable.Checked ? "1" : "0");
                            obj.Titleseo = txttitleseo.Text;
                            obj.Meta = txtmeta.Text;
                            obj.Keyword = txtKeyword.Text;
                            obj.Check_01 = 0;
                            obj.Check_02 = 0;
                            obj.Check_03 = 0;
                            obj.Check_04 = 0;
                            obj.Check_05 = 0;
                            obj.Noidung1 = "";
                            obj.Noidung2 = "";
                            obj.Noidung3 = "";
                            obj.Noidung4 = "";
                            obj.Noidung5 = "";
                            obj.Module = 5;
                            obj.TangName = TangName;
                            #endregion
                            SMenu.Insert(obj);
                        }
                    }
                    else
                    {
                        #region RewriteUrl
                        string TagName = "";
                        if (txtRewriteUrl.Text.Length > 0)
                        {
                            #region UpdateMenu
                            List<Entity.Menu> item = SMenu.GETBYID(hd_page_edit_id.Value);
                            if (item.Count > 0)
                            {
                                Menu obk = db.Menus.SingleOrDefault(p => p.TangName == item[0].TangName);
                                obk.Name = txtRewriteUrl.Text;
                                obk.Module = 5;
                                List<Menu> list = (from p in db.Menus where p.TangName == obk.TangName orderby p.ID descending select p).ToList();
                                if (list.Count > 2)
                                {
                                    var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtRewriteUrl.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(txtRewriteUrl.Text);
                                }
                                else
                                {
                                    if (MoreAll.AddURL.SeoURL(item[0].TangName) != MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)) { var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtRewriteUrl.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(txtRewriteUrl.Text); } else { TagName = item[0].TangName; }
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            #region UpdateMenu
                            List<Entity.Menu> item = SMenu.GETBYID(hd_page_edit_id.Value);
                            if (item.Count > 0)
                            {
                                Menu obk = db.Menus.SingleOrDefault(p => p.TangName == item[0].TangName);
                                obk.Name = txt_title.Text;
                                obk.Module = 5;
                                List<Menu> list = (from p in db.Menus where p.TangName == obk.TangName orderby p.ID descending select p).ToList();
                                if (list.Count > 2)
                                {
                                    var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txt_title.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txt_title.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(txt_title.Text);
                                }
                                else
                                {
                                    if (MoreAll.AddURL.SeoURL(item[0].TangName) != MoreAll.AddURL.SeoURL(txt_title.Text)) { var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txt_title.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txt_title.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(txt_title.Text); } else { TagName = item[0].TangName; }
                                }
                            }
                            #endregion
                        }
                        #endregion

                        #region MyRegion
                        obj.ID = Convert.ToInt16(hd_page_edit_id.Value);
                        obj.Parent_ID = Convert.ToInt16(this.hd_id.Value.Trim());
                        obj.capp = More.AB;
                        obj.Type = 0;
                        obj.Lang = lang;
                        obj.Name = txt_title.Text.Trim();
                        obj.Url_Name = RewriteURLNew.NameToTag(this.txt_title.Text.Trim());
                        obj.Link = "";
                        obj.Styleshow = "";
                        obj.Equals = 0;
                        obj.Images = txtImage.Text;
                        obj.Description = txtcontent.Text;
                        obj.Create_Date = DateTime.Now;
                        obj.Views = 0;
                        obj.ShowID = 0;
                        obj.Orders = Convert.ToInt16(txt_order.Text);
                        obj.Level = sgrnlevel + "00000";
                        obj.News = Convert.ToInt16(chknews.Checked ? "1" : "0");
                        obj.page_Home = Convert.ToInt16(chkTrangChu.Checked ? "1" : "0");
                        obj.Status = Convert.ToInt16(chck_Enable.Checked ? "1" : "0");
                        obj.Titleseo = txttitleseo.Text;
                        obj.Meta = txtmeta.Text;
                        obj.Keyword = txtKeyword.Text;
                        obj.Check_01 = 0;
                        obj.Check_02 = 0;
                        obj.Check_03 = 0;
                        obj.Check_04 = 0;
                        obj.Check_05 = 0;
                        obj.Noidung1 = "";
                        obj.Noidung2 = "";
                        obj.Noidung3 = "";
                        obj.Noidung4 = "";
                        obj.Noidung5 = "";
                        obj.Module = 5;
                        obj.TangName = TagName;
                        #endregion
                        SMenu.UPDATE(obj);
                    }
                }
                this.LoadItems();
                this.pn_list.Visible = true;
                this.pn_insert.Visible = false;
                this.hd_insertupdate.Value = "";
                this.txt_title.Text = "";
                this.hd_insertupdate.Value = "insert";
                this.hd_id.Value = "-1";
                txtImage.Text = "";
                hdimgnews.Value = "";
                ltimgs.Text = "";
                this.hdFileName.Value = "";

                this.txtcontent.Text = "";
                txttitleseo.Text = "";
                txtmeta.Text = "";
                txtKeyword.Text = "";
                this.lblmsg.Text = "";
                this.lbl_curpage.Text = "";
                txtRewriteUrl.Text = "";
                ltshowurl.Text = "";
            }
            // }
            //catch (Exception) { }
        }

        private void btn_link_cancel_Click(object sender, EventArgs e)
        {
            this.pn_list.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.hd_insertupdate.Value = "";
            this.pn_list.Visible = true;
            this.pn_insert.Visible = false;
            txtImage.Text = "";
            hdimgnews.Value = "";
            ltimgs.Text = "";
            this.hdFileName.Value = "";

            this.txtcontent.Text = "";
            this.lblmsg.Text = "";
            txttitleseo.Text = "";
            txtmeta.Text = "";
            txtKeyword.Text = "";
            hidLevel.Value = "";
            lbl_curpage.Text = "";
            hidLevel.Value = "";
            txtRewriteUrl.Text = "";
            ltshowurl.Text = "";
        }

        protected void Delete_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Xóa bài viết này ?')";
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            //this.lt_info.Text = " - " + this.label("l_createnew");
            this.pn_list.Visible = false;
            this.pn_insert.Visible = true;
            this.hd_insertupdate.Value = "insert";
            this.hd_page_edit_id.Value = "-1";
            txtImage.Text = "";
            hdimgnews.Value = "";
            ltimgs.Text = "";
            this.hdFileName.Value = "";

            this.txtcontent.Text = "";
            this.lblmsg.Text = "";
            this.txt_title.Text = "";
            hidLevel.Value = "";
            txtRewriteUrl.Text = "";
            ltshowurl.Text = "";
            if (hd_id.Value.Equals(""))
            {
                this.txt_order.Text = More.GetNextCateOrder(More.AB, this.lang, "-1").ToString();
            }
            else
            {
                this.txt_order.Text = More.GetNextCateOrder(More.AB, this.lang, hd_id.Value).ToString();
            }
            this.chknews.Checked = false;
            this.chkTrangChu.Checked = false;
        }

        protected void rp_pagelist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string str = e.CommandName.Trim();
            string str2 = e.CommandArgument.ToString().Trim();
            string str4 = str;

            switch (e.CommandName)
            {
                #region EditDetail
                case "EditDetail":
                    List<Entity.Menu> table = SMenu.GETBYID(str2);
                    if (table.Count > 0)
                    {
                        int _cid1 = -1;
                        if (int.TryParse(str2, out _cid1))
                        {
                            string nva1 = "";
                            this.lbl_curpage.Text = More.LoadNav(_cid1, ref nva1);
                        }

                        hidLevel.Value = table[0].Level.Substring(0, table[0].Level.Length - 5);
                        this.pn_list.Visible = false;
                        this.pn_insert.Visible = true;
                        this.hd_insertupdate.Value = "update";
                        this.hd_page_edit_id.Value = str2.Trim();
                        if (table.Count > 0)
                        {
                            hd_id.Value = table[0].Parent_ID.ToString().Trim();
                            this.hd_par_id.Value = table[0].Parent_ID.ToString().Trim();
                            this.hdid.Value = table[0].ID.ToString().Trim();
                            this.txt_title.Text = table[0].Name.ToString().Trim();
                            this.txt_order.Text = table[0].Orders.ToString().Trim();
                            this.txtcontent.Text = table[0].Description.ToString().Trim();
                            txtRewriteUrl.Text = table[0].TangName;

                            string ssl = "http://" + Request.Url.Host + "/";
                            if (Commond.Setting("SSL").Equals("1"))
                            {
                                ssl = "https://" + Request.Url.Host + "/";
                            }
                            ltshowurl.Text = ssl + table[0].TangName + ".html";
                            #region Seowwebsite
                            txttitleseo.Text = table[0].Titleseo.ToString().Trim();
                            txtmeta.Text = table[0].Meta.ToString().Trim();
                            txtKeyword.Text = table[0].Keyword.ToString().Trim();
                            #endregion

                            txtImage.Text = table[0].Images;
                            ltimgs.Text = MoreImage.Image(table[0].Images);
                            hdimgnews.Value = table[0].Images;

                            hdFileName.Value = table[0].Images.ToString();
                            if (table[0].Status.ToString().Trim().Equals("0"))
                            {
                                this.chck_Enable.Checked = false;
                            }
                            else if (table[0].Status.ToString().Equals("1"))
                            {
                                this.chck_Enable.Checked = true;
                            }
                            this.chck_Enable.Checked = true;


                            if (table[0].News.ToString().Trim().Equals("0"))
                            {
                                this.chknews.Checked = false;
                            }
                            else if (table[0].News.ToString().Equals("1"))
                            {
                                this.chknews.Checked = true;
                            }
                            this.chknews.Checked = true;


                            if (table[0].page_Home.ToString().Trim().Equals("0"))
                            {
                                this.chkTrangChu.Checked = false;
                            }
                            else if (table[0].page_Home.ToString().Equals("1"))
                            {
                                this.chkTrangChu.Checked = true;
                            }
                            this.chkTrangChu.Checked = true;



                        }
                    }
                    return;
                #endregion
                case "Delete":
                    {
                        try
                        {
                            List<Entity.Album> dtdetail = SAlbum.Name_Text("select * from Album where Menu_ID in(" + More.Sub_Menu(More.AB, str2) + ") ");
                            if (dtdetail.Count <= 0)
                            {

                                SMenu.DELETE(More.Sub_Menu(More.AB, str2));
                                SMenu.DELETE(str2);
                                this.LoadItems();
                                this.ltmsg.Text = "";
                                base.Response.Redirect(base.Request.Url.ToString().Trim());
                            }
                            else
                            {
                                //Response.Write("<script type=\"text/javascript\">alert('Xóa danh sách bài viết trước khi xóa nhóm');</script>");
                                this.ltmsg.Text = "<span class=alert>Xóa danh sách bài viết trước khi xóa nhóm</span>";
                            }
                        }
                        catch (Exception)
                        {
                            //Response.Write("<script type=\"text/javascript\">alert('Xóa danh sách bài viết trước khi xóa nhóm');</script>");
                            this.ltmsg.Text = "<span class=alert>Xóa danh sách bài viết trước khi xóa nhóm</span>";
                        }
                    }
                    return;
                case "ListChildren":
                    this.hd_id.Value = str2;
                    var itemAdd = SMenu.Detail(str2);
                    hidLevel.Value = itemAdd[0].Level;
                    int _cid = -1;
                    if (int.TryParse(str2, out _cid))
                    {
                        string nva = "";
                        this.lbl_curpage.Text = More.LoadNav(_cid, ref nva);
                    }
                    if (hd_id.Value.Equals(""))
                    {
                        this.txt_order.Text = More.GetNextCateOrder(More.AB, this.lang, "-1").ToString();
                    }
                    else
                    {
                        this.txt_order.Text = More.GetNextCateOrder(More.AB, this.lang, hd_id.Value).ToString();
                    }
                    this.pn_list.Visible = false;
                    this.pn_insert.Visible = true;
                    this.hd_insertupdate.Value = "insert";
                    this.hd_page_edit_id.Value = "-1";
                    return;
                case "ChangeStatus":
                    string str3;
                    str2 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                    if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                    { str3 = "0"; }
                    else { str3 = "1"; }
                    SMenu.UPDATESTATUS(str2, str3);
                    this.LoadItems();
                    return;
                case "News":
                    {
                        string str33;
                        str2 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                        if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                        { str33 = "0"; }
                        else { str33 = "1"; }
                        SMenu.Updatemenu(str2, "News", str33);
                        this.LoadItems();
                    }
                    return;
                case "page_Home":
                    {
                        string str344;
                        str2 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                        if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                        { str344 = "0"; }
                        else { str344 = "1"; }
                        SMenu.Updatemenu(str2, "page_Home", str344);
                        this.LoadItems();
                    }
                    return;
                case "Tang":
                    SMenu.UPDATEVIEWS_T(str2);
                    this.LoadItems();
                    return;
                case "Giam":
                    SMenu.UPDATEVIEWS_G(str2);
                    this.LoadItems();
                    return;
            }
        }

        //private void LoadItems()
        //{
        //    try
        //    {
        //        if (this.hd_id.Value.Equals(""))
        //        {
        //            this.hd_id.Value = "-1";
        //        }
        //        // List<Entity.Menu> table = SMenu.CATE_LOADALL_NEWS(More.AB, this.lang, this.hd_id.Value.Trim());
        //        List<Entity.Menu> table = SMenu.Name_Text("SELECT * FROM Menu where capp='" + More.AB + "' and lang='" + lang + "' order by level,Orders asc");
        //        CollectionPager1.DataSource = table;
        //        CollectionPager1.BindToControl = rp_pagelist;
        //        CollectionPager1.MaxPages = 10000;
        //        CollectionPager1.PageSize = int.Parse(ddlPage.SelectedValue);
        //        rp_pagelist.DataSource = CollectionPager1.DataSourcePaged;
        //        rp_pagelist.DataBind();

        //        RemoveCache.Menu();
        //        RemoveCache.Album();
        //        if (this.hd_id.Value.Equals("-1"))
        //        {
        //            this.lbl_curpage.Text = this.label("l_rootcate");
        //        }
        //        else
        //        {
        //            List<Entity.Menu> str = SMenu.Detail(this.hd_id.Value.Trim());
        //            if (str.Count > 0)
        //            {
        //                //  this.lbl_curpage.Text = this.label("l_rootcate") + " : " + str[0].Name.ToString().Trim();
        //                this.hd_par_id.Value = str[0].Parent_ID.ToString().Trim();
        //            }
        //        }
        //    }
        //    catch (Exception) { }
        //}

        public void LoadItems()
        {
            int Tongsobanghi = 0;
            Int16 pages = 1;
            int Tongsotrang = int.Parse(ddlPage.SelectedValue);

            if ((Request.QueryString["page"] != null) && (Request.QueryString["page"] != ""))
            {
                pages = Convert.ToInt16(Request.QueryString["page"].Trim());
            }
            List<Entity.Menu> dt = SMenu.CATEGORY_PHANTRANG(More.AB, (pages - 1), ref Tongsobanghi, Tongsotrang);
            rp_pagelist.DataSource = dt;
            rp_pagelist.DataBind();
            if (Tongsobanghi % Tongsotrang > 0)
            {
                Tongsobanghi = (Tongsobanghi / Tongsotrang) + 1;
            }
            else
            {
                Tongsobanghi = Tongsobanghi / Tongsotrang;
            }
            ltpage.Text = Commond.PhantrangAdmin("/admin.aspx?u=Album&su=Album", Tongsobanghi, pages);

            if (this.hd_id.Value.Equals(""))
            {
                this.hd_id.Value = "-1";
            }
            if (this.hd_id.Value.Equals("-1"))
            {
                this.lbl_curpage.Text = "Phân mục gốc";
            }
            else
            {
                List<Entity.Menu> str = SMenu.Detail(this.hd_id.Value.Trim());
                if (str.Count > 0)
                {
                    this.hd_par_id.Value = str[0].Parent_ID.ToString().Trim();
                }
            }
            RemoveCache.Menu();
            RemoveCache.Album();
        }

        protected void btxoa_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < rp_pagelist.Items.Count; i++)
                {
                    CheckBox chk = (CheckBox)rp_pagelist.Items[i].FindControl("chkid");
                    HiddenField id = (HiddenField)rp_pagelist.Items[i].FindControl("hiID");
                    if (chk.Checked)
                    {
                        List<Entity.Album> dtdetail = SAlbum.Name_Text("select * from Album where Menu_ID in(" + More.Sub_Menu(More.AB, id.Value) + ") ");
                        if (dtdetail.Count <= 0)
                        {

                            SMenu.DELETE_PARENT(More.Sub_Menu(More.AB, id.Value));
                            SMenu.DELETE(id.Value);
                        }
                        else
                        {
                            Response.Write("<script type=\"text/javascript\">alert('Xóa danh sách bài viết trước khi xóa nhóm');</script>");
                            this.ltmsg.Text = "<span class=alert>Xóa danh sách bài viết trước khi xóa nhóm</span>";
                        }

                    }
                }
                LoadItems();
                base.Response.Redirect(base.Request.Url.ToString().Trim());
            }
            catch (Exception)
            {
                this.ltmsg.Text = "<span class=alert>Xóa danh sách bài viết trước khi xóa nhóm</span>";
            }
        }



        protected void btthemmoi_Click(object sender, EventArgs e)
        {
            this.pn_list.Visible = false;
            this.pn_insert.Visible = true;
            this.hd_insertupdate.Value = "insert";
            this.hd_page_edit_id.Value = "-1";
            txtImage.Text = "";
            hdimgnews.Value = "";
            ltimgs.Text = "";
            this.hdFileName.Value = "";

            this.txtcontent.Text = "";
            this.lblmsg.Text = "";
            this.chknews.Checked = false;
            this.chkTrangChu.Checked = false;
            hidLevel.Value = "";
            txtRewriteUrl.Text = "";
            ltshowurl.Text = "";
            if (hd_id.Value.Equals(""))
            {
                this.txt_order.Text = More.GetNextCateOrder(More.AB, this.lang, "-1").ToString();
            }
            else
            {
                this.txt_order.Text = More.GetNextCateOrder(More.AB, this.lang, hd_id.Value).ToString();
            }
        }
        //protected void txtOrders_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox Orders = (TextBox)sender;
        //    var b = (HiddenField)Orders.FindControl("hiID");
        //    SMenu.Name_Text("UPDATE [Menu] SET Orders=" + Orders.Text + " WHERE ID=" + b.Value + " and capp='" + More.AB + "'");
        //    LoadItems();
        //    this.ltmsg.Text = "<span class=alert>Cập nhật thứ tự thành công.</span>";
        //}
        protected void txtTennhom_TextChanged(object sender, EventArgs e)
        {
            TextBox Nhom = (TextBox)sender;
            var b = (HiddenField)Nhom.FindControl("hiID");
            #region UpdateMenu
            string TagName = "";
            List<Entity.Menu> item = SMenu.GETBYID(b.Value);
            if (Nhom.Text.Length > 0)
            {
                if (item.Count > 0)
                {
                    Menu obk = db.Menus.SingleOrDefault(p => p.TangName == item[0].TangName);
                    if (obk != null)
                    {
                        obk.Name = Nhom.Text;
                        obk.Module = 5;
                        List<Menu> list = (from p in db.Menus where p.TangName == obk.TangName orderby p.ID descending select p).ToList();
                        if (list.Count > 2)
                        {
                            var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(Nhom.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(Nhom.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(Nhom.Text);
                        }
                        else
                        {
                            if (MoreAll.AddURL.SeoURL(item[0].Name) != MoreAll.AddURL.SeoURL(Nhom.Text)) { var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(Nhom.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(Nhom.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(Nhom.Text); } else { TagName = item[0].TangName; }
                        }
                        obk.TangName = TagName;
                        db.SubmitChanges();
                    }
                    else
                    {
                        if (MoreAll.AddURL.SeoURL(item[0].TangName) != MoreAll.AddURL.SeoURL(Nhom.Text))
                        {
                            var hasTagName = db.ModulControls.Where(s => s.TangName == MoreAll.AddURL.SeoURL(Nhom.Text)).FirstOrDefault();
                            TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(Nhom.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(Nhom.Text);
                        }
                        else
                        {
                            TagName = item[0].TangName;
                        }
                        Menu obl = db.Menus.SingleOrDefault(p => p.ID == int.Parse(b.Value));
                        obl.Name = Nhom.Text;
                        obl.TangName = TagName;
                        db.SubmitChanges();
                    }
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

        protected void rp_pagelist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DropDownList ddlCap = (e.Item.FindControl("ddlCap") as DropDownList);
                Label lblLevel = (e.Item.FindControl("lblLevel") as Label);

                List<Entity.Menu> list = SMenu.Name_Text("SELECT * FROM Menu where capp='" + More.AB + "' and lang='" + lang + "' order by level,Orders asc");
                ddlCap.Items.Add(new ListItem("===Chọn cấp cha===", "-1"));
                for (int i = 0; i < list.Count; i++)
                {
                    string space = "";
                    for (int j = 0; j < list[i].Level.Length / 5 - 1; j++) space += "-----";
                    ddlCap.Items.Add(new ListItem(space + list[i].Name, list[i].Level));
                }
                if (lblLevel.Text.Length == 5)
                {
                    ddlCap.Items.Add(new ListItem("=== Chọn cấp cha ===", "-1"));
                }
                else
                {
                    string lecha = lblLevel.Text.Substring(0, lblLevel.Text.Length - 5);
                    ddlCap.SelectedValue = lecha;
                }
                list.Clear();
                list = null;
            }
        }
        protected void ddlCaps_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList ddlCap = (DropDownList)sender;
                var b = (HiddenField)ddlCap.FindControl("hiID");
                var a = ddlCap.Parent;
                List<Entity.Menu> list = SMenu.Detail(b.Value);
                var strlv1 = list[0].Level;
                var srtlv2 = ddlCap.SelectedValue;
                string sss = More.Level_ID(ddlCap.SelectedValue, More.AB);
                if (strlv1.Length < srtlv2.Length && strlv1 == srtlv2.Substring(0, strlv1.Length))
                {
                    ltmsg.Text = "Không thể chọn cấp con làm cha !!";
                    LoadItems();
                }
                else if (b.Value == sss)
                {
                    ltmsg.Text = "Không thể chọn cấp con làm cha !!";
                    LoadItems();
                }
                else
                {
                    if (list.Count > 0)
                    {
                        List<Entity.Menu> ab = SMenu.Name_Text("SELECT * FROM Menu where capp='" + More.AB + "' and Level='" + ddlCap.SelectedValue + "' and lang='" + lang + "' order by level,Orders asc");
                        {
                            try
                            {
                                Menu abc = db.Menus.SingleOrDefault(p => p.ID == int.Parse(b.Value));
                                abc.ID = int.Parse(b.Value);
                                abc.Parent_ID = Convert.ToInt16(ab[0].ID.ToString());
                                abc.capp = More.AB;
                                abc.Level = ddlCap.SelectedValue + "00000";
                                db.SubmitChanges();
                            }
                            catch (Exception)
                            {
                                Menu abc = db.Menus.SingleOrDefault(p => p.ID == int.Parse(b.Value));
                                abc.ID = int.Parse(b.Value);
                                abc.Parent_ID = Convert.ToInt16("-1");
                                abc.capp = More.AB;
                                abc.Level = "00000";
                                db.SubmitChanges();
                            }
                        }
                    }
                    LoadItems();
                    ltmsg.Text = "Cập nhật cấp nhóm thành công !!";
                }
            }
            catch (Exception)
            {
                ltmsg.Text = "Không thể chọn cấp con làm cha !!";
            }
        }

        protected void btkiemtra_Click(object sender, EventArgs e)
        {
            string ssl = "http://" + Request.Url.Host + "/";
            if (MoreAll.Other.Giatri("SSL").Equals("1"))
            {
                ssl = "https://" + Request.Url.Host + "/";
            }
            if (hd_insertupdate.Value.Equals("insert"))
            {
                #region RewriteUrl
                int cong = 0;
                string TangName = "";
                if (txtRewriteUrl.Text.Length > 0)
                {
                    #region InsertMenu
                    List<Entity.Menu> curItem = SMenu.Name_Text("SELECT top 1 * FROM Menu order by ID desc");
                    int tong = int.Parse(curItem[0].ID.ToString()); cong = tong + 1; var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)).FirstOrDefault(); TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtRewriteUrl.Text) + "-" + cong : MoreAll.AddURL.SeoURL(txtRewriteUrl.Text);
                    #endregion
                }
                else
                {
                    #region InsertMenu
                    List<Entity.Menu> curItem = SMenu.Name_Text("SELECT top 1 * FROM Menu order by ID desc");
                    int tong = int.Parse(curItem[0].ID.ToString()); cong = tong + 1; var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txt_title.Text)).FirstOrDefault(); TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(txt_title.Text) + "-" + cong : MoreAll.AddURL.SeoURL(txt_title.Text);
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
                    List<Entity.Menu> item = SMenu.GETBYID(hd_page_edit_id.Value);
                    if (item.Count > 0)
                    {
                        Menu obk = db.Menus.SingleOrDefault(p => p.TangName == item[0].TangName);
                        obk.Name = txtRewriteUrl.Text;
                        obk.Module = 5;
                        List<Menu> list = (from p in db.Menus where p.TangName == obk.TangName orderby p.ID descending select p).ToList();
                        if (list.Count > 2)
                        {
                            var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtRewriteUrl.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(txtRewriteUrl.Text);
                        }
                        else
                        {
                            if (MoreAll.AddURL.SeoURL(item[0].TangName) != MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)) { var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtRewriteUrl.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(txtRewriteUrl.Text); } else { TagName = item[0].TangName; }
                        }
                    }
                    #endregion
                }
                else
                {
                    #region UpdateMenu
                    List<Entity.Menu> item = SMenu.GETBYID(hd_page_edit_id.Value);
                    if (item.Count > 0)
                    {
                        Menu obk = db.Menus.SingleOrDefault(p => p.TangName == item[0].TangName);
                        obk.Name = txt_title.Text;
                        obk.Module = 5;
                        List<Menu> list = (from p in db.Menus where p.TangName == obk.TangName orderby p.ID descending select p).ToList();
                        if (list.Count > 2)
                        {
                            var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txt_title.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txt_title.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(txt_title.Text);
                        }
                        else
                        {
                            if (MoreAll.AddURL.SeoURL(item[0].TangName) != MoreAll.AddURL.SeoURL(txt_title.Text)) { var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txt_title.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txt_title.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(txt_title.Text); } else { TagName = item[0].TangName; }
                        }
                    }
                    #endregion
                }
                ltshowurl.Text = ssl + TagName + ".html";
                #endregion
            }
        }

        protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            MoreAll.MoreAll.Update_setting("PageCateAlbum", ddlPage.SelectedValue);
            Response.Redirect(Request.RawUrl.ToString());
        }
        protected void bntcapnhat_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rp_pagelist.Items.Count; i++)
            {
                TextBox txtOrders = (TextBox)rp_pagelist.Items[i].FindControl("txtOrders");
                TextBox txtTennhom = (TextBox)rp_pagelist.Items[i].FindControl("txtTennhom");
                HiddenField id = (HiddenField)rp_pagelist.Items[i].FindControl("hiID");
                // Cập nhật thứ tự
                if (txtOrders.Text != "" && txtOrders.Text != "0")
                {
                    SMenu.Name_Text("UPDATE [Menu] SET Orders=" + txtOrders.Text + " WHERE ID=" + id.Value + " and capp='" + More.AB + "'");
                    ltmsg.Text = "<span class=alert>Cập nhật thành công !!</span>";
                }

            }
            LoadItems();
        }
    }
}