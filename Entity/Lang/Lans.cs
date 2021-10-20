using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entity
{
    public class Lans
    {
        #region[Entity Private]
        private int _ilanid;
        private string _VLAN_ID;
        private string _VLAN_NAME;
        private string _VLAN_NAME_VIE;
        private int _ILAN_ORDER;
        private int _ILAN_LOCKED;
        private int _MacDinh;
        #endregion

        #region[Properties]
        public int ilanid { get { return _ilanid; } set { _ilanid = value; } }
        public string VLAN_ID { get { return _VLAN_ID; } set { _VLAN_ID = value; } }
        public string VLAN_NAME { get { return _VLAN_NAME; } set { _VLAN_NAME = value; } }
        public string VLAN_NAME_VIE { get { return _VLAN_NAME_VIE; } set { _VLAN_NAME_VIE = value; } }
        public int ILAN_ORDER { get { return _ILAN_ORDER; } set { _ILAN_ORDER = value; } }
        public int ILAN_LOCKED { get { return _ILAN_LOCKED; } set { _ILAN_LOCKED = value; } }
        public int MacDinh { get { return _MacDinh; } set { _MacDinh = value; } }
        #endregion

    }
}
