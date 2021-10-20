using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

namespace MoreAll
{
    public class StringUtilities
    {
        public static bool check_stringinstring(string text, string value)
        {
            return (text.IndexOf(value) > -1);
        }

        public static string[] ConvertString_ToArray(string text, string separator)
        {
            return text.Split(new char[] { Convert.ToChar(separator) });
        }

        public static string[] ConvertString_ToArray(string text, string separator, int index, ref string getitem)
        {
            string[] r = ConvertString_ToArray(text, separator);
            if ((index > -1) && (index < r.Length))
            {
                getitem = r[index];
                return r;
            }
            getitem = "";
            return r;
        }

        public static ArrayList ConvertString_ToArrayList(string text, string separator)
        {
            ArrayList arr = new ArrayList();
            arr.AddRange(ConvertString_ToArray(text, separator));
            return arr;
        }

        public static int count_stringinstring(string t, string v)
        {
            Regex r = new Regex(v);
            return r.Matches(t).Count;
        }

        public string CutLeft(string text, int length)
        {
            if (length >= 1)
            {
                int i;
                char str;
                if (text.Length < 0x19)
                {
                    return text;
                }
                if (text.Length <= length)
                {
                    return text;
                }
                if ((text.Length - length) >= 12)
                {
                    for (i = length; i < text.Length; i++)
                    {
                        str = text[i];
                        if (str.ToString().Equals(" "))
                        {
                            return (text.Substring(0, i) + "");
                        }
                    }
                    return text;
                }
                if ((text.Length - length) < 12)
                {
                    for (i = text.Length - 12; i < length; i++)
                    {
                        str = text[i];
                        if (str.ToString().Equals(" "))
                        {
                            return (text.Substring(0, i) + "");
                        }
                    }
                }
            }
            return text;
        }
    }
}

