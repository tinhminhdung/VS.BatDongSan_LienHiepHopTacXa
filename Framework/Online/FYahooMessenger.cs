using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.SqlClient;
using System.Data;

namespace Framework
{
    public class FYahooMessenger
    {
        #region GET BY ID
        public List<YahooMessenger> GETBYID(string Id)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_YahooMessenger_ID", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@inick", Id));
            try
            {
                return Database.Bind_List_Reader<YahooMessenger>(comm);
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
        public List<YahooMessenger> GETBYALL(string Lang)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_YahooMessenger_All", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            try
            {
                return Database.Bind_List_Reader<YahooMessenger>(comm);
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
        public bool INSERT(YahooMessenger obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_YahooMessenger_Insert", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@Type", obj.Type));
            comm.Parameters.Add(new SqlParameter("@Title", obj.Title));
            comm.Parameters.Add(new SqlParameter("@Nick", obj.Nick));
            comm.Parameters.Add(new SqlParameter("@Skype", obj.Skype));
            comm.Parameters.Add(new SqlParameter("@Phone", obj.Phone));
            comm.Parameters.Add(new SqlParameter("@Email", obj.Email));
            comm.Parameters.Add(new SqlParameter("@Size", obj.Size));
            comm.Parameters.Add(new SqlParameter("@Orders", obj.Orders));
            comm.Parameters.Add(new SqlParameter("@lang", obj.lang));
            comm.Parameters.Add(new SqlParameter("@Status", obj.Status));
            try
            {
                comm.ExecuteNonQuery();
                tran.Commit();
                return true;
            }
            catch
            {
                tran.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region UPDATE
        public bool UPDATE(YahooMessenger obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_YahooMessenger_Update", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@inick", obj.inick));
            comm.Parameters.Add(new SqlParameter("@Type", obj.Type));
            comm.Parameters.Add(new SqlParameter("@Title", obj.Title));
            comm.Parameters.Add(new SqlParameter("@Nick", obj.Nick));
            comm.Parameters.Add(new SqlParameter("@Skype", obj.Skype));
            comm.Parameters.Add(new SqlParameter("@Phone", obj.Phone));
            comm.Parameters.Add(new SqlParameter("@Email", obj.Email));
            comm.Parameters.Add(new SqlParameter("@Size", obj.Size));
            comm.Parameters.Add(new SqlParameter("@Orders", obj.Orders));
            comm.Parameters.Add(new SqlParameter("@lang", obj.lang));
            comm.Parameters.Add(new SqlParameter("@Status", obj.Status));

            try
            {
                comm.ExecuteNonQuery();
                tran.Commit();
                return true;
            }
            catch
            {
                tran.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region CATE UPDATE
        public bool CATEUPDATE(string inick, string Status)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_YahooMessenger_Cate_Update", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@inick", inick));
            comm.Parameters.Add(new SqlParameter("@Status", Status));
            try
            {
                comm.ExecuteNonQuery();
                tran.Commit();
                return true;
            }
            catch
            {
                tran.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region DELETE
        public void DELETE(string inick)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_YahooMessenger_Delete", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@inick", inick));
            try
            {
                comm.ExecuteNonQuery();
                tran.Commit();
            }
            catch
            {
                tran.Rollback();
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region Name StoredProcedure
        public List<YahooMessenger> Name_StoredProcedure(string Name_StoredProcedure)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_StoredProcedure, conn);
            comm.CommandType = CommandType.StoredProcedure;
            try
            {
                return Database.Bind_List_Reader<YahooMessenger>(comm);
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
        public List<YahooMessenger> Name_Text(string Name_Text)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_Text, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<YahooMessenger>(comm);
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
