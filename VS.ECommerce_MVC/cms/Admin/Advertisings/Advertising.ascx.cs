using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using System.IO;
using MoreAll;
using Entity;

namespace VS.ECommerce_MVC.cms.Admin.Advertisings
{
    public partial class Advertising : System.Web.UI.UserControl
    {
        private string lang = Captionlanguage.Language;
        ServerInfoUtlitities utlitities = new ServerInfoUtlitities();

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
            if (Request["value"] != null && !Request["value"].Equals(""))
            {
                ddlvalue.SelectedValue = Request["value"];
            }
            if (Request["st"] != null && !Request["st"].Equals(""))
            {
                ddlstatus.SelectedValue = Request["st"];
            }
            if (!IsPostBack)
            {
                this.ddlstatus.Items.Add(new ListItem("Tất cả", "-1"));
                this.ddlstatus.Items.Add(new ListItem("Đã duyệt", "1"));
                this.ddlstatus.Items.Add(new ListItem("Chưa duyệt", "0"));
                txtname.Focus();
                LoadItems();
            }
        }


        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void btndisplay_Click(object sender, EventArgs e)
        {
            LoadItems();
        }

        void LoadItems()
        {
            try
            {
                List<Entity.Advertisings> dt = SAdvertisings.CATEGORY_ADMIN(lang, ddlvalue.SelectedValue, ddlstatus.SelectedValue);
                CollectionPager1.DataSource = dt;
                CollectionPager1.BindToControl = rpitems;
                CollectionPager1.MaxPages = 10000;
                CollectionPager1.PageSize = 10;
                rpitems.DataSource = CollectionPager1.DataSourcePaged;
                rpitems.DataBind();
				 RemoveCache.QuangCao();
            }
            catch (Exception) { }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateUtilities.IsValidInt(this.txtoder.Text.Trim()))
                {
                    this.lbl_msg.Text = "Xin vui lòng kiểm tra dữ liệu đầu vào của bạn!";
                }
                else
                {
                    #region chcek
                    WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlvalue, this.ddllocal.SelectedValue);
                    int status = 0;
                    if (chkstatus.Checked == true)
                    {
                        status = 1;
                    }
                    int text = 0;
                    if (chkdisplaytitle.Checked == true)
                    {
                        text = 1;
                    }
                    #endregion
                    #region Chekdata
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

