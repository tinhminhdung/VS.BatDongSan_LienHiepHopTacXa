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
    public class SessionCarts
    {
        #region "Cart"
        public static void ShoppingCreateCart()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PID", typeof(Int32));
            dt.Columns.Add("Vimg", typeof(String));
            dt.Columns.Add("Name", typeof(String));
            dt.Columns.Add("Price", typeof(float));
            dt.Columns.Add("Quantity", typeof(Int32));
            dt.Columns.Add("Money", typeof(float));
            dt.Columns.Add("Ghichu", typeof(String));
            dt.Columns.Add("Mausac", typeof(Int32));
            dt.Columns.Add("Kichco", typeof(Int32));
            System.Web.HttpContext.Current.Session["cart"] = dt;
        }

        static void ShoppingCart_CreateCart()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PID", typeof(Int32));
            dt.Columns.Add("Vimg", typeof(String));
            dt.Columns.Add("Name", typeof(String));
            dt.Columns.Add("Price", typeof(float));
            dt.Columns.Add("Quantity", typeof(Int32));
            dt.Columns.Add("Money", typeof(float));
            dt.Columns.Add("Mausac", typeof(Int32));
            dt.Columns.Add("Kichco", typeof(Int32));
            System.Web.HttpContext.Current.Session["cart"] = dt;
        }

        public static void ShoppingCart_RemoveProduct(string pid)
        {
            DataTable dtcart = new DataTable();
            dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];

            for (int i = 0; i < dtcart.Rows.Count; i++)
            {
                if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
                {
                    dtcart.Rows.RemoveAt(i);
                    break;
                }
            }
            System.Web.HttpContext.Current.Session["cart"] = dtcart;
        }

        public static void Cart_UpdateNumber(ref DataTable dtcart, string pid, string quantity)
        {
            if (dtcart.Rows.Count > 0)
            {
                for (int i = 0; i < dtcart.Rows.Count; i++)
                {

                    if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
                    {
                        dtcart.Rows[i]["Quantity"] = quantity;
                        dtcart.Rows[i]["Money"] = Convert.ToInt32(quantity) * Convert.ToDouble(dtcart.Rows[i]["Price"].ToString());
                        return;
                    }
                }
            }
        }

        public static void Cart_Updatequantity(ref DataTable dtcart, string pid, string quantity)
        {
            if (dtcart.Rows.Count > 0)
            {
                for (int i = 0; i < dtcart.Rows.Count; i++)
                {

                    if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
                    {
                        dtcart.Rows[i]["quantity"] = quantity;
                        dtcart.Rows[i]["Money"] = Convert.ToInt32(quantity) * Convert.ToDouble(dtcart.Rows[i]["Price"].ToString());
                        return;
                    }
                }
            }
        }

        public static void ShoppingCart_AddProduct(string pid, int quantity)
        {
            if (System.Web.HttpContext.Current.Session["cart"] == null)
            {
                // create session cart.
                ShoppingCart_CreateCart();
                ShoppingCart_AddProduct(pid, quantity);
            }
            else
            {
                List<Products> dt = new List<Products>();
                // lay chi tiet san pham.
                dt = SProducts.GetById(pid);
                if (dt.Count > 0)
                {
                    string vimg = dt[0].Images.ToString();
                    string name = dt[0].Name.ToString();
                    if (!dt[0].Price.ToString().Equals(""))
                    {
                        float price = Convert.ToSingle(dt[0].Price);
                        float money = price * quantity;
                        DataTable dtcart = new DataTable();
                        dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
                        bool hasincart = false;
                        for (int i = 0; i < dtcart.Rows.Count; i++)
                        {
                            if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
                            {
                                hasincart = true;
                                // cap nhat thong tin cua cart.
                                quantity += Convert.ToInt32(dtcart.Rows[i]["Quantity"]);
                                dtcart.Rows[i]["Quantity"] = quantity;
                                dtcart.Rows[i]["Money"] = quantity * Convert.ToSingle(dtcart.Rows[i]["Price"]);
                                System.Web.HttpContext.Current.Session["cart"] = dtcart;
                                break;
                            }
                        }
                        if (hasincart == false)
                        {
                            if (dtcart != null)
                            {
                                DataRow dr = dtcart.NewRow();
                                dr["PID"] = pid;
                                dr["Vimg"] = vimg;
                                dr["Name"] = name;
                                dr["Price"] = price;
                                dr["Quantity"] = quantity;
                                dr["Money"] = money;
                                dtcart.Rows.Add(dr);
                                System.Web.HttpContext.Current.Session["cart"] = dtcart;
                            }
                        }
                    }
                    else
                    {
                        float price = Convert.ToSingle(0);
                        float money = price * quantity;
                        DataTable dtcart = new DataTable();
                        dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
                        bool hasincart = false;
                        for (int i = 0; i < dtcart.Rows.Count; i++)
                        {
                            if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
                            {
                                hasincart = true;
                                // cap nhat thong tin cua cart.
                                quantity += Convert.ToInt32(dtcart.Rows[i]["Quantity"]);
                                dtcart.Rows[i]["Quantity"] = quantity;
                                dtcart.Rows[i]["Money"] = quantity * Convert.ToSingle(dtcart.Rows[i]["Price"]);
                                System.Web.HttpContext.Current.Session["cart"] = dtcart;
                                break;
                            }
                        }
                        if (hasincart == false)
                        {
                            if (dtcart != null)
                            {
                                DataRow dr = dtcart.NewRow();
                                dr["PID"] = pid;
                                dr["Vimg"] = vimg;
                                dr["Name"] = name;
                                dr["Price"] = price;
                                dr["Quantity"] = quantity;
                                dr["Money"] = money;
                                dtcart.Rows.Add(dr);
                                System.Web.HttpContext.Current.Session["cart"] = dtcart;
                            }
                        }
                    }
                }
            }

        }

        //protected static string AddProductAPI(string pid, int quantity, string Mausac, string Kichco)
        //{
        //    if (System.Web.HttpContext.Current.Session["cart"] == null)
        //    {
        //        // create session cart.
        //        ShoppingCart_CreateCart();
        //        AddProductAPI(pid, quantity, Mausac, Kichco);
        //    }
        //    else
        //    {
        //        List<Products> dt = new List<Products>();
        //        // lay chi tiet san pham.
        //        dt = SProducts.GetById(pid);
        //        if (dt.Count > 0)
        //        {
        //            string vimg = dt[0].Images.ToString();
        //            string name = dt[0].Name.ToString();

        //            if (!dt[0].Price.ToString().Equals(""))
        //            {
        //                float price = Convert.ToSingle(dt[0].Price);
        //                float money = price * quantity;
        //                DataTable dtcart = new DataTable();
        //                dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
        //                bool hasincart = false;
        //                for (int i = 0; i < dtcart.Rows.Count; i++)
        //                {
        //                    if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
        //                    {
        //                        hasincart = true;
        //                        // cap nhat thong tin cua cart.
        //                        quantity += Convert.ToInt32(dtcart.Rows[i]["Quantity"]);
        //                        dtcart.Rows[i]["Quantity"] = quantity;
        //                        dtcart.Rows[i]["Money"] = quantity * Convert.ToSingle(dtcart.Rows[i]["Price"]);
        //                        dtcart.Rows[i]["Mausac"] = Mausac;
        //                        dtcart.Rows[i]["Kichco"] = Kichco;
        //                        System.Web.HttpContext.Current.Session["cart"] = dtcart;
        //                        break;
        //                    }
        //                }
        //                if (hasincart == false)
        //                {
        //                    if (dtcart != null)
        //                    {
        //                        DataRow dr = dtcart.NewRow();
        //                        dr["PID"] = pid;
        //                        dr["Vimg"] = vimg;
        //                        dr["Name"] = name;
        //                        dr["Price"] = price;
        //                        dr["Quantity"] = quantity;
        //                        dr["Money"] = money;
        //                        dr["Mausac"] = Mausac;
        //                        dr["Kichco"] = Kichco;
        //                        dtcart.Rows.Add(dr);
        //                        System.Web.HttpContext.Current.Session["cart"] = dtcart;
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                float price = Convert.ToSingle(0);
        //                float money = price * quantity;
        //                DataTable dtcart = new DataTable();
        //                dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
        //                bool hasincart = false;
        //                for (int i = 0; i < dtcart.Rows.Count; i++)
        //                {
        //                    if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
        //                    {
        //                        hasincart = true;
        //                        // cap nhat thong tin cua cart.
        //                        quantity += Convert.ToInt32(dtcart.Rows[i]["Quantity"]);
        //                        dtcart.Rows[i]["Quantity"] = quantity;
        //                        dtcart.Rows[i]["Money"] = quantity * Convert.ToSingle(dtcart.Rows[i]["Price"]);
        //                        dtcart.Rows[i]["Mausac"] = Mausac;
        //                        dtcart.Rows[i]["Kichco"] = Kichco;
        //                        System.Web.HttpContext.Current.Session["cart"] = dtcart;
        //                        break;
        //                    }
        //                }
        //                if (hasincart == false)
        //                {
        //                    if (dtcart != null)
        //                    {
        //                        DataRow dr = dtcart.NewRow();
        //                        dr["PID"] = pid;
        //                        dr["Vimg"] = vimg;
        //                        dr["Name"] = name;
        //                        dr["Price"] = price;
        //                        dr["Quantity"] = quantity;
        //                        dr["Money"] = money;
        //                        dr["Mausac"] = Mausac;
        //                        dr["Kichco"] = Kichco;
        //                        dtcart.Rows.Add(dr);
        //                        System.Web.HttpContext.Current.Session["cart"] = dtcart;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return "OKOKPK";
        //}


        public static void ShoppingCart_AddProduct_Sesion(string pid, int quantity, string Mausac, string Kichco)
        {
            if (System.Web.HttpContext.Current.Session["cart"] == null)
            {
                // create session cart.
                ShoppingCart_CreateCart();
                ShoppingCart_AddProduct_Sesion(pid, quantity, Mausac, Kichco);
            }
            else
            {
                List<Products> dt = new List<Products>();
                // lay chi tiet san pham.
                dt = SProducts.GetById(pid);
                if (dt.Count > 0)
                {
                    string vimg = dt[0].Images.ToString();
                    string name = dt[0].Name.ToString();
                    if (!dt[0].Price.ToString().Equals(""))
                    {
                        float price = Convert.ToSingle(dt[0].Price);
                        float money = price * quantity;
                        DataTable dtcart = new DataTable();
                        dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
                        bool hasincart = false;
                        for (int i = 0; i < dtcart.Rows.Count; i++)
                        {
                            if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
                            {
                                hasincart = true;
                                // cap nhat thong tin cua cart.
                                quantity += Convert.ToInt32(dtcart.Rows[i]["Quantity"]);
                                dtcart.Rows[i]["Quantity"] = quantity;
                                dtcart.Rows[i]["Money"] = quantity * Convert.ToSingle(dtcart.Rows[i]["Price"]);
                                dtcart.Rows[i]["Mausac"] = Mausac;
                                dtcart.Rows[i]["Kichco"] = Kichco;
                                System.Web.HttpContext.Current.Session["cart"] = dtcart;
                                break;
                            }
                        }
                        if (hasincart == false)
                        {
                            if (dtcart != null)
                            {
                                DataRow dr = dtcart.NewRow();
                                dr["PID"] = pid;
                                dr["Vimg"] = vimg;
                                dr["Name"] = name;
                                dr["Price"] = price;
                                dr["Quantity"] = quantity;
                                dr["Money"] = money;
                                dr["Mausac"] = Mausac;
                                dr["Kichco"] = Kichco;
                                dtcart.Rows.Add(dr);
                                System.Web.HttpContext.Current.Session["cart"] = dtcart;
                            }
                        }
                    }
                    else
                    {
                        float price = Convert.ToSingle(0);
                        float money = price * quantity;
                        DataTable dtcart = new DataTable();
                        dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
                        bool hasincart = false;
                        for (int i = 0; i < dtcart.Rows.Count; i++)
                        {
                            if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
                            {
                                hasincart = true;
                                // cap nhat thong tin cua cart.
                                quantity += Convert.ToInt32(dtcart.Rows[i]["Quantity"]);
                                dtcart.Rows[i]["Quantity"] = quantity;
                                dtcart.Rows[i]["Money"] = quantity * Convert.ToSingle(dtcart.Rows[i]["Price"]);
                                dtcart.Rows[i]["Mausac"] = Mausac;
                                dtcart.Rows[i]["Kichco"] = Kichco;
                                System.Web.HttpContext.Current.Session["cart"] = dtcart;
                                break;
                            }
                        }
                        if (hasincart == false)
                        {
                            if (dtcart != null)
                            {
                                DataRow dr = dtcart.NewRow();
                                dr["PID"] = pid;
                                dr["Vimg"] = vimg;
                                dr["Name"] = name;
                                dr["Price"] = price;
                                dr["Quantity"] = quantity;
                                dr["Money"] = money;
                                dr["Mausac"] = Mausac;
                                dr["Kichco"] = Kichco;
                                dtcart.Rows.Add(dr);
                                System.Web.HttpContext.Current.Session["cart"] = dtcart;
                            }
                        }
                    }
                }
            }
        }
        public static void AddProduct(string pid, int quantity)
        {
            if (System.Web.HttpContext.Current.Session["cart"] == null)
            {
                // create session cart.
                ShoppingCart_CreateCart();
                AddProduct(pid, quantity);
            }
            else
            {
                List<Products> dt = new List<Products>();
                // lay chi tiet san pham.
                dt = SProducts.GetById(pid);
                if (dt.Count > 0)
                {
                    string name = dt[0].Name.ToString();
                    string vimg = dt[0].Images.ToString();
                    if (!dt[0].Price.ToString().Equals(""))
                    {
                        float price = Convert.ToSingle(dt[0].Price);
                        float money = price * quantity;
                        DataTable dtcart = new DataTable();
                        dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
                        bool hasincart = false;
                        for (int i = 0; i < dtcart.Rows.Count; i++)
                        {
                            if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
                            {
                                hasincart = true;
                                // cap nhat thong tin cua cart.
                                quantity += Convert.ToInt32(dtcart.Rows[i]["Quantity"]);
                                dtcart.Rows[i]["Quantity"] = quantity;
                                dtcart.Rows[i]["Money"] = quantity * Convert.ToSingle(dtcart.Rows[i]["Price"]);

                                //
                                System.Web.HttpContext.Current.Session["cart"] = dtcart;
                                break;
                            }
                        }
                        if (hasincart == false)
                        {
                            if (dtcart != null)
                            {
                                DataRow dr = dtcart.NewRow();
                                dr["PID"] = pid;
                                dr["Vimg"] = vimg;
                                dr["Name"] = name;
                                dr["Price"] = price;
                                dr["Quantity"] = quantity;
                                dr["Money"] = money;
                                dtcart.Rows.Add(dr);
                                System.Web.HttpContext.Current.Session["cart"] = dtcart;
                            }
                        }
                    }
                    else
                    {
                        float price = Convert.ToSingle(0);
                        float money = price * quantity;
                        DataTable dtcart = new DataTable();
                        dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
                        bool hasincart = false;
                        for (int i = 0; i < dtcart.Rows.Count; i++)
                        {
                            if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
                            {
                                hasincart = true;
                                // cap nhat thong tin cua cart.
                                quantity += Convert.ToInt32(dtcart.Rows[i]["Quantity"]);
                                dtcart.Rows[i]["Quantity"] = quantity;
                                dtcart.Rows[i]["Money"] = quantity * Convert.ToSingle(dtcart.Rows[i]["Price"]);

                                //
                                System.Web.HttpContext.Current.Session["cart"] = dtcart;
                                break;
                            }
                        }
                        if (hasincart == false)
                        {
                            if (dtcart != null)
                            {
                                DataRow dr = dtcart.NewRow();
                                dr["PID"] = pid;
                                dr["Vimg"] = vimg;
                                dr["Name"] = name;
                                dr["Price"] = price;
                                dr["Quantity"] = quantity;
                                dr["Money"] = money;
                                dtcart.Rows.Add(dr);
                                System.Web.HttpContext.Current.Session["cart"] = dtcart;
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Cart_Calculate_Cart
        public static void Cart_Calculate_Cart(List<Entity.CartDetail> dtcart, ref string inumofproducts, ref string totalvnd)
        {
            try
            {
                if (dtcart.Count > 0)
                {
                    double num = 0.0;
                    int num2 = 0;
                    for (int i = 0; i < dtcart.Count; i++)
                    {
                        num += Convert.ToDouble(dtcart[i].Money.ToString());
                        num2 += Convert.ToInt32(dtcart[i].Quantity.ToString());
                    }
                    totalvnd = num.ToString();
                    inumofproducts = num2.ToString();
                }
            }
            catch (Exception)
            { }
        }
        #endregion

        public static string LoadCart()
        {
            if (System.Web.HttpContext.Current.Session["cart"] != null)
            {
                DataTable cartdetail = (DataTable)System.Web.HttpContext.Current.Session["cart"];
                if (cartdetail.Rows.Count > 0)
                {
                    string inumofproducts = "";
                    string totalvnd = "";
                    // S_Product_Carts.Cart_Calculate_Cart(ref cartdetail, ref inumofproducts, ref totalvnd);
                    if (cartdetail.Rows.Count > 0)
                    {
                        double num = 0.0;
                        int num2 = 0;
                        for (int i = 0; i < cartdetail.Rows.Count; i++)
                        {
                            num += Convert.ToDouble(cartdetail.Rows[i]["Money"].ToString());
                            num2 += Convert.ToInt32(cartdetail.Rows[i]["Quantity"].ToString());
                        }
                        totalvnd = num.ToString();
                        inumofproducts = num2.ToString();
                    }
                    return inumofproducts;
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                return "0";
            }
        }
    }
}



