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
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Entity;
using Framework;
using Services;
using MoreAll;
using System.Xml;
using System.IO;
using System.Data.SqlClient;
using System.Linq;
using System.Globalization;


#region Url
public class Url
{
    public static string Url1(string Css, string Url, string ID1, string UrlName, string Name, string Alt, string Title)
    {
        return "<a  alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"   " + Css + " href='/" + Url + "/" + ID1 + "/" + RewriteURLNew.NameToTag(UrlName) + "'>" + Name + "</a>";
    }
    public static string Url2(string Css, string Url, string ID1, string ID2, string UrlName, string Name, string Alt, string Title)
    {
        return "<a alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"   " + Css + " href='/" + Url + "/" + ID1 + "/" + ID2 + "/" + RewriteURLNew.NameToTag(UrlName) + "'>" + Name + "</a>";
    }
    public static string Url3(string Css, string Url, string ID1, string ID2, string ID3, string UrlName, string Name, string Alt, string Title)
    {
        return "<a alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"   " + Css + " href='/" + Url + "/" + ID1 + "/" + ID2 + "/" + ID3 + "/" + RewriteURLNew.NameToTag(UrlName) + "'>" + Name + "</a>";
    }
    public static string Url4(string Css, string Url, string ID1, string ID2, string ID3, string ID4, string UrlName, string Name, string Alt, string Title)
    {
        return "<a alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"  " + Css + " href='/" + Url + "/" + ID1 + "/" + ID2 + "/" + ID3 + "/" + ID4 + "/" + RewriteURLNew.NameToTag(UrlName) + "'>" + Name + "</a>";
    }

    //------------ Hình ảnh/

    public static string Url_Images1(string Css, string Url, string ID1, string UrlName, string Images)
    {
        return "<a " + Css + " href='/" + Url + "/" + ID1 + "/" + RewriteURLNew.NameToTag(UrlName) + "'>" + Images + "</a>";
    }
    public static string Url_Images2(string Css, string Url, string ID1, string ID2, string UrlName, string Images)
    {
        return "<a " + Css + " href='/" + Url + "/" + ID1 + "/" + ID2 + "/" + RewriteURLNew.NameToTag(UrlName) + "'>" + Images + "</a>";
    }
    public static string Url_Images3(string Css, string Url, string ID1, string ID2, string ID3, string UrlName, string Images)
    {
        return "<a " + Css + " href='/" + Url + "/" + ID1 + "/" + ID2 + "/" + ID3 + "/" + RewriteURLNew.NameToTag(UrlName) + "'>" + Images + "</a>";
    }
    public static string Url_Images4(string Css, string Url, string ID1, string ID2, string ID3, string ID4, string UrlName, string Images)
    {
        return "<a " + Css + " href='/" + Url + "/" + ID1 + "/" + ID2 + "/" + ID3 + "/" + ID4 + "/" + RewriteURLNew.NameToTag(UrlName) + "'>" + Images + "</a>";
    }
}
#endregion
namespace MoreAll
{

