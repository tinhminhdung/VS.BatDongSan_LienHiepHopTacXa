using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entity
{
    public class YahooMessenger
    {
        #region[Entity Private]
        private int _inick;
        private int _Type;
        private string _Title;
        private string _Nick;
        private string _Phone;
        private int _Size;
        private int _Orders;
        private string _lang;
        private int _Status;
        private string _Skype;
        private string _Email;
        #endregion

        #region[Properties]
        public int inick { get { return _inick; } set { _inick = value; } }
        public int Type { get { return _Type; } set { _Type = value; } }
        public string Title { get { return _Title; } set { _Title = value; } }
        public string Nick { get { return _Nick; } set { _Nick = value; } }
        public string Phone { get { return _Phone; } set { _Phone = value; } }
        public int Size { get { return _Size; } set { _Size = value; } }
        public int Orders { get { return _Orders; } set { _Orders = value; } }
        public string lang { get { return _lang; } set { _lang = value; } }
        public int Status { get { return _Status; } set { _Status = value; } }
        public string Skype { get { return _Skype; } set { _Skype = value; } }
        public string Email { get { return _Email; } set { _Email = value; } }
        #endregion

    }
}
