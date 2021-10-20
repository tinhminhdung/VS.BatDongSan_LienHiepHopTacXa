using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entity
{
    public class Setting
    {
        #region[Declare variables]
        private int _ID;
        private string _Properties;
        private string _Value;
        private string _Lang;
        #endregion

        #region[Public Properties]
        public int ID { get { return _ID; } set { _ID = value; } }
        public string Properties { get { return _Properties; } set { _Properties = value; } }
        public string Value { get { return _Value; } set { _Value = value; } }
        public string Lang { get { return _Lang; } set { _Lang = value; } }
        #endregion

    }
}
