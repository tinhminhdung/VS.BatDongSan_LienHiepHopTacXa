using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entity
{
    public class Comments
    {
        #region[Entity Private]
        private int _ID;
        private int _ID_Parent;
        private string _Name;
        private string _Add;
        private string _Email;
        private string _Title;
        private string _Contens;
        private DateTime _Create_Date;
        private int _Status;
        #endregion

        #region[Properties]
        public int ID { get { return _ID; } set { _ID = value; } }
        public int ID_Parent { get { return _ID_Parent; } set { _ID_Parent = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public string Add { get { return _Add; } set { _Add = value; } }
        public string Email { get { return _Email; } set { _Email = value; } }
        public string Title { get { return _Title; } set { _Title = value; } }
        public string Contens { get { return _Contens; } set { _Contens = value; } }
        public DateTime Create_Date { get { return _Create_Date; } set { _Create_Date = value; } }
        public int Status { get { return _Status; } set { _Status = value; } }
        #endregion

    }
}
