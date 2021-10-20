using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Entity;


namespace Services
{
    public class SYahoo
    {
        #region language
        public static string Language
        {
            get
            {
                string language = "VIE";
                if (System.Web.HttpContext.Current.Session["language"] != null)
                {
                    language = System.Web.HttpContext.Current.Session["language"].ToString();
                }
                return language;
            }
        }
        #endregion
        private static FYahooMessenger db = new FYahooMessenger();

        #region GET BY ID
        public static List<YahooMessenger> GET_BY_ID(string ID)
        {
            return db.GETBYID(ID);
        }
        #endregion

        #region GET BY ALL
        public static List<YahooMessenger> GET_BY_ALL(string Lang)
        {
            return db.GETBYALL(Lang);
        }
        #endregion

        #region INSERT
        public static bool INSERT(YahooMessenger Obj)
        {
            return db.INSERT(Obj);
        }
        #endregion

        #region UPDATE
        public static bool UPDATE(YahooMessenger Obj)
        {
            return db.UPDATE(Obj);
        }
        #endregion

        #region CATE UPDATE
        public static bool CATE_UPDATE(string inick, string Status)
        {
            return db.CATEUPDATE(inick, Status);
        }
        #endregion

        #region DELETE
        public static void DELETE(string ID)
        {
            db.DELETE(ID);
        }
        #endregion

        #region YahooMessengers
        public static string YahooMessengers()
        {
            System.Text.StringBuilder strb = new System.Text.StringBuilder();
            List<Entity.YahooMessenger> dt = SYahoo.GET_BY_ALL(Language);
            if (dt.Count > 0)
            {
                for (int i = 0; i < dt.Count; i++)
                {
                    if (dt[i].Type.ToString() == "2")
                    {
                        strb.AppendLine("<div class=\"nickName\"><a href=\"skype:" + dt[i].Nick + "?chat\"><img src=\"/Resources/images/skype.png\"  title=\"skype\" alt=\"skype\"  /></a></div>");
                    }
                    else if (dt[i].Type.ToString() == "4")
                    {
                        strb.AppendLine("<div class=\"nickName\"><a href=\"viber://add?number=" + dt[i].Phone + "\"><img src=\"/Resources/images/Viber.png\"  title=\"Viber\" alt=\"Viber\" style=\"text-decoration: none; width:25px;\" /></a></div>");
                    }
                    else if (dt[i].Type.ToString() == "1")
                    {
                        strb.AppendLine("<div class=\"nickName\"><a href=\"https://zalo.me/" + dt[i].Phone + "\" style=\"text-decoration: none; width:25px;\"><img src=\"/Resources/images/zalo.png\"  title=\"zalo\" alt=\"zalo\" style=\"text-decoration: none; width:25px;\" /></a></div>");
                    }
                    else if (dt[i].Type.ToString() == "3")
                    {
                        strb.AppendLine("<div class=\"nickName\"><a target=\"_blank\" href=\"https://www.facebook.com/messages/t/" + dt[i].Nick + "\" style=\"text-decoration: none; width:25px;\"><img src=\"/Resources/images/facebook.png\"  title=\"facebook\" alt=\"zalo\" style=\"text-decoration: none; width:25px;\" /></a></div>");
                    }
                }
            }
            return strb.ToString();
        }
        #endregion

        #region Name_StoredProcedure
        public static List<YahooMessenger> Name_StoredProcedure(string Name_StoredProcedure)
        {
            return db.Name_StoredProcedure(Name_StoredProcedure);
        }
        #endregion

        #region Name_Text
        public static List<YahooMessenger> Name_Text(string Name_Text)
        {
            return db.Name_Text(Name_Text);
        }
        #endregion
    }
}
