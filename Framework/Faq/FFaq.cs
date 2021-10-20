using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.SqlClient;
using System.Data;

namespace Framework
{
    public class FFaq
    {
        #region UPDATE VIEW TIME
        public List<Faq> UPDATE_VIEW_TIME(string inid)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update Faq set Views=Views + 1 where inid=@inid", conn);
            comm.CommandType = CommandType.Text;

            comm.Parameters.Add(new SqlParameter("@inid", inid));
            try
            {
                return Database.Bind_List_Reader<Faq>(comm);
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
        public List<Faq> CATEGORY(string lang, string Status)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("SELECT * FROM [Faq] WHERE lang= @lang  AND Status= @Status  order by Create_Date desc", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@lang", lang));
            comm.Parameters.Add(new SqlParameter("@Status", Status));
            try
            {
                return Database.Bind_List_Reader<Faq>(comm);
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
        public List<Faq> GETBYID(string inid)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Faq_GetById", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add(new SqlParameter("@inid", inid));
            try
            {
                return Database.Bind_List_Reader<Faq>(comm);
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
        public List<Faq> GETBYALL(string Lang)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Faq_GetByAll", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            try
            {
                return Database.Bind_List_Reader<Faq>(comm);
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
        public bool INSERT(Faq obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Faq_Insert", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@Title", obj.Title));
            comm.Parameters.Add(new SqlParameter("@Brief", obj.Brief));
            comm.Parameters.Add(new SqlParameter("@Contents", obj.Contents));
            comm.Parameters.Add(new SqlParameter("@Keywords", obj.Keywords));
            comm.Parameters.Add(new SqlParameter("@search", obj.search));
            comm.Parameters.Add(new SqlParameter("@Chekdata", obj.Chekdata));
            comm.Parameters.Add(new SqlParameter("@Create_Date", obj.Create_Date));
            comm.Parameters.Add(new SqlParameter("@Modified_Date", obj.Modified_Date));
            comm.Parameters.Add(new SqlParameter("@Views", obj.Views));
            comm.Parameters.Add(new SqlParameter("@lang", obj.lang));
            comm.Parameters.Add(new SqlParameter("@New", obj.New));
            comm.Parameters.Add(new SqlParameter("@Status", obj.Status));
            comm.Parameters.Add(new SqlParameter("@TangName", obj.TangName));
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
        public bool UPDATE(Faq obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Faq_Update", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@inid", obj.inid));
            comm.Parameters.Add(new SqlParameter("@Title", obj.Title));
            comm.Parameters.Add(new SqlParameter("@Brief", obj.Brief));
            comm.Parameters.Add(new SqlParameter("@Contents", obj.Contents));
            comm.Parameters.Add(new SqlParameter("@Keywords", obj.Keywords));
            comm.Parameters.Add(new SqlParameter("@search", obj.search));
            comm.Parameters.Add(new SqlParameter("@Chekdata", obj.Chekdata));
            comm.Parameters.Add(new SqlParameter("@Create_Date", obj.Create_Date));
            comm.Parameters.Add(new SqlParameter("@Modified_Date", obj.Modified_Date));
            comm.Parameters.Add(new SqlParameter("@Views", obj.Views));
            comm.Parameters.Add(new SqlParameter("@lang", obj.lang));
            comm.Parameters.Add(new SqlParameter("@New", obj.New));
            comm.Parameters.Add(new SqlParameter("@Status", obj.Status));
            comm.Parameters.Add(new SqlParameter("@TangName", obj.TangName));
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
        public void Faq_DELETE(string _Value_List_Delete)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("Delete From [Faq] where [inid] IN(" + _Value_List_Delete + ")", conn);
            comm.CommandType = CommandType.Text;
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
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

        #region Update_Status
        public List<Faq> UPDATE_STATUS(string Status, string inid)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update Faq set Status= @Status where inid= @inid", conn);
            comm.CommandType = CommandType.Text;

            comm.Parameters.Add(new SqlParameter("@Status", Status));
            comm.Parameters.Add(new SqlParameter("@inid", inid));
            try
            {
                return Database.Bind_List_Reader<Faq>(comm);
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

        #region Update_News
        public List<Faq> UPDATE_News(string New, string inid)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update Faq set New= " + New + " where inid= @inid", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@inid", inid));
            try
            {
                return Database.Bind_List_Reader<Faq>(comm);
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
        public List<Faq> Update_datetime(string inid, DateTime Create_Date, DateTime Modified_Date)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update Faq set Create_Date=@Create_Date,Modified_Date=@Modified_Date where inid= @inid", conn);
            comm.CommandType = CommandType.Text;

            comm.Parameters.Add(new SqlParameter("@Create_Date", Create_Date));
            comm.Parameters.Add(new SqlParameter("@Modified_Date", Modified_Date));
            comm.Parameters.Add(new SqlParameter("@inid", inid));
            try
            {
                return Database.Bind_List_Reader<Faq>(comm);
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

        # region CHECKDATA
        public List<Faq> Chekdata(string inid, string Chekdata, DateTime Create_Date, DateTime Modified_Date)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update Faq set Chekdata=@Chekdata,Create_Date=@Create_Date,Modified_Date=@Modified_Date where inid= @inid", conn);
            comm.CommandType = CommandType.Text;

            comm.Parameters.Add(new SqlParameter("@Chekdata", Chekdata));
            comm.Parameters.Add(new SqlParameter("@Create_Date", Create_Date));
            comm.Parameters.Add(new SqlParameter("@Modified_Date", Modified_Date));
            comm.Parameters.Add(new SqlParameter("@inid", inid));
            try
            {
                return Database.Bind_List_Reader<Faq>(comm);
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
        public List<Faq> CATEGORYADMIN(string orderby, string searchkeyword, string[] searchfields, string lang, string Status)
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
            string sql = @"select * from Faq  where  lang='" + lang + "'";// 
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
            comm.Parameters.Add(new SqlParameter("@lang", lang));
            if (!Status.Equals("-1"))
            {
                comm.Parameters.Add(new SqlParameter("@Status", Status));
            }
            try
            {
                return Database.Bind_List_Reader<Faq>(comm);
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
        public List<Faq> SEARCH(string keyword, string lang)
        {
            string sql = @"select * from Faq  where (Title like '%'+ @keyword1 +'%'  or Brief like '%'+ @keyword2 +'%' or Keywords like '%'+ @keyword3 +'%' or Contents like '%'+ @keyword4 +'%'  or search like '%'+ @keyword5+'%') and lang= @lang and Status=1    order by Create_Date desc";
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;

            comm.Parameters.Add(new SqlParameter("@keyword1", keyword));
            comm.Parameters.Add(new SqlParameter("@keyword2", keyword));
            comm.Parameters.Add(new SqlParameter("@keyword3", keyword));
            comm.Parameters.Add(new SqlParameter("@keyword4", keyword));
            comm.Parameters.Add(new SqlParameter("@keyword5", keyword));
            comm.Parameters.Add(new SqlParameter("@lang", lang));
            try
            {
                return Database.Bind_List_Reader<Faq>(comm);
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

        #region GET DETAIL BY ICID
        public List<Faq> GET_DETAIL_BYICID(string imcid)
        {
            string sql = @"SELECT * FROM [Faq] WHERE icid IN (@imcid)";
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;

            comm.Parameters.Add(new SqlParameter("@imcid", imcid));
            try
            {
                return Database.Bind_List_Reader<Faq>(comm);
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


        #region UPDATE DATETIME
        public List<Faq> UPDATE_DATETIME(string inid, string Modified_Date)
        {
            string sql = @"update Faq set Modified_Date= @Modified_Date where inid= @inid";
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;

            comm.Parameters.Add(new SqlParameter("@Modified_Date", Modified_Date));
            comm.Parameters.Add(new SqlParameter("@inid", inid));
            try
            {
                return Database.Bind_List_Reader<Faq>(comm);
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
        public List<Faq> GETDETAIL_BYID(string inid)
        {
            string sql = @"SELECT * FROM [Faq] WHERE inid =@inid";
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;

            comm.Parameters.Add(new SqlParameter("@inid", inid));
            try
            {
                return Database.Bind_List_Reader<Faq>(comm);
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

        #region Faq OTHER LAST
        public List<Faq> Faq_OTHERLAST(string nid, int top, string lang)
        {
            string sql = @"select * from Faq where Create_Date < (select Create_Date from Faq where inid=@nid) and lang=@lang   order by Create_Date desc";
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;

            comm.Parameters.Add(new SqlParameter("@nid", nid));
            comm.Parameters.Add(new SqlParameter("@lang", lang));
            try
            {
                return Database.Bind_List_Reader<Faq>(comm);
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

        #region Faq OTHER FIRST
        public List<Faq> Faq_OTHERFIRST(string nid, int top, string lang)
        {
            string sql = @"select   * from Faq where Create_Date > (select Create_Date from Faq where inid=@nid) and lang=@lang    order by Create_Date desc";
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@nid", nid));
            comm.Parameters.Add(new SqlParameter("@lang", lang));
            try
            {
                return Database.Bind_List_Reader<Faq>(comm);
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
        public List<Faq> Detail_Top(int top, string lang, string Status)
        {
            string sql = @"SELECT * FROM [Faq] WHERE icid=@icid AND lang= @lang  AND Status= @Status  order by Create_Date desc";
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@lang", lang));
            comm.Parameters.Add(new SqlParameter("@Status", Status));
            try
            {
                return Database.Bind_List_Reader<Faq>(comm);
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

        #region GET Text Sql ALL
        public List<Faq> Text(string Text)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Text, conn);
            comm.CommandType = CommandType.Text;

            try
            {
                return Database.Bind_List_Reader<Faq>(comm);
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
        public List<Faq> Name_StoredProcedure(string Name_StoredProcedure)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_StoredProcedure, conn);
            comm.CommandType = CommandType.StoredProcedure;
            try
            {
                return Database.Bind_List_Reader<Faq>(comm);
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
        public List<Faq> Name_Text(string Name_Text)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_Text, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<Faq>(comm);
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
