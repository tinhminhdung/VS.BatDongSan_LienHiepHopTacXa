using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Entity;

namespace Services
{
    public class SNews_Related
    {
        private static FNews_Related db = new FNews_Related();

        #region DETAIL ICID
        public static List<News_Related> DETAIL_INID(string inID)
        {
            return db.DETAIL_INID(inID);
        }
        #endregion

        #region INSERT
        public static bool INSERT(News_Related obj)
        {
            return db.Insert(obj);
        }
        #endregion

        #region DELETE
        public static void DELETE(string ID)
        {
            db.DELETE(ID);
        }
        #endregion

        #region DELETE RELATED
        public static void DELETE_RELATED(string irelated)
        {
            db.DELETE_RELATED(irelated);
        }
        #endregion
    }
}
