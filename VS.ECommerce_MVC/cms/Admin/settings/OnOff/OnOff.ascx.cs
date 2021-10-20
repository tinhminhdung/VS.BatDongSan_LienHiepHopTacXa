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

namespace VS.ECommerce_MVC.cms.Admin.settings.OnOff
{
    public partial class OnOff : System.Web.UI.UserControl
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
                this.binddata();
            }
        }

        private void binddata()
        {
            try
            {
                string StatusOnOff = "";
                FSetting DB = new FSetting();
                List<Entity.Setting> str = DB.GETBYALL(lang);
                ltmsg.Text = string.Empty;
                if (str.Count >= 1)
                {
                    foreach (Entity.Setting its in str)
                    {
                        if (its.Properties == "OnOff")
                        {
                            this.txtOnOff.Text = its.Value;
                        }

                        if (its.Properties == "StatusOnOff")
                        {
                            StatusOnOff = its.Value;
                        }
                    }
                }
                if (StatusOnOff.Equals("0"))
                {
                    this.rdcommentoptioncheckcomments.Checked = false;
                    this.rdcommentoptionnotcheckcomments.Checked = true;
                }
                else if (StatusOnOff.Equals("1"))
                {
                    this.rdcommentoptioncheckcomments.Checked = true;
                    this.rdcommentoptionnotcheckcomments.Checked = false;
                }
            }
            catch (Exception) { }
        }

        protected void btnsetup_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int num = 0;
                if (this.rdcommentoptioncheckcomments.Checked)
                {
                    num = 1;
                }
                Entity.Setting obj = new Entity.Setting();
                obj.Lang = lang;
                obj.Properties = "OnOff";
                obj.Value = txtOnOff.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "StatusOnOff";
                obj.Value = num.ToString();
                SSetting.UPDATE(obj);
            }
            this.binddata();
            this.ltmsg.Text = "Thiết lập th\x00e0nh c\x00f4ng!";
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

    }
}