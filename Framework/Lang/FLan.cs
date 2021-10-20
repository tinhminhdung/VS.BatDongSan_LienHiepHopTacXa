using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.SqlClient;
using System.Data;

namespace Framework
{
    public class FLan
    {
        #region NOMARL
        public List<Lans> NORMAL()
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select  top 1 * from lans  where ILAN_LOCKED=1 and MacDinh=1 order by ILAN_ORDER asc", conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<Lans>(comm);
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
        public List<Lans> GETBYID(string ilanid)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from lans where ilanid= @ilanid", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@ilanid", ilanid));
            try
            {
                return Database.Bind_List_Reader<Lans>(comm);
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

        #region ALL
        public List<Lans> ALL()
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select  * from lans   order by ILAN_ORDER asc", conn);
            comm.CommandType = CommandType.Text;
            
            try
            {
                return Database.Bind_List_Reader<Lans>(comm);
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

        #region LANG
        public List<Lans> LANG(string Lang)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_lans_lang", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            try
            {
                return Database.Bind_List_Reader<Lans>(comm);
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
        public bool INSERT(Lans obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_lans_Insert", conn);
            comm.CommandType = CommandType.StoredProcedure;
            
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@VLAN_ID", obj.VLAN_ID));
            comm.Parameters.Add(new SqlParameter("@VLAN_NAME", obj.VLAN_NAME));
            comm.Parameters.Add(new SqlParameter("@VLAN_NAME_VIE", obj.VLAN_NAME_VIE));
            comm.Parameters.Add(new SqlParameter("@ILAN_ORDER", obj.ILAN_ORDER));
            comm.Parameters.Add(new SqlParameter("@ILAN_LOCKED", obj.ILAN_LOCKED));
            comm.Parameters.Add(new SqlParameter("@MacDinh", obj.MacDinh));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("lans");
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
        public bool UPDATE(Lans obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update lans set VLAN_ID=@VLAN_ID, VLAN_NAME= @VLAN_NAME,VLAN_NAME_VIE= @VLAN_NAME_VIE,ILAN_ORDER= @ILAN_ORDER,ILAN_LOCKED= @ILAN_LOCKED,MacDinh= @MacDinh where ilanid= @ilanid", conn);
            comm.CommandType = CommandType.Text;
            
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@ilanid", obj.ilanid));
            comm.Parameters.Add(new SqlParameter("@VLAN_ID", obj.VLAN_ID));
            comm.Parameters.Add(new SqlParameter("@VLAN_NAME", obj.VLAN_NAME));
            comm.Parameters.Add(new SqlParameter("@VLAN_NAME_VIE", obj.VLAN_NAME_VIE));
            comm.Parameters.Add(new SqlParameter("@ILAN_ORDER", obj.ILAN_ORDER));
            comm.Parameters.Add(new SqlParameter("@ILAN_LOCKED", obj.ILAN_LOCKED));
            comm.Parameters.Add(new SqlParameter("@MacDinh", obj.MacDinh));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Lans");
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
        public void DELETE(string Id)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("delete from lans where ilanid= @ilanid", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@ilanid", Id));
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("Lans");
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

        #region Name Text
        public List<Lans> Name_Text(string Name_Text)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_Text, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<Lans>(comm);
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
