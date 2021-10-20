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
    public class SosanhCarts
    {
        #region "Cart"
        public static void ShoppingCart_CreateCart()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PID", typeof(Int32));
            System.Web.HttpContext.Current.Session["Sosanh"] = dt;
        }
        public static void ShoppingCart_RemoveProduct(string pid)
        {
            DataTable dtcart = new DataTable();
            dtcart = (DataTable)System.Web.HttpContext.Current.Session["Sosanh"];
            for (int i = 0; i < dtcart.Rows.Count; i++)
            {
                if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
                {
                    dtcart.Rows.RemoveAt(i);
                    break;
                }
            }
            System.Web.HttpContext.Current.Session["Sosanh"] = dtcart;
        }
        public static void ShoppingCart_AddProduct(string pid)
        {
            if (System.Web.HttpContext.Current.Session["Sosanh"] == null)
            {
                // create session cart.
                ShoppingCart_CreateCart();
                ShoppingCart_AddProduct(pid);
            }
            else
            {
                List<Products> dt = new List<Products>();
                // lay chi tiet san pham.
                dt = SProducts.GetById(pid);
                if (dt.Count > 0)
                {
                    DataTable dtcart = new DataTable();
                    dtcart = (DataTable)System.Web.HttpContext.Current.Session["Sosanh"];
                    bool hasincart = false;
                    for (int i = 0; i < dtcart.Rows.Count; i++)
                    {
                        if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
                        {
                            hasincart = true;
                            // cap nhat thong tin cua cart.
                            System.Web.HttpContext.Current.Session["Sosanh"] = dtcart;
                            break;
                        }
                    }
                    if (hasincart == false)
                    {
                        if (dtcart != null)
                        {
                            DataRow dr = dtcart.NewRow();
                            dr["PID"] = pid;
                            dtcart.Rows.Add(dr);
                            System.Web.HttpContext.Current.Session["Sosanh"] = dtcart;
                        }
                    }
                }
            }
        }
        public static string Xoasanhnhe(string id)
        {
            string Chuoi = "";
            if (System.Web.HttpContext.Current.Session["Sosanh"] != null)
            {
                DataTable dtcart = (DataTable)System.Web.HttpContext.Current.Session["Sosanh"];
                if (dtcart.Rows.Count > 0)
                {
                    for (int i = 0; i < dtcart.Rows.Count; i++)
                    {
                        if (dtcart.Rows[i]["PID"].ToString() == id.ToString())
                        {
                            Chuoi = "display:none";
                        }
                    }
                }
            }
            else
            {
               // Chuoi = "display:block";
            }
            return Chuoi;
        }
        public static string Xoasanhnhe2(string id)
        {
            string Chuoi = "";
            if (System.Web.HttpContext.Current.Session["Sosanh"] != null)
            {
                DataTable dtcart = (DataTable)System.Web.HttpContext.Current.Session["Sosanh"];
                if (dtcart.Rows.Count > 0)
                {
                    for (int i = 0; i < dtcart.Rows.Count; i++)
                    {
                        if (dtcart.Rows[i]["PID"].ToString() == id.ToString())
                        {
                            Chuoi = "display:block";
                        }
                    }
                }
            }
            else
            {
               // Chuoi = "display:none";
            }
            return Chuoi;
        }
        public static string Sosanhnhe(string id)
        {
            string Chuoi = "";
            if (System.Web.HttpContext.Current.Session["Sosanh"] != null)
            {
                DataTable dtcart = (DataTable)System.Web.HttpContext.Current.Session["Sosanh"];
                if (dtcart.Rows.Count > 0)
                {
                    for (int i = 0; i < dtcart.Rows.Count; i++)
                    {
                        if (dtcart.Rows[i]["PID"].ToString() == id.ToString())
                        {
                            Chuoi = "<input id='" + id + "' type='checkbox' checked='checked' />";
                        }
                    }
                }
            }
            else
            {
                Chuoi = "<input id='" + id + "' type='checkbox'  />";
            }
            return Chuoi;
        }
        #endregion
    }
}



