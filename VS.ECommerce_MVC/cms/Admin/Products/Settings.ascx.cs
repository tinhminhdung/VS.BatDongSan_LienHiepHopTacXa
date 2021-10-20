using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using Entity;
using MoreAll;

namespace VS.ECommerce_MVC.cms.Admin.Products
{
    public partial class Settings : System.Web.UI.UserControl
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
                this.chkChangePass.Text = "Cập nhật mật khẩu";
            }
        }

        private void binddata()
        {
            RemoveCache.Products();
            RemoveCache.Menu();
            string Comment = "";

            string ToolTip = "";
            string Nganluong = "";
            List<Entity.Setting> str = SSetting.GETBYALL(lang);
            ltmsg.Text = "";
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "Pro_titile_Substring")
                    {
                        this.txtSubstring.Text = its.Value;
                    }
                    if (its.Properties == "color")
                    {
                        this.txtoptioncolor.Text = its.Value;
                    }
                    if (its.Properties == "HomePage")
                    {
                        this.txtHomePage.Text = its.Value;
                    }
                    if (its.Properties == "TieudeGia")
                    {
                        this.txttieudeGia.Text = its.Value;
                    }
                    if (its.Properties == "Lienhevnd")
                    {
                        this.txtlienhevnd.Text = its.Value;
                    }
                    if (its.Properties == "Dongiapro")
                    {
                        this.txtdongia.Text = its.Value;
                    }
                    if (its.Properties == "pagepro")
                    {
                        this.txtpagenews.Text = its.Value;
                    }
                    if (its.Properties == "prowidth")
                    {
                        this.txtwidth.Text = its.Value;
                    }
                    if (its.Properties == "proheight")
                    {
                        this.txtheight.Text = its.Value;
                    }
                    if (its.Properties == "proother")
                    {
                        this.txtnewsother.Text = its.Value;
                    }
                    if (its.Properties == "prowidthThumbnail")
                    {
                        this.txtrongThumbnail.Text = its.Value;
                    }
                    if (its.Properties == "proheightThumbnail")
                    {
                        this.txtcaoThumbnail.Text = its.Value;
                    }
                    if (its.Properties == "ToolTip")
                    {
                        ToolTip = its.Value;
                    }
                    //Ngan luong

                    if (its.Properties == "CheckOutUrl")
                    {
                        txtCheckOutUrl.Text = its.Value;
                    }
                    if (its.Properties == "MerchantSiteCode")
                    {
                        txtMerchantSiteCodes.Text = its.Value;
                    }
                    if (its.Properties == "PasswordNL")
                    {
                        txtPasss.Text = its.Value;
                    }
                    if (its.Properties == "Receive")
                    {
                        txtReceive.Text = its.Value;
                    }
                    if (its.Properties == "paypal")
                    {
                        txtpaypal.Text = its.Value;
                    }
                    if (its.Properties == "Usd")
                    {
                        txtusd.Text = its.Value;
                    }
                    if (its.Properties == "ttcuahang")
                    {
                        txtttcuahang.Text = its.Value;
                    }
                    if (its.Properties == "ttnganhang")
                    {
                        txtttnganhang.Text = its.Value;
                    }
                    if (its.Properties == "ttgiaodich")
                    {
                        txtttgiaodich.Text = its.Value;
                    }
                    if (its.Properties == "ttchuyenphatnhanh")
                    {
                        txtttchuyenphatnhanh.Text = its.Value;
                    }
                    if (its.Properties == "chknganluong")
                    {
                        if (its.Value.ToString().Trim().Equals("0"))
                        {
                            this.chknganluong.Checked = false;
                        }
                        else if (its.Value.ToString().Equals("1"))
                        {
                            this.chknganluong.Checked = true;
                        }
                    }
                    if (its.Properties == "CheckPaypal")
                    {
                        if (its.Value.ToString().Trim().Equals("0"))
                        {
                            this.CheckPaypal.Checked = false;
                        }
                        else if (its.Value.ToString().Equals("1"))
                        {
                            this.CheckPaypal.Checked = true;
                        }
                    }
                    if (its.Properties == "Merchant")
                    {
                        this.txtMerchant.Text = its.Value;
                    }
                    if (its.Properties == "Hashcode")
                    {
                        this.txtHashcode.Text = its.Value;
                    }
                    if (its.Properties == "Accesscode")
                    {
                        this.txtAccesscode.Text = its.Value;
                    }
                    if (its.Properties == "CheckTest")
                    {
                        if (its.Value.ToString().Trim().Equals("0"))
                        {
                            this.CheckTest.Checked = false;
                        }
                        else if (its.Value.ToString().Equals("1"))
                        {
                            this.CheckTest.Checked = true;
                        }
                    }

                    if (its.Properties == "CheckOnepay")
                    {
                        if (its.Value.ToString().Trim().Equals("0"))
                        {
                            this.CheckOnepay.Checked = false;
                        }
                        else if (its.Value.ToString().Equals("1"))
                        {
                            this.CheckOnepay.Checked = true;
                        }
                    }
                    if (its.Properties == "txtttatm")
                    {
                        txtttatm.Text = its.Value;
                    }
                    if (its.Properties == "txtttnganluong")
                    {
                        txtttnganluong.Text = its.Value;
                    }
                    if (its.Properties == "txtttPayPal")
                    {
                        txtttPayPal.Text = its.Value;
                    }
                    if (its.Properties == "txtVisa")
                    {
                        txtVisa.Text = its.Value;
                    }
                    if (its.Properties == "Commentsp")
                    {
                        Comment = its.Value;
                    }
                }
            }
            if (ToolTip.Equals("0"))
            {
                this.ToolTip1.Checked = true;
                this.ToolTip2.Checked = false;
                this.ToolTip3.Checked = false;
            }
            else if (ToolTip.Equals("1"))
            {
                this.ToolTip1.Checked = false;
                this.ToolTip2.Checked = true;
                this.ToolTip3.Checked = false;
            }
            else if (ToolTip.Equals("2"))
            {
                this.ToolTip1.Checked = false;
                this.ToolTip2.Checked = false;
                this.ToolTip3.Checked = true;
            }
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

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void btnsetup_Click(object sender, EventArgs e)
        {
            //Comment
            #region Comment
            int Comment = 0;
            if (this.Radio_CommentCo.Checked)
            {
                Comment = 1;
            }
            #endregion

            int ToolTip = 0;
            if (this.ToolTip2.Checked)
            {
                ToolTip = 1;
            }
            else if (this.ToolTip3.Checked)
            {
                ToolTip = 2;
            }
            Entity.Setting obj = new Entity.Setting();
            if (Page.IsValid)
            {
                if (this.chkChangePass.Checked && (this.txtPasss.Text.Length == 0))
                {
                    this.ltmsg.Text = "Mật khẩu kh\x00f4ng được để trống";
                }
                else
                {
                    if (this.chkChangePass.Checked)
                    {
                        obj.Lang = lang;
                        obj.Properties = "PasswordNL";
                        obj.Value = txtPasss.Text;
                        SSetting.UPDATE(obj);
                    }

                    obj.Lang = lang;
                    obj.Properties = "Lienhevnd";
                    obj.Value = txtlienhevnd.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Pro_titile_Substring";
                    obj.Value = txtSubstring.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "color";
                    obj.Value = txtoptioncolor.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "HomePage";
                    obj.Value = txtHomePage.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "TieudeGia";
                    obj.Value = txttieudeGia.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Dongiapro";
                    obj.Value = txtdongia.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "pagepro";
                    obj.Value = txtpagenews.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "prowidth";
                    obj.Value = txtwidth.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "proheight";
                    obj.Value = txtheight.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "proother";
                    obj.Value = txtnewsother.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "prowidthThumbnail";
                    obj.Value = txtrongThumbnail.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "proheightThumbnail";
                    obj.Value = txtcaoThumbnail.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "ToolTip";
                    obj.Value = ToolTip.ToString();
                    SSetting.UPDATE(obj);
                    //Nganluong/

                    obj.Lang = lang;
                    obj.Properties = "CheckOutUrl";
                    obj.Value = txtCheckOutUrl.Text;
                    SSetting.UPDATE(obj);
                    obj.Lang = lang;
                    obj.Properties = "MerchantSiteCode";
                    obj.Value = txtMerchantSiteCodes.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Receive";
                    obj.Value = txtReceive.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "paypal";
                    obj.Value = txtpaypal.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Usd";
                    obj.Value = txtusd.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "ttcuahang";
                    obj.Value = txtttcuahang.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "ttnganhang";
                    obj.Value = txtttnganhang.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "ttgiaodich";
                    obj.Value = txtttgiaodich.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "ttchuyenphatnhanh";
                    obj.Value = txtttchuyenphatnhanh.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "chknganluong";
                    obj.Value = chknganluong.Checked ? "1" : "0"; ;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "CheckPaypal";
                    obj.Value = CheckPaypal.Checked ? "1" : "0"; ;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Merchant";
                    obj.Value = txtMerchant.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Hashcode";
                    obj.Value = txtHashcode.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Accesscode";
                    obj.Value = txtAccesscode.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "CheckTest";
                    obj.Value = CheckTest.Checked ? "1" : "0";
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "CheckOnepay";
                    obj.Value = CheckOnepay.Checked ? "1" : "0";
                    SSetting.UPDATE(obj);


                    obj.Lang = lang;
                    obj.Properties = "txtttatm";
                    obj.Value = txtttatm.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "txtttnganluong";
                    obj.Value = txtttnganluong.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "txtttPayPal";
                    obj.Value = txtttPayPal.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "txtVisa";
                    obj.Value = txtVisa.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Commentsp";
                    obj.Value = Comment.ToString();
                    SSetting.UPDATE(obj);

                    this.binddata();
                    this.ltmsg.Text = "Thiết lập th\x00e0nh c\x00f4ng!";
                }
            }
        }
    }
}