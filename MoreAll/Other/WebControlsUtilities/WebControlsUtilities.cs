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
    public class WebControlsUtilities
    {
        public static void SetSelectedIndexInCheckBoxList(ref CheckBoxList ddl, string selectedvalue)
        {
            if (ddl != null)
            {
                selectedvalue = selectedvalue.Trim();
                int count = ddl.Items.Count;
                for (int i = 0; i < count; i++)
                {
                    if (ddl.Items[i].Value.Equals(selectedvalue))
                    {
                        ddl.SelectedIndex = i;
                    }
                }
            }
        }
        public static void SetSelectedIndexInDropDownList(ref DropDownList ddl, string selectedvalue)
        {
            if (ddl != null)
            {
                selectedvalue = selectedvalue.Trim();
                int count = ddl.Items.Count;
                for (int i = 0; i < count; i++)
                {
                    if (ddl.Items[i].Value.Equals(selectedvalue))
                    {
                        ddl.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
    }
}



