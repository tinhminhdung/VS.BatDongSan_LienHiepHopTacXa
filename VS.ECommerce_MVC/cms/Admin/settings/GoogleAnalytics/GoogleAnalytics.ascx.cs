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

namespace VS.ECommerce_MVC.cms.Admin.settings.GoogleAnalytics
{
    public partial class GoogleAnalytics : System.Web.UI.UserControl
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
            RemoveCache.Home();
            try
            {
                FSetting DB = new FSetting();
                List<Entity.Setting> str = DB.GETBYALL(lang);
                ltmsg.Text = string.Empty;
                if (str.Count >= 1)
                {
                    foreach (Entity.Setting its in str)
                    {
                        if (its.Properties == "head")
                        {
                            this.txthead.Text = its.Value;
                        }
                        if (its.Properties == "body")
                        {
                            this.txtbody.Text = its.Value;
                        }
                    }
                }
                this.btnsetup.Text = "Cập nhật";
            }
            catch (Exception) { }
        }

        protected void btnsetup_Click(object sender, EventArgs e)
        {
            try
            {
                Entity.Setting obj = new Entity.Setting();

                obj.Lang = lang;
                obj.Properties = "head";
                obj.Value = txthead.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "body";
                obj.Value = txtbody.Text;
                SSetting.UPDATE(obj);

                this.binddata();
                this.ltmsg.Text = "Thiết lập th\x00e0nh c\x00f4ng!";
            }
            catch (Exception) { }
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }
    }
}