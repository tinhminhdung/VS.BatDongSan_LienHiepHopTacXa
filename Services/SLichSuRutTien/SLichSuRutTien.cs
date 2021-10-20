using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Entity;

namespace Services
{
    public class SLichSuRutTien
    {
        private static FLichSuRutTien db = new FLichSuRutTien();

        #region CATEGORY_PHANTRANG
        public static List<ELichSuRutTien> CATEGORY_PHANTRANG2(string sql, int PageIndex, int Tongpage)
        {
            return db.CATEGORY_PHANTRANG2(sql, PageIndex, Tongpage);
        }
        public static List<ELichSuRutTien> CATEGORY_PHANTRANG1(string sql)
        {
            return db.CATEGORY_PHANTRANG1(sql);
        }
        public static List<ELichSuRutTien> Exel(string sql)
        {
            return db.Exel(sql);
        }
        #endregion

        #region Name_Text
        public static List<ELichSuRutTien> Name_Text(string Name_Text)
        {
            return db.Name_Text(Name_Text);
        }
        #endregion
    }
}
