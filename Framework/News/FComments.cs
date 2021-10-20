using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data;
using System.Data.SqlClient;

namespace Framework
{
    public class FComments
    {
        #region GET BY ID
        public List<Comments> GETBYID(string Id)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Comments_GetById", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@ID", Id));
            try
            {
                return Database.Bind_List_Reader<Comments>(comm);
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

        #region GET BY TOP
        public List<Comments> GETBYTOP(string Top, string Where, string Order)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("sp_Comments_GetByTop", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@Top", Top));
            comm.Parameters.Add(new SqlParameter("@Where", Where));
            comm.Parameters.Add(new SqlParameter("@Order", Order));
            try
            {
                return Database.Bind_List_Reader<Comments>(comm);
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
        public List<Comments> GETBYALL()
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Comments_GetByAll", conn);
            comm.CommandType = CommandType.StoredProcedure;
            
            try
            {
                return Database.Bind_List_Reader<Comments>(comm);
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

        #region PAGING
        public List<Comments> PAGING(string CurentPage, string PageSize)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("sp_Comments_Paging", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@CurentPage", CurentPage));
            comm.Parameters.Add(new SqlParameter("@PageSize", PageSize));
            try
            {
                return Database.Bind_List_Reader<Comments>(comm);
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
        public bool INSERT(Comments obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Comments_Insert", conn);
            comm.CommandType = CommandType.StoredProcedure;
            
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@ID_Parent", obj.ID_Parent));
            comm.Parameters.Add(new SqlParameter("@Name", obj.Name));
            comm.Parameters.Add(new SqlParameter("@Add", obj.Add));
            comm.Parameters.Add(new SqlParameter("@Email", obj.Email));
            comm.Parameters.Add(new SqlParameter("@Title", obj.Title));
            comm.Parameters.Add(new SqlParameter("@Contens", obj.Contens));
            comm.Parameters.Add(new SqlParameter("@Create_Date", obj.Create_Date));
            comm.Parameters.Add(new SqlParameter("@Status", obj.Status));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Comments");
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
        public bool UPDATE(Comments obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Comments_Update", conn);
            comm.CommandType = CommandType.StoredProcedure;
            
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@ID", obj.ID));
            comm.Parameters.Add(new SqlParameter("@ID_Parent", obj.ID_Parent));
            comm.Parameters.Add(new SqlParameter("@Name", obj.Name));
            comm.Parameters.Add(new SqlParameter("@Add", obj.Add));
            comm.Parameters.Add(new SqlParameter("@Email", obj.Email));
            comm.Parameters.Add(new SqlParameter("@Title", obj.Title));
            comm.Parameters.Add(new SqlParameter("@Contens", obj.Contens));
            comm.Parameters.Add(new SqlParameter("@Create_Date", obj.Create_Date));
            comm.Parameters.Add(new SqlParameter("@Status", obj.Status));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Comments");
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
            SqlCommand comm = new SqlCommand("S_Comments_Delete", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@ID", Id));
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Comments");
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
        #region DELETE
        public void DELETE_Parent_ID(string ID_Parent)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("DELETE FROM [Comments] WHERE ID_Parent = @ID_Parent", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@ID_Parent", ID_Parent));
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Comments");
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

        #region Detail_ID_Parent_Status_orderasc_desc
        public List<Comments> Detail_ID_Parent_Status_orderasc_desc(string ID_Parent, string Status, bool orderasc_desc)
        {
            string str = " order by Create_Date asc";
            if (!orderasc_desc)
            {
                str = " order by Create_Date desc";
            }
            string str2 = "select * from Comments where ID_Parent= @ID_Parent ";
            if (!Status.Equals("-1"))
            {
                str2 = str2 + " and Status= @Status";
            }
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(str2 + str, conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@ID_Parent", ID_Parent));
            comm.Parameters.Add(new SqlParameter("@Status", Status));
            try
            {
                return Database.Bind_List_Reader<Comments>(comm);
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

        #region GET DETAIL BY ID
        public List<Comments> GETDETAIL_BYID(string ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from Comments where ID= @ID", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                return Database.Bind_List_Reader<Comments>(comm);
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

        #region UPDATE STATUS
        public bool UPDATESTATUS(string ID, string conditon)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update Comments set " + conditon + " where ID = @ID", conn);
            comm.CommandType = CommandType.Text;
            
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Comments");
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

        #region NEWS TOTAL
        public List<Comments> NEWS_TOTAL(string ID_Parent, string Status)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from Comments where ID_Parent= @ID_Parent and Status= @Status", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@ID_Parent", ID_Parent));
            comm.Parameters.Add(new SqlParameter("@Status", Status));
            try
            {
                return Database.Bind_List_Reader<Comments>(comm);
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

        #region DETAIL TOP
        public List<Comments> DETAIL_TOP(int top, string ID_Parent, string Status, string orderby)
        {
            string order = " order by Create_Date asc";
            if (!orderby.Equals(""))
            {
                order = " order by " + orderby;
            }
            string strtop = "";
            if (top > -1)
            {
                strtop = " top " + top.ToString() + " ";
            }
            else
            {
                strtop = " top 0 ";
            }
            string sql = "select " + strtop + " * from Comments where ID_Parent=@ID_Parent ";
            if (!Status.Equals("-1"))
            {
                sql = sql + " and Status=@Status ";
            }
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@ID_Parent", ID_Parent));
            if (!Status.Equals("-1"))
            {
                comm.Parameters.AddWithValue("@Status", Status);
            }
            try
            {
                return Database.Bind_List_Reader<Comments>(comm);
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

        #region Detail_Count
        public int Detail_Count(string ID_Parent, string Status, string condition)
        {
            string sql = "select count(*) from Comments where ID_Parent=? ";
            if (!Status.Equals("-1"))
            {
                sql = sql + " and Status=? ";
            }
            if (!condition.Equals(""))
            {
                sql = sql + " and " + condition + " ";
            }
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@ID_Parent", ID_Parent));
            if (!Status.Equals("-1"))
            {
                comm.Parameters.AddWithValue("@Status", Status);
            }
            return Convert.ToInt32(Database.GetData(comm).Rows[0][0]);
        }
        #endregion

        #region Name StoredProcedure
        public List<Comments> Name_StoredProcedure(string Name_StoredProcedure)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_StoredProcedure, conn);
            comm.CommandType = CommandType.StoredProcedure;
            try
            {
                return Database.Bind_List_Reader<Comments>(comm);
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
        public List<Comments> Name_Text(string Name_Text)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_Text, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<Comments>(comm);
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
