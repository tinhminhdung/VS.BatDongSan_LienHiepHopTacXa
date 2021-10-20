using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.SqlClient;
using System.Data;

namespace Framework
{
    public class FDichvu
    {
        #region GET BY ID
        public List<Dichvu> GETBYID(string Id)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Dichvu_GetById", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@ID", Id));
            try
            {
                return Database.Bind_List_Reader<Dichvu>(comm);
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
        public List<Dichvu> GETBYTOP(string Top, string Where, string Order)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("sp_Dichvu_GetByTop", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@Top", Top));
            comm.Parameters.Add(new SqlParameter("@Where", Where));
            comm.Parameters.Add(new SqlParameter("@Order", Order));
            try
            {
                return Database.Bind_List_Reader<Dichvu>(comm);
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
        public List<Dichvu> GETBYALL(string Lang)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Dichvu_GetByAll", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            try
            {
                return Database.Bind_List_Reader<Dichvu>(comm);
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
        public List<Dichvu> PAGING(string CurentPage, string PageSize, string Lang)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("sp_Dichvu_Paging", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@CurentPage", CurentPage));
            comm.Parameters.Add(new SqlParameter("@PageSize", PageSize));
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            try
            {
                return Database.Bind_List_Reader<Dichvu>(comm);
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
        public bool Insert(Dichvu obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Dichvu_Insert", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@Title", obj.Title));
            comm.Parameters.Add(new SqlParameter("@Brief", obj.Brief));
            comm.Parameters.Add(new SqlParameter("@Contents", obj.Contents));
            comm.Parameters.Add(new SqlParameter("@Keywords", obj.Keywords));
            comm.Parameters.Add(new SqlParameter("@search", obj.search));
            comm.Parameters.Add(new SqlParameter("@Images", obj.Images));
            comm.Parameters.Add(new SqlParameter("@Equals", obj.Equals));
            comm.Parameters.Add(new SqlParameter("@Chekdata", obj.Chekdata));
            comm.Parameters.Add(new SqlParameter("@Create_Date", obj.Create_Date));
            comm.Parameters.Add(new SqlParameter("@Modified_Date", obj.Modified_Date));
            comm.Parameters.Add(new SqlParameter("@Views", obj.Views));
            comm.Parameters.Add(new SqlParameter("@lang", obj.lang));
            comm.Parameters.Add(new SqlParameter("@Status", obj.Status));
            comm.Parameters.Add(new SqlParameter("@Titleseo", obj.Titleseo));
            comm.Parameters.Add(new SqlParameter("@Meta", obj.Meta));
            comm.Parameters.Add(new SqlParameter("@Keyword", obj.Keyword));
            comm.Parameters.Add(new SqlParameter("@TangName", obj.TangName));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Dichvu");
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
        public bool Update(Dichvu obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Dichvu_Update", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@ID", obj.ID));
            comm.Parameters.Add(new SqlParameter("@Title", obj.Title));
            comm.Parameters.Add(new SqlParameter("@Brief", obj.Brief));
            comm.Parameters.Add(new SqlParameter("@Contents", obj.Contents));
            comm.Parameters.Add(new SqlParameter("@Keywords", obj.Keywords));
            comm.Parameters.Add(new SqlParameter("@search", obj.search));
            comm.Parameters.Add(new SqlParameter("@Images", obj.Images));
            comm.Parameters.Add(new SqlParameter("@Equals", obj.Equals));
            comm.Parameters.Add(new SqlParameter("@Chekdata", obj.Chekdata));
            //comm.Parameters.Add(new SqlParameter("@Create_Date", obj.Create_Date));
            //comm.Parameters.Add(new SqlParameter("@Modified_Date", obj.Modified_Date));
            comm.Parameters.Add(new SqlParameter("@lang", obj.lang));
            comm.Parameters.Add(new SqlParameter("@Status", obj.Status));
            comm.Parameters.Add(new SqlParameter("@Titleseo", obj.Titleseo));
            comm.Parameters.Add(new SqlParameter("@Meta", obj.Meta));
            comm.Parameters.Add(new SqlParameter("@Keyword", obj.Keyword));
            comm.Parameters.Add(new SqlParameter("@TangName", obj.TangName));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Dichvu");
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
        public void DELETE(string ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Dichvu_Delete", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Dichvu");
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
        public List<Dichvu> CATEGORY_ADMIN(string orderby, string searchkeyword, string[] searchfields, string lang, string Status)
        {
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
            string sql = @"select * from Dichvu where lang=@lang ";
            if (!Status.Equals("-1"))
            {
                sql += " and Status=@Status";
            }
            if ((searchkeyword.Length > 0) && (searchfields.Length > 0))
            {
                sql = sql + " and ";
                string strsearch = "(";
                for (i = 0; i < searchfields.Length; i++)
                {
                    if (i < (searchfields.Length - 1))
                    {
                        strsearch = strsearch + searchfields[i] + " like N'%" + searchkeyword + "%' or ";
                    }
                    else
                    {
                        strsearch = strsearch + searchfields[i] + " like N'%" + searchkeyword + "%'";
                    }
                }
                strsearch = strsearch + ")";
                sql = sql + strsearch;
            }
            sql += " " + shortbydate + "";
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;
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
                return Database.Bind_List_Reader<Dichvu>(comm);
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

        #region GET CATEGORY BY ID
        public List<Dichvu> GET_CATEGORY_BYID(string id)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from Dichvu where ID = @ID", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@ID", id));
            try
            {
                return Database.Bind_List_Reader<Dichvu>(comm);
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
            SqlCommand comm = new SqlCommand("delete from Dichvu where Menu_ID = @Menu_ID  or Menu_ID in (" + imcid + ") ", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@Menu_ID", Menu_ID));
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Dichvu");
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
        public List<Dichvu> GETDETAIL_BYMENUID(string ID_Menu, string imcid)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from Dichvu where Menu_ID = @ID_Menu  or Menu_ID in (" + imcid + ") ", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add(new SqlParameter("@ID_Menu", ID_Menu));
            try
            {
                return Database.Bind_List_Reader<Dichvu>(comm);
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

        #region UPDATE VIEWS
        public bool UPDATEVIEWS(string ID, int iviews)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update Dichvu set iviews = iviews + @iviews where ID = @ID", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            comm.Parameters.Add(new SqlParameter("@iviews", iviews));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Dichvu");
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

        #region UPDATE VIEWS TIME
        public bool UPDATE_VIEWSTIME(string ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update Dichvu set Views=Views + 1 where ID = @ID", conn);
            comm.CommandType = CommandType.Text;

            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Dichvu");
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

        #region UPDATE STATUS
        public bool UPDATE_STATUS(string ID, string status)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("UPDATE [Dichvu] SET [status] = @Status WHERE ID =@ID", conn);
            comm.CommandType = CommandType.Text;

            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@status", status));
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Dichvu");
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

        # region UPDATE TIMES
        public bool UPDATE_DATETIME(string ID, DateTime Create_Date, DateTime Modified_Date)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update Dichvu set Create_Date=@Create_Date,Modified_Date=@Modified_Date where ID= @ID", conn);
            comm.CommandType = CommandType.Text;

            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@Create_Date", Create_Date));
            comm.Parameters.Add(new SqlParameter("@Modified_Date", Modified_Date));
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Dichvu");
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

        # region CHECK DATA
        public bool CHECKDATA(string ID, string Chekdata, DateTime Create_Date, DateTime Modified_Date)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update Dichvu set Chekdata=@Chekdata,Create_Date=@Create_Date,Modified_Date=@Modified_Date where ID= @ID", conn);
            comm.CommandType = CommandType.Text;

            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@Chekdata", Chekdata));
            comm.Parameters.Add(new SqlParameter("@Create_Date", Create_Date));
            comm.Parameters.Add(new SqlParameter("@Modified_Date", Modified_Date));
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Dichvu");
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
        public bool UPDATEIMG(string id)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update Dichvu set Images='' where ID = @ID", conn);
            comm.CommandType = CommandType.Text;

            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@ID", id));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Dichvu");
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

        #region CATEGORY
        public List<Dichvu> CATEGORY(string lang)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from Dichvu where  Status= 1 and lang=@lang  order by Create_Date asc", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@lang", lang));
            try
            {
                return Database.Bind_List_Reader<Dichvu>(comm);
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

        #region SEARCH
        public List<Dichvu> Search(string keyword, string lang)
        {
            string sql = @"select * from Dichvu  where (Title like '%'+@keyword1+'%'  or Brief like '%'+@keyword2+'%'  or Contents like '%'+@keyword3+'%'  or search like '%'+@keyword4+'%') and lang=@Lang and Status=1   order by Create_Date desc";
            List<Dichvu> list = new List<Dichvu>();
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@Lang", lang));
            comm.Parameters.Add(new SqlParameter("@keyword1", keyword));
            comm.Parameters.Add(new SqlParameter("@keyword2", keyword));
            comm.Parameters.Add(new SqlParameter("@keyword3", keyword));
            comm.Parameters.Add(new SqlParameter("@keyword4", keyword));
            try
            {
                return Database.Bind_List_Reader<Dichvu>(comm);
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

        #region NEWS OTHER LAST
        public List<Dichvu> NEWS_OTHERLAST(string id, int top, string lang)
        {
            string sql = @"select  top " + top.ToString() + " * from Dichvu where Create_Date < (select Create_Date from Dichvu where id=@id) and lang=@lang   order by Create_Date desc";
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@id", id));
            comm.Parameters.Add(new SqlParameter("@lang", lang));
            try
            {
                return Database.Bind_List_Reader<Dichvu>(comm);
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

        #region NEWS OTHER FIRST
        public List<Dichvu> NEWS_OTHERFIRST(string id, int top, string lang)
        {
            string sql = @"select top " + top.ToString() + "  * from Dichvu where Create_Date > (select Create_Date from Dichvu where id=@id) and lang=@lang   order by Create_Date desc";
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@id", id));
            comm.Parameters.Add(new SqlParameter("@lang", lang));
            try
            {
                return Database.Bind_List_Reader<Dichvu>(comm);
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
        public List<Dichvu> Name_StoredProcedure(string Name_StoredProcedure)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_StoredProcedure, conn);
            comm.CommandType = CommandType.StoredProcedure;
            try
            {
                return Database.Bind_List_Reader<Dichvu>(comm);
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
        public List<Dichvu> Name_Text(string Name_Text)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_Text, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<Dichvu>(comm);
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