    public class AddURL
    {
        public static string SeoURL(string inputstring)
        {
            if (inputstring.Length > 0)
            {
                return (RewriteURLNew.NameToTag(inputstring));
            }
            return (RewriteURLNew.NameToTag(inputstring));
        }

    }
    public class Hamdoisorachu
    {
        private static string Chu(string gNumber)
        {
            string result = "";
            switch (gNumber)
            {
                case "0":
                    result = "không";
                    break;
                case "1":
                    result = "một";
                    break;
                case "2":
                    result = "hai";
                    break;
                case "3":
                    result = "ba";
                    break;
                case "4":
                    result = "bốn";
                    break;
                case "5":
                    result = "năm";
                    break;
                case "6":
                    result = "sáu";
                    break;
                case "7":
                    result = "bảy";
                    break;
                case "8":
                    result = "tám";
                    break;
                case "9":
                    result = "chín";
                    break;
            }
            return result;
        }
        private static string Donvi(string so)
        {
            string Kdonvi = "";
            if (so.Equals("1"))
                Kdonvi = "";
            if (so.Equals("2"))
                Kdonvi = "nghìn";
            if (so.Equals("3"))
                Kdonvi = "triệu";
            if (so.Equals("4"))
                Kdonvi = "tỷ";
            if (so.Equals("5"))
                Kdonvi = "nghìn tỷ";
            if (so.Equals("6"))
                Kdonvi = "triệu tỷ";
            if (so.Equals("7"))
                Kdonvi = "tỷ tỷ";

            return Kdonvi;
        }
        private static string Tach(string tach3)
        {
            string Ktach = "";
            if (tach3.Equals("000"))
                return "";
            if (tach3.Length == 3)
            {
                string tr = tach3.Trim().Substring(0, 1).ToString().Trim();
                string ch = tach3.Trim().Substring(1, 1).ToString().Trim();
                string dv = tach3.Trim().Substring(2, 1).ToString().Trim();
                if (tr.Equals("0") && ch.Equals("0"))
                    Ktach = " không trăm lẻ " + Chu(dv.ToString().Trim()) + " ";
                if (!tr.Equals("0") && ch.Equals("0") && dv.Equals("0"))
                    Ktach = Chu(tr.ToString().Trim()).Trim() + " trăm ";
                if (!tr.Equals("0") && ch.Equals("0") && !dv.Equals("0"))
                    Ktach = Chu(tr.ToString().Trim()).Trim() + " trăm lẻ " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && dv.Equals("0"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && dv.Equals("5"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi lăm ";
                if (tr.Equals("0") && ch.Equals("1") && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = " không trăm mười " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && ch.Equals("1") && dv.Equals("0"))
                    Ktach = " không trăm mười ";
                if (tr.Equals("0") && ch.Equals("1") && dv.Equals("5"))
                    Ktach = " không trăm mười lăm ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi " + Chu(dv.Trim()).Trim() + " ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && dv.Equals("0"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi lăm ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười " + Chu(dv.Trim()).Trim() + " ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && dv.Equals("0"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười lăm ";
            }
            return Ktach;
        }
        public static string So_chu(double gNum)
        {
            if (gNum == 0)
                return "Không đồng";
            string lso_chu = "";
            string tach_mod = "";
            string tach_conlai = "";
            double Num = Math.Round(gNum, 0);
            string gN = Convert.ToString(Num);
            int m = Convert.ToInt32(gN.Length / 3);
            int mod = gN.Length - m * 3;
            string dau = "[+]";
            // Dau [+ , - ]
            if (gNum < 0)
                dau = "[-]";
            dau = "";
            // Tach hang lon nhat
            if (mod.Equals(1))
                tach_mod = "00" + Convert.ToString(Num.ToString().Trim().Substring(0, 1)).Trim();
            if (mod.Equals(2))
                tach_mod = "0" + Convert.ToString(Num.ToString().Trim().Substring(0, 2)).Trim();
            if (mod.Equals(0))
                tach_mod = "000";
            // Tach hang con lai sau mod :
            if (Num.ToString().Length > 2)
                tach_conlai = Convert.ToString(Num.ToString().Trim().Substring(mod, Num.ToString().Length - mod)).Trim();
            ///don vi hang mod
            int im = m + 1;
            if (mod > 0)
                lso_chu = Tach(tach_mod).ToString().Trim() + " " + Donvi(im.ToString().Trim());
            /// Tach 3 trong tach_conlai
            int i = m;
            int _m = m;
            int j = 1;
            string tach3 = "";
            string tach3_ = "";
            while (i > 0)
            {
                tach3 = tach_conlai.Trim().Substring(0, 3).Trim();
                tach3_ = tach3;
                lso_chu = lso_chu.Trim() + " " + Tach(tach3.Trim()).Trim();
                m = _m + 1 - j;
                if (!tach3_.Equals("000"))
                    lso_chu = lso_chu.Trim() + " " + Donvi(m.ToString().Trim()).Trim();
                tach_conlai = tach_conlai.Trim().Substring(3, tach_conlai.Trim().Length - 3);

                i = i - 1;
                j = j + 1;
            }
            if (lso_chu.Trim().Substring(0, 1).Equals("k"))
                lso_chu = lso_chu.Trim().Substring(10, lso_chu.Trim().Length - 10).Trim();
            if (lso_chu.Trim().Substring(0, 1).Equals("l"))
                lso_chu = lso_chu.Trim().Substring(2, lso_chu.Trim().Length - 2).Trim();
            if (lso_chu.Trim().Length > 0)
                lso_chu = dau.Trim() + " " + lso_chu.Trim().Substring(0, 1).Trim().ToUpper() + lso_chu.Trim().Substring(1, lso_chu.Trim().Length - 1).Trim() + " đồng chẵn.";
            return lso_chu.ToString().Trim();
        }
    }

    #region MoreAll
    public class MoreAll
    {
        public static string TrangThaiEnableRut(string enable)
        {
            if (enable.Trim().Equals("0"))
            {
                return "<span style='font-size:12px; background:red;padding: 4px;margin-right:3px;margin-left:5px;color:#fff;border-radius: 3px;font-weight: 600;'>Chưa duyệt</span>";
            }
            else if (enable.Trim().Equals("1"))
            {
                return "<span style='font-size:12px; background:#00a9d2;padding: 4px;margin-right:3px;margin-left:5px;color:#fff;border-radius: 3px;font-weight: 600;'>Đã duyệt</span>";
            }
            return "<span style='font-size:12px; background:red;padding: 4px;margin-right:3px;margin-left:5px;color:#fff;border-radius: 3px;font-weight: 600;'>Đã Hủy</span>";
        }
        public static string FormatDate_IDQR(object date)
        {
            return (Convert.ToDateTime(date).ToString("MMddyyhhmmss"));
        }
        /// <summary>
        /// Lấy ra thứ tự trong năm của tuần có chứa ngày nhập vào 
        /// với Culture mặc định là Culture hiện tại
        /// </summary>
        /// <param name="time">Ngày nhập vào</param>
        /// <returns>Trả về kiểu int là thứ tự của tuần trong năm</returns>
        /// //<%=GetWeekOrderInYear("2020-01-11") %>
        public static int GetWeekOrderInYear(string time)
        {
            CultureInfo myCI = CultureInfo.CurrentCulture;
            System.Globalization.Calendar myCal = myCI.Calendar;
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;

            return myCal.GetWeekOfYear(Convert.ToDateTime(time), myCWR, myFirstDOW);
        }
        public static string Update_setting(string str, string Value)
        {
            Entity.Setting obj = new Entity.Setting();
            obj.Lang = "VIE";
            obj.Properties = str;
            obj.Value = Value.ToString();
            SSetting.UPDATE(obj);
            return "";
        }
        public static string RunScriptFile(string fileName, bool blnShowMsg = true)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                //chi chay file script co duoi .txt, cac file co duoi sql va gan ma version duoc chay trong phan Upgrade Version
                return "ERROR";
            }
            string stLog = "";
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(Path.Combine(HttpContext.Current.Server.MapPath("/Uploads/sql"), fileName));
            }
            catch
            {
                return "ERROR";
            }

