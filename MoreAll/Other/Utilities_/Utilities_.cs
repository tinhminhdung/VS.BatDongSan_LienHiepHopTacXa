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

namespace MoreAll
{
    public class Utilities_
    {
        private static string label(string id, string lang)
        {
            return GetControlText(id, lang);
        }

        public static string GetControlText(string id, string fld)
        {
            return Captionlanguage.GetLabel(id, fld);
        }

        public static void LoadDropdownlistCheckItems(ref DropDownList ddl, string lang)
        {
            ddl.Items.Add(new ListItem(label("l_alls", lang), "-1"));
            ddl.Items.Add(new ListItem(label("l_checked", lang), "1"));
            ddl.Items.Add(new ListItem(label("l_unchecked", lang), "0"));
        }

        public static void LoadDropdownlistDisplayItems(ref DropDownList ddl, string lang)
        {
            ddl.Items.Add(new ListItem(label("l_alls", lang), "-1"));
            ddl.Items.Add(new ListItem(label("l_show", lang), "1"));
            ddl.Items.Add(new ListItem(label("lt_hide", lang), "0"));
        }

        public static void LoadDropdownlistDisplayItems1(ref DropDownList ddl, string lang)
        {
            ddl.Items.Add(new ListItem(label("l_show", lang), "1"));
            ddl.Items.Add(new ListItem(label("lt_hide", lang), "0"));
        }
    }
}




