using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using Framwork;
using System.Data;

namespace Services
{
    public class SProducts
    {
        private static Fproducts db = new Fproducts();

        #region SearchPro
        public static List<Category_Product> SearchPro_locTongbanghi(string keyword, string icid, string chuoi, string lang, string Status)
        {
            return db.SearchPro_locTongbanghi(keyword, icid, chuoi, lang, Status);
        }
        public static List<Category_Product> SearchPro_loc(string keyword, string icid, string chuoi, string lang, string Status, int PageIndex, int Tongpage)
        {
            return db.SearchPro_loc(keyword, icid, chuoi, lang, Status, PageIndex, Tongpage);
        }
        #endregion
        #region CATEGORY
        public static List<Category_Product> CATEGORY_PHANTRANG1(string icid, string lang)
        {
            return db.CATEGORY_PHANTRANG1(icid, lang);
        }
        public static List<Category_Product> CATEGORY_PHANTRANG2(string icid, string lang, string sapxep, int PageIndex, int Tongpage)
        {
            return db.CATEGORY_PHANTRANG2(icid, lang, sapxep, PageIndex, Tongpage);
        }
        #endregion


        #region CATEGORY_PHANTRANG_ADMIN
        public static List<Products> CATEGORY_PHANTRANG_ADMIN1(string icid, string filter, string lang)
        {
            return db.CATEGORY_PHANTRANG_ADMIN1(icid, filter, lang);
        }
        public static List<Products> CATEGORY_PHANTRANG_ADMIN2(string icid, string filter, string lang, string sapxep, int PageIndex, int Tongpage)
        {
            return db.CATEGORY_PHANTRANG_ADMIN2(icid, filter, lang, sapxep, PageIndex, Tongpage);
        }
        #endregion

        #region CATEGORY_PHANTRANG
        //public static List<Category_Product> CATEGORY_PHANTRANG(string icid, string lang, string Status, int PageIndex, int Tongpage)
        //{
        //    return db.CATEGORY_PHANTRANG(icid, lang, Status, PageIndex, Tongpage);
        //}
        #endregion

        #region SearchPro
        public static List<Category_Product> SearchPro(string keyword, string lang, string Status, int PageIndex, ref int TotalRecords, int Tongpage)
        {
            return db.SearchPro(keyword, lang, Status, PageIndex, ref TotalRecords, Tongpage);
        }
        #endregion

        #region CATEGORY_PHANTRANG
        public static List<Category_Product> CATEGORY_PHANTRANG(string icid, string lang, string Status, int PageIndex, ref int TotalRecords, int Tongpage)
        {
            return db.CATEGORY_PHANTRANG(icid, lang, Status, PageIndex, ref TotalRecords, Tongpage);
        }
        #endregion

        #region News_All
        public static List<Category_Product> Product_All(string lang, string Status, int PageIndex, ref int TotalRecords, int Tongpage)
        {
            return db.Product_All(lang, Status, PageIndex, ref TotalRecords, Tongpage);
        }
        #endregion

        #region[GetById]
        public static List<Products> GetById(string Id)
        {
            return db.GetById(Id);
        }
        #endregion

        #region[GetById]
        public static void Detail_ID(DataTable dt, string ipid)
        {
            db.Detail_ID(dt, ipid);
        }
        #endregion

        #region[More_icid]
        public static List<Products> More_icid(string icid)
        {
            return db.More_icid(icid);
        }
        #endregion

        #region[GetByAll]
        public static List<Products> GetByAll(string Lang)
        {
            return db.GetByAll(Lang);
        }
        #endregion

        #region[Insert]
        public static bool Insert(Products data)
        {
            return db.Insert(data);
        }
        #endregion

        #region[Update]
        public static bool Update(Products data)
        {
            return db.Update(data);
        }
        #endregion

        #region[Delete]
        public static void Delete(string Id)
        {
            db.Delete(Id);
        }
        #endregion

        #region[Cate_Delete_icid]
        public static void Cate_Delete_icid(string icid)
        {
            db.Cate_Delete_icid(icid);
        }
        #endregion

        #region[CategoryAdmin]
        public static List<Products> CategoryAdmin(string orderby, string searchkeyword, string[] searchfields, string icid, string lang, string Status, string Vitri)
        {
            return db.CategoryAdmin(orderby, searchkeyword, searchfields, icid, lang, Status, Vitri);
        }
        #endregion

        #region List_ToolTip
        public static List<Products> List_ToolTip(string lang)
        {
            return db.GetByAll(lang);
        }
        #endregion

        #region CategoryDisplay
        public static List<Products> CategoryDisplay(string icid, string lang, string Status)
        {
            return db.CategoryDisplay(icid, lang, Status);
        }
        #endregion

