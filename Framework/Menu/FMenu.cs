using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.SqlClient;
using System.Data;

namespace Framework
{
    public class FMenu
    {


        #region CATEGORY_PHANTRANG
        public List<Menu> CATEGORY_PHANTRANG(string capp, int PageIndex, ref int TotalRecords, int Tongpage)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("Menu_List", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters(comm);
            comm.Parameters["@capp"].Value = capp;
            comm.Parameters["@PageIndex"].Value = PageIndex;
            comm.Parameters["@TotalRecord"].Direction = ParameterDirection.Output;
            comm.Parameters["@Tongpage"].Value = Tongpage;
            try
            {
                return Database.Bind_List_Reader_pages<Menu>(comm, ref TotalRecords);
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


        #region Menu_ExitstByLevel
        public List<Menu_OK> Menu_ExitstByLevel(string Level)
        {
            int n = Level.Length;
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select capp,Create_Date,Description,Equals,ID,Images,Lang,Level,Link,Module,Name,Orders,Parent_ID,ShowID,Styleshow,TangName,Type,Url_Name,Views from Menu where Level <> '" + Level + "' and substring(Level, 1, " + n.ToString() + ") = '" + Level + "' and capp='MN'", conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<Menu_OK>(comm);
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

        public DataTable DataTable_capp_Lang_MoreIn_ID_Status(string capp, string Lang, string Parent_ID, string Status)
        {
            DataTable dts = new DataTable();
            SqlDataAdapter VSda;
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("SELECT * FROM [Menu]  where capp=@capp and Lang=@Lang  and Parent_ID=@Parent_ID and Status=@Status order by ID asc,Orders desc", conn);
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

        #region UPDATE Updatemenu
        public bool Updatemenu(string id, string Giatri, string Giatritruyen)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("UPDATE [Menu] SET [" + Giatri + "] =" + Giatritruyen + " WHERE id= @id", conn);
            comm.CommandType = CommandType.Text;
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@id", id));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Menu");
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
        public List<Menu> capp_Lang_MoreIn_ID_Status(string capp, string Lang, string ID, string Status)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("SELECT * FROM [Menu]  where capp=@capp and lang=@Lang and id in(" + ID + ") and Status=@Status  order by ID asc,Orders desc", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@capp", capp));
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            comm.Parameters.Add(new SqlParameter("@Status", Status));
            try
            {
                return Database.Bind_List_Reader<Menu>(comm);
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

        #region CATE LOAD ALL MENU
        public List<Menu> LOAD_ALL_MENU(string capp, string Lang, string Parent_ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Menu_Cate_LoadAllnews", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@capp", capp));
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            comm.Parameters.Add(new SqlParameter("@Parent_ID", Parent_ID));
            try
            {
                return Database.Bind_List_Reader<Menu>(comm);
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
        public List<Menu> CATE_CAPP_LANG(string capp, string Lang, string Status)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Menu_Cate_capp_Lang", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@capp", capp));
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            comm.Parameters.Add(new SqlParameter("@Status", Status));
            try
            {
                return Database.Bind_List_Reader<Menu>(comm);
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
        public List<Menu> LOAD_CATES_PARENTID(string capp, string Lang, string Parent_ID, string Status)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Menu_Load_Cates_Parent_ID", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@capp", capp));
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            comm.Parameters.Add(new SqlParameter("@Parent_ID", Parent_ID));
            comm.Parameters.Add(new SqlParameter("@Status", Status));
            try
            {
                return Database.Bind_List_Reader<Menu>(comm);
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
        public List<Menu> capp_Lang_ID_Status(string capp, string Lang, string ID, string Status)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Menu_Load_Cates_ID", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@capp", capp));
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            comm.Parameters.Add(new SqlParameter("@Status", Status));
            try
            {
                return Database.Bind_List_Reader<Menu>(comm);
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
        public List<Menu> DETAIL_CAPP(string ID, string capp)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Menu_Load_ID", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            comm.Parameters.Add(new SqlParameter("@capp", capp));
            try
            {
                return Database.Bind_List_Reader<Menu>(comm);
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
        public List<Menu> DETAIL_CAPP_PARENTID(string Parent_ID, string capp)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("SELECT * FROM [Menu] where Parent_ID=@Parent_ID and capp=@capp order by Orders asc", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@Parent_ID", Parent_ID));
            comm.Parameters.Add(new SqlParameter("@capp", capp));
            try
            {
                return Database.Bind_List_Reader<Menu>(comm);
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

        #region Load category id kiểu in
        public List<MenuID> Menu_ID(string Parent_ID, string capp)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("SELECT * FROM [Menu] where Parent_ID=@Parent_ID and capp=@capp order by Orders asc", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@Parent_ID", Parent_ID));
            comm.Parameters.Add(new SqlParameter("@capp", capp));
            try
            {
                return Database.Bind_List_Reader<MenuID>(comm);
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
        public List<Menu> capp_Lang_Parent_ID_Home_Status(string capp, string Lang, string Parent_ID, string page_Home, string Status)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("SELECT * FROM [Menu]  where capp=@capp and Lang=@Lang  and Parent_ID=@Parent_ID and page_Home=@page_Home and Status=@Status order by Orders asc", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@capp", capp));
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            comm.Parameters.Add(new SqlParameter("@Parent_ID", Parent_ID));
            comm.Parameters.Add(new SqlParameter("@page_Home", page_Home));
            comm.Parameters.Add(new SqlParameter("@Status", Status));
            try
            {
                return Database.Bind_List_Reader<Menu>(comm);
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
        public List<Menu> LOADCID(string Parent_ID, string capp)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Menu_Loadcid", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@Parent_ID", Parent_ID));
            comm.Parameters.Add(new SqlParameter("@capp", capp));
            try
            {
                return Database.Bind_List_Reader<Menu>(comm);
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
        public List<Menu> LOADCAPP(string Capp)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Menu_Load_Capp", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@Capp", Capp));
            try
            {
                return Database.Bind_List_Reader<Menu>(comm);
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
        public List<Menu> ID_Parent_ID(string ID,string _parent_ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * FROM [Menu] WHERE ID=@ID and Parent_ID in (" + _parent_ID + ") and Status=1", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            comm.Parameters.Add(new SqlParameter("@Parent_ID", _parent_ID));
            try
            {
                return Database.Bind_List_Reader<Menu>(comm);
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
        public List<Menu> Parent_ID(string _parent_ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * FROM [Menu] WHERE  Parent_ID in (" + _parent_ID + ") and capp='PR' and Status=1", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@Parent_ID", _parent_ID));
            try
            {
                return Database.Bind_List_Reader<Menu>(comm);
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
        public List<Menu> GETPARENT_ID(string ID, string Parent_ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Menu_Get_Parent_ID", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            comm.Parameters.Add(new SqlParameter("@Parent_ID", Parent_ID));
            try
            {
                return Database.Bind_List_Reader<Menu>(comm);
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
        public List<Menu> DETAIL_NEWS(string capp, string Lang, string News)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Menu_Detail_News", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@capp", capp));
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            comm.Parameters.Add(new SqlParameter("@News", News));
            try
            {
                return Database.Bind_List_Reader<Menu>(comm);
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
        public List<Menu> LOADCATES(string Lang, string capp, string Parent_ID, string Status)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Menu_LoadCates", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            comm.Parameters.Add(new SqlParameter("@capp", capp));
            comm.Parameters.Add(new SqlParameter("@Parent_ID", Parent_ID));
            comm.Parameters.Add(new SqlParameter("@Status", Status));
            try
            {
                return Database.Bind_List_Reader<Menu>(comm);
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
        public List<Menu> CATE_LOADALL(string Lang, string capp, string Parent_ID, string Status)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Menu_Cate_LoadAll", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            comm.Parameters.Add(new SqlParameter("@capp", capp));
            comm.Parameters.Add(new SqlParameter("@Parent_ID", Parent_ID));
            try
            {
                return Database.Bind_List_Reader<Menu>(comm);
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
            SqlCommand comm = new SqlCommand("S_Menu_Update", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            comm.Parameters.Add(new SqlParameter("@sql", sql));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Menu");
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
            SqlCommand comm = new SqlCommand("S_Menu_Updatestatus", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@status", status));
            comm.Parameters.Add(new SqlParameter("@id", id));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Menu");
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
            SqlCommand comm = new SqlCommand("	UPDATE [Menu] SET [page_Home] = @page_Home WHERE id= @id", conn);
            comm.CommandType = CommandType.Text;
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@page_Home", page_Home));
            comm.Parameters.Add(new SqlParameter("@id", id));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Menu");
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
            SqlCommand comm = new SqlCommand("S_Menu_Update_Order", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@Orders", Orders));
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Menu");
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
            SqlCommand comm = new SqlCommand("UPDATE [Menu] SET Orders=Orders + 1 WHERE ID = @ID", conn);
            comm.CommandType = CommandType.Text;
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Menu");
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
            SqlCommand comm = new SqlCommand("UPDATE [Menu] SET Orders=Orders - 1 WHERE ID = @ID", conn);
            comm.CommandType = CommandType.Text;
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Menu");
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
            SqlCommand comm = new SqlCommand("S_Menu_UpdateImg", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@Images", Images));
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Menu");
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
        public List<Menu> GETBYID(string ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("SELECT * FROM [Menu] WHERE ID = @ID", conn);
            comm.CommandType = CommandType.Text;

            comm.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                return Database.Bind_List_Reader<Menu>(comm);
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


        #region M_TangNameicid
        public List<MenuID> M_TangNameicid(string sql, string TangName)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@TangName", TangName));
            try
            {
                return Database.Bind_List_Reader<MenuID>(comm);
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
        public List<Menu> Detail(string ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("SELECT * FROM [Menu] WHERE ID = @ID", conn);
            comm.CommandType = CommandType.Text;

            comm.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                return Database.Bind_List_Reader<Menu>(comm);
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
        public List<Menu> GETBYTOP(string Top, string Where, string Order)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("sp_Menu_GetByTop", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add(new SqlParameter("@Top", Top));
            comm.Parameters.Add(new SqlParameter("@Where", Where));
            comm.Parameters.Add(new SqlParameter("@Order", Order));
            try
            {
                return Database.Bind_List_Reader<Menu>(comm);
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
        public List<Menu> GETBYALL(string Lang)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Menu_GetByAll", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            try
            {
                return Database.Bind_List_Reader<Menu>(comm);
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
        public List<Menu> PAGING(string CurentPage, string PageSize, string Lang)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("sp_Menu_Paging", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add(new SqlParameter("@CurentPage", CurentPage));
            comm.Parameters.Add(new SqlParameter("@PageSize", PageSize));
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            try
            {
                return Database.Bind_List_Reader<Menu>(comm);
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
        public bool INSERT(Menu data)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Menu_Insert", conn);
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
                System.Web.HttpContext.Current.Cache.Remove("Menu");
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
        public bool UPDATE(Menu data)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Menu_Update", conn);
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
                System.Web.HttpContext.Current.Cache.Remove("Menu");
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


        #region INSERT
        public bool INSERT_NoLevel(Menu data)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Menu_Insert_NoLevel", conn);
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
                System.Web.HttpContext.Current.Cache.Remove("Menu");
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
        public bool UPDATE_NoLevel(Menu data)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Menu_Update_NoLevel", conn);
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
                System.Web.HttpContext.Current.Cache.Remove("Menu");
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
            SqlCommand comm = new SqlCommand("S_Menu_UpdateImg", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@ID", id));
            comm.Parameters.Add(new SqlParameter("@Images", image));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Menu");
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
            SqlCommand comm = new SqlCommand("delete from Menu where ID in (" + ID + ")", conn);
            comm.CommandType = CommandType.Text;
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Menu");
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
            SqlCommand comm = new SqlCommand("delete from Menu where Parent_ID in (" + Parent_ID + ")", conn);
            comm.CommandType = CommandType.Text;
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Menu");
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
            SqlCommand comm = new SqlCommand("update Menu set Orders=" + up_down + " where ID = @ID", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Menu");
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
        public List<Menu> CATE_LOADALLNEWS(string capp, string Lang, string Parent_ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Menu_Cate_LoadAllnews", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@capp", capp));
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            comm.Parameters.Add(new SqlParameter("@Parent_ID", Parent_ID));
            try
            {
                return Database.Bind_List_Reader<Menu>(comm);
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
        public List<Menu> MORE_ID(string ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("SELECT * FROM [Menu] WHERE ID IN (" + ID + ")", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                return Database.Bind_List_Reader<Menu>(comm);
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
        public List<Menu> Name_StoredProcedure(string Name_StoredProcedure)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_StoredProcedure, conn);
            comm.CommandType = CommandType.StoredProcedure;
            try
            {
                return Database.Bind_List_Reader<Menu>(comm);
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
        public List<Menu> Name_Text(string Name_Text)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_Text, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<Menu>(comm);
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

        //capp,Create_Date,Description,Equals,ID,Images,Lang,Level,Link,Module,Name,Orders,Parent_ID,ShowID,Styleshow,TangName,Type,Url_Name,Views
        public List<Menu_OK> Name_Text_Rg(string Name_Text)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_Text, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<Menu_OK>(comm);
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
        public List<MenuID> Name_Text_ID(string Name_Text)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_Text, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<MenuID>(comm);
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
        

        #region DETAIL Pages_Home
        public List<MenuShow> Pages_Home(string capp, string Lang, string page_Home)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("SELECT * FROM [Menu] WHERE capp = @capp and Lang = @Lang and page_Home = @page_Home  order by Orders asc", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@capp", capp));
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            comm.Parameters.Add(new SqlParameter("@page_Home", page_Home));
            try
            {
                return Database.Bind_List_Reader<MenuShow>(comm);
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
