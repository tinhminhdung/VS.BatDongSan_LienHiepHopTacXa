using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Entity
{
    public class CartDetail
    {
        #region[Entity Private]
        private int _ID;
        private int _ID_Cart;
        private int _ipid;
        private Double _Price;
        private int _Quantity;
        private Double _Money;
        private int _Mausac;
        private int _Kichco;
        private string _Name;
        private int _IDThanhVien;
        #endregion
        #region[Properties]
        public int ID { get { return _ID; } set { _ID = value; } }
        public int ID_Cart { get { return _ID_Cart; } set { _ID_Cart = value; } }
        public int ipid { get { return _ipid; } set { _ipid = value; } }
        public Double Price { get { return _Price; } set { _Price = value; } }
        public int Quantity { get { return _Quantity; } set { _Quantity = value; } }
        public Double Money { get { return _Money; } set { _Money = value; } }
        public int Mausac { get { return _Mausac; } set { _Mausac = value; } }
        public int Kichco { get { return _Kichco; } set { _Kichco = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public int IDThanhVien { get { return _IDThanhVien; } set { _IDThanhVien = value; } }
        #endregion

    }
}