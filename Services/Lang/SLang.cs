using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Entity;

namespace Services
{
    public class SLang
    {
        private static FLan db = new FLan();

        #region GET BY ID
        public static List<Lans> GET_BY_ID(string ilanID)
        {
            return db.GETBYID(ilanID);
        }
        #endregion

        #region LANG
        public static List<Lans> LANG(string Lang)
        {
            return db.LANG(Lang);
        }
        #endregion

        #region ALL
        public static List<Lans> ALL()
        {
            return db.ALL();
        }
        #endregion

        #region INSERT
        public static bool INSERT(Lans Obj)
        {
            return db.INSERT(Obj);
        }
        #endregion

        #region UPDATE
        public static bool UPDATE(Lans Obj)
        {
            return db.UPDATE(Obj);
        }
        #endregion

        #region DELETE
        public static void DELETE(string ID)
        {
            db.DELETE(ID);
        }
        #endregion

        #region Name_Text
        public static List<Lans> Name_Text(string sql)
        {
            return db.Name_Text(sql);
        }
        #endregion
        
    }
}
