using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framwork;
using Entity;
using System.Data.SqlClient;
using System.Data;


namespace Services
{
    public class SCarts
    {
        private static FCarts db = new FCarts();
        #region p_cartslist_count
        public static List<Carts> p_cartslist_count(string status, string keyword)
        {
            return db.p_cartlist_count(status, keyword);
        }
        #endregion

        #region p_cart_UpdateStatus
        public static bool UpdateStatus(string ino, string istatus)
        {
            return db.UpdateStatus(ino, istatus);
        }
        #endregion

        #region Carts_GetById
        public static List<Carts> Carts_GetById(String id)
        {
            return db.GetById(id);
        }
        #endregion

        #region Carts_Delete
        public static void Carts_Delete(string id)
        {
            db.Delete(id);
        }
        #endregion

        //public static int Insert(string Name, string Address, string Phone, string Email, string Contents, string Money, string lang, string Status)
        //{
        //    return db.Insert(Name, Address, Phone, Email, Contents, Money, lang, Status);
        //}
        //#region Carts_Insert
        //public static int Carts_Insert(Carts obj)
        //{
        //    return db.Insert(obj);
        //}
        //#endregion

        #region Name_Text
        public static List<Carts> Name_Text(string Name_Text)
        {
            return db.Name_Text(Name_Text);
        }
        #endregion

    }
}
