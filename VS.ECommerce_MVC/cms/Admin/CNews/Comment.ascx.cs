using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Services;
using Entity;

namespace VS.ECommerce_MVC.cms.Admin.CNews
{
    public partial class Comment : System.Web.UI.UserControl
    {
        private string nid = "-1";
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
            if (Request["nid"] != null && !Request["nid"].Equals(""))
            {
                nid = Request["nid"];
            }
            if (!base.IsPostBack)
            {
                this.RefreshItems();
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            this.MultiView1.ActiveViewIndex = 0;
            this.setemptyform();
            this.RefreshItems();
        }

        protected void btncreatecomment_Click(object sender, EventArgs e)
        {
            this.MultiView1.ActiveViewIndex = 1;
            this.hdinsertupdate.Value = "insert";
            setemptyform();
        }

        protected void btndisplay_Click(object sender, EventArgs e)
        {
            this.RefreshItems();
        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            int istatus = 0;
            if (this.chkstatus.Checked)
            {
                istatus = 1;
            }
            if (this.txtname.Text.Trim().Length < 1)
            {
                this.ltmsg.Text = "Tên của bạn chưa nhập";
            }
            else if (this.txtemail.Text.Trim().Length < 1)
            {
                this.ltmsg.Text = "Email kh\x00f4ng thể bỏ trống!";
            }
            else if (!ValidateUtilities.IsValidEmail(this.txtemail.Text.Trim()))
            {
                this.ltmsg.Text = "Email kh\x00f4ng hợp lệ";
            }
            else if (this.txtcontent.Text.Trim().Length < 1)
            {
                this.ltmsg.Text = "Nội dung chưa nhập";
            }
            else if (this.txttitle.Text.Trim().Length < 1)
            {
                this.ltmsg.Text = "Tiêu đề chưa nhập";
            }
            else
            {
                Comments obj = new Comments();

                if (this.hdinsertupdate.Value.Equals("insert"))
                {
                    #region MyRegion
                    obj.ID_Parent = int.Parse(this.nid);
                    obj.Name = this.txtname.Text;
                    obj.Add = "";
                    obj.Email = this.txtemail.Text;
                    obj.Title = this.txttitle.Text;
                    obj.Contens = this.txtcontent.Text;
                    obj.Create_Date =   DateTime.Now;
                    obj.Status = istatus;
                    #endregion
                    SComments.INSERT(obj);
                }
                else
                {
                    #region MyRegion
                    obj.ID = int.Parse(this.hdid.Value);
                    obj.ID_Parent = int.Parse(this.nid);
                    obj.Name = this.txtname.Text;
                    obj.Add = "";
                    obj.Email = this.txtemail.Text;
                    obj.Title = this.txttitle.Text;
                    obj.Contens = this.txtcontent.Text;
                    obj.Create_Date =   DateTime.Now;
                    obj.Status = istatus;
                    #endregion
                    SComments.UPDATE(obj);
                }
                this.RefreshItems();
                this.MultiView1.ActiveViewIndex = 0;
                this.setemptyform();
            }
        }

        void RefreshItems()
        {
            try
            {
                bool flag = false;
                if (this.ddlorder.SelectedValue.Equals("1"))
                {
                    flag = true;
                }
                List<Comments> dt = SComments.Detail_ID_Parent_Status_orderasc_desc(this.nid, this.ddlstatus.SelectedValue, flag);
                CollectionPager1.DataSource = dt;
                CollectionPager1.BindToControl = rpitems;
                CollectionPager1.MaxPages = 10000;
                CollectionPager1.PageSize = 10;
                rpitems.DataSource = CollectionPager1.DataSourcePaged;
                rpitems.DataBind();
                this.ltpage1.Text = "Tổng cộng <span style=color:red;font-weight:bold> " + dt.Count.ToString() + "</span> \x00dd Kiến ";
            }
            catch (Exception) { }
        }

        protected void Delete_Load(object sender, System.EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Xóa Thông Tin Vừa Chọn ?')";

        }

        protected void rpitems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            List<Comments> dtdetail = new List<Comments>();
            switch (e.CommandName)
            {
                case "view":
                    List<Comments> table = SComments.GET_DETAIL_BYID(e.CommandArgument.ToString());
                    if (table.Count > 0)
                    {
                        this.hdid.Value = e.CommandArgument.ToString();
                        //this.txtaddress.Text = table[0]["vaddr"].ToString();
                        this.txtcontent.Text = table[0].Contens.ToString();
                        this.txtemail.Text = table[0].Email.ToString();
                        this.txtname.Text = table[0].Name.ToString();
                        this.txttitle.Text = table[0].Title.ToString();
                        this.MultiView1.ActiveViewIndex = 1;
                        this.hdinsertupdate.Value = "view";
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
                        SComments.UPDATE_STATUS(str2, str3);
                        this.RefreshItems();
                        base.Response.Redirect(base.Request.Url.ToString().Trim());
                        return;
                    }
                    return;
                case "delete":
                    {
                        SComments.DELETE(e.CommandArgument.ToString());
                        this.RefreshItems();
                        base.Response.Redirect(base.Request.Url.ToString().Trim());
                    }
                    break;
            }
        }

        private void setemptyform()
        {
            // this.txtaddress.Text = "";
            this.txtcontent.Text = "";
            this.txtemail.Text = "";
            this.txtname.Text = "";
            this.txttitle.Text = "";
        }

        protected void btxoa_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < rpitems.Items.Count; i++)
                {
                    CheckBox chk = (CheckBox)rpitems.Items[i].FindControl("chkid");
                    HiddenField id = (HiddenField)rpitems.Items[i].FindControl("hiID");
                    if (chk.Checked)
                    {
                        SComments.DELETE(id.Value);
                    }
                }
                RefreshItems();
            }
            catch (Exception)
            {

            }
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void ddlorder_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshItems();
        }

        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshItems();
        }
    }
}