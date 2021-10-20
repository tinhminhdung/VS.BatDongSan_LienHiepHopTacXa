using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using MoreAll;
using Entity;
using System.Data;
using Framwork;
using FlexCel.XlsAdapter;
using FlexCel.Core;
using System.Text;

namespace VS.ECommerce_MVC.cms.Admin.Products
{
    public partial class Cart : System.Web.UI.UserControl
    {
        private string status = "1";
        public int i = 1;
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
            this.Page.Form.DefaultButton = btnshow.UniqueID;
            if (!base.IsPostBack)
            {
                if (Request["st"] != null && !Request["st"].Equals(""))
                {
                    ddlstatus.SelectedValue = Request["st"];
                }
                this.MultiView1.ActiveViewIndex = 0;
				 this.ShowProducts();
            }
           
        }

        //private void ShowProducts()
        //{
        //    try
        //    {
        //         string sql = "select * from Carts ";
        //        if (!ddlstatus.SelectedValue.Equals("-1"))
        //        {
        //            sql = sql + "  where Status=" + ddlstatus.SelectedValue + " ";
        //        }
        //        if (txtkeyword.Text.Length > 0)
        //        {
        //            sql = sql + " and  (dbo.fuConvertToUnsign(Name) LIKE N'" + Framwork.FCarts.SearchApproximate.Exec(Framwork.FCarts.ConvertVN.Convert(txtkeyword.Text)) + "' OR Address LIKE N'" + Framwork.FCarts.SearchApproximate.Exec(Framwork.FCarts.ConvertVN.Convert(txtkeyword.Text)) + "' OR Phone LIKE N'" + Framwork.FCarts.SearchApproximate.Exec(Framwork.FCarts.ConvertVN.Convert(txtkeyword.Text)) + "' OR Email LIKE N'" + Framwork.FCarts.SearchApproximate.Exec(Framwork.FCarts.ConvertVN.Convert(txtkeyword.Text)) + "' OR Money LIKE N'" + Framwork.FCarts.SearchApproximate.Exec(Framwork.FCarts.ConvertVN.Convert(txtkeyword.Text)) + "') ";
        //        }
        //        sql = sql + " order by Create_Date desc";
        //        List<LCart> dt = db.ExecuteQuery<LCart>(@"" + sql + "").ToList();
        //        //List<Carts> dt = SCarts.p_cartslist_count(ddlstatus.SelectedValue, txtkeyword.Text);
        //        CollectionPager1.DataSource = dt;
        //        CollectionPager1.BindToControl = rp_items;
        //        CollectionPager1.MaxPages = 10000;
        //        CollectionPager1.PageSize = 10;
        //        rp_items.DataSource = CollectionPager1.DataSourcePaged;
        //        rp_items.DataBind();
        //    }
        //    catch (Exception) { }
        //}
        public void ShowProducts()
        {
            string sql = "";
            if (!ddlstatus.SelectedValue.Equals("-1"))
            {
                sql += " and Status=" + ddlstatus.SelectedValue + " ";
            }
            if (txtkeyword.Text.Length > 0)
            {
                sql += " and (dbo.fuConvertToUnsign(Name) LIKE N'" + Framwork.FCarts.SearchApproximate.Exec(Framwork.FCarts.ConvertVN.Convert(txtkeyword.Text)) + "' OR Address LIKE N'" + Framwork.FCarts.SearchApproximate.Exec(Framwork.FCarts.ConvertVN.Convert(txtkeyword.Text)) + "' OR Phone LIKE N'" + Framwork.FCarts.SearchApproximate.Exec(Framwork.FCarts.ConvertVN.Convert(txtkeyword.Text)) + "' OR Email LIKE N'" + Framwork.FCarts.SearchApproximate.Exec(Framwork.FCarts.ConvertVN.Convert(txtkeyword.Text)) + "' OR Money LIKE N'" + Framwork.FCarts.SearchApproximate.Exec(Framwork.FCarts.ConvertVN.Convert(txtkeyword.Text)) + "') ";
            }
            int Tongsobanghi = 0;
            Int16 pages = 1;
            int Tongsotrang = int.Parse("20");
            if ((Request.QueryString["page"] != null) && (Request.QueryString["page"] != ""))
            {
                pages = Convert.ToInt16(Request.QueryString["page"].Trim());
            }
            List<LCart> iitem = db.ExecuteQuery<LCart>(@"SELECT * FROM Carts where 1=1 " + sql + " order by Create_Date desc").ToList();
            if (iitem.Count() > 0)
            {
                Tongsobanghi = iitem.Count();
            }
            int PageIndex = (pages - 1);
            int Tongpage = Tongsotrang;
            int StartRecord = PageIndex * Tongpage;
            int EndRecord = StartRecord + Tongpage + 1;
            List<LCart> dt = db.ExecuteQuery<LCart>(@"SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY Create_Date DESC) AS rowindex ,*  FROM  Carts  where 1=1 " + sql + " ) AS A WHERE  ( A.rowindex >  " + StartRecord.ToString() + " AND A.rowindex < " + EndRecord + ")").ToList();
            //if (dt.Count >= 1)
            {
                rp_items.DataSource = dt;
                rp_items.DataBind();
            }
            if (Tongsobanghi % Tongsotrang > 0)
            {
                Tongsobanghi = (Tongsobanghi / Tongsotrang) + 1;
            }
            else
            {
                Tongsobanghi = Tongsobanghi / Tongsotrang;
            }
            ltpage.Text = Commond.PhantrangAdmin("/admin.aspx?u=carts", Tongsobanghi, pages);
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            this.MultiView1.ActiveViewIndex = 0;
        }
        protected void btnSend_Click(object sender, EventArgs e)
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
                    MailUtilities.SendMail(this.txttoname.Text.Trim(), email, password, this.txtTo.Text, host, port, this.txttitle.Text.Trim(), this.txtContent.Text.Trim());
                    this.MultiView1.ActiveViewIndex = 0;
                }
            }
            catch (Exception ex)
            {
                this.lblmsg.Text = "Hệ thống Email của bạn có thể chưa điền hoặc chưa điền đúng hoặc chưa đúng thông tài khoản Gmail mà chúng tôi yêu cầu " + ex.Message;
            }
        }
        protected void btnshow_Click(object sender, EventArgs e)
        {
            this.ShowProducts();
        }

        protected void Delete_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Xóa đơn hàng này ?')";
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void Pass_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Xử lý ?')";
        }

        protected void rp_items_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string str = e.CommandName.Trim();
            string ID = e.CommandArgument.ToString();
            string str4 = str;
            if (str4 != null)
            {
                if (!(str4 == "Delete"))
                {
                    if (str4 == "Check")
                    {
                        List<Entity.CartDetail> strid = SCartDetail.Name_Text("select * from CartDetail where ID_Cart=" + ID + "  ");
                        if (strid.Count > 0)
                        {
                            for (int i = 0; i < strid.Count; i++)
                            {
                                List<Entity.Products> dt = SProducts.Name_Text("select * from Products where ipid=" + strid[i].ipid + "  ");
                                if (dt.Count > 0)
                                {
                                    for (int j = 0; j < dt.Count; j++)
                                    {
                                        if (dt[j].ipid.ToString() == strid[i].ipid.ToString())
                                        {
                                            if (dt[j].Quantity.ToString() != "0")
                                            {
                                                double hientai = Convert.ToDouble(dt[j].Quantity.ToString());
                                                if (hientai.ToString().Length > 0)
                                                {
                                                    // Khóa tạm khi nào có số lượng ở sản phẩm thì mở cái này ra để nó tự động tính
                                                    // hiện tại bên danh sách sản phẩm đang khóa ô số lượng lại\

                                                    //double cu = Convert.ToDouble(strid[i].Quantity.ToString());
                                                    //double Tong = (hientai - cu);
                                                    //Tong = System.Math.Round(Tong, 0);
                                                    //int number = int.Parse(Tong.ToString());
                                                    //if (number < 0)
                                                    //{
                                                    //    SProducts.Name_Text("update products set Quantity=0 where ipid=" + strid[i].ipid.ToString() + " ");
                                                    //}
                                                    //else
                                                    //{
                                                    //    SProducts.Name_Text("update products set Quantity=" + Tong.ToString().Replace("-", "") + " where ipid=" + strid[i].ipid.ToString() + " ");
                                                    //}
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                        }
                        SCarts.UpdateStatus(ID, "1");
                    }
                    else if (str4 == "UnCheck")
                    {
                        SCarts.UpdateStatus(ID, "0");
                    }
                    else if (str4 == "Detail")
                    {
                        List<Entity.CartDetail> table = SCartDetail.Detail_ID_Cart(e.CommandArgument.ToString());
                        this.rpcartdetail.DataSource = table;
                        this.rpcartdetail.DataBind();
                        List<Entity.Carts> dt1 = SCarts.Carts_GetById(e.CommandArgument.ToString());
                        if (dt1.Count > 0)
                        {
                            ltname.Text = dt1[0].Name.ToString();
                            ltdienthoai.Text = dt1[0].Phone.ToString();
                            ltemail.Text = dt1[0].Email.ToString();
                            ltdiachi.Text = dt1[0].Address.ToString();
                            lttong.Text = AllQuery.MorePro.Detail_Price(dt1[0].Money.ToString());
                            lthinhthucgiaohang.Text = dt1[0].Phuongthucthanhtoan.ToString();
                            ltthanhtoan.Text = dt1[0].Hinhthucvanchuyen.ToString();
                            ltghichu.Text = dt1[0].Contents;
                            ltvietchu.Text = ConvertSoRaChu(dt1[0].Money);
                        }
                        this.MultiView1.ActiveViewIndex = 2;
                    }
                    else if (str4 == "SendMail")
                    {
                        List<Entity.CartDetail> table = new List<Entity.CartDetail>();
                        table = SCartDetail.Detail_ID_Cart(e.CommandArgument.ToString());
                        if (table.Count > 0)
                        {
                            List<Carts> table2 = SCarts.Carts_GetById(table[0].ID_Cart.ToString());
                            if (table2.Count > 0)
                            {
                                this.txtTo.Text = table2[0].Email.ToString();
                                this.txttoname.Text = table2[0].Name.ToString();
                                string str3 = ("Th\x00e2n ch\x00e0o bạn: " + this.txttoname.Text.Trim() + "<br>") + "Bạn c\x00f3 đặt h\x00e0ng tại c\x00f4ng ty của ch\x00fang t\x00f4i như sau: <br>";
                                DataTable table3 = new DataTable();
                                FCartDetail db = new FCartDetail();
                                db.CartDetail_List_Cart_Pro(table3, ID);
                                if (table3.Rows.Count > 0)
                                {
                                    string str5 = str3;
                                    str3 = str5 + "<table  border='0' width='100%' cellpadding='3' style='border-collapse: collapse' id='table1'><tr height='22' bgcolor='Gainsboro'><td>Tên sản phẩm &nbsp;</td><td align='right'> Giá </td><td align='right'> Số lượng &nbsp;</td><td align='right'>Thành tiền &nbsp;</td></tr>";
                                    for (int i = 0; i < table3.Rows.Count; i++)
                                    {
                                        string str6 = str3;
                                        str3 = str6 + "<tr height='22'><td>" + table3.Rows[i]["Name"].ToString() + "&nbsp;</td><td align='right' width='100'>" + AllQuery.MorePro.FormatMoney(table3.Rows[i]["Price"].ToString()) + "&nbsp;</td><td align='right' width='100'>" + table3.Rows[i]["Quantity"].ToString() + "&nbsp;</td><td align='right'  width='100'>" + AllQuery.MorePro.FormatMoney(table3.Rows[i]["Money"].ToString()) + "&nbsp;</td></tr>";
                                    }
                                    #region Tong Gia Tien
                                    string Tong = "0";
                                    if (table3.Rows.Count > 0)
                                    {
                                        double num = 0.0;
                                        for (int i = 0; i < table3.Rows.Count; i++)
                                        {
                                            num += Convert.ToDouble(table3.Rows[i]["Money"].ToString());
                                        }
                                        Tong = num.ToString();
                                    }
                                    #endregion
                                    str3 = str3 + "<tr height='22' align=right><td colspan='4'>" + AllQuery.MorePro.FormatMoney(Tong.ToString()) + "</td></tr>";
                                    str3 = str3 + "</table><br /><br /><br /><br /><br />";
                                }
                                this.txtContent.Text = str3;
                            }
                        }
                        this.MultiView1.ActiveViewIndex = 1;
                    }
                }
                else
                {
                    SCartDetail.Delete_by_CartID(e.CommandArgument.ToString());
                    SCarts.Carts_Delete(e.CommandArgument.ToString());
                }

            }
            this.ShowProducts();
            
        }

        protected void UnPass_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Hủy bỏ ?')";
        }

        protected bool Visible(string status)
        {
            if (status.Equals("1"))
            {
                return false;
            }
            return true;
        }

        protected bool Visible_(string status)
        {
            if (status.Equals("0"))
            {
                return false;
            }
            return true;
        }

        protected string Thanhtoan(string ID)
        {
            LCart abc = db.LCarts.SingleOrDefault(p => p.ID == int.Parse(ID));
            if (abc.StatusGiaoDich.ToString().Equals("1"))
            {
                return "color:#fff; padding:3px; font-weight:bold; background:#fe0505; border-radius:5px; width:250px";
            }
            return "color:#fff; padding:3px; font-weight:bold; background:#ff619c; border-radius:5px; width:250px";
        }
        protected void btxoa_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < rp_items.Items.Count; i++)
                {
                    CheckBox chk = (CheckBox)rp_items.Items[i].FindControl("chkid");
                    HiddenField id = (HiddenField)rp_items.Items[i].FindControl("hiID");
                    if (chk.Checked)
                    {
                        SCartDetail.Delete_by_CartID(id.Value);
                        SCarts.Carts_Delete(id.Value);
                    }
                }
                ShowProducts();
                base.Response.Redirect(base.Request.Url.ToString().Trim());
            }
            catch (Exception) { }
        }
        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowProducts();
            Response.Redirect("admin.aspx?u=pro&su=carts&st=" + ddlstatus.SelectedValue + "");
        }
        protected void ddltrangthai_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddltrangthai = (DropDownList)sender;
            var id = (HiddenField)ddltrangthai.FindControl("hiID");
            List<Entity.Carts> list = SCarts.Name_Text("select * from Carts where id=" + id.Value + "  ");
            if (list.Count > 0)
            {
                SCarts.UpdateStatus(id.Value, ddltrangthai.SelectedValue);
            }
            ShowProducts();
            lblmsg.Text = "Cập nhật cấp nhóm sản phẩm thành công !!";
            Response.Redirect("admin.aspx?u=pro&su=carts&st=" + ddlstatus.SelectedValue + "");
        }
        protected void rp_items_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DropDownList ddltrangthai = (e.Item.FindControl("ddltrangthai") as DropDownList);
                HiddenField id = (e.Item.FindControl("hdStatus") as HiddenField);
                if (id.Value != "")
                {
                    ddltrangthai.SelectedValue = id.Value;
                }
            }
        }
        protected void Export_Click(object sender, EventArgs e)
        {
            string Namefile = "Danhsachdondathang";
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
            sb.Append("    <b>Ghi chú</b>");
            sb.Append("  </th>");
            sb.Append("  </tr>");
            List<Carts> dt = SCarts.p_cartslist_count(ddlstatus.SelectedValue, txtkeyword.Text);
            if (dt.Count > 0)
            {
                int i = 1;
                foreach (var item in dt)
                {
                    sb.Append("    <tr style='background:#f334ad'>");
                    sb.Append("    <td style=\"width:50px; vertical-align:middle; height: 22px; text-align: center;\">" + i++ + "</td>");
                    sb.Append("    <td style=\"width:150px; vertical-align:middle;text-align: center;\">" + item.Name + "</td>");
                    sb.Append("    <td style=\"width:400px; vertical-align:middle; text-align: center;\">" + item.Address + "</td>");
                    sb.Append("    <td style=\"width:250px; vertical-align:middle;text-align: center;\">" + item.Phone + "</td>");
                    sb.Append("    <td style=\"width:150px; vertical-align:middle;text-align: center;\">" + item.Email + "</td>");
                    sb.Append("    <td style=\"width:520px; vertical-align:middle; text-align: center;\">" + item.Contents + "</td>");
                    sb.Append("  </tr>");

                    List<Entity.CartDetail> table = SCartDetail.Detail_ID_Cart(item.ID.ToString());
                    if (table.Count > 0)
                    {
                        sb.Append("<tr>");
                        sb.Append("    <td style=\"vertical-align:middle; height: 22px; text-align: center;\" colspan=\"6\">");
                        sb.Append(" <table border='1' bgcolor='#ffffff' bordercolor='#ffa903'  cellspacing='0' cellpadding='0' style='font-size:12px; font-family:Arial; background:white;'>");
                        sb.Append("<tr style=\" background:#dcdcdc\">");
                        sb.Append("  <th style=\"width:50px; vertical-align:middle; height: 22px;\">");
                        sb.Append("    <b>STT</b>");
                        sb.Append("  </th>");
                        sb.Append("  <th style=\"width:130px; vertical-align:middle;\">");
                        sb.Append("    <b>Mã sản phẩm</b>");
                        sb.Append("  </th>");
                        sb.Append("  <th style=\"width:400px; vertical-align:middle;\">");
                        sb.Append("    <b>Tên sản phẩm</b>");
                        sb.Append("  </th>");
                        sb.Append("  <th style=\"width:186px; vertical-align:middle;\">");
                        sb.Append("    <b>Số lượng</b>");
                        sb.Append("  </th>");
                        sb.Append("  <th style=\"width:120px; vertical-align:middle;\">");
                        sb.Append("    <b>Đ.V tính</b>");
                        sb.Append("  </th>");
                        sb.Append("  <th style=\"width:160px; vertical-align:middle;\">");
                        sb.Append("    <b>Đơn giá</b>");
                        sb.Append("  </th>");
                        sb.Append("  <th style=\"width:160px; vertical-align:middle;\">");
                        sb.Append("    <b>Thành tiền</b>");
                        sb.Append("  </th>");
                        sb.Append("  </tr>");
                        int j = 1;
                        foreach (var item1 in table)
                        {
                            sb.Append("    <tr style=''>");
                            sb.Append("    <td style=\"width:50px; vertical-align:middle; height: 22px; text-align: center;\">" + j++ + "</td>");
                            sb.Append("    <td style=\"width:130px; vertical-align:middle;text-align: center;\">" + Code(item1.ipid.ToString()) + "</td>");
                            sb.Append("    <td style=\"width:400px; vertical-align:middle; text-align: left;\">" + item1.Name + "</td>");
                            sb.Append("    <td style=\"width:186px; vertical-align:middle;text-align: center;\">" + item1.Quantity + "</td>");
                            sb.Append("    <td style=\"width:120px; vertical-align:middle;text-align: center;\">VNĐ</td>");
                            sb.Append("    <td style=\"width:160px; vertical-align:middle; text-align: center;\">" + AllQuery.MorePro.Detail_Price(item1.Price.ToString()) + "</td>");
                            sb.Append("        <td style=\"width:160px; vertical-align:middle; text-align: center;\">" + AllQuery.MorePro.Detail_Price(item1.Money.ToString()) + "</td>");
                            sb.Append("  </tr>");
                        }
                        sb.Append(" </tr>");

                        sb.Append("  <tr>");
                        sb.Append(" <td style=\"vertical-align:middle; height: 22px; text-align: center;font-weight:bold\" colspan=\"3\">Tổng cộng</td>");
                        sb.Append("<td style=\"width:200px; vertical-align:middle;\">" + Soluong(item.ID.ToString()) + "</td>");
                        sb.Append(" <td style=\"vertical-align:middle;\" colspan=\"2\">&nbsp;</td>");
                        sb.Append(" <td style=\"width:120px; vertical-align:middle; text-align: center;\">" + AllQuery.MorePro.Detail_Price(item.Money.ToString()) + "</td>");
                        sb.Append(" </tr>");
                        sb.Append("  <tr><td style=\"vertical-align:middle; height: 22px; text-align: center;font-weight:bold\" colspan=\"7\">" + ConvertSoRaChu(item.Money) + "</td>");
                        sb.Append("  <tr><td style=\"vertical-align:middle; height: 22px; text-align: center;font-weight:bold\" colspan=\"7\"></td>");

                        sb.Append("    </table>");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                    }

                }
            }
            sb.Append("</table>");
            Response.Write(sb.ToString());
            Response.Flush();
            Response.End();
        }
        protected string Soluong(string ID_Cart)
        {
            string totalvnd = "0";
            List<Entity.CartDetail> cartdetail = SCartDetail.Detail_ID_Cart(ID_Cart);
            if (cartdetail.Count > 0)
            {
                if (cartdetail.Count > 0)
                {
                    double num = 0.0;
                    for (int i = 0; i < cartdetail.Count; i++)
                    {
                        num += Convert.ToDouble(cartdetail[i].Quantity.ToString());
                    }
                    totalvnd = num.ToString();
                }
            }
            return totalvnd;
        }
        #region Hàm đổi số ra chữ
        private string Chu(string gNumber)
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
        private string Donvi(string so)
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
        private string Tach(string tach3)
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
        public string ConvertSoRaChu(double gNum)
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
        #endregion
        protected string Quantity(string id)
        {
            string str = "";
            List<Entity.Products> dt = SProducts.GetById(id);
            if (dt.Count > 0)
            {
                str += dt[0].Quantity.ToString();
            }
            return str.ToString();
        }
        protected string Code(string id)
        {
            string str = "";
            List<Entity.Products> dt = SProducts.GetById(id);
            if (dt.Count > 0)
            {
                str += dt[0].Code.ToString();
            }
            return str.ToString();
        }
        protected string Name(string id)
        {
            string str = "";
            List<Entity.Products> dt = SProducts.GetById(id);
            if (dt.Count > 0)
            {
                str += dt[0].Name.ToString();
            }
            return str.ToString();
        }


        // chi tiết giỏ hàng


        protected string Anh(string id)
        {
            string str = "";
            List<Entity.Products> dt = SProducts.GetById(id);
            if (dt.Count > 0)
            {
                str += dt[0].Images.ToString();
            }
            return str.ToString();
        }
        protected string Codes(string id)
        {
            string str = "";
            List<Entity.Products> dt = SProducts.GetById(id);
            if (dt.Count > 0)
            {
                str += dt[0].Code.ToString();
            }
            return str.ToString();
        }
        protected string Kho(string id)
        {
            string str = "";
            List<Entity.Products> dt = SProducts.GetById(id);
            if (dt.Count > 0)
            {
                str = dt[0].Quantity.ToString();
            }
            return str.ToString();
        }
        protected string Kichthuoc(string id)
        {
            string str = "";
            List<Entity.Menu> dt = SMenu.GETBYID(id);
            if (dt.Count > 0)
            {
                str += dt[0].Name.ToString();
            }
            return str.ToString();
        }
        protected string Mausac(string id)
        {
            string str = "";
            List<Entity.Menu> dt = SMenu.GETBYID(id);
            if (dt.Count > 0)
            {
                str += "<img src=\"" + dt[0].Images.ToString() + "\" style=\"width:28px; height:28px;border:solid 1px #d7d7d7\" />";
            }
            return str.ToString();
        }

    }
}