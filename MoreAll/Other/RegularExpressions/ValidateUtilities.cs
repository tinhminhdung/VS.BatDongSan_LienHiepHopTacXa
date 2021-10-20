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
using System.Text.RegularExpressions;

namespace MoreAll
{
    public class ValidateUtilities
    {
        public static bool CheckValidDay(string day, string month, string year)
        {
            try
            {
                int dd = Convert.ToInt32(day);
                int mm = Convert.ToInt32(month);
                int yyyy = Convert.ToInt32(year);
                if ((dd > DateTime.DaysInMonth(yyyy, mm)) || (dd < 1))
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public static bool IsNumber(string strNumber)
        {
            Regex objNotNumberPattern = new Regex("[^0-9.-]");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
            string strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
            string strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
            Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");
            return (((!objNotNumberPattern.IsMatch(strNumber) && !objTwoDotPattern.IsMatch(strNumber)) && !objTwoMinusPattern.IsMatch(strNumber)) && objNumberPattern.IsMatch(strNumber));
        }

        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^.+\@(\[?)[a-zA-Z0-9\-\.]+\.([a-zA-Z]{2,3}|[0-9]{1,3})(\]?)$");
        }

        public static bool IsValidInt(string val)
        {
            return Regex.IsMatch(val, @"^[1-9]\d*\.?[0]*$");
        }

        public static bool IsValidURL(string url)
        {
            return Regex.IsMatch(url, @"^(http|https|ftp)\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&%\$#\=~])*[^\.\,\)\(\s]$");
        }
    }
}