            string line = null;
            StringBuilder sql = new StringBuilder();

            using (SqlConnection dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                bool hasError = false;
                SqlCommand dbCmd = new SqlCommand();
                dbCmd.CommandType = CommandType.Text;
                dbCmd.Connection = dbConn;
                dbConn.Open();
                do
                {
                    if (sr == null)
                    {
                        break;
                    }
                    line = sr.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    if (line.Trim().ToUpper() == "GO" & sql.Length > 0)
                    {
                        dbCmd.CommandText = sql.ToString();
                        try
                        {
                            stLog = stLog + dbCmd.CommandText + Environment.NewLine;
                            dbCmd.ExecuteNonQuery();
                        }
                        catch
                        {
                        }
                        sql.Length = 0;
                    }
                    else
                    {
                        sql.AppendLine(line.Trim());
                    }
                } while (!(line == null));
                //cho lenh cuoi cung
                if (sql.Length > 0)
                {
                    try
                    {
                        dbCmd.CommandText = sql.ToString();
                        stLog = stLog + dbCmd.CommandText + Environment.NewLine;
                        dbCmd.ExecuteNonQuery();
                    }
                    catch
                    {
                    }
                }
                dbConn.Close();
                if ((sr != null))
                {
                    sr.Close();
                }
            }
            return stLog;
        }

