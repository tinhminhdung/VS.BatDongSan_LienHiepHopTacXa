using MoreAll;
using Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VS.ECommerce_MVC;

public class SinhHH
{
    public static string VanPhongChiNhanh()
    {
        string bc = System.Web.HttpContext.Current.Request.Url.Authority + System.Web.HttpContext.Current.Request.RawUrl.ToString();
        if (!bc.Contains("localhost"))
        {
            return "27";
        }
        return "2";//????????????
    }
    public static string BanDaoTao()
    {
        // 9443 là tạm thời để test còn ID chính là : 67357
        string bc = System.Web.HttpContext.Current.Request.Url.Authority + System.Web.HttpContext.Current.Request.RawUrl.ToString();
        if (!bc.Contains("localhost"))
        {
            return "28";
        }
        return "3";
    }
    public static string BanDieuHanh()
    {
        // 9443 là tạm thời để test còn ID chính là : 67357
        string bc = System.Web.HttpContext.Current.Request.Url.Authority + System.Web.HttpContext.Current.Request.RawUrl.ToString();
        if (!bc.Contains("localhost"))
        {
            return "29";
        }
        return "4";
    }

    public static string HoaHongF(string IDThanhVien, string IDNguoiBan, string IDDonHang, string Tien)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        Double TongTienDaChia = 0;
        double TongTien = Convert.ToDouble(Tien);

        #region F1 - Trực tiếp - Người bán
        List<Entity.Member> F1 = SMember.GET_BY_ID(IDNguoiBan);
        if (F1.Count > 0)
        {
            #region Số lần bán được sản phẩm
            SMember.Name_Text("update Members set DaBanDuocSanPham=DaBanDuocSanPham+1 where ID=" + IDNguoiBan.ToString() + "");
            #endregion

            double HoaHongF1 = Convert.ToDouble(Commond.Setting("NguoiBanHang"));
            double TienHoaHongF1 = (TongTien * HoaHongF1) / 100;
            if (TrangThaiThuPhi(IDNguoiBan.ToString()) == true)
            {
                TongTienDaChia += TienHoaHongF1;
                ChiaHoaHong.ThemHoaHong("1", "Hoa hồng Người Bán Hàng", Tien, IDThanhVien.Trim(), IDNguoiBan.ToString(), HoaHongF1.ToString(), TienHoaHongF1.ToString(), IDDonHang.ToString());
            }
            //#region F2
            //List<Entity.Member> F2 = SMember.GET_BY_ID(F1[0].GioiThieu.ToString());
            //if (F2.Count > 0)
            //{
            //    if (F2[0].ID.ToString() != "0")
            //    {
            //        double HoaHongF2 = Convert.ToDouble(Commond.Setting("NguoiTuyenDung"));
            //        double TienHoaHongF2 = (TienHoaHongF1 * HoaHongF2) / 100;

            //        if (TrangThaiThuPhi(F2[0].ID.ToString()) == true)
            //        {
            //            TongTienDaChia += TienHoaHongF2;
            //            ThemHoaHong("2", "Hoa hồng người tuyển dụng", Tien, IDThanhVien.Trim(), F2[0].ID.ToString(), HoaHongF2.ToString(), TienHoaHongF2.ToString(), IDDonHang.ToString());
            //        }
            //    }
            //}
            //#endregion
        }
        #endregion

        #region VanPhongChiNhanh
        List<Entity.Member> vp = SMember.GET_BY_ID(VanPhongChiNhanh());
        if (vp.Count > 0)
        {
            double HoaHongVP = Convert.ToDouble(Commond.Setting("VanPhongChiNhanh"));
            double TienHoaHongVP = (TongTien * HoaHongVP) / 100;
            if (TrangThaiThuPhi(VanPhongChiNhanh()) == true)
            {
                TongTienDaChia += TienHoaHongVP;
                ChiaHoaHong.ThemHoaHong("3", "Hoa hồng Văn Phòng Chi Nhánh", Tien, IDThanhVien.Trim(), VanPhongChiNhanh(), HoaHongVP.ToString(), TienHoaHongVP.ToString(), IDDonHang.ToString());
            }
        }
        #endregion

