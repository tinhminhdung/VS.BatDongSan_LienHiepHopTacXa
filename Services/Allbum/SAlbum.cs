using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Entity;

namespace Services
{
    public class SAlbum
    {
        private static FAlbum db = new FAlbum();

        #region CATEGORY_PHANTRANG_ADMIN
        public static List<Album> CATEGORY_PHANTRANG_ADMIN1(string icid, string filter, string lang)
        {
            return db.CATEGORY_PHANTRANG_ADMIN1(icid, filter, lang);
        }
        public static List<Album> CATEGORY_PHANTRANG_ADMIN2(string icid, string filter, string lang, string sapxep, int PageIndex, int Tongpage)
        {
            return db.CATEGORY_PHANTRANG_ADMIN2(icid, filter, lang, sapxep, PageIndex, Tongpage);
        }
        #endregion

        #region CATEGORY_PHANTRANG
        public static List<Album_RutGon> CATEGORY_PHANTRANG(string icid, string lang, string Status, int PageIndex, ref int TotalRecords, int Tongpage)
        {
            return db.CATEGORY_PHANTRANG(icid, lang, Status, PageIndex, ref TotalRecords, Tongpage);
        }
        #endregion

        #region INSERT
        public static bool INSERT(Album obj)
        {
            return db.INSERT(obj);
        }
        #endregion

        #region UPDATE
        public static bool UPDATE(Album obj)
        {
            return db.UPDATE(obj);
        }
        #endregion

        #region DELETE
        public static void DELETE(string ID)
        {
            db.DELETE(ID);
        }
        #endregion

        #region GET BY ID
        public static List<Album> GETBYID(string ID)
        {
            return db.GETBYID(ID);
        }
        #endregion

        #region GET BY ALL
        public static List<Album> GET_GY_ALL(string Lang)
        {
            return db.GETBYALL(Lang);
        }
        #endregion

        #region GET DETAIL BY MENU ID
        public static List<Album> GET_DETAIL_BY_MENUID(string ID_Menu, string imicID)
        {
            return db.GETDETAILBY_MENU_ID(ID_Menu, imicID);
        }
        #endregion

        #region CATE DELETE MENU ID
        public static void CATE_DELETE_MENUID(string Menu_ID, string imicID)
        {
            db.DELETE_CATEMENU_ID(Menu_ID, imicID);
        }
        #endregion

        #region CATEGORY ADMIN
        public static List<Album> CATEGORY_ADMIN(string orderby, string searchkeyword, string[] searchfields, string Menu_ID, string imcID, string lang, string Status)
        {
            return db.CATEGORY_ADMIN(orderby, searchkeyword, searchfields, Menu_ID, imcID, lang, Status);
        }
        #endregion

        #region UPDATE STATUS
        public static bool Album_UpdateStatus(string ID, string status)
        {
            return db.UPDATESTATUS(ID, status);
        }
        #endregion

        #region UPDATE Noi Bat
        public static bool Album_UpdateImagehot(string ID, string news)
        {
            return db.UpdateNoibat(ID, news);
        }
        #endregion

        #region ALBUM HOT
        public static List<Album> Album_NOIBAT(string Lang)
        {
            return db.NOIBAT(Lang);
        }
        #endregion

        #region GET DETAIL BY ID
        public static List<Album> GET_DETAIL_BYID(string ID)
        {
            return db.GETDETAIL_ID(ID);
        }
        #endregion

        #region UPDATE IMG
        public static bool UPDATE_IMG(string ID)
        {
            return db.UPDATE_IMG(ID);
        }
        #endregion

        #region CATEGORY
        public static List<Album> CATEGORY(string imID, string lang, string Status)
        {
            return db.CATEGORY(imID, lang, Status);
        }
        #endregion

        #region CHECK DATA
        public static List<Album> CHECKDATA(string ID, string Chekdata, DateTime Create_Date, DateTime Modified_Date)
        {
            return db.CHECKDATA(ID, Chekdata, Create_Date, Modified_Date);
        }
        #endregion

        #region UPDATE DATETIME
        public static List<Album> UPDATE_DATETIME(string ID, DateTime Create_Date, DateTime Modified_Date)
        {
            return db.UPDATE_DATETIME(ID, Modified_Date, Modified_Date);
        }
        #endregion

        #region Name_StoredProcedure
        public static List<Album> Name_StoredProcedure(string Name_StoredProcedure)
        {
            return db.Name_StoredProcedure(Name_StoredProcedure);
        }
        #endregion

        #region Name_Text
        public static List<Album> Name_Text(string Name_Text)
        {
            return db.Name_Text(Name_Text);
        }
        #endregion
          #region Name_Text_RG
        // ID,Title,Images,ImagesSmall,Create_Date,TangName,Anhnhieu
        public static List<Album_RutGon> Name_Text_RG(string Name_Text)
        {
            return db.Name_Text_RG(Name_Text);
        }
        #endregion
       
    }
}
