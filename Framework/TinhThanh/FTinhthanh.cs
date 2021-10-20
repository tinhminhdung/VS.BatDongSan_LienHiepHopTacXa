using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.SqlClient;
using System.Data;

namespace Framework
{
    public class FTinhthanh
    {
        public DataTable DataTable_capp_Lang_MoreIn_ID_Status(string capp, string Lang, string Parent_ID, string Status)
        {
            DataTable dts = new DataTable();
            SqlDataAdapter VSda;
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("SELECT * FROM [Tinhthanh]  where capp=@capp and Lang=@Lang  and Parent_ID=@Parent_ID and Status=@Status order by ID asc,Orders desc", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@capp", capp));
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            comm.Parameters.Add(new SqlParameter("@Parent_ID", Parent_ID));
            comm.Parameters.Add(new SqlParameter("@Status", Status));
            try
            {
                VSda = new SqlDataAdapter(comm);
                VSda.Fill(dts);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return dts;
        }

        #region UPDATE UpdateTinhthanh
        public bool UpdateTinhthanh(string id, string Giatri, string Giatritruyen)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("UPDATE [Tinhthanh] SET [" + Giatri + "] =" + Giatritruyen + " WHERE id= @id", conn);
            comm.CommandType = CommandType.Text;
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@id", id));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Tinhthanh");
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

        #region capp_Lang_MoreIn_ID_Status
        public List<Tinhthanh> capp_Lang_MoreIn_ID_Status(string capp, string Lang, string ID, string Status)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("SELECT * FROM [Tinhthanh]  where capp=@capp and lang=@Lang and id in(" + ID + ") and Status=@Status  order by ID asc,Orders desc", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@capp", capp));
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            comm.Parameters.Add(new SqlParameter("@Status", Status));
            try
            {
                return Database.Bind_List_Reader<Tinhthanh>(comm);
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

        #region CATE LOAD ALL Tinhthanh
        public List<Tinhthanh> LOAD_ALL_Tinhthanh(string capp, string Lang, string Parent_ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Tinhthanh_Cate_LoadAllnews", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@capp", capp));
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            comm.Parameters.Add(new SqlParameter("@Parent_ID", Parent_ID));
            try
            {
                return Database.Bind_List_Reader<Tinhthanh>(comm);
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

        #region CATE CAPP LANG
        public List<Tinhthanh> CATE_CAPP_LANG(string capp, string Lang, string Status)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Tinhthanh_Cate_capp_Lang", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@capp", capp));
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            comm.Parameters.Add(new SqlParameter("@Status", Status));
            try
            {
                return Database.Bind_List_Reader<Tinhthanh>(comm);
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

        #region LOAD CATES PARENT ID
        public List<Tinhthanh> LOAD_CATES_PARENTID(string capp, string Lang, string Parent_ID, string Status)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Tinhthanh_Load_Cates_Parent_ID", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@capp", capp));
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            comm.Parameters.Add(new SqlParameter("@Parent_ID", Parent_ID));
            comm.Parameters.Add(new SqlParameter("@Status", Status));
            try
            {
                return Database.Bind_List_Reader<Tinhthanh>(comm);
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

        #region GET BY ID
        public List<Tinhthanh> capp_Lang_ID_Status(string capp, string Lang, string ID, string Status)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Tinhthanh_Load_Cates_ID", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@capp", capp));
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            comm.Parameters.Add(new SqlParameter("@Status", Status));
            try
            {
                return Database.Bind_List_Reader<Tinhthanh>(comm);
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

        #region DETAIL CAPP
        public List<Tinhthanh> DETAIL_CAPP(string ID, string capp)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Tinhthanh_Load_ID", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            comm.Parameters.Add(new SqlParameter("@capp", capp));
            try
            {
                return Database.Bind_List_Reader<Tinhthanh>(comm);
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

        #region DETAIL CAPP PARENT ID
        public List<Tinhthanh> DETAIL_CAPP_PARENTID(string Parent_ID, string capp)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("SELECT * FROM [Tinhthanh]  where   Parent_ID=@Parent_ID and  capp=@capp    order by Orders asc", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@Parent_ID", Parent_ID));
            comm.Parameters.Add(new SqlParameter("@capp", capp));
            try
            {
                return Database.Bind_List_Reader<Tinhthanh>(comm);
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

        #region capp_Lang_Parent_ID_Status ID Hone
        public List<Tinhthanh> capp_Lang_Parent_ID_Home_Status(string capp, string Lang, string Parent_ID, string page_Home, string Status)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("SELECT * FROM [Tinhthanh]  where capp=@capp and Lang=@Lang  and Parent_ID=@Parent_ID and page_Home=@page_Home and Status=@Status order by Orders asc", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@capp", capp));
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            comm.Parameters.Add(new SqlParameter("@Parent_ID", Parent_ID));
            comm.Parameters.Add(new SqlParameter("@page_Home", page_Home));
            comm.Parameters.Add(new SqlParameter("@Status", Status));
            try
            {
                return Database.Bind_List_Reader<Tinhthanh>(comm);
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

        #region LOAD CID
        public List<Tinhthanh> LOADCID(string Parent_ID, string capp)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Tinhthanh_Loadcid", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@Parent_ID", Parent_ID));
            comm.Parameters.Add(new SqlParameter("@capp", capp));
            try
            {
                return Database.Bind_List_Reader<Tinhthanh>(comm);
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

        #region LOAD CAPP
        public List<Tinhthanh> LOADCAPP(string Capp)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Tinhthanh_Load_Capp", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@Capp", Capp));
            try
            {
                return Database.Bind_List_Reader<Tinhthanh>(comm);
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

        #region Parent_ID AND ID
        public List<Tinhthanh> ID_Parent_ID(string ID,string _parent_ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * FROM [Tinhthanh] WHERE ID=@ID and Parent_ID in (" + _parent_ID + ") and Status=1", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            comm.Parameters.Add(new SqlParameter("@Parent_ID", _parent_ID));
            try
            {
                return Database.Bind_List_Reader<Tinhthanh>(comm);
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

        #region Parent_ID
        public List<Tinhthanh> Parent_ID(string _parent_ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * FROM [Tinhthanh] WHERE  Parent_ID in (" + _parent_ID + ") and capp='PR' and Status=1", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@Parent_ID", _parent_ID));
            try
            {
                return Database.Bind_List_Reader<Tinhthanh>(comm);
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

        #region GET PARENT ID
        public List<Tinhthanh> GETPARENT_ID(string ID, string Parent_ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Tinhthanh_Get_Parent_ID", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            comm.Parameters.Add(new SqlParameter("@Parent_ID", Parent_ID));
            try
            {
                return Database.Bind_List_Reader<Tinhthanh>(comm);
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

        #region DETAIL NEWS
        public List<Tinhthanh> DETAIL_NEWS(string capp, string Lang, string News)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Tinhthanh_Detail_News", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@capp", capp));
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            comm.Parameters.Add(new SqlParameter("@News", News));
            try
            {
                return Database.Bind_List_Reader<Tinhthanh>(comm);
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

        #region LOAD CATES
        public List<Tinhthanh> LOADCATES(string Lang, string capp, string Parent_ID, string Status)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Tinhthanh_LoadCates", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            comm.Parameters.Add(new SqlParameter("@capp", capp));
            comm.Parameters.Add(new SqlParameter("@Parent_ID", Parent_ID));
            comm.Parameters.Add(new SqlParameter("@Status", Status));
            try
            {
                return Database.Bind_List_Reader<Tinhthanh>(comm);
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

        #region CATE LOAD ALL
        public List<Tinhthanh> CATE_LOADALL(string Lang, string capp, string Parent_ID, string Status)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Tinhthanh_Cate_LoadAll", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            comm.Parameters.Add(new SqlParameter("@capp", capp));
            comm.Parameters.Add(new SqlParameter("@Parent_ID", Parent_ID));
            try
            {
                return Database.Bind_List_Reader<Tinhthanh>(comm);
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

        #region CATE UPDATE
        public bool CATE_UPDATE(string ID, string sql)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Tinhthanh_Update", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            comm.Parameters.Add(new SqlParameter("@sql", sql));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Tinhthanh");
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
        public bool UPDATESTATUS(string id, string status)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Tinhthanh_Updatestatus", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@status", status));
            comm.Parameters.Add(new SqlParameter("@id", id));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Tinhthanh");
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

        #region UPDATE Home
        public bool UPDATESHOME(string id, string page_Home)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("	UPDATE [Tinhthanh] SET [page_Home] = @page_Home WHERE id= @id", conn);
            comm.CommandType = CommandType.Text;
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@page_Home", page_Home));
            comm.Parameters.Add(new SqlParameter("@id", id));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Tinhthanh");
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

        #region UPDATE ORDER
        public bool UPDATE_ORDER(string Orders, string ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Tinhthanh_Update_Order", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@Orders", Orders));
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Tinhthanh");
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

        #region UPDATE VIEWS Tang
        public bool UPDATEVIEWS_T(string ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("UPDATE [Tinhthanh] SET Orders=Orders + 1 WHERE ID = @ID", conn);
            comm.CommandType = CommandType.Text;
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Tinhthanh");
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

        #region UPDATE VIEWS Giam
        public bool UPDATEVIEWS_G(string ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("UPDATE [Tinhthanh] SET Orders=Orders - 1 WHERE ID = @ID", conn);
            comm.CommandType = CommandType.Text;
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Tinhthanh");
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
        public bool UPDATEIMG(string ID, string Images)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Tinhthanh_UpdateImg", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@Images", Images));
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Tinhthanh");
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
        public List<Tinhthanh> GETBYID(string ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("SELECT * FROM [Tinhthanh] WHERE ID = @ID", conn);
            comm.CommandType = CommandType.Text;

            comm.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                return Database.Bind_List_Reader<Tinhthanh>(comm);
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

        #region Detail
        public List<Tinhthanh> Detail(string ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("SELECT * FROM [Tinhthanh] WHERE ID = @ID", conn);
            comm.CommandType = CommandType.Text;

            comm.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                return Database.Bind_List_Reader<Tinhthanh>(comm);
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
        public List<Tinhthanh> GETBYTOP(string Top, string Where, string Order)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("sp_Tinhthanh_GetByTop", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add(new SqlParameter("@Top", Top));
            comm.Parameters.Add(new SqlParameter("@Where", Where));
            comm.Parameters.Add(new SqlParameter("@Order", Order));
            try
            {
                return Database.Bind_List_Reader<Tinhthanh>(comm);
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
        public List<Tinhthanh> GETBYALL(string Lang)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Tinhthanh_GetByAll", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            try
            {
                return Database.Bind_List_Reader<Tinhthanh>(comm);
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
        public List<Tinhthanh> PAGING(string CurentPage, string PageSize, string Lang)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("sp_Tinhthanh_Paging", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add(new SqlParameter("@CurentPage", CurentPage));
            comm.Parameters.Add(new SqlParameter("@PageSize", PageSize));
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            try
            {
                return Database.Bind_List_Reader<Tinhthanh>(comm);
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
        public bool INSERT(Tinhthanh data)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Tinhthanh_Insert", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@Parent_ID", data.Parent_ID));
            comm.Parameters.Add(new SqlParameter("@capp", data.capp));
            comm.Parameters.Add(new SqlParameter("@Type", data.Type));
            comm.Parameters.Add(new SqlParameter("@Lang", data.Lang));
            comm.Parameters.Add(new SqlParameter("@Name", data.Name));
            comm.Parameters.Add(new SqlParameter("@Url_Name", data.Url_Name));
            comm.Parameters.Add(new SqlParameter("@Link", data.Link));
            comm.Parameters.Add(new SqlParameter("@Styleshow", data.Styleshow));
            comm.Parameters.Add(new SqlParameter("@Equals", data.Equals));
            comm.Parameters.Add(new SqlParameter("@Images", data.Images));
            comm.Parameters.Add(new SqlParameter("@Description", data.Description));
            comm.Parameters.Add(new SqlParameter("@Create_Date", data.Create_Date));
            comm.Parameters.Add(new SqlParameter("@Views", data.Views));
            comm.Parameters.Add(new SqlParameter("@ShowID", data.ShowID));
            comm.Parameters.Add(new SqlParameter("@Orders", data.Orders));
            comm.Parameters.Add(new SqlParameter("@Level", data.Level));
            comm.Parameters.Add(new SqlParameter("@News", data.News));
            comm.Parameters.Add(new SqlParameter("@page_Home", data.page_Home));
            comm.Parameters.Add(new SqlParameter("@Status", data.Status));
            comm.Parameters.Add(new SqlParameter("@Titleseo", data.Titleseo));
            comm.Parameters.Add(new SqlParameter("@Meta", data.Meta));
            comm.Parameters.Add(new SqlParameter("@Keyword", data.Keyword));
            comm.Parameters.Add(new SqlParameter("@Check_01", data.Check_01));
            comm.Parameters.Add(new SqlParameter("@Check_02", data.Check_02));
            comm.Parameters.Add(new SqlParameter("@Check_03", data.Check_03));
            comm.Parameters.Add(new SqlParameter("@Check_04", data.Check_04));
            comm.Parameters.Add(new SqlParameter("@Check_05", data.Check_05));
            comm.Parameters.Add(new SqlParameter("@Noidung1", data.Noidung1));
            comm.Parameters.Add(new SqlParameter("@Noidung2", data.Noidung2));
            comm.Parameters.Add(new SqlParameter("@Noidung3", data.Noidung3));
            comm.Parameters.Add(new SqlParameter("@Noidung4", data.Noidung4));
            comm.Parameters.Add(new SqlParameter("@Noidung5", data.Noidung5));
            comm.Parameters.Add(new SqlParameter("@Module", data.Module));
            comm.Parameters.Add(new SqlParameter("@TangName", data.TangName));

            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Tinhthanh");
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
        public bool UPDATE(Tinhthanh data)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Tinhthanh_Update", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@ID", data.ID));
            comm.Parameters.Add(new SqlParameter("@Parent_ID", data.Parent_ID));
            comm.Parameters.Add(new SqlParameter("@capp", data.capp));
            comm.Parameters.Add(new SqlParameter("@Type", data.Type));
            comm.Parameters.Add(new SqlParameter("@Lang", data.Lang));
            comm.Parameters.Add(new SqlParameter("@Name", data.Name));
            comm.Parameters.Add(new SqlParameter("@Url_Name", data.Url_Name));
            comm.Parameters.Add(new SqlParameter("@Link", data.Link));
            comm.Parameters.Add(new SqlParameter("@Styleshow", data.Styleshow));
            comm.Parameters.Add(new SqlParameter("@Equals", data.Equals));
            comm.Parameters.Add(new SqlParameter("@Images", data.Images));
            comm.Parameters.Add(new SqlParameter("@Description", data.Description));
            comm.Parameters.Add(new SqlParameter("@Create_Date", data.Create_Date));
            comm.Parameters.Add(new SqlParameter("@Views", data.Views));
            comm.Parameters.Add(new SqlParameter("@ShowID", data.ShowID));
            comm.Parameters.Add(new SqlParameter("@Orders", data.Orders));
            comm.Parameters.Add(new SqlParameter("@Level", data.Level));
            comm.Parameters.Add(new SqlParameter("@News", data.News));
            comm.Parameters.Add(new SqlParameter("@page_Home", data.page_Home));
            comm.Parameters.Add(new SqlParameter("@Status", data.Status));
            comm.Parameters.Add(new SqlParameter("@Titleseo", data.Titleseo));
            comm.Parameters.Add(new SqlParameter("@Meta", data.Meta));
            comm.Parameters.Add(new SqlParameter("@Keyword", data.Keyword));
            comm.Parameters.Add(new SqlParameter("@Check_01", data.Check_01));
            comm.Parameters.Add(new SqlParameter("@Check_02", data.Check_02));
            comm.Parameters.Add(new SqlParameter("@Check_03", data.Check_03));
            comm.Parameters.Add(new SqlParameter("@Check_04", data.Check_04));
            comm.Parameters.Add(new SqlParameter("@Check_05", data.Check_05));
            comm.Parameters.Add(new SqlParameter("@Noidung1", data.Noidung1));
            comm.Parameters.Add(new SqlParameter("@Noidung2", data.Noidung2));
            comm.Parameters.Add(new SqlParameter("@Noidung3", data.Noidung3));
            comm.Parameters.Add(new SqlParameter("@Noidung4", data.Noidung4));
            comm.Parameters.Add(new SqlParameter("@Noidung5", data.Noidung5));
            comm.Parameters.Add(new SqlParameter("@Module", data.Module));
            comm.Parameters.Add(new SqlParameter("@TangName", data.TangName));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Tinhthanh");
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
        public bool UPDATEIMG1(string id, string image)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Tinhthanh_UpdateImg", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@ID", id));
            comm.Parameters.Add(new SqlParameter("@Images", image));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Tinhthanh");
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
            SqlCommand comm = new SqlCommand("delete from Tinhthanh where ID in (" + ID + ")", conn);
            comm.CommandType = CommandType.Text;
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Tinhthanh");
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

        #region DELETE_PARENT
        public void DELETE_PARENT(string Parent_ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("delete from Tinhthanh where Parent_ID in (" + Parent_ID + ")", conn);
            comm.CommandType = CommandType.Text;
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Tinhthanh");
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

        #region UPDATE ORDERS
        public bool UPDATE_ORDERS(string ID, string up_down)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update Tinhthanh set Orders=" + up_down + " where ID = @ID", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Tinhthanh");
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

        #region CATE LOAD ALL NEWS
        public List<Tinhthanh> CATE_LOADALLNEWS(string capp, string Lang, string Parent_ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Tinhthanh_Cate_LoadAllnews", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@capp", capp));
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            comm.Parameters.Add(new SqlParameter("@Parent_ID", Parent_ID));
            try
            {
                return Database.Bind_List_Reader<Tinhthanh>(comm);
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

        #region MORE ID
        public List<Tinhthanh> MORE_ID(string ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("SELECT * FROM [Tinhthanh] WHERE ID IN (" + ID + ")", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                return Database.Bind_List_Reader<Tinhthanh>(comm);
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
        public List<Tinhthanh> Name_StoredProcedure(string Name_StoredProcedure)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_StoredProcedure, conn);
            comm.CommandType = CommandType.StoredProcedure;
            try
            {
                return Database.Bind_List_Reader<Tinhthanh>(comm);
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
        public List<Tinhthanh> Name_Text(string Name_Text)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_Text, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<Tinhthanh>(comm);
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

        #region DETAIL Pages_Home
        public List<Tinhthanh> Pages_Home(string capp, string Lang, string page_Home)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("SELECT * FROM [Tinhthanh] WHERE capp = @capp and Lang = @Lang and page_Home = @page_Home  order by Orders asc", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@capp", capp));
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            comm.Parameters.Add(new SqlParameter("@page_Home", page_Home));
            try
            {
                return Database.Bind_List_Reader<Tinhthanh>(comm);
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
