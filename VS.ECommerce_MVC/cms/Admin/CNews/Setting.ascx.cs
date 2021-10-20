using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using MoreAll;

namespace VS.ECommerce_MVC.cms.Admin.M_News
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
                RemoveCache.News();
                RemoveCache.Menu();
                string Comment = "";
                string StatusComment = "";
                string Facebook = "";
                #region Setting
                List<Entity.Setting> str = SSetting.GETBYALL(lang);
                ltmsg.Text = string.Empty;
                if (str.Count >= 1)
                {
                    foreach (Entity.Setting its in str)
                    {
                        if (its.Properties == "News_Mota_Substring")
                        {
                            this.txtSubstring_Mota.Text = its.Value;
                        }
                        if (its.Properties == "News_titile_Substring")
                        {
                            this.txtSubstring.Text = its.Value;
                        }
                        if (its.Properties == "News_titile_Substring")
                        {
                            this.txtSubstring.Text = its.Value;
                        }
                        if (its.Properties == "pagenews")
                        {
                            this.txtpagenews.Text = its.Value;
                        }
                        if (its.Properties == "newswidth")
                        {
                            this.txtwidth.Text = its.Value;
                        }
                        if (its.Properties == "newsheight")
                        {
                            this.txtheight.Text = its.Value;
                        }
                        if (its.Properties == "newsother")
                        {
                            this.txtnewsother.Text = its.Value;
                        }
                        if (its.Properties == "Comment")
                        {
                            Comment = its.Value;
                        }
                        if (its.Properties == "StatusComment")
                        {
                            StatusComment = its.Value;
                        }
                        if (its.Properties == "NFacebook")
                        {
                            Facebook = its.Value;
                        }
                    }
                }
                #endregion
                #region MyRegion
                if (Facebook.Equals("0"))
                {
                    this.Facebook1.Checked = true;
                    this.Facebook2.Checked = false;
                    this.Facebook3.Checked = false;
                }
                else if (Facebook.Equals("1"))
                {
                    this.Facebook1.Checked = false;
                    this.Facebook2.Checked = true;
                    this.Facebook3.Checked = false;
                }
                else if (Facebook.Equals("2"))
                {
                    this.Facebook1.Checked = false;
                    this.Facebook2.Checked = false;
                    this.Facebook3.Checked = true;
                }
                #endregion
                #region MyRegion
                if (Comment.Equals("0"))
                {
                    this.Radio_CommentCo.Checked = false;
                    this.Radio_CommentKhong.Checked = true;
                }
                else if (Comment.Equals("1"))
                {
                    this.Radio_CommentCo.Checked = true;
                    this.Radio_CommentKhong.Checked = false;
                }
                #endregion
            }
            catch (Exception) { }
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            btnsetup_Click(sender, e);
        }
        protected void btnsetup_Click(object sender, EventArgs e)
        {
            try
            {
                #region Setting
                if (Page.IsValid)
                {

                    //Comment
                    #region Comment
                    int Comment = 0;
                    if (this.Radio_CommentCo.Checked)
                    {
                        Comment = 1;
                    }
                    #endregion
                    //Facebook
                    #region Facebook
                    int Facebook = 0;
                    if (this.Facebook2.Checked)
                    {
                        Facebook = 1;
                    }
                    else if (this.Facebook3.Checked)
                    {
                        Facebook = 2;
                    }
                    #endregion
                    #region Setting

                    Entity.Setting obj = new Entity.Setting();
                    obj.Lang = lang;
                    obj.Properties = "NFacebook";
                    obj.Value = Facebook.ToString(); ;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "News_titile_Substring";
                    obj.Value = txtSubstring.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "News_Mota_Substring";
                    obj.Value = txtSubstring_Mota.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "pagenews";
                    obj.Value = txtpagenews.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "newswidth";
                    obj.Value = txtwidth.Text;
                    SSetting.UPDATE(obj);
                    obj.Lang = lang;

                    obj.Properties = "newsheight";
                    obj.Value = txtheight.Text;
                    SSetting.UPDATE(obj);
                    obj.Lang = lang;

                    obj.Properties = "newsother";
                    obj.Value = txtnewsother.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Comment";
                    obj.Value = Comment.ToString();
                    SSetting.UPDATE(obj);

                    #endregion
                }
                this.binddata();
                this.ltmsg.Text = "Thiết lập th\x00e0nh c\x00f4ng!";
                #endregion
            }
            catch (Exception) { }
        }
    }
}