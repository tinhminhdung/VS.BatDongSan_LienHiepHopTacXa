using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Services;
using Entity;

namespace VS.ECommerce_MVC.cms.Admin.MMember
{
    public partial class AMembers : System.Web.UI.UserControl
    {
        private string status = "-1";
        private string IDThanhVien = "0";
        DatalinqDataContext db = new DatalinqDataContext();
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
            if (Request["st"] != null && !Request["st"].Equals(""))
            {
                status = Request["st"];
            }
            if (!base.IsPostBack)
            {
                if (Request["st"] != null && !Request["st"].Equals(""))
                {
                    ddlstatus.SelectedValue = Request["st"];
                }
                if (Request["us"] != null && !Request["us"].Equals(""))
                {
                    ddlorderby.SelectedValue = Request["us"];
                }
                if (Request["ds"] != null && !Request["ds"].Equals(""))
                {
                    ddlordertype.SelectedValue = Request["ds"];
                }
                if (Request["kw"] != null && !Request["kw"].Equals(""))
                {
                    txtkeyword.Text = Request["kw"];
                }
                if (Request["IDThanhVien"] != null && !Request["IDThanhVien"].Equals(""))
                {
                    IDThanhVien = Request["IDThanhVien"];
                }
                if (Request["cb"] != null && !Request["cb"].Equals(""))
                {
                    dddlcapbac.SelectedValue = Request["cb"];
                }

                this.ddlstatus.Items.Add(new ListItem("Tất cả các mục", "-1"));
                this.ddlstatus.Items.Add(new ListItem("Kích hoạt", "1"));
                this.ddlstatus.Items.Add(new ListItem("Chưa kích hoạt", "0"));
                WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlstatus, this.status);
                this.LoadItems();
            }
        }
        protected void btndisplay_Click(object sender, EventArgs e)
        {
            this.LoadItems();
            LoadRequest();
        }
        protected void lnksearch_Click(object sender, EventArgs e)
        {
            LoadItems();
            LoadRequest();
        }
        protected void Delete_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Bạn c\x00f3 muốn x\x00f3a th\x00e0nh vi\x00ean n\x00e0y?')";
        }
        protected bool EnableLock(string status)
        {
            return status.Equals("1");
        }
        protected bool EnablecUnLock(string status)
        {
            return status.Equals("1");
        }
        protected bool EnablecLock(string status)
        {
            return status.Equals("2");
        }
        protected bool EnableUnLock(string status)
        {
            return status.Equals("0");
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }
        //void LoadItems()
        //{
        //    //try
        //    //{
        //    //  string[] searchfields = new string[] { "HoVaTen", "DiaChi", "DienThoai", "Email" };
        //    //   string orderby = this.ddlorderby.SelectedValue + " " + this.ddlordertype.SelectedValue;
        //    // List<Entity.Member> dt = SMember.CATEGORY_ADMIN(orderby, this.txtkeyword.Text.Replace("&nbsp;", ""), searchfields, lang, ddlstatus.SelectedValue);
        //    string shortbydate = "";
        //    string orderby = this.ddlorderby.SelectedValue + " " + this.ddlordertype.SelectedValue;
        //    string sql = "select * from Members where lang='" + lang + "' ";
        //    if (!ddlstatus.SelectedValue.Equals("-1"))
        //    {
        //        sql += " and TrangThai=" + ddlstatus.SelectedValue;
        //    }
        //    if (txtkeyword.Text.Length > 0)
        //    {
        //        sql += " and  (dbo.fuConvertToUnsign(HoVaTen) LIKE N'" + Framwork.FCarts.SearchApproximate.Exec(Framwork.FCarts.ConvertVN.Convert(txtkeyword.Text)) + "' OR dbo.fuConvertToUnsign(DiaChi)  LIKE N'" + Framwork.FCarts.SearchApproximate.Exec(Framwork.FCarts.ConvertVN.Convert(txtkeyword.Text)) + "' OR DienThoai LIKE N'" + Framwork.FCarts.SearchApproximate.Exec(Framwork.FCarts.ConvertVN.Convert(txtkeyword.Text)) + "' OR Email LIKE N'" + Framwork.FCarts.SearchApproximate.Exec(Framwork.FCarts.ConvertVN.Convert(txtkeyword.Text)) + "') ";
        //    }
        //    if (orderby.Length < 1)
        //    {
        //        shortbydate = " order by NgayTao desc";
        //    }
        //    else
        //    {
        //        shortbydate = " order by " + orderby;
        //    }
        //    sql += shortbydate;
        //    List<Member> dt = db.ExecuteQuery<Member>(@"" + sql + "").ToList();
        //    CollectionPager1.DataSource = dt;
        //    CollectionPager1.BindToControl = Repeater1;
        //    CollectionPager1.MaxPages = 10000;
        //    CollectionPager1.PageSize = 30;
        //    Repeater1.DataSource = CollectionPager1.DataSourcePaged;
        //    Repeater1.DataBind();
        //    //}
        //    //catch (Exception)
        //    //{ }
        //}

        public void LoadItems()
        {
            string sql1 = "";
            if (dddlcapbac.SelectedValue!="0")
            {
                sql1 += " and capbac=" + dddlcapbac.SelectedValue + " ";
            }
            if (IDThanhVien != "0")
            {
                sql1 += " and ID=" + IDThanhVien + " ";
            }

            int Tongsobanghi = 0;
            Int16 pages = 1;
            int Tongsotrang = int.Parse("30");
            if ((Request.QueryString["page"] != null) && (Request.QueryString["page"] != ""))
            {
                pages = Convert.ToInt16(Request.QueryString["page"].Trim());
            }
            List<Entity.Member> iitem = SMember.CATEGORY_PHANTRANG1(sql1, txtkeyword.Text.Replace("&nbsp;", ""), ddlstatus.SelectedValue);
            if (iitem.Count() > 0)
            {
                Tongsobanghi = iitem.Count();
            }
            List<Entity.Member> dt = SMember.CATEGORY_PHANTRANG2(sql1, txtkeyword.Text.Replace("&nbsp;", ""), ddlstatus.SelectedValue, (pages - 1), Tongsotrang);
            if (dt.Count >= 1)
            {
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
            if (Tongsobanghi % Tongsotrang > 0)
            {
                Tongsobanghi = (Tongsobanghi / Tongsotrang) + 1;
            }
            else
            {
                Tongsobanghi = Tongsobanghi / Tongsotrang;
            }
            ltpage.Text = Commond.PhantrangAdmin("/admin.aspx?u=Thanhvien&st=" + ddlstatus.SelectedValue + "&us=" + ddlorderby.SelectedValue + "&ds=" + ddlordertype.SelectedValue + "&kw=" + txtkeyword.Text + "", Tongsobanghi, pages);
        }
        protected void Lock_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Bạn c\x00f3 muốn kh\x00f3a t\x00e0i khoản n\x00e0y?')";
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "delete":
                    SMember.DELETE(e.CommandArgument.ToString().Trim());
                    this.LoadItems();
                    base.Response.Redirect(base.Request.Url.ToString().Trim());
                    return;
                case "lock":
                    this.UpdateStatus(e.CommandArgument.ToString().Trim(), "0");
                    this.LoadItems();
                    base.Response.Redirect(base.Request.Url.ToString().Trim());
                    return;
                case "unlock":
                    this.UpdateStatus(e.CommandArgument.ToString().Trim(), "1");
                    this.LoadItems();
                    base.Response.Redirect(base.Request.Url.ToString().Trim());
                    return;

            }
        }
        protected string Status(string status)
        {
            if (status.Equals("1"))
            {
                return "Đang hoạt động";
            }
            return "Đ\x00e3 kh\x00f3a";
        }
        protected void ddlordertype_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItems();
            LoadRequest();
        }
        protected void ddlorderby_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItems();
            LoadRequest();
        }
        protected string Enablechon(string chon)
        {
            if (chon.Equals("1"))
            {
                return "Thành viên";
            }
            return "Nội bộ";
        }
        private void UpdateStatus(string un, string status)
        {
            SMember.UPDATE_STATUS(un, status);
        }
        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadItems();
            LoadRequest();
        }
        protected void LoadRequest()
        {
            Response.Redirect("admin.aspx?u=Thanhvien&st=" + ddlstatus.SelectedValue + "&us=" + ddlorderby.SelectedValue + "&ds=" + ddlordertype.SelectedValue + "&cb=" + dddlcapbac.SelectedValue + "&kw=" + txtkeyword.Text + "");
        }
        protected void btxoa_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < Repeater1.Items.Count; i++)
                {
                    CheckBox chk = (CheckBox)Repeater1.Items[i].FindControl("chkid");
                    HiddenField id = (HiddenField)Repeater1.Items[i].FindControl("hiID");
                    if (chk.Checked)
                    {
                        SMember.DELETE(id.Value);
                    }
                }
                LoadItems();
            }
            catch (Exception)
            {

            }
        }

        protected void dddlcapbac_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadItems();
            LoadRequest();
        }
    }
}