        #region Romove HTML Tag
        public static string RemoveHTMLTags(string content)
        {
            var cleaned = string.Empty;
            try
            {
                StringBuilder textOnly = new StringBuilder();
                using (var reader = XmlNodeReader.Create(new System.IO.StringReader("<xml>" + content + "</xml>")))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Text)
                            textOnly.Append(reader.ReadContentAsString());
                    }
                }
                cleaned = textOnly.ToString();
            }
            catch
            {
                string textOnly = string.Empty;
                Regex tagRemove = new Regex(@"<[^>]*(>|$)");
                Regex compressSpaces = new Regex(@"[\s\r\n]+");
                textOnly = tagRemove.Replace(content, string.Empty);
                textOnly = compressSpaces.Replace(textOnly, " ");
                cleaned = textOnly;
            }

            return cleaned;
        }
        #endregion

        #region #
        public static string RequestUrl(string url)//Request.Url.ToString() ví dụ: MoreAll.RequestUrl(Request.Url.ToString());
        {
            string str = url;
            int index = str.IndexOf('?');
            if (index >= 0)
            {
                str = str.Substring(0, index);
            }
            return str;
        }
        public static string NamNam(object date)
        {
            return (Convert.ToDateTime(date).ToString("yyyy"));
        }
        public static string Date_ngay(object date)
        {
            return (Convert.ToDateTime(date).ToString("dd"));
        }
        public static string Date_Thangs(object date)
        {
            return (Convert.ToDateTime(date).ToString("MM"));
        }
        public static string Date_Thang(object date)
        {
            return Thang((Convert.ToDateTime(date).ToString("MM")));
        }
        private static string Thang(string gNumber)
        {
            string result = "";
            switch (gNumber)
            {
                case "01":
                    result = "JAN";
                    break;
                case "02":
                    result = "Feb";
                    break;
                case "03":
                    result = "Mar";
                    break;
                case "04":
                    result = "Apr";
                    break;
                case "05":
                    result = "May";
                    break;
                case "06":
                    result = "Jun";
                    break;
                case "07":
                    result = "Jul";
                    break;
                case "08":
                    result = "Aug";
                    break;
                case "09":
                    result = "Sep";
                    break;
                case "10":
                    result = "Oct";
                    break;
                case "11":
                    result = "Now";
                    break;
                case "12":
                    result = "Dec";
                    break;
            }
            return result;
        }
        public static string FormatDate(object date)
        {
            return (Convert.ToDateTime(date).ToString("dd/MM/yyyy hh:mm"));
        }
        public static string FormatDates(object date)
        {
            return (Convert.ToDateTime(date).ToString("dd/MM/yyyy"));
        }
        public static string Date(object date)
        {
            return (Convert.ToDateTime(date).ToString("dd/MM/yyyy"));
        }
        public static string IDDate(object date)
        {
            return (Convert.ToDateTime(date).ToString("ddMMyyyy"));
        }
        public static string Date_Time(string DateHientai, string DateKetthuc)
        {
            TimeSpan ist = Convert.ToDateTime(DateKetthuc) - Convert.ToDateTime(DateHientai);
            int day = Convert.ToInt32(ist.Days) <= 0 ? 0 : Convert.ToInt32(ist.Days);
            int Hours = Convert.ToInt32(ist.Hours);
            int TotalMinutes = Convert.ToInt32(ist.Minutes);
            return day.ToString() + "Ngày : " + Hours.ToString() + " Giờ :" + TotalMinutes.ToString() + " Phút ";
        }
        public static string VipDateTime(string DateHientai, string DateKetthuc)
        {
            TimeSpan ist = Convert.ToDateTime(DateKetthuc) - Convert.ToDateTime(DateHientai);
            int day = Convert.ToInt32(ist.Days) <= 0 ? 0 : Convert.ToInt32(ist.Days);
            int Hours = Convert.ToInt32(ist.Hours);
            int TotalMinutes = Convert.ToInt32(ist.Minutes);
            return day.ToString() + " Ngày";
        }
        #endregion

        #region ImageAdmin
        public static string ChilGood(string enable)
        {
            if (enable.Trim().Equals("0"))
            {
                return "<img src='/Uploads/pic/web/icon/action_delete.jpg' border='0'>";
            }
            return "<img src='/Uploads/pic/web/icon/ChilGood.png'  border='0'>";
        }
        public static string Enable(string enable)
        {
            if (enable.Trim().Equals("0"))
            {
                return "<i class=\"icon-check-empty\"></i>";
            }
            return "<i class=\"icon-check\"></i>";
        }
        public static string Duyet(string enable)
        {
            if (enable.Trim().Equals("0"))
            {
                return "<i class=\"fas fa-ellipsis-h\" style=\"width: 1.25rem; height: 1.25rem;\" title=\"Chờ xét duyệt\"></i>";
            }
            return "<span style='color:red'>Đã duyệt</span>";
        }

        public static string Enable_Date(string enable)
        {
            if (enable.Trim().Equals("0"))
            {
                return "";
            }
            return "<img src='/Uploads/pic/web/icon/badvote.gif'  border='0'>";
        }

        #endregion

        #region Style_Width Style_Height
        public static string Style_Width(string width)
        {
            if (width.Length > 0)
            {
                if (width.Equals("0"))
                {
                    return "width:auto";
                }
                else
                {
                    return "width:" + width + "px";
                }
            }
            return "";
        }
        public static string Style_Height(string height)
        {
            if (height.Length > 0)
            {
                if (height.Equals("0"))
                {
                    return "height:auto";
                }
                else
                {
                    return "height:" + height + "px";
                }
            }
            return "";
        }
        #endregion

        #region Substring
        public static string Substring_Length_setup(string number, string input, int length)
        {
            if (number.Length > 0)
            {
                if (number.Equals("0"))
                {
                    return input;
                }
                else
                {
                    if (input.Length <= length)
                    {
                        return input;
                    }
                    else
                    {
                        return input.Substring(0, length) + "...";
                    }
                }
            }
            return "";
        }
        public static string Substring(string input, int length)
        {
            if (input.Length <= length)
            {
                return input;
            }
            else
            {
                return input.Substring(0, length) + "...";
            }
        }
        #endregion

        #region language
        public static string Language
        {
            get
            {
                string language = "VIE";
                if (System.Web.HttpContext.Current.Session["language"] != null)
                {
                    language = System.Web.HttpContext.Current.Session["language"].ToString();
                }
                else
                {
                    System.Web.HttpContext.Current.Session["language"] = language;
                }
                return language;
            }
        }
        public static string LanguageAdmin
        {
            get
            {
                string language = Captionlanguage.Language;
                if (System.Web.HttpContext.Current.Session["lang"] != null)
                {
                    language = System.Web.HttpContext.Current.Session["lang"].ToString();
                }
                return language;
            }
        }
        #endregion

        #region Request Cookies Session
        public static string GetCache(string NameCache, string DauVaoGiuLieu)
        {
            string ketQua = "";
            if (HttpContext.Current.Cache[NameCache] != null)
            {
                ketQua = HttpContext.Current.Cache[NameCache].ToString();
            }
            else
            {
                ketQua = DauVaoGiuLieu;
                HttpContext.Current.Cache[NameCache] = ketQua;
            }
            return ketQua;
        }
        public static string GetCookies(string name)
        {
            if (HttpContext.Current.Request.Cookies[name] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.Cookies[name].Value;
        }
        public static void SetCookie(string name, string val)
        {
            if (HttpContext.Current.Request.Cookies[name] != null)
            {
                HttpContext.Current.Request.Cookies[name].Value = val;
                HttpContext.Current.Response.Cookies[name].Value = val;
            }
            else
            {
                HttpCookie cookie = new HttpCookie(name);
                cookie.Value = val;
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
        public static string GetParamValue(string var_name)
        {
            if (HttpContext.Current.Request.QueryString[var_name] != null)
            {
                return HttpContext.Current.Request.QueryString[var_name].Trim();
            }
            return "";
        }
        public static string CurrentModuleCode
        {
            get
            {
                return GetParamValue("u");
            }
        }
        public static void SetCookie(string name, string val, int minutes)
        {
            if (HttpContext.Current.Request.Cookies[name] != null)
            {
                HttpContext.Current.Request.Cookies[name].Value = val;
                HttpContext.Current.Request.Cookies[name].Expires = DateTime.Now.AddMinutes((double)minutes);
                HttpContext.Current.Response.Cookies[name].Value = val;
                HttpContext.Current.Response.Cookies[name].Expires = DateTime.Now.AddMinutes((double)minutes);
            }
            else
            {
                HttpCookie cookie = new HttpCookie(name);
                cookie.Value = val;
                cookie.Expires = DateTime.Now.AddMinutes((double)minutes);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
        public static void SetCookie_AddDays(string name, string val, int Ngay)
        {
            if (HttpContext.Current.Request.Cookies[name] != null)
            {
                HttpContext.Current.Request.Cookies[name].Value = val;
                HttpContext.Current.Request.Cookies[name].Expires = DateTime.Now.AddDays((double)Ngay);
                HttpContext.Current.Response.Cookies[name].Value = val;
                HttpContext.Current.Response.Cookies[name].Expires = DateTime.Now.AddDays((double)Ngay);
            }
            else
            {
                HttpCookie cookie = new HttpCookie(name);
                cookie.Value = val;
                cookie.Expires = DateTime.Now.AddDays((double)Ngay);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
        public static void SetSession(string name, string val)
        {
            HttpContext.Current.Session[name] = val;
        }
        public static void DestroySession(string name)
        {
            if (HttpContext.Current.Session[name] != null)
            {
                HttpContext.Current.Session[name] = null;
            }
        }
        public static void DelCookie(string name)
        {
            if (HttpContext.Current.Request.Cookies[name] != null)
            {
                HttpContext.Current.Request.Cookies[name].Expires = DateTime.Now.AddDays(-1.0);
                HttpContext.Current.Response.Cookies[name].Expires = DateTime.Now.AddDays(-1.0);
            }
        }
        public static string GetCookie(string name)
        {
            if (HttpContext.Current.Request.Cookies[name] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.Cookies[name].Value;
        }
        public static string GetSession(string name)
        {
            if (HttpContext.Current.Session[name] != null)
            {
                return HttpContext.Current.Session[name].ToString();
            }
            return "";
        }
        #endregion
    }
    #endregion

    #region MoreNoimg
    public class MoreNoimg
    {
        public static string Noimg(string Width, string Height)
        {
            string path = Other.Giatri("NoImages");
            return "<img src='" + path.ToString() + "' style='border:1px solid #9EC3CB;" + MoreAll.Style_Width(Width) + ";" + MoreAll.Style_Height(Height) + "'>";
        }
    }
    #endregion

    #region MoreImage
    public class MoreImage
    {
        public static string Image(string image)
        {
            if (image.Length > 0)
            {
                return ("<img src='" + image + "' style='border:1px solid #9EC3CB;' width=100px  height=65px>");
            }
            return MoreNoimg.Noimg("100", "65");
        }
        public static string DisplayImage(string image)
        {
            if (image.Length > 0)
            {
                return ("<img src='" + image + "' style='border:1px solid #9EC3CB;' width=100px  height=65px>");
            }
            return MoreNoimg.Noimg("100", "65");
        }
        public static string Image_width_height_gallery(string image, string width, string height, string title)
        {
            if (image.Length > 0)
            {
                return "<a href=\"" + image + "\" rel=\"gallery\"   title=\"" + title + "\"  class=\"pirobox_gall\"><img src='" + image + "'  style='" + MoreAll.Style_Width(width) + ";" + MoreAll.Style_Height(height) + "' border=0></a>";
            }
            return MoreNoimg.Noimg(width, height);
        }
        public static string Image_width_height(string image, string width, string height)
        {
            if (image.Length > 0)
            {
                return "<img src='" + image + "' style='" + MoreAll.Style_Width(width) + ";" + MoreAll.Style_Height(height) + "' border=0>";
            }
            return MoreNoimg.Noimg(width, height);
        }
        public static string Image_width_height_Title_Alt(string image, string width, string height, string Title, string Alt)
        {
            if (image.Length > 0)
            {
                if (Alt.Length > 0)
                {
                    return "<img   src='" + image + "' style='" + MoreAll.Style_Width(width) + ";" + MoreAll.Style_Height(height) + "'  alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"    border=0>";
                }
                else
                {
                    return "<img   src='" + image + "' style='" + MoreAll.Style_Width(width) + ";" + MoreAll.Style_Height(height) + "'  alt=\"" + Title.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"    border=0>";
                }
            }
            return MoreNoimg.Noimg(width, height);
        }
        public static string Image_Title_Alt(string image, string Title, string Alt)
        {
            if (image.Length > 0)
            {
                return "<img   src='" + image + "' alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"    border=0>";
            }
            return MoreNoimg.Noimg("0", "0");
        }
        public static string Image_width_height_Title_Alt_css(string css, string image, string width, string height, string Title, string Alt)
        {
            if (image.Length > 0)
            {
                return "<img class=\"" + css + "\"  src='" + image + "' style='" + MoreAll.Style_Width(width) + ";" + MoreAll.Style_Height(height) + "'  alt=\"" + Alt.Replace("\"", "&rdquo;") + "\"  title=\"" + Title.Replace("\"", "&rdquo;") + "\"    border=0>";
            }
            return MoreNoimg.Noimg(width, height);
        }

    }
    #endregion

    #region Email
    public class Email
    {
        public static string email()
        {
            string Chuoi = Other.Giatri("sysemail");
            return Chuoi.ToString();
        }
        public static string password()
        {
            string Chuoi = Other.Giatri("sysemailpass");
            return Chuoi.ToString();
        }
        public static string port()
        {
            string Chuoi = Other.Giatri("smtpport");
            return Chuoi.ToString();
        }
        public static string host()
        {
            string Chuoi = Other.Giatri("smtp");
            return Chuoi.ToString();
        }
    }
    #endregion

    #region Others
    public class Other
    {
        public static string Giatri(string giatri)
        {
            string item = "";
            List<Entity.Setting> str = SSetting.Name_Text("SELECT * FROM Setting WHERE Properties='" + giatri + "' and lang='" + MoreAll.Language + "' ");
            if (str.Count >= 1)
            {
                item = str[0].Value;
            }
            return item.ToString();
        }
        public static string GiatriOll(string giatri)
        {
            string item = "";
            List<Entity.Setting> str = SSetting.GETBYALL(MoreAll.Language);
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == giatri)
                    {
                        item = its.Value;
                    }
                }
            }
            return item.ToString();
        }
        public static string website()
        {
            string Facebooks = Other.Giatri("website");
            return Facebooks.ToString();
        }
        public static string TitleWebname()
        {
            string Titlename = Other.Giatri("webname");
            return Titlename.ToString();
        }
        public static string Popup_TrangThai()
        {
            string Popup = Other.Giatri("Popup_TrangThai");
            return Popup.ToString();
        }
        public static string Facebook_comments(string Url, string Width)
        {
            string Facebooks = "";
            {
                Facebooks += " <div class='fb-comments' data-href='" + Url + "' data-width=" + Width + "  data-num-posts='2'></div>";
                Facebooks += " <div class='addthis_toolbox addthis_default_style '><a class='addthis_button_preferred_1'></a><a class='addthis_button_preferred_2'></a><a class='addthis_button_preferred_3'></a><a class='addthis_button_preferred_4'></a><a class='addthis_button_compact'></a><a class='addthis_counter addthis_bubble_style'></a></div><script type='text/javascript' src='http://s7.addthis.com/js/250/addthis_widget.js#pubid=xa-4e2a6c617ab55718'></script>";
            }
            return Facebooks.ToString();
        }
        #region[Hienthihinhcay]
        public static string Hienthihinhcay(string name, string treecode)
        {
            string chuoi = "<img src='Resources/admin/images/Speerio_folderopen_edit.gif' border=0>";
            if (treecode.ToString().Trim().Length > 50)
            {
                chuoi = "<span style='margin-left:100px'><img src='Resources/admin/images/sub.gif' border=0></span>";
            }
            else if (treecode.ToString().Trim().Length > 45)
            {
                chuoi = "<span style='margin-left:90px'><img src='Resources/admin/images/sub.gif' border=0></span>";
            }
            else if (treecode.ToString().Trim().Length > 40)
            {
                chuoi = "<span style='margin-left:80px'><img src='Resources/admin/images/sub.gif' border=0></span>";
            }
            else if (treecode.ToString().Trim().Length > 35)
            {
                chuoi = "<span style='margin-left:70px'><img src='Resources/admin/images/sub.gif' border=0></span>";
            }
            else if (treecode.ToString().Trim().Length > 30)
            {
                chuoi = "<span style='margin-left:60px'><img src='Resources/admin/images/sub.gif' border=0></span>";
            }
            else if (treecode.ToString().Trim().Length > 25)
            {
                chuoi = "<span style='margin-left:50px'><img src='Resources/admin/images/sub.gif' border=0></span>";
            }
            else if (treecode.ToString().Trim().Length > 20)
            {
                chuoi = "<span style='margin-left:40px'><img src='Resources/admin/images/sub.gif' border=0><span>";
            }
            else if (treecode.ToString().Trim().Length > 15)
            {
                chuoi = "<span style='margin-left:30px'><img src='Resources/admin/images/sub.gif' border=0></span>";
            }
            else if (treecode.ToString().Trim().Length > 10)
            {
                chuoi = "<span style='margin-left:20px'><img src='Resources/admin/images/sub.gif' border=0></span>";
            }
            else if (treecode.ToString().Trim().Length > 5)
            {
                chuoi = "<span style='margin-left:10px'><img src='Resources/admin/images/sub.gif' border=0></span>";
            }
            else
            {
                chuoi = chuoi;
            }
            return chuoi = chuoi + "&nbsp;" + name;
        }
        #endregion
    }
    #endregion


    #region OnOffs
    public class OnOffs
    {
        public static string OnOff()
        {
            string Pages = Other.Giatri("OnOff");
            return Pages.ToString();
        }
        public static string StatusOnOff()
        {
            string Pages = Other.Giatri("StatusOnOff");
            return Pages.ToString();
        }
    }
    #endregion

    #region Ngan_Luong
    public class Ngan_Luong
    {
        public static string CheckOutUrl()
        {
            string stt = Other.Giatri("CheckOutUrl");

            return stt.ToString();
        }
        public static string MerchantSiteCode()
        {
            string stt = Other.Giatri("MerchantSiteCode");
            return stt.ToString();
        }
        public static string Receive()
        {
            string stt = Other.Giatri("Receive");
            return stt.ToString();
        }
        public static string PasswordNL()
        {
            string stt = Other.Giatri("PasswordNL");
            return stt.ToString();
        }

    }
    #endregion
}