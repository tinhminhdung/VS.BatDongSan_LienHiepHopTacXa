using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entity
{
    public class web_statistic
    {
        #region[Declare variables]
        private int _INO;
        private DateTime _DDATE;
        private int _INUMOFVISIT;
        private int _INUMOFMEMBER;
        private int _IHITS;
        #endregion

        #region[Public Properties]
        public int INO { get { return _INO; } set { _INO = value; } }
        public DateTime DDATE { get { return _DDATE; } set { _DDATE = value; } }
        public int INUMOFVISIT { get { return _INUMOFVISIT; } set { _INUMOFVISIT = value; } }
        public int INUMOFMEMBER { get { return _INUMOFMEMBER; } set { _INUMOFMEMBER = value; } }
        public int IHITS { get { return _IHITS; } set { _IHITS = value; } }
        #endregion


    }
}
