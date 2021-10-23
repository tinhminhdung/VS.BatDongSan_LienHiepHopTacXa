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
    public partial class ChiHoaHong : System.Web.UI.UserControl
    {
        private string lang = Captionlanguage.Language;
        private string IDMaDonTao = "1";
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
            ThanhVienMua.Text = ""; ThanhVienBan.Text = ""; SoTien.Text = "";
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void btnsetup_Click(object sender, EventArgs e)
        {
            IDMaDonTao = MoreAll.MoreAll.FormatDate_IDQR(DateTime.Now);
            if (hdThanhVienMua.Value != "0" && hdThanhVienBan.Value != "0")
            {
                SinhHH.HoaHongF(hdThanhVienMua.Value, hdThanhVienBan.Value, IDMaDonTao, SoTien.Text);

                this.binddata();
                Response.Write("<script type=\"text/javascript\">alert('Duyệt thành công với mã đơn hàng #" + IDMaDonTao + ".');window.location.href='" + Request.RawUrl.ToString() + "'; </script>");
            }
            else
            {
                ltmsg.Text = "Vui lòng kiểm tra đầu vào.";
            }
        }

        protected void ThanhVienBan_TextChanged(object sender, EventArgs e)
        {
            TextBox Tieude = (TextBox)sender;
            ltthongtin1.Text = SearchThanhVien1(Tieude.Text.Trim().Replace("&nbsp;", ""));
        }

        protected void ThanhVienMua_TextChanged(object sender, EventArgs e)
        {
            TextBox Tieude = (TextBox)sender;
            ltthongtin2.Text = SearchThanhVien2(Tieude.Text.Trim().Replace("&nbsp;", ""));
        }
        protected string SearchThanhVien1(string keyword)
        {
            List<Entity.Member> dt = SMember.Name_Text("select * from Members where (DienThoai ='" + keyword + "')");
            if (dt.Count >= 1)
            {
                hdThanhVienBan.Value = dt[0].ID.ToString();
                return dt[0].HoVaTen.ToString() + " - " + dt[0].DienThoai.ToString();
            }
            return "";
        }
        protected string SearchThanhVien2(string keyword)
        {
            List<Entity.Member> dt = SMember.Name_Text("select * from Members where (DienThoai ='" + keyword + "')");
            if (dt.Count >= 1)
            {
                hdThanhVienMua.Value = dt[0].ID.ToString();
                return dt[0].HoVaTen.ToString() + " - " + dt[0].DienThoai.ToString();
            }
            return "";
        }

    }
}