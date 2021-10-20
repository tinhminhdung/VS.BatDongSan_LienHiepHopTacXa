using System;using System.Data;using System.Data.SqlClient;using System.Collections.Generic;namespace Entity{	public class Carts	{		#region[Entity Private]
        private int _ID;		private string  _Name;		private string  _Address;		private string  _Phone;		private string  _Email;		private string  _Contents;
        private DateTime _Create_Date;
        private Double _Money;		private string  _lang;
        private int _Status;
        private string _Phuongthucthanhtoan;
        private string _Hinhthucvanchuyen;
        private string _StatusGiaoDich;
        private int _IDThanhVien;		#endregion		#region[Properties]
        public int ID { get { return _ID; } set { _ID = value; } }		public string Name{ get { return _Name; } set { _Name = value; } }		public string Address{ get { return _Address; } set { _Address = value; } }		public string Phone{ get { return _Phone; } set { _Phone = value; } }		public string Email{ get { return _Email; } set { _Email = value; } }		public string Contents{ get { return _Contents; } set { _Contents = value; } }
        public DateTime Create_Date { get { return _Create_Date; } set { _Create_Date = value; } }
        public Double Money { get { return _Money; } set { _Money = value; } }		public string lang{ get { return _lang; } set { _lang = value; } }
        public int Status { get { return _Status; } set { _Status = value; } }
        public string Phuongthucthanhtoan { get { return _Phuongthucthanhtoan; } set { _Phuongthucthanhtoan = value; } }
        public string Hinhthucvanchuyen { get { return _Hinhthucvanchuyen; } set { _Hinhthucvanchuyen = value; } }
        public string StatusGiaoDich { get { return _StatusGiaoDich; } set { _StatusGiaoDich = value; } }
        public int IDThanhVien { get { return _IDThanhVien; } set { _IDThanhVien = value; } }		#endregion			}}