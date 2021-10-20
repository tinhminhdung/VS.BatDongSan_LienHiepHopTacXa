using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Framework;
using Entity;
using Services;

namespace VS.ECommerce_MVC.cms.Admin
{
    public partial class u_admin_hr : System.Web.UI.UserControl
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
            if (!base.IsPostBack)
            {
                try
                {
                    ltadmin.Text = MoreAll.MoreAll.GetCookies("UName").ToString();
                    FLan DB = new FLan();
                    List<Lans> str = DB.ALL();
                    this.rplangs.DataSource = str;
                    this.rplangs.DataBind();
                    //ltcontacts.Text = TotalContacts(lang);
                    //List<Carts> tong = SCarts.Name_Text("SELECT * FROM Carts where Status=0");
                    //ltProduct_Carts.Text = tong.Count.ToString();
                }
                catch (Exception) { }
            }
        }

        protected void lnkdangxuat_Click(object sender, EventArgs e)
        {
            MoreAll.MoreAll.SetCookie("UName", "", -1);
            MoreAll.MoreAll.SetCookie("URole", "", -1);
            Response.Redirect(Request.Url.ToString());
        }

        protected string langcss(string lang)
        {
            if (lang.Equals(this.lang))
            {
                return "languagecur";
            }
            return "language";
        }

        protected void rplangs_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("change"))
            {
                System.Web.HttpContext.Current.Session["lang"] = e.CommandArgument.ToString();
                base.Response.Redirect("admin.aspx");
            }
        }

        protected string TotalContacts(string lang)
        {
            FContacts DB = new FContacts();
            List<Entity.Contacts> str = DB.GETBYALL(lang);
            if (str.Count > 0)
            {
                return str.Count.ToString();
            }
            else return "0";
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }
    }
}