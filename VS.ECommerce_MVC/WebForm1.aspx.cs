using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace VS.ECommerce_MVC
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string price = "112000,00000";
            string chuois = "0";
            if (price != "0")
            {
                string Gia = " and (";
                string[] strArray = price.ToString().Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    Gia += (i == 0 ? "" : " OR ") + "(Price between (" + (strArray[i].ToString()) + ") and (" + (strArray[i].ToString()) + ")) ";
                }
                chuois += Gia + ")";
            }
            Response.Write(chuois);

            //List<Entity.Products> iitem = SProducts.GetByAll("VIE");
            //if (iitem.Count() > 0)
            //{
            //    foreach (var item in iitem)
            //    {
            //        SProducts.Name_Text("update products set search=N'" + MoreAll.RewriteURLNew.NameSearch(item.Name) + "'  where ipid=" + item.ipid + "");
            //    }
            //}
        }
        public string ParseRssFile()
        {
            XmlDocument rssXmlDoc = new XmlDocument();
            rssXmlDoc.Load("https://vnexpress.net/rss/thoi-su.rss");
            XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");
            StringBuilder rssContent = new StringBuilder();
            foreach (XmlNode rssNode in rssNodes)
            {
                XmlNode rssSubNode = rssNode.SelectSingleNode("title");
                string title = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("link");
                string link = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("description");
                string description = rssSubNode != null ? rssSubNode.InnerText : "";

                rssContent.Append("<a href='" + link + "'>" + title + "</a><br>" + description);
            }
            return rssContent.ToString();
        }
    }
}