using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.SqlClient;
using System.Data;

namespace Framework
{
    public class FNfooter
    {
        public List<Entity.Nfooter> CATEGORY(string icid, string lang, string Status)
        {
            List<Entity.Nfooter> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("SELECT * FROM [Nfooter] WHERE icid IN(" + icid + ") AND lang= @lang  AND Status= @Status  order by Create_Date desc", connection)
            {
                CommandType = CommandType.Text
            };
            command.Parameters.Add(new SqlParameter("@lang", lang));
            command.Parameters.Add(new SqlParameter("@Status", Status));
            command.Parameters.Add(new SqlParameter("@icid", icid));
            try
            {
                list = Database.Bind_List_Reader<Nfooter>(command);
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

        public List<Entity.Nfooter> CATEGORYADMIN(string orderby, string searchkeyword, string[] searchfields, string icid, string lang, string Status)
        {
            List<Entity.Nfooter> list;
            string str = "";
            if (orderby.Length < 1)
            {
                str = "order by Create_Date desc";
            }
            else
            {
                str = "order by " + orderby;
            }
            string cmdText = "select * from Nfooter  where icid in (" + icid + ")  and lang='" + lang + "'";
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
                list = Database.Bind_List_Reader<Nfooter>(command);
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

        public List<Entity.Nfooter> Chekdata(string inid, string Chekdata, DateTime Create_Date, DateTime Modified_Date)
        {
            List<Entity.Nfooter> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("update Nfooter set Chekdata=@Chekdata,Create_Date=@Create_Date,Modified_Date=@Modified_Date where inid= @inid", connection)
            {
                CommandType = CommandType.Text
            };
            command.Parameters.Add(new SqlParameter("@Chekdata", Chekdata));
            command.Parameters.Add(new SqlParameter("@Create_Date", Create_Date));
            command.Parameters.Add(new SqlParameter("@Modified_Date", Modified_Date));
            command.Parameters.Add(new SqlParameter("@inid", inid));
            try
            {
                list = Database.Bind_List_Reader<Nfooter>(command);
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

        public List<Entity.Nfooter> DETAIL_Nfooter_RELATED(string inid)
        {
            List<Entity.Nfooter> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("select * from Nfooter where inid in(" + inid + ")", connection)
            {
                CommandType = CommandType.Text
            };
            command.Parameters.Add(new SqlParameter("@inid", inid));
            try
            {
                list = Database.Bind_List_Reader<Nfooter>(command);
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

        public List<Entity.Nfooter> Detail_Top(int top, string icid, string lang, string Status)
        {
            List<Entity.Nfooter> list;
            string cmdText = "SELECT top (" + top.ToString() + ") * FROM [Nfooter] WHERE icid=@icid AND lang= @lang  AND Status= @Status  order by Create_Date desc";
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
                list = Database.Bind_List_Reader<Nfooter>(command);
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

        public List<Entity.Nfooter> GET_DETAIL_BYICID(string imcid)
        {
            List<Entity.Nfooter> list;
            string cmdText = "SELECT * FROM [Nfooter] WHERE icid IN (@imcid)";
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand(cmdText, connection)
            {
                CommandType = CommandType.Text
            };
            command.Parameters.Add(new SqlParameter("@imcid", imcid));
            try
            {
                list = Database.Bind_List_Reader<Nfooter>(command);
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

        public List<Entity.Nfooter> GETBYALL(string Lang)
        {
            List<Entity.Nfooter> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("S_Nfooter_GetByAll", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@Lang", Lang));
            try
            {
                list = Database.Bind_List_Reader<Nfooter>(command);
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

        public List<Entity.Nfooter> GETBYID(string inid)
        {
            List<Entity.Nfooter> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("S_Nfooter_GetById", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@inid", inid));
            try
            {
                list = Database.Bind_List_Reader<Nfooter>(command);
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

        public List<Entity.Nfooter> GETDETAIL_BYID(string inid)
        {
            List<Entity.Nfooter> list;
            string cmdText = "SELECT * FROM [Nfooter] WHERE inid =@inid";
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand(cmdText, connection)
            {
                CommandType = CommandType.Text
            };
            command.Parameters.Add(new SqlParameter("@inid", inid));
            try
            {
                list = Database.Bind_List_Reader<Nfooter>(command);
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

        public bool INSERT(Nfooter obj)
        {
            bool flag;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("S_Nfooter_Insert", connection)
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
            command.Parameters.Add(new SqlParameter("@Status", obj.Status));
            command.Parameters.Add(new SqlParameter("@Titleseo", obj.Titleseo));
            command.Parameters.Add(new SqlParameter("@Meta", obj.Meta));
            command.Parameters.Add(new SqlParameter("@Keyword", obj.Keyword));
            command.Parameters.Add(new SqlParameter("@TangName", obj.TangName));
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

        public List<Entity.Nfooter> MORE_ICID(string icid)
        {
            List<Entity.Nfooter> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("SELECT * FROM [Nfooter] WHERE  icid in (" + icid + ")", connection)
            {
                CommandType = CommandType.Text
            };
            try
            {
                list = Database.Bind_List_Reader<Nfooter>(command);
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

        public List<Entity.Nfooter> Name_StoredProcedure(string Name_StoredProcedure)
        {
            List<Entity.Nfooter> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand(Name_StoredProcedure, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            try
            {
                list = Database.Bind_List_Reader<Nfooter>(command);
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

        public List<Entity.Nfooter> Name_Text(string Name_Text)
        {
            List<Entity.Nfooter> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand(Name_Text, connection)
            {
                CommandType = CommandType.Text
            };
            try
            {
                list = Database.Bind_List_Reader<Nfooter>(command);
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

        public void Nfooter_CATE_DELETE_ICID(string icid)
        {
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("DELETE FROM Nfooter WHERE icid in (" + icid + ")", connection)
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

        public void Nfooter_DELETE(string _Value_List_Delete)
        {
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("Delete From [Nfooter] where [inid] IN(" + _Value_List_Delete + ")", connection)
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

        public List<Entity.Nfooter> Nfooter_GETBYTOP(string Top, string Where, string Order)
        {
            List<Entity.Nfooter> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("S_Nfooter_GetByTop", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@Top", Top));
            command.Parameters.Add(new SqlParameter("@Where", Where));
            command.Parameters.Add(new SqlParameter("@Order", Order));
            try
            {
                list = Database.Bind_List_Reader<Nfooter>(command);
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

        public List<Entity.Nfooter> Nfooter_INDEX(string lang, string Status)
        {
            List<Entity.Nfooter> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("S_Nfooter_Nfooter_Index", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@lang", lang));
            command.Parameters.Add(new SqlParameter("@Status", Status));
            try
            {
                list = Database.Bind_List_Reader<Nfooter>(command);
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

        public List<Entity.Nfooter> Nfooter_OTHERFIRST(string nid, int top, string lang, string icid)
        {
            List<Entity.Nfooter> list;
            string cmdText = "select top " + top.ToString() + "  * from Nfooter where Create_Date > (select Create_Date from Nfooter where inid=@nid) and lang=@lang and icid=@icid    order by Create_Date desc";
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
                list = Database.Bind_List_Reader<Nfooter>(command);
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

        public List<Entity.Nfooter> Nfooter_OTHERLAST(string nid, int top, string lang, string icid)
        {
            List<Entity.Nfooter> list;
            string cmdText = "select  top " + top.ToString() + " * from Nfooter where Create_Date < (select Create_Date from Nfooter where inid=@nid) and lang=@lang and icid=@icid    order by Create_Date desc";
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
                list = Database.Bind_List_Reader<Nfooter>(command);
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

        public List<Entity.Nfooter> SEARCH(string keyword, string lang)
        {
            List<Entity.Nfooter> list;
            string cmdText = "select * from Nfooter  where (Title like '%'+ @keyword1 +'%'  or Brief like '%'+ @keyword2 +'%' or Keywords like '%'+ @keyword3 +'%' or Contents like '%'+ @keyword4 +'%'  or search like '%'+ @keyword5+'%') and lang= @lang and Status=1    order by Create_Date desc";
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
                list = Database.Bind_List_Reader<Nfooter>(command);
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

        public List<Entity.Nfooter> Text(string Text)
        {
            List<Entity.Nfooter> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand(Text, connection)
            {
                CommandType = CommandType.Text
            };
            try
            {
                list = Database.Bind_List_Reader<Nfooter>(command);
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

        public bool UPDATE(Nfooter obj)
        {
            bool flag;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("S_Nfooter_Update", connection)
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
            command.Parameters.Add(new SqlParameter("@Create_Date", obj.Create_Date));
            command.Parameters.Add(new SqlParameter("@Modified_Date", obj.Modified_Date));
            command.Parameters.Add(new SqlParameter("@Views", obj.Views));
            command.Parameters.Add(new SqlParameter("@Tags", obj.Tags));
            command.Parameters.Add(new SqlParameter("@lang", obj.lang));
            command.Parameters.Add(new SqlParameter("@New", obj.New));
            command.Parameters.Add(new SqlParameter("@Status", obj.Status));
            command.Parameters.Add(new SqlParameter("@Titleseo", obj.Titleseo));
            command.Parameters.Add(new SqlParameter("@Meta", obj.Meta));
            command.Parameters.Add(new SqlParameter("@Keyword", obj.Keyword));
            command.Parameters.Add(new SqlParameter("@TangName", obj.TangName));
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

        public List<Entity.Nfooter> Update_datetime(string inid, DateTime Create_Date, DateTime Modified_Date)
        {
            List<Entity.Nfooter> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("update Nfooter set Create_Date=@Create_Date,Modified_Date=@Modified_Date where inid= @inid", connection)
            {
                CommandType = CommandType.Text
            };
            command.Parameters.Add(new SqlParameter("@Create_Date", Create_Date));
            command.Parameters.Add(new SqlParameter("@Modified_Date", Modified_Date));
            command.Parameters.Add(new SqlParameter("@inid", inid));
            try
            {
                list = Database.Bind_List_Reader<Nfooter>(command);
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

        public List<Entity.Nfooter> UPDATE_DATETIME(string inid, string Modified_Date)
        {
            List<Entity.Nfooter> list;
            string cmdText = "update Nfooter set Modified_Date= @Modified_Date where inid= @inid";
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand(cmdText, connection)
            {
                CommandType = CommandType.Text
            };
            command.Parameters.Add(new SqlParameter("@Modified_Date", Modified_Date));
            command.Parameters.Add(new SqlParameter("@inid", inid));
            try
            {
                list = Database.Bind_List_Reader<Nfooter>(command);
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

        public List<Entity.Nfooter> UPDATE_Nfooter(string Nfooter, string inid)
        {
            List<Entity.Nfooter> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("update Nfooter set new= " + Nfooter + " where inid= @inid", connection)
            {
                CommandType = CommandType.Text
            };
            command.Parameters.Add(new SqlParameter("@inid", inid));
            try
            {
                list = Database.Bind_List_Reader<Nfooter>(command);
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

        public List<Entity.Nfooter> UPDATE_STATUS(string Status, string inid)
        {
            List<Entity.Nfooter> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("update Nfooter set Status= @Status where inid= @inid", connection)
            {
                CommandType = CommandType.Text
            };
            command.Parameters.Add(new SqlParameter("@Status", Status));
            command.Parameters.Add(new SqlParameter("@inid", inid));
            try
            {
                list = Database.Bind_List_Reader<Nfooter>(command);
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

        public List<Entity.Nfooter> UPDATE_VIEW_TIME(string inid)
        {
            List<Entity.Nfooter> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand("update Nfooter set Views=Views + 1 where inid=@inid", connection)
            {
                CommandType = CommandType.Text
            };
            command.Parameters.Add(new SqlParameter("@inid", inid));
            try
            {
                list = Database.Bind_List_Reader<Nfooter>(command);
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
            SqlCommand command = new SqlCommand("S_Nfooter_UpdateImg", connection)
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
            SqlCommand command = new SqlCommand("update Nfooter set Images='',ImagesSmall='' where inid= @inid", connection)
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

        public List<Entity.Nfooter> SearchNfooter(string keyword, string lang)
        {
            string sql = SearchApproximate.ApproximateSearch(keyword, lang);
            List<Entity.Nfooter> list = new List<Entity.Nfooter>();
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<Nfooter>(comm);
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
                string sql = "SELECT * FROM Nfooter WHERE Title LIKE N'" + Exec(keyWord) + "' OR Brief LIKE N'" + Exec(ConvertVN.Convert(keyWord)) + "' OR Contents LIKE N'" + Exec(ConvertVN.Convert(keyWord)) + "' OR search LIKE N'" + Exec(ConvertVN.Convert(keyWord)) + "' and lang='" + lang + "' and Status=1   order by Create_Date desc";
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
