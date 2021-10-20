using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entity
{
    public class Album
    {
        #region[Entity Private]
        private int _ID;
        private int _Menu_ID;
        private string _Title;
        private string _Brief;
        private string _Contents;
        private string _Keywords;
        private string _search;
        private string _Images;
        private string _ImagesSmall;
        private int _Equals;
        private int _Chekdata;
        private DateTime _Create_Date;
        private DateTime _Modified_Date;
        private int _Views;
        private string _lang;
        private int _News;
        private int _Status;
        private string _Titleseo;
        private string _Meta;
        private string _Keyword;
        private string _TangName;
        private string _Anhnhieu;
        private string _Alt;
        #endregion

        #region[Properties]
        public int ID { get { return _ID; } set { _ID = value; } }
        public int Menu_ID { get { return _Menu_ID; } set { _Menu_ID = value; } }
        public string Title { get { return _Title; } set { _Title = value; } }
        public string Brief { get { return _Brief; } set { _Brief = value; } }
        public string Contents { get { return _Contents; } set { _Contents = value; } }
        public string Keywords { get { return _Keywords; } set { _Keywords = value; } }
        public string search { get { return _search; } set { _search = value; } }
        public string Images { get { return _Images; } set { _Images = value; } }
        public string ImagesSmall { get { return _ImagesSmall; } set { _ImagesSmall = value; } }
        public int Equals { get { return _Equals; } set { _Equals = value; } }
        public int Chekdata { get { return _Chekdata; } set { _Chekdata = value; } }
        public DateTime Create_Date { get { return _Create_Date; } set { _Create_Date = value; } }
        public DateTime Modified_Date { get { return _Modified_Date; } set { _Modified_Date = value; } }
        public int Views { get { return _Views; } set { _Views = value; } }
        public string lang { get { return _lang; } set { _lang = value; } }
        public int News { get { return _News; } set { _News = value; } }
        public int Status { get { return _Status; } set { _Status = value; } }
        public string Titleseo { get { return _Titleseo; } set { _Titleseo = value; } }
        public string Meta { get { return _Meta; } set { _Meta = value; } }
        public string Keyword { get { return _Keyword; } set { _Keyword = value; } }
        public string TangName { get { return _TangName; } set { _TangName = value; } }
        public string Anhnhieu { get { return _Anhnhieu; } set { _Anhnhieu = value; } }
        public string Alt { get { return _Alt; } set { _Alt = value; } }
        #endregion

    }

    public class Album_RutGon
    {
        #region[Entity Private]
        private int _ID;
        private string _Title;
        private string _Images;
        private string _ImagesSmall;
        private DateTime _Create_Date;
        private string _TangName;
        private string _Anhnhieu;
        private string _Alt;
        #endregion

        #region[Properties]
        public int ID { get { return _ID; } set { _ID = value; } }
        public string Title { get { return _Title; } set { _Title = value; } }
        public string Images { get { return _Images; } set { _Images = value; } }
        public string ImagesSmall { get { return _ImagesSmall; } set { _ImagesSmall = value; } }
        public DateTime Create_Date { get { return _Create_Date; } set { _Create_Date = value; } }
        public string TangName { get { return _TangName; } set { _TangName = value; } }
        public string Anhnhieu { get { return _Anhnhieu; } set { _Anhnhieu = value; } }
        public string Alt { get { return _Alt; } set { _Alt = value; } }
        #endregion

    }
}
