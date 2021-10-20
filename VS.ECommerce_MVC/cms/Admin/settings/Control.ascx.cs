using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;

namespace VS.ECommerce_MVC.cms.Admin.settings
{
    public partial class Control : System.Web.UI.UserControl
    {
        private string lang = Captionlanguage.Language;
        private string su = "";
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
            if (Request["su"] != null && !Request["su"].Equals(""))
            {
                su = Request["su"];
            }
            switch (this.su)
            {
                case "sql":
                    phcontrol.Controls.Add(LoadControl("ExecuteSQL.ascx"));
                    return;
                case "website":
                    phcontrol.Controls.Add(LoadControl("website.ascx"));
                    return;
                case "login":
                    phcontrol.Controls.Add(LoadControl("HistoryLogin.ascx"));
                    return;
                case "Vote":
                    phcontrol.Controls.Add(LoadControl("../Vote/Vote.ascx"));
                    return;
                case "OnOff":
                    phcontrol.Controls.Add(LoadControl("OnOff/OnOff.ascx"));
                    return;
                case "Guide_Posts":
                    phcontrol.Controls.Add(LoadControl("Guide_Posts.ascx"));
                    return;
                case "GoogleAnalytics":
                    phcontrol.Controls.Add(LoadControl("GoogleAnalytics/GoogleAnalytics.ascx"));
                    return;
                case "languages":
                    phcontrol.Controls.Add(LoadControl("../languages/languages.ascx"));
                    return;
                case "AdminUser":
                    phcontrol.Controls.Add(LoadControl("../AdminUser/AdminUser.ascx"));
                    return;
                case "pr":
                    phcontrol.Controls.Add(LoadControl("u_setting_adm_siteproperties.ascx"));
                    return;
                case "PopUp":
                    phcontrol.Controls.Add(LoadControl("../Advertisings/Advertisings_PopUp.ascx"));
                    return;
                case "Screen":
                    phcontrol.Controls.Add(LoadControl("../Advertisings/Advertisings_Screen_left_right.ascx"));
                    return;
                case "set":
                    phcontrol.Controls.Add(LoadControl("u_adm_systemsetting.ascx"));
                    return;
                case "Noimg":
                    phcontrol.Controls.Add(LoadControl("SettingLogo.ascx"));
                    return;
            }
            this.su = "set";
            phcontrol.Controls.Add(LoadControl("u_adm_systemsetting.ascx"));
        }
        protected string returnCSS(string ctrol)
        {
            if ((this.su != "") && this.su.Equals(ctrol))
            {
                return "color:red";
            }
            return "";
        }
        private void InitializeComponent()
        {
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }
        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }
    }
}