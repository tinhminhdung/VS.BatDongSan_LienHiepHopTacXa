using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;

namespace VS.ECommerce_MVC.cms.Admin.Advertisings
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
                case "Posts":
                    phcontrol.Controls.Add(LoadControl("Guide_Posts.ascx"));
                    return;
                case "cate":
                    phcontrol.Controls.Add(LoadControl("Category.ascx"));
                    return;
                case "Advertisings":
                    phcontrol.Controls.Add(LoadControl("Advertising.ascx"));
                    return;
                case "Advertisings1":
                    phcontrol.Controls.Add(LoadControl("Advertising_banner.ascx"));
                    return;
                case "DMAdvertising":
                    phcontrol.Controls.Add(LoadControl("DMAdvertising.ascx"));
                    return;

                case "DMAdvertisingNews":
                    phcontrol.Controls.Add(LoadControl("DMAdvertisingNews.ascx"));
                    return;
            }
            this.su = "Advertisings";
            phcontrol.Controls.Add(LoadControl("Advertising.ascx"));
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
            return Captionlanguage.GetLabel(id, "VIE");
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }
    }
}