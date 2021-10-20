using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using MoreAll;
using System.Text;

namespace VS.ECommerce_MVC.cms.Admin.Marketing
{
    public partial class Marketing : System.Web.UI.UserControl
    {
        private string lang = Captionlanguage.Language;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["lang"] != null)
            {
                this.lang = System.Web.HttpContext.Current.Session["lang"].ToString();
            }
            else
            {
                System.Web.HttpContext.Current.Session["lang"] = this.lang;
                this.lang = System.Web.HttpContext.Current.Session["lang"].ToString();
            }
            if (!IsPostBack)
            {
                if (Request["st"] != null && !Request["st"].Equals(""))
                {
                    ddlstatus.SelectedValue = Request["st"];
                }
                LoadItems();
            }
        }

        void LoadItems()
        {
            //try
            {
                string Sql = "";
                if (Request["st"] == "0")
                {
                    Sql += "where istatus=0";
                }
                else if (Request["st"] == "-1")
                {
                    Sql += "";
                }
                else if (Request["st"] == "1")
                {
                    Sql += "where istatus=1";
                }
                List<Entity.Marketing> dt = SMarketing.Name_Text("select * from Marketing " + Sql + "  order by dcreatedate desc");

               // List<Entity.Marketing> dt = SMarketing.CategoryAdmin(ddlstatus.SelectedValue);
                CollectionPager1.DataSource = dt;
                CollectionPager1.BindToControl = rpitems;
                CollectionPager1.MaxPages = 10000;
                CollectionPager1.PageSize = 10;
                rpitems.DataSource = CollectionPager1.DataSourcePaged;
                rpitems.DataBind();
            }
           // catch (Exception) { }
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void btndisplay_Click(object sender, EventArgs e)
        {
            LoadItems();
        }

        protected void rpitems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "detail":
                    List<Entity.Marketing> dt = SMarketing.GET_BY_ID(e.CommandArgument.ToString());
                    if (dt.Count > 0)
                    {
                        this.ltsender.Text = dt[0].Name.ToString();
                        this.ltaddress.Text = dt[0].Address.ToString();
                        this.ltphone.Text = dt[0].Phone.ToString();
                        this.ltemail.Text = dt[0].Email.ToString();
                        if (dt[0].istatus.ToString().Equals("0"))
                        {
                            this.btncheck.Visible = true;
                        }
                        else
                        {
                            this.btncheck.Visible = false;
                        }
                        hdid.Value = e.CommandArgument.ToString();
                        MultiView1.ActiveViewIndex = 1;
                    }
                    break;
                case "ChangeStatus":
                    string str = e.CommandName.Trim();
                    string str2 = e.CommandArgument.ToString().Trim();
                    string str4 = str;
                    if (str4 != null)
                    {
                        string str3;
                        str2 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                        if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                        {
                            str3 = "0";
                        }
                        else
                        {
                            str3 = "1";
                        }
                        SMarketing.CATE_UPDATE(str2, str3);
                        this.LoadItems();
                        base.Response.Redirect(base.Request.Url.ToString().Trim());
                        return;
                    }
                    return;
                case "Email":
                    List<Entity.Marketing> ist = SMarketing.GET_BY_ID(e.CommandArgument.ToString());
                    if (ist.Count > 0)
                    {
                        this.txtTo.Text = ist[0].Email.ToString();
                        hdid.Value = e.CommandArgument.ToString();
                        MultiView1.ActiveViewIndex = 2;
                        this.txttitle.Text = "";
                        this.lblmsg.Text = "";
                        this.txtContent.Text = "";
                    }
                    break;
                case "delete":
                    SMarketing.DELETE(e.CommandArgument.ToString());
                    LoadItems();
                    break;
            }
        }

        protected void Delete_Load(object sender, System.EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Xóa Thông Tin vừa Chọn?')";
        }

        protected void Delete_Load_Button(object sender, System.EventArgs e)
        {
            ((Button)sender).Attributes["onclick"] = "return confirm('Xóa Thông Tin vừa Chọn?')";
        }

        protected void btncheck_Click(object sender, EventArgs e)
        {
            List<Entity.Marketing> dt = SMarketing.GET_BY_ID(this.hdid.Value);
            if (dt.Count > 0)
            {
                SMarketing.CATE_UPDATE(this.hdid.Value, "1");
            }
            LoadItems();
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            LoadItems();
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            LoadItems();
        }

        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItems();
            Response.Redirect("admin.aspx?u=Marketing&st=" + ddlstatus.SelectedValue + "");
        }

        protected void btphanhoi_Click(object sender, EventArgs e)
        {
            List<Entity.Marketing> dt = SMarketing.GET_BY_ID(this.hdid.Value);
            if (dt.Count > 0)
            {
                txtTo.Text = dt[0].Email.ToString();
            }
            MultiView1.ActiveViewIndex = 2;
            this.txttitle.Text = "";
            this.lblmsg.Text = "";
            this.txtContent.Text = "";
        }

        protected void btxoa_Click(object sender, EventArgs e)
        {
            SMarketing.DELETE(this.hdid.Value);
            LoadItems();
            MultiView1.ActiveViewIndex = 0;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<Entity.Marketing> dt = SMarketing.GET_BY_ID(this.hdid.Value);
            if (dt.Count > 0)
            {
                SMarketing.CATE_UPDATE(this.hdid.Value, "1");
            }
            LoadItems();
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnreplyemail_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txttitle.Text.Length < 1)
                {
                    this.lblmsg.Text = "Chèn tiêu đề";
                }
                else if (this.txtTo.Text.Length < 1)
                {
                    this.lblmsg.Text = "Chèn Email đến";
                }
                else if (!ValidateUtilities.IsValidEmail(this.txtTo.Text))
                {
                    this.lblmsg.Text = "Email không hợp lệ";
                }
                else if (this.txtContent.Text.Length < 1)
                {
                    this.lblmsg.Text = "Chèn nội dung";
                }
                else
                {
                    string email = Email.email();
                    string password = Email.password();
                    int port = Convert.ToInt32(Email.port());
                    string host = Email.host();
                    MailUtilities.SendMail(this.txttitle.Text.Trim(), email, password, this.txtTo.Text, host, port, this.txttitle.Text.Trim(), this.txtContent.Text.Trim());
                    this.txttitle.Text = "";
                    this.txtTo.Text = "";
                    this.lblmsg.Text = "";
                    this.txtContent.Text = "";
                    MultiView1.ActiveViewIndex = 0;
                    LoadItems();
                }
            }
            catch (Exception)
            {
                this.lblmsg.Text = "Hệ thống Email của bạn có thể chưa điền hoặc chưa điền đúng hoặc chưa đúng thông tài khoản Gmail mà chúng tôi yêu cầu";
            }
        }

        protected void btcancelemail_Click(object sender, EventArgs e)
        {
            this.txttitle.Text = "";
            this.txtTo.Text = "";
            this.lblmsg.Text = "";
            this.txtContent.Text = "";
            this.MultiView1.ActiveViewIndex = 0;
        }

        protected void btdelete_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < rpitems.Items.Count; i++)
                {
                    CheckBox chk = (CheckBox)rpitems.Items[i].FindControl("chkid");
                    HiddenField id = (HiddenField)rpitems.Items[i].FindControl("hiID");
                    if (chk.Checked)
                    {
                        SMarketing.DELETE(id.Value);
                    }
                }
                LoadItems();
            }
            catch (Exception)
            {

            }
        }

        protected void Export_Click(object sender, EventArgs e)
        {
            string Namefile = "Emailnhankhuyenmai";
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment;filename=" + Namefile + ".xls");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"; // "application/ms-excel";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Charset = "utf-8";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
            sb.Append("<table border='1' bgcolor='#ffffff' bordercolor='#dedede' cellspacing='0' cellpadding='0' style='font-size:12px; font-family:Arial; background:white;'>");
            sb.Append("<tr>");
            sb.Append("  <th style=\"width:50px; vertical-align:middle; height: 22px;\">");
            sb.Append("    <b>STT</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:150px; vertical-align:middle;\">");
            sb.Append("    <b>Họ và tên</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:400px; vertical-align:middle;\">");
            sb.Append("    <b>Địa chỉ</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:250px; vertical-align:middle;\">");
            sb.Append("    <b>Điện thoại</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:150px; vertical-align:middle;\">");
            sb.Append("    <b>Email</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:520px; vertical-align:middle;\">");
            sb.Append("    <b>Ngày đăng ký</b>");
            sb.Append("  </th>");
            sb.Append("  </tr>");

            List<Entity.Marketing> dt = SMarketing.Name_Text("select * from Marketing order by IDMarketing asc");
            if (dt.Count > 0)
            {
                int i = 1;
                foreach (var item in dt)
                {
                    sb.Append("    <tr>");
                    sb.Append("    <td style=\"width:50px; vertical-align:middle; height: 22px; text-align: center;\">" + i++ + "</td>");
                    sb.Append("    <td style=\"width:150px; vertical-align:middle;text-align: center;\">" + item.Name + "</td>");
                    sb.Append("    <td style=\"width:400px; vertical-align:middle; text-align: center;\">" + item.Address + "</td>");
                    sb.Append("    <td style=\"width:250px; vertical-align:middle;text-align: center;\">" + item.Phone + "</td>");
                    sb.Append("    <td style=\"width:150px; vertical-align:middle;text-align: center;\">" + item.Email + "</td>");
                    sb.Append("    <td style=\"width:520px; vertical-align:middle; text-align: center;\">" + item.dcreatedate + "</td>");
                    sb.Append("  </tr>");
                }
            }
            sb.Append("</table>");
            Response.Write(sb.ToString());
            Response.Flush();
            Response.End();
        }
    }
}