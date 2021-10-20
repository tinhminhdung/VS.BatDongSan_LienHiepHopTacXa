using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entity
{
    public class Faq
    {
        #region[Entity Private]
        private int _inid;
        private string _Title;
        private string _Brief;
        private string _Contents;
        private string _Keywords;
        private string _search;
        private int _Chekdata;
        private DateTime _Create_Date;
        private DateTime _Modified_Date;
        private int _Views;
        private string _lang;
        private int _New;
        private int _Status;
        private string _TangName;
        #endregion

        #region[Properties]
        public int inid { get { return _inid; } set { _inid = value; } }
        public string Title { get { return _Title; } set { _Title = value; } }
        public string Brief { get { return _Brief; } set { _Brief = value; } }
        public string Contents { get { return _Contents; } set { _Contents = value; } }
        public string Keywords { get { return _Keywords; } set { _Keywords = value; } }
        public string search { get { return _search; } set { _search = value; } }
        public int Chekdata { get { return _Chekdata; } set { _Chekdata = value; } }
        public DateTime Create_Date { get { return _Create_Date; } set { _Create_Date = value; } }
        public DateTime Modified_Date { get { return _Modified_Date; } set { _Modified_Date = value; } }
        public int Views { get { return _Views; } set { _Views = value; } }
        public string lang { get { return _lang; } set { _lang = value; } }
        public int New { get { return _New; } set { _New = value; } }
        public int Status { get { return _Status; } set { _Status = value; } }
        public string TangName { get { return _TangName; } set { _TangName = value; } }
        #endregion

    }
}
