using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using Entity;
using System.IO;
using MoreAll;
using Framework;

namespace VS.ECommerce_MVC.cms.Admin.Advertisings
{
    public partial class Advertisings_PopUp : System.Web.UI.UserControl
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
                string Popup_TrangThai = "";
                string Popup_option = "";
                string Width = "";
                string Height = "";
                string str5 = "";
                #region Setting
                FSetting DB = new FSetting();
                List<Entity.Setting> str = DB.GETBYALL(lang);
                ltmsg.Text = string.Empty;
                if (str.Count >= 1)
                {
                    foreach (Entity.Setting its in str)
                    {
                        if (its.Properties == "Popuplink")
                        {
                            this.txtlink.Text = its.Value;
                        }
                        else if (its.Properties == "Popupwidth")
                        {
                            this.txtbannerwidth.Text = its.Value;
                            Width = its.Value;
                        }
                        else if (its.Properties == "Popupheight")
                        {
                            this.txtbannerheight.Text = its.Value;
                            Height = its.Value;
                        }
                        else if (its.Properties == "Popuppath")
                        {
                            str5 = its.Value;
                        }
                        else if (its.Properties == "Popup_TrangThai")
                        {
                            Popup_TrangThai = its.Value;
                        }
                        else if (its.Properties == "Popup_option")
                        {
                            Popup_option = its.Value;
                        }
                    }
                }
                #endregion
                #region Radio
                if (Popup_option.Equals("0"))
                {
                    this.rdcommentoptioncheckcomments.Checked = false;
                    this.rdcommentoptionnotcheckcomments.Checked = true;
                }
                else if (Popup_option.Equals("1"))
                {
                    this.rdcommentoptioncheckcomments.Checked = true;
                    this.rdcommentoptionnotcheckcomments.Checked = false;
                }

                if (Popup_TrangThai.Equals("0"))
                {
                    this.Radiomo.Checked = false;
                    this.Radiotat.Checked = true;
                }
                else if (Popup_TrangThai.Equals("1"))
                {
                    this.Radiomo.Checked = true;
                    this.Radiotat.Checked = false;
                }
                #endregion
                #region Images
                if (Width.Equals("-1"))
                {
                    Width = "0";
                }
                if (Height.Equals("-1"))
                {
                    Height = "0";
                }
                this.txtbannerwidth.Text = Width;
                this.txtbannerheight.Text = Height;

                if (str5.Equals("-1"))
                {
                    this.ltcurrentpic.Text = "";
                }
                else if (str5.Equals(""))
                {
                    this.ltcurrentpic.Text = "";
                }
                else if (str5.Length > 4)
                {
                    string str6 = str5.Substring(str5.IndexOf(".")).ToLower();
                    if ((str6.Equals(".jpg") || str6.Equals(".gif")) || str6.Equals(".png"))
                    {
                        this.ltcurrentpic.Text = "<img src='Uploads/advs/" + str5 + "' border=0 style='border:1px solid #9EC3CB;" + MoreAll.MoreAll.Style_Width((Width)) + ";" + MoreAll.MoreAll.Style_Height((Height)) + "' /><br>";
                    }
                    else if (str6.Equals(".swf"))
                    {
                        this.ltcurrentpic.Text = "<embed  style='" + MoreAll.MoreAll.Style_Width((Width)) + ";" + MoreAll.MoreAll.Style_Height((Height)) + "'  align='middle'  quality='high' wmode='transparent' allowscriptaccess='always'  type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer'  src='Uploads/advs/" + str5 + "'>";
                    }
                }
                this.hdimage.Value = str5;
                #endregion
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
                if (Page.IsValid)
                {
                    #region Images
                    int num = 0;
                    if (this.rdcommentoptioncheckcomments.Checked)
                    {
                        num = 1;
                    }
                    int num2 = 0;
                    if (this.Radiomo.Checked)
                    {
                        num2 = 1;
                    }
                    string vvalue = "";
                    if ((this.flimg.FileName.Trim().Length > 0) && (this.flimg.PostedFile.ContentLength > 0))
                    {
                        string fileName = Path.GetFileName(this.flimg.PostedFile.FileName);
                        string str3 = "";
                        str3 = Path.GetExtension(fileName).ToLower();
                        if ((!str3.Equals(".jpg") && !str3.Equals(".gif")) && !str3.Equals(".png") && !str3.Equals(".swf"))
                        {
                            this.ltmsg.Text = "Chỉ hỗ trợ định dạng .gif hoặc .jpg hoặc .png hoặc .swf";
                            return;
                        }
                        if (!this.hdimage.Equals("-1"))
                        {
                            try
                            {
                                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/Uploads/advs/" + this.hdimage.Value);
                            }
                            catch (Exception)
                            {
                            }
                        }
                        vvalue = DateTime.Now.Ticks.ToString() + str3;
                        this.flimg.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "/Uploads/advs/" + vvalue);
                    }
                    else
                    {
                        vvalue = this.hdimage.Value;
                    }
                    #endregion
                    #region Setting

                    Entity.Setting obj = new Entity.Setting();
                    obj.Lang = lang;
                    obj.Properties = "Popuplink";
                    obj.Value = txtlink.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Popuppath";
                    obj.Value = vvalue;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Popupwidth";
                    obj.Value = txtbannerwidth.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Popupheight";
                    obj.Value = txtbannerheight.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Popup_option";
                    obj.Value = num.ToString();
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Popup_TrangThai";
                    obj.Value = num2.ToString();
                    SSetting.UPDATE(obj);
                    #endregion
                }
                this.binddata();
                this.ltmsg.Text = "Thiết lập th\x00e0nh c\x00f4ng!";
            }
            catch (Exception) { }
        }

        protected void lnkbannerdelete_Click(object sender, EventArgs e)
        {
            try
            {
                #region Delete
                try
                {
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/Uploads/advs/" + this.hdimage.Value);
                }
                catch (Exception) { }
                Entity.Setting obj = new Entity.Setting();
                obj.Lang = lang;
                obj.Properties = "Popuppath";
                obj.Value = "";
                SSetting.UPDATE(obj);


                obj.Lang = lang;
                obj.Properties = "Popupwidth";
                obj.Value = "0";
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "Popupheight";
                obj.Value = "0";
                SSetting.UPDATE(obj);

                this.binddata();
                this.ltmsg.Text = "Thiết lập th\x00e0nh c\x00f4ng!";
                base.Response.Redirect(base.Request.Url.ToString());
                #endregion
            }
            catch (Exception) { }
        }
    }
}