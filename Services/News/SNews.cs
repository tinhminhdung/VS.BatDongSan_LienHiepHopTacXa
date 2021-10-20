using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Entity;

namespace Services
{
    public class SNews
    {
        private static FNews db = new FNews();

        #region CATEGORY_PHANTRANG_ADMIN
        public static List<News> CATEGORY_PHANTRANG_ADMIN1(string icid, string filter, string lang)
        {
            return db.CATEGORY_PHANTRANG_ADMIN1(icid, filter, lang);
        }
        public static List<News> CATEGORY_PHANTRANG_ADMIN2(string icid, string filter, string lang, string sapxep, int PageIndex, int Tongpage)
        {
            return db.CATEGORY_PHANTRANG_ADMIN2(icid, filter, lang, sapxep, PageIndex, Tongpage);
        }
        #endregion

        #region CATEGORY ADMIN
        public static List<News> CATEGORY_ADMIN(string orderby, string searchkeyword, string[] searchfields, string icID, string lang, string Status)
        {
            return db.CATEGORYADMIN(orderby, searchkeyword, searchfields, icID, lang, Status);
        }
        #endregion

        #region NEWS INDEX
        public static List<News> INDEX(string lang, string Status)
        {
            return db.NEWS_INDEX(lang, Status);
        }
        #endregion

        #region NEWS CATEGORY
        public static List<News> CATEGORY(string icID, string lang, string Status)
        {
            return db.CATEGORY(icID, lang, Status);
        }
        #endregion

        //#region CATEGORY_PHANTRANG
        //public static List<Category_News> CATEGORY_PHANTRANG(string icid, string lang, string Status, int PageIndex, int Tongpage)
        //{
        //    return db.CATEGORY_PHANTRANG(icid, lang, Status, PageIndex, Tongpage);
        //}
        //#endregion

        #region SearchNews
        public static List<Category_News> SearchNews(string keyword, string lang, string Status, int PageIndex, ref int TotalRecords, int Tongpage)
        {
            return db.SearchNews(keyword, lang, Status, PageIndex, ref TotalRecords, Tongpage);
        }
        #endregion


        #region CATEGORY_PHANTRANG
        public static List<Category_News> CATEGORY_PHANTRANG(string icid, string lang, string Status, int PageIndex, ref int TotalRecords, int Tongpage)
        {
            return db.CATEGORY_PHANTRANG(icid,lang, Status, PageIndex, ref TotalRecords, Tongpage);
        }
        #endregion
        #region News_All
        public static List<Category_News> News_All(string lang, string Status, int PageIndex, ref int TotalRecords, int Tongpage)
        {
            return db.News_All(lang, Status, PageIndex, ref TotalRecords, Tongpage);
        }
        #endregion

        #region MORE ICID
        public static List<News> MORE_ICID(string icID)
        {
            return db.MORE_ICID(icID);
        }
        #endregion

        #region GET BY ID
        public static List<News> GETBYID(string ID)
        {
            return db.GETBYID(ID);
        }
        #endregion

        #region GET BY ALL
        public static List<News> GETBYALL(string Lang)
        {
            return db.GETBYALL(Lang);
        }
        #endregion

        #region GET BY TOP
        public static List<News> GETBYTOP(string Top, string Where, string Order)
        {
            return db.News_GETBYTOP(Top, Where, Order);
        }
        #endregion

        #region INSERT
        public static bool News_INSERT(News obj)
        {
            return db.INSERT(obj);
        }
        #endregion

        #region UPDATE
        public static bool News_UPDATE(News obj)
        {
            return db.UPDATE(obj);
        }
        #endregion

        #region DELETE
        public static void News_DELETE(string ID)
        {
            db.News_DELETE(ID);
        }
        #endregion

        #region CATE DELETE ICID
        public static void News_CATE_DELETE_ICID(string icID)
        {
            db.News_CATE_DELETE_ICID(icID);
        }
        #endregion

        #region DETAIL NEWS RELATED
        public static List<News> DETAIL_NEWS_RELATED(string inID)
        {
            return db.DETAIL_NEWS_RELATED(inID);
        }
        #endregion

        #region SEARCH
        public static List<News> SEARCH(string keyword, string lang)
        {
            return db.SEARCH(keyword, lang);
        }
        #endregion

        #region SEARCH
        public static List<News> SearchNews(string keyword, string lang)
        {
            return db.SearchNews(keyword, lang);
        }
        #endregion

        #region GET DETAIL BY ICID
        public static List<News> GET_DETAIL_ICID(string imcID)
        {
            return db.GET_DETAIL_BYICID(imcID);
        }
        #endregion

        #region UPDATE IMG
        public static bool News_UPDATEIMG(string inID)
        {
            return db.UPDATEIMG(inID);
        }
        #endregion

        #region UPDATE DATETIME
        public static List<News> UPDATE_DATETIME(string inID, DateTime Create_Date, DateTime Modified_Date)
        {
            return db.Update_datetime(inID, Create_Date, Modified_Date);
        }
        #endregion

        #region GET DETAIL BY ID
        public static List<News> GET_DETAIL_BYID(string inID)
        {
            return db.GETDETAIL_BYID(inID);
        }
        #endregion

        #region NEWS OTHER LAST
        public static List<Category_News> OTHERLAST(string nID, int top, string lang, string icID)
        {
            return db.NEWS_OTHERLAST(nID, top, lang, icID);
        }
        #endregion

        #region NEWS OTEHR FIRST
        public static List<Category_News> OTHERFIRST(string nID, int top, string lang, string icID)
        {
            return db.NEWS_OTHERFIRST(nID, top, lang, icID);
        }
        #endregion

        #region UPDATE VIEW TIMES
        public static List<News> UPDATEVIEWS_TIMES(string inID)
        {
            return db.UPDATE_VIEW_TIME(inID);
        }
        #endregion

        #region UPDATE STATUS
        public static List<News> UPDATESTATUS(string Status, string inID)
        {
            return db.UPDATE_STATUS(Status, inID);
        }
        #endregion

        #region UPDATE News
        public static List<News> UPDATE_News(string News, string inID)
        {
            return db.UPDATE_News(News, inID);
        }
        #endregion

        #region CHECK DATA
        public static List<News> CHECKDATA(string inID, string Chekdata, DateTime Create_Date, DateTime Modified_Date)
        {
            return db.Chekdata(inID, Chekdata, Create_Date, Modified_Date);
        }
        #endregion

        #region UPDATE DATETIME
        public static List<News> UPDATE_DATETIME(string inID, string Modified_Date)
        {
            return db.UPDATE_DATETIME(inID, Modified_Date);
        }
        #endregion

        #region GET Text Sql ALL
        public static List<News> Text(string Text)
        {
            return db.Text(Text);
        }
        #endregion

        #region Name_StoredProcedure
        public static List<News> Name_StoredProcedure(string Name_StoredProcedure)
        {
            return db.Name_StoredProcedure(Name_StoredProcedure);
        }
        #endregion

        #region Name_Text
        public static List<News> Name_Text(string Name_Text)
        {
            return db.Name_Text(Name_Text);
        }
        #endregion

        #region News_Count
        public static List<News_Count> News_Count(string Name_Text)
        {
            return db.News_Count(Name_Text);
        }
        #endregion

        #region Name_Text_Rg
        //inid,TangName,Title,Images,ImagesSmall,Brief,Create_Date 
        public static List<Category_News> Name_Text_Rg(string Name_Text)
        {
            return db.Name_Text_Rg(Name_Text);
        }
        #endregion

    }
}
