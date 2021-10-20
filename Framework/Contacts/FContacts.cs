using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.SqlClient;
using System.Data;

namespace Framework
{
    public class FContacts
    {
        #region UPDATE STATUS
        public bool UPDATESTATUS(string ino, string istatus)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Contacts_Updatestatus", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@istatus", istatus));
            comm.Parameters.Add(new SqlParameter("@ino", ino));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Contacts");
                return true;
            }
            catch
            {
                objtran.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region GET BY ID
        public List<Contacts> GETBYID(string Id)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Contacts_ID", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@ino", Id));
            try
            {
                return Database.Bind_List_Reader<Contacts>(comm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region GET BY ALL
        public List<Contacts> GETBYALL(string Lang)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Contacts_GetByAll", conn);
            comm.CommandType = CommandType.StoredProcedure;
            
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            try
            {
                return Database.Bind_List_Reader<Contacts>(comm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region INSERT
        public bool Insert(Contacts obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Contacts_Insert", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@vtitle", obj.vtitle));
            comm.Parameters.Add(new SqlParameter("@vname", obj.vname));
            comm.Parameters.Add(new SqlParameter("@vaddress", obj.vaddress));
            comm.Parameters.Add(new SqlParameter("@vphone", obj.vphone));
            comm.Parameters.Add(new SqlParameter("@vemail", obj.vemail));
            comm.Parameters.Add(new SqlParameter("@vcontent", obj.vcontent));
            comm.Parameters.Add(new SqlParameter("@dcreatedate", obj.dcreatedate));
            comm.Parameters.Add(new SqlParameter("@lang", obj.lang));
            comm.Parameters.Add(new SqlParameter("@istatus", obj.istatus));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Contacts");
                return true;
            }
            catch
            {
                objtran.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region UPDATE
        public bool Update(Contacts obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Contacts_Update", conn);
            comm.CommandType = CommandType.StoredProcedure;
            
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@ino", obj.ino));
            comm.Parameters.Add(new SqlParameter("@vtitle", obj.vtitle));
            comm.Parameters.Add(new SqlParameter("@vname", obj.vname));
            comm.Parameters.Add(new SqlParameter("@vaddress", obj.vaddress));
            comm.Parameters.Add(new SqlParameter("@vphone", obj.vphone));
            comm.Parameters.Add(new SqlParameter("@vemail", obj.vemail));
            comm.Parameters.Add(new SqlParameter("@vcontent", obj.vcontent));
            comm.Parameters.Add(new SqlParameter("@dcreatedate", obj.dcreatedate));
            comm.Parameters.Add(new SqlParameter("@lang", obj.lang));
            comm.Parameters.Add(new SqlParameter("@istatus", obj.istatus));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Contacts");
                return true;
            }
            catch
            {
                objtran.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region DELETE
        public void DELETE(string Id)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Contacts_Delete", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@ino", Id));
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Contacts");
            }
            catch
            {
                objtran.Rollback();
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region CATEGORY ADMIN
        public List<Contacts> CATEGORY_ADMIN(string lang, string istatus)
        {
            string sql = @"select * from Contacts where lang='" + lang + "'";
            if (!istatus.Equals("-1"))
            {
                sql += " and istatus=" + istatus + " ";
            }
            sql += " order by dcreatedate desc ";
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@lang", lang));
            if (!istatus.Equals("-1"))
            {
                comm.Parameters.Add(new SqlParameter("@istatus", istatus));
            }
            try
            {
                return Database.Bind_List_Reader<Contacts>(comm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region Name StoredProcedure
        public List<Contacts> Name_StoredProcedure(string Name_StoredProcedure)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_StoredProcedure, conn);
            comm.CommandType = CommandType.StoredProcedure;
            try
            {
                return Database.Bind_List_Reader<Contacts>(comm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region Name Text
        public List<Contacts> Name_Text(string Name_Text)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_Text, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<Contacts>(comm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion
    }
}
