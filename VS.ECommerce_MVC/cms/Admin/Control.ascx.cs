using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS.ECommerce_MVC.cms.Admin
{
    public partial class Control : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (MoreAll.MoreAll.GetCookie("UName") == null || MoreAll.MoreAll.GetCookie("UName").ToString().Equals(""))
                {
                    phcontrol.Controls.Add(base.LoadControl("login.ascx"));
                }
                else
                {
                    try
                    {
                        phcontrol.Controls.Add(base.LoadControl("main.ascx"));
                    }
                    catch (Exception)
                    {
                        base.Response.Redirect("admin.aspx");
                    }
                }
            }
            catch (Exception)
            { }
        }
    }
}