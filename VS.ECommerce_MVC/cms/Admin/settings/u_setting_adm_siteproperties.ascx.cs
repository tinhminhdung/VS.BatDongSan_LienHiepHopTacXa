using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Services;
using Entity;
using Framework;
using MoreAll;

namespace VS.ECommerce_MVC.cms.Admin.settings
{
    public partial class u_setting_adm_siteproperties : System.Web.UI.UserControl
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
                this.load();
            }
        }

        protected void btnsetup_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                #region PageS404
                int ErrPage = 0;
                if (this.Radio_loiCo.Checked)
                {
                    ErrPage = 1;
                }
                #endregion
                #region Setting
                Entity.Setting obj = new Entity.Setting();
                obj.Lang = lang;
                obj.Properties = "FooTer";
                obj.Value = txtfootercontent.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "LienHe";
                obj.Value = txtcontactcontent.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "GioHang";
                obj.Value = txtgiohang.Text;
                SSetting.UPDATE(obj);
              
                obj.Lang = lang;
                obj.Properties = "Seo";
                obj.Value = txtseo.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "Loi404";
                obj.Value = txtloi404.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "txtbando";
                obj.Value = txtbando.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "ErrPage";
                obj.Value = ErrPage.ToString();
                SSetting.UPDATE(obj);
                #endregion
            }
            this.load();
            this.ltmsg.Text = "Thiết lập th\x00e0nh c\x00f4ng!";
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }
        private void load()
        {
            RemoveCache.Home();

            string ErrPage = "";
            FSetting DB = new FSetting();
            List<Entity.Setting> str = DB.GETBYALL(lang);
            ltmsg.Text = string.Empty;
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "FooTer")
                    {
                        this.txtfootercontent.Text = its.Value;
                    }
                    else if (its.Properties == "LienHe")
                    {
                        this.txtcontactcontent.Text = its.Value;
                    }
                    else if (its.Properties == "GioHang")
                    {
                        this.txtgiohang.Text = its.Value;
                    }
                    else if (its.Properties == "Seo")
                    {
                        this.txtseo.Text = its.Value;
                    }
                    else if (its.Properties == "Loi404")
                    {
                        this.txtloi404.Text = its.Value;
                    }
                    else if (its.Properties == "txtbando")
                    {
                        this.txtbando.Text = its.Value;
                    }
                    if (its.Properties == "ErrPage")
                    {
                        ErrPage = its.Value;
                    }
                    #region MyRegion
                    if (ErrPage.Equals("0"))
                    {
                        this.Radio_loiCo.Checked = false;
                        this.Radio_loiKhong.Checked = true;
                    }
                    else if (ErrPage.Equals("1"))
                    {
                        this.Radio_loiCo.Checked = true;
                        this.Radio_loiKhong.Checked = false;
                    }
                    #endregion
                    this.btnsetup.Text = "Cập nhật";
                }
            }
        }

       
    }
}