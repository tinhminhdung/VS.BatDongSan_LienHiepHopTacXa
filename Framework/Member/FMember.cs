using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;

namespace Framework
{
    public class FMember
    {
        #region BULD PASSOWRD
        static string BuildPassword(string input)
        {
            //MD5 md5Hasher = MD5.Create();
            //byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            //StringBuilder sBuilder = new StringBuilder();
            //for (int i = 0; i < data.Length; i++)
            //{
            //    sBuilder.Append(data[i].ToString("x2"));
            //} return sBuilder.ToString();
            return input.ToString();
        }
        #endregion


        #region Admin
        public List<Member> CATEGORY_PHANTRANG1(string IDThanhVien, string keyword, string Status)
        {
            string sql1 = "";
            if (!Status.Equals("-1"))
            {
                sql1 += " and TrangThai=" + Status + " ";
            }
           
            sql1 += IDThanhVien;


            string sql = @"SELECT * FROM  Members  where (HoVaTen like N'%" + keyword + "%'  or DiaChi like N'%" + keyword + "%' or DienThoai like '%" + keyword + "%' or Email like '%" + keyword + "%')   " + sql1 + " ";
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<Member>(comm);
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
        public List<Member> CATEGORY_PHANTRANG2(string IDThanhVien, string keyword, string Status, int PageIndex, int Tongpage)
        {
            int StartRecord = PageIndex * Tongpage;
            int EndRecord = StartRecord + Tongpage + 1;
            string sql1 = "";
            if (!Status.Equals("-1"))
            {
                sql1 += " and TrangThai=" + Status + " ";
            }

            sql1 += IDThanhVien;

            string sql = @"SELECT *  FROM  (SELECT ROW_NUMBER() OVER (ORDER BY ID DESC) AS rowindex ,* 
                                FROM  Members
        		                 where (HoVaTen like N'%" + keyword + "%'  or DiaChi like N'%" + keyword + "%' or DienThoai like '%" + keyword + "%' or Email like '%" + keyword + "%')  " + sql1 + " ";
            sql += ") AS A WHERE  ( A.rowindex >  " + StartRecord.ToString() + " AND A.rowindex < " + EndRecord + ")";
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<Member>(comm);
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


        #region DETAIL DETAIL_ID
        public List<Member> DETAIL_ID(string ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from Members where ID=@ID", conn);
            comm.CommandType = CommandType.Text;

            comm.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                return Database.Bind_List_Reader<Member>(comm);
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

        //#region DETAIL VEMAIL
        //public List<Member> DETAIL_VEMAIL(string vuserun, string vemail)
        //{
        //    SqlConnection conn = Database.Connection();
        //    SqlCommand comm = new SqlCommand("S_Member_vemail", conn);
        //    comm.CommandType = CommandType.StoredProcedure;

        //    comm.Parameters.Add(new SqlParameter("@vuserun", vuserun));
        //    comm.Parameters.Add(new SqlParameter("@vemail", vemail));
        //    try
        //    {
        //        return Database.Bind_List_Reader<Member>(comm);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
        //#endregion

        #region DETAIL VALIDATEKEY
        public List<Member> DETAIL_VALIDATEKEY(string Key)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from Members where Key=@Key", conn);
            comm.CommandType = CommandType.Text;

            comm.Parameters.Add(new SqlParameter("@Key", Key));
            try
            {
                return Database.Bind_List_Reader<Member>(comm);
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

        //#region DETAIL VUSERUN VUSERPWD
        //public List<Member> DETAIL_VUSERUN_VUSERPWD(string vuserun, string vuserpwd)
        //{
        //    vuserpwd = BuildPassword(vuserpwd);
        //    SqlConnection conn = Database.Connection();
        //    SqlCommand comm = new SqlCommand("S_Member_vuserun_vuserpwd", conn);
        //    comm.CommandType = CommandType.StoredProcedure;

        //    comm.Parameters.Add(new SqlParameter("@vuserun", vuserun));
        //    comm.Parameters.Add(new SqlParameter("@vuserpwd", vuserpwd));
        //    try
        //    {
        //        return Database.Bind_List_Reader<Member>(comm);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
        //#endregion

        //#region UPDATE VUSERUN PASSWORD
        //public bool UPDATE_VUSERUN_PASSWORD(string vuserun, string newpassword)
        //{
        //    SqlConnection conn = Database.Connection();
        //    SqlCommand comm = new SqlCommand("Update_vuserun_password", conn);
        //    comm.CommandType = CommandType.StoredProcedure;

        //    SqlTransaction tran = conn.BeginTransaction();
        //    comm.Transaction = tran;
        //    comm.Parameters.Add(new SqlParameter("@vuserun", vuserun));
        //    comm.Parameters.Add(new SqlParameter("@vuserpwd", newpassword));
        //    try
        //    {
        //        comm.ExecuteNonQuery();
        //        tran.Commit();
        //        return true;
        //    }
        //    catch
        //    {
        //        tran.Rollback();
        //        return false;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
        //#endregion

        #region UPDATE VUSERUN PASSWORD
        public bool DoiMatKhau(string ID)
        {
            string key = DateTime.Now.Ticks.ToString();
            key = key.Substring(key.Length - 8, 7);
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update Members set Key=" + key + "  where ID=" + ID + "", conn);
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

        # region UPDATE DATETIME
        public List<Member> Update_validatekey_byemail(string Email, string key)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update Members set key=@key where Email=@Email", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@key", key));
            comm.Parameters.Add(new SqlParameter("@Email", Email));
            try
            {
                return Database.Bind_List_Reader<Member>(comm);
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

        //#region DETAIL VUSERUN VUSERPWD STATUS
        //public List<Member> DETAIL_VUSERUN_STATUS(string vuserun, string vuserpwd, string istatus)
        //{
        //    SqlConnection conn = Database.Connection();
        //    SqlCommand comm = new SqlCommand("S_Member_vuserun_vuserpwd_istatus", conn);
        //    comm.CommandType = CommandType.StoredProcedure;
        //    comm.Parameters.Add(new SqlParameter("@vuserun", vuserun));
        //    comm.Parameters.Add(new SqlParameter("@vuserpwd", vuserpwd));
        //    comm.Parameters.Add(new SqlParameter("@istatus", istatus));
        //    try
        //    {
        //        return Database.Bind_List_Reader<Member>(comm);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
        //#endregion

        #region GET BY ID
        public List<Member> GETBYID(string ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from Members where ID=@ID", conn);
            comm.CommandType = CommandType.Text;

            comm.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                return Database.Bind_List_Reader<Member>(comm);
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
        public List<Member> GETBYALL()
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from Members", conn);
            comm.CommandType = CommandType.Text;

            try
            {
                return Database.Bind_List_Reader<Member>(comm);
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
        public bool INSERT(Member obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Member_Insert", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@PasWord", obj.PasWord));
            comm.Parameters.Add(new SqlParameter("@HoVaTen", obj.HoVaTen));
            comm.Parameters.Add(new SqlParameter("@GioiTinh", obj.GioiTinh));
            comm.Parameters.Add(new SqlParameter("@NgaySinh", obj.NgaySinh));
            comm.Parameters.Add(new SqlParameter("@DiaChi", obj.DiaChi));
            comm.Parameters.Add(new SqlParameter("@DienThoai", obj.DienThoai));
            comm.Parameters.Add(new SqlParameter("@Email", obj.Email));
            comm.Parameters.Add(new SqlParameter("@AnhDaiDien", obj.AnhDaiDien));
            comm.Parameters.Add(new SqlParameter("@NgayTao", obj.NgayTao));
            comm.Parameters.Add(new SqlParameter("@Key", obj.Key));
            comm.Parameters.Add(new SqlParameter("@TrangThai", obj.TrangThai));
            comm.Parameters.Add(new SqlParameter("@Lang", obj.Lang));
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
        public bool UPDATE(Member obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_Member_Update", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@ID", obj.ID));
            comm.Parameters.Add(new SqlParameter("@PasWord", obj.PasWord));
            comm.Parameters.Add(new SqlParameter("@HoVaTen", obj.HoVaTen));
            comm.Parameters.Add(new SqlParameter("@GioiTinh", obj.GioiTinh));
            comm.Parameters.Add(new SqlParameter("@NgaySinh", obj.NgaySinh));
            comm.Parameters.Add(new SqlParameter("@DiaChi", obj.DiaChi));
            comm.Parameters.Add(new SqlParameter("@DienThoai", obj.DienThoai));
            comm.Parameters.Add(new SqlParameter("@Email", obj.Email));
            comm.Parameters.Add(new SqlParameter("@AnhDaiDien", obj.AnhDaiDien));
            comm.Parameters.Add(new SqlParameter("@NgayTao", obj.NgayTao));
            comm.Parameters.Add(new SqlParameter("@Key", obj.Key));
            comm.Parameters.Add(new SqlParameter("@TrangThai", obj.TrangThai));
            comm.Parameters.Add(new SqlParameter("@Lang", obj.Lang));
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
            SqlCommand comm = new SqlCommand("DELETE FROM [Members] WHERE ID=@ID", conn);
            comm.CommandType = CommandType.Text;
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

        #region UPDATE STATUS
        public bool UPDATE_STATUS(string ID, string TrangThai)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("UPDATE [Members] SET [TrangThai] = @TrangThai WHERE ID = @ID", conn);
            comm.CommandType = CommandType.Text;
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@TrangThai", TrangThai));
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

        #region CATEGORY
        public List<Member> CATEGORY(string TrangThai)
        {
            string sql = @"select * from Members order by NgayTao desc";
            if (!TrangThai.Equals("-1"))
            {
                sql = sql + "where TrangThai=" + TrangThai + "";
            }
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            if (!TrangThai.Equals("-1"))
            {
                comm.Parameters.Add(new SqlParameter("@TrangThai", TrangThai));

            }
            try
            {
                return Database.Bind_List_Reader<Member>(comm);
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
        //#region UPDATE
        //public bool Member_update(Member obj)
        //{
        //    SqlConnection conn = Database.Connection();
        //    SqlCommand comm = new SqlCommand("update Members set vuserun=@vuserun,vfname=@vfname,vlname=@vlname,igender=@igender,dbirthday=@dbirthday,vaddress=@vaddress,vphone=@vphone,vavatartitle=@vavatartitle,vemail=@vemail where iuser_id=@iuser_id", conn);
        //    comm.CommandType = CommandType.Text;
        //    SqlTransaction tran = conn.BeginTransaction();
        //    comm.Transaction = tran;
        //    comm.Parameters.Add(new SqlParameter("@vuserun", obj.vuserun));
        //    comm.Parameters.Add(new SqlParameter("@vfname", obj.vfname));
        //    comm.Parameters.Add(new SqlParameter("@vlname", obj.vlname));
        //    comm.Parameters.Add(new SqlParameter("@igender", obj.igender));
        //    comm.Parameters.Add(new SqlParameter("@dbirthday", obj.dbirthday));
        //    comm.Parameters.Add(new SqlParameter("@vaddress", obj.vaddress));
        //    comm.Parameters.Add(new SqlParameter("@vphone", obj.vphone));
        //    comm.Parameters.Add(new SqlParameter("@vavatartitle", obj.vavatartitle));
        //    comm.Parameters.Add(new SqlParameter("@vemail", obj.vemail));
        //    comm.Parameters.Add(new SqlParameter("@iuser_id", obj.iuser_id));
        //    try
        //    {
        //        comm.ExecuteNonQuery();
        //        tran.Commit();
        //        return true;
        //    }
        //    catch
        //    {
        //        tran.Rollback();
        //        return false;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
        //#endregion

        //#region UPDATE
        //public bool Active_vvalidatekey(string ID, string key)
        //{
        //    SqlConnection conn = Database.Connection();
        //    SqlCommand comm = new SqlCommand("update Members set key=@key where ID=@ID", conn);
        //    comm.CommandType = CommandType.Text;
        //    SqlTransaction tran = conn.BeginTransaction();
        //    comm.Transaction = tran;
        //    comm.Parameters.Add(new SqlParameter("@key", key));
        //    comm.Parameters.Add(new SqlParameter("@ID", ID));
        //    try
        //    {
        //        comm.ExecuteNonQuery();
        //        tran.Commit();
        //        return true;
        //    }
        //    catch
        //    {
        //        tran.Rollback();
        //        return false;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
        //#endregion
        #region CATEGORY ADMIN
        public List<Entity.Member> CATEGORY_ADMIN(string orderby, string searchkeyword, string[] searchfields, string lang, string TrangThai)
        {
            int i;
            string shortbydate = "";
            if (orderby.Length < 1)
            {
                shortbydate = "order by NgayTao desc";
            }
            else
            {
                shortbydate = "order by " + orderby;
            }
            string sql = @"select * from Members where lang=@lang ";
            if (!TrangThai.Equals("-1"))
            {
                sql += " and TrangThai=@TrangThai";
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
            if (!TrangThai.Equals("-1"))
            {
                comm.Parameters.Add(new SqlParameter("@TrangThai", TrangThai));
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
                return Database.Bind_List_Reader<Entity.Member>(comm);
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
        //#region UPDATE
        //public bool Member_update_updatepassword(string vuserun, string newpassword)
        //{
        //    newpassword = BuildPassword(newpassword);
        //    SqlConnection conn = Database.Connection();
        //    SqlCommand comm = new SqlCommand("update Members set vuserpwd=@vuserpwd where vuserun=@vuserun", conn);
        //    comm.CommandType = CommandType.Text;
        //    SqlTransaction tran = conn.BeginTransaction();
        //    comm.Transaction = tran;
        //    comm.Parameters.Add(new SqlParameter("@vuserpwd", newpassword));
        //    comm.Parameters.Add(new SqlParameter("@vuserun", vuserun));
        //    try
        //    {
        //        comm.ExecuteNonQuery();
        //        tran.Commit();
        //        return true;
        //    }
        //    catch
        //    {
        //        tran.Rollback();
        //        return false;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
        //#endregion

        #region UPDATE
        public bool Member_update_updateavatar(Member obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update Members set AnhDaiDien=@AnhDaiDien  where ID=@ID", conn);
            comm.CommandType = CommandType.Text;
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@AnhDaiDien", obj.AnhDaiDien));
            comm.Parameters.Add(new SqlParameter("@ID", obj.ID));
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

        public DataTable vvalidatekey(string key)
        {
            DataTable dts = new DataTable();
            SqlDataAdapter VSda;
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from Members where key=@key", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@key", key));
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

        //public DataTable Detailvuserun(string vuserun)
        //{
        //    DataTable dts = new DataTable();
        //    SqlDataAdapter VSda;
        //    SqlConnection conn = Database.Connection();
        //    SqlCommand comm = new SqlCommand("select * from Members where vuserun=@vuserun", conn);
        //    comm.CommandType = CommandType.Text;
        //    comm.Parameters.Add(new SqlParameter("@vuserun", vuserun));
        //    try
        //    {
        //        VSda = new SqlDataAdapter(comm);
        //        VSda.Fill(dts);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return dts;
        //}

        public DataTable Detailemail(string Email)
        {
            DataTable dts = new DataTable();
            SqlDataAdapter VSda;
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from Members where Email=@Email", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@Email", Email));
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

        //#region GET BY ID
        //public List<Member> Logiin(string vuserun, string vuserpwd, string istatus)
        //{
        //    SqlConnection conn = Database.Connection();
        //    SqlCommand comm = new SqlCommand("select * from Members where vuserun='" + vuserun + "' and vuserpwd='" + vuserpwd + "' and istatus=" + istatus + "", conn);
        //    comm.CommandType = CommandType.Text;
        //    comm.Parameters.Add(new SqlParameter("@vuserun", vuserun));
        //    comm.Parameters.Add(new SqlParameter("@vuserpwd", BuildPassword(vuserpwd)));
        //    comm.Parameters.Add(new SqlParameter("@istatus", istatus));
        //    try
        //    {
        //        return Database.Bind_List_Reader<Member>(comm);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
        //#endregion

        //public DataTable Detail_vuserun_vuserpwd(string vuserun, string vuserpwd, string istatus)
        //{
        //    vuserpwd = BuildPassword(vuserpwd);
        //    DataTable dts = new DataTable();
        //    SqlDataAdapter VSda;
        //    SqlConnection conn = Database.Connection();
        //    SqlCommand comm = new SqlCommand("select * from Members where vuserun=@vuserun and vuserpwd=@vuserpwd and istatus=@istatus", conn);
        //    comm.CommandType = CommandType.Text;
        //    comm.Parameters.Add(new SqlParameter("@vuserun", vuserun));
        //    comm.Parameters.Add(new SqlParameter("@vuserpwd", BuildPassword(vuserpwd)));
        //    comm.Parameters.Add(new SqlParameter("@istatus", istatus));
        //    try
        //    {
        //        VSda = new SqlDataAdapter(comm);
        //        VSda.Fill(dts);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return dts;
        //}

        //public DataTable Getdetailbyunpwd(string vuserun, string vuserpwd)
        //{
        //    vuserpwd = BuildPassword(vuserpwd);
        //    DataTable dts = new DataTable();
        //    SqlDataAdapter VSda;
        //    SqlConnection conn = Database.Connection();
        //    SqlCommand comm = new SqlCommand("select * from Members where vuserun=@vuserun and vuserpwd=@vuserpwd", conn);
        //    comm.CommandType = CommandType.Text;
        //    comm.Parameters.Add(new SqlParameter("@vuserun", vuserun));
        //    comm.Parameters.Add(new SqlParameter("@vuserpwd", vuserpwd));
        //    try
        //    {
        //        VSda = new SqlDataAdapter(comm);
        //        VSda.Fill(dts);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return dts;
        //}

        #region Name StoredProcedure
        public List<Member> Name_StoredProcedure(string Name_StoredProcedure)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_StoredProcedure, conn);
            comm.CommandType = CommandType.StoredProcedure;
            try
            {
                return Database.Bind_List_Reader<Member>(comm);
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
        public List<Member> Name_Text(string Name_Text)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_Text, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<Member>(comm);
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
        public List<SumMember> Name_SumMember(string Name_Text)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_Text, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<SumMember>(comm);
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
