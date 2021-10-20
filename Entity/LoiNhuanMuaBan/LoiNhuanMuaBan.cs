using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entity
{
    public class ELoiNhuanMuaBan
    {
        private int _ID;
        private int _IDThanhVienMua;
        private string _IDDonHang;
        private string _MoTa;
        private DateTime _NgayTao;
        private string _TongTien;
        private string _TongTienCon;
        private string _TongTienDaChia;
        private string _MTreeIDThanhVienMua;
        private string _NguoiDuyet;

        public int ID { get { return _ID; } set { _ID = value; } }
        public int IDThanhVienMua { get { return _IDThanhVienMua; } set { _IDThanhVienMua = value; } }
        public string IDDonHang { get { return _IDDonHang; } set { _IDDonHang = value; } }
        public string MoTa { get { return _MoTa; } set { _MoTa = value; } }
        public DateTime NgayTao { get { return _NgayTao; } set { _NgayTao = value; } }
        public string TongTien { get { return _TongTien; } set { _TongTien = value; } }
        public string TongTienCon { get { return _TongTienCon; } set { _TongTienCon = value; } }
        public string TongTienDaChia { get { return _TongTienDaChia; } set { _TongTienDaChia = value; } }
        public string MTreeIDThanhVienMua { get { return _MTreeIDThanhVienMua; } set { _MTreeIDThanhVienMua = value; } }
        public string NguoiDuyet { get { return _NguoiDuyet; } set { _NguoiDuyet = value; } }
    }
}
