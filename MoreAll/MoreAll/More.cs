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
using Framework;
using System.Collections.Generic;
using Services;
using Entity;

namespace MoreAll
{
    // Bảng danh mục Modul - Menu
    //1, Nhóm tin tức
    //2, Danh sách tin tức
    //NewsFooter nhớm 3, danh sách 4
    //Allbum  nhóm 5 , danh sách 6
    //Video nhóm 7, danh sách 8
    //Download 10
    //GioiThieu 11
    //Faq 12
    //Dichvu 13
    //podust
    //20 Nhóm sp
    //21 danh sách sản phẩm
    //23 hãng
    //24 giá
    //25 nhả sản xuất
    //26 mầu sắc
    //27 kich thước

    public class More
    {

        #region Ky Capp
        public static string VP = "VP";//Vi phạm bản quyền
        public static string TT = "TT";//Vi phạm bản quyền


        public static string CO = "CO";//Top menu
        public static string SI = "SI";//Bootomenu

        public static string IF = "IF";//Menu chính
        public static string HG = "HG";//Menu chính
        public static string MN = "MN";//Menu chính
        public static string BM = "BM";//Top menu
        public static string TM = "TM";//Bootomenu

        public static string CS = "CS";//Cơ sở và lớp
        public static string NS = "NS";// Nhà trường
        public static string BE = "BE";//Cho bé yêu
        public static string MB = "MB";//Cho bố mẹ
        public static string GT = "GT";//Học và giải trí
        public static string SC = "SC";// Nhà trường
        public static string PR = "PR";//Sản phẩm
        public static string HA = "HA";//Hãng Sản phẩm
        public static string KG = "KG";//Khoảng giá Sản phẩm
        public static string SM = "SM";//Sitemap
        public static string AB = "AB";//AllBum
        public static string VD = "VD";//Video 
        public static string YA = "YA";//yahoo 
        public static string AD = "AD";//Advertisings 
        public static string VO = "VO";//Vote 
        #endregion

        #region LoadMenu
        public static List<Entity.Menu> LoadMenu(string ID, string lang, string link, string capp)
        {
            return _LoadMenu(ID, lang, link, capp);
        }

        private static List<Entity.Menu> _LoadMenu(string ID, string lang, string link, string capp)
        {
            if (link.IndexOf("tin-tuc") > -1)
            {
                capp = NS;
                ID = "-1";
            }
            else if (link.IndexOf("san-pham") > -1)
            {
                capp = PR;
                ID = "-1";
            }
            else if (link.IndexOf("thu-vien-video") > -1)
            {
                capp = VD;
                ID = "-1";
            }
            else if (link.IndexOf("thu-vien-anh") > -1)
            {
                capp = AB;
                ID = "-1";
            }
            return SMenu.LOAD_CATESPARENT_ID(capp, lang, ID, "1");
        }

        public static string MenuLink(string capp, string Type, string ID, string name, string link, string KieuShow)
        {
            switch (capp)
            {
                case "NS":
                    return ("/" + name + ".html");
                case "PR":
                    return ("/" + name + ".html");
                case "AB":
                    return ("/" + name + ".html");
                case "VD":
                    return ("/" + name + ".html");
            }
            if (Type.Trim().Equals("1"))
            {
                return ("/" + name + ".html");
            }
            if (Type.Equals("2"))
            {
                return ("/" + link).Replace("//", "/");
            }
            return link;
        }
        #endregion

        #region AllMenu
        public static string Sup_Parent_ID(string cid)
        {
            List<Entity.Menu> dt = SMenu.Parent_ID(cid);
            if (dt.Count > 0)
            {
                return "1";
            }
            return "";
        }

        public static string Sub_Parent_ID(string cid)
        {
            List<Entity.Menu> dt = SMenu.Parent_ID(cid);
            if (dt.Count > 0)
            {
                return (dt[0].ID.ToString());
            }
            return "";
        }

        public static string MenuDacap(string cid)
        {
            string str = "";
            List<Entity.Menu> dt = SMenu.GETBYID(cid);
            if (dt.Count > 0)
            {
                if (dt[0].Parent_ID.ToString() == "-1")
                {
                    return dt[0].ID.ToString();
                }
                else
                {
                    str = dt[0].Parent_ID.ToString();
                    return MenuDacap(str);
                }
            }
            return str;
        }

        public static string Sub_ID(string cid)
        {
            List<Entity.Menu> dt = SMenu.GETBYID(cid);
            if (dt.Count > 0)
            {
                return (dt[0].Parent_ID.ToString());
            }
            return "";
        }

