using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Entity;
using System.Data.SqlClient;
using System.Text;

namespace Framwork
{
    public class FCarts
    {
        #region[GetById]
        public List<Carts> GetById(string Id)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Carts_GetById", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add(new SqlParameter("@ID", Id));
            try
            {
                return Database.Bind_List_Reader<Carts>(comm);
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

        #region[GetByAll]
        public List<Carts> GetByAll(string Lang)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Carts_GetByAll", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            try
            {
                return Database.Bind_List_Reader<Carts>(comm);
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

        #region Insert
        public static int Insert(string Name, string Address, string Phone, string Email, string Contents, string Money, string lang, string Status, string Phuongthucthanhtoan, string Hinhthucvanchuyen, string StatusGiaoDich, string IDThanhVien)
        {
            using (SqlCommand dbCmd = new SqlCommand("insert Carts values(@Name,@Address,@Phone,@Email,@Contents,getdate(),@Money,@lang,@Status,@Phuongthucthanhtoan,@Hinhthucvanchuyen,@StatusGiaoDich,@IDThanhVien)", Database.Connection()))
            {
                dbCmd.CommandType = CommandType.Text;
                dbCmd.Parameters.Add(new SqlParameter("@Name", Name));
                dbCmd.Parameters.Add(new SqlParameter("@Address", Address));
                dbCmd.Parameters.Add(new SqlParameter("@Phone", Phone));
                dbCmd.Parameters.Add(new SqlParameter("@Email", Email));
                dbCmd.Parameters.Add(new SqlParameter("@Contents", Contents));
                dbCmd.Parameters.Add(new SqlParameter("@Money", Money));
                dbCmd.Parameters.Add(new SqlParameter("@lang", lang));
                dbCmd.Parameters.Add(new SqlParameter("@Status", Status));
                dbCmd.Parameters.Add(new SqlParameter("@Phuongthucthanhtoan", Phuongthucthanhtoan));
                dbCmd.Parameters.Add(new SqlParameter("@Hinhthucvanchuyen", Hinhthucvanchuyen));
                dbCmd.Parameters.Add(new SqlParameter("@StatusGiaoDich", StatusGiaoDich));
                dbCmd.Parameters.Add(new SqlParameter("@IDThanhVien", IDThanhVien));
                dbCmd.ExecuteNonQuery();
            }
            System.Web.HttpContext.Current.Cache.Remove("Carts");
            using (SqlCommand dbCmd = new SqlCommand("select isnull(max(ID),0) as maxid from Carts", Database.Connection()))
                return Convert.ToInt32(Database.GetData(dbCmd).Rows[0]["maxid"]);
        }
        #endregion

        #region[Update]
        public bool Update(Carts obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Carts_Update", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@ID", obj.ID));
            comm.Parameters.Add(new SqlParameter("@Name", obj.Name));
            comm.Parameters.Add(new SqlParameter("@Address", obj.Address));
            comm.Parameters.Add(new SqlParameter("@Phone", obj.Phone));
            comm.Parameters.Add(new SqlParameter("@Email", obj.Email));
            comm.Parameters.Add(new SqlParameter("@Contents", obj.Contents));
            comm.Parameters.Add(new SqlParameter("@Create_Date", obj.Create_Date));
            comm.Parameters.Add(new SqlParameter("@Money", obj.Money));
            comm.Parameters.Add(new SqlParameter("@lang", obj.lang));
            comm.Parameters.Add(new SqlParameter("@Status", obj.Status));

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

        #region[Delete]
        public void Delete(string Id)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Carts_Delete", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@ID", Id));
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

        #region UpdateStatus
        public bool UpdateStatus(string id, string status)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Carts_UpdateStatus", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add("@status", status);
            comm.Parameters.Add("@id", id);

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

        #region p_cartlist_count
        public List<Carts> p_cartlist_count(string status, string keyword)
        {
            List<Carts> list = new List<Carts>();
            string sql = "select * from Carts ";
            if (!status.Equals("-1"))
            {
                sql = sql + "  where Status=@Status ";
            }
            if (keyword.Length > 0)
            {
                sql = sql + " and  dbo.fuConvertToUnsign(Name) LIKE N'" + SearchApproximate.Exec(ConvertVN.Convert(keyword)) + "' OR Address LIKE N'" + SearchApproximate.Exec(ConvertVN.Convert(keyword)) + "' OR Phone LIKE N'" + SearchApproximate.Exec(ConvertVN.Convert(keyword)) + "' OR Email LIKE N'" + SearchApproximate.Exec(ConvertVN.Convert(keyword)) + "' OR Money LIKE N'" + SearchApproximate.Exec(ConvertVN.Convert(keyword)) + "'";
            }
            sql = sql + " order by Create_Date desc";
            SqlConnection conn = Database.Connection();
            SqlCommand dbCmd = new SqlCommand(sql, conn);
            dbCmd.CommandType = CommandType.Text;
            if (!status.Equals("-1"))
            {
                dbCmd.Parameters.AddWithValue("@Status", status);
            }
            try
            {
                return Database.Bind_List_Reader<Carts>(dbCmd);
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

        public List<Carts> Name_Text(string Text)
        {
            List<Carts> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand(Text, connection)
            {
                CommandType = CommandType.Text
            };
            try
            {
                list = Database.Bind_List_Reader<Carts>(command);
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
        public class SearchApproximate
        {
            // Phương thức trả về câu lệnh SQL dùng truy vấn dữ liệu
            public static string ApproximateSearch(string keyWord, string lang)
            {
                string sql = "SELECT * FROM products WHERE Name LIKE N'" + Exec(keyWord) + "' OR Brief LIKE N'" + Exec(ConvertVN.Convert(keyWord)) + "' OR Code LIKE N'" + Exec(ConvertVN.Convert(keyWord)) + "' and lang='" + lang + "' and Status=1   order by Create_Date desc";
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