using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.SqlClient;
using System.Data;

namespace Framework
{
    public class FMarketing
    {
        #region GET BY ID
        public List<Marketing> GETBYID(string IDMarketing)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Marketing_GetById", conn);
            comm.CommandType = CommandType.StoredProcedure;
           
            comm.Parameters.Add(new SqlParameter("@IDMarketing", IDMarketing));
            try
            {
                return Database.Bind_List_Reader<Marketing>(comm);
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
        public List<Marketing> GETBYALL()
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Marketing_GetByAll", conn);
            comm.CommandType = CommandType.StoredProcedure;
           
            try
            {
                return Database.Bind_List_Reader<Marketing>(comm);
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
        public bool INSERT(Marketing obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Marketing_Insert", conn);
            comm.CommandType = CommandType.StoredProcedure;
           
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@Name", obj.Name));
            comm.Parameters.Add(new SqlParameter("@Email", obj.Email));
            comm.Parameters.Add(new SqlParameter("@Phone", obj.Phone));
            comm.Parameters.Add(new SqlParameter("@Address", obj.Address));
            comm.Parameters.Add(new SqlParameter("@dcreatedate", obj.dcreatedate));
            comm.Parameters.Add(new SqlParameter("@istatus", obj.istatus));
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
        public bool UPDATE(Marketing obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Marketing_Update", conn);
            comm.CommandType = CommandType.StoredProcedure;
           
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@IDMarketing", obj.IDMarketing));
            comm.Parameters.Add(new SqlParameter("@Name", obj.Name));
            comm.Parameters.Add(new SqlParameter("@Email", obj.Email));
            comm.Parameters.Add(new SqlParameter("@Phone", obj.Phone));
            comm.Parameters.Add(new SqlParameter("@Address", obj.Address));
            comm.Parameters.Add(new SqlParameter("@dcreatedate", obj.dcreatedate));
            comm.Parameters.Add(new SqlParameter("@istatus", obj.istatus));
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
        public bool CATEUPDATE(string IDMarketing, string istatus)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update Marketing set istatus=@istatus where IDMarketing=@IDMarketing", conn);
            comm.CommandType = CommandType.Text;
           
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@IDMarketing", IDMarketing));
            comm.Parameters.Add(new SqlParameter("@istatus", istatus));
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
        public void DELETE(string IDMarketing)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Marketing_Delete", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@IDMarketing", IDMarketing));
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

        #region SEARCH
        public List<Marketing> SEARCH(string searchkeyword, string[] searchfields)
        {
            int i;
            string sql = @"select * from Marketing where  istatus=1";
            if ((searchkeyword.Length > 0) && (searchfields.Length > 0))
            {
                sql = sql + " and ";
                string strsearch = "(";
                for (i = 0; i < searchfields.Length; i++)
                {
                    if (i < (searchfields.Length - 1))
                    {
                        strsearch = strsearch + searchfields[i] + " like '%" + searchkeyword + "%' or ";
                    }
                    else
                    {
                        strsearch = strsearch + searchfields[i] + " like '%" + searchkeyword + "%'";
                    }
                }
                strsearch = strsearch + ")";
                sql = sql + strsearch;
            }
            sql += " order by dcreatedate desc";

            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;
           
            if ((searchkeyword.Length > 0) && (searchfields.Length > 0))
            {
                for (i = 0; i < searchfields.Length; i++)
                {
                    comm.Parameters.Add(new SqlParameter("@" + searchfields[i], searchkeyword));
                }
            }
            try
            {
                return Database.Bind_List_Reader<Marketing>(comm);
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

        #region CATEGORY ADMIN
        public List<Marketing> CATEGORYADMIN(string istatus)
        {
            string sql = @"select * from Marketing ";
            if (!istatus.Equals("-1"))
            {
                sql += " where istatus=" + istatus + " ";
            }
            sql += " order by dcreatedate desc ";
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;
           

            if (!istatus.Equals("-1"))
            {
                comm.Parameters.Add(new SqlParameter("@istatus", istatus));
            }
            try
            {
                return Database.Bind_List_Reader<Marketing>(comm);
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
        public List<Marketing> Name_Text(string Name_Text)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_Text, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<Marketing>(comm);
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
