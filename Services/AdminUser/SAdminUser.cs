using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Entity;

namespace Services
{
    public class SAdminUser
    {
        private static FAdminUser db = new FAdminUser();

        #region GET BY ID
        public static List<AdminUser> GETBYID(string ID)
        {
            return db.GETBYID(ID);
        }
        #endregion

        #region GET BY ALL
        public static List<AdminUser> GETBYALL()
        {
            return db.GETBYALL();
        }
        #endregion

        #region INSERT
        public static bool INSERT(AdminUser data)
        {
            return db.Insert(data);
        }
        #endregion

        #region UPDATE
        public static bool UPDATE(AdminUser data)
        {
            return db.Update(data);
        }
        #endregion

        #region UPDATE STATUS
        public static bool UPDATE_STATUS(AdminUser data)
        {
            return db.UPDATESTATUS(data);
        }
        #endregion

        #region UPDATE PASSWORD]
        public static bool UPDATE_PASSWORD(AdminUser data)
        {
            return db.UPDATEPASSWORD(data);
        }
        #endregion

        #region DELETE
        public static void DELETE(string ID)
        {
            db.Delete(ID);
        }
        #endregion
    }
}