        #region BanDaoTao
        List<Entity.Member> DT = SMember.GET_BY_ID(BanDaoTao());
        if (DT.Count > 0)
        {
            double HoaHongDT = Convert.ToDouble(Commond.Setting("DongHuong"));
            double TienHoaHongDT = (TongTien * HoaHongDT) / 100;
            if (TrangThaiThuPhi(BanDaoTao()) == true)
            {
                TongTienDaChia += TienHoaHongDT;
                ChiaHoaHong.ThemHoaHong("4", "Hoa hồng đồng hưởng", Tien, IDThanhVien.Trim(), BanDaoTao(), HoaHongDT.ToString(), TienHoaHongDT.ToString(), IDDonHang.ToString());
            }
        }
        #endregion


        // Hoa Hồng Cấp Quản Lý
        // Tìm trong dây của mình xem có ai được trưởng nhóm kinh doanh không thì cho hh
        // Có 5 F1 đã đóng phí là được và đã bán dc 1 sản phẩm DaBanDuocSanPham
        // Tìm ông gần nhất để cho 

        ChiaHoaHong.ChiaHoaHongCapBacs(IDThanhVien.ToString(), TongTien.ToString(), IDDonHang.ToString());

        // Sum các 
        #region Vi Loi Nhuan sau khi da chia HH
        Double TTongTienDaChia = Convert.ToDouble(TongTienDaChia.ToString());
        Double TongCong = (TongTien - TongTienDaChia);
        LoiNhuanMuaBan abln = new LoiNhuanMuaBan();
        abln.IDThanhVienMua = int.Parse(IDThanhVien.ToString());
        abln.IDDonHang = IDDonHang;
        abln.MoTa = "";
        abln.NgayTao = DateTime.Now;
        abln.TongTien = TongTien.ToString();
        abln.TongTienCon = TongCong.ToString();
        abln.TongTienDaChia = TTongTienDaChia.ToString();
        abln.MTreeIDThanhVienMua = Commond.ShowMTree(IDThanhVien.ToString());
        abln.NguoiDuyet = MoreAll.MoreAll.GetCookies("UName").ToString();
        db.LoiNhuanMuaBans.InsertOnSubmit(abln);
        db.SubmitChanges();
        #endregion
        return "";
    }
    public static string TimTruongNhomGanNhat(string id)
    {
        string str = "0";
        List<Entity.Member> dt = SMember.Name_Text("select top 1 * from Members  where ID=" + id + " ");
        if (dt.Count > 0)
        {
            if (dt[0].CapBac.ToString() == "1")
            {
                return dt[0].ID.ToString();
            }
            else
            {
                str = dt[0].GioiThieu.ToString();
                return TimTruongNhomGanNhat(str);
            }
        }
        return str;
    }
    public static string TimTruongPhongGanNhat(string id)
    {
        string str = "0";
        List<Entity.Member> dt = SMember.Name_Text("select top 1 * from Members  where ID=" + id + " ");
        if (dt.Count > 0)
        {
            if (dt[0].CapBac.ToString() == "2")
            {
                return dt[0].ID.ToString();
            }
            else
            {
                str = dt[0].GioiThieu.ToString();
                return TimTruongPhongGanNhat(str);
            }
        }
        return str;
    }

    public static string TimGiamDocGanNhat(string id)
    {
        string str = "0";
        List<Entity.Member> dt = SMember.Name_Text("select top 1 * from Members  where ID=" + id + " ");
        if (dt.Count > 0)
        {
            if (dt[0].CapBac.ToString() == "3")
            {
                return dt[0].ID.ToString();
            }
            else
            {
                str = dt[0].GioiThieu.ToString();
                return TimGiamDocGanNhat(str);
            }
        }
        return str;
    }

    public static bool TrangThaiThuPhi(string IDThanhVienHuong)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        List<Entity.Member> F1 = SMember.Name_Text("select * from Members  where ID=" + IDThanhVienHuong.ToString() + " and ThuPhi=1");//DaKichHoat
        if (F1.Count() > 0)
        {
            return true;
        }
        return false;
    }
  

   
}
