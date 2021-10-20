using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Entity;

namespace Services
{
    public class SMarketing
    {
        private static FMarketing db = new FMarketing();

        #region CATEGORY ADMIN
        public static List<Marketing> CategoryAdmin(string Status)
        {
            return db.CATEGORYADMIN(Status);
        }
        #endregion

        #region SEARCH
        public static List<Marketing> SEARCH(string searchkeyword, string[] searchfields)
        {
            return db.SEARCH(searchkeyword, searchfields);
        }
        #endregion

        #region GET BY ID
        public static List<Marketing> GET_BY_ID(string ID)
        {
            return db.GETBYID(ID);
        }
        #endregion

        #region GET BY ALL
        public static List<Marketing> GET_BYALL()
        {
            return db.GETBYALL();
        }
        #endregion

        #region INSERT
        public static bool INSERT(Marketing data)
        {
            return db.INSERT(data);
        }
        #endregion

        #region UPDATE
        public static bool UPDATE(Marketing data)
        {
            return db.UPDATE(data);
        }
        #endregion

        #region CATE  UPDATE
        public static bool CATE_UPDATE(string IDMarketing, string istatus)
        {
            return db.CATEUPDATE(IDMarketing, istatus);
        }
        #endregion

        #region DELETE
        public static void DELETE(string ID)
        {
            db.DELETE(ID);
        }
        #endregion

        #region Name_Text
        public static List<Marketing> Name_Text(string Name_Text)
        {
            return db.Name_Text(Name_Text);
        }
        #endregion
    }
}