                    Entity.Advertisings obj = new Entity.Advertisings();
                    if (this.hdinsertupdate.Value.Equals("insert"))
                    {
                        #region Insert
                        obj.Name = txtname.Text;
                        obj.Path = txtSupport.Text;
                        obj.value = int.Parse(ddllocal.SelectedValue);
                        obj.Equals = 0;
                        obj.vimg = txtImage.Text;
                        obj.lang = lang;
                        obj.Orders = int.Parse(txtoder.Text);
                        obj.Views = 0;
                        obj.Width = int.Parse(txtwidth.Text);
                        obj.Height = int.Parse(txtheight.Text);
                        obj.Opentype = int.Parse(ddlopentype.SelectedValue);
                        obj.Text = text;
                        obj.Contents = txtmota.Text;
                        obj.Chekdata = Chekdata;
                        obj.Create_Date = dcreatedate;
                        obj.Modified_Date = denddate;
                        obj.Type = int.Parse(ddltype.SelectedValue);
                        obj.Youtube = txtYoutube.Text;
                        obj.Status = status;
                        SAdvertisings.INSERT(obj);
                        #endregion
                    }
                    else
                    {

                        #region Update
                        obj.images = int.Parse(hdid.Value);
                        obj.Name = txtname.Text;
                        obj.Path = txtSupport.Text;
                        obj.value = int.Parse(ddllocal.SelectedValue);
                        obj.Equals = 0;
                        obj.vimg = txtImage.Text;
                        obj.lang = lang;
                        obj.Orders = int.Parse(txtoder.Text);
                        obj.Views = 0;
                        obj.Width = int.Parse(txtwidth.Text);
                        obj.Height = int.Parse(txtheight.Text);
                        obj.Opentype = int.Parse(ddlopentype.SelectedValue);
                        obj.Text = text;
                        obj.Contents = txtmota.Text;
                        obj.Chekdata = Chekdata;
                        obj.Create_Date = dcreatedate;
                        obj.Modified_Date = denddate;
                        obj.Type = int.Parse(ddltype.SelectedValue);
                        obj.Youtube = txtYoutube.Text;
                        obj.Status = status;
                        SAdvertisings.UPDATE(obj);
                        #endregion
                    }
                    MultiView1.ActiveViewIndex = 0;
                    LoadItems();
                }
            }
            catch (Exception) { }
        }

        protected void linkcreatenew_Click(object sender, EventArgs e)
        {
            hdinsertupdate.Value = "insert";
            MultiView1.ActiveViewIndex = 1;
            DeleteFormValue();
            this.txtfromday.Text = DateTime.Now.ToString("MM/dd/yyyy");
            WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddllocal, this.ddlvalue.SelectedValue);
            WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddltype, "1");
            PanelLink01.Visible = true;
            PanelLink02.Visible = true;
            PanelYoutube.Visible = false;
            PanelLink03.Visible = false;
            PanelLink04.Visible = true;
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            DeleteFormValue();
            LoadItems();
        }

        protected void Delete_Load(object sender, System.EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Xóa Thông Tin vừa Chọn?')";
        }

        protected void rpitems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                #region update
                case "update":
                    List<Entity.Advertisings> dt = SAdvertisings.GETBYID(e.CommandArgument.ToString());
                    if (dt.Count > 0)
                    {
                        this.hdimg.Value = dt[0].vimg.ToString();
                        // this.ltimg.Text = 
                        this.txtname.Text = dt[0].Name.ToString();
                        this.txtSupport.Text = dt[0].Path.ToString();
                        this.txtoder.Text = dt[0].Orders.ToString();
                        this.txtwidth.Text = dt[0].Width.ToString();
                        this.txtheight.Text = dt[0].Height.ToString();
                        this.txtmota.Text = dt[0].Contents.ToString();
                        txtYoutube.Text = dt[0].Youtube.ToString();


                        txtImage.Text = dt[0].vimg;
                        ltimgs.Text = Image(dt[0].vimg.ToString(), dt[0].Type.ToString());
                        hdimgnews.Value = dt[0].vimg;
                        hdFileName.Value = dt[0].vimg.ToString();


                        WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlopentype, dt[0].Opentype.ToString());
                        WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddltype, dt[0].Type.ToString());
                        WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddllocal, dt[0].value.ToString());

                        #region Update
                        this.txtfromday.Text = Convert.ToDateTime(dt[0].Create_Date).ToString("MM/dd/yyyy");
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

                        if (dt[0].Type.ToString().Equals("2"))//Video Youtube
                        {
                            PanelLink01.Visible = false;
                            PanelLink02.Visible = false;
                            PanelYoutube.Visible = true;
                            PanelLink03.Visible = false;
                            PanelLink04.Visible = false;
                        }
                        else if (dt[0].Type.ToString().Equals("0"))//Text
                        {
                            PanelLink01.Visible = false;
                            PanelLink02.Visible = true;
                            PanelYoutube.Visible = false;
                            PanelLink03.Visible = true;
                            PanelLink04.Visible = false;
                        }
                        else if (dt[0].Type.ToString().Equals("1"))//Image
                        {
                            PanelLink01.Visible = true;
                            PanelLink02.Visible = true;
                            PanelYoutube.Visible = false;
                            PanelLink03.Visible = false;
                            PanelLink04.Visible = true;
                        }
                        else if (dt[0].Type.ToString().Equals("3"))//Flash
                        {
                            PanelLink01.Visible = true;
                            PanelLink02.Visible = true;
                            PanelYoutube.Visible = false;
                            PanelLink03.Visible = false;
                            PanelLink04.Visible = true;
                        }
                        if (dt[0].Status.ToString().Equals("1"))
                        {
                            this.chkstatus.Checked = true;
                        }
                        else
                        {
                            this.chkstatus.Checked = false;
                        }
                        if (dt[0].Text.ToString().Equals("1"))
                        {
                            this.chkdisplaytitle.Checked = true;
                        }
                        else
                        {
                            this.chkdisplaytitle.Checked = false;
                        }
                    }
                    hdid.Value = e.CommandArgument.ToString();
                    MultiView1.ActiveViewIndex = 1;
                    hdinsertupdate.Value = "update";
                    break;
                #endregion
                #region ChangeStatus
                case "ChangeStatus":
                    string str = e.CommandName.Trim();
                    string str2 = e.CommandArgument.ToString().Trim();
                    string str4 = str;
                    if (str4 != null)
                    {
                        string image;
                        str2 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                        if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                        {
                            image = "0";
                        }
                        else
                        {
                            image = "1";
                        }
                        SAdvertisings.CATEUPDATE(str2, image);
                        this.LoadItems();
                        return;
                    }
                    break;
                #endregion
                #region delete
                case "delete":
                 
                    SAdvertisings.DELETE(e.CommandArgument.ToString());
                    LoadItems();
                    break;
                #endregion
            }
        }

        void DeleteFormValue()
        {
            txtname.Text = "";
            txtSupport.Text = "";
            this.txtoder.Text = "1";
            this.txtwidth.Text = "0";
            this.txtheight.Text = "0";
            ltimgs.Text = "";
            this.txtImage.Text = "";
            this.hdFileName.Value = "";
            this.txtmota.Text = "";
            txtYoutube.Text = "";
            txtImage.Text = "";
            hdimgnews.Value = "";
            ltimgs.Text = "";
        }


        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItems();
            Response.Redirect("admin.aspx?u=Advertisings&value=" + ddlvalue.SelectedValue + "&st=" + ddlstatus.SelectedValue + "");
        }
        protected void btinsert_Click(object sender, EventArgs e)
        {
            hdinsertupdate.Value = "insert";
            MultiView1.ActiveViewIndex = 1;
            DeleteFormValue();
            this.txtfromday.Text = DateTime.Now.ToString("MM/dd/yyyy");
            WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddllocal, this.ddlvalue.SelectedValue);
            WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddltype, "1");
            PanelLink01.Visible = true;
            PanelLink02.Visible = true;
            PanelYoutube.Visible = false;
            PanelLink03.Visible = false;
            PanelLink04.Visible = true;
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
                        SAdvertisings.DELETE(id.Value);
                    }
                }
                LoadItems();
            }
            catch (Exception) { }
        }

        protected void ddlvalue_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItems();
            Response.Redirect("admin.aspx?u=Advertisings&value=" + ddlvalue.SelectedValue + "&st=" + ddlstatus.SelectedValue + "");
        }

        public string Image(string images, string Type)
        {
            if (Type.Equals("0"))
            {
                return "Trang Text";
            }
            else if (Type.Equals("1"))
            {
                if (images.Length > 0)
                {
                    return "<img src='" + images + "' border=0 width=200><br>";
                }
                else return ("<img src='Uploads/Noimg/titleNoimg4.gif' border=0  style='width:180px;height:180px'>");
            }
            else if (Type.Equals("2"))
            {
                return "<img src='Uploads/Noimg/Youtube.png' border=0 style='width:180px;height:180px'>";
            }
            else if (Type.Equals("3"))
            {
                if (images.Length > 0)
                {
                    return @"<embed style='width:180px;height:180px' align='middle'  quality='high' wmode='transparent' allowscriptaccess='always' flashvars='alink1=" + images + "&amp;atar1=_blank' type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer'  src='" + images + "'><br>";
                }
                else return ("<img src='Uploads/Noimg/titleNoimg4.gif' border=0 style='width:180px;height:180px' >");
            }
            return "";
        }

        protected void bthienthi_Click(object sender, EventArgs e)
        {
            LoadItems();
            Response.Redirect("admin.aspx?u=Advertisings&value=" + ddlvalue.SelectedValue + "&st=" + ddlstatus.SelectedValue + "");
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

        protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddltype.SelectedValue.Equals("2"))
            {
                PanelLink01.Visible = false;
                PanelLink02.Visible = false;
                PanelYoutube.Visible = true;
                PanelLink03.Visible = false;
                PanelLink04.Visible = false;
            }
            else if (ddltype.SelectedValue.Equals("3"))
            {
                PanelLink01.Visible = true;
                PanelLink02.Visible = true;
                PanelYoutube.Visible = false;
                PanelLink03.Visible = false;
                PanelLink04.Visible = true;
            }
            else if (ddltype.SelectedValue.Equals("1"))
            {
                PanelLink01.Visible = true;
                PanelLink02.Visible = true;
                PanelYoutube.Visible = false;
                PanelLink03.Visible = false;
                PanelLink04.Visible = true;
            }
            else if (ddltype.SelectedValue.Equals("0"))
            {
                PanelLink01.Visible = false;
                PanelLink02.Visible = true;
                PanelYoutube.Visible = false;
                PanelLink03.Visible = true;
                PanelLink04.Visible = false;
            }
        }

        protected void txtxWidth_TextChanged(object sender, EventArgs e)
        {
            TextBox Width = (TextBox)sender;
            var b = (HiddenField)Width.FindControl("hiID");
            if (MoreAll.RegularExpressions.phone(b.Value) == true)
            {
                ltthongbao.Text = "Độ rộng phải là số";
            }
            else
            {
                List<Entity.Advertisings> strid = SAdvertisings.GETBYID(b.Value);
                if (strid.Count > 0)
                {
                    SAdvertisings.Name_Text("update Advertisings set Width='" + Width.Text + "' where images=" + b.Value + " ");
                }
                ltthongbao.Text = "Cập nhật Độ rộng thành công";
                LoadItems();
            }
        }

        protected void txtxHeight_TextChanged(object sender, EventArgs e)
        {
            TextBox Height = (TextBox)sender;
            var b = (HiddenField)Height.FindControl("hiID");
            if (MoreAll.RegularExpressions.phone(b.Value) == true)
            {
                ltthongbao.Text = "Độ cao phải là số";
            }
            else
            {
                List<Entity.Advertisings> strid = SAdvertisings.GETBYID(b.Value);
                if (strid.Count > 0)
                {
                    SAdvertisings.Name_Text("update Advertisings set Height='" + Height.Text + "' where images=" + b.Value + " ");
                }
                ltthongbao.Text = "Cập nhật Độ cao thành công";
                LoadItems();
            }
        }
    }
}