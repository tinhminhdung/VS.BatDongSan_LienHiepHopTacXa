using System;using System.Data;using System.Data.SqlClient;using System.Collections.Generic;namespace Entity{	public class Product_images	{		#region[Entity Private]
        private int _ID;
        private int _ipid;
        private int _icid;		private string  _Title;		private string  _Brief;		private string  _Images;		private string  _ImagesSmall;
        private int _Equals;
        private int _Orders;
        private int _Status;		#endregion		#region[Properties]
        public int ID { get { return _ID; } set { _ID = value; } }
        public int ipid { get { return _ipid; } set { _ipid = value; } }
        public int icid { get { return _icid; } set { _icid = value; } }		public string Title{ get { return _Title; } set { _Title = value; } }		public string Brief{ get { return _Brief; } set { _Brief = value; } }		public string Images{ get { return _Images; } set { _Images = value; } }		public string ImagesSmall{ get { return _ImagesSmall; } set { _ImagesSmall = value; } }
        public int Equals { get { return _Equals; } set { _Equals = value; } }
        public int Orders { get { return _Orders; } set { _Orders = value; } }
        public int Status { get { return _Status; } set { _Status = value; } }		#endregion			}}