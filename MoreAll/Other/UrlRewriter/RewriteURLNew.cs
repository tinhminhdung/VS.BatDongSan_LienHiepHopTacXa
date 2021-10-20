using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MoreAll
{
    public class RewriteURLNew
    {
        public static string NameToTag(string strName)
        {
            string strReturn = strName.Trim().ToLower();
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            strReturn = Regex.Replace(strReturn, "[^\\w\\s-]", string.Empty);
            string strFormD = strReturn.Normalize(System.Text.NormalizationForm.FormD);
            strReturn = regex.Replace(strFormD, string.Empty).Replace("đ", "d");
            strReturn = Regex.Replace(strReturn, "(-+)", " ");
            strReturn = Regex.Replace(strReturn, "(_+)", " ");
            strReturn = Regex.Replace(strReturn.Trim(), "( +)", "-");
            strReturn = Regex.Replace(strReturn.Trim(), "(?+)", "");
			strReturn = Regex.Replace(strReturn.Trim(), " ", "");
            strReturn = GetContent(strReturn, 150);
            return strReturn;
        }

        public static string NameSearch(string strName)
        {
            string strReturn = strName.Trim().ToLower();
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            strReturn = Regex.Replace(strReturn, "[^\\w\\s-]", string.Empty);
            string strFormD = strReturn.Normalize(System.Text.NormalizationForm.FormD);
            strReturn = regex.Replace(strFormD, string.Empty).Replace("đ", "d");
            strReturn = Regex.Replace(strReturn, "(-+)", " ");
            strReturn = Regex.Replace(strReturn, "(_+)", " ");
            strReturn = Regex.Replace(strReturn.Trim(), "( +)", "-");
            strReturn = Regex.Replace(strReturn.Trim(), "(?+)", "");
			strReturn = Regex.Replace(strReturn.Trim(), " ", "");
            strReturn = GetContent(strReturn, 150);
            return strReturn.Replace("-", " ");
        }
        

        #region GetContent
        public static string GetContent(object String)
        {
            return String != null && String.ToString().Length > 0 ? String.ToString() : "";
        }
        public static string GetContent(string String, int Length)
        {
            string strReturn = String;
            if (String.Length > Length && String.Length - Length > 5)
            {
                try
                {
                    strReturn = String.Substring(0, String.IndexOf(" ", Length)) + "...";
                }
                catch
                {
                    strReturn = String;
                }
            }
            return strReturn;
        }
        #endregion
    }
}