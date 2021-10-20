using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using MoreAll;
using Entity;

namespace VS.ECommerce_MVC.cms.Admin.Video
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
            RemoveCache.Video();
            RemoveCache.Menu();

            List<Entity.Setting> str = SSetting.GETBYALL(lang);
            ltmsg.Text = string.Empty;
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "pagevideo")
                    {
                        this.txtpagevideo.Text = its.Value;
                    }

                    if (its.Properties == "videowidth")
                    {
                        this.txtwidth.Text = its.Value;
                    }
                    if (its.Properties == "videoheight")
                    {
                        this.txtheight.Text = its.Value;
                    }


                    if (its.Properties == "videoimgwidth")
                    {
                        this.txtronghinhanh.Text = its.Value;
                    }
                    if (its.Properties == "videoimgheight")
                    {
                        this.txtcaohinhanh.Text = its.Value;
                    }
                    if (its.Properties == "VideopageHome")
                    {
                        this.txtHomePage.Text = its.Value;
                    }
                    if (its.Properties == "videoother")
                    {
                        this.txtvideoother.Text = its.Value;
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
                obj.Properties = "pagevideo";
                obj.Value = txtpagevideo.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "videowidth";
                obj.Value = txtwidth.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "videoheight";
                obj.Value = txtheight.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "videoimgwidth";
                obj.Value = txtronghinhanh.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "videoimgheight";
                obj.Value = txtcaohinhanh.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "videoother";
                obj.Value = txtvideoother.Text;
                SSetting.UPDATE(obj);

                obj.Properties = "VideopageHome";
                obj.Value = txtHomePage.Text;
                SSetting.UPDATE(obj);
            }
            #endregion
            this.binddata();
            this.ltmsg.Text = "Thiết lập thành công!";

        }
    }
}