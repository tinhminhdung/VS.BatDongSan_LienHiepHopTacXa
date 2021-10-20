using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Entity;

namespace Services
{
    public class SNfooter
    {
        private static FNfooter db = new FNfooter();

        #region CATEGORY ADMIN
        public static List<Entity.Nfooter> CATEGORY_ADMIN(string orderby, string searchkeyword, string[] searchfields, string icID,string lang, string Status)
        {
            return db.CATEGORYADMIN(orderby, searchkeyword, searchfields, icID, lang, Status);
        }
        #endregion

        #region Nfooter INDEX
        public static List<Entity.Nfooter> INDEX(string lang, string Status)
        {
            return db.Nfooter_INDEX(lang, Status);
        }
        #endregion

        #region Nfooter CATEGORY
        public static List<Entity.Nfooter> CATEGORY(string icID, string lang, string Status)
        {
            return db.CATEGORY(icID, lang, Status);
        }
        #endregion

        #region MORE ICID
        public static List<Entity.Nfooter> MORE_ICID(string icID)
        {
            return db.MORE_ICID(icID);
        }
        #endregion

        #region GET BY ID
        public static List<Entity.Nfooter> GETBYID(string ID)
        {
            return db.GETBYID(ID);
        }
        #endregion

        #region GET BY ALL
        public static List<Entity.Nfooter> GETBYALL(string Lang)
        {
            return db.GETBYALL(Lang);
        }
        #endregion

        #region GET BY TOP
        public static List<Entity.Nfooter> GETBYTOP(string Top, string Where, string Order)
        {
            return db.Nfooter_GETBYTOP(Top, Where, Order);
        }
        #endregion

        #region INSERT 
        public static bool Nfooter_INSERT(Nfooter obj)
        {
            return db.INSERT(obj);
        }
        #endregion

        #region UPDATE
        public static bool Nfooter_UPDATE(Nfooter obj)
        {
            return db.UPDATE(obj);
        }
        #endregion

        #region DELETE
        public static void Nfooter_DELETE(string ID)
        {
            db.Nfooter_DELETE(ID);
        }
        #endregion

        #region CATE DELETE ICID
        public static void Nfooter_CATE_DELETE_ICID(string icID)
        {
            db.Nfooter_CATE_DELETE_ICID(icID);
        }
        #endregion

        #region DETAIL Nfooter RELATED
        public static List<Entity.Nfooter> DETAIL_Nfooter_RELATED(string inID)
        {
            return db.DETAIL_Nfooter_RELATED(inID);
        }
        #endregion

        #region SEARCH
        public static List<Entity.Nfooter> SEARCH(string keyword, string lang)
        {
            return db.SEARCH(keyword, lang);
        }
        #endregion

        #region SEARCH
        public static List<Entity.Nfooter> SearchNfooter(string keyword, string lang)
        {
            return db.SearchNfooter(keyword, lang);
        }
        #endregion

        #region GET DETAIL BY ICID
        public static List<Entity.Nfooter> GET_DETAIL_ICID(string imcID)
        {
            return db.GET_DETAIL_BYICID(imcID);
        }
        #endregion

        #region UPDATE IMG
        public static bool Nfooter_UPDATEIMG(string inID)
        {
            return db.UPDATEIMG(inID);
        }
        #endregion

        #region UPDATE DATETIME
        public static List<Entity.Nfooter> UPDATE_DATETIME(string inID,  DateTime Create_Date, DateTime Modified_Date)
        {
            return db.Update_datetime(inID, Create_Date, Modified_Date);
        }
        #endregion

        #region GET DETAIL BY ID
        public static List<Entity.Nfooter> GET_DETAIL_BYID(string inID)
        {
            return db.GETDETAIL_BYID(inID);
        }
        #endregion

        #region Nfooter OTHER LAST
        public static List<Entity.Nfooter> OTHERLAST(string nID, int top, string lang, string icID)
        {
            return db.Nfooter_OTHERLAST(nID, top, lang, icID);
        }
        #endregion

        #region Nfooter OTEHR FIRST
        public static List<Entity.Nfooter> OTHERFIRST(string nID, int top, string lang, string icID)
        {
            return db.Nfooter_OTHERFIRST(nID, top, lang, icID);
        }
        #endregion

        #region UPDATE VIEW TIMES
        public static List<Entity.Nfooter> UPDATEVIEWS_TIMES(string inID)
        {
            return db.UPDATE_VIEW_TIME(inID);
        }
        #endregion

        #region UPDATE STATUS
        public static List<Entity.Nfooter> UPDATESTATUS(string Status, string inID)
        {
            return db.UPDATE_STATUS(Status, inID);
        }
        #endregion

        #region UPDATE Nfooter
        public static List<Entity.Nfooter> UPDATE_Nfooter(string Nfooter, string inID)
        {
            return db.UPDATE_Nfooter(Nfooter, inID);
        }
        #endregion

        #region CHECK DATA
        public static List<Entity.Nfooter> CHECKDATA(string inID, string Chekdata, DateTime Create_Date, DateTime Modified_Date)
        {
            return db.Chekdata(inID, Chekdata, Create_Date, Modified_Date);
        }
        #endregion

        #region UPDATE DATETIME
        public static List<Entity.Nfooter> UPDATE_DATETIME(string inID,string Modified_Date)
        {
            return db.UPDATE_DATETIME(inID, Modified_Date);
        }
        #endregion

        #region GET Text Sql ALL
        public static List<Entity.Nfooter> Text(string Text)
        {
            return db.Text(Text);
        }
        #endregion

        #region Name_StoredProcedure
        public static List<Entity.Nfooter> Name_StoredProcedure(string Name_StoredProcedure)
        {
            return db.Name_StoredProcedure(Name_StoredProcedure);
        }
        #endregion

        #region Name_Text
        public static List<Entity.Nfooter> Name_Text(string Name_Text)
        {
            return db.Name_Text(Name_Text);
        }
        #endregion
    }
}
