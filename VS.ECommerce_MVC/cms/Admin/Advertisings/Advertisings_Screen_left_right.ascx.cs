using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using Entity;
using System.IO;
using Framework;
using MoreAll;

namespace VS.ECommerce_MVC.cms.Admin.Advertisings
{
    public partial class Advertisings_Screen_left_right : System.Web.UI.UserControl
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
            string Height = "";
            string Width = "";
            string str5 = "";

            string Height2 = "";
            string Width2 = "";
            string str52 = "";

            string Screen_option = "";
            string Screen_TrangThai = "";
            #region Setting
            FSetting DB = new FSetting();
            List<Entity.Setting> str = DB.GETBYALL(lang);
            ltmsg.Text = string.Empty;
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "Screenlink")
                    {
                        this.txtlink.Text = its.Value;
                    }
                    else if (its.Properties == "Screenwidth")
                    {
                        this.txtbannerwidth.Text = its.Value;
                        Width = its.Value;
                    }
                    else if (its.Properties == "Screenheight")
                    {
                        this.txtbannerheight.Text = its.Value;
                        Height = its.Value;
                    }
                    else if (its.Properties == "Screenpath")
                    {
                        str5 = its.Value;
                    }
                    if (its.Properties == "Screenlink2")
                    {
                        this.txtlink2.Text = its.Value;
                    }
                    else if (its.Properties == "Screenwidth2")
                    {
                        this.txtbannerwidth2.Text = its.Value;
                        Width2 = its.Value;
                    }
                    else if (its.Properties == "Screenheight2")
                    {
                        this.txtbannerheight2.Text = its.Value;
                        Height2 = its.Value;
                    }
                    else if (its.Properties == "Screenpath2")
                    {
                        str52 = its.Value;
                    }
                    else if (its.Properties == "Screen_option")
                    {
                        Screen_option = its.Value;
                    }
                    else if (its.Properties == "Screen_TrangThai")
                    {
                        Screen_TrangThai = its.Value;
                    }
                }
            }
            #endregion
            #region Trai
            if (Height.Equals("-1"))
            {
                Height = "0";
            }
            if (Width.Equals("-1"))
            {
                Width = "0";
            }
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
                    this.ltcurrentpic.Text = "<embed  style='" + MoreAll.MoreAll.Style_Width((Width)) + ";" + MoreAll.MoreAll.Style_Height((Height)) + "' align='middle'  quality='high' wmode='transparent' allowscriptaccess='always'  type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer'  src='Uploads/advs/" + str5 + "'>";
                }
            }
            #endregion
            #region Phai
            if (Width2.Equals("-1"))
            {
                Width2 = "0";
            }
            if (Height2.Equals("-1"))
            {
                Height2 = "0";
            }
            if (str52.Equals("-1"))
            {
                this.ltcurrentpic2.Text = "";
            }
            else if (str52.Equals(""))
            {
                this.ltcurrentpic2.Text = "";
            }
            else if (str52.Length > 4)
            {
                string str6 = str52.Substring(str52.IndexOf(".")).ToLower();
                if ((str6.Equals(".jpg") || str6.Equals(".gif")) || str6.Equals(".png"))
                {

                    this.ltcurrentpic2.Text = "<img src='Uploads/advs/" + str52 + "' border=0 style='border:1px solid #9EC3CB;" + MoreAll.MoreAll.Style_Width((Width2)) + ";" + MoreAll.MoreAll.Style_Height((Height2)) + "' /><br>";
                }
                else if (str6.Equals(".swf"))
                {
                    this.ltcurrentpic2.Text = "<embed   style='" + MoreAll.MoreAll.Style_Width((Width2)) + ";" + MoreAll.MoreAll.Style_Height((Height2)) + "'  align='middle'  quality='high' wmode='transparent' allowscriptaccess='always'  type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer'  src='Uploads/advs/" + str52 + "'>";
                }
            }
            #endregion
            #region Radio
            if (Screen_option.Equals("0"))
            {
                this.rdcommentoptioncheckcomments.Checked = false;
                this.rdcommentoptionnotcheckcomments.Checked = true;
            }
            else if (Screen_option.Equals("1"))
            {
                this.rdcommentoptioncheckcomments.Checked = true;
                this.rdcommentoptionnotcheckcomments.Checked = false;
            }

            if (Screen_TrangThai.Equals("0"))
            {
                this.Radiomo.Checked = false;
                this.Radiotat.Checked = true;
            }
            else if (Screen_TrangThai.Equals("1"))
            {
                this.Radiomo.Checked = true;
                this.Radiotat.Checked = false;
            }
            #endregion
            this.hdimage.Value = str5;
            this.hdimage2.Value = str52;
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void btnsetup_Click(object sender, EventArgs e)
        {
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
            #region MyRegion
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
            //Ben phai
            #region MyRegion
            string vvalue2 = "";
            if ((this.flimg2.FileName.Trim().Length > 0) && (this.flimg2.PostedFile.ContentLength > 0))
            {
                string fileName = Path.GetFileName(this.flimg2.PostedFile.FileName);
                string str333 = "";
                str333 = Path.GetExtension(fileName).ToLower();
                if ((!str333.Equals(".jpg") && !str333.Equals(".gif")) && !str333.Equals(".png") && !str333.Equals(".swf"))
                {
                    this.ltmsg.Text = "Chỉ hỗ trợ định dạng .gif hoặc .jpg hoặc .png hoặc .swf";
                    return;
                }
                if (!this.hdimage2.Equals("-1"))
                {
                    try
                    {
                        File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/Uploads/advs/" + this.hdimage2.Value);
                    }
                    catch (Exception)
                    {
                    }
                }
                vvalue2 = DateTime.Now.Ticks.ToString() + str333;
                this.flimg2.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "/Uploads/advs/" + vvalue2);
            }
            else
            {
                vvalue2 = this.hdimage2.Value;
            }
            #endregion
            #region Setting

            Entity.Setting obj = new Entity.Setting();
            obj.Lang = lang;
            obj.Properties = "Screenlink2";
            obj.Value = txtlink2.Text;
            SSetting.UPDATE(obj);

            obj.Lang = lang;
            obj.Properties = "Screenpath2";
            obj.Value = vvalue2;
            SSetting.UPDATE(obj);

            obj.Lang = lang;
            obj.Properties = "Screenheight2";
            obj.Value = txtbannerheight2.Text;
            SSetting.UPDATE(obj);


            obj.Lang = lang;
            obj.Properties = "Screenwidth2";
            obj.Value = txtbannerwidth2.Text;
            SSetting.UPDATE(obj);


            obj.Lang = lang;
            obj.Properties = "Screenlink";
            obj.Value = txtlink.Text;
            SSetting.UPDATE(obj);

            obj.Lang = lang;
            obj.Properties = "Screenpath";
            obj.Value = vvalue;
            SSetting.UPDATE(obj);

            obj.Lang = lang;
            obj.Properties = "Screenwidth";
            obj.Value = txtbannerwidth.Text;
            SSetting.UPDATE(obj);

            obj.Lang = lang;
            obj.Properties = "Screenheight";
            obj.Value = txtbannerheight.Text;
            SSetting.UPDATE(obj);

            obj.Lang = lang;
            obj.Properties = "Screen_option";
            obj.Value = num.ToString();
            SSetting.UPDATE(obj);

            obj.Lang = lang;
            obj.Properties = "Screen_TrangThai";
            obj.Value = num2.ToString();
            SSetting.UPDATE(obj);
            #endregion
            this.binddata();
            this.ltmsg.Text = "Thiết lập th\x00e0nh c\x00f4ng!";
        }

        protected void lnkbannerdelete_Click(object sender, EventArgs e)
        {
            try
            {
                #region MyRegion
                try
                {
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/Uploads/advs/" + this.hdimage.Value);
                }
                catch (Exception) { }
                Entity.Setting obj = new Entity.Setting();
                obj.Lang = lang;
                obj.Properties = "Screenpath";
                obj.Value = "";
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "Screenwidth";
                obj.Value = "0";
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "Screenheight";
                obj.Value = "0";
                SSetting.UPDATE(obj);
                this.ltmsg.Text = "Thiết lập th\x00e0nh c\x00f4ng!";
                this.binddata();
                base.Response.Redirect(base.Request.Url.ToString());
                #endregion
            }
            catch (Exception) { }
        }

        protected void lnkbannerdelete2_Click(object sender, EventArgs e)
        {
            try
            {
                #region Delete
                try
                {
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/Uploads/advs/" + this.hdimage2.Value);
                }
                catch (Exception) { }
                Entity.Setting obj = new Entity.Setting();
                obj.Lang = lang;
                obj.Properties = "Screenpath2";
                obj.Value = "";
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "Screenwidth2";
                obj.Value = "0";
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "Screenheight2";
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