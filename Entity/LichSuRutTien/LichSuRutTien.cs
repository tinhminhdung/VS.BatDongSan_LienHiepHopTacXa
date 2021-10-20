using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entity
{
    public class ELichSuRutTien
    {
        private int _ID;
        private int _IDThanhVien;
        private string _TongTienTrongVi;
        private string _SoTienCanRut;
        private string _SoCoin;
        private string _TenNganHang;
        private string _HoVaTen;
        private string _SoTaiKHoan;
        private string _ChiNhanh;
        private string _NoiDungChuyenTien;
        private string _GhiChu;
        private int _TrangThai;
        private DateTime _NgayTao;
        private string _NgayDuyet;
        private string _NguoiDuyet;
        public int ID { get { return _ID; } set { _ID = value; } }
        public int IDThanhVien { get { return _IDThanhVien; } set { _IDThanhVien = value; } }
        public string TongTienTrongVi { get { return _TongTienTrongVi; } set { _TongTienTrongVi = value; } }
        public string SoTienCanRut { get { return _SoTienCanRut; } set { _SoTienCanRut = value; } }
        public string SoCoin { get { return _SoCoin; } set { _SoCoin = value; } }
        public string TenNganHang { get { return _TenNganHang; } set { _TenNganHang = value; } }
        public string HoVaTen { get { return _HoVaTen; } set { _HoVaTen = value; } }
        public string SoTaiKHoan { get { return _SoTaiKHoan; } set { _SoTaiKHoan = value; } }
        public string ChiNhanh { get { return _ChiNhanh; } set { _ChiNhanh = value; } }
        public string NoiDungChuyenTien { get { return _NoiDungChuyenTien; } set { _NoiDungChuyenTien = value; } }
        public string GhiChu { get { return _GhiChu; } set { _GhiChu = value; } }
        public int TrangThai { get { return _TrangThai; } set { _TrangThai = value; } }
        public DateTime NgayTao { get { return _NgayTao; } set { _NgayTao = value; } }
        public string NgayDuyet { get { return _NgayDuyet; } set { _NgayDuyet = value; } }
        public string NguoiDuyet { get { return _NguoiDuyet; } set { _NguoiDuyet = value; } }
    }
}
