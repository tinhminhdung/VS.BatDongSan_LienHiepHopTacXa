using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Entity;
using Services;
using System.Data;

namespace VS.ECommerce_MVC.cms.Admin.languages
{
    public partial class languages : System.Web.UI.UserControl
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
                List<Lans> str = new List<Lans>();
                str = SLang.ALL();
                this.rp_lans.DataSource = str;
                this.rp_lans.DataBind();
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            this.hd_insertnew.Value = "";
            this.pn_list.Visible = true;
            this.pn_detail.Visible = false;
            this.lt_info.Text = "";
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            if (((this.txt_showinvie.Text.Trim().Length >= 1) && (this.txt_name_inother.Text.Trim().Length >= 1)) && ValidateUtilities.IsValidInt(this.txt_order.Text.Trim()))
            {
                int locked = 0;
                if (this.chk_show.Checked)
                {
                    locked = 1;
                }
                int MacDinh = 0;
                if (this.chk_MacDinh.Checked)
                {
                    MacDinh = 1;
                }
                Lans obj = new Lans();
                #region MyRegion

                #endregion
                if (this.hd_insertnew.Value.Equals("Update"))
                {
                    obj.ilanid = int.Parse(this.id.Value.Trim());
                    obj.VLAN_ID = this.txt_name_inother.Text.Trim();
                    obj.VLAN_NAME = this.txt_showinvie.Text.Trim();
                    obj.VLAN_NAME_VIE = this.txt_showinvie.Text.Trim();
                    obj.ILAN_ORDER = int.Parse(this.txt_order.Text.Trim());
                    obj.ILAN_LOCKED = locked;
                    obj.MacDinh = MacDinh;
                    SLang.UPDATE(obj);
                }
                else
                {

                    obj.VLAN_ID = this.txt_name_inother.Text.Trim();
                    obj.VLAN_NAME = this.txt_showinvie.Text.Trim();
                    obj.VLAN_NAME_VIE = this.txt_showinvie.Text.Trim();
                    obj.ILAN_ORDER = int.Parse(this.txt_order.Text.Trim());
                    obj.ILAN_LOCKED = locked;
                    obj.MacDinh = MacDinh;
                    SLang.INSERT(obj);
                }
                this.hd_insertnew.Value = "";
                this.pn_detail.Visible = false;
                this.pn_list.Visible = true;
                this.txt_showinvie.Text = "";
                this.load_lang();
                this.lt_info.Text = "";
            }
        }

        protected void btncancelvalue_Click(object sender, EventArgs e)
        {
            this.MultiView1.ActiveViewIndex = 0;
        }

        protected void btnupdatevalue_Click(object sender, EventArgs e)
        {
            if (this.txtvalues.Text.Length < 1)
            {
                this.ltmsg.Text = "";
                this.ltmsg.Visible = true;
            }
            else
            {
                this.ltmsg.Visible = false;
                Captionlanguage.UpdateLanguageList(this.hdvalue.Value, this.hdlangid.Value, this.txtvalues.Text);
                this.LoadValue(this.hdlangid.Value);
                this.MultiView1.ActiveViewIndex = 0;
            }
        }

        protected void Delete_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Bạn chắc chắn là bạn muốn xóa ?')";
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void lnk_back_Click(object sender, EventArgs e)
        {
            this.pnvalue.Visible = false;
            this.pn_detail.Visible = false;
            this.pn_list.Visible = true;
        }

        protected void lnk_insertnewlanguage_Click(object sender, EventArgs e)
        {
            this.hd_insertnew.Value = "insert";
            this.pn_list.Visible = false;
            this.pn_detail.Visible = true;
            this.txt_shortname.Enabled = true;
        }

        private void load_lang()
        {
            this.rp_lans.DataSource = SLang.ALL();
            this.rp_lans.DataBind();
        }

        private void LoadValue(string lang)
        {
            DataTable table = Captionlanguage.LoadLanguageList_(lang);
            this.rpvalues.DataSource = table;
            this.rpvalues.DataBind();
        }

        protected void rp_lans_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string str = e.CommandName.Trim();
            string lang = e.CommandArgument.ToString();
            this.hdlangid.Value = lang;
            string str3 = str;
            if (str3 != null)
            {
                if (!(str3 == "Update"))
                {
                    if (!(str3 == "ValuesList"))
                    {
                        if (!(str3 == "Delete"))
                        {
                            if (!(str3 == "MacDinh"))
                            {
                                return;
                            }
                            string str33 = "";
                            string str2 = "";
                            str2 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                            if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                            { str33 = "0"; }
                            else { str33 = "1"; }
                            SLang.Name_Text("UPDATE [lans] SET MacDinh=" + str33 + " WHERE ilanid= " + str2 + "");
                            base.Response.Redirect(base.Request.Url.ToString());
                            return;
                        }
                        SLang.DELETE(lang);
                        base.Response.Redirect(base.Request.Url.ToString());
                        return;
                    }
                }
                else
                {
                    this.id.Value = lang;
                    this.pn_list.Visible = false;
                    this.pn_detail.Visible = true;
                    this.txt_shortname.Enabled = false;
                    List<Lans> table = SLang.GET_BY_ID(lang);
                    if (table.Count > 0)
                    {
                        WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.txt_shortname, table[0].VLAN_ID.ToString().Trim());
                        this.txt_showinvie.Text = table[0].VLAN_NAME_VIE.ToString().Trim();
                        this.txt_name_inother.Text = table[0].VLAN_NAME.ToString().Trim();
                        this.txt_order.Text = table[0].ILAN_ORDER.ToString().Trim();
                        if (table[0].ILAN_LOCKED.ToString().Trim().Equals("0"))
                        {
                            this.chk_show.Checked = false;
                        }
                        else if (table[0].ILAN_ORDER.ToString().Equals("1"))
                        {
                            this.chk_show.Checked = true;
                        }
                        if (table[0].MacDinh.ToString().Trim().Equals("0"))
                        {
                            this.chk_MacDinh.Checked = false;
                        }
                        else if (table[0].MacDinh.ToString().Equals("1"))
                        {
                            this.chk_MacDinh.Checked = true;
                        }
                    }
                    this.hd_insertnew.Value = "Update";
                    this.LoadValue(lang);
                    return;
                }
                this.pnvalue.Visible = true;
                this.pn_list.Visible = false;
                this.pn_detail.Visible = false;
                this.MultiView1.ActiveViewIndex = 0;
                this.LoadValue(lang);
            }




        }

        protected void rpvalues_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            this.hdvalue.Value = e.CommandArgument.ToString();
            this.txtvalues.Text = Captionlanguage.GetLabel(e.CommandArgument.ToString(), this.hdlangid.Value);
            this.MultiView1.ActiveViewIndex = 1;
        }


    }
}