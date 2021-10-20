using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framwork;
using Entity;

namespace Services
{
    public class SProduct_images
    {
        private static FProduct_images db = new FProduct_images();
        #region [GetById]
        public static List<Product_images> GetById(string Id)
        {
            return db.GetById(Id);
        }
        #endregion

        #region [More_icid]
        public static List<Product_images> More_icid(string icid)
        {
            return db.More_icid(icid);
        }
        #endregion
        #region [GetByAll]
        public static List<Product_images> GetByAll()
        {
            return db.GetByAll();
        }
        #endregion
        #region Cate_Delete_icid
        public static void Cate_Delete_icid(string cid)
        {
             db.Cate_Delete_icid(cid);
        }
        #endregion
        #region [Insert]
        public static bool Insert(Product_images data)
        {
            return db.Insert(data);
        }
        #endregion
        #region [Update]
        public static bool Update(Product_images data)
        {
            return db.Update(data);
        }
        #endregion
        #region [Delete]
        public static void Delete(string Id)
        {
             db.Delete(Id);
        }
        #endregion
        #region [Delete_Ipid]
        public static void Delete_Ipid(string Id)
        {
             db.Delete_Ipid(Id);
        }
        #endregion
        #region prods_images_upate_status
        public static bool upate_status(string ID, string status)
        {
            return db.upate_status(ID, status);
        }
        #endregion
        #region GetBy_ipid
        public static List<Product_images> GetBy_ipid(string ipid)
        {
            return db.GetBy_ipid(ipid);
        }
        #endregion
        #region Update_img
        public static bool Update_img(string ipid, string Images, string ImagesSmall)
        {
            return db.Update_img(ipid, Images, ImagesSmall);
        }
        #endregion
    }
}
