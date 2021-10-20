using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entity
{
    public class ModulControls
    {
        #region[Declare variables]
        private int _ID;
        private string _Name;
        private int _Module;
        private string _TangName;
        #endregion

        #region[Public Properties]
        public int ID { get { return _ID; } set { _ID = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public int Module { get { return _Module; } set { _Module = value; } }
        public string TangName { get { return _TangName; } set { _TangName = value; } }
        #endregion

    }
    public class ModulControlsID
    {
        public int ID { get; set; }
    }
}