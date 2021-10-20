using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using Services;
using MoreAll;

namespace VS.ECommerce_MVC.cms.Admin.M_News
{
    public partial class News_Related : System.Web.UI.UserControl
    {
        string inid = "-1";
        private string language = Captionlanguage.Language;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["language"] != null)
            {
                this.language = System.Web.HttpContext.Current.Session["language"].ToString();
            }
            else
            {
                System.Web.HttpContext.Current.Session["language"] = this.language;
                this.language = System.Web.HttpContext.Current.Session["language"].ToString();
            }
            if (Request["inid"] != null && !Request["inid"].Equals(""))
            {
                this.hdinid.Value = Request["inid"];
            }
            if (!base.IsPostBack)
            {
                this.loaditems();
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            this.searchrelateditems();
        }

        protected void Delete_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Bạn chắc chắn là bạn muốn xóa ?')";
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }

        private void loaditems()
        {
            List<Entity.News> table = SNews.DETAIL_NEWS_RELATED(Sub_Menu());
            this.rp_itemslist.DataSource = table;
            this.rp_itemslist.DataBind();
        }

        protected string Sub_Menu()
        {
            string submn = "0";
            List<Entity.News_Related> dt = SNews_Related.DETAIL_INID(hdinid.Value);
            for (int i = 0; i < dt.Count; i++)
            {
                submn = submn + "," + dt[i].irelated.ToString();
            }
            return submn;
        }

        protected void rp_itemslist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string str2;
            string str = e.CommandName.Trim();
            e.CommandArgument.ToString().Trim();
            if (((str2 = str) != null) && (str2 == "Delete"))
            {
                try
                {
                    SNews_Related.DELETE_RELATED(e.CommandArgument.ToString());
                    this.loaditems();
                }
                catch (Exception)
                {
                }
            }
        }

        protected void rp_searcheditems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Entity.News_Related obj = new Entity.News_Related();
            #region MyRegion
            obj.inid = int.Parse(this.hdinid.Value);
            obj.irelated = int.Parse(e.CommandArgument.ToString());
            #endregion
            if (e.CommandName.ToString().Equals("addtorelateditems"))
            {
                SNews_Related.INSERT(obj);
                this.loaditems();
            }
        }

        private void searchrelateditems()
        {
            if (this.txtkeyword.Text.Trim().Length > 0)
            {
                List<News> table = SNews.SEARCH(this.txtkeyword.Text, language);
                this.rp_searcheditems.DataSource = table;
                this.rp_searcheditems.DataBind();
            }
        }
    }
}