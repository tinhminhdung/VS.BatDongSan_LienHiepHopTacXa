using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Entity;

namespace Services
{
    public class SSetting
    {
        private static FSetting db = new FSetting();

        #region GET BY ID
        public static List<Entity.Setting> GETBYID(string ID)
        {
            return db.GETBYID(ID);
        }
        #endregion

        #region GET BY ALL
        public static List<Entity.Setting> GETBYALL(string Lang)
        {
            return db.GETBYALL(Lang);
        }
        #endregion

        #region INSERT
        public static bool INSERT(Setting Obj)
        {
            return db.INSERT(Obj);
        }
        #endregion

        #region UPDATE
        public static bool UPDATE(Setting Obj)
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
        public static List<Entity.Setting> Name_Text(string Name_Text)
        {
            return db.Text(Name_Text);
        }
        #endregion
    }
}
