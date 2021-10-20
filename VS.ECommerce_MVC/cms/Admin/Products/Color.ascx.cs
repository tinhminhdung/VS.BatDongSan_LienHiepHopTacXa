using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using System.IO;
using Services;
using Entity;

namespace VS.ECommerce_MVC.cms.Admin.Products
{
    public partial class Color : System.Web.UI.UserControl
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
                this.UpdateList();
            }
        }

        protected void btn_InsertUpdate_Click(object sender, EventArgs e)
        {
            try
            {
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
                    int status = 0;
                    if (this.chck_Enable.Checked)
                    {
                        status = 1;
                    }
                    int news = 0;
                    if (this.chknews.Checked)
                    {
                        news = 1;
                    }
                    int TrangChu = 0;
                    if (this.chkTrangChu.Checked)
                    {
                        TrangChu = 1;
                    }
                    ServerInfoUtlitities utlitities = new ServerInfoUtlitities();


                    Entity.Menu obj = new Entity.Menu();
                    string str5 = this.hd_insertupdate.Value.Trim();
                    if (str5 != null)
                    {
                        if (!(str5 == "update"))
                        {
                            if (str5 == "insert")
                            {
                                #region Menu
                                string TangName = "";
                                int cong = 0;
                                List<Entity.ModulControls> curItem = SModulControls.Name_Text("SELECT top 1 * FROM ModulControls order by ID desc");
                                int tong = int.Parse(curItem[0].ID.ToString());
                                cong = tong + 1;
                                var hasTagName = db.ModulControls.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txt_title.Text)).FirstOrDefault();
                                TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(txt_title.Text) + "-" + cong : MoreAll.AddURL.SeoURL(txt_title.Text);

                                ModulControl obm = new ModulControl();
                                obm.Name = txt_title.Text;
                                obm.Module = 26;
                                obm.TangName = TangName;
                                db.ModulControls.InsertOnSubmit(obm);
                                db.SubmitChanges();

                                #endregion

                                // Insert danh mục sản phẩm
                                #region MyRegion
                                obj.Parent_ID = Convert.ToInt16(this.hd_id.Value.Trim());
                                obj.capp = More.CO;
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
                                //obj.Level =" 100";
                                obj.News = Convert.ToInt16(chknews.Checked ? "1" : "0");
                                obj.page_Home = Convert.ToInt16(chkTrangChu.Checked ? "1" : "0");
                                obj.Status = Convert.ToInt16(chck_Enable.Checked ? "1" : "0");
                                obj.Titleseo = "";
                                obj.Meta = "";
                                obj.Keyword = "";
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
                                obj.Module = 26;
                                obj.TangName = TangName;
                                #endregion
                                SMenu.Insert_NoLevel(obj);
                            }
                        }
                        else
                        {
                            string TagName = "";
                            #region UpdateMenu
                            List<Entity.Menu> item = SMenu.GETBYID(hd_page_edit_id.Value);
                            if (item.Count > 0)
                            {
                                ModulControl obk = db.ModulControls.SingleOrDefault(p => p.TangName == item[0].TangName);
                                obk.Name = txt_title.Text;
                                obk.Module = 26;
                                List<ModulControl> list = (from p in db.ModulControls where p.TangName == obk.TangName orderby p.ID descending select p).ToList();
                                if (list.Count > 2)
                                {
                                    var hasTagName = db.ModulControls.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txt_title.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txt_title.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(txt_title.Text);
                                }
                                else
                                {
                                    if (MoreAll.AddURL.SeoURL(item[0].TangName) != MoreAll.AddURL.SeoURL(txt_title.Text)) { var hasTagName = db.ModulControls.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txt_title.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txt_title.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(txt_title.Text); } else { TagName = item[0].TangName; }
                                }
                                obk.TangName = TagName;
                                db.SubmitChanges();
                            }
                            #endregion

                            #region MyRegion
                            obj.ID = Convert.ToInt16(hd_page_edit_id.Value);
                            obj.Parent_ID = Convert.ToInt16(this.hd_id.Value.Trim());
                            obj.capp = More.CO;
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
                            // obj.Level =" 100";
                            obj.News = Convert.ToInt16(chknews.Checked ? "1" : "0");
                            obj.page_Home = Convert.ToInt16(chkTrangChu.Checked ? "1" : "0");
                            obj.Status = Convert.ToInt16(chck_Enable.Checked ? "1" : "0");
                            obj.Titleseo = "";
                            obj.Meta = "";
                            obj.Keyword = "";
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
                            obj.Module = 26;
                            obj.TangName = TagName;
                            #endregion
                            SMenu.UPDATE_NoLevel(obj);
                        }
                    }
                    this.UpdateList();
                    this.pn_list.Visible = true;
                    this.pn_insert.Visible = false;
                    this.hd_insertupdate.Value = "";
                    this.txt_title.Text = "";
                    txtImage.Text = "";
                    hdimgnews.Value = "";
                    ltimgs.Text = "";
                    this.hdFileName.Value = "";
                    this.txtcontent.Text = "";
                    this.lblmsg.Text = "";
                }
            }
            catch (Exception) { }
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
            this.pn_list.Visible = false;
            this.pn_insert.Visible = true;
            this.hd_insertupdate.Value = "insert";
            this.hd_page_edit_id.Value = "-1";
            this.hdFileName.Value = "";
            txtImage.Text = "";
            hdimgnews.Value = "";
            ltimgs.Text = "";
            this.txtcontent.Text = "";
            this.lblmsg.Text = "";
            this.txt_title.Text = "";
            if (hd_id.Value.Equals(""))
            {
                this.txt_order.Text = More.GetNextCateOrder(More.CO, this.lang, "-1").ToString();
            }
            else
            {
                this.txt_order.Text = More.GetNextCateOrder(More.CO, this.lang, hd_id.Value).ToString();
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
                        this.btn_InsertUpdate.Text = "Cập nhật";
                        this.pn_list.Visible = false;
                        this.pn_insert.Visible = true;
                        this.hd_insertupdate.Value = "update";
                        this.hd_page_edit_id.Value = str2.Trim();
                        if (table.Count > 0)
                        {
                            this.hd_par_id.Value = table[0].Parent_ID.ToString().Trim();
                            this.hdid.Value = table[0].ID.ToString().Trim();
                            this.txt_title.Text = table[0].Name.ToString().Trim();
                            this.txt_order.Text = table[0].Orders.ToString().Trim();
                            this.txtcontent.Text = table[0].Description.ToString().Trim();

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
                        List<Entity.Menu> str5 = SMenu.GETBYID(e.CommandArgument.ToString());
                        if (str5.Count > 0)
                        {
                            try
                            {
                                SModulControls.Name_Text("DELETE FROM ModulControls WHERE TangName ='" + str5[0].TangName + "'");
                            }
                            catch (Exception)
                            { }
                        }
                        try
                        {
                            var dtdetail = db.Trunggians.Where(s => s.Icolor == int.Parse(str2) && s.Trangthai == 1).ToList();
                            if (dtdetail.Count <= 0)
                            {
                                SProduct_images.Cate_Delete_icid(More.Sub_Menu(More.CO, str2));
                                SProducts.Cate_Delete_icid(More.Sub_Menu(More.CO, str2));
                                SMenu.DELETE(More.Sub_Menu(More.CO, str2));
                                SMenu.DELETE(str2);
                                this.UpdateList();
                                this.ltmsg.Text = "";
                            }
                            else
                            {
                                this.ltmsg.Text = "<span class=alert>Không xóa được,Đang có sản phẩm liên quan</span>";
                            }
                        }
                        catch (Exception)
                        {
                            this.ltmsg.Text = "<span class=alert>Không xóa được,Đang có sản phẩm liên quan</span>";
                        }
                    }
                    return;
                case "ListChildren":
                    this.hd_id.Value = str2;
                    int _cid = -1;
                    if (int.TryParse(str2, out _cid))
                    {
                        string nva = "";
                        this.lbl_curpage.Text = More.LoadNav(_cid, ref nva);
                    }
                    this.UpdateList();
                    return;
                case "ChangeStatus":
                    string str3;
                    str2 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                    if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                    { str3 = "0"; }
                    else { str3 = "1"; }
                    SMenu.UPDATESTATUS(str2, str3);
                    this.UpdateList();
                    return;
                case "ChangeHome":
                    string str33;
                    str2 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                    if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                    { str33 = "0"; }
                    else { str33 = "1"; }
                    SMenu.UPDATESHOME(str2, str33);
                    this.UpdateList();
                    return;
                case "Tang":
                    SMenu.UPDATEVIEWS_T(str2);
                    this.UpdateList();
                    return;
                case "Giam":
                    SMenu.UPDATEVIEWS_G(str2);
                    this.UpdateList();
                    return;
            }
        }

        private void UpdateList()
        {
            try
            {
                if (this.hd_id.Value.Equals(""))
                {
                    this.hd_id.Value = "-1";
                }
                List<Entity.Menu> table = SMenu.CATE_LOADALL_NEWS(More.CO, this.lang, this.hd_id.Value.Trim());
                this.rp_pagelist.DataSource = table;
                this.rp_pagelist.DataBind();
                if (this.hd_id.Value.Equals("-1"))
                {
                    this.lbl_curpage.Text ="Phân mục gốc";
                }
                else
                {
                    List<Entity.Menu> str = SMenu.Detail(this.hd_id.Value.Trim());
                    if (str.Count > 0)
                    {
                        this.hd_par_id.Value = str[0].Parent_ID.ToString().Trim();
                    }
                }
            }
            catch (Exception) { }
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
                        var dtdetail = db.Trunggians.Where(s => s.Icolor == int.Parse(id.Value) && s.Trangthai == 1).ToList();
                        if (dtdetail.Count <= 0)
                        {
                            List<Entity.Menu> str5 = SMenu.GETBYID(id.Value);
                            if (str5.Count > 0)
                            {
                                try
                                {
                                    SModulControls.Name_Text("DELETE FROM ModulControls WHERE TangName ='" + str5[0].TangName + "'");
                                }
                                catch (Exception)
                                { }
                            }
                            SProduct_images.Cate_Delete_icid(More.Sub_Menu(More.CO, id.Value));
                            SProducts.Cate_Delete_icid(More.Sub_Menu(More.CO, id.Value));
                            SMenu.DELETE_PARENT(More.Sub_Menu(More.CO, id.Value));
                            SMenu.DELETE(id.Value);
                        }
                        else
                        {
                            this.ltmsg.Text = "<span class=alert>Không xóa được,Đang có sản phẩm liên quan</span>";
                        }
                        
                    }
                }
                UpdateList();
            }
            catch (Exception)
            {
                this.ltmsg.Text = "<span class=alert>Không xóa được,Đang có sản phẩm liên quan</span>";
            }
        }

        protected void btthemmoi_Click(object sender, EventArgs e)
        {
            this.pn_list.Visible = false;
            this.pn_insert.Visible = true;
            this.hd_insertupdate.Value = "insert";
            this.hd_page_edit_id.Value = "-1";
            this.hdFileName.Value = "";
            this.txtcontent.Text = "";
            this.lblmsg.Text = "";
            this.chknews.Checked = false;
            this.chkTrangChu.Checked = false;
            txtImage.Text = "";
            hdimgnews.Value = "";
            ltimgs.Text = "";
            if (hd_id.Value.Equals(""))
            {
                this.txt_order.Text = More.GetNextCateOrder(More.CO, this.lang, "-1").ToString();
            }
            else
            {
                this.txt_order.Text = More.GetNextCateOrder(More.CO, this.lang, hd_id.Value).ToString();
            }
        }


        protected void txtOrders_TextChanged(object sender, EventArgs e)
        {
            TextBox Orders = (TextBox)sender;
            var b = (HiddenField)Orders.FindControl("hiID");
            SMenu.Name_Text("UPDATE [Menu] SET Orders=" + Orders.Text + " WHERE ID=" + b.Value + " and capp='" + More.CO + "'");
            UpdateList();
            this.ltmsg.Text = "<span class=alert>Cập nhật thứ tự thành công.</span>";
        }
        protected void txtTennhom_TextChanged(object sender, EventArgs e)
        {
            TextBox Nhom = (TextBox)sender;
            var b = (HiddenField)Nhom.FindControl("hiID");
            if (Nhom.Text.Length > 0)
            {
                #region UpdateMenu
                string TagName = "";
                List<Entity.Menu> item = SMenu.GETBYID(b.Value);
                if (item.Count > 0)
                {
                    Menu iitem = db.Menus.SingleOrDefault(p => p.TangName == item[0].TangName);
                    ModulControl obk = db.ModulControls.SingleOrDefault(p => p.TangName == item[0].TangName);
                    obk.Name = Nhom.Text;
                    obk.Module = 26;
                    List<ModulControl> list = (from p in db.ModulControls where p.TangName == obk.TangName orderby p.ID descending select p).ToList();
                    if (list.Count > 2)
                    {
                        var hasTagName = db.ModulControls.Where(s => s.TangName == MoreAll.AddURL.SeoURL(Nhom.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(Nhom.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(Nhom.Text);
                    }
                    else
                    {
                        if (MoreAll.AddURL.SeoURL(item[0].Name) != MoreAll.AddURL.SeoURL(Nhom.Text)) { var hasTagName = db.ModulControls.Where(s => s.TangName == MoreAll.AddURL.SeoURL(Nhom.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(Nhom.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(Nhom.Text); } else { TagName = item[0].TangName; }
                    }
                    obk.TangName = TagName;
                    db.SubmitChanges();

                    iitem.Name = Nhom.Text;
                    iitem.Module = 26;
                    iitem.TangName = TagName;
                    db.SubmitChanges();
                    UpdateList();

                    UpdateList();
                    this.ltmsg.Text = "<span class=alert>Cập nhật tiêu đề thành công !!</span>";
                }
                #endregion
            }
            else
            {
                UpdateList();
                ltmsg.Text = "<span class=alert>Bạn chưa nhập tiêu đề !!</span>";
            }
        }
    }
}