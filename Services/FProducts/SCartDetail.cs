using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framwork;
using Entity;
using System.Data;

namespace Services
{
    public class SCartDetail
    {
        private static FCartDetail db = new FCartDetail();
        #region Detail_ID_Cart
        public static List<Entity.CartDetail> Detail_ID_Cart(string ID_Cart)
        {
            return db.Detail_ID_Cart(ID_Cart);
        }
        #endregion             
        #region GetDetailbyId
        public static List<Entity.CartDetail> GetDetail(String id)
        {
            return db.GetById(id);
        }
        #endregion
        #region Delete_by_CartID
        public static void Delete_by_CartID(string ID_Carte)
        {
             db.Delete_ID_Cart(ID_Carte);
        }
        #endregion
        #region Delete
        public static void Delete(string id)
        {
             db.Delete(id);
        }
        #endregion
        #region Insert
        public static bool CartDetail_Insert(CartDetail obj)
        {
            return db.Insert(obj);
        }
        #endregion
        #region CartDetail_List_Cart_Pro
        public void CartDetail_List_Cart_Pro(DataTable dts, string ID_Cart)
        {
            db.CartDetail_List_Cart_Pro(dts, ID_Cart);
        }
        #endregion

        #region Name_Text
        public static List<Entity.CartDetail> Name_Text(string Name_Text)
        {
            return db.Name_Text(Name_Text);
        }
        #endregion
    }

}
