using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;

namespace VS.ECommerce_MVC.cms.Admin.Products
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
                case "ManagementPrice":
                    phcontrol.Controls.Add(LoadControl("ManagementPrice.ascx"));
                    return;
                case "Manufacturer":
                    phcontrol.Controls.Add(LoadControl("Manufacturer.ascx"));
                    return;
                case "pro":
                    phcontrol.Controls.Add(LoadControl("CProducts.ascx"));
                    return;
                case "images":
                    phcontrol.Controls.Add(LoadControl("Album.ascx"));
                    return;
                case "Posts":
                    phcontrol.Controls.Add(LoadControl("Guide_Posts.ascx"));
                    return;
                case "set":
                    phcontrol.Controls.Add(LoadControl("Settings.ascx"));
                    return;
                case "items":
                    phcontrol.Controls.Add(LoadControl("MProducts.ascx"));
                    return;
                case "carts":
                    phcontrol.Controls.Add(LoadControl("Cart.ascx"));
                    return;
                case "Size":
                    phcontrol.Controls.Add(LoadControl("Size.ascx"));
                    return;
                case "Color":
                    phcontrol.Controls.Add(LoadControl("Color.ascx"));
                    return;
            }
            this.su = "pro";
            phcontrol.Controls.Add(LoadControl("CProducts.ascx"));
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