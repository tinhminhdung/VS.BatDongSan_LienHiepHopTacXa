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
using FlexCel.XlsAdapter;

namespace VS.ECommerce_MVC.cms.Admin.Redirect301
{
    public partial class StatusCode : System.Web.UI.UserControl
    {
        private string lang = Captionlanguage.Language;
        DatalinqDataContext db = new DatalinqDataContext();
        string ssl = "http://";
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
                if (Commond.Setting("SSL").Equals("1"))
                {
                    ssl = "https://";
                }
                ltluy.Text += ssl + Request.Url.Host;
                #region UpdatePanel
                this.Page.Form.Enctype = "multipart/form-data";
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(btn_InsertUpdate);
                #endregion
                this.ShowList();
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
                            #region MyRegion
                            obj.Parent_ID = Convert.ToInt16(this.hd_id.Value.Trim());
                            obj.capp = More.SC;
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
                            obj.Module = 50;
                            obj.TangName = "";
                            #endregion
                            SMenu.Insert(obj);
                        }
                    }
                    else
                    {

                        #region MyRegion
                        obj.ID = Convert.ToInt16(hd_page_edit_id.Value);
                        obj.Parent_ID = Convert.ToInt16(this.hd_id.Value.Trim());
                        obj.capp = More.SC;
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
                        obj.Module = 50;
                        obj.TangName = "";
                        #endregion
                        SMenu.UPDATE(obj);
                    }
                }
                this.ShowList();
                this.pn_list.Visible = true;
                this.pn_insert.Visible = false;
                this.hd_insertupdate.Value = "";
                this.txt_title.Text = "";
                this.hd_insertupdate.Value = "insert";
                this.hd_id.Value = "-1";
                this.hdFileName.Value = "";
                txtImage.Text = "";
                hdimgnews.Value = "";
                ltimgs.Text = "";
                this.txtcontent.Text = "";
                txttitleseo.Text = "";
                txtmeta.Text = "";
                txtKeyword.Text = "";

                this.lblmsg.Text = "";
                this.lbl_curpage.Text = "";
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
            this.hdFileName.Value = "";
            txtImage.Text = "";
            hdimgnews.Value = "";
            ltimgs.Text = "";
            this.txtcontent.Text = "";
            this.lblmsg.Text = "";
            txttitleseo.Text = "";
            txtmeta.Text = "";
            txtKeyword.Text = "";
            hidLevel.Value = "";
            lbl_curpage.Text = "";

            hidLevel.Value = "";
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
            hidLevel.Value = "";
            if (hd_id.Value.Equals(""))
            {
                this.txt_order.Text = More.GetNextCateOrder(More.SC, this.lang, "-1").ToString();
            }
            else
            {
                this.txt_order.Text = More.GetNextCateOrder(More.SC, this.lang, hd_id.Value).ToString();
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

                            #region Seowwebsite

                            txttitleseo.Text = table[0].Titleseo.ToString().Trim();
                            txtmeta.Text = table[0].Meta.ToString().Trim();
                            txtKeyword.Text = table[0].Keyword.ToString().Trim();
                            #endregion

                            txtImage.Text = table[0].Images;
                            ltimgs.Text = MoreImage.Image(table[0].Images);
                            hdimgnews.Value = table[0].Images;
                            hdFileName.Value = table[0].Images.ToString();
                            chck_Enable.Checked = (table[0].Status == 1);
                            chknews.Checked = (table[0].News == 1);
                            chkTrangChu.Checked = (table[0].page_Home == 1);

                        }
                    }
                    return;
                #endregion
                case "Delete":
                    List<News> dtdetail = SNews.Name_Text("SELECT * FROM [News] WHERE icid IN(" + More.Sub_Menu(More.SC, str2) + ") order by Create_Date desc");
                    if (dtdetail.Count <= 0)
                    {
                        SMenu.DELETE(More.Sub_Menu(More.SC, str2));
                        SMenu.DELETE(str2);
                        this.ShowList();
                        this.ltmsg.Text = "";
                    }
                    else
                    {
                        this.ltmsg.Text = "<span class=alert>Xóa danh sách bài viết trước khi xóa nhóm</span>";
                    }
                    this.ShowList();
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
                        this.txt_order.Text = More.GetNextCateOrder(More.SC, this.lang, "-1").ToString();
                    }
                    else
                    {
                        this.txt_order.Text = More.GetNextCateOrder(More.SC, this.lang, hd_id.Value).ToString();
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
                    this.ShowList();
                    return;
                case "News":
                    {
                        string str33;
                        str2 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                        if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                        { str33 = "0"; }
                        else { str33 = "1"; }
                        SMenu.Updatemenu(str2, "News", str33);
                        this.ShowList();
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
                        this.ShowList();
                    }
                    return;
                case "Tang":
                    SMenu.UPDATEVIEWS_T(str2);
                    this.ShowList();
                    return;
                case "Giam":
                    SMenu.UPDATEVIEWS_G(str2);
                    this.ShowList();
                    return;
            }
        }

        private void ShowList()
        {
            try
            {
                if (this.hd_id.Value.Equals(""))
                {
                    this.hd_id.Value = "-1";
                }
                // List<Entity.Menu> table = SMenu.CATE_LOADALL_NEWS(More.SC, this.lang, this.hd_id.Value.Trim());
                List<Entity.Menu> table = SMenu.Name_Text("SELECT * FROM Menu where capp='" + More.SC + "' and lang='" + lang + "' order by level,Orders asc");
                CollectionPager1.DataSource = table;
                CollectionPager1.BindToControl = rp_pagelist;
                CollectionPager1.MaxPages = 10000;
                CollectionPager1.PageSize = 20;
                rp_pagelist.DataSource = CollectionPager1.DataSourcePaged;
                rp_pagelist.DataBind();

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
                        List<News> dtdetail = SNews.Name_Text("SELECT * FROM [News] WHERE icid IN(" + More.Sub_Menu(More.SC, id.Value) + ") order by Create_Date desc");
                        if (dtdetail.Count <= 0)
                        {
                            SMenu.DELETE_PARENT(More.Sub_Menu(More.SC, id.Value));
                            SMenu.DELETE(id.Value);
                        }
                        else
                        {
                            this.ltmsg.Text = "<span class=alert>Xóa danh sách bài viết trước khi xóa nhóm</span>";
                        }
                    }
                }
                ShowList();
            }
            catch (Exception)
            {
                this.ltmsg.Text = "<span class=alert> Xóa thông tin trong phân mục này trước khi muốn xóa nó!</span>";
            }
        }


        protected void btthemmoi_Click(object sender, EventArgs e)
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
            this.chknews.Checked = false;
            this.chkTrangChu.Checked = false;
            hidLevel.Value = "";
            if (hd_id.Value.Equals(""))
            {
                this.txt_order.Text = More.GetNextCateOrder(More.SC, this.lang, "-1").ToString();
            }
            else
            {
                this.txt_order.Text = More.GetNextCateOrder(More.SC, this.lang, hd_id.Value).ToString();
            }
        }

        protected void txtOrders_TextChanged(object sender, EventArgs e)
        {
            TextBox Orders = (TextBox)sender;
            var b = (HiddenField)Orders.FindControl("hiID");
            SMenu.Name_Text("UPDATE [Menu] SET Orders=" + Orders.Text + " WHERE ID=" + b.Value + " and capp='" + More.SC + "'");
            ShowList();
            this.ltmsg.Text = "<span class=alert>Cập nhật thứ tự thành công.</span>";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string LinhCu = "";
            string LinkMoi = "";
            if (Request.Files.Count > 0)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFile file = Request.Files[i];
                    if (file.FileName != "")
                    {
                        if (file.FileName.Split('.')[1] == "xls" || file.FileName.Split('.')[1] == "xlsx")
                        {
                            file.SaveAs(Server.MapPath("uploads/excel/") + file.FileName);
                            XlsFile xls = new XlsFile(Server.MapPath("uploads/excel/") + file.FileName);
                            if (xls.GetSheetName(1) == "Sheet1")
                            {
                                xls.ActiveSheetByName = "Sheet1";
                                string regex = "[A-G]";
                                for (int row = 1; row <= xls.RowCount; row++)
                                {
                                    //   là 5 nhé//  for (int colIndex = 1; colIndex <= 5; colIndex++)
                                    for (int colIndex = 1; colIndex <= 2; colIndex++)
                                    {
                                        object cell = xls.GetCellValue(row, colIndex);
                                        switch (colIndex)
                                        {
                                            case 1:
                                                if (cell != null)
                                                    LinhCu = cell.ToString();
                                                break;
                                            case 2:
                                                if (cell != null)
                                                    LinkMoi = cell.ToString();
                                                break;
                                        }
                                    }
                                        //try
                                        // {
                                        List<Entity.Menu> abc = SMenu.Name_Text("SELECT * FROM Menu WHERE capp='sc' and Name like N'" + LinhCu + "' and Description like N'" + LinkMoi + "'");
                                        if (abc.Count > 0)
                                        {
                                            Entity.Menu obj = new Entity.Menu();
                                            obj.ID = int.Parse(abc[0].ID.ToString());
                                            obj.Parent_ID = 0;
                                            obj.capp = More.SC;
                                            obj.Type = 0;
                                            obj.Lang = lang;
                                            obj.Name = LinhCu;
                                            obj.Url_Name = LinhCu;
                                            obj.Link = "";
                                            obj.Styleshow = "";
                                            obj.Equals = 0;
                                            obj.Images = "";
                                            obj.Description = LinkMoi;
                                            obj.Create_Date = DateTime.Now;
                                            obj.Views = 0;
                                            obj.ShowID = 0;
                                            obj.Orders = 1;
                                            obj.Level = "00000";
                                            obj.News = 0;
                                            obj.page_Home = 0;
                                            obj.Status = 1;
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
                                            obj.Module = 50;
                                            obj.TangName = "";
                                            SMenu.UPDATE(obj);
                                        }
                                        else
                                        {
                                            if (LinhCu != "" && LinkMoi != "")
                                            {
                                                Entity.Menu obj = new Entity.Menu();
                                                obj.Parent_ID = 0;
                                                obj.capp = More.SC;
                                                obj.Type = 0;
                                                obj.Lang = lang;
                                                obj.Name = LinhCu;
                                                obj.Url_Name = LinhCu;
                                                obj.Link = "";
                                                obj.Styleshow = "";
                                                obj.Equals = 0;
                                                obj.Images = "";
                                                obj.Description = LinkMoi;
                                                obj.Create_Date = DateTime.Now;
                                                obj.Views = 0;
                                                obj.ShowID = 0;
                                                obj.Orders = 1;
                                                obj.Level = "00000";
                                                obj.News = 0;
                                                obj.page_Home = 0;
                                                obj.Status = 1;
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
                                                obj.Module = 50;
                                                obj.TangName = "";
                                                SMenu.Insert(obj);
                                            }
                                        }
                                        //}
                                        //catch (Exception)
                                        //{
                                        //}
                                }
                                ltmsg.Text = "Import thành công!";
                                ShowList();
                            }
                            else
                                ltmsg.Text = "File excel không đúng template!";
                        }
                        else
                            ltmsg.Text = "File upload không đúng định dạng!";
                    }
                    else
                        ltmsg.Text = "Không có file upload!'";
                }
            }

        }

    }
}