using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Entity;

namespace Framwork
{
    public class FProduct_images
    {
        #region[GetById]
        public List<Product_images> GetById(string Id)
        {
            SqlConnection conn = Database.Connection();

            SqlCommand dbCmd = new SqlCommand("SELECT * FROM Product_images WHERE ID=@ID", conn);

            dbCmd.CommandType = CommandType.Text;
            dbCmd.Parameters.Add(new SqlParameter("@ID", Id));
            try
            {
                return Database.Bind_List_Reader<Product_images>(dbCmd);
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

        #region[More_icid]
        public List<Product_images>  More_icid(string icid)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand dbCmd = new SqlCommand("SELECT * FROM [Product_images] WHERE icid IN (" + icid + ")", conn);
            dbCmd.CommandType = CommandType.Text;
            dbCmd.Parameters.Add(new SqlParameter("@icid", icid));
            try
            {
                return Database.Bind_List_Reader<Product_images>(dbCmd);
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
        public List<Product_images>  GetByAll()
        {
            SqlConnection conn = Database.Connection();
            SqlCommand dbCmd = new SqlCommand("S_Product_images_GetByAll", conn);

            dbCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                return Database.Bind_List_Reader<Product_images>(dbCmd);
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

        #region[Insert]
        public bool Insert(Product_images obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand dbCmd = new SqlCommand("S_Product_images_Insert", conn);

            dbCmd.CommandType = CommandType.StoredProcedure;
            SqlTransaction tran = conn.BeginTransaction();
            dbCmd.Transaction = tran;
            dbCmd.Parameters.Add(new SqlParameter("@ipid", obj.ipid));
            dbCmd.Parameters.Add(new SqlParameter("@icid", obj.icid));
            dbCmd.Parameters.Add(new SqlParameter("@Title", obj.Title));
            dbCmd.Parameters.Add(new SqlParameter("@Brief", obj.Brief));
            dbCmd.Parameters.Add(new SqlParameter("@Images", obj.Images));
            dbCmd.Parameters.Add(new SqlParameter("@ImagesSmall", obj.ImagesSmall));
            dbCmd.Parameters.Add(new SqlParameter("@Equals", obj.Equals));
            dbCmd.Parameters.Add(new SqlParameter("@Orders", obj.Orders));
            dbCmd.Parameters.Add(new SqlParameter("@Status", obj.Status));
            try
            {
                dbCmd.ExecuteNonQuery();
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

        #region[Update]
        public bool Update(Product_images obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand dbCmd = new SqlCommand("S_Product_images_Update", conn);

            dbCmd.CommandType = CommandType.StoredProcedure;
            SqlTransaction tran = conn.BeginTransaction();
            dbCmd.Transaction = tran;
            dbCmd.Parameters.Add(new SqlParameter("@ID", obj.ID));
            dbCmd.Parameters.Add(new SqlParameter("@ipid", obj.ipid));
            dbCmd.Parameters.Add(new SqlParameter("@icid", obj.icid));
            dbCmd.Parameters.Add(new SqlParameter("@Title", obj.Title));
            dbCmd.Parameters.Add(new SqlParameter("@Brief", obj.Brief));
            dbCmd.Parameters.Add(new SqlParameter("@Images", obj.Images));
            dbCmd.Parameters.Add(new SqlParameter("@ImagesSmall", obj.ImagesSmall));
            dbCmd.Parameters.Add(new SqlParameter("@Equals", obj.Equals));
            dbCmd.Parameters.Add(new SqlParameter("@Orders", obj.Orders));
            dbCmd.Parameters.Add(new SqlParameter("@Status", obj.Status));
            try
            {
                dbCmd.ExecuteNonQuery();
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
            SqlCommand dbCmd = new SqlCommand("DELETE FROM [Product_images] WHERE ID=@ID", conn);

            dbCmd.CommandType = CommandType.Text;
            dbCmd.Parameters.Add(new SqlParameter("@ID", Id));
            SqlTransaction tran = conn.BeginTransaction();
            dbCmd.Transaction = tran;
            try
            {
                dbCmd.ExecuteNonQuery();
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

        #region[Delete_Ipid]
        public void Delete_Ipid(string Ipid)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand dbCmd = new SqlCommand("DELETE FROM [Product_images] WHERE Ipid=@Ipid", conn);

            dbCmd.CommandType = CommandType.Text;
            dbCmd.Parameters.Add(new SqlParameter("@Ipid", Ipid));
            SqlTransaction tran = conn.BeginTransaction();
            dbCmd.Transaction = tran;
            try
            {
                dbCmd.ExecuteNonQuery();
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

        #region upate_status
        public bool upate_status(string id, string status)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update Product_images set status = @status   where id = @ID", conn);
            comm.CommandType = CommandType.Text;

            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@ID", id));
            comm.Parameters.Add(new SqlParameter("@status", status));
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

        #region GetBy_ipid
        public List<Product_images>  GetBy_ipid(string ipid)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand dbCmd = new SqlCommand("SELECT * FROM Product_images WHERE ipid=@ipid", conn);

            dbCmd.CommandType = CommandType.Text;
            dbCmd.Parameters.Add(new SqlParameter("@ipid", ipid));
            try
            {
                return Database.Bind_List_Reader<Product_images>(dbCmd);
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

        #region Update_img
        public bool Update_img(string ipid, string Images, string ImagesSmall)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update Product_images set Images=@Images,ImagesSmall=@ImagesSmall where ipid=@ipid", conn);
            comm.CommandType = CommandType.Text;

            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@ipid", ipid));
            comm.Parameters.Add(new SqlParameter("@Images", Images));
            comm.Parameters.Add(new SqlParameter("@ImagesSmall", ImagesSmall));
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

        #region Cate_Delete_icid
        public void Cate_Delete_icid(string icid)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand dbCmd = new SqlCommand("DELETE FROM [Product_images] WHERE  icid  IN(" + icid + ")", conn);

            dbCmd.CommandType = CommandType.Text;
            dbCmd.Parameters.Add(new SqlParameter("@icid", icid));
            SqlTransaction tran = conn.BeginTransaction();
            dbCmd.Transaction = tran;
            try
            {
                dbCmd.ExecuteNonQuery();
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
    }
}