        #region NewxTopNewsAfterNews
        public static List<Products> NewxTopNewsAfterNews(string cid, string pid, int top, string lang)
        {
            return db.NewxTopNewsAfterNews(cid, pid, top, lang);
        }
        #endregion

        #region GetTopProductInCategory
        public static List<Category_Product> GetTopProductInCategory(string top, string cateid, string imcid)
        {
            return db.GetTopProductInCategory(top, cateid, imcid);
        }
        #endregion

        #region UpdateViewTimes
        public static bool UpdateViewTimes(string ipid)
        {
            return db.UpdateViewTimes(ipid);
        }
        #endregion

        #region Chekdata
        public static List<Products> Chekdata(string ipid, string Chekdata, DateTime Create_Date, DateTime Modified_Date)
        {
            return db.Chekdata(ipid, Chekdata, Create_Date, Modified_Date);
        }
        #endregion

        #region Update_datetime
        public static List<Products> Update_datetime(string ipid, DateTime Create_Date, DateTime Modified_Date)
        {
            return db.Update_datetime(ipid, Create_Date, Modified_Date);
        }
        #endregion

        #region Update_Images
        public static bool Update_Images(string ipid, string Images, string ImagesSmall)
        {
            return db.Update_Images(ipid, Images, ImagesSmall);
        }
        #endregion

        #region Check
        #region Update_Status
        public static List<Products> Update_Status(string ipid, string Status)
        {
            return db.Update_Status(ipid, Status);
        }
        #endregion
        #region Update_News
        public static List<Products> Update_News(string ipid, string News)
        {
            return db.Update_News(ipid, News);
        }
        #endregion
        #region Update_Home
        public static List<Products> Update_Home(string ipid, string Home)
        {
            return db.Update_Home(ipid, Home);
        }
        #endregion
        #region Update_Check_01
        public static List<Products> Update_Check_01(string ipid, string Check_01)
        {
            return db.Update_Check_01(ipid, Check_01);
        }
        #endregion
        #region Update_Check_02
        public static List<Products> Update_Check_02(string ipid, string Check_02)
        {
            return db.Update_Check_02(ipid, Check_02);
        }
        #endregion
        #region Update_Check_03
        public static List<Products> Update_Check_03(string ipid, string Check_03)
        {
            return db.Update_Check_03(ipid, Check_03);
        }
        #endregion
        #region Update_Check_04
        public static List<Products> Update_Check_04(string ipid, string Check_04)
        {
            return db.Update_Check_04(ipid, Check_04);
        }
        #endregion
        #region Update_Check_05
        public static List<Products> Update_Check_05(string ipid, string Check_05)
        {
            return db.Update_Check_05(ipid, Check_05);
        }
        #endregion
        #endregion

        #region pro_new
        public static List<Products> pro_new(string top)
        {
            return db.pro_new(top);
        }
        #endregion

        #region pro_vip
        public static List<Products> pro_vip(string top)
        {
            return db.pro_vip(top);
        }
        #endregion

        #region pro_show
        public static List<Products> pro_show(string top)
        {
            return db.pro_show(top);
        }
        #endregion

        #region pro_mostview
        public static List<Products> pro_mostview(string top)
        {
            return db.pro_mostview(top);
        }
        #endregion

        #region pro_sellmost
        public static List<Products> pro_sellmost(string top)
        {
            return db.pro_sellmost(top);
        }
        #endregion

        #region Search
        public static List<Products> Search(string keyword, string lang)
        {
            return db.Search(keyword, lang);
        }
        #endregion

        #region Search
        public static List<Category_Product> SearchNews(string keyword, string lang)
        {
            return db.SearchNews(keyword, lang);
        }
        #endregion

        #region pronew_id
        public static List<Products> pronew_id(string top, string icid)
        {
            return db.pronew_id(top, icid);
        }
        #endregion

        #region prosellmost_id
        public static List<Products> prosellmost_id(string top, string icid)
        {
            return db.prosellmost_id(top, icid);
        }
        #endregion

        #region Name_Text
        public static List<Products> Name_Text(string Name_Text)
        {
            return db.Name_Text(Name_Text);
        }
        #endregion
        #region Name_Text_Rg
        //ipid,icid,TangName,Name,Images,ImagesSmall,Brief,Create_Date,Price,OldPrice,ID_Hang,sanxuat,Code
        public static List<Category_Product> Name_Text_Rg(string Name_Text)
        {
            return db.Name_Text_Rg(Name_Text);
        }


        #endregion
        #region Product_Count
        public static List<Product_Count> Product_Count(string Name_Text)
        {
            return db.Product_Count(Name_Text);
        }
        #endregion

        public static List<Category_Product> S_products_NoiChuoi(string Name_Text)
        {
            return db.S_products_NoiChuoi(Name_Text);
        }


    }
}