        public static string Sub_Menu(string Capp, string cid)
        {
            string submn = cid;
            List<Entity.Menu> dt = SMenu.DETAIL_CAPP_PARENTID(cid, Capp);
            for (int i = 0; i < dt.Count; i++)
            {
                submn = submn + "," + Sub_Menu(Capp, dt[i].ID.ToString());
            }
            return submn;
        }
        #endregion
        public static string TangNameProducts(string TangName) //// Tăng và giảm thứ tự trong ô txtOrders
        {
            List<Entity.Products> table = SProducts.Name_Text("SELECT top 1 * FROM products where TangName=N'" + TangName + "'");
            if (table.Count > 0)
            {
                return table[0].icid.ToString();
            }
            return "";
        }

        public static string PriceTu(string id)
        {
            string str = "";
            List<Entity.Menu> table = SMenu.GETBYID(id);
            if (table.Count > 0)
            {
                str += table[0].Link.ToString();
            }
            return str.ToString();
        }
        public static string Level_ID(string level, string capp)
        {
            string str = "";
            List<Entity.Menu> table = SMenu.Name_Text("SELECT * FROM Menu where capp='" + capp + "' and Level='" + level + "' order by level,Orders asc");
            if (table.Count > 0)
            {
                str = table[0].ID.ToString();
            }
            return str;
        }
        public static string PriceDen(string id)
        {
            string str = "";
            List<Entity.Menu> table = SMenu.GETBYID(id);
            if (table.Count > 0)
            {
                str += table[0].Styleshow.ToString();
            }
            return str.ToString();
        }

        public static string LoadNav(int ID, ref string nav)
        {
            var item = SMenu.Name_Text("select * from Menu where id=" + ID + "");
            if (item != null)
            {
                if (item[0].Parent_ID == -1)
                {
                    nav = " <div class='Namemenu'>" + item[0].Name + "</div>" + nav;
                }
                else
                {
                    nav = " <div class='Namemenu'><span> >> </span>" + item[0].Name + "</div>  " + nav;
                }
                if (item[0].Parent_ID != -1)
                {
                    LoadNav(Convert.ToInt32(item[0].Parent_ID), ref nav);
                }
            }
            return "<div class=\"menun\"><div class='Namemenu'><span class='pmgoc'>Phân mục gốc</span> : </div>" + nav + "</div>";
        }

        public static string DetaiName(string cid)
        {
            List<Entity.Menu> dt = SMenu.GETBYID(cid);
            if (dt.Count > 0)
            {
                return (dt[0].Name.ToString());
            }
            return "0";
        }

        public static int STATUS(string ID) //// Tăng và giảm thứ tự trong ô txtOrders
        {
            try
            {
                List<Entity.Menu> table = SMenu.GETBYID(ID);
                if (table.Count > 0)
                {
                    return (Convert.ToInt32(table[table.Count - 0].Status.ToString()) + 1);
                }
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static string Name(string ID) //// Tăng và giảm thứ tự trong ô txtOrders
        {
            List<Entity.Menu> table = SMenu.GETBYID(ID);
            if (table.Count > 0)
            {
                return table[0].Name.ToString();
            }
            return "0";
        }

        public static string TangNameicid(string TangName) //// Tăng và giảm thứ tự trong ô txtOrders
        {
            List<Entity.MenuID> table = SMenu.M_TangNameicid("M_TangNameicid", TangName);
            if (table.Count > 0)
            {
                return table[0].ID.ToString();
            }
            return "0";
        }

        public static string TangNameNewsicid(string TangName) //// Tăng và giảm thứ tự trong ô txtOrders
        {
            List<Entity.News> table = SNews.Name_Text("SELECT * FROM [News]  where TangName=N'" + TangName + "'");
            if (table.Count > 0)
            {
                return table[0].icid.ToString();
            }
            return "0";
        }


        public static string TopMainMenu(string Capp, string lang, string seperator)
        {
            string menu = "";
            List<Entity.Menu> dt = SMenu.capp_Lang_Parent_ID_Status(Capp, lang, "-1", "1");
            for (int i = 0; i < dt.Count; i++)
            {
                string opentype = "";
                if (dt[i].Type.ToString().Equals("1"))
                {
                    opentype = "target=_blank";
                }
                if (i < (dt.Count - 1))
                {
                    menu += "<a href='" + dt[i].Link.ToString() + "'  " + opentype + ">" + dt[i].Name.ToString() + "</a>" + seperator;
                }
                else
                {
                    menu += "<a  href='" + dt[i].Link.ToString() + "'  " + opentype + ">" + dt[i].Name.ToString() + "</a>";
                }
            }
            return menu;
        }

        public static int GetNextCateOrder(string app, string lan, string Parent_ID) //// Tăng và giảm thứ tự trong ô txtOrders
        {
            try
            {
                List<Entity.Menu> table = SMenu.CATE_LOADALL_NEWS(app, lan, Parent_ID);
                if (table.Count > 0)
                {
                    return (Convert.ToInt32(table[table.Count - 1].Orders.ToString()) + 1);
                }
                return 1;
            }
            catch (Exception)
            {
                return 1;
            }
        }
    }
}