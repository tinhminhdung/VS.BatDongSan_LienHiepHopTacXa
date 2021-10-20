using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using System.IO;
using Services;

namespace VS.ECommerce_MVC.cms.Admin.GioiThieu
{
    public partial class GioiThieu : System.Web.UI.UserControl
    {
        ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
        private string status = "";
        private string lang = Captionlanguage.Language;
        DatalinqDataContext db = new DatalinqDataContext();
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
            if (!IsPostBack)
            {
                #region UpdatePanel
                this.Page.Form.Enctype = "multipart/form-data";
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnsave);
                #endregion
                if (Request["st"] != null && !Request["st"].Equals(""))
                {
                    ddlstatus.SelectedValue = Request["st"];
                    WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlstatus, this.status);
                }
                LoadItems();
            }
        }

        void LoadItems()
        {
            try
            {
                string[] searchfields = new string[] { "Title", "Brief", "Contents", "search" };
                string orderby = this.ddlorderby.SelectedValue + " " + this.ddlordertype.SelectedValue;
                List<Entity.Gioithieu> dt = SGioithieu.CATEGORY_ADMIN(orderby, this.txtkeyword.Text.Replace("&nbsp;", ""), searchfields, lang, ddlstatus.SelectedValue);
                CollectionPager1.DataSource = dt;
                CollectionPager1.BindToControl = rpitems;
                CollectionPager1.MaxPages = 10000;
                CollectionPager1.PageSize = 10;
                rpitems.DataSource = CollectionPager1.DataSourcePaged;
                rpitems.DataBind();
            }
            catch (Exception) { }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            // try
            //{
            if (this.txtname.Text.Trim().Length < 1)
            {
                this.lbl_msg.Text = "Xin vui lòng kiểm tra dữ liệu đầu vào của bạn";
            }
            else
            {
                int status = 0;
                if (this.chkstatus.Checked)
                {
                    status = 1;
                }

                #region Date
                int Chekdata = 0;
                string cdate = DateTime.Now.ToString();
                string edate = DateTime.Now.AddYears(10).ToString();
                DateTime dcreatedate = Convert.ToDateTime(cdate.ToString());
                DateTime denddate = Convert.ToDateTime(edate.ToString());
                if (this.chkdaytype.Checked)
                {
                    Chekdata = 1;
                    dcreatedate = Convert.ToDateTime(this.txtfromday.Text);
                    denddate = dcreatedate.AddDays((double)Convert.ToInt32(this.txtindays.Text));
                }
                #endregion

                


                Entity.Gioithieu obj = new Entity.Gioithieu();
                string str2 = this.hdinsertupdate.Value.Trim();
                if (str2 != null)
                {
                    if (!(str2 == "update"))
                    {
                        if (str2 == "insert")
                        {
                            #region InsertMenu
                            int cong = 0;
                            string TangName = "";
                            List<Entity.Gioithieu> curItem = SGioithieu.Name_Text("SELECT top 1 * FROM Gioithieu order by ID desc");
                            int tong = int.Parse(curItem[0].ID.ToString()); cong = tong + 1; var hasTagName = db.Gioithieus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtname.Text)).FirstOrDefault(); TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtname.Text) + "-" + cong : MoreAll.AddURL.SeoURL(txtname.Text);
                            #endregion

                            #region MyRegion
                            obj.Title = txtname.Text;
                            obj.Brief = txtdesc.Text;
                            obj.Contents = txtcontent.Text;
                            obj.Keywords = txtauthor.Text;
                            obj.search = RewriteURLNew.NameToTag(txtname.Text + txtdesc.Text + txtcontent.Text + txtauthor.Text);
                            obj.Images = txtImage.Text;
                            obj.Equals = 0;
                            obj.Chekdata = Chekdata;
                            obj.Create_Date = dcreatedate;
                            obj.Modified_Date = denddate;
                            obj.Views = 0;
                            obj.lang = this.lang;
                            obj.Status = status;
                            obj.Titleseo = this.txttitleseo.Text;
                            obj.Meta = this.txtmeta.Text;
                            obj.Keyword = this.txtKeywordS.Text;
                            obj.TangName = TangName;
                            #endregion
                            SGioithieu.INSERT(obj);
                        }
                    }
                    else
                    {
                        #region UpdateMenu
                        string TagName = "";
                        List<Entity.Gioithieu> item = SGioithieu.GET_BY_ID(this.hdid.Value);
                        if (item.Count > 0)
                        {
                            List<Gioithieu> list = (from p in db.Gioithieus where p.TangName == item[0].TangName orderby p.ID descending select p).ToList();
                            if (list.Count > 2)
                            {
                                var hasTagName = db.Gioithieus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtname.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtname.Text) + "-" + item[0].ID : MoreAll.AddURL.SeoURL(txtname.Text);
                            }
                            else
                            {
                                if (MoreAll.AddURL.SeoURL(item[0].Title) != MoreAll.AddURL.SeoURL(txtname.Text)) { var hasTagName = db.Gioithieus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtname.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtname.Text) + "-" + item[0].ID : MoreAll.AddURL.SeoURL(txtname.Text); } else { TagName = item[0].TangName; }
                            }
                        }
                        #endregion

                        #region MyRegion
                        obj.ID = int.Parse(hdid.Value);
                        obj.Title = txtname.Text;
                        obj.Brief = txtdesc.Text;
                        obj.Contents = txtcontent.Text;
                        obj.Keywords = txtauthor.Text;
                        obj.search = RewriteURLNew.NameToTag(txtname.Text + txtdesc.Text + txtcontent.Text + txtauthor.Text);
                        obj.Images = txtImage.Text;
                        obj.Equals = 0;
                        obj.Chekdata = Chekdata;
                        //obj.Create_Date = dcreatedate;
                        //obj.Modified_Date = denddate;
                        obj.lang = this.lang;
                        obj.Status = status;
                        obj.Titleseo = this.txttitleseo.Text;
                        obj.Meta = this.txtmeta.Text;
                        obj.Keyword = this.txtKeywordS.Text;
                        obj.TangName = TagName;
                        #endregion
                        SGioithieu.UPDATE(obj);
                    }
                }
                LoadItems();
                MultiView1.ActiveViewIndex = 0;
                DeleteFormValue();
            }
            //}
            // catch (Exception) { }
        }

        void DeleteFormValue()
        {
            txtcontent.Text = "";
            txtdesc.Text = "";
            hdimg.Value = "";
            hdcid.Value = "";
            hdimg.Value = "";
            txtname.Text = "";
            txtcontent.Text = "";
            txtauthor.Text = "";
            ltimg.Text = "";
            txtImage.Text = "";
            hdFileName.Value = "";
            lbl_msg.Text = "";
            lbl_msg.Text = "";
            this.txttitleseo.Text = "";
            this.txtmeta.Text = "";
            this.txtKeywordS.Text = "";
        }

        protected void Delete_Load(object sender, System.EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Xóa Thông Tin Vừa Chọn ?')";
        }

        protected void btthemmoi_Click(object sender, EventArgs e)
        {
            hdinsertupdate.Value = "insert";
            MultiView1.ActiveViewIndex = 1;
            DeleteFormValue();
            this.txtfromday.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
        }

        protected void btndisplay_Click(object sender, EventArgs e)
        {
            LoadItems(); LoadRequest();
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            DeleteFormValue();
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void rpitems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            List<Entity.Gioithieu> dt = new List<Entity.Gioithieu>();
            switch (e.CommandName)
            {
                #region EditDetail
                case "EditDetail":
                    dt = SGioithieu.GET_DETAIL_BYID(e.CommandArgument.ToString());
                    if (dt.Count > 0)
                    {
                        txtname.Text = dt[0].Title.ToString();
                        txtdesc.Text = dt[0].Brief.ToString();
                        txtcontent.Text = dt[0].Contents.ToString();
                        txtauthor.Text = dt[0].Keywords.ToString();
                        hdimg.Value = dt[0].Images.ToString();
                        txtImage.Text = dt[0].Images.ToString();
                        ltimg.Text = MoreImage.Image(dt[0].Images);
                        if (dt[0].Status.ToString().Trim().Equals("0"))
                        {
                            this.chkstatus.Checked = false;
                        }
                        else if (dt[0].Status.ToString().Equals("1"))
                        {
                            this.chkstatus.Checked = true;
                        }
                        #region Seowwebsite
                        txttitleseo.Text = dt[0].Titleseo.ToString().Trim();
                        txtmeta.Text = dt[0].Meta.ToString().Trim();
                        txtKeywordS.Text = dt[0].Keyword.ToString().Trim();
                        #endregion
                        #region Update
                        this.txtfromday.Text = Convert.ToDateTime(dt[0].Create_Date).ToString("MM/dd/yyyy HH:mm");
                        this.txtindays.Text = ((Convert.ToDateTime(dt[0].Modified_Date).Ticks - Convert.ToDateTime(dt[0].Create_Date).Ticks) / 0xc92a69c000L).ToString();
                        if (dt[0].Chekdata.ToString().Equals("1"))
                        {
                            this.chkdaytype.Checked = true;
                            this.pnadddate.Visible = true;
                        }
                        else
                        {
                            this.chkdaytype.Checked = false;
                            this.pnadddate.Visible = false;
                        }
                        #endregion
                       

                        MultiView1.ActiveViewIndex = 1;
                        hdinsertupdate.Value = "update";
                        hdid.Value = dt[0].ID.ToString();
                    }
                    break;
                #endregion

                #region ChangeStatus
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
                        SGioithieu.UPDATE_STATUS(str2, str3);
                        this.LoadItems();
                        return;
                    }
                    return;
                #endregion

                #region updat_date
                case "updat_date":
                    SGioithieu.UPDATE_DATETIME(e.CommandArgument.ToString(), Convert.ToDateTime(DateTime.Now.ToString()), Convert.ToDateTime(DateTime.Now.AddYears(20).ToString()));
                    this.LoadItems();
                    MultiView1.ActiveViewIndex = 0;
                    base.Response.Redirect(base.Request.Url.ToString().Trim());
                    return;
                case "Chekdata":
                    SGioithieu.CHECKDATA(e.CommandArgument.ToString(), "0", Convert.ToDateTime(DateTime.Now.ToString()), Convert.ToDateTime(DateTime.Now.AddYears(20).ToString()));
                    this.LoadItems();
                    MultiView1.ActiveViewIndex = 0;
                    base.Response.Redirect(base.Request.Url.ToString().Trim());
                    return;
                #endregion

                #region Delete
                case "Delete":
                    dt = SGioithieu.GET_DETAIL_BYID(e.CommandArgument.ToString());
                    if (dt.Count > 0)
                    {
                        try
                        {
                            File.Delete(utlitities.APPL_PHYSICAL_PATH + dt[0].Images.ToString());

                        }
                        catch (Exception) { }
                        try
                        {
                            SGioithieu.Name_Text("DELETE FROM Gioithieu WHERE TangName=N'" + dt[0].TangName + "'");
                        }
                        catch (Exception)
                        { }
                    }
                    SGioithieu.DELETE(e.CommandArgument.ToString());
                    LoadItems();
                    break;
                #endregion
            }
        }

        protected void lnkcreatenew_Click(object sender, EventArgs e)
        {
            hdinsertupdate.Value = "insert";
            MultiView1.ActiveViewIndex = 1;
            DeleteFormValue();
            this.txtfromday.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
        }

        protected void ddlordertype_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItems(); LoadRequest();
        }

        protected void ddlorderby_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItems(); LoadRequest();
        }

        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItems(); LoadRequest();
        }

        protected void btDeleteall_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < rpitems.Items.Count; i++)
                {
                    CheckBox chk = (CheckBox)rpitems.Items[i].FindControl("chkid");
                    HiddenField id = (HiddenField)rpitems.Items[i].FindControl("hiID");
                    if (chk.Checked)
                    {
                        #region Delete
                        List<Entity.Gioithieu> dlt = new List<Entity.Gioithieu>();
                        dlt = SGioithieu.GET_DETAIL_BYID(id.Value);
                        for (int j = 0; j < dlt.Count; j++)
                        {
                            try
                            {
                                File.Delete(utlitities.APPL_PHYSICAL_PATH + dlt[j].Images.ToString());

                            }
                            catch (Exception) { }
                            try
                            {
                                SGioithieu.Name_Text("DELETE FROM Gioithieu WHERE TangName=N'" + dlt[j].TangName + "'");
                            }
                            catch (Exception)
                            { }
                        }
                        #endregion
                        SGioithieu.DELETE(id.Value);
                    }
                }
                LoadItems();
            }
            catch (Exception) { }
        }

     
        protected void lnksearch_Click(object sender, EventArgs e)
        {
            LoadItems();
            LoadRequest();
        }

        protected void bthienthi_Click(object sender, EventArgs e)
        {
            LoadItems();
            LoadRequest();
        }

        protected void btDeleteimages_Click(object sender, EventArgs e)
        {
            List<Entity.Gioithieu> str5 = SGioithieu.GET_BY_ID(hdid.Value);
            if (str5.Count > 0)
            {
                try
                {
                    ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
                    File.Delete(utlitities.APPL_PHYSICAL_PATH + str5[0].Images.ToString());
                }
                catch (Exception) { }
            }
            this.hdimg.Value = "";
            SGioithieu.UPDATE_IMG(hdid.Value);
            this.LoadItems();
            ltimg.Text = "";
            MultiView1.ActiveViewIndex = 1;
        }
        protected void LoadRequest()
        {
            Response.Redirect("admin.aspx?u=Gioithieu&st=" + ddlstatus.SelectedValue + "&us=" + ddlorderby.SelectedValue + "&ds=" + ddlordertype.SelectedValue + "&kw=" + txtkeyword.Text + "");
        }
        protected void chkdaytype_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkdaytype.Checked)
            {
                this.pnadddate.Visible = true;
            }
            else
            {
                this.pnadddate.Visible = false;
            }
        }
    }
}