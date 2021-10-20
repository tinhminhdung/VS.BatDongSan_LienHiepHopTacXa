using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.SqlClient;
using System.Data;

namespace Framework
{
    public class FVideoClip
    {

        #region CATEGORY_PHANTRANG_ADMIN
        public List<VideoClip> CATEGORY_PHANTRANG_ADMIN1(string icid, string filter, string lang)
        {
            string sql = @"SELECT * FROM  VideoClip  WHERE	Menu_ID in (" + icid + ") and  lang='" + lang + "' " + filter + " ";
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<VideoClip>(comm);
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
        public List<VideoClip> CATEGORY_PHANTRANG_ADMIN2(string icid, string filter, string lang, string sapxep, int PageIndex, int Tongpage)
        {
            int StartRecord = PageIndex * Tongpage;
            int EndRecord = StartRecord + Tongpage + 1;

            string sql = @"SELECT  * FROM  ( SELECT ROW_NUMBER() OVER (" + sapxep + ") AS rowindex,* FROM  VideoClip WHERE	Menu_ID in (" + icid + ") and  lang='" + lang + "'  " + filter + "";
            sql += ") AS A WHERE  ( A.rowindex >  " + StartRecord.ToString() + " AND A.rowindex < " + EndRecord + ")";
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<VideoClip>(comm);
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

        #region CATEGORY_PHANTRANG
        public List<VideoClip_RutGon> CATEGORY_PHANTRANG(string icid, string lang, string Status, int PageIndex, ref int TotalRecords, int Tongpage)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("Category_VideoClip_List", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters(comm);
            comm.Parameters["@Nhom"].Value = icid;
            comm.Parameters["@lang"].Value = lang;
            comm.Parameters["@Status"].Value = Status;
            comm.Parameters["@PageIndex"].Value = PageIndex;
            comm.Parameters["@TotalRecord"].Direction = ParameterDirection.Output;
            comm.Parameters["@Tongpage"].Value = Tongpage;
            try
            {
                return Database.Bind_List_Reader_pages<VideoClip_RutGon>(comm, ref TotalRecords);
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
        public bool INSERT(VideoClip obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_VideoClip_Insert", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@Menu_ID", obj.Menu_ID));
            comm.Parameters.Add(new SqlParameter("@Title", obj.Title));
            comm.Parameters.Add(new SqlParameter("@Brief", obj.Brief));
            comm.Parameters.Add(new SqlParameter("@Contents", obj.Contents));
            comm.Parameters.Add(new SqlParameter("@Keywords", obj.Keywords));
            comm.Parameters.Add(new SqlParameter("@search", obj.search));
            comm.Parameters.Add(new SqlParameter("@Images", obj.Images));
            comm.Parameters.Add(new SqlParameter("@ImagesSmall", obj.ImagesSmall));
            comm.Parameters.Add(new SqlParameter("@Equals", obj.Equals));
            comm.Parameters.Add(new SqlParameter("@Chekdata", obj.Chekdata));
            comm.Parameters.Add(new SqlParameter("@Create_Date", obj.Create_Date));
            comm.Parameters.Add(new SqlParameter("@Modified_Date", obj.Modified_Date));
            comm.Parameters.Add(new SqlParameter("@Views", obj.Views));
            comm.Parameters.Add(new SqlParameter("@lang", obj.lang));
            comm.Parameters.Add(new SqlParameter("@News", obj.News));
            comm.Parameters.Add(new SqlParameter("@Status", obj.Status));
            comm.Parameters.Add(new SqlParameter("@Titleseo", obj.Titleseo));
            comm.Parameters.Add(new SqlParameter("@Meta", obj.Meta));
            comm.Parameters.Add(new SqlParameter("@Keyword", obj.Keyword));
            comm.Parameters.Add(new SqlParameter("@TangName", obj.TangName));
            comm.Parameters.Add(new SqlParameter("@Alt", obj.Alt));
            comm.Parameters.Add(new SqlParameter("@Youtube", obj.Youtube));
            
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
        public bool UPDATE(VideoClip obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_VideoClip_Update", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@ID", obj.ID));
            comm.Parameters.Add(new SqlParameter("@Menu_ID", obj.Menu_ID));
            comm.Parameters.Add(new SqlParameter("@Title", obj.Title));
            comm.Parameters.Add(new SqlParameter("@Brief", obj.Brief));
            comm.Parameters.Add(new SqlParameter("@Contents", obj.Contents));
            comm.Parameters.Add(new SqlParameter("@Keywords", obj.Keywords));
            comm.Parameters.Add(new SqlParameter("@search", obj.search));
            comm.Parameters.Add(new SqlParameter("@Images", obj.Images));
            comm.Parameters.Add(new SqlParameter("@ImagesSmall", obj.ImagesSmall));
            comm.Parameters.Add(new SqlParameter("@Equals", obj.Equals));
            comm.Parameters.Add(new SqlParameter("@Chekdata", obj.Chekdata));
            //comm.Parameters.Add(new SqlParameter("@Create_Date", obj.Create_Date));
            //comm.Parameters.Add(new SqlParameter("@Modified_Date", obj.Modified_Date));
            comm.Parameters.Add(new SqlParameter("@Views", obj.Views));
            comm.Parameters.Add(new SqlParameter("@lang", obj.lang));
            comm.Parameters.Add(new SqlParameter("@News", obj.News));
            comm.Parameters.Add(new SqlParameter("@Status", obj.Status));
            comm.Parameters.Add(new SqlParameter("@Titleseo", obj.Titleseo));
            comm.Parameters.Add(new SqlParameter("@Meta", obj.Meta));
            comm.Parameters.Add(new SqlParameter("@Keyword", obj.Keyword));
            comm.Parameters.Add(new SqlParameter("@TangName", obj.TangName));
            comm.Parameters.Add(new SqlParameter("@Alt", obj.Alt));
            comm.Parameters.Add(new SqlParameter("@Youtube", obj.Youtube));
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

        #region UPDATE TIME
        public bool UPDATE_TIME(string id, bool updatecreatedate, string Modified_Date)
        {
            string createdate = "";
            if (updatecreatedate == false)
            {
                createdate = "Create_Date = getdate(),";
            }
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update VideoClip set " + createdate + "Modified_Date = @Modified_Date where ID = @ID", conn);
            comm.CommandType = CommandType.Text;

            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@Modified_Date", Modified_Date));
            comm.Parameters.Add(new SqlParameter("@ID", id));
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

        #region UPDATE IMG
        public bool UPDATEIMG(string ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update VideoClip set Images='',ImagesSmall='' where ID = @ID", conn);
            comm.CommandType = CommandType.Text;

            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@ID", ID));
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

        #region UPDATE STATUS
        public bool UPDATE_STATUS(string ID, string status)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("UPDATE [VideoClip] SET [status] = @Status WHERE ID =@ID", conn);
            comm.CommandType = CommandType.Text;

            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@status", status));
            comm.Parameters.Add(new SqlParameter("@ID", ID));
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
        public void DELETE(string ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_VideoClip_Delete", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@ID", ID));
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

        #region CATE DELETE MENU ID
        public void Video_CATE_DELETE_MENU_ID(string Menu_ID, string imcid)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("delete from VideoClip where Menu_ID = @Menu_ID  or Menu_ID in (" + imcid + ")", conn);
            comm.CommandType = CommandType.Text;
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@Menu_ID", Menu_ID));
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
        //
        #region GET BY ID
        public List<Entity.VideoClip> GETBYID(string ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_VideoClip_GetById", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                return Database.Bind_List_Reader<VideoClip>(comm);
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
        public List<Entity.VideoClip> GETBYALL(string Lang)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_VideoClip_GetByAll", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            try
            {
                return Database.Bind_List_Reader<VideoClip>(comm);
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

        #region GET DETAIL MENU ID
        public List<Entity.VideoClip> GETDETAIL_MENUID(string ID_Menu, string imcid)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from VideoClip where Menu_ID = @ID_Menu  or Menu_ID in (" + imcid + ") and Status=1 ", conn);
            comm.CommandType = CommandType.Text;

            comm.Parameters.Add(new SqlParameter("@ID_Menu", ID_Menu));
            try
            {
                return Database.Bind_List_Reader<VideoClip>(comm);
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
        public List<Entity.VideoClip> Video_GETDETAIL_BYID(string ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from VideoClip where ID = @ID", conn);
            comm.CommandType = CommandType.Text;

            comm.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                return Database.Bind_List_Reader<VideoClip>(comm);
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
        public List<Entity.VideoClip> NEWS_OTHERLAST(string ID, int top, string lang)
        {
            string sql = @"select top " + top.ToString() + "  * from VideoClip where Create_Date < (select Create_Date from VideoClip where id=@id) and lang=@lang   order by Create_Date desc";
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;

            comm.Parameters.Add(new SqlParameter("@ID", ID));
            comm.Parameters.Add(new SqlParameter("@lang", lang));
            try
            {
                return Database.Bind_List_Reader<VideoClip>(comm);
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
        public List<Entity.VideoClip> NEWS_OTHERFIRST(string ID, int top, string lang)
        {
            string sql = @"select top " + top.ToString() + "  * from VideoClip where Create_Date > (select Create_Date from VideoClip where id=@id) and lang=@lang    order by Create_Date desc";
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;

            comm.Parameters.Add(new SqlParameter("@ID", ID));
            comm.Parameters.Add(new SqlParameter("@lang", lang));
            try
            {
                return Database.Bind_List_Reader<VideoClip>(comm);
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

        # region CHEKCDATA
        public List<Entity.VideoClip> CHECKDATA(string ID, string Chekdata, DateTime Create_Date, DateTime Modified_Date)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update VideoClip set Chekdata=@Chekdata,Create_Date=@Create_Date,Modified_Date=@Modified_Date where ID= @ID", conn);
            comm.CommandType = CommandType.Text;

            comm.Parameters.Add(new SqlParameter("@Chekdata", Chekdata));
            comm.Parameters.Add(new SqlParameter("@Create_Date", Create_Date));
            comm.Parameters.Add(new SqlParameter("@Modified_Date", Modified_Date));
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                return Database.Bind_List_Reader<VideoClip>(comm);
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

        #region UPDATE VIEW TIME
        public List<Entity.VideoClip> UPDATE_VIEWTIME(string ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update VideoClip set Views=Views + 1 where ID=@ID", conn);
            comm.CommandType = CommandType.Text;

            comm.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                return Database.Bind_List_Reader<VideoClip>(comm);
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

        # region UPDATE DATETIME
        public List<Entity.VideoClip> UPDATE_DATETIME(string ID, DateTime Create_Date, DateTime Modified_Date)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update VideoClip set Create_Date=@Create_Date,Modified_Date=@Modified_Date where ID= @ID", conn);
            comm.CommandType = CommandType.Text;

            comm.Parameters.Add(new SqlParameter("@Create_Date", Create_Date));
            comm.Parameters.Add(new SqlParameter("@Modified_Date", Modified_Date));
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                return Database.Bind_List_Reader<VideoClip>(comm);
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

        #region CATEGORY
        public List<Entity.VideoClip_RutGon> CATEGORY(string imid, string lang, string Status)
        {
            string sql = @"select ID,Title,Images,Alt,ImagesSmall,Create_Date,TangName,Youtube,Brief from VideoClip where Menu_ID IN (" + imid + ") and lang=@lang  and Status=@Status  order by Create_Date desc";
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;

            comm.Parameters.Add(new SqlParameter("@lang", lang));
            comm.Parameters.Add(new SqlParameter("@Status", Status));
            try
            {
                return Database.Bind_List_Reader<VideoClip_RutGon>(comm);
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
        public List<Entity.VideoClip> CATEGORY_ADMIN(string orderby, string searchkeyword, string[] searchfields, string Menu_ID, string imcid, string lang, string Status)
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
            string sql = @"select * from VideoClip where Menu_ID in (" + imcid + ") and lang='" + lang + "'";
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
                return Database.Bind_List_Reader<VideoClip>(comm);
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
        public List<Entity.VideoClip> Name_StoredProcedure(string Name_StoredProcedure)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_StoredProcedure, conn);
            comm.CommandType = CommandType.StoredProcedure;
            try
            {
                return Database.Bind_List_Reader<VideoClip>(comm);
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
        public List<Entity.VideoClip> Name_Text(string Name_Text)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_Text, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<VideoClip>(comm);
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
        //ID,Title,Images,Alt,ImagesSmall,Create_Date,TangName
        public List<Entity.VideoClip_RutGon> Name_Text_RG(string Name_Text)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_Text, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<VideoClip_RutGon>(comm);
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
