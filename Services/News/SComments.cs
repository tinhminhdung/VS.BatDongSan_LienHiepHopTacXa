using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Entity;

namespace Services
{
    public class SComments
    {
        private static FComments db = new FComments();

        #region GET BY ID
        public static List<Comments> GETBYID(string ID)
        {
            return db.GETBYID(ID);
        }
        #endregion

        #region GET BY ALL
        public static List<Comments> GETBYALL()
        {
            return db.GETBYALL();
        }
        #endregion

        #region INSERT
        public static bool INSERT(Comments obj)
        {
            return db.INSERT(obj);
        }
        #endregion

        #region UPDATE
        public static bool UPDATE(Comments obj)
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


        #region DELETE_Parent_ID
        public static void DELETE_Parent_ID(string ID)
        {
            db.DELETE_Parent_ID(ID);
        }
        #endregion


        #region Detail_ID_Parent_Status_orderasc_desc
        public static List<Comments> Detail_ID_Parent_Status_orderasc_desc(string ID_Parent, string Status, bool orderasc_desc)
        {
            return db.Detail_ID_Parent_Status_orderasc_desc(ID_Parent, Status, orderasc_desc);
        }
        #endregion

        #region GET DETAIL BY ID
        public static List<Comments> GET_DETAIL_BYID(string ID)
        {
            return db.GETDETAIL_BYID(ID);
        }
        #endregion

        #region UPDATE STATUS
        public static bool UPDATE_STATUS(string ID, string conditon)
        {
            return db.UPDATESTATUS(ID, conditon);
        }
        #endregion

        #region NEWS TOTALS
        public static List<Comments> NEWS_TOTALS(string ID_Parent, string Status)
        {
            return db.NEWS_TOTAL(ID_Parent, Status);
        }
        #endregion

        #region DETAIL TOP
        public static List<Comments> DETAIL_TOP(int top, string ID_Parent, string Status, string orderby)
        {
            return db.DETAIL_TOP(top, ID_Parent, Status, orderby);
        }
        #endregion
        #region DETAIL COUNT
        public static int DETAIL_COUNT(string ID_Parent, string Status, string condition)
        {
            return db.Detail_Count(ID_Parent, Status, condition);
        }
        #endregion

        #region Name_StoredProcedure
        public static List<Comments> Name_StoredProcedure(string Name_StoredProcedure)
        {
            return db.Name_StoredProcedure(Name_StoredProcedure);
        }
        #endregion

        #region Name_Text
        public static List<Comments> Name_Text(string Name_Text)
        {
            return db.Name_Text(Name_Text);
        }
        #endregion
    }
}
