using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Entity;

namespace Services
{
    public class SMember
    {
        private static FMember db = new FMember();

        #region CATEGORY_PHANTRANG
        public static List<Member> CATEGORY_PHANTRANG2(string IDThanhVien, string keyword, string Status, int PageIndex, int Tongpage)
        {
            return db.CATEGORY_PHANTRANG2(IDThanhVien, keyword, Status, PageIndex, Tongpage);
        }
        public static List<Member> CATEGORY_PHANTRANG1(string IDThanhVien, string keyword, string Status)
        {
            return db.CATEGORY_PHANTRANG1(IDThanhVien, keyword, Status);
        }
        #endregion

        #region UPDATE STATUS
        public static bool UPDATE_STATUS(string vuserun, string istatus)
        {
            return db.UPDATE_STATUS(vuserun, istatus);
        }
        #endregion

        #region GET BY ID
        public static List<Member> GET_BY_ID(string ID)
        {
            return db.GETBYID(ID);
        }
        #endregion

        #region CATEGORY
        public static List<Member> CATEGORY(string istatus)
        {
            return db.CATEGORY(istatus);
        }
        #endregion

        #region GET BY ALL
        public static List<Member> GET_BY_ALL()
        {
            return db.GETBYALL();
        }
        #endregion

        #region INSERT
        public static bool INSERT(Member data)
        {
            return db.INSERT(data);
        }
        #endregion

        //#region UPDATE
        //public static bool Member_update(Member data)
        //{
        //    return db.Member_update(data);
        //}
        //#endregion
        #region UPDATE
        public static bool UPDATE(Member data)
        {
            return db.UPDATE(data);
        }
        #endregion

        #region Member_update_updateavatar
        public static bool Member_update_updateavatar(Member data)
        {
            return db.Member_update_updateavatar(data);
        }
        #endregion

        public static List<Entity.Member> CATEGORY_ADMIN(string orderby, string searchkeyword, string[] searchfields, string lang, string Status)
        {
            return db.CATEGORY_ADMIN(orderby, searchkeyword, searchfields, lang, Status);
        }

        #region DELETE
        public static void DELETE(string ID)
        {
            db.DELETE(ID);
        }
        #endregion

        #region Name_StoredProcedure
        public static List<Member> Name_StoredProcedure(string Name_StoredProcedure)
        {
            return db.Name_StoredProcedure(Name_StoredProcedure);
        }
        #endregion


        #region Name_Text
        public static List<Member> Name_Text(string Name_Text)
        {
            return db.Name_Text(Name_Text);
        }
        public static List<SumMember> Name_SumMember(string Name_Text)
        {
            return db.Name_SumMember(Name_Text);
        }
        #endregion
    }
}
