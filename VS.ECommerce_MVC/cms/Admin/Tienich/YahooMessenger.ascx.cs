using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Services;

namespace VS.ECommerce_MVC.cms.Admin.Tienich
{
    public partial class YahooMessenger : System.Web.UI.UserControl
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
            if (!base.IsPostBack)
            {
                this.UpdateList();
            }
        }

        protected void btn_InsertUpdate_Click(object sender, EventArgs e)
        {
            if (this.txttitle.Text.Trim().Length < 1)
            {
                this.lblmsg.Text = "Xin vui lòng kiểm tra dữ liệu đầu vào của bạn!";
            }
            else if (!ValidateUtilities.IsValidInt(this.txt_order.Text.Trim()))
            {
                this.lblmsg.Text = "Xin vui lòng kiểm tra dữ liệu đầu vào của bạn!";
            }
            else
            {
                Entity.YahooMessenger obj = new Entity.YahooMessenger();
                string str2 = this.hd_insertupdate.Value.Trim();
                if (str2 != null)
                {
                    if (!(str2 == "update"))
                    {
                        if (str2 == "insert")
                        {
                            #region MyRegion
                            obj.Type = int.Parse(ddltype.SelectedValue);
                            obj.Title = txttitle.Text;
                            obj.Nick = txtname.Text;
                            obj.Skype = txtSkype.Text;
                            obj.Phone = txtphone.Text;
                            obj.Email = txtEmail.Text;
                            obj.Size = int.Parse(ddlsize.SelectedValue);
                            obj.Orders = int.Parse(txt_order.Text);
                            obj.lang = lang;
                            obj.Status = int.Parse(chck_Enable.Checked ? "1" : "0");
                            #endregion
                            SYahoo.INSERT(obj);
                        }
                    }
                    else
                    {
                        #region MyRegion
                        obj.inick = int.Parse(hd_page_edit_id.Value);
                        obj.Type = int.Parse(ddltype.SelectedValue);
                        obj.Title = txttitle.Text;
                        obj.Nick = txtname.Text;
                        obj.Skype = txtSkype.Text;
                        obj.Phone = txtphone.Text;
                        obj.Email = txtEmail.Text;
                        obj.Size = int.Parse(ddlsize.SelectedValue);
                        obj.Orders = int.Parse(txt_order.Text);
                        obj.lang = lang;
                        obj.Status = int.Parse(chck_Enable.Checked ? "1" : "0");
                        #endregion
                        SYahoo.UPDATE(obj);
                    }
                }
                this.UpdateList();
                this.pn_list.Visible = true;
                this.pn_insert.Visible = false;
                this.hd_insertupdate.Value = "";
                this.txttitle.Text = "";
                this.txt_order.Text = "";
                txtphone.Text = "";
                txtphone.Text = "";
                txtSkype.Text = "";
                txtEmail.Text = "";
            }
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
        }

        protected void Delete_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Xóa thông tin vừa chọn ?')";
        }

        private void InitializeComponent()
        {
            this.rp_pagelist.ItemCommand += new RepeaterCommandEventHandler(this.rp_pagelist_ItemCommand);
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }
        protected void btthemmoi_Click(object sender, EventArgs e)
        {
            this.pn_list.Visible = false;
            this.pn_insert.Visible = true;
            this.hd_insertupdate.Value = "insert";
            this.txtname.Text = "";
            this.txttitle.Text = "";
            this.txt_order.Text = "";
            txtphone.Text = "";
            txtSkype.Text = "";
            txtEmail.Text = "";
        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            this.pn_list.Visible = false;
            this.pn_insert.Visible = true;
            this.hd_insertupdate.Value = "insert";
            this.txtname.Text = "";
            this.txttitle.Text = "";
            this.txt_order.Text = "";
            txtphone.Text = "";
            txtSkype.Text = "";
            txtEmail.Text = "";
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        protected void rp_pagelist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string str = e.CommandName.Trim();
            string str2 = e.CommandArgument.ToString().Trim();
            string str4 = str;
            if (str4 != null)
            {
                if (!(str4 == "EditDetail"))
                {
                    if (!(str4 == "ListChildren"))
                    {
                        string str3;
                        if (!(str4 == "ChangeStatus"))
                        {
                            if (!(str4 == "InsertNew"))
                            {
                                if (str4 == "Delete")
                                {
                                    try
                                    {
                                        SYahoo.DELETE(str2);
                                        this.UpdateList();
                                        // this.ltmsg.Text = "";
                                    }
                                    catch (Exception) { }
                                }
                                return;
                            }
                            return;
                        }
                        str2 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                        if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                        {
                            str3 = "0";
                        }
                        else
                        {
                            str3 = "1";
                        }
                        SYahoo.CATE_UPDATE(str2, str3);
                        this.UpdateList();
                        return;
                    }
                }
                else
                {
                    this.btn_InsertUpdate.Text = "Cập nhật";
                    this.pn_list.Visible = false;
                    this.pn_insert.Visible = true;
                    this.hd_insertupdate.Value = "update";
                    this.hd_page_edit_id.Value = str2.Trim();
                    List<Entity.YahooMessenger> table = SYahoo.GET_BY_ID(str2);
                    if (table.Count > 0)
                    {
                        WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddltype, table[0].Type.ToString());
                        this.txttitle.Text = table[0].Title.ToString().Trim();
                        this.txt_order.Text = table[0].Orders.ToString().Trim();
                        this.txtname.Text = table[0].Nick.ToString().Trim();
                        this.txtphone.Text = table[0].Phone.ToString().Trim();
                        txtSkype.Text = table[0].Skype.ToString().Trim();
                        txtEmail.Text = table[0].Email.ToString().Trim();
                        WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlsize, table[0].Size.ToString());
                        if (table[0].Status.ToString().Trim().Equals("0"))
                        {
                            this.chck_Enable.Checked = false;
                            return;
                        }
                        if (!table[0].Status.ToString().Equals("1"))
                        {
                            return;
                        }
                        this.chck_Enable.Checked = true;
                    }
                    return;
                }
                this.hd_id.Value = str2;
                this.UpdateList();
            }
        }

        private void SetSelectedIndexInDropDownList(ref DropDownList ddl, string selectedvalue)
        {
            if (ddl != null)
            {
                selectedvalue = selectedvalue.Trim();
                int count = ddl.Items.Count;
                for (int i = 0; i < count; i++)
                {
                    if (ddl.Items[i].Value.Equals(selectedvalue))
                    {
                        ddl.SelectedIndex = i;
                        return;
                    }
                }
            }
        }

        private void UpdateList()
        {
            List<Entity.YahooMessenger> table = SYahoo.GET_BY_ALL(lang);
            this.rp_pagelist.DataSource = table;
            this.rp_pagelist.DataBind();
        }
        public static string Enable(string enable)
        {
            if (enable.Trim().Equals("1"))
            {
                return "Zalo";
            }
            else if (enable.Trim().Equals("2"))
            {
                return "Skype";
            }
            else if (enable.Trim().Equals("3"))
            {
                return "Facebook";
            }
            else if (enable.Trim().Equals("4"))
            {
                return "Viber";
            }
            return "";
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
                        SYahoo.DELETE(id.Value);
                    }
                }
                UpdateList();
            }
            catch (Exception) { }
        }
    }
}