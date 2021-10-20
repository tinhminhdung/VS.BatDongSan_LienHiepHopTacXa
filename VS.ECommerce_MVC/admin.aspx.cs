using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using AjaxPro;
using Services;
using System.Data;
using System.IO;
using System.Web.Services;
using Entity;

namespace VS.ECommerce_MVC
{
    public partial class admin1 : System.Web.UI.Page
    {
        string ssl = "http://";
        private string lang = Captionlanguage.Language;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Commond.Setting("SSL").Equals("1"))
            {
                ssl = "https://";
            }
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
                    website();
                }
                catch (Exception)
                { }
            }
            #region icon
            string str = Commond.Setting("Icon");
            LiteralControl lticon = new LiteralControl("<link rel='icon' href='" + str + "' type='image/x-icon' /><link rel='shortcut icon' href='" + str + "' type='image/x-icon' />");
            Page.Header.Controls.Add(lticon);
            #endregion
        }
        public void website()
        {
            string bc = Request.Url.Authority + Request.RawUrl.ToString();
            if (!bc.Contains("localhost"))
            {
                if (Request["su"] == null)
                {
                    if (MoreAll.Other.Giatri("Redirectwebsite") != "")
                    {
                        Response.Redirect(ssl + MoreAll.Other.Giatri("Redirectwebsite"));
                    }
                }
            }
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        //Id, Sql, Status

        // vi du: 10,News,status
        [WebMethod]
        public static string SqlUpdateStatus(string id, string sql, string status)
        {
            if (sql == "News")
            {
                List<Entity.News> dtdetail = SNews.GETBYID(id);
                if (dtdetail.Count > 0)
                {
                    if (dtdetail[0].Status.ToString() == "0")
                    {
                        SNews.Name_Text("update News set [" + status + "] =1  where inid=" + id + "");
                    }
                    else
                    {
                        SNews.Name_Text("update News set [" + status + "] =0  where inid=" + id + "");
                    }
                }
            }
            return "";
        }

    }
}