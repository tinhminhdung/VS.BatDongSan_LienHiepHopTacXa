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
    public partial class DMAdvertisingNews : System.Web.UI.UserControl
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
                LoadCategories();
                LoadItems();
            }
        }

        #region Menu
        protected void LoadCategories()
        {
            try
            {
                if (Request["id"] != null && !Request["id"].Equals(""))
                {
                    ddlvalue.SelectedValue = Request["id"];
                }
                int str = 0;
                List<Entity.Menu> dt = SMenu.Name_Text("SELECT * FROM [Menu]  where capp='" + More.NS + "' and Lang='" + this.lang + "'  and Parent_ID=-1 and Status=1 order by Orders asc");
                //SMenu.LOAD_CATESPARENT_ID(More.PR, this.lang, "-1", "1");
                for (int i = 0; i < dt.Count; i++)
                {
                    if (dt[i].Parent_ID.ToString() == "-1")
                    {
                        ddlvalue.Items.Insert(str, new ListItem(dt[i].Name.ToString(), dt[i].ID.ToString()));
                        ddllocal.Items.Insert(str, new ListItem(dt[i].Name.ToString(), dt[i].ID.ToString()));
                        str = str + 1;
                        str = Categories(dt[i].ID.ToString(), str, "===");
                    }
                }
                this.ddlvalue.DataBind();
                this.ddllocal.DataBind();
            }
            catch (Exception) { }
        }
        #region Menu
        protected int Categories(string id, int str, string j)
        {
            List<Entity.Menu> dt = SMenu.LOAD_CATESPARENT_ID(More.PR, this.lang, id, "1");
            for (int i = 0; i < dt.Count; i++)
            {
                if (dt[i].Parent_ID.ToString() == id)
                {
                    ddlvalue.Items.Insert(str, new ListItem(j + dt[i].Name.ToString(), dt[i].ID.ToString()));
                    ddllocal.Items.Insert(str, new ListItem(j + dt[i].Name.ToString(), dt[i].ID.ToString()));
                    str = str + 1;
                    str = Categories(dt[i].ID.ToString(), str, j + j);
                }
            }
            return str;
        }
        #endregion
        #endregion

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, "VIE");
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
                RemoveCache.News();
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
                    #region image
                    int vkey = 1;
                    string vimg = this.txtvimg.Text;
                    string path = "";
                    if (this.rdFromComputer.Checked)
                    {
                        if ((this.flimage.FileName.Trim().Length > 0) && (this.flimage.PostedFile.ContentLength > 0))
                        {
                            path = Path.GetFileName(this.flimage.PostedFile.FileName);
                            string str6 = "";
                            str6 = Path.GetExtension(path).ToLower();
                            if ((!str6.Equals(".jpg") && !str6.Equals(".gif")) && (!str6.Equals(".bmp") && !str6.Equals(".png") && !str6.Equals(".swf")))
                            {
                                this.lbl_msg.Visible = true;
                                this.lbl_msg.Text = "Kh\x00f4ng hỗ trợ dạng *" + str6 + ". Chỉ hỗ trợ định dạng *.jpg,*.gif,*.bmp,*.png,*.swf";
                                return;
                            }
                            vimg = "/Uploads/pic/advs/" + DateTime.Now.Ticks.ToString() + str6;
                            flimage.PostedFile.SaveAs(AppDomain.CurrentDomain.BaseDirectory + vimg);
                        }
                        else
                        {
                            if (this.txtvimg.Text.Trim().Length > 0)
                            {
                                vimg = this.hdFileName.Value;
                            }
                        }
                        vkey = 0;
                    }
                    #endregion


                    Entity.Advertisings obj = new Entity.Advertisings();
                    if (this.hdinsertupdate.Value.Equals("insert"))
                    {
                        #region Insert
                        obj.Name = txtname.Text;
                        obj.Path = txtSupport.Text;
                        obj.value = int.Parse(ddllocal.SelectedValue);
                        obj.Equals = vkey;
                        obj.vimg = vimg;
                        obj.lang = lang;
                        obj.Orders = int.Parse(txtoder.Text);
                        obj.Views = 0;
                        obj.Width = int.Parse(txtwidth.Text);
                        obj.Height = int.Parse(txtheight.Text);
                        obj.Opentype = int.Parse(ddlopentype.SelectedValue);
                        obj.Text = int.Parse(ddlvitri.SelectedValue);
                        obj.Contents = txtmota.Text;
                        obj.Chekdata = Chekdata;
                        obj.Create_Date = dcreatedate;
                        obj.Modified_Date = denddate;
                        obj.Type = int.Parse(ddltype.SelectedValue);
                        obj.Youtube = "";
                        obj.Status = status;
                        SAdvertisings.INSERT(obj);
                        #endregion
                    }
                    else
                    {
                        #region Delete
                        if (vimg.Equals(""))
                        {
                            vimg = this.hdimg.Value;
                        }
                        else
                        {
                            try
                            {
                                if ((this.flimage.FileName.Trim().Length > 0) && (this.flimage.PostedFile.ContentLength > 0))
                                {
                                    File.Delete(utlitities.APPL_PHYSICAL_PATH + this.hdimg.Value);
                                }
                                if (this.txtvimg.Text.Trim().Length > 0)
                                {
                                    File.Delete(utlitities.APPL_PHYSICAL_PATH + this.hdimg.Value);
                                }
                            }
                            catch (Exception) { }
                        }
                        #endregion
                        #region Update
                        obj.images = int.Parse(hdid.Value);
                        obj.Name = txtname.Text;
                        obj.Path = txtSupport.Text;
                        obj.value = int.Parse(ddllocal.SelectedValue);
                        obj.Equals = vkey;
                        obj.vimg = vimg;
                        obj.lang = lang;
                        obj.Orders = int.Parse(txtoder.Text);
                        obj.Views = 0;
                        obj.Width = int.Parse(txtwidth.Text);
                        obj.Height = int.Parse(txtheight.Text);
                        obj.Opentype = int.Parse(ddlopentype.SelectedValue);
                        obj.Text = int.Parse(ddlvitri.SelectedValue);
                        obj.Contents = txtmota.Text;
                        obj.Chekdata = Chekdata;
                        obj.Create_Date = dcreatedate;
                        obj.Modified_Date = denddate;
                        obj.Type = int.Parse(ddltype.SelectedValue);
                        obj.Youtube = "";
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
            WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddltype, "0");
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
                        this.ltimg.Text = Image(dt[0].vimg.ToString(), dt[0].Type.ToString());
                        this.txtname.Text = dt[0].Name.ToString();
                        this.txtSupport.Text = dt[0].Path.ToString();
                        this.txtoder.Text = dt[0].Orders.ToString();
                        this.txtwidth.Text = dt[0].Width.ToString();
                        this.txtheight.Text = dt[0].Height.ToString();
                        this.txtmota.Text = dt[0].Contents.ToString();

                        WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlvitri, dt[0].Text.ToString());
                        WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlopentype, dt[0].Opentype.ToString());
                        WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddltype, dt[0].Type.ToString());
                        WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddllocal, dt[0].value.ToString());
                        if (dt[0].Equals.ToString().Trim().Equals("1"))
                        {
                            this.rdFromLinks.Checked = true;
                            this.rdFromComputer.Checked = false;
                            this.LoadView();
                            this.txtvimg.Text = dt[0].vimg.ToString();
                        }
                        else
                        {
                            this.rdFromComputer.Checked = true;
                            this.rdFromLinks.Checked = false;
                            this.LoadView();
                            this.hdFileName.Value = dt[0].vimg.ToString();
                        }

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
                            PanelLink03.Visible = true;
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
                    List<Entity.Advertisings> table = SAdvertisings.GETBYID(e.CommandArgument.ToString());
                    if (table.Count > 0)
                    {
                        try
                        {
                            File.Delete(utlitities.APPL_PHYSICAL_PATH + table[0].vimg.ToString());
                        }
                        catch (Exception) { }
                    }
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
            ltimg.Text = "";
            this.txtvimg.Text = "";
            this.hdFileName.Value = "";
            this.txtmota.Text = "";
            txtYoutube.Text = "";
        }

        protected void lnkxoa_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete(utlitities.APPL_PHYSICAL_PATH + hdimg.Value);
            }
            catch (Exception) { }
            SAdvertisings.UPDATE2(hdid.Value, "");
            MultiView1.ActiveViewIndex = 1;
            LoadItems();
            hdimg.Value = "";
            ltimg.Text = "";
        }

        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItems();
            Response.Redirect("admin.aspx?u=Advertisings&su=DMAdvertisingNews&value=" + ddlvalue.SelectedValue + "&st=" + ddlstatus.SelectedValue + "");
        }

        protected void rdFromComputer_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadView();
        }

        protected void rdFromLinks_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadView();
        }

        private void LoadView()
        {
            if (this.rdFromComputer.Checked)
            {
                this.MultiView2.SetActiveView(this.vwFromComputer);
            }
            else
            {
                this.MultiView2.SetActiveView(this.vwFromLinks);
            }
        }

        protected void btinsert_Click(object sender, EventArgs e)
        {
            hdinsertupdate.Value = "insert";
            MultiView1.ActiveViewIndex = 1;
            DeleteFormValue();
            this.txtfromday.Text = DateTime.Now.ToString("MM/dd/yyyy");
            WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddllocal, this.ddlvalue.SelectedValue);
            WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddltype, "0");
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
                        #region Xoa danh sach tin va anh
                        int k;
                        List<Entity.Advertisings> str = SAdvertisings.GETBYID(id.Value);
                        for (k = 0; k < str.Count; k++)
                        {
                            try
                            {
                                File.Delete(utlitities.APPL_PHYSICAL_PATH + str[k].vimg.ToString());
                            }
                            catch (Exception) { }
                        }
                        #endregion
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
            Response.Redirect("admin.aspx?u=Advertisings&su=DMAdvertisingNews&value=" + ddlvalue.SelectedValue + "&st=" + ddlstatus.SelectedValue + "");
        }

        public string Image(string images, string Type)
        {
            if (Type.Equals("0"))
            {
                if (images.Length > 0)
                {
                    return "<img src='" + images + "' border=0 width=200><br>";
                }
                else return ("<img src='Uploads/pic/Noimg/titleNoimg4.gif' border=0  style='width:180px;height:180px'>");
            }
            else if (Type.Equals("1"))
            {
                if (images.Length > 0)
                {
                    return "<img src='" + images + "' border=0 width=200><br>";
                }
                else return ("<img src='Uploads/pic/Noimg/titleNoimg4.gif' border=0  style='width:180px;height:180px'>");
            }
            else if (Type.Equals("2"))
            {
                return "<img src='Uploads/pic/Noimg/Youtube.png' border=0 style='width:180px;height:180px'>";
            }
            else if (Type.Equals("3"))
            {
                if (images.Length > 0)
                {
                    return @"<embed style='width:180px;height:180px' align='middle'  quality='high' wmode='transparent' allowscriptaccess='always' flashvars='alink1=" + images + "&amp;atar1=_blank' type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer'  src='" + images + "'><br>";
                }
                else return ("<img src='Uploads/pic/Noimg/titleNoimg4.gif' border=0 style='width:180px;height:180px' >");
            }
            return "";
        }

        protected void bthienthi_Click(object sender, EventArgs e)
        {
            LoadItems();
            Response.Redirect("admin.aspx?u=Advertisings&su=DMAdvertisingNews&value=" + ddlvalue.SelectedValue + "&st=" + ddlstatus.SelectedValue + "");
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
                PanelLink03.Visible = true;
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

        public string Vitri(string enable)
        {
            if (enable.Trim().Equals("1"))
            {
                return "Hiện thị theo danh sách";
            }
            return "Hiển thị theo trang nhóm";
        }

        protected void ddlvalue_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Advertisings&su=DMAdvertisingNews&value=" + ddlvalue.SelectedValue + "&st=" + ddlstatus.SelectedValue + "");
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