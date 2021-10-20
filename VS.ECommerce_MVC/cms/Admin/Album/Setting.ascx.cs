using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using MoreAll;

namespace VS.ECommerce_MVC.cms.Admin.Album
{
    public partial class Setting : System.Web.UI.UserControl
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
                RemoveCache.Album();
                RemoveCache.Menu();


                List<Entity.Setting> str = SSetting.GETBYALL(lang);
                ltmsg.Text = string.Empty;
                if (str.Count >= 1)
                {
                    foreach (Entity.Setting its in str)
                    {
                        if (its.Properties == "pagePhoto")
                        {
                            this.txtpagenews.Text = its.Value;
                        }
                        if (its.Properties == "Photowidth")
                        {
                            this.txtwidth.Text = its.Value;
                        }
                        if (its.Properties == "Photoheight")
                        {
                            this.txtheight.Text = its.Value;
                        }
                        if (its.Properties == "txtHomePagealbum")
                        {
                            this.txtHomePagealbum.Text = its.Value;
                        }
                        

                    }
                }
            }
            catch (Exception) { }
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void btnsetup_Click(object sender, EventArgs e)
        {
            try
            {
                #region Setting
                {
                    Entity.Setting obj = new Entity.Setting();
                    obj.Lang = lang;
                    obj.Properties = "pagePhoto";
                    obj.Value = txtpagenews.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Photowidth";
                    obj.Value = txtwidth.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Photoheight";
                    obj.Value = txtheight.Text;
                    SSetting.UPDATE(obj);


                    obj.Lang = lang;
                    obj.Properties = "txtHomePagealbum";
                    obj.Value = txtHomePagealbum.Text;
                    SSetting.UPDATE(obj);
                        

                }
                #endregion
                this.binddata();
                this.ltmsg.Text = "Thiết lập thành công!";
            }
            catch (Exception) { }
        }
    }
}