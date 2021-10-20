using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entity
{
    public class News
    {
        #region[Entity Private]
        private int _inid;
        private int _icid;
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
        private string _Tags;
        private string _lang;
        private int _New;
        private int _CheckBox1;
        private int _CheckBox2;
        private int _CheckBox3;
        private int _CheckBox4;
        private int _CheckBox5;
        private int _CheckBox6;
        private int _Status;
        private string _Titleseo;
        private string _Meta;
        private string _Keyword;
        private string _TangName;
        private string _Alt;
        #endregion

        #region[Properties]
        public int inid { get { return _inid; } set { _inid = value; } }
        public int icid { get { return _icid; } set { _icid = value; } }
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
        public string Tags { get { return _Tags; } set { _Tags = value; } }
        public string lang { get { return _lang; } set { _lang = value; } }
        public int New { get { return _New; } set { _New = value; } }
        public int CheckBox1 { get { return _CheckBox1; } set { _CheckBox1 = value; } }
        public int CheckBox2 { get { return _CheckBox2; } set { _CheckBox2 = value; } }
        public int CheckBox3 { get { return _CheckBox3; } set { _CheckBox3 = value; } }
        public int CheckBox4 { get { return _CheckBox4; } set { _CheckBox4 = value; } }
        public int CheckBox5 { get { return _CheckBox5; } set { _CheckBox5 = value; } }
        public int CheckBox6 { get { return _CheckBox6; } set { _CheckBox6 = value; } }
        public int Status { get { return _Status; } set { _Status = value; } }
        public string Titleseo { get { return _Titleseo; } set { _Titleseo = value; } }
        public string Meta { get { return _Meta; } set { _Meta = value; } }
        public string Keyword { get { return _Keyword; } set { _Keyword = value; } }
        public string TangName { get { return _TangName; } set { _TangName = value; } }
        public string Alt { get { return _Alt; } set { _Alt = value; } }

        #endregion

    }
    public class News_Count
    {
        public int nid { get; set; }
    }
    public class Category_News
    {
        public int inid { get; set; }
        public string Title { get; set; }
        public string Brief { get; set; }
        public string Images { get; set; }
        public string ImagesSmall { get; set; }
        public DateTime Create_Date { get; set; }
        public string TangName { get; set; }
        public string Alt { get; set; }
    }
}
