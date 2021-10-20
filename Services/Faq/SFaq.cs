using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Entity;

namespace Services
{
    public class SFaq
    {
        private static FFaq db = new FFaq();

        #region CATEGORY ADMIN
        public static List<Faq> CATEGORY_ADMIN(string orderby, string searchkeyword, string[] searchfields,string lang, string Status)
        {
            return db.CATEGORYADMIN(orderby, searchkeyword, searchfields, lang, Status);
        }
        #endregion

        #region Faq CATEGORY
        public static List<Faq> CATEGORY(string lang, string Status)
        {
            return db.CATEGORY(lang, Status);
        }
        #endregion
      
        #region GET BY ID
        public static List<Faq> GETBYID(string ID)
        {
            return db.GETBYID(ID);
        }
        #endregion

        #region GET BY ALL
        public static List<Faq> GETBYALL(string Lang)
        {
            return db.GETBYALL(Lang);
        }
        #endregion
        
        #region INSERT 
        public static bool Faq_INSERT(Faq obj)
        {
            return db.INSERT(obj);
        }
        #endregion

        #region UPDATE
        public static bool Faq_UPDATE(Faq obj)
        {
            return db.UPDATE(obj);
        }
        #endregion

        #region DELETE
        public static void Faq_DELETE(string ID)
        {
            db.Faq_DELETE(ID);
        }
        #endregion

        #region SEARCH
        public static List<Faq> SEARCH(string keyword, string lang)
        {
            return db.SEARCH(keyword, lang);
        }
        #endregion

        #region GET DETAIL BY ICID
        public static List<Faq> GET_DETAIL_ICID(string imcID)
        {
            return db.GET_DETAIL_BYICID(imcID);
        }
        #endregion

        #region UPDATE DATETIME
        public static List<Faq> UPDATE_DATETIME(string inID,  DateTime Create_Date, DateTime Modified_Date)
        {
            return db.Update_datetime(inID, Create_Date, Modified_Date);
        }
        #endregion

        #region GET DETAIL BY ID
        public static List<Faq> GET_DETAIL_BYID(string inID)
        {
            return db.GETDETAIL_BYID(inID);
        }
        #endregion

        #region Faq OTHER LAST
        public static List<Faq> OTHERLAST(string nID, int top, string lang)
        {
            return db.Faq_OTHERLAST(nID, top, lang);
        }
        #endregion

        #region Faq OTEHR FIRST
        public static List<Faq> OTHERFIRST(string nID, int top, string lang)
        {
            return db.Faq_OTHERFIRST(nID, top, lang);
        }
        #endregion

        #region UPDATE VIEW TIMES
        public static List<Faq> UPDATEVIEWS_TIMES(string inID)
        {
            return db.UPDATE_VIEW_TIME(inID);
        }
        #endregion

        #region UPDATE STATUS
        public static List<Faq> UPDATESTATUS(string Status, string inID)
        {
            return db.UPDATE_STATUS(Status, inID);
        }
        #endregion

        #region UPDATE News
        public static List<Faq> UPDATE_News(string News, string inID)
        {
            return db.UPDATE_News(News, inID);
        }
        #endregion

        #region CHECK DATA
        public static List<Faq> CHECKDATA(string inID, string Chekdata, DateTime Create_Date, DateTime Modified_Date)
        {
            return db.Chekdata(inID, Chekdata, Create_Date, Modified_Date);
        }
        #endregion

        #region UPDATE DATETIME
        public static List<Faq> UPDATE_DATETIME(string inID,string Modified_Date)
        {
            return db.UPDATE_DATETIME(inID, Modified_Date);
        }
        #endregion

        #region GET Text Sql ALL
        public static List<Faq> Text(string Text)
        {
            return db.Text(Text);
        }
        #endregion

        #region Name_StoredProcedure
        public static List<Faq> Name_StoredProcedure(string Name_StoredProcedure)
        {
            return db.Name_StoredProcedure(Name_StoredProcedure);
        }
        #endregion

        #region Name_Text
        public static List<Faq> Name_Text(string Name_Text)
        {
            return db.Name_Text(Name_Text);
        }
        #endregion
    }
}
