using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace MoreAll
{
    public class RewriteReplaceAll
    {
        private static string[] a = new string[] { "\x00e0", "\x00e1", "ạ", "ả", "\x00e3", "\x00e2", "ầ", "ấ", "ậ", "ẩ", "ẫ", "ă", "ắ", "ằ", "ắ", "ặ", "ẳ", "ẵ", "a" };
        private static string[] d = new string[] { "đ", "d" };
        private static string[] e = new string[] { "\x00e8", "\x00e9", "ẹ", "ẻ", "ẽ", "\x00ea", "ề", "ế", "ệ", "ể", "ễ", "e" };
        private static string[] ii = new string[] { "\x00ec", "\x00ed", "ị", "ỉ", "ĩ", "i" };
        private static string[] o = new string[] { "\x00f2", "\x00f3", "ọ", "ỏ", "\x00f5", "\x00f4", "ồ", "ố", "ộ", "ổ", "ỗ", "ơ", "ờ", "ớ", "ợ", "ở", "ỡ", "o" };
        private static string[] u = new string[] { "\x00f9", "\x00fa", "ụ", "ủ", "ũ", "ừ", "ứ", "ự", "ử", "ữ", "u", "ư" };
        private static string[] y = new string[] { "ỳ", "\x00fd", "ỵ", "ỷ", "ỹ", "y" };

        public static string GetRewriteURL(string inputstring)
        {
            if (inputstring.Length > 0)
            {
                return (Title(inputstring));
            }
            return (Title(inputstring));
        }

        private static string ChangeChar(string charinput)
        {
            int i;
            for (i = 0; i < a.Length; i++)
            {
                if (a[i].Equals(charinput))
                {
                    return "a";
                }
            }
            for (i = 0; i < d.Length; i++)
            {
                if (d[i].Equals(charinput))
                {
                    return "d";
                }
            }
            for (i = 0; i < e.Length; i++)
            {
                if (e[i].Equals(charinput))
                {
                    return "e";
                }
            }
            for (i = 0; i < ii.Length; i++)
            {
                if (ii[i].Equals(charinput))
                {
                    return "i";
                }
            }
            for (i = 0; i < y.Length; i++)
            {
                if (y[i].Equals(charinput))
                {
                    return "y";
                }
            }
            for (i = 0; i < o.Length; i++)
            {
                if (o[i].Equals(charinput))
                {
                    return "o";
                }
            }
            for (i = 0; i < u.Length; i++)
            {
                if (u[i].Equals(charinput))
                {
                    return "u";
                }
            }
            return charinput;
        }

        private static string GenNosign(string LongName)
        {
            string ret = "";
            string currentchar = "";
            int len = LongName.Length;
            if (LongName.Length > 0)
            {
                for (int i = 0; i < len; i++)
                {
                    currentchar = LongName.Substring(i, 1);
                    ret = ret + ChangeChar(currentchar);
                }
                return ret;
            }
            return "";
        }

        private static string GenShortName(string LongName)
        {
            string ret = "";
            string currentchar = "";
            LongName = LongName.Replace(" ", " ");
            LongName = LongName.ToLower();
            int len = LongName.Length;
            if (LongName.Length > 0)
            {
                for (int i = 0; i < len; i++)
                {
                    currentchar = LongName.Substring(i, 1);
                    ret = ret + ChangeChar(currentchar);
                }
                return ret;
            }
            return "";
        }

        public static string Title(string stringinput)
        {
            return GenShortName(GenNosign(stringinput));
        }
    }
}

