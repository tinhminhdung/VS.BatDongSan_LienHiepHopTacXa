using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Entity;

namespace Services
{
    public class SAdvertisings
    {
        private static FAdvertisings db = new FAdvertisings();

        #region GET BY ID
        public static List<Entity.Advertisings> GETBYID(string ID)
        {
            return db.GetById(ID);
        }
        #endregion

        #region GET VALUES
        public static List<Entity.Advertisings> VALUES(string lang, string value, string Status)
        {
            return db.VALUES(lang, value, Status);
        }
        #endregion

        #region CATEGORY ADMIN
        public static List<Entity.Advertisings> CATEGORY_ADMIN(string lang, string value, string Status)
        {
            return db.CATEGORY_ADMIN(lang, value, Status);
        }
        #endregion

        #region GET BY ALL
        public static List<Entity.Advertisings> GETBYALL()
        {
            return db.GetByAll();
        }
        #endregion

        #region INSERT
        public static bool INSERT(Entity.Advertisings Obj)
        {
            return db.INSERT(Obj);
        }
        #endregion

        #region UPDATE 
        public static bool UPDATE(Entity.Advertisings Obj)
        {
            return db.UPDATE(Obj);
        }
        #endregion

        #region UPDATE 2
        public static bool UPDATE2(string images, string vimg)
        {
            return db.UPDATE2(images, vimg);
        }
        #endregion

        #region UPDATE VIEW
        public static bool UPDATE_VIEW(string images)
        {
            return db.UPDATEVIEWS(images);
        }
        #endregion

        #region CATE UPDATE
        public static bool CATEUPDATE(string images, string Status)
        {
            return db.CATE_UPDATE(images, Status);
        }
        #endregion

        #region DELETE
        public static void DELETE(string ID)
        {
            db.DELETE(ID);
        }
        #endregion      
     
        #region Name_StoredProcedure
        public static List<Entity.Advertisings> Name_StoredProcedure(string Name_StoredProcedure)
        {
            return db.Name_StoredProcedure(Name_StoredProcedure);
        }
        #endregion

        #region Name_Text
        public static List<Entity.Advertisings> Name_Text(string Name_Text)
        {
            return db.Name_Text(Name_Text);
        }
        #endregion

    }
}
