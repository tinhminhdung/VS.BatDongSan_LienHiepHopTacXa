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
using System.IO;
using System.Collections.Generic;
using Framework;
using Entity;

namespace MoreAll
{
    public class Captionlanguage
    {
        public static string SetLanguage()
        {
            string language = Captionlanguage.Language;
            if (System.Web.HttpContext.Current.Session["language"] != null)
            {
                return System.Web.HttpContext.Current.Session["language"].ToString();
            }
            else
            {
                System.Web.HttpContext.Current.Session["language"] = language;
                return System.Web.HttpContext.Current.Session["language"].ToString();
            }
            return Language;
        }

        public static string Language
        {
            get
            {
                try
                {
                    return Alllang();
                }
                catch (Exception)
                {
                    return "VIE";
                }
            }
        }

        public static string Alllang()
        {
            try
            {
                FLan DB = new FLan();
                List<Lans> table = DB.NORMAL();
                if (table.Count > 0)
                {
                    return table[0].VLAN_ID;
                }
                else return "VIE";
            }
            catch (Exception)
            {
                return "VIE";
            }
        }

        private static bool CheckLanguage(string id, Hashtable hslang)
        {
            return hslang.Contains(id);
        }

        public static string GetLabel(string id, string fld)
        {
            if (fld.Trim().Length < 1)
            {
                fld = Language;
            }
            id = id.Trim().ToLower();
            Hashtable hslang = new Hashtable();
            hslang = LoadLanguageList(fld);
            if (CheckLanguage(id, hslang).Equals(true))
            {
                return hslang[id].ToString();
            }
            return "";
        }

        public static Hashtable LoadLanguageList(string lang)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "/Resources/temp/" + lang + ".xml");
            Hashtable htblang = new Hashtable();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                htblang.Add(ds.Tables[0].Rows[i]["ID"].ToString().Trim().ToLower(), ds.Tables[0].Rows[i]["VALUE"].ToString());
            }
            return htblang;
        }
        public static DataTable LoadLanguageList_(string lang)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "/Resources/temp/" + lang + ".xml");
            return ds.Tables[0];
        }
        public static void UpdateLanguageList(string id, string lang, string newvalue)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "/Resources/temp/" + lang + ".xml");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["ID"].Equals(id))
                {
                    ds.Tables[0].Rows[i]["VALUE"] = newvalue;
                    break;
                }
            }
            ds.WriteXml(AppDomain.CurrentDomain.BaseDirectory + "/Resources/temp/" + lang + ".xml");
        }

        public static void WrtileLanguage(string old_xml_lang, string new_xml_lang)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "/Resources/temp/" + old_xml_lang + ".xml");
            ds.WriteXml(AppDomain.CurrentDomain.BaseDirectory + "/Resources/temp/" + new_xml_lang + ".xml");
        }
    }
}
