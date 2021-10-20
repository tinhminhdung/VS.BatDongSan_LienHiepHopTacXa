using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Entity;

namespace Services
{
    public class SModulControls
    {
        private static FModulControls db = new FModulControls();

        #region Name_StoredProcedure
        public static List<ModulControls> Name_StoredProcedure(string Name_StoredProcedure)
        {
            return db.Name_StoredProcedure(Name_StoredProcedure);
        }
        #endregion

        #region Name_Text
        public static List<ModulControls> Name_Text(string Name_Text)
        {
            return db.Name_Text(Name_Text);
        }
        #endregion

        #region Name_Text_ID
        public static List<ModulControlsID> Name_Text_ID(string Name_Text)
        {
            return db.Name_Text_ID(Name_Text);
        }
        #endregion



    }
}
