using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entity
{
    public class News_Related
    {
        #region[Entity Private]
        private int _ID;
        private int _inid;
        private int _irelated;
        #endregion

        #region[Properties]
        public int ID { get { return _ID; } set { _ID = value; } }
        public int inid { get { return _inid; } set { _inid = value; } }
        public int irelated { get { return _irelated; } set { _irelated = value; } }
        #endregion

    }
}
