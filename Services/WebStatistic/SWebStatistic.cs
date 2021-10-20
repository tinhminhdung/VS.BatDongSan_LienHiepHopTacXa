using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Entity;
using System.Data;

namespace Services
{
    public class SWebStatistic
    {
        private static Fweb_statistic db = new Fweb_statistic();

        #region GET BY ID
        public static List<web_statistic> GET_BY_ID(string ID)
        {
            return db.GETBYID(ID);
        }
        #endregion

        #region GET BY ALL
        public static List<web_statistic> GET_BY_ALL()
        {
            return db.GETBYALL();
        }
        #endregion

        #region INSERT
        public static bool INSERT(web_statistic obj)
        {
            return db.INSERT(obj);
        }
        #endregion

        #region UPDATE
        public static bool UPDATE(web_statistic obj)
        {
            return db.UPDATE(obj);
        }
        #endregion

        #region DELETE
        public static void DELETE(string ID)
        {
            db.DELETE(ID);
        }
        #endregion

        #region WEB STATISTIC BY DATE
        public static List<web_statistic> WebStatistic_ByDate(string month, string year)
        {
            return db.BYDATE(month, year);
        }
        #endregion

        #region WebStatistic_ByMonth
        public static List<web_statistic> WebStatistic_ByMonth(string year)
        {
            return db.BYMONTH(year);
        }
        #endregion

        #region WebStatistic_DDATE
        public static List<web_statistic> WebStatistic_DDATE()
        {
            return db.DDATE();
        }
        #endregion        

        #region Trongngay
        public static List<web_statistic> Trongngay()
        {
            return db.Trongngay();
        }
        #endregion


        #region TrongThang
        public static DataTable TrongThang()
        {
            return db.TrongThang();
        }
        #endregion
    }
}
