using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.SqlClient;
using System.Data;

namespace Framework
{
    public class FNews
    {
        public static string Sql_News()
        {
            return "inid,Alt,TangName,Title,Images,ImagesSmall,Brief,Create_Date";
        }
        //        public List<Category_News> CATEGORY_PHANTRANG(string icid, string lang, string Status, int PageIndex, int Tongpage)
        //        {
        //            int StartRecord = PageIndex * Tongpage;
        //            int EndRecord = StartRecord + Tongpage + 1;
        //            string sql = @"SELECT  "+Sql_News()+"   FROM  (SELECT ROW_NUMBER() OVER (ORDER BY Create_Date DESC) AS rowindex,"+Sql_News()+"
        //		                FROM  News
        //		                WHERE	icid in (" + icid + ") and  lang='" + lang + "' and  Status=" + Status + " ";
        //            sql += ") AS A WHERE  ( A.rowindex >  " + StartRecord.ToString() + " AND A.rowindex < " + EndRecord + ")";
        //            SqlConnection conn = Database.Connection();
        //            SqlCommand comm = new SqlCommand(sql, conn);
        //            comm.CommandType = CommandType.Text;
        //            try
        //            {
        //                return Database.Bind_List_Reader<Category_News>(comm);
        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }
        //            finally
        //            {
        //                conn.Close();
        //            }
        //        }

