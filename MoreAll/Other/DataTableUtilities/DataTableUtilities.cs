using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Text;
using System.Collections;

namespace MoreAll
{
    public class DataTableUtilities
    {
        public static void CopyRowBetween2Tables_SameFormat(DataTable from, ref DataTable to, int row)
        {
            int i;
            if (to.Columns.Count < 1)
            {
                for (i = 0; i < from.Columns.Count; i++)
                {
                    to.Columns.Add(from.Columns[i].ColumnName, from.Columns[i].DataType);
                }
            }
            if (from.Rows.Count > 0)
            {
                DataRow dr = to.NewRow();
                for (i = 0; i < to.Columns.Count; i++)
                {
                    dr[i] = from.Rows[row][i];
                }
                to.Rows.Add(dr);
            }
        }

        public static void CopyRowsBetween2Tables_SameFormat(DataTable from, ref DataTable to)
        {
            for (int i = 0; i < from.Rows.Count; i++)
            {
                CopyRowBetween2Tables_SameFormat(from, ref to, i);
            }
        }

        public static int CountItems(string condition, string sort, DataTable dt_source)
        {
            if (sort.Trim().Length > 0)
            {
                return dt_source.Select(condition, sort).Length;
            }
            return dt_source.Select(condition).Length;
        }

        public static int CountItems(string condition, string sort, ref DataTable dt_source)
        {
            if (sort.Trim().Length > 0)
            {
                return dt_source.Select(condition, sort).Length;
            }
            return dt_source.Select(condition).Length;
        }

        public static DataRow[] LoadDataRows(string condition, string sort, ref DataTable dt_source)
        {
            return dt_source.Select(condition, sort);
        }

        public static DataTable LoadDataTable(string condition, string sort, DataTable dt_source)
        {
            DataTable dt = new DataTable();
            if (dt_source.Rows.Count > 0)
            {
                int i;
                DataRow[] drs;
                DataRow r;
                int j;
                for (i = 0; i < dt_source.Columns.Count; i++)
                {
                    dt.Columns.Add(dt_source.Columns[i].ColumnName.ToString(), dt_source.Columns[i].DataType);
                }
                if (sort.Trim().Length > 0)
                {
                    drs = dt_source.Select(condition, sort);
                    if (drs.Length > 0)
                    {
                        for (i = 0; i < drs.Length; i++)
                        {
                            r = dt.NewRow();
                            j = 0;
                            while (j < dt.Columns.Count)
                            {
                                r[j] = drs[i][j];
                                j++;
                            }
                            dt.Rows.Add(r);
                        }
                    }
                    return dt;
                }
                drs = dt_source.Select(condition);
                if (drs.Length <= 0)
                {
                    return dt;
                }
                for (i = 0; i < drs.Length; i++)
                {
                    r = dt.NewRow();
                    for (j = 0; j < dt.Columns.Count; j++)
                    {
                        r[j] = drs[i][j];
                    }
                    dt.Rows.Add(r);
                }
            }
            return dt;
        }

        public static DataTable LoadDataTable(string condition, string sort, ref DataTable dt_source)
        {
            DataTable dt = new DataTable();
            if (dt_source.Rows.Count > 0)
            {
                int i;
                DataRow[] drs;
                DataRow r;
                int j;
                for (i = 0; i < dt_source.Columns.Count; i++)
                {
                    dt.Columns.Add(dt_source.Columns[i].ColumnName.ToString(), dt_source.Columns[i].DataType);
                }
                if (sort.Trim().Length > 0)
                {
                    drs = dt_source.Select(condition, sort);
                    if (drs.Length > 0)
                    {
                        for (i = 0; i < drs.Length; i++)
                        {
                            r = dt.NewRow();
                            j = 0;
                            while (j < dt.Columns.Count)
                            {
                                r[j] = drs[i][j];
                                j++;
                            }
                            dt.Rows.Add(r);
                        }
                    }
                    return dt;
                }
                drs = dt_source.Select(condition);
                if (drs.Length <= 0)
                {
                    return dt;
                }
                for (i = 0; i < drs.Length; i++)
                {
                    r = dt.NewRow();
                    for (j = 0; j < dt.Columns.Count; j++)
                    {
                        r[j] = drs[i][j];
                    }
                    dt.Rows.Add(r);
                }
            }
            return dt;
        }
    }
}

