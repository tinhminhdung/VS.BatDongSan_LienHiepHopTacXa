using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entity
{
    public class Member
    {
        #region[Entity Private]
        private int _ID;
        private string _PasWord;
        private string _HoVaTen;
        private int _GioiTinh;
        private string _NgaySinh;
        private string _DiaChi;
        private string _DienThoai;
        private string _Email;
        private string _AnhDaiDien;
        private DateTime _NgayTao;
        private string _Key;
        private int _TrangThai;
        private string _Lang;
        private int _GioiThieu;
        private string _MTRee;
        private string _TienHoaHong;
        private string _TongTienDaRut;
        private int _CapBac;
        private int _ThuPhi;
        private int _DaBanDuocSanPham;
        private string _IDLuuTam;
        private string _TongTienDaMua;


        #endregion

        #region[Properties]
        public int ID { get { return _ID; } set { _ID = value; } }
        public string PasWord { get { return _PasWord; } set { _PasWord = value; } }
        public string HoVaTen { get { return _HoVaTen; } set { _HoVaTen = value; } }
        public int GioiTinh { get { return _GioiTinh; } set { _GioiTinh = value; } }
        public string NgaySinh { get { return _NgaySinh; } set { _NgaySinh = value; } }
        public string DiaChi { get { return _DiaChi; } set { _DiaChi = value; } }
        public string DienThoai { get { return _DienThoai; } set { _DienThoai = value; } }
        public string Email { get { return _Email; } set { _Email = value; } }
        public string AnhDaiDien { get { return _AnhDaiDien; } set { _AnhDaiDien = value; } }
        public DateTime NgayTao { get { return _NgayTao; } set { _NgayTao = value; } }
        public string Key { get { return _Key; } set { _Key = value; } }
        public int TrangThai { get { return _TrangThai; } set { _TrangThai = value; } }
        public string Lang { get { return _Lang; } set { _Lang = value; } }
        public int GioiThieu { get { return _GioiThieu; } set { _GioiThieu = value; } }
        public string MTRee { get { return _MTRee; } set { _MTRee = value; } }
        public string TienHoaHong { get { return _TienHoaHong; } set { _TienHoaHong = value; } }
        public string TongTienDaRut { get { return _TongTienDaRut; } set { _TongTienDaRut = value; } }
        public int CapBac { get { return _CapBac; } set { _CapBac = value; } }
        public int ThuPhi { get { return _ThuPhi; } set { _ThuPhi = value; } }
        public int DaBanDuocSanPham { get { return _DaBanDuocSanPham; } set { _DaBanDuocSanPham = value; } }
        public string IDLuuTam { get { return _IDLuuTam; } set { _IDLuuTam = value; } }
        public string TongTienDaMua { get { return _TongTienDaMua; } set { _TongTienDaMua = value; } }
       
        #endregion
    }
    public class SumMember
    {
        public string SUMTongTienDaMua { get; set; }
    }
    
}
