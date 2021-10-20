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
    public class FormatDateTime
    {
        public static string CombineMDYDate(string day, string month, string year)
        {
            try
            {
                int num = Convert.ToInt32(day);
                int num2 = Convert.ToInt32(month);
                int num3 = Convert.ToInt32(year);
                if (num > DateTime.DaysInMonth(num3, num2))
                {
                    num = DateTime.DaysInMonth(num3, num2);
                }
                return (num2.ToString() + "/" + num.ToString() + "/" + num3.ToString());
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static string FormatDate(object date)
        {
            return (Convert.ToDateTime(date).ToString("dd-MM-yyyy hh:mm:ss") + " " + date.ToString().Substring(date.ToString().Length - 2, 2));
        }

        public static string FormatDateVIE(object date)
        {
            return Convert.ToDateTime(date).ToString("dd-MM-yyyy");
        }

        public static string FormatDate_Brithday(object date)
        {
            return Convert.ToDateTime(date).ToString("MM/dd/yyyy");
        }
        public static string FormatDates(object date)
        {
            return Convert.ToDateTime(date).ToString("MM/dd/yyyy");
        }
        public static string FormatDate_Longdate(string lang)
        {
            string str = DateTime.Now.DayOfWeek.ToString();
            switch (DateTime.Now.DayOfWeek.ToString())
            {
                case "Saturday":
                    if (lang.Equals("VIE"))
                    {
                        str = "Thứ bảy";
                    }
                    break;

                case "Sunday":
                    if (lang.Equals("VIE"))
                    {
                        str = "Chủ nhật";
                    }
                    break;

                case "Monday":
                    if (lang.Equals("VIE"))
                    {
                        str = "Thứ hai";
                    }
                    break;

                case "Tuesday":
                    if (lang.Equals("VIE"))
                    {
                        str = "Thứ ba";
                    }
                    break;

                case "Wednesday":
                    if (lang.Equals("VIE"))
                    {
                        str = "Thứ tư";
                    }
                    break;

                case "Thursday":
                    if (lang.Equals("VIE"))
                    {
                        str = "Thứ năm";
                    }
                    break;

                case "Friday":
                    if (lang.Equals("VIE"))
                    {
                        str = "Thứ sáu";
                    }
                    break;
            }
            return (str + ",  " + DateTime.Now.ToString("hh") + "h :" + DateTime.Now.ToString("mm") + "'&nbsp; " + Captionlanguage.GetLabel("lt_day", lang) + "&nbsp;" + DateTime.Now.ToString("dd-MM-yyyy"));
        }
    }
}
