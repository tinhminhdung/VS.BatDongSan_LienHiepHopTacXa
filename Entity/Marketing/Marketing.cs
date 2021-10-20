using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entity
{
    public class Marketing
    {
        #region[Entity Private]
        private int _IDMarketing;
        private string _Name;
        private string _Email;
        private string _Phone;
        private string _Address;
        private DateTime _dcreatedate;
        private int _istatus;
        #endregion

        #region[Properties]
        public int IDMarketing { get { return _IDMarketing; } set { _IDMarketing = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public string Email { get { return _Email; } set { _Email = value; } }
        public string Phone { get { return _Phone; } set { _Phone = value; } }
        public string Address { get { return _Address; } set { _Address = value; } }
        public DateTime dcreatedate { get { return _dcreatedate; } set { _dcreatedate = value; } }
        public int istatus { get { return _istatus; } set { _istatus = value; } }
        #endregion

    }
}
