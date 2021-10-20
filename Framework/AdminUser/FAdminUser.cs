using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
namespace Framework
{
    public class FAdminUser
    {
        public static string EncodeMD5(string text)
        {
            byte[] byteArray = new UnicodeEncoding().GetBytes(text);
            byte[] hashvalue = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(byteArray);
            string encryptedText = "";
            for (int i = 0; i < hashvalue.Length; i++)
            {
                encryptedText = encryptedText + Convert.ToString(hashvalue[i]);
            }
            return encryptedText;
        }

        #region DETAIL NAME
        public List<AdminUser> DETAILNAME(string vuser_name)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_AdminUser_DetailName", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@vuser_name", vuser_name));
            try
            {
                return Database.Bind_List_Reader<AdminUser>(comm);
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

        #region USER DETAIL
        public List<AdminUser> DETAIL(string vusername, string vuser_pwd, string ILOCKED)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_AdminUser_User_Detail", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@vuser_name", vusername));
            comm.Parameters.Add(new SqlParameter("@vuser_pwd", EncodeMD5(vuser_pwd)));
            comm.Parameters.Add(new SqlParameter("@ILOCKED", ILOCKED));
            try
            {
                return Database.Bind_List_Reader<AdminUser>(comm);
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

        #region[UPDATE PASSWORD]
        public bool UPDATEPASSWORD(AdminUser obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_AdminUser_UpdatePassword", conn);
            comm.CommandType = CommandType.StoredProcedure;
            
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@ID", obj.ID));
            comm.Parameters.Add(new SqlParameter("@VUSER_PWD", obj.VUSER_PWD));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("AdminUser");
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

        #region[UPDATE PASSWORD STATUS]
        public bool UPDATESTATUS(AdminUser obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_AdminUser_UpdateStatus", conn);
            comm.CommandType = CommandType.StoredProcedure;
            
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@ID", obj.ID));
            comm.Parameters.Add(new SqlParameter("@ILOCKED", obj.ILOCKED));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("AdminUser");
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

        #region[AdminUser GET BY ID]
        public List<AdminUser> GETBYID(string Id)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_AdminUser_Get", conn);
            comm.CommandType = CommandType.StoredProcedure;
            
            comm.Parameters.Add(new SqlParameter("@ID", Id));
            try
            {
                return Database.Bind_List_Reader<AdminUser>(comm);
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

        #region[AdminUser GET BY ALL]
        public List<AdminUser> GETBYALL()
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_AdminUser_All", conn);
            comm.CommandType = CommandType.StoredProcedure;
            try
            {
                return Database.Bind_List_Reader<AdminUser>(comm);
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

        #region[AdminUser INSERT]
        public bool Insert(AdminUser data)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("sp_AdminUser_Insert", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@VUSER_NAME", data.VUSER_NAME));
            comm.Parameters.Add(new SqlParameter("@VUSER_PWD", data.VUSER_PWD));
            comm.Parameters.Add(new SqlParameter("@VROLE", data.VROLE));
            comm.Parameters.Add(new SqlParameter("@IASSIGN", data.IASSIGN));
            comm.Parameters.Add(new SqlParameter("@DASSIGN_DATE", data.DASSIGN_DATE));
            comm.Parameters.Add(new SqlParameter("@ILOCKED", data.ILOCKED));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("AdminUser");
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

        #region[AdminUser UPDATE]
        public bool Update(AdminUser obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("sp_AdminUser_Update", conn);
            comm.CommandType = CommandType.StoredProcedure;
            
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@ID", obj.ID));
            comm.Parameters.Add(new SqlParameter("@VUSER_NAME", obj.VUSER_NAME));
            comm.Parameters.Add(new SqlParameter("@VUSER_PWD", obj.VUSER_PWD));
            comm.Parameters.Add(new SqlParameter("@VROLE", obj.VROLE));
            comm.Parameters.Add(new SqlParameter("@IASSIGN", obj.IASSIGN));
            comm.Parameters.Add(new SqlParameter("@DASSIGN_DATE", obj.DASSIGN_DATE));
            comm.Parameters.Add(new SqlParameter("@ILOCKED", obj.ILOCKED));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("AdminUser");
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

        #region[AdminUser DELETE]
        public void Delete(string Id)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_AdminUser_Delete", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@ID", Id));
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("AdminUser");
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
    }
}
