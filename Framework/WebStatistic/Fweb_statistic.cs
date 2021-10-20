using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.SqlClient;
using System.Data;

namespace Framework
{
    public class Fweb_statistic
    {
        public static int ihitscounter = 0;
        #region GET BY ID
        public List<web_statistic> GETBYID(string INO)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_web_statistic_GetById", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add(new SqlParameter("@INO", INO));
            try
            {
                return Database.Bind_List_Reader<web_statistic>(comm);
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
        public List<web_statistic> GETBYALL()
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_web_statistic_GetByAll", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                return Database.Bind_List_Reader<web_statistic>(comm);
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
        public bool INSERT(web_statistic obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_web_statistic_Insert", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@DDATE", obj.DDATE));
            comm.Parameters.Add(new SqlParameter("@INUMOFVISIT", obj.INUMOFVISIT));
            comm.Parameters.Add(new SqlParameter("@INUMOFMEMBER", obj.INUMOFMEMBER));
            comm.Parameters.Add(new SqlParameter("@IHITS", obj.IHITS));
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
        public bool UPDATE(web_statistic obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_web_statistic_Update", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@INO", obj.INO));
            comm.Parameters.Add(new SqlParameter("@DDATE", obj.DDATE));
            comm.Parameters.Add(new SqlParameter("@INUMOFVISIT", obj.INUMOFVISIT));
            comm.Parameters.Add(new SqlParameter("@INUMOFMEMBER", obj.INUMOFMEMBER));
            comm.Parameters.Add(new SqlParameter("@IHITS", obj.IHITS));
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
        public void DELETE(string INO)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_web_statistic_Delete", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@INO", INO));
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

        #region BY DATE
        public List<web_statistic> BYDATE(string month, string year)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select sum(inumofvisit) as numofvisit,day(ddate) as date from web_statistic where month(ddate)= @month and year(ddate)= @year group by day(ddate) order by day(ddate) asc", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@month", month));
            comm.Parameters.Add(new SqlParameter("@year", year));
            try
            {
                return Database.Bind_List_Reader<web_statistic>(comm);
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

        #region BY MONTH
        public List<web_statistic> BYMONTH(string year)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select sum(inumofvisit) as numofvisit,month(ddate) as month from web_statistic where year(ddate)= @year group by month(ddate) order by month(ddate) asc", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@year", year));
            try
            {
                return Database.Bind_List_Reader<web_statistic>(comm);
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

        #region DDATE
        public List<web_statistic> DDATE()
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from web_statistic where (datepart(dd,ddate)=datepart(dd,getdate()) and datepart(MM,ddate)=datepart(MM,getdate()) and datepart(yyyy,ddate)=datepart(yyyy,getdate()))", conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<web_statistic>(comm);
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

        #region REPORT BY MONTH
        public string REPORTBYMONTH(DataTable report, string Fcolor, string Bcolor, string Barcolor)
        {
            string str = "<table  border='0' width='100%' cellpadding='0' style='border-collapse: collapse; border-left-width: 1px; border-right: 1px solid #FFFFFF; border-top-width: 1px; border-bottom-width: 1px'' id='table4'><tr height=0><td><font size=1>[NUM]</font></td></tr><tr  bgcolor=" + Barcolor + " height=[HEIGHT]><td></td></tr><tr align=center height=10><td>[COL]</td></tr></table>";
            string str2 = "<table border='0' width='100%' cellpadding='0' style='border-collapse: collapse; border-left: 1px solid #C0C0C0; border-right-width: 1px; border-top-width: 1px; border-bottom: 1px solid #C0C0C0' id='table2'><tr><td style='border-left-style: solid; border-left-width: 1px; border-bottom-style: solid; border-bottom-width: 1px'> &nbsp;";
            str2 = str2 + "</td><td><table bgcolor=" + Bcolor + " height=0 class=all border='0' cellpadding='0' style='border-collapse: collapse'><tr  valign=bottom>";
            string str3 = "1";
            int num = 0;
            for (int i = 0; i < report.Rows.Count; i++)
            {
                int num3 = Convert.ToInt32(report.Rows[i]["numofvisit"].ToString());
                num += num3;
            }
            for (int j = 0; j < report.Rows.Count; j++)
            {
                str2 = str2 + "<td align=center width=20>";
                str3 = str;
                int num5 = Convert.ToInt32(report.Rows[j]["numofvisit"].ToString());
                int num6 = (num5 * 350) / num;
                str3 = str3.Replace("[HEIGHT]", num6.ToString()).Replace("[COL]", report.Rows[j]["month"].ToString()).Replace("[NUM]", report.Rows[j]["numofvisit"].ToString());
                str2 = str2 + str3 + "</td><td></td>";
            }
            return (str2 + "</tr></table></td>\t</tr></table>" + "<table class=all border='0' width='100%' cellspacing='0' cellpadding='0'><tr><td width=50%><b>Total</b>: [TOTAL]</td><td></td></tr></table>").Replace("[TOTAL]", num.ToString());
        }
        #endregion

        public DataTable Load_WebStatistic()
        {
            DataTable dts = new DataTable();
            SqlDataAdapter VSda;
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select (select sum(INUMOFVISIT) from web_statistic) as sumvisitor,(select sum(IHITS) from web_statistic) as subhits", conn);
            comm.CommandType = CommandType.Text;
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

        public void UpdateHitsCounter()
        {
            SqlCommand cmd = new SqlCommand("update web_statistic set IHITS = IHITS + " + ihitscounter.ToString() + " where datepart(dd,getdate())=datepart(dd,ddate) and datepart(MM,ddate)=datepart(MM,getdate()) and datepart(yyyy,ddate)=datepart(yyyy,getdate())");
            Database.ExecuteNoneQuery(cmd);
            cmd = null;
            ihitscounter = 0;
        }

        public void UpdateCounter()
        {
            try
            {
                SqlConnection conn = Database.Connection();
                SqlCommand comm = new SqlCommand("select count(*) as numofitem from web_statistic where datepart(dd,ddate)=datepart(dd,getdate()) and datepart(MM,ddate)=datepart(MM,getdate()) and datepart(yyyy,ddate)=datepart(yyyy,getdate())", conn);
                if (Convert.ToInt32(Database.GetData(comm).Rows[0]["numofitem"].ToString().Trim()) == 0)
                {
                    comm = new SqlCommand("insert web_statistic values(GETDATE(),1,0,0)", conn);
                }
                else
                {
                    comm = new SqlCommand("update web_statistic set inumofvisit = inumofvisit + 1 where (datepart(dd,ddate)=datepart(dd,getdate()) and datepart(MM,ddate)=datepart(MM,getdate()) and datepart(yyyy,ddate)=datepart(yyyy,getdate()))", conn);
                }
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
            catch (Exception) { }
        }

        public DataTable ByDate(string month, string year)
        {
            DataTable dts = new DataTable();
            SqlDataAdapter VSda;
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select sum(inumofvisit) as numofvisit,day(ddate) as date from web_statistic where month(ddate)=@month and year(ddate)=@year group by day(ddate) order by day(ddate) asc", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@month", month));
            comm.Parameters.Add(new SqlParameter("@year", year));
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

        public DataTable ByMonth(string year)
        {
            DataTable dts = new DataTable();
            SqlDataAdapter VSda;
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select sum(inumofvisit) as numofvisit,month(ddate) as month from web_statistic where year(ddate)=@year group by month(ddate) order by month(ddate) asc", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@year", year));
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

        //
        public DataTable TrongThang()
        {
            DataTable dts = new DataTable();
            SqlDataAdapter VSda;
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select sum(INUMOFVISIT) as Thang from web_statistic WHERE month(DDATE)=" + DateTime.Now.Month + "", conn);
            comm.CommandType = CommandType.Text;
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
       
        #region Trongngay
        public List<web_statistic> Trongngay()
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from web_statistic  where (datepart(dd,ddate)=datepart(dd,getdate()) and datepart(MM,ddate)=datepart(MM,getdate()) and datepart(yyyy,ddate)=datepart(yyyy,getdate()))", conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<web_statistic>(comm);
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
