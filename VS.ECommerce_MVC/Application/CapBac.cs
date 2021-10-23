using Entity;
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

public class ChiaHoaHong
{
    public static string ChiaHoaHongCapBacs(string IDThanhVien, string Tongtien, string IDDonHang)
    {
        string Plevel = "0";
        string chuoi1 = "0";
        string TongLevel = "0";
        System.Web.HttpContext.Current.Session["TongPT"] = "";
        #region Cộng điểm theo hoa hồng

        List<Entity.Member> item = SMember.Name_Text("select * from Members where ID=" + IDThanhVien.ToString() + "");
        if (item.Count > 0)
        {
            int i = 0;
            string CapBac = item[0].CapBac.ToString();
            SMember.Name_Text("update Members set IDLuuTam='0'  where ID=" + IDThanhVien.ToString() + "");
            string chuyendoi = item[0].MTRee.ToString();
            chuyendoi = chuyendoi.Replace("|", ",") + "0";
            chuyendoi = "0" + chuyendoi;
            chuoi1 = chuyendoi.ToString();
            List<Entity.Member> iitems = SMember.Name_Text("select * from Members where ID in (" + chuyendoi.ToString() + ") and CapBac!=0  and ThuPhi=1 order by ID desc ");
            if (iitems.Count > 0)
            {
                foreach (var obj in iitems)
                {
                    Plevel = Plevel + "," + LoaID(IDThanhVien);
                    TongLevel = MinAndMax(Plevel.ToString());
                    Double Stop = Convert.ToDouble(ChiaHH(TongLevel, obj.CapBac.ToString(), IDThanhVien.ToString(), obj.ID.ToString(), Tongtien, IDDonHang));
                    if (Stop == 1)
                    {
                        break;
                    }

                    // kiểm tra trong tổng hh được chia chỉ được = giám đốc kinh doanh cấp cao
                    #region DungChay
                    Double TongHoaHong = Convert.ToDouble(KiemTraTongHoaHongDaChia(IDDonHang));
                    Double DungChay = 0;
                    DungChay = Convert.ToDouble(Commond.Setting("GiamDocKinhDoanh"));
                    if (TongHoaHong >= DungChay)
                    {
                        break;
                    }
                    #endregion
                }
            }
        }
        #endregion
        return "";
    }
    public static string KiemTraTongHoaHongDaChia(string IDDonHang)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        double num = 0.0;
        List<HoaHong> items = db.HoaHongs.Where(s => (s.IDDonHang) == (IDDonHang) && s.KieuHoaHong == 10).ToList();// xóa nhiều
        if (items.Count > 0)
        {
            for (int i = 0; i < items.Count; i++)
            {
                num += Convert.ToDouble(items[i].PhanTram.ToString());
            }
        }
        return num.ToString();
    }
    public static string LoaID(string IDThanhVien)
    {
        List<Entity.Member> items = SMember.Name_Text("select * from Members where ID=" + IDThanhVien.ToString() + "");
        if (items.Count > 0)
        {
            return items[0].IDLuuTam.ToString();
        }
        return "0";
    }
    public static string UpdateLoaID(string Capbac, string IDThanhVien)
    {
        SMember.Name_Text("update Members set IDLuuTam='" + Capbac.ToString() + "'  where ID=" + IDThanhVien.ToString() + "");
        return "";
    }
    public static string ChiaHH(string TongLevel, string TCapBac, string IDThanhVienMuaHang, string IDThanhViens, string Money, string IDCart)
    {
        Double Cap1 = 0;
        Double Cap2 = 0;
        Double Cap3 = 0;
        Double Cap4 = 0;
        Double Cap5 = 0;

        Cap1 = Convert.ToDouble(Commond.Setting("Nhanvien"));
        Cap2 = Convert.ToDouble(Commond.Setting("TruongNhomKinhDoanh"));
        Cap3 = Convert.ToDouble(Commond.Setting("TruongPhongKinhDoanh"));
        Cap4 = Convert.ToDouble(Commond.Setting("PhoGiamDoc"));
        Cap5 = Convert.ToDouble(Commond.Setting("GiamDocKinhDoanh"));

        double TienDauVao = Convert.ToDouble(Money);
        Double TongTien = 0;
        string Capbac = "";
        #region hoa hồng
        List<Entity.Member> items = SMember.Name_Text("select * from Members where ID=" + IDThanhViens.ToString() + "");
        if (items.Count > 0)
        {
            double Tongphantram = Convert.ToDouble(items[0].CapBac.ToString());
            //Convert.ToDouble(PhanTramLevel(TongLevel, items[0].CapBac.ToString()));
            if (Tongphantram > 0)
            {
                Double Tru = 0;
                string PhanTram = "0" + System.Web.HttpContext.Current.Session["TongPT"].ToString();
                if (PhanTram != "")
                {
                    string[] strArray = PhanTram.ToString().Split(new char[] { ',' });
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        Tru = Convert.ToDouble(strArray[i].ToString());
                        Tongphantram = (Tongphantram - Tru);
                    }
                }
            }
            double PTHH = 0;
            if (Tongphantram > 0)
            {
                System.Web.HttpContext.Current.Session["TongPT"] += "," + Tongphantram;
                #region Tongphantram Mang đi chia
                // số 1,2,3,4 này chính là cấp bậc 1,2,3,4 tương ứng với drop trong quản lý thành viên nhé
                if (Tongphantram == 1)
                {
                    PTHH = Cap1;
                }
                if (Tongphantram == 2)
                {
                    PTHH = Cap2;
                }
                if (Tongphantram == 3)
                {
                    PTHH = Cap3;
                }
                if (Tongphantram == 4)
                {
                    PTHH = Cap4;
                }
                if (Tongphantram == 5)
                {
                    PTHH = Cap5;
                }
                #endregion
                #region TCapBac
                if (TCapBac == "1")
                {
                    Capbac = "Nhân viên";
                }
                if (TCapBac == "2")
                {
                    Capbac = "Trưởng nhóm kinh doanh";
                }
                if (TCapBac == "3")
                {
                    Capbac = "Trưởng phòng kinh doanh";
                }
                if (TCapBac == "4")
                {
                    Capbac = "Phó giám đốc";
                }
                if (TCapBac == "5")
                {
                    Capbac = "Giám đốc kinh doanh";
                }
                #endregion
                if (PTHH > 0)
                {
                    double TongHHTT = (TienDauVao * PTHH) / 100;
                    ThemHoaHong("10", Capbac, TienDauVao.ToString(), IDThanhVienMuaHang.Trim(), items[0].ID.ToString(), PTHH.ToString(), TongHHTT.ToString(), IDCart.ToString());
                    TongTien += TongHHTT;
                    UpdateLoaID(Tongphantram.ToString(), IDThanhVienMuaHang);
                }
            }
            if (Tongphantram >= 5)
            {
                return "1";
            }
            //if (Tongphantram < 0)
            //{
            //    return "1";
            //}
        }
        #endregion
        return "0";
    }
    public static string PhanTramLevel(string ThanhVienA, string ThanhVienB)
    {
        // Lấy trên trừ dưới level A - level B
        Double CBThanhVienA = Convert.ToDouble(ThanhVienA);
        Double CBThanhVienB = Convert.ToDouble(ThanhVienB);
        double TongCong = Convert.ToDouble(CBThanhVienB - CBThanhVienA);
        return TongCong.ToString();
    }

    #region Tìm giá trị lớn nhất trong level để thưởng cho các đời F1 đến F5
    public static string MinAndMax(string c)
    {
        String intString = c.Replace("99999999999,", "");
        int[] strArray = stringArrayToIntArray(intString);
        int max = strArray[0];
        if (strArray.Length > 0)
        {
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i] > max)
                {
                    max = strArray[i];
                }
            }
        }
        if (max.ToString() == "0")
        {
            return "0";
        }
        else
        {
            return max.ToString();
        }
        return "0";
    }
    public static int[] stringArrayToIntArray(String intString)
    {
        String[] intStringSplit = intString.Trim().Split(new char[] { ',' });
        int[] result = new int[intStringSplit.Length]; //Used to store our ints

        for (int i = 0; i < intStringSplit.Length; i++)
        {
            result[i] = int.Parse(intStringSplit[i]);
        }
        return result;
    }
    #endregion;

    public static string KiemTraTongTienHoaHongDaChiaCapBac(string IDDonHang, string IDThanhVien)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        Double num = 0;
        List<HoaHong> items = db.HoaHongs.Where(s => s.IDDonHang == IDDonHang && s.KieuHoaHong == 10 && s.IDThanhVienMua == int.Parse(IDThanhVien)).ToList();// xóa nhiều
        if (items.Count > 0)
        {
            for (int i = 0; i < items.Count; i++)
            {
                num += Convert.ToDouble(items[i].SoTienDuocHuong.ToString());
            }
        }
        return num.ToString();
    }

    //public static bool Kiemtratongcapbac(string IDThanhVien)
    //{
    //    DatalinqDataContext db = new DatalinqDataContext();
    //    List<Entity.Member> tb1 = SMember.Name_Text("select * from Members where GioiThieu=" + IDThanhVien.ToString() + " and ThuPhi=1 ");
    //    if (tb1.Count() > 0)
    //    {
    //        Double CauHinh = Convert.ToDouble(Commond.Setting("DieuKienLenTruongNhomKD"));
    //        Double CauHinhTVCapDuoi = Convert.ToDouble(Commond.Setting("CauHinhTVCapDuoi"));
    //        Double Count = Convert.ToDouble(tb1.Count().ToString());
    //        if (Count >= CauHinh)
    //        {
    //            //var tongthanhvien = db.TongThanhVienBenDuoi_kichhoat(int.Parse(IDThanhVien.ToString())).ToList();
    //            //if (tongthanhvien.Count > 0)
    //            //{
    //            //    Double Counttongthanhvien = Convert.ToDouble(tongthanhvien[0].COUNT.ToString());
    //            //    if (Counttongthanhvien >= CauHinhTVCapDuoi)
    //            //    {
    //            //        return true;
    //            //    }
    //            //}
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }
    //    return false;
    //}
    //public static string NangCapbac(string IDThanhVien)
    //{
    //    List<Entity.Member> data = SMember.Name_Text("select * from Members where ID=" + IDThanhVien.ToString() + "");
    //    if (data.Count() > 0)
    //    {
    //        if (Kiemtratongcapbac(IDThanhVien) == true)
    //        {
    //            if (data[0].CapBac.ToString() == "0")
    //            {
    //                SMember.Name_Text("update Members set CapBac='1'  where ID=" + IDThanhVien.ToString() + "");
    //            }
    //        }
    //    }
    //    return "";
    //}
    public static string ThanhVienGioiTHieu(string IDThanhVien)
    {
        List<Entity.Member> data = SMember.Name_Text("select * from Members where GioiThieu=" + IDThanhVien.ToString() + "  and ThuPhi=1");
        if (data.Count() > 0)
        {
            return data.Count().ToString();
        }
        return "0";
    }
    public static string ThanhVienGioiTHieuChuaKich(string IDThanhVien)
    {
        List<Entity.Member> data = SMember.Name_Text("select * from Members where GioiThieu=" + IDThanhVien.ToString() + " ");
        if (data.Count() > 0)
        {
            return data.Count().ToString();
        }
        return "0";
    }


    // ThemHoaHong("10", Capbac, TienDauVao.ToString(), TongHHTT.ToString(), PTHH.ToString(), IDThanhVienMuaHang.ToString(), items[0].ID.ToString(), IDCart);


    public static void ThemHoaHong(string KieuHoaHong, string KieuHH, string TienDonHang, string IDThanhVienMua, string IDThanhVienHuong, string PhanTram, string SoTienDuocHuong, string IDDonHang)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        List<Entity.Member> F1 = SMember.Name_Text("select * from Members  where ID=" + IDThanhVienHuong.ToString() + " and ThuPhi=1");//DaKichHoat
        if (F1.Count() > 0)
        {
            #region HoaHongThanhVien
            HoaHong obj = new HoaHong();
            obj.KieuHoaHong = int.Parse(KieuHoaHong);
            obj.KieuHH = KieuHH;
            obj.TienDonHang = TienDonHang;
            obj.SoTienDuocHuong = SoTienDuocHuong;
            obj.PhanTram = PhanTram;
            obj.IDThanhVienMua = int.Parse(IDThanhVienMua);
            obj.IDThanhVienHuong = int.Parse(IDThanhVienHuong);
            obj.NgayTao = DateTime.Now;
            obj.IDDonHang = IDDonHang;
            db.HoaHongs.InsertOnSubmit(obj);
            db.SubmitChanges();
            #endregion
            try
            {
                CapNhatTrangThai(IDThanhVienHuong);
            }
            catch (Exception)
            { }
            CongTien(IDThanhVienHuong, SoTienDuocHuong);
        }
    }
    public static void CongTien(string IDUserNguoiDuocHuong, string SoTienDuocHuong)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        #region Cộng điểm theo hoa hồng
        List<Entity.Member> iitem = SMember.Name_Text("select * from Members where ID=" + IDUserNguoiDuocHuong.ToString() + "");
        if (iitem != null)
        {
            double TongSoCoinDaCo = Convert.ToDouble(iitem[0].TienHoaHong);
            double TongTienNapVao = Convert.ToDouble(SoTienDuocHuong);
            double Conglai = 0;
            Conglai = ((TongSoCoinDaCo) + (TongTienNapVao));
            SMember.Name_Text("update Members set TienHoaHong='" + Conglai.ToString() + "'  where ID=" + iitem[0].ID.ToString() + "");
        }
        #endregion
    }
    public static void CongTienTongTienDaMua(string IDThanhVien, string SoTien)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        #region Cộng điểm theo hoa hồng
        List<Entity.Member> iitem = SMember.Name_Text("select * from Members where ID=" + IDThanhVien.ToString() + "");
        if (iitem != null)
        {
            double TongSoCoinDaCo = Convert.ToDouble(iitem[0].TongTienDaMua);
            double TongTienNapVao = Convert.ToDouble(SoTien);
            double Conglai = 0;
            Conglai = ((TongSoCoinDaCo) + (TongTienNapVao));
            SMember.Name_Text("update Members set TongTienDaMua='" + Conglai.ToString() + "'  where ID=" + iitem[0].ID.ToString() + "");
        }
        #endregion
    }




    public static void CapNhatTrangThai(string IDThanhVien)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        List<Entity.Member> F1 = SMember.Name_Text("select * from Members  where ID=" + IDThanhVien.ToString() + " and ThuPhi=1  and ID !=1 and ID !=2 and ID !=3 and ID !=4");//DaKichHoat
        if (F1.Count() > 0)
        {

            #region  Nhân viên (Tìm ra 1 F1 và đã mua 10 triệu tiền hàng)
            if (Other.Giatri("NhanVienTongTien") != "" && Other.Giatri("NhanVienTongTien") != "0")
            {
                Double TongTienC1 = 0;
                List<Entity.Member> Cap1 = SMember.Name_Text("SELECT * FROM Members  WHERE  ((MTree LIKE N'%|" + IDThanhVien + "|%')) and CapBac!=1 and  ThuPhi=1  and ID !=1 and ID !=2 and ID !=3 and ID !=4");
                if (Cap1.Count > 0)
                {
                    foreach (var item in Cap1)
                    {
                        TongTienC1 += Convert.ToDouble(item.TongTienDaMua);
                    }
                }
                if (TongTienC1 >= Convert.ToDouble(Other.Giatri("NhanVienTongTien")))
                {
                    if (Other.Giatri("NhanVienTimRa1F1") != "" && Other.Giatri("NhanVienTimRa1F1") != "0")// đếm F1
                    {
                        List<Entity.Member> Cap22 = SMember.Name_Text("SELECT top " + Other.Giatri("NhanVienTimRa1F1") + " *  FROM Members  WHERE  ((MTree LIKE N'%|" + IDThanhVien + "|%')) and ID!=" + IDThanhVien + " and  ThuPhi=1  and ID !=1 and ID !=2 and ID !=3 and ID !=4");
                        if (Cap22.Count > 0)
                        {
                            if (Convert.ToDouble(Cap22.Count) >= Convert.ToDouble(Other.Giatri("NhanVienTimRa1F1")))
                                SMember.Name_Text("update Members set CapBac=1 where ID=" + IDThanhVien.ToString() + "");
                        }
                    }
                }
            }
            #endregion

            #region Trưởng nhóm kinh doanh (Tìm ra 3 F1 và đã mua 500 triệu tiền hàng)
            if (Other.Giatri("TruongNhomKDTongTien") != "" && Other.Giatri("TruongNhomKDTongTien") != "0")
            {
                Double TongTienC2 = 0;
                List<Entity.Member> Cap1 = SMember.Name_Text("SELECT * FROM Members  WHERE  ((MTree LIKE N'%|" + IDThanhVien + "|%')) and CapBac!=2 and  ThuPhi=1  and ID !=1 and ID !=2 and ID !=3 and ID !=4");
                if (Cap1.Count > 0)
                {
                    foreach (var item in Cap1)
                    {
                        TongTienC2 += Convert.ToDouble(item.TongTienDaMua);
                    }
                    if (TongTienC2 >= Convert.ToDouble(Other.Giatri("TruongNhomKDTongTien")))
                    {
                        if (Other.Giatri("TruongNhomKDF1") != "" && Other.Giatri("TruongNhomKDF1") != "0")// đếm F1
                        {
                            List<Entity.Member> Cap22 = SMember.Name_Text("SELECT top " + Other.Giatri("TruongNhomKDF1") + " *  FROM Members  WHERE  ((MTree LIKE N'%|" + IDThanhVien + "|%')) and ID!=" + IDThanhVien + " and  ThuPhi=1  and ID !=1 and ID !=2 and ID !=3 and ID !=4");
                            if (Cap22.Count > 0)
                            {
                                if (Convert.ToDouble(Cap22.Count) >= Convert.ToDouble(Other.Giatri("TruongNhomKDF1")))
                                    SMember.Name_Text("update Members set CapBac=2 where ID=" + IDThanhVien.ToString() + "");
                            }

                        }
                    }
                }
            }
            #endregion

            #region Trưởng nhóm kinh doanh (Tìm ra 3 F1 và đã mua 500 triệu tiền hàng)
            if (Other.Giatri("TruongNhomKDTongTien") != "" && Other.Giatri("TruongPhongKinhDoanhTongTien") != "0")
            {
                Double TongTienC3 = 0;
                List<Entity.Member> Cap1 = SMember.Name_Text("SELECT * FROM Members  WHERE  ((MTree LIKE N'%|" + IDThanhVien + "|%')) and CapBac!=3 and  ThuPhi=1  and ID !=1 and ID !=2 and ID !=3 and ID !=4");
                if (Cap1.Count > 0)
                {
                    foreach (var item in Cap1)
                    {
                        TongTienC3 += Convert.ToDouble(item.TongTienDaMua);
                    }
                    if (TongTienC3 >= Convert.ToDouble(Other.Giatri("TruongPhongKinhDoanhTongTien")))
                    {
                        if (Other.Giatri("TruongPhongKinhDoanhF1") != "" && Other.Giatri("TruongPhongKinhDoanhF1") != "0")// đếm F1
                        {
                            List<Entity.Member> Cap22 = SMember.Name_Text("SELECT top " + Other.Giatri("TruongPhongKinhDoanhF1") + " *  FROM Members  WHERE  ((MTree LIKE N'%|" + IDThanhVien + "|%')) and ID!=" + IDThanhVien + " and  ThuPhi=1 and CapBac=2 and ID !=1 and ID !=2 and ID !=3 and ID !=4");
                            if (Cap22.Count > 0)
                            {
                                if (Convert.ToDouble(Cap22.Count) >= Convert.ToDouble(Other.Giatri("TruongPhongKinhDoanhF1")))
                                    SMember.Name_Text("update Members set CapBac=3 where ID=" + IDThanhVien.ToString() + " ");
                            }

                        }
                    }
                }
            }
            #endregion

            #region Phó giám đốc (Tìm ra 3 Trưởng nhóm kinh doanh  và đã mua 5 tỷ tiền hàng)
            if (Other.Giatri("PhoGiamDocTien") != "" && Other.Giatri("PhoGiamDocTien") != "0")
            {
                Double TongTienC4 = 0;
                List<Entity.Member> Cap1 = SMember.Name_Text("SELECT * FROM Members  WHERE  ((MTree LIKE N'%|" + IDThanhVien + "|%')) and CapBac!=4 and  ThuPhi=1  and ID !=1 and ID !=2 and ID !=3 and ID !=4");
                if (Cap1.Count > 0)
                {
                    foreach (var item in Cap1)
                    {
                        TongTienC4 += Convert.ToDouble(item.TongTienDaMua);
                    }
                    if (TongTienC4 >= Convert.ToDouble(Other.Giatri("PhoGiamDocTien")))
                    {
                        if (Other.Giatri("PhoGiamDocF1") != "" && Other.Giatri("PhoGiamDocF1") != "0")// đếm F1
                        {
                            List<Entity.Member> Cap22 = SMember.Name_Text("SELECT top " + Other.Giatri("PhoGiamDocF1") + " *  FROM Members  WHERE  ((MTree LIKE N'%|" + IDThanhVien + "|%')) and ID!=" + IDThanhVien + " and  ThuPhi=1 and CapBac=3  and ID !=1 and ID !=2 and ID !=3 and ID !=4");
                            if (Cap22.Count > 0)
                            {
                                if (Convert.ToDouble(Cap22.Count) >= Convert.ToDouble(Other.Giatri("PhoGiamDocF1")))
                                    SMember.Name_Text("update Members set CapBac=4 where ID=" + IDThanhVien.ToString() + "");
                            }

                        }
                    }
                }
            }
            #endregion

            #region Giám đốc kinh doanh (Tìm ra 3 Phó giám đốc  và đã mua 50 tỷ tiền hàng)
            if (Other.Giatri("GiamDocKinhDoanhTien") != "" && Other.Giatri("GiamDocKinhDoanhTien") != "0")
            {
                Double TongTienC5 = 0;
                List<Entity.Member> Cap1 = SMember.Name_Text("SELECT * FROM Members  WHERE  ((MTree LIKE N'%|" + IDThanhVien + "|%')) and CapBac!=5 and  ThuPhi=1  and ID !=1 and ID !=2 and ID !=3 and ID !=4");
                if (Cap1.Count > 0)
                {
                    foreach (var item in Cap1)
                    {
                        TongTienC5 += Convert.ToDouble(item.TongTienDaMua);
                    }
                    if (TongTienC5 >= Convert.ToDouble(Other.Giatri("GiamDocKinhDoanhTien")))
                    {
                        if (Other.Giatri("GiamDocKinhDoanhF1") != "" && Other.Giatri("GiamDocKinhDoanhF1") != "0")// đếm F1
                        {
                            List<Entity.Member> Cap22 = SMember.Name_Text("SELECT top " + Other.Giatri("GiamDocKinhDoanhF1") + " *  FROM Members  WHERE  ((MTree LIKE N'%|" + IDThanhVien + "|%')) and ID!=" + IDThanhVien + " and  ThuPhi=1 and CapBac=4 and ID !=1 and ID !=2 and ID !=3 and ID !=4");
                            if (Cap22.Count > 0)
                            {
                                if (Convert.ToDouble(Cap22.Count) >= Convert.ToDouble(Other.Giatri("GiamDocKinhDoanhF1")))
                                    SMember.Name_Text("update Members set CapBac=5 where ID=" + IDThanhVien.ToString() + "");
                            }

                        }
                    }
                }
            }
            #endregion
        }
    }
}