        #region CATEGORY_PHANTRANG_ADMIN
        public List<News> CATEGORY_PHANTRANG_ADMIN1(string icid, string filter, string lang)
        {
            string sql = @"SELECT * FROM  News  WHERE	icid in (" + icid + ") and  lang='" + lang + "' " + filter + " ";
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<News>(comm);
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
        public List<News> CATEGORY_PHANTRANG_ADMIN2(string icid, string filter, string lang, string sapxep, int PageIndex, int Tongpage)
        {
            int StartRecord = PageIndex * Tongpage;
            int EndRecord = StartRecord + Tongpage + 1;

            string sql = @"SELECT  * FROM  ( SELECT ROW_NUMBER() OVER (" + sapxep + ") AS rowindex,* FROM  News   WHERE	icid in (" + icid + ") and  lang='" + lang + "'  " + filter + "";
            sql += ") AS A WHERE  ( A.rowindex >  " + StartRecord.ToString() + " AND A.rowindex < " + EndRecord + ")";
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<News>(comm);
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

        #region SearchPro
        public List<Category_News> SearchNews(String keyword, string lang, string Status, int PageIndex, ref int TotalRecords, int Tongpage)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("SearchNews", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters(comm);
            comm.Parameters["@keyword"].Value = SearchApproximate.Exec(keyword);
            comm.Parameters["@lang"].Value = lang;
            comm.Parameters["@Status"].Value = Status;
            comm.Parameters["@PageIndex"].Value = PageIndex;
            comm.Parameters["@TotalRecord"].Direction = ParameterDirection.Output;
            comm.Parameters["@Tongpage"].Value = Tongpage;
            try
            {
                return Database.Bind_List_Reader_pages<Category_News>(comm, ref TotalRecords);
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
        public List<News> CATEGORY(string icid, string lang, string Status)
        {
            List<News> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("SELECT * FROM [News] WHERE icid IN(" + icid + ") AND lang= @lang  AND Status= @Status  order by Create_Date desc", connection)
            {
                CommandType = CommandType.Text
            };
            command.Parameters.Add(new SqlParameter("@lang", lang));
            command.Parameters.Add(new SqlParameter("@Status", Status));
            command.Parameters.Add(new SqlParameter("@icid", icid));
            try
            {
                list = Database.Bind_List_Reader<News>(command);
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

        public List<News> CATEGORYADMIN(string orderby, string searchkeyword, string[] searchfields, string icid, string lang, string Status)
        {
            List<News> list;
            string str = "";
            if (orderby.Length < 1)
            {
                str = "order by Create_Date desc";
            }
            else
            {
                str = "order by " + orderby;
            }
            string cmdText = "select * from News  where icid in (" + icid + ")  and lang='" + lang + "'";
            if (!Status.Equals("-1"))
            {
                cmdText = cmdText + " and Status=" + Status + " ";
            }
            if ((searchkeyword.Length > 0) && (searchfields.Length > 0))
            {
                cmdText = cmdText + " and ";
                string str3 = "(";
                for (int i = 0; i < searchfields.Length; i++)
                {

                    if (i < (searchfields.Length - 1))
                    {
                        str3 = str3 + searchfields[i] + " LIKE N'" + SearchApproximate.Exec(ConvertVN.Convert(searchkeyword)) + "' or ";
                    }
                    else
                    {
                        str3 = str3 + searchfields[i] + " LIKE N'" + SearchApproximate.Exec(ConvertVN.Convert(searchkeyword)) + "'";
                    }

                    //if (i < (searchfields.Length - 1))
                    //{
                    // str3 = str3 + searchfields[i] + " like N'%" + searchkeyword + "%' or ";
                    //}
                    //else
                    //{
                    //str3 = str3 + searchfields[i] + " like N'%" + searchkeyword + "%'";
                    //}
                }
                str3 = str3 + ")";
                cmdText = cmdText + str3;
            }
            cmdText = cmdText + " " + str;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand(cmdText, connection)
            {
                CommandType = CommandType.Text
            };
            command.Parameters.Add(new SqlParameter("@icid", icid));
            command.Parameters.Add(new SqlParameter("@lang", lang));
            if (!Status.Equals("-1"))
            {
                command.Parameters.Add(new SqlParameter("@Status", Status));
            }
            try
            {
                list = Database.Bind_List_Reader<News>(command);
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

        public List<News> Chekdata(string inid, string Chekdata, DateTime Create_Date, DateTime Modified_Date)
        {
            List<News> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("update News set Chekdata=@Chekdata,Create_Date=@Create_Date,Modified_Date=@Modified_Date where inid= @inid", connection)
            {
                CommandType = CommandType.Text
            };
            command.Parameters.Add(new SqlParameter("@Chekdata", Chekdata));
            command.Parameters.Add(new SqlParameter("@Create_Date", Create_Date));
            command.Parameters.Add(new SqlParameter("@Modified_Date", Modified_Date));
            command.Parameters.Add(new SqlParameter("@inid", inid));
            try
            {
                list = Database.Bind_List_Reader<News>(command);
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

        public List<News> DETAIL_NEWS_RELATED(string inid)
        {
            List<News> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("select * from News where inid in(" + inid + ")", connection)
            {
                CommandType = CommandType.Text
            };
            command.Parameters.Add(new SqlParameter("@inid", inid));
            try
            {
                list = Database.Bind_List_Reader<News>(command);
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

        public List<News> Detail_Top(int top, string icid, string lang, string Status)
        {
            List<News> list;
            string cmdText = "SELECT top (" + top.ToString() + ") * FROM [News] WHERE icid=@icid AND lang= @lang  AND Status= @Status  order by Create_Date desc";
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand(cmdText, connection)
            {
                CommandType = CommandType.Text
            };
            command.Parameters.Add(new SqlParameter("@icid", icid));
            command.Parameters.Add(new SqlParameter("@lang", lang));
            command.Parameters.Add(new SqlParameter("@Status", Status));
            try
            {
                list = Database.Bind_List_Reader<News>(command);
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

        public List<News> GET_DETAIL_BYICID(string imcid)
        {
            List<News> list;
            string cmdText = "SELECT * FROM [News] WHERE icid IN (@imcid)";
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand(cmdText, connection)
            {
                CommandType = CommandType.Text
            };
            command.Parameters.Add(new SqlParameter("@imcid", imcid));
            try
            {
                list = Database.Bind_List_Reader<News>(command);
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

        public List<News> GETBYALL(string Lang)
        {
            List<News> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("S_News_GetByAll", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@Lang", Lang));
            try
            {
                list = Database.Bind_List_Reader<News>(command);
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

        public List<News> GETBYID(string inid)
        {
            List<News> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("S_News_GetById", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@inid", inid));
            try
            {
                list = Database.Bind_List_Reader<News>(command);
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

        public List<News> GETDETAIL_BYID(string inid)
        {
            List<News> list;
            string cmdText = "SELECT * FROM [News] WHERE inid =@inid";
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand(cmdText, connection)
            {
                CommandType = CommandType.Text
            };
            command.Parameters.Add(new SqlParameter("@inid", inid));
            try
            {
                list = Database.Bind_List_Reader<News>(command);
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

        public bool INSERT(News obj)
        {
            bool flag;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("S_News_Insert", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlTransaction transaction = connection.BeginTransaction();
            command.Transaction = transaction;
            command.Parameters.Add(new SqlParameter("@icid", obj.icid));
            command.Parameters.Add(new SqlParameter("@Title", obj.Title));
            command.Parameters.Add(new SqlParameter("@Brief", obj.Brief));
            command.Parameters.Add(new SqlParameter("@Contents", obj.Contents));
            command.Parameters.Add(new SqlParameter("@Keywords", obj.Keywords));
            command.Parameters.Add(new SqlParameter("@search", obj.search));
            command.Parameters.Add(new SqlParameter("@Images", obj.Images));
            command.Parameters.Add(new SqlParameter("@ImagesSmall", obj.ImagesSmall));
            command.Parameters.Add(new SqlParameter("@Equals", obj.Equals));
            command.Parameters.Add(new SqlParameter("@Chekdata", obj.Chekdata));
            command.Parameters.Add(new SqlParameter("@Create_Date", obj.Create_Date));
            command.Parameters.Add(new SqlParameter("@Modified_Date", obj.Modified_Date));
            command.Parameters.Add(new SqlParameter("@Views", obj.Views));
            command.Parameters.Add(new SqlParameter("@Tags", obj.Tags));
            command.Parameters.Add(new SqlParameter("@lang", obj.lang));
            command.Parameters.Add(new SqlParameter("@New", obj.New));
            command.Parameters.Add(new SqlParameter("@CheckBox1", obj.CheckBox1));
            command.Parameters.Add(new SqlParameter("@CheckBox2", obj.CheckBox2));
            command.Parameters.Add(new SqlParameter("@CheckBox3", obj.CheckBox3));
            command.Parameters.Add(new SqlParameter("@CheckBox4", obj.CheckBox4));
            command.Parameters.Add(new SqlParameter("@CheckBox5", obj.CheckBox5));
            command.Parameters.Add(new SqlParameter("@CheckBox6", obj.CheckBox6));
            command.Parameters.Add(new SqlParameter("@Status", obj.Status));
            command.Parameters.Add(new SqlParameter("@Titleseo", obj.Titleseo));
            command.Parameters.Add(new SqlParameter("@Meta", obj.Meta));
            command.Parameters.Add(new SqlParameter("@Keyword", obj.Keyword));
            command.Parameters.Add(new SqlParameter("@TangName", obj.TangName));
            command.Parameters.Add(new SqlParameter("@Alt", obj.Alt));

            try
            {
                command.ExecuteNonQuery();
                transaction.Commit();
                flag = true;
            }
            catch
            {
                transaction.Rollback();
                flag = false;
            }
            finally
            {
                connection.Close();
            }
            return flag;
        }

        public bool UPDATE(News obj)
        {
            bool flag;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("S_News_Update", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlTransaction transaction = connection.BeginTransaction();
            command.Transaction = transaction;
            command.Parameters.Add(new SqlParameter("@inid", obj.inid));
            command.Parameters.Add(new SqlParameter("@icid", obj.icid));
            command.Parameters.Add(new SqlParameter("@Title", obj.Title));
            command.Parameters.Add(new SqlParameter("@Brief", obj.Brief));
            command.Parameters.Add(new SqlParameter("@Contents", obj.Contents));
            command.Parameters.Add(new SqlParameter("@Keywords", obj.Keywords));
            command.Parameters.Add(new SqlParameter("@search", obj.search));
            command.Parameters.Add(new SqlParameter("@Images", obj.Images));
            command.Parameters.Add(new SqlParameter("@ImagesSmall", obj.ImagesSmall));
            command.Parameters.Add(new SqlParameter("@Equals", obj.Equals));
            command.Parameters.Add(new SqlParameter("@Chekdata", obj.Chekdata));
            //command.Parameters.Add(new SqlParameter("@Create_Date", obj.Create_Date));
            //command.Parameters.Add(new SqlParameter("@Modified_Date", obj.Modified_Date));
            command.Parameters.Add(new SqlParameter("@Views", obj.Views));
            command.Parameters.Add(new SqlParameter("@Tags", obj.Tags));
            command.Parameters.Add(new SqlParameter("@lang", obj.lang));
            command.Parameters.Add(new SqlParameter("@New", obj.New));
            command.Parameters.Add(new SqlParameter("@CheckBox1", obj.CheckBox1));
            command.Parameters.Add(new SqlParameter("@CheckBox2", obj.CheckBox2));
            command.Parameters.Add(new SqlParameter("@CheckBox3", obj.CheckBox3));
            command.Parameters.Add(new SqlParameter("@CheckBox4", obj.CheckBox4));
            command.Parameters.Add(new SqlParameter("@CheckBox5", obj.CheckBox5));
            command.Parameters.Add(new SqlParameter("@CheckBox6", obj.CheckBox6));
            command.Parameters.Add(new SqlParameter("@Status", obj.Status));
            command.Parameters.Add(new SqlParameter("@Titleseo", obj.Titleseo));
            command.Parameters.Add(new SqlParameter("@Meta", obj.Meta));
            command.Parameters.Add(new SqlParameter("@Keyword", obj.Keyword));
            command.Parameters.Add(new SqlParameter("@TangName", obj.TangName));
            command.Parameters.Add(new SqlParameter("@Alt", obj.Alt));
            try
            {
                command.ExecuteNonQuery();
                transaction.Commit();
                flag = true;
            }
            catch
            {
                transaction.Rollback();
                flag = false;
            }
            finally
            {
                connection.Close();
            }
            return flag;
        }

        public List<News> MORE_ICID(string icid)
        {
            List<News> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("SELECT * FROM [News] WHERE  icid in (" + icid + ")", connection)
            {
                CommandType = CommandType.Text
            };
            try
            {
                list = Database.Bind_List_Reader<News>(command);
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

        public List<News> Name_StoredProcedure(string Name_StoredProcedure)
        {
            List<News> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand(Name_StoredProcedure, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            try
            {
                list = Database.Bind_List_Reader<News>(command);
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

        public List<News> Name_Text(string Name_Text)
        {
            List<News> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand(Name_Text, connection)
            {
                CommandType = CommandType.Text
            };
            try
            {
                list = Database.Bind_List_Reader<News>(command);
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

        public void News_CATE_DELETE_ICID(string icid)
        {
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("DELETE FROM News WHERE icid in (" + icid + ")", connection)
            {
                CommandType = CommandType.Text
            };
            SqlTransaction transaction = connection.BeginTransaction();
            command.Transaction = transaction;
            try
            {
                command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
            finally
            {
                connection.Close();
            }
        }

        public void News_DELETE(string _Value_List_Delete)
        {
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("Delete From [News] where [inid] IN(" + _Value_List_Delete + ")", connection)
            {
                CommandType = CommandType.Text
            };
            SqlTransaction transaction = connection.BeginTransaction();
            command.Transaction = transaction;
            try
            {
                command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
            finally
            {
                connection.Close();
            }
        }

        public List<News> News_GETBYTOP(string Top, string Where, string Order)
        {
            List<News> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("S_News_GetByTop", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@Top", Top));
            command.Parameters.Add(new SqlParameter("@Where", Where));
            command.Parameters.Add(new SqlParameter("@Order", Order));
            try
            {
                list = Database.Bind_List_Reader<News>(command);
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

        public List<News> NEWS_INDEX(string lang, string Status)
        {
            List<News> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("S_News_News_Index", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@lang", lang));
            command.Parameters.Add(new SqlParameter("@Status", Status));
            try
            {
                list = Database.Bind_List_Reader<News>(command);
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

        public List<Category_News> NEWS_OTHERFIRST(string nid, int top, string lang, string icid)
        {
            List<Category_News> list;
            string cmdText = "select top " + top.ToString() + "  " + Sql_News() + " from News where Create_Date > (select Create_Date from News where inid=@nid) and lang=@lang and icid=@icid    order by Create_Date desc";
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand(cmdText, connection)
            {
                CommandType = CommandType.Text
            };
            command.Parameters.Add(new SqlParameter("@nid", nid));
            command.Parameters.Add(new SqlParameter("@lang", lang));
            command.Parameters.Add(new SqlParameter("@icid", icid));
            try
            {
                list = Database.Bind_List_Reader<Category_News>(command);
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

        public List<Category_News> NEWS_OTHERLAST(string nid, int top, string lang, string icid)
        {
            List<Category_News> list;
            string cmdText = "select  top " + top.ToString() + " " + Sql_News() + " from News where Create_Date < (select Create_Date from News where inid=@nid) and lang=@lang and icid=@icid    order by Create_Date desc";
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand(cmdText, connection)
            {
                CommandType = CommandType.Text
            };
            command.Parameters.Add(new SqlParameter("@nid", nid));
            command.Parameters.Add(new SqlParameter("@lang", lang));
            command.Parameters.Add(new SqlParameter("@icid", icid));
            try
            {
                list = Database.Bind_List_Reader<Category_News>(command);
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

        public List<News> SEARCH(string keyword, string lang)
        {
            List<News> list;
            string cmdText = "select * from News  where (Title like '%'+ @keyword1 +'%'  or Brief like '%'+ @keyword2 +'%' or Keywords like '%'+ @keyword3 +'%' or Contents like '%'+ @keyword4 +'%'  or search like '%'+ @keyword5+'%') and lang= @lang and Status=1    order by Create_Date desc";
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand(cmdText, connection)
            {
                CommandType = CommandType.Text
            };
            command.Parameters.Add(new SqlParameter("@keyword1", keyword));
            command.Parameters.Add(new SqlParameter("@keyword2", keyword));
            command.Parameters.Add(new SqlParameter("@keyword3", keyword));
            command.Parameters.Add(new SqlParameter("@keyword4", keyword));
            command.Parameters.Add(new SqlParameter("@keyword5", keyword));
            command.Parameters.Add(new SqlParameter("@lang", lang));
            try
            {
                list = Database.Bind_List_Reader<News>(command);
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


        //"+Sql_News()+"  
        public List<Category_News> Name_Text_Rg(string Text)
        {
            List<Category_News> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand(Text, connection)
            {
                CommandType = CommandType.Text
            };
            try
            {
                list = Database.Bind_List_Reader<Category_News>(command);
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
        #region Product_Count
        public List<News_Count> News_Count(string Name_Text)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_Text, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<News_Count>(comm);
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

        public List<News> Text(string Text)
        {
            List<News> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand(Text, connection)
            {
                CommandType = CommandType.Text
            };
            try
            {
                list = Database.Bind_List_Reader<News>(command);
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


        public List<News> Update_datetime(string inid, DateTime Create_Date, DateTime Modified_Date)
        {
            List<News> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("update News set Create_Date=@Create_Date,Modified_Date=@Modified_Date where inid= @inid", connection)
            {
                CommandType = CommandType.Text
            };
            command.Parameters.Add(new SqlParameter("@Create_Date", Create_Date));
            command.Parameters.Add(new SqlParameter("@Modified_Date", Modified_Date));
            command.Parameters.Add(new SqlParameter("@inid", inid));
            try
            {
                list = Database.Bind_List_Reader<News>(command);
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

        public List<News> UPDATE_DATETIME(string inid, string Modified_Date)
        {
            List<News> list;
            string cmdText = "update News set Modified_Date= @Modified_Date where inid= @inid";
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand(cmdText, connection)
            {
                CommandType = CommandType.Text
            };
            command.Parameters.Add(new SqlParameter("@Modified_Date", Modified_Date));
            command.Parameters.Add(new SqlParameter("@inid", inid));
            try
            {
                list = Database.Bind_List_Reader<News>(command);
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

        public List<News> UPDATE_News(string news, string inid)
        {
            List<News> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("update News set new= " + news + " where inid= @inid", connection)
            {
                CommandType = CommandType.Text
            };
            command.Parameters.Add(new SqlParameter("@inid", inid));
            try
            {
                list = Database.Bind_List_Reader<News>(command);
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

        public List<News> UPDATE_STATUS(string Status, string inid)
        {
            List<News> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("update News set Status= @Status where inid= @inid", connection)
            {
                CommandType = CommandType.Text
            };
            command.Parameters.Add(new SqlParameter("@Status", Status));
            command.Parameters.Add(new SqlParameter("@inid", inid));
            try
            {
                list = Database.Bind_List_Reader<News>(command);
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

        public List<News> UPDATE_VIEW_TIME(string inid)
        {
            List<News> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("update News set Views=Views + 1 where inid=@inid", connection)
            {
                CommandType = CommandType.Text
            };
            command.Parameters.Add(new SqlParameter("@inid", inid));
            try
            {
                list = Database.Bind_List_Reader<News>(command);
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

        public bool UPDATEIMG(string inid)
        {
            bool flag;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("S_News_UpdateImg", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlTransaction transaction = connection.BeginTransaction();
            command.Transaction = transaction;
            command.Parameters.Add(new SqlParameter("@inid", inid));
            try
            {
                command.ExecuteNonQuery();
                transaction.Commit();
                flag = true;
            }
            catch
            {
                transaction.Rollback();
                flag = false;
            }
            finally
            {
                connection.Close();
            }
            return flag;
        }

        public bool UPDATEIMG1(string inid)
        {
            bool flag;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("update News set Images='',ImagesSmall='' where inid= @inid", connection)
            {
                CommandType = CommandType.Text
            };
            SqlTransaction transaction = connection.BeginTransaction();
            command.Transaction = transaction;
            command.Parameters.Add(new SqlParameter("@inid", inid));
            try
            {
                command.ExecuteNonQuery();
                transaction.Commit();
                flag = true;
            }
            catch
            {
                transaction.Rollback();
                flag = false;
            }
            finally
            {
                connection.Close();
            }
            return flag;
        }
        #region News_All

        public List<Category_News> News_All(string lang, string Status, int PageIndex, ref int TotalRecords, int Tongpage)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("News_All", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters(comm);
            comm.Parameters["@lang"].Value = lang;
            comm.Parameters["@Status"].Value = Status;
            comm.Parameters["@PageIndex"].Value = PageIndex;
            comm.Parameters["@TotalRecord"].Direction = ParameterDirection.Output;
            comm.Parameters["@Tongpage"].Value = Tongpage;
            try
            {
                return Database.Bind_List_Reader_pages<Category_News>(comm, ref TotalRecords);
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
        public List<Category_News> CATEGORY_PHANTRANG(string icid, string lang, string Status, int PageIndex, ref int TotalRecords, int Tongpage)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("Category_News_List", conn);
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
                return Database.Bind_List_Reader_pages<Category_News>(comm, ref TotalRecords);
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
        public List<News> SearchNews(string keyword, string lang)
        {
            string sql = SearchApproximate.ApproximateSearch(keyword, lang);
            List<News> list = new List<News>();
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<News>(comm);
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

        public class SearchApproximate
        {
            // Phương thức trả về câu lệnh SQL dùng truy vấn dữ liệu
            public static string ApproximateSearch(string keyWord, string lang)
            {
                string sql = "SELECT * FROM News WHERE Title LIKE N'" + Exec(keyWord) + "' OR search LIKE N'" + Exec((keyWord)) + "' and lang='" + lang + "' and Status=1  order by Create_Date desc";

                // string sql = "SELECT * FROM News WHERE Title LIKE N'" + Exec(keyWord) + "' OR Brief LIKE N'" + Exec(ConvertVN.Convert(keyWord)) + "' OR Contents LIKE N'" + Exec(ConvertVN.Convert(keyWord)) + "' OR search LIKE N'" + Exec(ConvertVN.Convert(keyWord)) + "' and lang='" + lang + "' and Status=1   order by Create_Date desc";
                return sql;
            }
            // Phương thức chuyển đổi một chuỗi ký tự: Nếu chuỗi đó có ký tự " " sẽ thay thế bằng "%"
            public static string Exec(string keyWord)
            {
                string[] arrWord = keyWord.Split(' ');
                StringBuilder str = new StringBuilder("%");
                for (int i = 0; i < arrWord.Length; i++)
                {
                    str.Append(arrWord[i] + "%");
                }
                return str.ToString();
            }
        }

        public class ConvertVN
        {
            // Phương thức Convert một chuỗi ký tự Có dấu sang Không dấu
            public static string Convert(string chucodau)
            {
                const string FindText = "áàảãạâấầẩẫậăắằẳẵặđéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ";
                const string ReplText = "aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAADEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYY";
                int index = -1;
                char[] arrChar = FindText.ToCharArray();
                while ((index = chucodau.IndexOfAny(arrChar)) != -1)
                {
                    int index2 = FindText.IndexOf(chucodau[index]);
                    chucodau = chucodau.Replace(chucodau[index], ReplText[index2]);
                }
                return chucodau;
            }
        }
    }
}
