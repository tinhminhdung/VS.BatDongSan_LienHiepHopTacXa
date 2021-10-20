using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.SqlClient;
using System.Data;

namespace Framework
{
    public class FAlbum_Images
    {
        #region GET BY ID
        public List<Album_Images> GETBYID(string Id)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Album_Images_GetById", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@ID", Id));
            try
            {
                return Database.Bind_List_Reader<Album_Images>(comm);
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
        public List<Album_Images> GETBYTOP(string Top, string Where, string Order)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("sp_Album_Images_GetByTop", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@Top", Top));
            comm.Parameters.Add(new SqlParameter("@Where", Where));
            comm.Parameters.Add(new SqlParameter("@Order", Order));
            try
            {
                return Database.Bind_List_Reader<Album_Images>(comm);
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
        public List<Album_Images> GETBYALL()
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Album_Images_GetByAll", conn);
            comm.CommandType = CommandType.StoredProcedure;
            
            try
            {
                return Database.Bind_List_Reader<Album_Images>(comm);
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
        public List<Album_Images> PAGING(string CurentPage, string PageSize)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("sp_Album_Images_Paging", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@CurentPage", CurentPage));
            comm.Parameters.Add(new SqlParameter("@PageSize", PageSize));
            try
            {
                return Database.Bind_List_Reader<Album_Images>(comm);
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
        public bool INSERT(Album_Images obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Album_Images_Insert", conn);
            comm.CommandType = CommandType.StoredProcedure;
            
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@Menu_ALB", obj.Menu_ALB));
            comm.Parameters.Add(new SqlParameter("@Menu_ID", obj.Menu_ID));
            comm.Parameters.Add(new SqlParameter("@Title", obj.Title));
            comm.Parameters.Add(new SqlParameter("@Brief", obj.Brief));
            comm.Parameters.Add(new SqlParameter("@Images", obj.Images));
            comm.Parameters.Add(new SqlParameter("@ImagesSmall", obj.ImagesSmall));
            comm.Parameters.Add(new SqlParameter("@Equals", obj.Equals));
            comm.Parameters.Add(new SqlParameter("@Orders", obj.Orders));
            comm.Parameters.Add(new SqlParameter("@Status", obj.Status));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Album_Images");
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
        public bool UPDATE(Album_Images obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Album_Images_Update", conn);
            comm.CommandType = CommandType.StoredProcedure;
            
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@ID", obj.ID));
            comm.Parameters.Add(new SqlParameter("@Menu_ALB", obj.Menu_ALB));
            comm.Parameters.Add(new SqlParameter("@Menu_ID", obj.Menu_ID));
            comm.Parameters.Add(new SqlParameter("@Title", obj.Title));
            comm.Parameters.Add(new SqlParameter("@Brief", obj.Brief));
            comm.Parameters.Add(new SqlParameter("@Images", obj.Images));
            comm.Parameters.Add(new SqlParameter("@ImagesSmall", obj.ImagesSmall));
            comm.Parameters.Add(new SqlParameter("@Equals", obj.Equals));
            comm.Parameters.Add(new SqlParameter("@Orders", obj.Orders));
            comm.Parameters.Add(new SqlParameter("@Status", obj.Status));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Album_Images");
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
            SqlCommand comm = new SqlCommand("S_Album_Images_Delete", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@ID", Id));
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Album_Images");
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
        public List<Album_Images> CATEGORY_ADMIN(string orderby, string searchkeyword, string[] searchfields, string Menu_ID, string imcid, string lang, string Status)
        {
            SqlConnection conn = Database.Connection();
            int i;
            string shortbydate = "";
            if (orderby.Length < 1)
            {
                shortbydate = "order by Create_Date desc";
            }
            else
            {
                shortbydate = "order by " + orderby;
            }
            string sql = @"select * from Album_Images where Menu_ID in (" + imcid + ") and lang='" + lang + "'";// 
            if (!Status.Equals("-1"))
            {
                sql += " and Status=" + Status + " ";
            }
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
            sql += " " + shortbydate + "";
            SqlCommand comm = new SqlCommand("S_AdminUser_DetailName", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@Menu_ID", Menu_ID));
            comm.Parameters.Add(new SqlParameter("@lang", lang));
            if (!Status.Equals("-1"))
            {
                comm.Parameters.Add(new SqlParameter("@Status", Status));
            }
            if ((searchkeyword.Length > 0) && (searchfields.Length > 0))
            {
                for (i = 0; i < searchfields.Length; i++)
                {
                    comm.Parameters.Add(new SqlParameter("@" + searchfields[i], searchkeyword));
                }
            }
            try
            {
                return Database.Bind_List_Reader<Album_Images>(comm);
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
        public List<Album_Images> GETDETAILBYID(string id)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from Album_Images where ID = @ID", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@ID", id));
            try
            {
                return Database.Bind_List_Reader<Album_Images>(comm);
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

        #region CATE DELETE MENU ID
        public void CATE_DELETE_MENUID(string Menu_ID, string imcid)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("delete from Album_Images where Menu_ID = @Menu_ID  or Menu_ID in (" + imcid + ") ", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@Menu_ID", Menu_ID));
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Album_Images");
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

        #region CATE DELETE MENU ALB
        public void CATE_DELETE_MENUALB(string Menu_ALB)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("delete from Album_Images where Menu_ALB = @Menu_ALB ", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@Menu_ALB", Menu_ALB));
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Album_Images");
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

        #region GET DETAIL BY MENU ID
        public List<Album_Images> GET_DETAIL_MENUID(string ID_Menu, string imcid)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from Album_Images where Menu_ID = @ID_Menu  or Menu_ID in (" + imcid + ") ", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@ID_Menu", ID_Menu));
            try
            {
                return Database.Bind_List_Reader<Album_Images>(comm);
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

        #region GET DETAIL BY MENU ALB
        public List<Album_Images> GETDETAILBY_MENUALB(string Menu_ALB)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from Album_Images where Menu_ALB = @Menu_ALB", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@Menu_ALB", Menu_ALB));
            try
            {
                return Database.Bind_List_Reader<Album_Images>(comm);
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
        public bool UPDATESTATUS(string id, string status)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Album_Images_UpdateStatus", conn);
            comm.CommandType = CommandType.StoredProcedure;
            
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@status", status));
            comm.Parameters.Add(new SqlParameter("@ID", id));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Album_Images");
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

        #region UPDATE_DATETIME
        public bool UPDATE_DATETIME(string id, bool updatecreatedate, string Modified_Date)
        {
            string createdate = "";
            if (updatecreatedate == false)
            {
                createdate = "Create_Date = getdate(),";
            }
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update Album_Images set " + createdate + "Modified_Date = @Modified_Date where ID = @ID", conn);
            comm.CommandType = CommandType.Text;
            
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@Modified_Date", Modified_Date));
            comm.Parameters.Add(new SqlParameter("@ID", id));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Album_Images");
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

        #region UPDATE IMG
        public bool Album_UPDATE_IMG(string id, string Images, string ImagesSmall)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update Album_Images set Images = @Images,ImagesSmall = @ImagesSmall where ID = @ID", conn);
            comm.CommandType = CommandType.Text;
            
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@ID", id));
            comm.Parameters.Add(new SqlParameter("@Images", Images));
            comm.Parameters.Add(new SqlParameter("@ImagesSmall", ImagesSmall));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Album_Images");
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

        #region Name StoredProcedure
        public List<Album_Images> Name_StoredProcedure(string Name_StoredProcedure)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_StoredProcedure, conn);
            comm.CommandType = CommandType.StoredProcedure;
            try
            {
                return Database.Bind_List_Reader<Album_Images>(comm);
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
        public List<Album_Images> Name_Text(string Name_Text)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_Text, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<Album_Images>(comm);
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
