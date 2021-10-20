using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VS.ECommerce_MVC;

namespace VS.E_Commerce
{
    public partial class Autologon : System.Web.UI.Page
    {
        DatalinqDataContext db = new DatalinqDataContext();
        string U1 = "";
        string ID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["U1"] != null && !Request["U1"].Equals(""))
            {
                U1 = Request["U1"];
            }
            if (Request["ID"] != null && !Request["ID"].Equals(""))
            {
                ID = Request["ID"];
            }
            if (MoreAll.MoreAll.GetCookies("UName") != "")
            {
                List<Entity.Member> table = SMember.Name_Text("select * from Members where [Key]='" + U1.Trim().ToLower() + "' and ID=" + (ID.Trim().ToLower()) + " ");// and DuyetTienDanap=1 phải nạp tiền xong mới cho đăng nhập
                if (table.Count > 0)
                {
                    MoreAll.MoreAll.SetCookie("Members", table[0].DienThoai.ToString(), 5000);
                    MoreAll.MoreAll.SetCookie("MembersUser", table[0].HoVaTen.ToString().ToLower(), 5000);
                    MoreAll.MoreAll.SetCookie("MembersID", table[0].ID.ToString(), 5000);
                    Response.Redirect("/");
                }
            }
            else
            {
                Response.Redirect("/");
            }
        }
        protected string CheckBrowserCaps()
        {
            System.Web.HttpBrowserCapabilities myBrowserCaps = Request.Browser;
            if (((System.Web.Configuration.HttpCapabilitiesBase)myBrowserCaps).IsMobileDevice)
            {
                return "Mobile : " + myBrowserCaps.Browser + " <br /><span style=\"color:red; font-weight:bold\"> Admin:  " + MoreAll.MoreAll.GetCookies("UName").ToString() + "</span>";
            }
            return "Destop: " + myBrowserCaps.Browser + "  <br /><span style=\"color:red; font-weight:bold\"> Admin:  " + MoreAll.MoreAll.GetCookies("UName").ToString() + "</span>";
        }
    }
}