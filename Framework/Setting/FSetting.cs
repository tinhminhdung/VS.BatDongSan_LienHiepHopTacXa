using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.SqlClient;
using System.Data;

namespace Framework
{
    public class FSetting
    {
        #region GET BY ID
        public List<Entity.Setting> GETBYID(string Id)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Setting_ID", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@ID", Id));
            try
            {
                return Database.Bind_List_Reader<Setting>(comm);
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
        public List<Entity.Setting> GETBYALL(string Lang)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Setting_All", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            try
            {
                return Database.Bind_List_Reader<Setting>(comm);
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
        public bool INSERT(Setting Obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Setting_Insert", conn);
            comm.CommandType = CommandType.StoredProcedure;
            
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@Properties", Obj.Properties));
            comm.Parameters.Add(new SqlParameter("@Value", Obj.Value));
            comm.Parameters.Add(new SqlParameter("@Lang", Obj.Lang));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Setting");
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
        public bool UPDATE(Setting Obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S-Setting_New_Update", conn);
            comm.CommandType = CommandType.StoredProcedure;
            
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@Properties", Obj.Properties));
            comm.Parameters.Add(new SqlParameter("@Value", Obj.Value));
            comm.Parameters.Add(new SqlParameter("@Lang", Obj.Lang));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Setting");
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
            SqlCommand comm = new SqlCommand("S_Setting_Delete", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@ID", Id));
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Setting");
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

        public List<Entity.Setting> Text(string Text)
        {
            List<Entity.Setting> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand(Text, connection)
            {
                CommandType = CommandType.Text
            };
            try
            {
                list = Database.Bind_List_Reader<Setting>(command);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                connection.Close();
            }
            return list;
        }

    }
}
