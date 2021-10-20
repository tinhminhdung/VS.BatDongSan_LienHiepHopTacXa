using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using MoreAll;

namespace VS.ECommerce_MVC.cms.Admin.Download
{
    public partial class u_nws_setting : System.Web.UI.UserControl
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
            List<Entity.Setting> str = SSetting.GETBYALL(lang);
            ltmsg.Text = string.Empty;
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "pageDownload")
                    {
                        this.txtpagenews.Text = its.Value;
                    }

                    if (its.Properties == "Downloadwidth")
                    {
                        this.txtwidth.Text = its.Value;
                    }

                    if (its.Properties == "Downloadheight")
                    {
                        this.txtheight.Text = its.Value;
                    }
                }
            }
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void btnsetup_Click(object sender, EventArgs e)
        {
            #region Setting
            if (Page.IsValid)
            {
                Entity.Setting obj = new Entity.Setting();
                obj.Lang = lang;
                obj.Properties = "pageDownload";
                obj.Value = txtpagenews.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "Downloadwidth";
                obj.Value = txtwidth.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "Downloadheight";
                obj.Value = txtheight.Text;
                SSetting.UPDATE(obj);
            }
            #endregion
            this.binddata();
            this.ltmsg.Text = "Thiết lập th\x00e0nh c\x00f4ng!";

        }
    }
}