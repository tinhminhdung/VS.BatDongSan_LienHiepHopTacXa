using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entity
{
    public class Advertisings
    {
        #region [Entity Private]
        private int _images;
        private string _Name;
        private string _Path;
        private int _value;
        private int _Equals;
        private string _vimg;
        private string _lang;
        private int _Orders;
        private int _Views;
        private int _Width;
        private int _Height;
        private int _Opentype;
        private int _Text;
        private string _Contents;
        private int _Chekdata;
        private DateTime _Create_Date;
        private DateTime _Modified_Date;
        private int _Type;
        private string _Youtube;
        private int _Status;
        #endregion

        #region[Properties]
        public int images { get { return _images; } set { _images = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public string Path { get { return _Path; } set { _Path = value; } }
        public int value { get { return _value; } set { _value = value; } }
        public int Equals { get { return _Equals; } set { _Equals = value; } }
        public string vimg { get { return _vimg; } set { _vimg = value; } }
        public string lang { get { return _lang; } set { _lang = value; } }
        public int Orders { get { return _Orders; } set { _Orders = value; } }
        public int Views { get { return _Views; } set { _Views = value; } }
        public int Width { get { return _Width; } set { _Width = value; } }
        public int Height { get { return _Height; } set { _Height = value; } }
        public int Opentype { get { return _Opentype; } set { _Opentype = value; } }
        public int Text { get { return _Text; } set { _Text = value; } }
        public string Contents { get { return _Contents; } set { _Contents = value; } }
        public int Chekdata { get { return _Chekdata; } set { _Chekdata = value; } }
        public DateTime Create_Date { get { return _Create_Date; } set { _Create_Date = value; } }
        public DateTime Modified_Date { get { return _Modified_Date; } set { _Modified_Date = value; } }
        public int Type { get { return _Type; } set { _Type = value; } }
        public string Youtube { get { return _Youtube; } set { _Youtube = value; } }
        public int Status { get { return _Status; } set { _Status = value; } }
        #endregion

    }
}
