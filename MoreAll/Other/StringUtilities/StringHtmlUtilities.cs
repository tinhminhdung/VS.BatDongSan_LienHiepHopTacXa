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
    public class StringHtmlUtilities
    {
        public static string ExtractDomainNameFromURL(string Url)
        {
            if (!Url.Contains("://"))
            {
                Url = "http://" + Url;
            }
            return new Uri(Url).Host;
        }

        public static string ExtractDomainNameFromURL2(string Url)
        {
            if (Url.Contains("://"))
            {
                Url = Url.Split(new string[] { "://" }, 2, StringSplitOptions.None)[1];
            }
            return Url.Split(new char[] { '/' })[0];
        }

        public static string ExtractDomainNameFromURL3(string Url)
        {
            return Regex.Replace(Url, @"^([a-zA-Z]+:\/\/)?([^\/]+)\/.*?$", "$2");
        }

        public static string removehtmlcommenttag(string t)
        {
            t = Regex.Replace(t, @"<!-- [a-zA-Z\/][^>]* -->", " ", RegexOptions.IgnoreCase);
            return t;
        }

        public static string removehtmlscripttag(string t)
        {
            t = Regex.Replace(t, @"<script[a-zA-Z\/][^>]*</script>", " ", RegexOptions.IgnoreCase);
            return t;
        }

        public static string removehtmltag(string t)
        {
            t = Regex.Replace(t, @"<[a-zA-Z\/][^>]*>", " ", RegexOptions.IgnoreCase);
            return t;
        }
    }
}

