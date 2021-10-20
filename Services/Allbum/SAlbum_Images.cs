using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Entity;

namespace Services
{
    public class SAlbum_Images
    {
        private static FAlbum_Images db = new FAlbum_Images();

        #region ALBUM IMAGES INSERT
        public static bool ALBUM_IMAGES_INSERT(Album_Images obj)
        {
            return db.INSERT(obj);
        }
        #endregion

        #region ALBUM IMAGES UPDATE
        public static bool ALBUM_IMAGES_UPDATE(Album_Images obj)
        {
            return db.UPDATE(obj);
        }
        #endregion

        #region ALBUM IMAGES DELETE
        public static void ALBUM_IMAGES_DELETE(string ID)
        {
            db.DELETE(ID);
        }
        #endregion

        #region GET BY ID
        public static List<Album_Images> GET_BY_ID(string ID)
        {
            return db.GETBYID(ID);
        }
        #endregion

        #region GET BY ALL
        public static List<Album_Images> GET_BY_ALL()
        {
            return db.GETBYALL();
        }
        #endregion

        #region GET DETAIL BY MENU ID
        public static List<Album_Images> GET_DETAIL_BY_MENUID(string ID_Menu, string imicID)
        {
            return db.GET_DETAIL_MENUID(ID_Menu, imicID);
        }
        #endregion

        #region CATE DELETE MENU ID
        public static void CATE_DELETE_MENU_ID(string Menu_ID, string imicID)
        {
            db.CATE_DELETE_MENUID(Menu_ID, imicID);
        }
        #endregion

        #region CATE DELETE MENU ALB
        public static void CATE_DELETE_MENU_ALB(string Menu_ALB)
        {
            db.CATE_DELETE_MENUALB(Menu_ALB);
        }
        #endregion

        #region CATEGORY ADMIN
        public static List<Album_Images> CATEGORY_ADMIN(string orderby, string searchkeyword, string[] searchfields, string Menu_ID, string imcID, string lang, string Status)
        {
            return db.CATEGORY_ADMIN(orderby, searchkeyword, searchfields, Menu_ID, imcID, lang, Status);
        }
        #endregion

        #region UPDATE STATUS
        public static bool UPDATE_STATUS(string ID, string status)
        {
            return db.UPDATESTATUS(ID, status);
        }
        #endregion

        #region UPDATE DATETIME
        public static bool UPDATE_DATETIME(string ID, bool updatecreatedate, string Modified_Date)
        {
            return db.UPDATE_DATETIME(ID, updatecreatedate, Modified_Date);
        }
        #endregion

        #region GET DETAIL BY ID
        public static List<Album_Images> GET_DETAIL_BYID(string ID)
        {
            return db.GETDETAILBYID(ID);
        }
        #endregion

        #region UPDATE IMG
        public static bool UPDATE_IMG(string ID, string Images, string ImagesSmall)
        {
            return db.Album_UPDATE_IMG(ID, Images, ImagesSmall);
        }
        #endregion

        #region GET DETAIL BY MENU ALB
        public static List<Album_Images> GET_DETAIL_BY_MENUALB(string Menu_ALB)
        {
            return db.GETDETAILBY_MENUALB(Menu_ALB);
        }
        #endregion

        #region Name_StoredProcedure
        public static List<Album_Images> Name_StoredProcedure(string Name_StoredProcedure)
        {
            return db.Name_StoredProcedure(Name_StoredProcedure);
        }
        #endregion

        #region Name_Text
        public static List<Album_Images> Name_Text(string Name_Text)
        {
            return db.Name_Text(Name_Text);
        }
        #endregion
    }
}
