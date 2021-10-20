using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.SqlClient;
using System.Data;

namespace Framework
{
    public class FNews_Related
    {
        #region GET BY ALL
        public List<News_Related> GetByAll()
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_News_Related_GetByAll", conn);
            comm.CommandType = CommandType.StoredProcedure;
           
            try
            {
                return Database.Bind_List_Reader<News_Related>(comm);
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
        public bool Insert(News_Related obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_News_Related_Insert", conn);
            comm.CommandType = CommandType.StoredProcedure;
           
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@inid", obj.inid));
            comm.Parameters.Add(new SqlParameter("@irelated", obj.irelated));
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
        public bool UPDATE(News_Related obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_News_Related_Update", conn);
            comm.CommandType = CommandType.StoredProcedure;
           
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@ID", obj.ID));
            comm.Parameters.Add(new SqlParameter("@inid", obj.inid));
            comm.Parameters.Add(new SqlParameter("@irelated", obj.irelated));
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
        public void DELETE(string inid)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_News_Related_Delete", conn);
            comm.CommandType = CommandType.Text;
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@inid", inid));

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

        #region DETAIL INID
        public List<News_Related> DETAIL_INID(string inid)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from News_Related where inid=@inid", conn);
            comm.CommandType = CommandType.Text;
           
            comm.Parameters.Add(new SqlParameter("@inid", inid));
            try
            {
                return Database.Bind_List_Reader<News_Related>(comm);
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

        #region DELETE RELATED
        public void DELETE_RELATED(string irelated)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("delete from News_Related where irelated= @irelated", conn);
            comm.CommandType = CommandType.Text;
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@irelated", irelated));
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

    }
}
