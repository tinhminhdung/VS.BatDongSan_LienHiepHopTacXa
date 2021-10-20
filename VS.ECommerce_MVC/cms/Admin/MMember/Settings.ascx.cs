using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using Entity;
using MoreAll;

namespace VS.ECommerce_MVC.cms.Admin.MMember
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
            }
        }

        private void binddata()
        {
            List<Entity.Setting> str = SSetting.GETBYALL(lang);
            ltmsg.Text = "";
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "TruongNhomKinhDoanh")
                    {
                        this.TruongNhomKinhDoanh.Text = its.Value;
                    }
                    if (its.Properties == "TruongPhongKinhDoanh")
                    {
                        this.TruongPhongKinhDoanh.Text = its.Value;
                    }
                    if (its.Properties == "GiamDocKinhDoanh")
                    {
                        this.GiamDocKinhDoanh.Text = its.Value;
                    }
                    if (its.Properties == "VanPhongChiNhanh")
                    {
                        this.VanPhongChiNhanh.Text = its.Value;
                    }
                    if (its.Properties == "HHTrucTiep")
                    {
                        this.HHTrucTiep.Text = its.Value;
                    }
                    if (its.Properties == "DongHuong")
                    {
                        this.DongHuong.Text = its.Value;
                    }
                    if (its.Properties == "PhoGiamDoc")
                    {
                        this.PhoGiamDoc.Text = its.Value;
                    }
                    if (its.Properties == "Nhanvien")
                    {
                        this.Nhanvien.Text = its.Value;
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

            Entity.Setting obj = new Entity.Setting();
            if (Page.IsValid)
            {
                obj.Lang = lang;
                obj.Properties = "HHTrucTiep";
                obj.Value = HHTrucTiep.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "DongHuong";
                obj.Value = DongHuong.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "TruongNhomKinhDoanh";
                obj.Value = TruongNhomKinhDoanh.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "TruongPhongKinhDoanh";
                obj.Value = TruongPhongKinhDoanh.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "GiamDocKinhDoanh";
                obj.Value = GiamDocKinhDoanh.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "VanPhongChiNhanh";
                obj.Value = VanPhongChiNhanh.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "Nhanvien";
                obj.Value = Nhanvien.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "PhoGiamDoc";
                obj.Value = PhoGiamDoc.Text;
                SSetting.UPDATE(obj);

                this.binddata();
                this.ltmsg.Text = "Thiết lập th\x00e0nh c\x00f4ng!";
            }
        }
    }
}