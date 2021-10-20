using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entity
{
    public class Contacts
    {
        #region[Entity Private]
        private int _ino;
        private string _vtitle;
        private string _vname;
        private string _vaddress;
        private string _vphone;
        private string _vemail;
        private string _vcontent;
        private DateTime _dcreatedate;
        private string _lang;
        private int _istatus;
        #endregion

        #region[Properties]
        public int ino { get { return _ino; } set { _ino = value; } }
        public string vtitle { get { return _vtitle; } set { _vtitle = value; } }
        public string vname { get { return _vname; } set { _vname = value; } }
        public string vaddress { get { return _vaddress; } set { _vaddress = value; } }
        public string vphone { get { return _vphone; } set { _vphone = value; } }
        public string vemail { get { return _vemail; } set { _vemail = value; } }
        public string vcontent { get { return _vcontent; } set { _vcontent = value; } }
        public DateTime dcreatedate { get { return _dcreatedate; } set { _dcreatedate = value; } }
        public string lang { get { return _lang; } set { _lang = value; } }
        public int istatus { get { return _istatus; } set { _istatus = value; } }
        #endregion

    }
}
