using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using System.IO;
using Services;
using Entity;
using System.Drawing.Imaging;

namespace VS.ECommerce_MVC.cms.Admin.Products
{
    public partial class Album : System.Web.UI.UserControl
    {
        private string lang = Captionlanguage.Language;
        private string ipid = "-1";
        private string icid = "-1";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["icid"] != null && !Request["icid"].Equals(""))
            {
                icid = Request["icid"];
               
            }
            if (Request["ipid"] != null && !Request["ipid"].Equals(""))
            {
                ipid = Request["ipid"];

            }
            if (System.Web.HttpContext.Current.Session["lang"] != null)
            {
                this.lang = System.Web.HttpContext.Current.Session["lang"].ToString();
            }
            else
            {
                System.Web.HttpContext.Current.Session["lang"] = this.lang;
                this.lang = System.Web.HttpContext.Current.Session["lang"].ToString();
            }
            if (!base.IsPostBack)
            {
                this.UpdateList();
                LoadItemsProduct();
            }
        }

        void LoadItemsProduct()
        {
            try
            {
                List<Entity.Products> dt = SProducts.GetById(ipid);
                rpitems.DataSource = dt;
                rpitems.DataBind();
            }
            catch (Exception) { }
        }

        protected void btn_InsertUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txt_title.Text.Trim().Length < 0)
                {
                    this.lblmsg.Text = "Xin vui lòng kiểm tra dữ liệu đầu vào của bạn";
                }
                else if (!ValidateUtilities.IsValidInt(this.txt_order.Text.Trim()))
                {
                    this.lblmsg.Text = "Xin vui lòng kiểm tra dữ liệu đầu vào của bạn!";
                }
                else
                {
                    string status = "0";
                    if (this.chck_Enable.Checked)
                    {
                        status = "1";
                    }
                    #region Img
                    string vimg = this.txtvimg.Text;
                    hdimgsmall.Value = vimg;
                    hdimgMax.Value = vimg;
                    ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
                    int vkey = 1;
                    string path = "";
                    string small = "";
                    if (this.rdFromComputer.Checked)
                    {
                        if ((this.flimage.FileName.Trim().Length > 0) && (this.flimage.PostedFile.ContentLength > 0))
                        {
                            String paths = "/Uploads/prods/";
                            path = Path.GetFileName(this.flimage.PostedFile.FileName);
                            string str6 = "";
                            str6 = Path.GetExtension(path).ToLower();
                            vimg = paths + DateTime.Now.Ticks.ToString() + str6;
                            flimage.PostedFile.SaveAs(AppDomain.CurrentDomain.BaseDirectory + vimg);
                            small = paths + DateTime.Now.Ticks.ToString() + "SMall" + str6;
                            Database.ResizeIamgesFix(Server.MapPath(vimg), Server.MapPath(small), Convert.ToInt32(AllQuery.MorePro.Height()), Convert.ToInt32(AllQuery.MorePro.Width()));
                        }
                        else
                        {
                            if ((this.txtvimg.Text.Trim().Length > 0))
                            {
                                vimg = this.hdFileName.Value;
                            }
                        }
                        vkey = 0;
                    }
                    #endregion
                    Entity.Product_images obj = new Entity.Product_images();

                    string str5 = this.hd_insertupdate.Value.Trim();
                    if (str5 != null)
                    {
                        if (!(str5 == "update"))
                        {
                            if (str5 == "insert")
                            {
                                #region MyRegion
                                obj.ipid = int.Parse(ipid);
                                obj.icid = int.Parse(icid);
                                obj.Title = this.txt_title.Text.Trim();
                                obj.Brief = txtNoiDung.Text;
                                obj.Images = vimg;
                                obj.ImagesSmall = small;
                                obj.Equals = vkey;
                                obj.Orders = int.Parse(this.txt_order.Text.Trim());
                                obj.Status = int.Parse(status);
                                #endregion
                                SProduct_images.Insert(obj);
                            }
                        }
                        else
                        {
                            #region Delete
                            if (vimg.Equals(""))
                            {
                                vimg = this.hdimgMaxEdit.Value;
                            }
                            if (small.Equals(""))
                            {
                                small = this.hdimgsmallEdit.Value;
                            }
                            else
                            {
                                try
                                {
                                    if ((this.flimage.FileName.Trim().Length > 0) && (this.flimage.PostedFile.ContentLength > 0))
                                    {
                                        File.Delete(utlitities.APPL_PHYSICAL_PATH + this.hdimgMaxEdit.Value);
                                        File.Delete(utlitities.APPL_PHYSICAL_PATH + this.hdimgsmallEdit.Value);
                                    }
                                    if (this.txtvimg.Text.Trim().Length > 0)
                                    {
                                        File.Delete(utlitities.APPL_PHYSICAL_PATH + this.hdimgMaxEdit.Value);
                                        File.Delete(utlitities.APPL_PHYSICAL_PATH + this.hdimgsmallEdit.Value);
                                    }
                                }
                                catch (Exception) { }
                            }
                            #endregion

                            #region MyRegion
                            obj.ID = int.Parse(this.hd_page_edit_id.Value);
                            obj.ipid = int.Parse(ipid);
                            obj.icid = int.Parse(icid);
                            obj.Title = this.txt_title.Text.Trim();
                            obj.Brief = txtNoiDung.Text;
                            obj.Images = vimg;
                            obj.ImagesSmall = small;
                            obj.Equals = vkey;
                            obj.Orders = int.Parse(this.txt_order.Text.Trim());
                            obj.Status = int.Parse(status);
                            #endregion
                            SProduct_images.Update(obj);
                        }
                    }
                    this.UpdateList();
                    this.pn_list.Visible = true;
                    this.pn_insert.Visible = false;
                    this.hd_insertupdate.Value = "";
                    this.txt_title.Text = "";
                    this.txt_order.Text = "1";
                    this.txtvimg.Text = "";
                    this.hdFileName.Value = "";
                    ltimg.Text = "";
                    this.lblmsg.Text = "";
                    txtNoiDung.Text = "";
                }
            }
            catch (Exception) { }
        }

        public bool ThumbnailCallback()
        {
            return false;
        }

        private void btn_link_cancel_Click(object sender, EventArgs e)
        {
            this.pn_list.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.hd_insertupdate.Value = "";
            this.pn_list.Visible = true;
            this.pn_insert.Visible = false;
        }

        protected void Delete_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('xóa bài viết này ?')";
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            this.pn_list.Visible = false;
            this.pn_insert.Visible = true;
            this.hd_insertupdate.Value = "insert";
            this.hd_page_edit_id.Value = "-1";
            this.txtvimg.Text = "";
            this.hdFileName.Value = "";
            ltimg.Text = "";
            this.txtNoiDung.Text = "";
        }

        protected void rp_pagelist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string str = e.CommandName.Trim();
            string str2 = e.CommandArgument.ToString().Trim();
            string str4 = str;
            if (str4 != null)
            {
                string str3;
                if (!(str4 == "EditDetail"))
                {
                    if (!(str4 == "ChangeStatus"))
                    {
                        if (!(str4 == "ListChildren"))
                        {
                            if (str4 == "Delete")
                            {
                                try
                                {
                                    #region Xoa anh Va danh sach
                                    //Xóa danh mục
                                    int k;
                                    List<Product_images> str1 = SProduct_images.GetById(str2);
                                    for (k = 0; k < str1.Count; k++)
                                    {
                                        try
                                        {
                                            ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
                                            File.Delete(utlitities.APPL_PHYSICAL_PATH + str1[k].Images.ToString());
                                            File.Delete(utlitities.APPL_PHYSICAL_PATH + str1[k].ImagesSmall.ToString());
                                        }
                                        catch (Exception) { }
                                    }
                                    #endregion
                                    SProduct_images.Delete(str2);
                                    this.UpdateList();
                                    this.ltmsg.Text = "";
                                }
                                catch (Exception)
                                {
                                    this.ltmsg.Text = "<span class=alert> Xóa thông tin trong phân mục này trước khi muốn xóa nó!</a>";
                                }
                            }
                            return;
                        }
                        this.hd_id.Value = str2;
                        this.UpdateList();
                        return;
                    }
                }
                else
                {
                    this.btn_InsertUpdate.Text = "Cập nhật";
                    this.pn_list.Visible = false;
                    this.pn_insert.Visible = true;
                    this.hd_insertupdate.Value = "update";
                    this.hd_page_edit_id.Value = str2.Trim();
                    List<Product_images> table = new List<Product_images>();
                    table = SProduct_images.GetById(str2);
                    if (table.Count > 0)
                    {
                        this.hdid.Value = table[0].ipid.ToString().Trim();
                        this.txt_title.Text = table[0].Title.ToString().Trim();
                        this.txt_order.Text = table[0].Orders.ToString().Trim();
                        this.txtNoiDung.Text = table[0].Brief.ToString().Trim();
                        hdimgMaxEdit.Value = table[0].Images.ToString();
                        hdimgsmallEdit.Value = table[0].ImagesSmall.ToString();
                        ltimg.Text = MoreImage.Image(table[0].ImagesSmall.ToString());
                        if (table[0].Status.ToString().Trim().Equals("0"))
                        {
                            this.chck_Enable.Checked = false;
                        }
                        else if (table[0].Status.ToString().Equals("1"))
                        {
                            this.chck_Enable.Checked = true;
                        }
                        this.chck_Enable.Checked = true;
                        if (table[0].Equals.ToString().Trim().Equals("1"))
                        {
                            this.rdFromLinks.Checked = true;
                            this.rdFromComputer.Checked = false;
                            this.LoadView();
                            this.txtvimg.Text = table[0].Images.ToString();
                        }
                        else
                        {
                            this.rdFromComputer.Checked = true;
                            this.rdFromLinks.Checked = false;
                            this.LoadView();
                            this.hdFileName.Value = table[0].Images.ToString();
                        }
                    }
                    return;
                }
                str2 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                {
                    str3 = "0";
                }
                else
                {
                    str3 = "1";
                }
                SProduct_images.upate_status(str2, str3);
                this.UpdateList();
            }
        }

        private void UpdateList()
        {
            try
            {
                List<Product_images> table = SProduct_images.GetBy_ipid(ipid);
                this.rp_pagelist.DataSource = table;
                this.rp_pagelist.DataBind();
            }
            catch (Exception) { }
        }

        protected void btxoa_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < rp_pagelist.Items.Count; i++)
                {
                    CheckBox chk = (CheckBox)rp_pagelist.Items[i].FindControl("chkid");
                    HiddenField id = (HiddenField)rp_pagelist.Items[i].FindControl("hiID");
                    if (chk.Checked)
                    {
                        #region Xoa danh sach tin va anh
                        //Xóa danh mục
                        int k;
                        List<Product_images> str = SProduct_images.GetById(id.Value);
                        for (k = 0; k < str.Count; k++)
                        {
                            try
                            {
                                ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
                                File.Delete(utlitities.APPL_PHYSICAL_PATH + str[k].Images.ToString());
                                File.Delete(utlitities.APPL_PHYSICAL_PATH + str[k].ImagesSmall.ToString());
                            }
                            catch (Exception) { }
                        }
                        #endregion
                        SProduct_images.Delete(id.Value);
                    }
                }
                UpdateList();
            }
            catch (Exception)
            {
            }
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

        protected void btDeleteimages_Click(object sender, EventArgs e)
        {
            List<Entity.Product_images> str5 = SProduct_images.GetById(hdid.Value);
            if (str5.Count > 0)
            {
                try
                {
                    ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
                    File.Delete(utlitities.APPL_PHYSICAL_PATH + str5[0].Images.ToString());
                    File.Delete(utlitities.APPL_PHYSICAL_PATH + str5[0].ImagesSmall.ToString());
                }
                catch (Exception) { }
            }
            this.hdimgMaxEdit.Value = "";
            this.hdimgsmallEdit.Value = "";
            SProduct_images.Update_img(hdid.Value, "", "");
            this.UpdateList();
            ltimg.Text = "";
            this.pn_list.Visible = false;
            this.pn_insert.Visible = true;
        }

       
    }
}