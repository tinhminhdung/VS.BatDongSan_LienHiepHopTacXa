using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Entity;


public class DataSql
{
    #region UPDATE DATA ID sql
    public bool UPDATE_DATA_ID_sql(string Data, string ID, string sql)
    {
        SqlConnection conn = Database.Connection();
        SqlCommand comm = new SqlCommand("update " + Data + " set " + sql + " where ID=" + ID + "", conn);
        comm.CommandType = CommandType.Text;
        SqlTransaction objtran = conn.BeginTransaction();
        comm.Transaction = objtran;
        try
        {
            comm.ExecuteNonQuery();
            objtran.Commit();
            System.Web.HttpContext.Current.Cache.Remove(Data);
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

}

