using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using System.Data.SqlClient;
using Entity;
using System.Data;
using System.Configuration;
using System.IO;
using System.Text;

namespace VS.ECommerce_MVC.cms.View
{
    public partial class ExecuteSQL : System.Web.UI.Page
    {
        string keyword = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (HttpContext.Current.Cache["MenuBottom"] != null)
                {
                    ltketqua.Text += "MenuBottom------>" + HttpContext.Current.Cache["MenuBottom"].ToString();
                }
                if (HttpContext.Current.Cache["MenuTop"] != null)
                {
                    ltketqua.Text += "MenuTop------>" + HttpContext.Current.Cache["MenuTop"].ToString();
                }



                if (Request["keyword"] != null && !Request["keyword"].Equals(""))
                {
                    txttimkiem.Text = Request["keyword"].ToString();
                }
            }
            if (Session["XoaDelete"] != null && !Session["XoaDelete"].Equals(""))
            {
                ShowList();
                Response.Write("Đăng nhập thành công");
            }
            else
            {
                Response.Write("Chưa đăng nhập........");
            }
        }
        protected void resto_Click(object sender, EventArgs e)
        {
            string path = HttpContext.Current.Server.MapPath("/Uploads/" + txttenbd.Text + ".bak");
            //  string path = Request.PhysicalApplicationPath + "/Uploads/Database.bak"; ở localhos
            string sqlRestore = "Use master Restore Database [" + txttenbd.Text + "] from disk='" + path + "'";
            using (SqlConnection dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlCommand dbCmd = new SqlCommand();
                dbCmd.CommandType = CommandType.Text;
                dbCmd.Connection = dbConn;
                dbConn.Open();
                SqlCommand cmd = new SqlCommand(sqlRestore, dbConn);
                cmd.ExecuteNonQuery();
            }
            lblAlert.Text = "Database đã được restore ";
        }
        protected void backup_Click(object sender, EventArgs e)
        {
            string path = HttpContext.Current.Server.MapPath("/Uploads/" + txttenbd.Text + ".bak");
            //string path = Request.PhysicalApplicationPath + "/Uploads/Database.bak";
            string sqlBackup = "BACKUP DATABASE [" + txttenbd.Text + "] TO  disk='" + path + "'";
            using (SqlConnection dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlCommand dbCmd = new SqlCommand();
                dbCmd.CommandType = CommandType.Text;
                dbCmd.Connection = dbConn;
                dbConn.Open();
                SqlCommand cmd = new SqlCommand(sqlBackup, dbConn);
                cmd.ExecuteNonQuery();
            }
            lblAlert.Text = "Đã backup cơ sở dữ liệu";

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "";
            try
            {
                sql = MoreAll.MoreAll.RunScriptFile("SQLQuery.sql", false);
                if (sql == "ERROR")
                {
                    sql = "Không tồn tại file script hoặc thư mục sql";
                }

                lblAlert.Text = "<b style=\"color:red;\">Cập nhật CSDL Thành công</b>OK<br/>" + sql;
            }
            catch (Exception ex)
            {
                if (sql == "ERROR")
                {
                    sql = "Không tồn tại file script hoặc thư mục sql ";
                }
                lblAlert.Text = "Lỗi khi Cập nhật CSDL <br/>" + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace + "<br/>" + sql;
            }
        }
        protected void Sql_Load(object sender, System.EventArgs e)
        {
            ((Button)sender).Attributes["onclick"] = "return confirm('Chạy file SQLQuery.sql chứ ?')";
        }
        protected void TangName_Load(object sender, System.EventArgs e)
        {
            ((Button)sender).Attributes["onclick"] = "return confirm('Sẽ update toàn bộ TangName ở các bảng chứ?')";
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            List<Entity.VideoClip> dt = SVideoClip.GET_BY_ALL("VIE");
            if (dt.Count > 0)
            {
                for (int i = 0; i < dt.Count; i++)
                {
                    SVideoClip.Name_Text("UPDATE [VideoClip] SET  TangName='" + MoreAll.AddURL.SeoURL(dt[i].Title) + "' where ID=" + dt[i].ID.ToString() + "");
                }
            }

            List<Entity.Album> dt2 = SAlbum.GET_GY_ALL("VIE");
            if (dt2.Count > 0)
            {
                for (int i = 0; i < dt2.Count; i++)
                {
                    SAlbum.Name_Text("UPDATE [Album] SET  TangName='" + MoreAll.AddURL.SeoURL(dt2[i].Title) + "' where ID=" + dt2[i].ID.ToString() + "");
                }
            }

            List<Entity.Gioithieu> dt3 = SGioithieu.GET_BY_ALL("VIE");
            if (dt3.Count > 0)
            {
                for (int i = 0; i < dt3.Count; i++)
                {
                    SGioithieu.Name_Text("UPDATE [Gioithieu] SET  TangName='" + MoreAll.AddURL.SeoURL(dt3[i].Title) + "' where ID=" + dt3[i].ID.ToString() + "");
                }
            }

            List<Entity.Faq> dt4 = SFaq.GETBYALL("VIE");
            if (dt4.Count > 0)
            {
                for (int i = 0; i < dt4.Count; i++)
                {
                    SFaq.Name_Text("UPDATE [Faq] SET  TangName='" + MoreAll.AddURL.SeoURL(dt4[i].Title) + "' where inid=" + dt4[i].inid.ToString() + "");
                }
            }

            List<Entity.Download> dt5 = SDownload.GET_BY_ALL("VIE");
            if (dt5.Count > 0)
            {
                for (int i = 0; i < dt5.Count; i++)
                {
                    SDownload.Name_Text("UPDATE [Download] SET  TangName='" + MoreAll.AddURL.SeoURL(dt5[i].Title) + "' where ID=" + dt5[i].ID.ToString() + "");
                }
            }
            List<Entity.Dichvu> dt6 = SDichvu.GET_BY_ALL("VIE");
            if (dt6.Count > 0)
            {
                for (int i = 0; i < dt6.Count; i++)
                {
                    SDichvu.Name_Text("UPDATE [Dichvu] SET  TangName='" + MoreAll.AddURL.SeoURL(dt6[i].Title) + "' where ID=" + dt6[i].ID.ToString() + "");
                }
            }


        }
        protected void rp_pagelist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string str = e.CommandName.Trim();
            string str2 = e.CommandArgument.ToString().Trim();
            string str4 = str;
            switch (e.CommandName)
            {
                case "Delete":
                    SMenu.DELETE(str2);
                    this.ShowList();
                    return;
            }
        }
        protected void rpNews_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string str = e.CommandName.Trim();
            string str2 = e.CommandArgument.ToString().Trim();
            string str4 = str;
            switch (e.CommandName)
            {
                case "Delete":
                    SNews.News_DELETE(str2);
                    this.ShowList();
                    return;
            }
        }
        protected void rpPro_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string str = e.CommandName.Trim();
            string str2 = e.CommandArgument.ToString().Trim();
            string str4 = str;
            switch (e.CommandName)
            {
                case "Delete":
                    SProducts.Delete(str2);
                    this.ShowList();
                    return;
            }
        }
        protected void rpvideo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string str = e.CommandName.Trim();
            string str2 = e.CommandArgument.ToString().Trim();
            string str4 = str;
            switch (e.CommandName)
            {
                case "Delete":
                    SVideoClip.DELETE(str2);
                    this.ShowList();
                    return;
            }
        }
        protected void rpalbum_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string str = e.CommandName.Trim();
            string str2 = e.CommandArgument.ToString().Trim();
            string str4 = str;
            switch (e.CommandName)
            {
                case "Delete":
                    SAlbum.DELETE(str2);
                    this.ShowList();
                    return;
            }
        }
        private void ShowList()
        {
            if (MoreAll.MoreAll.GetCookies("XoaDelete").ToString() != null)
            {
                if (Request["keyword"] != null && !Request["keyword"].Equals(""))
                {
                    List<Entity.Menu> table = SMenu.Name_Text("SELECT * FROM Menu WHERE  dbo.fuConvertToUnsign(Name)  LIKE N'" + SearchApproximate.Exec(ConvertVN.Convert(txttimkiem.Text)) + "' ");
                    rp_pagelist.DataSource = table;
                    rp_pagelist.DataBind();
                    //Response.Write("SELECT * FROM Menu WHERE  dbo.fuConvertToUnsign(Name)  LIKE N'" + SearchApproximate.Exec(ConvertVN.Convert(txttimkiem.Text)) + "' ");
                }
                if (Request["keyword"] != null && !Request["keyword"].Equals(""))
                {
                    List<Entity.News> table = SNews.Name_Text("SELECT * FROM News WHERE  dbo.fuConvertToUnsign(Title)  LIKE N'" + SearchApproximate.Exec(ConvertVN.Convert(txttimkiem.Text)) + "' ");
                    rpNews.DataSource = table;
                    rpNews.DataBind();
                    // Response.Write("SELECT * FROM Menu WHERE  dbo.fuConvertToUnsign(Title)  LIKE N'" + SearchApproximate.Exec(ConvertVN.Convert(txttimkiem.Text)) + "' ");
                }
                if (Request["keyword"] != null && !Request["keyword"].Equals(""))
                {
                    List<Entity.Products> table = SProducts.Name_Text("SELECT * FROM Products WHERE  dbo.fuConvertToUnsign(Name)  LIKE N'" + SearchApproximate.Exec(ConvertVN.Convert(txttimkiem.Text)) + "' ");
                    rpPro.DataSource = table;
                    rpPro.DataBind();
                    // Response.Write("SELECT * FROM Menu WHERE  dbo.fuConvertToUnsign(Name)  LIKE N'" + SearchApproximate.Exec(ConvertVN.Convert(txttimkiem.Text)) + "' ");
                }
                if (Request["keyword"] != null && !Request["keyword"].Equals(""))
                {
                    List<Entity.VideoClip> table = SVideoClip.Name_Text("SELECT * FROM VideoClip WHERE  dbo.fuConvertToUnsign(Title)  LIKE N'" + SearchApproximate.Exec(ConvertVN.Convert(txttimkiem.Text)) + "' ");
                    rpvideo.DataSource = table;
                    rpvideo.DataBind();
                    //Response.Write("SELECT * FROM VideoClip WHERE  dbo.fuConvertToUnsign(Title)  LIKE N'" + SearchApproximate.Exec(ConvertVN.Convert(txttimkiem.Text)) + "' ");
                }

                if (Request["keyword"] != null && !Request["keyword"].Equals(""))
                {
                    List<Entity.Album> table = SAlbum.Name_Text("SELECT * FROM Album WHERE  dbo.fuConvertToUnsign(Title)  LIKE N'" + SearchApproximate.Exec(ConvertVN.Convert(txttimkiem.Text)) + "' ");
                    rpalbum.DataSource = table;
                    rpalbum.DataBind();
                    // Response.Write("SELECT * FROM Album WHERE  dbo.fuConvertToUnsign(Title)  LIKE N'" + SearchApproximate.Exec(ConvertVN.Convert(txttimkiem.Text)) + "' ");
                }
            }
        }
        public class SearchApproximate
        {
            // Phương thức trả về câu lệnh SQL dùng truy vấn dữ liệu
            public static string ApproximateSearch(string keyWord, string lang)
            {
                string sql = "SELECT * FROM Menu WHERE Name LIKE N'" + Exec(ConvertVN.Convert(keyWord)) + "' ";
                return sql;
            }
            // Phương thức chuyển đổi một chuỗi ký tự: Nếu chuỗi đó có ký tự " " sẽ thay thế bằng "%"
            public static string Exec(string keyWord)
            {
                string[] arrWord = keyWord.Split(' ');
                StringBuilder str = new StringBuilder("%");
                for (int i = 0; i < arrWord.Length; i++)
                {
                    str.Append(arrWord[i] + "%");
                }
                return str.ToString();
            }
        }

        public class ConvertVN
        {
            // Phương thức Convert một chuỗi ký tự Có dấu sang Không dấu
            public static string Convert(string chucodau)
            {
                const string FindText = "áàảãạâấầẩẫậăắằẳẵặđéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ";
                const string ReplText = "aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAADEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYY";
                int index = -1;
                char[] arrChar = FindText.ToCharArray();
                while ((index = chucodau.IndexOfAny(arrChar)) != -1)
                {
                    int index2 = FindText.IndexOf(chucodau[index]);
                    chucodau = chucodau.Replace(chucodau[index], ReplText[index2]);
                }
                return chucodau;
            }
        }

        protected void bttimkiem_Click(object sender, EventArgs e)
        {
            ShowList();
            Response.Redirect("ExecuteSQL.aspx?keyword=" + txttimkiem.Text + "");
        }
        protected void Delete_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Xóa bài viết này ?')";
        }

        protected void btDeleteall_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < rp_pagelist.Items.Count; i++)
            {
                CheckBox chk = (CheckBox)rp_pagelist.Items[i].FindControl("chkid");
                HiddenField id = (HiddenField)rp_pagelist.Items[i].FindControl("hiID");
                if (chk.Checked)
                {
                    SMenu.DELETE(id.Value);
                }
            }

            for (int i = 0; i < rpNews.Items.Count; i++)
            {
                CheckBox chk = (CheckBox)rpNews.Items[i].FindControl("chkid");
                HiddenField id = (HiddenField)rpNews.Items[i].FindControl("hiID");
                if (chk.Checked)
                {
                    SNews.News_DELETE(id.Value);
                }
            }

            for (int i = 0; i < rpPro.Items.Count; i++)
            {
                CheckBox chk = (CheckBox)rpPro.Items[i].FindControl("chkid");
                HiddenField id = (HiddenField)rpPro.Items[i].FindControl("hiID");
                if (chk.Checked)
                {
                    SProducts.Delete(id.Value);
                }
            }


            for (int i = 0; i < rpvideo.Items.Count; i++)
            {
                CheckBox chk = (CheckBox)rpvideo.Items[i].FindControl("chkid");
                HiddenField id = (HiddenField)rpvideo.Items[i].FindControl("hiID");
                if (chk.Checked)
                {
                    SVideoClip.DELETE(id.Value);
                }
            }

            for (int i = 0; i < rpalbum.Items.Count; i++)
            {
                CheckBox chk = (CheckBox)rpalbum.Items[i].FindControl("chkid");
                HiddenField id = (HiddenField)rpalbum.Items[i].FindControl("hiID");
                if (chk.Checked)
                {
                    SAlbum.DELETE(id.Value);
                }
            }


            ShowList();
        }

        protected void lnkdangnhap_Click(object sender, EventArgs e)
        {
            if ((this.txt_username.Text.Trim().Length < 1) || (this.txt_pwd.Text.Trim().Length < 1))
            {
                this.lt_msg.Text = "Vui lòng kiểm tra dữ liệu nhập";
                this.Page.SetFocus(this.txt_username);
            }
            else if (this.txt_username.Text.Equals("Tinhminhdung1109") && this.txt_pwd.Text.Equals("Phapdanh"))
            {
                System.Web.HttpContext.Current.Session["XoaDelete"] = "XoaDelete";
                base.Response.Redirect((base.Request.Url.ToString().Trim()));
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Session["XoaDelete"] != null && !Session["XoaDelete"].Equals(""))
            {
                Response.Write("Đăng nhập thành công");
            }
            else
            {
                Response.Write("Chưa đăng nhập........");
            }

            if (txtSQLQuery.Text.Length > 10)
            {
                try
                {
                    using (SqlConnection dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                    {
                        using (SqlCommand dbCmd = new SqlCommand(txtSQLQuery.Text, dbConn))
                        {
                            dbCmd.CommandType = CommandType.Text;
                            dbConn.Open();
                            dbCmd.ExecuteNonQuery();
                            dbConn.Close();
                        }
                    }
                    lblAlert.Text = "Thành công.!!!!!!!!!!!!!!";
                }
                catch
                {
                    lblAlert.Text = "Lỗi.!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!";
                }
            }
        }
    }
}