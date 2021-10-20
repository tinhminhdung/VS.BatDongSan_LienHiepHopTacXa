using MoreAll;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS.ECommerce_MVC.cms.Admin.Page
{
    public partial class Menu_Page : System.Web.UI.UserControl
    {
        //pagPosition =Views
        //Styleshow=
        //obj.Styleshow = drlKieuxuathien.SelectedValue;
        //drlVitri.SelectedValue = Views
        #region[Declare Varian]
        private string lang = Captionlanguage.Language;
        private string status = "";
        DatalinqDataContext db = new DatalinqDataContext();
        #endregion
        #region[Page_Load]
        public class pageType
        {
            public static string GP = "100"; // Nhóm: sản phẩm - grou product
            public static string GN = "200"; // Nhóm: tin tức - group new
            public static string GL = "300"; // Nhóm: thư viện - group library
            public static string ND = "800"; // Nhóm: chi tiết tin tức - new detail
            public static string PD = "900"; // Nhóm: chi tiết sản phẩm - product detail    
            public static string LD = "400"; // Nhóm: chi tiết thư viện - library detail
            // Nhóm menu
            public static string ML = "1"; // Menu kiểu liên kết trang - menu link
            public static string MC = "2"; // Menu kiểu nội dung - menu
            public static string MU = "3"; // Menu kiểu liên kết URL - menu url
            public static string HP = "4"; // Trang chủ - home page
            public static string MN = "5";// Tin tức - menu new
            public static string MP = "6";// Sản phẩm - menu product
            public static string MPn = "7";// Sản phẩm mới - menu product new
            public static string MPnb = "17";// Sản phẩm noi bat - menu product new
            public static string MPbc = "18";// Sản phẩm ban chay - menu product new
            public static string MPkm = "19";// Sản phẩm km - menu product new
            public static string PC = "8";// Giỏ hàng - product cart
            public static string LP = "9";// Thư viện - library page
            public static string CP = "10";// Liên hệ - contact page
            public static string VD = "20";// Thư viện - library page

            public static string RG = "11";// Đăng ký thành viên - register
            public static string FP = "12";// Quên mật khẩu - forgot password
            public static string CPw = "13";// Đổi mật khẩu - change password
            public static string UI = "14";// Thông tin tài khoản - user info
            public static string LO = "15";// Đơn hàng - list order
            public static string PM = "16";// Thanh toán - payment
        }

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
                ddlstatus.SelectedValue = Request["st"];
                WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlstatus, this.status);
            }
            if (Request["Vitri"] != null && !Request["Vitri"].Equals(""))
            {
                try
                {
                    drlFilterVitri.SelectedValue = Request["Vitri"];
                }
                catch (Exception)
                { }
            }
            if (Request["pa"] != null && !Request["pa"].Equals(""))
            {
                ddlPage.SelectedValue = Request["pa"];
            }
            if (!IsPostBack)
            {
                LoadGroupLink();
                Showthutu();
                Shownhomchuyenmuc();
                Viewcategory();
                ViewVideo();
                ViewLibrary();
                Viewcapacha();
                LoadItems();
            }
        }
        #endregion
        private void LoadGroupLink()
        {
            drlNhomlienket.Items.Add(new ListItem("Chọn nhóm liên kết", "0"));
            drlNhomlienket.Items.Add(new ListItem("Trang chủ", pageType.HP));
            drlNhomlienket.Items.Add(new ListItem("Tin tức", pageType.MN));
            drlNhomlienket.Items.Add(new ListItem("Sản phẩm", pageType.MP));//PD

            //drlNhomlienket.Items.Add(new ListItem("Sản phẩm mới", pageType.MPn));
            //drlNhomlienket.Items.Add(new ListItem("Sản phẩm nổi bật", pageType.MPnb));
            //drlNhomlienket.Items.Add(new ListItem("Sản phẩm bán chạy", pageType.MPbc));
            //drlNhomlienket.Items.Add(new ListItem("Sản phẩm khuyến mại", pageType.MPkm));

            // drlNhomlienket.Items.Add(new ListItem("Giỏ hàng", pageType.PC));
            drlNhomlienket.Items.Add(new ListItem("Thư viện ảnh", pageType.LP));
            drlNhomlienket.Items.Add(new ListItem("Thư viện video", pageType.VD));//VD
            drlNhomlienket.Items.Add(new ListItem("Liên hệ", pageType.CP));

            //drlNhomlienket.Items.Add(new ListItem("Đăng ký thành viên", pageType.RG));
            //drlNhomlienket.Items.Add(new ListItem("Quên mật khẩu", pageType.FP));
            //drlNhomlienket.Items.Add(new ListItem("Đổi mật khẩu", pageType.CPw));
            //drlNhomlienket.Items.Add(new ListItem("Thông tin tài khoản", pageType.UI));

            //drlNhomlienket.Items.Add(new ListItem("Đơn hàng", pageType.LO));
            //drlNhomlienket.Items.Add(new ListItem("Thanh toán", pageType.PM));
        }
        //void LoadItems()
        //{
        //    string sql = "";
        //    string spage = "";
        //    if (drlFilterVitri.SelectedValue != "0")
        //    {
        //        sql += " and Views=" + drlFilterVitri.SelectedValue + " ";
        //    }
        //    if (ddlstatus.SelectedValue != "-1")
        //    {
        //        sql += " and status=" + ddlstatus.SelectedValue + " ";
        //    }
        //    List<Entity.Menu> list = SMenu.Name_Text("SELECT * FROM Menu where capp='" + More.MN + "' and lang='" + lang + "' " + sql + " order by level,Orders asc");
        //    if (drlFilterVitri.SelectedValue != "0")
        //    {
        //        list = list.Where(u => u.Views == int.Parse(drlFilterVitri.SelectedValue)).ToList();
        //    }
        //    ltrTotalProduct.Text = "<span style='color: #A52A2A;'>" + list.Count() + "</span> / <span style='color: #333;'>" + ddlPage.SelectedValue + "</span>";
        //    CollectionPager1.DataSource = list;
        //    CollectionPager1.BindToControl = rptDanhsach;
        //    CollectionPager1.MaxPages = 10000;
        //    CollectionPager1.PageSize = int.Parse(ddlPage.SelectedValue);
        //    rptDanhsach.DataSource = CollectionPager1.DataSourcePaged;
        //    rptDanhsach.DataBind();
        //    RemoveCache.Menu();
        //}

        public void LoadItems()
        {
            string sql = "";
            if (drlFilterVitri.SelectedValue != "0")
            {
                sql += " and Views=" + drlFilterVitri.SelectedValue + " ";
            }
            if (ddlstatus.SelectedValue != "-1")
            {
                sql += " and status=" + ddlstatus.SelectedValue + " ";
            }
            int Tongsobanghi = 0;
            Int16 pages = 1;
            int Tongsotrang = int.Parse(ddlPage.SelectedValue);

            if ((Request.QueryString["page"] != null) && (Request.QueryString["page"] != ""))
            {
                pages = Convert.ToInt16(Request.QueryString["page"].Trim());
            }
            List<Menu> iitem = db.ExecuteQuery<Menu>(@"SELECT * FROM Menu where capp='" + More.MN + "' and lang='" + lang + "' " + sql + " order by level,Orders asc").ToList();
            if (iitem.Count() > 0)
            {
                Tongsobanghi = iitem.Count();
            }
            int PageIndex = (pages - 1);
            int Tongpage = Tongsotrang;
            int StartRecord = PageIndex * Tongpage;
            int EndRecord = StartRecord + Tongpage + 1;
            List<Menu> dt = db.ExecuteQuery<Menu>(@"SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY level,Orders asc) AS rowindex ,*  FROM  Menu  where capp='" + More.MN + "' and lang='" + lang + "' " + sql + ") AS A WHERE  ( A.rowindex >  " + StartRecord.ToString() + " AND A.rowindex < " + EndRecord + ")").ToList();
            //if (dt.Count >= 1)
            {
                ltrTotalProduct.Text = "<span style='color: #A52A2A;'>" + dt.Count() + "</span> / <span style='color: #333;'>" + ddlPage.SelectedValue + "</span>";
                rptDanhsach.DataSource = dt;
                rptDanhsach.DataBind();
            }
            if (Tongsobanghi % Tongsotrang > 0)
            {
                Tongsobanghi = (Tongsobanghi / Tongsotrang) + 1;
            }
            else
            {
                Tongsobanghi = Tongsobanghi / Tongsotrang;
            }
            ltpage.Text = Commond.PhantrangAdmin("/admin.aspx?u=Page&Vitri=" + drlFilterVitri.SelectedValue + "&st=" + ddlstatus.SelectedValue + "&pa=" + ddlPage.SelectedValue + "", Tongsobanghi, pages);
            RemoveCache.Menu();
        }

        #region Showchuyenmuc
        protected void Shownhomchuyenmuc()
        {
            try
            {
                int str = 0;
                List<Entity.Menu> dt = SMenu.LOAD_CATESPARENT_ID(More.NS, this.lang, "-1", "1");
                ddlNews.Items.Clear();
                for (int i = 0; i < dt.Count; i++)
                {
                    if (dt[i].Parent_ID.ToString() == "-1")
                    {
                        ddlNews.Items.Insert(str, new ListItem(dt[i].Name.ToString(), dt[i].ID.ToString()));
                        str = str + 1;
                        str = CategoriesNews(dt[i].ID.ToString(), str, "---");
                    }
                }
                this.ddlNews.Items.Insert(0, new ListItem(" >> DANH SÁCH TIN TỨC << ", "0"));
                this.ddlNews.DataBind();
                dt.Clear();
                dt = null;
            }
            catch (Exception) { }
        }
        protected int CategoriesNews(string id, int str, string j)
        {
            List<Entity.Menu> dt = SMenu.LOAD_CATESPARENT_ID(More.NS, this.lang, id, "1");
            for (int i = 0; i < dt.Count; i++)
            {
                if (dt[i].Parent_ID.ToString() == id)
                {
                    ddlNews.Items.Insert(str, new ListItem(j + dt[i].Name.ToString(), dt[i].ID.ToString()));
                    str = str + 1;
                    str = CategoriesNews(dt[i].ID.ToString(), str, j + j);
                }
            }
            dt.Clear();
            dt = null;
            return str;
        }
        #endregion

        #region[Showthutu]
        void Showthutu()
        {
            drlThutu.Items.Clear();
            for (int i = 1; i < 251; i++)
            {
                drlThutu.Items.Add(i.ToString());
            }
        }
        #endregion
        #region[Delete]
        protected void Delete(object sender, System.EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Bạn chắc chắn muốn xóa thông tin vừa chọn !!') ";
        }
        #endregion
        #region[Kichhoat]
        protected string Kichhoat(string actives)
        {
            string Chuoi = "";
            if (actives == "1")
            {
                Chuoi = "có";
            }
            else
            {
                Chuoi = "không";
            }
            return Chuoi;
        }
        #endregion
        #region[Vitri]
        protected string Vitri(string vitri)
        {
            string Chuoi = "";
            if (vitri == "1")
            {
                Chuoi = "<span style='background:#009147;color:#fff;padding:5px'>Menu trên</span>";
            }
            else if (vitri == "2")
            {
                Chuoi = "<span style='background:#fd7603;color:#fff;padding:5px'>Menu dưới</span>";
            }
            else if (vitri == "3")
            {
                Chuoi = "<span style='background:#e895c2;color:#fff;padding:5px'>Menu trái</span>";
            }
            else
            {
                Chuoi = "<span style='background:#02c3ad;color:#fff;padding:5px'>Hỏi Chưa xác định</span>";
            }
            return Chuoi;
        }
        #endregion

        #region[rptDanhsach_ItemCommand]
        protected void rptDanhsach_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string Id = e.CommandArgument.ToString();

            switch (e.CommandName.ToString())
            {
                case "ChangeStatus":
                    Menu abc = db.Menus.SingleOrDefault(p => p.ID == int.Parse(Id));
                    abc.ID = int.Parse(Id);
                    if (abc.Status == 0)
                    {
                        abc.Status = 1;
                    }
                    else
                    {
                        abc.Status = 0;
                    }
                    db.SubmitChanges();
                    lblThongbao.Text = "Cập nhật trạng thái thành công!!";
                    LoadItems();
                    break;
                case "Edit":
                    var list = db.Menus.Where(u => u.ID == Convert.ToInt32(Id)).ToList();
                    HidId.Value = list[0].ID.ToString();
                    hd_id.Value = list[0].Parent_ID.ToString().Trim();
                    hidLevel.Value = list[0].Level;
                    txtTenmenu.Text = list[0].Name;

                    txtRewriteUrl.Text = list[0].TangName;
                    if (list[0].Type == 3 || list[0].Type == 1)
                    {
                        txtUrl.Text = list[0].Link;
                    }
                    if (list[0].Images.Length > 0)
                    {
                        lblImg.Text = "<img src=\"" + list[0].Images.ToString() + "\" style=\"height:100px\" />";
                        txtImg.Text = list[0].Images.ToString();
                        lbtDelimg.Visible = true;
                    }
                    else
                    {
                        lbtDelimg.Visible = false;
                        lblImg.Text = "";
                        txtImg.Text = "";
                    }
                    txtTieude.Text = list[0].Titleseo;
                    txtDesscription.Text = list[0].Meta;
                    txtKeyword.Text = list[0].Keyword;
                    txtThuTu.Text = list[0].Orders.ToString();
                    Viewcapacha();
                    try
                    {
                        ddlcha.SelectedValue = list[0].Level.Substring(0, list[0].Level.Length - 5);
                    }
                    catch { }
                    if (list[0].Status == 1)
                    {
                        chkKichhoat.Checked = true;
                    }
                    else
                    {
                        chkKichhoat.Checked = false;
                    }
                    if (list[0].Type > 3)
                    {
                        drlKieutrang.SelectedValue = pageType.ML;
                        drlNhomlienket.SelectedValue = list[0].Type.ToString();
                    }
                    else drlKieutrang.SelectedValue = list[0].Type.ToString();
                    fckNoidung.Text = list[0].Description;
                    if (list[0].Type == Convert.ToInt32(pageType.ML) || list[0].Type > 3)
                    {
                        if (list[0].Link != "/")
                        {
                            string strLink = list[0].Link.Substring(0, (list[0].Link.Length - 5));
                            var curLink = db.Menus.Where(s => s.TangName == list[0].TangName && s.Type != int.Parse(pageType.MC)).FirstOrDefault();
                            if (curLink != null)
                            {
                                if (curLink.Type == int.Parse(pageType.MN))//5
                                {
                                    pnNhom.Visible = true;
                                    pnpro.Visible = false;
                                    pnLibrary.Visible = false;
                                    pnVideo.Visible = false;
                                    Menu tbp = db.Menus.FirstOrDefault(s => s.TangName == strLink && s.Module == 1);
                                    if (tbp != null)
                                    {
                                        ddlNews.SelectedValue = tbp.ID.ToString();
                                    }
                                    else
                                    {
                                        //  ddlNews.SelectedValue = "0";
                                    }
                                    ddlNews.Visible = true;


                                    drlNhomlienket.SelectedValue = pageType.MN;
                                }
                                else if (curLink.Type == int.Parse(pageType.MP))
                                {
                                    pnpro.Visible = true;
                                    pnNhom.Visible = false;
                                    pnLibrary.Visible = false;
                                    pnVideo.Visible = false;
                                    Menu tbp = db.Menus.FirstOrDefault(s => s.TangName == strLink && s.Module == 20);
                                    if (tbp != null)
                                    {
                                        ddlProducts.SelectedValue = tbp.ID.ToString();
                                    }
                                    else
                                    {
                                        // ddlProducts.SelectedValue = "0";
                                    }
                                    ddlProducts.Visible = true;
                                    drlNhomlienket.SelectedValue = pageType.MP;
                                }
                                else if (curLink.Type == int.Parse(pageType.LP))
                                {
                                    pnLibrary.Visible = true;
                                    pnpro.Visible = false;
                                    pnNhom.Visible = false;
                                    pnVideo.Visible = false;
                                    Menu tbp = db.Menus.FirstOrDefault(s => s.TangName == strLink && s.Module == 5);
                                    if (tbp != null)
                                    {
                                        ddlAmbum.SelectedValue = tbp.ID.ToString();
                                    }
                                    else
                                    {
                                        ddlAmbum.SelectedValue = "0";
                                    }
                                    ddlAmbum.Visible = true;
                                    drlNhomlienket.SelectedValue = pageType.LP;
                                }
                                else if (curLink.Type == int.Parse(pageType.VD))
                                {
                                    pnVideo.Visible = true;
                                    pnpro.Visible = false;
                                    pnNhom.Visible = false;
                                    pnLibrary.Visible = false;
                                    Menu tbp = db.Menus.FirstOrDefault(s => s.TangName == strLink && s.Module == 7);
                                    if (tbp != null)
                                    {
                                        ddlVideo.SelectedValue = tbp.ID.ToString();
                                    }
                                    else
                                    {
                                        ddlVideo.SelectedValue = "0";
                                    }
                                    ddlVideo.Visible = true;
                                    drlNhomlienket.SelectedValue = pageType.LP;
                                }

                            }
                            else if (list[0].Link == "/san-pham-news.html")
                            {
                                drlNhomlienket.SelectedValue = pageType.MP;
                                pnNhom.Visible = false;
                                pnpro.Visible = false;
                                pnLibrary.Visible = false;
                            }
                            else if (list[0].Link == "/san-pham-moi.html")
                            {
                                drlNhomlienket.SelectedValue = pageType.MPn;
                                pnNhom.Visible = false;
                                pnpro.Visible = false;
                                pnLibrary.Visible = false;
                            }
                            else if (list[0].Link == "/tin-tuc-new.html")
                            {
                                drlNhomlienket.SelectedValue = pageType.MN;
                                pnNhom.Visible = false;
                                pnpro.Visible = false;
                                pnLibrary.Visible = false;
                            }
                            else if (list[0].Link == "/thu-vien-anh.html")
                            {
                                drlNhomlienket.SelectedValue = pageType.LP;
                                pnNhom.Visible = false;
                                pnpro.Visible = false;
                                pnLibrary.Visible = false;
                            }
                            else if (list[0].Link == "/lien-he.html")
                            {
                                drlNhomlienket.SelectedValue = pageType.CP;
                                pnNhom.Visible = false;
                                pnpro.Visible = false;
                                pnLibrary.Visible = false;
                            }
                            else if (list[0].Link == "/dang-ky.html")
                            {
                                drlNhomlienket.SelectedValue = pageType.RG;
                                pnNhom.Visible = false;
                                pnpro.Visible = false;
                                pnLibrary.Visible = false;
                            }
                            else
                            {
                                drlNhomlienket.SelectedValue = "0";
                                pnNhom.Visible = false;
                                pnpro.Visible = false;
                                pnLibrary.Visible = false;
                            }
                        }
                        else
                        {
                            pnNhom.Visible = false;
                            pnpro.Visible = false;
                            pnLibrary.Visible = false;
                            drlNhomlienket.SelectedValue = pageType.HP;
                        }
                        pnKieulienket.Visible = true;
                    }
                    else if (list[0].Type == Convert.ToInt32(pageType.MU))
                    {
                        txtUrl.Text = list[0].Link;
                        pnUrl.Visible = true;
                    }
                    else
                    {
                        pnNoidung.Visible = true;
                        Pnseo.Visible = true;
                    }
                    drlKieuxuathien.SelectedValue = list[0].Styleshow;
                    drlVitri.SelectedValue = list[0].Views.ToString();
                    lblLoi.Text = "";
                    pnDanhsach.Visible = false;
                    pnUpdate.Visible = true;
                    break;
                case "Delete":

                    Menu del = db.Menus.Where(s => s.ID == int.Parse(Id) && s.capp == More.MN).FirstOrDefault();
                    List<Menu> catChild = db.Menus.Where(s => s.Level.Substring(0, del.Level.Length) == del.Level && s.capp == More.MN).ToList();
                    if (catChild.Count() > 0)
                    {
                        for (int i = 0; i < catChild.Count; i++)
                        {
                            // SModulControls.Name_Text("DELETE FROM ModulControls WHERE TangName ='" + catChild[i].TangName + "'");

                            db.Menus.DeleteOnSubmit(catChild[i]);
                            db.SubmitChanges();
                        }
                        LoadItems();
                        lblThongbao.Text = "Xóa thành công menu !!";
                        base.Response.Redirect(base.Request.Url.ToString().Trim());
                    }
                    else
                    {
                        List<Entity.Menu> str5 = SMenu.GETBYID(Id);
                        if (str5.Count > 0)
                        {
                            try
                            {
                                //  SModulControls.Name_Text("DELETE FROM ModulControls WHERE TangName ='" + str5[0].TangName + "'");
                            }
                            catch (Exception)
                            { }
                        }
                        SMenu.DELETE(Id);
                        lblThongbao.Text = "Xóa thành công menu !!";
                        LoadItems();
                        base.Response.Redirect(base.Request.Url.ToString().Trim());
                    }
                    break;
                case "Add":
                    List<Entity.Menu> lists = SMenu.Detail(Id);
                    ltcapcha.Text = "Cấp cha: " + lists[0].Name;
                    this.hd_id.Value = Id;
                    pnDanhsach.Visible = false;
                    pnUpdate.Visible = true;
                    Resetcontrol();
                    hidLevel.Value = lists[0].Level;
                    Viewcapacha();
                    ddlcha.SelectedValue = lists[0].Level;
                    drlVitri.SelectedValue = lists[0].Views.ToString();
                    break;
            }
        }
        #endregion
        #region[Update]
        protected void lbtCapnhat_Click(object sender, EventArgs e)
        {
            WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.drlFilterVitri, this.drlVitri.SelectedValue);
            if (this.txtTenmenu.Text.Trim().Length < 1)
            {
                this.lbl_msg.Text = "Xin vui lòng kiểm tra dữ liệu đầu vào của bạn";
            }
            else
            {
                string img_path = "";
                if (txtImg.Text != "")
                {
                    img_path = txtImg.Text;
                }
                else { img_path = lblImg.Text; }
                string sLink = "";

                string Id = HidId.Value;
                string sgrnlevel = hidLevel.Value;
                if (Id.Length == 0)
                {
                    //#region Menu
                    //string TangName = "";
                    //int cong = 0;
                    //List<Entity.Menu> curItem = SMenu.Name_Text("SELECT top 1 * FROM Menu order by ID desc");
                    //int tong = int.Parse(curItem[0].ID.ToString());
                    //cong = tong + 1;
                    //var hasTagName = db.ModulControls.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtTenmenu.Text)).FirstOrDefault();
                    //TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtTenmenu.Text) + "-" + cong : MoreAll.AddURL.SeoURL(txtTenmenu.Text);
                    //#endregion

                    #region RewriteUrl
                    int cong = 0;
                    string TangName = "";
                    if (txtRewriteUrl.Text.Length > 0)
                    {
                        #region InsertMenu
                        List<Entity.Menu> curItem = SMenu.Name_Text("SELECT top 1 * FROM Menu order by ID desc");
                        int tong = int.Parse(curItem[0].ID.ToString()); cong = tong + 1; var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)).FirstOrDefault(); TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtRewriteUrl.Text) + "-" + cong : MoreAll.AddURL.SeoURL(txtRewriteUrl.Text);
                        #endregion
                    }
                    else
                    {
                        #region InsertMenu
                        List<Entity.Menu> curItem = SMenu.Name_Text("SELECT top 1 * FROM Menu order by ID desc");
                        int tong = int.Parse(curItem[0].ID.ToString()); cong = tong + 1; var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtTenmenu.Text)).FirstOrDefault(); TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtTenmenu.Text) + "-" + cong : MoreAll.AddURL.SeoURL(txtTenmenu.Text);
                        #endregion
                    }
                    #endregion


                    Entity.Menu obj = new Entity.Menu();
                    obj.Parent_ID = Convert.ToInt16(this.hd_id.Value.Trim());
                    obj.capp = More.MN;
                    obj.Type = int.Parse((drlNhomlienket.SelectedValue != "0") ? drlNhomlienket.SelectedValue : drlKieutrang.SelectedValue);
                    obj.Lang = lang;
                    obj.Name = txtTenmenu.Text.Trim();
                    obj.Url_Name = RewriteURLNew.NameToTag(this.txtTenmenu.Text.Trim());
                    #region MyRegion



                    if (drlKieutrang.SelectedValue == pageType.ML)
                    {
                        if (drlNhomlienket.SelectedValue == pageType.MN)
                        {
                            if (ddlNews.SelectedValue != "0")
                            {
                                var grn = db.Menus.Where(s => s.ID == int.Parse(ddlNews.SelectedValue)).First();
                                sLink = "/danh-muc-tin/" + grn.TangName + ".html";
                            }
                            else
                            {
                                sLink = "/tin-tuc-new.html";
                            }
                        }
                        else if (drlNhomlienket.SelectedValue == pageType.MP)
                        {

                            if (ddlProducts.SelectedValue != "0")
                            {
                                var grn = db.Menus.Where(s => s.ID == int.Parse(ddlProducts.SelectedValue)).First();
                                sLink = "/danh-muc/" + grn.TangName + ".html";
                            }
                            else
                            {
                                sLink = "/san-pham-news";
                            }
                        }
                        else if (drlNhomlienket.SelectedValue == pageType.LP)
                        {
                            if (ddlAmbum.SelectedValue != "0")
                            {
                                var grn = db.Menus.Where(s => s.ID == int.Parse(ddlAmbum.SelectedValue)).First();
                                sLink = "/danh-muc-anh/" + grn.TangName + ".html";
                            }
                            else
                            {
                                sLink = "/thu-vien-anh.html";
                            }
                        }
                        else if (drlNhomlienket.SelectedValue == pageType.VD)
                        {
                            if (ddlVideo.SelectedValue != "0")
                            {
                                var grn = db.Menus.Where(s => s.ID == int.Parse(ddlVideo.SelectedValue)).First();
                                sLink = "/danh-muc-video/" + grn.TangName + ".html";
                            }
                            else
                            {
                                sLink = "/thu-vien-video.html";
                            }
                        }
                        //else if (drlNhomlienket.SelectedValue == pageType.CP)
                        //{
                        //    sLink = curItem[0].TangName + "";
                        //}
                        else if (drlNhomlienket.SelectedValue == pageType.MPn)
                        {
                            sLink = "/san-pham-moi.html";
                        }
                        else if (drlNhomlienket.SelectedValue == pageType.MPnb)
                        {
                            sLink = "/san-pham-noi-bat.html";
                        }
                        else if (drlNhomlienket.SelectedValue == pageType.MPbc)
                        {
                            sLink = "/san-pham-ban-chay.html";
                        }
                        else if (drlNhomlienket.SelectedValue == pageType.MPkm)
                        {
                            sLink = "/san-pham-khuyen-mai.html";
                        }
                        else if (drlNhomlienket.SelectedValue == pageType.CP)
                        {
                            sLink = "/lien-he.html";
                        }
                        else if (drlNhomlienket.SelectedValue == pageType.RG)
                        {
                            sLink = "/dang-ky.html";
                        }


                        else
                        {
                            sLink = "/";
                        }
                    }
                    else if (drlKieutrang.SelectedValue == pageType.MU)
                    {
                        sLink = txtUrl.Text;
                    }
                    #endregion
                    obj.Link = sLink;
                    obj.Styleshow = drlKieuxuathien.SelectedValue;
                    obj.Equals = Convert.ToInt16("0");
                    obj.Images = img_path;
                    obj.Description = fckNoidung.Text;
                    obj.Create_Date = DateTime.Now;
                    obj.Views = int.Parse(drlVitri.SelectedValue);//pagPosition  --> thay bằng vị trí là Views
                    obj.ShowID = int.Parse(drlKieutrang.SelectedValue);
                    obj.Orders = Convert.ToInt16(txtThuTu.Text);
                    obj.Level = ddlcha.SelectedValue + "00000";
                    obj.News = 0;
                    obj.page_Home = 0;
                    obj.Status = Convert.ToInt16(chkKichhoat.Checked ? "1" : "0");
                    obj.Titleseo = txtTieude.Text;
                    obj.Meta = txtDesscription.Text;
                    obj.Keyword = txtKeyword.Text;
                    obj.Check_01 = 0;
                    obj.Check_02 = 0;
                    obj.Check_03 = 0;
                    obj.Check_04 = 0;
                    obj.Check_05 = 0;
                    obj.Noidung1 = fckNoidung.Text;
                    obj.Noidung2 = "";
                    obj.Noidung3 = "";
                    obj.Noidung4 = "";
                    obj.Noidung5 = "";
                    obj.Module = 99;
                    obj.TangName = TangName;
                    string tagName = Urltag(txtTenmenu.Text);
                    if (SMenu.Insert(obj))
                    {
                        // #region Check
                        //SMenu.Name_Text("UPDATE [Menu] SET Link='" + sLink + "',TangName=N'" + hasTagName != null ? tagName + "_" + curItem[0].ID : tagName + "' WHERE id= " + curItem[0].ID + "");
                        //#endregion
                        lblThongbao.Text = "Thêm mới menu thành công !!";
                        Resetcontrol();
                        //LoadItems();
                        base.Response.Redirect(base.Request.Url.ToString().Trim());
                        pnDanhsach.Visible = true;
                        pnUpdate.Visible = false;
                    }
                }
                else
                {
                    string TagName = "";
                    List<Entity.Menu> list = SMenu.Detail(Id);
                    if (list.Count > 0)
                    {
                        if (txtRewriteUrl.Text.Length > 0)
                        {
                            List<Entity.Menu> item = SMenu.GETBYID(Id);
                            if (item.Count > 0)
                            {
                                Menu obk = db.Menus.SingleOrDefault(p => p.TangName == item[0].TangName);
                                obk.Name = txtRewriteUrl.Text;
                                obk.Module = 99;
                                List<Menu> list1 = (from p in db.Menus where p.TangName == obk.TangName orderby p.ID descending select p).ToList();
                                if (list1.Count > 2)
                                {
                                    var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtRewriteUrl.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(txtRewriteUrl.Text);
                                }
                                else
                                {
                                    if (MoreAll.AddURL.SeoURL(item[0].TangName) != MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)) { var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtRewriteUrl.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(txtRewriteUrl.Text); } else { TagName = item[0].TangName; }
                                }
                                obk.TangName = TagName;
                                db.SubmitChanges();
                            }

                        }
                        else
                        {
                            List<Entity.Menu> item = SMenu.GETBYID(Id);
                            if (item.Count > 0)
                            {
                                Menu obk = db.Menus.SingleOrDefault(p => p.TangName == item[0].TangName);
                                obk.Name = txtTenmenu.Text;
                                obk.Module = 99;
                                List<Menu> list1 = (from p in db.Menus where p.TangName == obk.TangName orderby p.ID descending select p).ToList();
                                if (list1.Count > 2)
                                {
                                    var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtTenmenu.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtTenmenu.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(txtTenmenu.Text);
                                }
                                else
                                {
                                    if (MoreAll.AddURL.SeoURL(item[0].TangName) != MoreAll.AddURL.SeoURL(txtTenmenu.Text)) { var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtTenmenu.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtTenmenu.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(txtTenmenu.Text); } else { TagName = item[0].TangName; }
                                }
                                obk.TangName = TagName;
                                db.SubmitChanges();
                            }
                        }
                        list[0].ID = int.Parse(Id);
                        list[0].Parent_ID = Convert.ToInt16(this.hd_id.Value.Trim());
                        list[0].capp = More.MN;
                        list[0].Type = (drlNhomlienket.SelectedValue != "0") ? Convert.ToInt32(drlNhomlienket.SelectedValue) : Convert.ToInt32(drlKieutrang.SelectedValue);
                        list[0].Lang = lang;
                        list[0].Name = txtTenmenu.Text.Trim();
                        list[0].Url_Name = RewriteURLNew.NameToTag(this.txtTenmenu.Text.Trim());
                        #region MyRegion
                        if (drlKieutrang.SelectedValue == pageType.ML)
                        {
                            if (drlNhomlienket.SelectedValue == pageType.MN)
                            {
                                if (ddlNews.SelectedValue != "0")
                                {
                                    var grn = db.Menus.Where(s => s.ID == int.Parse(ddlNews.SelectedValue)).First();
                                    sLink = "/danh-muc-tin/" + grn.TangName + ".html";
                                }
                                else
                                {
                                    sLink = "/tin-tuc-new.html";
                                }

                            }
                            else if (drlNhomlienket.SelectedValue == pageType.MP)
                            {
                                if (ddlProducts.SelectedValue != "0")
                                {
                                    var grn = db.Menus.Where(s => s.ID == int.Parse(ddlProducts.SelectedValue)).First();
                                    sLink = "/danh-muc/" + grn.TangName + ".html";
                                }
                                else
                                {
                                    sLink = "/san-pham-news.html";
                                }
                            }
                            else if (drlNhomlienket.SelectedValue == pageType.MPn)
                            {
                                sLink = "/san-pham-moi.html";
                            }
                            else if (drlNhomlienket.SelectedValue == pageType.MPnb)
                            {
                                sLink = "/san-pham-noi-bat.html";
                            }
                            else if (drlNhomlienket.SelectedValue == pageType.MPbc)
                            {
                                sLink = "/san-pham-ban-chay.html";
                            }
                            else if (drlNhomlienket.SelectedValue == pageType.MPkm)
                            {
                                sLink = "/san-pham-khuyen-mai.html";
                            }
                            else if (drlNhomlienket.SelectedValue == pageType.CP)
                            {
                                sLink = "/lien-he.html";
                            }
                            else if (drlNhomlienket.SelectedValue == pageType.RG)
                            {
                                sLink = "/dang-ky.html";
                            }


                            else if (drlNhomlienket.SelectedValue == pageType.LP)
                            {
                                if (ddlAmbum.SelectedValue != "0")
                                {
                                    var grn = db.Menus.Where(s => s.ID == int.Parse(ddlAmbum.SelectedValue)).First();
                                    sLink = "/danh-muc-anh/" + grn.TangName + ".html";
                                }
                                else
                                {
                                    sLink = "/thu-vien-anh.html";
                                }
                            }
                            else if (drlNhomlienket.SelectedValue == pageType.VD)
                            {
                                if (ddlVideo.SelectedValue != "0")
                                {
                                    var grn = db.Menus.Where(s => s.ID == int.Parse(ddlVideo.SelectedValue)).First();
                                    sLink = "/danh-muc-video/" + grn.TangName + ".html";
                                }
                                else
                                {
                                    sLink = "/thu-vien-video.html";
                                }
                            }
                            //else if (drlNhomlienket.SelectedValue == pageType.CP || drlNhomlienket.SelectedValue == pageType.PC)
                            //{
                            //    sLink = list[0].TangName + "";
                            //}
                            else { sLink = "/"; }
                        }
                        else if (
                            drlKieutrang.SelectedValue == pageType.MU)
                        {
                            sLink = txtUrl.Text;
                        }
                        else
                        {
                            sLink = list[0].TangName + "";
                        }
                        #endregion
                        list[0].Link = sLink;
                        list[0].Styleshow = drlKieuxuathien.SelectedValue;
                        list[0].Equals = 0;
                        list[0].Images = img_path;
                        list[0].Description = fckNoidung.Text;
                        list[0].Create_Date = DateTime.Now;
                        list[0].Views = int.Parse(drlVitri.SelectedValue);//pagPosition  --> thay bằng vị trí là Views
                        list[0].ShowID = int.Parse(drlKieutrang.SelectedValue);
                        list[0].Orders = Convert.ToInt16(txtThuTu.Text);
                        list[0].Level = ddlcha.SelectedValue + "00000";
                        list[0].News = 0;
                        list[0].page_Home = 0;
                        list[0].Status = Convert.ToInt16(chkKichhoat.Checked ? "1" : "0");
                        list[0].Titleseo = txtTieude.Text;
                        list[0].Meta = txtDesscription.Text;
                        list[0].Keyword = txtKeyword.Text;
                        list[0].Check_01 = 0;
                        list[0].Check_02 = 0;
                        list[0].Check_03 = 0;
                        list[0].Check_04 = 0;
                        list[0].Check_05 = 0;
                        list[0].Noidung1 = fckNoidung.Text;
                        list[0].Noidung2 = "";
                        list[0].Noidung3 = "";
                        list[0].Noidung4 = "";
                        list[0].Noidung5 = "";
                        list[0].Module = 99;
                        list[0].TangName = TagName;
                        if (SMenu.UPDATE(list[0]))
                        {
                            lblThongbao.Text = "Cập nhật menu thành công !!";
                            Resetcontrol();
                            base.Response.Redirect(base.Request.Url.ToString().Trim());
                            pnDanhsach.Visible = true;
                            pnUpdate.Visible = false;
                        }
                    }
                }
            }
        }
        #endregion
        #region[Back]
        protected void lbtTrolai_Click(object sender, EventArgs e)
        {
            Resetcontrol();
            pnDanhsach.Visible = true;
            pnUpdate.Visible = false;
            LoadItems();
        }
        #endregion
        #region[Delete Imges]
        protected void lbtDelimg_Click(object sender, EventArgs e)
        {
            string Id = HidId.Value;
            if (Id.Length > 0)
            {
                List<Entity.Menu> list = SMenu.Detail(Id);
                if (list.Count > 0)
                {
                    list[0].ID = int.Parse(ID);
                    string path = list[0].Images;
                    path = Server.MapPath(path);
                    if (path != "")
                    {
                        File.Delete(path);
                    }
                    SMenu.Name_Text("update Menu set Images='' where ID=" + ID + "");
                    lbtDelimg.Visible = false;
                    lblImg.Text = "";
                    ltrImg.Text = "";
                }
            }
        }
        #endregion
        #region[Add]
        protected void lbtAdd_Click(object sender, EventArgs e)
        {
            HidId.Value = "";
            hidLevel.Value = "";
            Resetcontrol();
            this.hd_id.Value = "-1";
            pnDanhsach.Visible = false;
            pnUpdate.Visible = true;
            ddlcha.SelectedValue = "";
            WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.drlVitri, this.drlFilterVitri.SelectedValue);
        }
        #endregion
        #region[Chọn kiểu liên kết]
        protected void drlKieutrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drlKieutrang.SelectedValue == pageType.MC)
            {
                pnNoidung.Visible = true;
                Pnseo.Visible = true;
                pnKieulienket.Visible = false;
                drlNhomlienket.SelectedValue = "0";
                //ddlProducts.SelectedValue = "0";
                pnUrl.Visible = false;
                pnpro.Visible = false;
            }
            else if (drlKieutrang.SelectedValue == pageType.ML)
            {
                pnNoidung.Visible = false;
                Pnseo.Visible = false;
                pnKieulienket.Visible = true;
                pnUrl.Visible = false;
                pnpro.Visible = false;
            }
            else if (drlKieutrang.SelectedValue == pageType.MU)
            {
                pnNoidung.Visible = false;
                Pnseo.Visible = false;
                pnKieulienket.Visible = false;
                pnUrl.Visible = true;
                pnpro.Visible = false;
                drlNhomlienket.SelectedValue = "0";
                // ddlProducts.SelectedValue = "0";
            }
            else
            {
                pnNoidung.Visible = false;
                Pnseo.Visible = false;
                pnKieulienket.Visible = false;
                pnUrl.Visible = false;
                pnpro.Visible = false;
                drlNhomlienket.SelectedValue = "0";
                // ddlProducts.SelectedValue = "0";
            }
        }
        #endregion
        #region[Resetcontrol]
        void Resetcontrol()
        {
            HidId.Value = "";
            hidLevel.Value = "";
            //ddlNews.SelectedValue = "0";
            txtTenmenu.Text = "";
            drlKieutrang.SelectedValue = "0";
            fckNoidung.Text = "";
            txtUrl.Text = "";
            lblImg.Text = "";
            ltrImg.Text = "";
            txtTieude.Text = "";
            txtDesscription.Text = "";
            txtKeyword.Text = "";
            drlVitri.SelectedValue = "0";
            drlThutu.SelectedValue = "1";
            drlNhomlienket.SelectedValue = "0";
            txtImg.Text = "";
            ddlNews.Visible = false;
            pnNoidung.Visible = false;
            Pnseo.Visible = false;
            pnKieulienket.Visible = false;
            ddlProducts.Visible = false;
            ddlAmbum.Visible = false;
            pnVideo.Visible = false;
            ddlVideo.Visible = false;
            pnNhom.Visible = false;
            pnKieulienket.Visible = false;
            pnpro.Visible = false;
            pnLibrary.Visible = false;
            txtRewriteUrl.Text = "";
            ltshowurl.Text = "";
        }
        #endregion
        #region[Test]
        protected bool Test()
        {
            if (txtTenmenu.Text == "") { lblLoi.Text = "Chưa nhập tên menu !!"; lblLoi.Focus(); return false; }
            if (drlKieutrang.SelectedValue == "0") { lblLoi.Text = "Chưa chọn kiểu trang !!"; lblLoi.Focus(); return false; }
            if (drlKieutrang.SelectedValue == "2" && fckNoidung.Text == "") { lblLoi.Text = "Chưa nhập nội dung trang !!"; lblLoi.Focus(); return false; }
            if (drlKieutrang.SelectedValue == "3" && txtUrl.Text == "") { lblLoi.Text = "Chưa nhập đường dẫn Url liên kết !!"; lblLoi.Focus(); return false; }
            if (drlKieuxuathien.SelectedValue == "0") { lblLoi.Text = "Chưa chọn kiểu xuất hiện trang !!"; lblLoi.Focus(); return false; }
            if (drlVitri.SelectedValue == "0") { lblLoi.Text = "Chưa chọn vị trí menu !!"; lblLoi.Focus(); return false; }
            return true;
        }
        #endregion
        #region[Nhomlienket]
        protected void drlNhomlienket_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drlNhomlienket.SelectedValue == pageType.MN)
            {
                pnNhom.Visible = true;
                ddlNews.Visible = true;
                Shownhomchuyenmuc();
                pnpro.Visible = false;
                pnLibrary.Visible = false;
                ddlProducts.Visible = false;
                pnVideo.Visible = false;
                ddlVideo.Visible = false;
            }
            else if (drlNhomlienket.SelectedValue == pageType.MP)
            {
                pnpro.Visible = true;
                ddlProducts.Visible = true;
                Viewcategory();
                pnNhom.Visible = false;
                pnLibrary.Visible = false;
                ddlNews.Visible = false;
                pnVideo.Visible = false;
                ddlVideo.Visible = false;
            }
            else if (drlNhomlienket.SelectedValue == pageType.LP)
            {
                ddlAmbum.Visible = true;
                ViewLibrary();
                pnNhom.Visible = false;
                pnpro.Visible = false;
                pnLibrary.Visible = true;
                ddlNews.Visible = false;
                pnVideo.Visible = false;
                ddlVideo.Visible = false;
            }
            else if (drlNhomlienket.SelectedValue == pageType.VD)
            {
                ddlVideo.Visible = true;
                ddlAmbum.Visible = false;
                ViewVideo();
                pnNhom.Visible = false;
                pnpro.Visible = false;
                pnVideo.Visible = true;
                pnLibrary.Visible = false;
                ddlNews.Visible = false;
            }
            else
            {
                pnLibrary.Visible = false;
                pnNhom.Visible = false;
                pnpro.Visible = false;
                ddlNews.Visible = false;
                ddlProducts.Visible = false;
            }
        }
        #endregion

        #region ViewLibrary
        protected void ViewLibrary()
        {
            try
            {
                int str = 0;
                List<Entity.Menu> dt = SMenu.LOAD_CATESPARENT_ID(More.AB, this.lang, "-1", "1");
                ddlAmbum.Items.Clear();
                for (int i = 0; i < dt.Count; i++)
                {
                    if (dt[i].Parent_ID.ToString() == "-1")
                    {
                        ddlAmbum.Items.Insert(str, new ListItem(dt[i].Name.ToString(), dt[i].ID.ToString()));
                        str = str + 1;
                        str = CategoriesalbumN(dt[i].ID.ToString(), str, "---");
                    }
                }
                this.ddlAmbum.Items.Insert(0, new ListItem(" >> DANH SÁCH THƯ VIỆN ALBUM << ", "0"));
                this.ddlAmbum.DataBind();
                dt.Clear();
                dt = null;
            }
            catch (Exception) { }
        }
        protected int CategoriesalbumN(string id, int str, string j)
        {
            List<Entity.Menu> dt = SMenu.LOAD_CATESPARENT_ID(More.AB, this.lang, id, "1");
            for (int i = 0; i < dt.Count; i++)
            {
                if (dt[i].Parent_ID.ToString() == id)
                {
                    ddlAmbum.Items.Insert(str, new ListItem(j + dt[i].Name.ToString(), dt[i].ID.ToString()));
                    str = str + 1;
                    str = CategoriesalbumN(dt[i].ID.ToString(), str, j + j);
                }
            }
            dt.Clear();
            dt = null;
            return str;
        }
        #endregion
        #region ViewVideo
        protected void ViewVideo()
        {
            try
            {
                int str = 0;
                List<Entity.Menu> dt = SMenu.LOAD_CATESPARENT_ID(More.VD, this.lang, "-1", "1");
                ddlVideo.Items.Clear();
                for (int i = 0; i < dt.Count; i++)
                {
                    if (dt[i].Parent_ID.ToString() == "-1")
                    {
                        ddlVideo.Items.Insert(str, new ListItem(dt[i].Name.ToString(), dt[i].ID.ToString()));
                        str = str + 1;
                        str = CategoriesVideoN(dt[i].ID.ToString(), str, "---");
                    }
                }
                this.ddlVideo.Items.Insert(0, new ListItem(" >> DANH SÁCH VIDEO << ", "0"));
                this.ddlVideo.DataBind();
                dt.Clear();
                dt = null;
            }
            catch (Exception) { }
        }
        protected int CategoriesVideoN(string id, int str, string j)
        {
            List<Entity.Menu> dt = SMenu.LOAD_CATESPARENT_ID(More.VD, this.lang, id, "1");
            for (int i = 0; i < dt.Count; i++)
            {
                if (dt[i].Parent_ID.ToString() == id)
                {
                    ddlVideo.Items.Insert(str, new ListItem(j + dt[i].Name.ToString(), dt[i].ID.ToString()));
                    str = str + 1;
                    str = CategoriesVideoN(dt[i].ID.ToString(), str, j + j);
                }
            }
            dt.Clear();
            dt = null;
            return str;
        }
        #endregion
        #region Menu
        protected void Viewcategory()
        {
            try
            {
                int str = 0;
                List<Entity.Menu> dt = SMenu.LOAD_CATESPARENT_ID(More.PR, this.lang, "-1", "1");
                ddlProducts.Items.Clear();
                for (int i = 0; i < dt.Count; i++)
                {
                    if (dt[i].Parent_ID.ToString() == "-1")
                    {
                        ddlProducts.Items.Insert(str, new ListItem(dt[i].Name.ToString(), dt[i].ID.ToString()));
                        str = str + 1;
                        str = Categories(dt[i].ID.ToString(), str, "---");
                    }
                }
                this.ddlProducts.Items.Insert(0, new ListItem(" >> DANH SÁCH SẢN PHẨM << ", "0"));
                this.ddlProducts.DataBind();
                dt.Clear();
                dt = null;
            }
            catch (Exception) { }
        }
        protected int Categories(string id, int str, string j)
        {
            List<Entity.Menu> dt = SMenu.LOAD_CATESPARENT_ID(More.PR, this.lang, id, "1");
            for (int i = 0; i < dt.Count; i++)
            {
                if (dt[i].Parent_ID.ToString() == id)
                {
                    ddlProducts.Items.Insert(str, new ListItem(j + dt[i].Name.ToString(), dt[i].ID.ToString()));
                    str = str + 1;
                    str = Categories(dt[i].ID.ToString(), str, j + j);
                }
            }
            dt.Clear();
            dt = null;
            return str;
        }
        #endregion

        #region[Viewcha]
        void Viewcapacha()
        {
            List<Entity.Menu> list = SMenu.Name_Text("SELECT * FROM Menu where capp='" + More.MN + "' and lang='" + lang + "' order by level,Orders asc");
            ddlcha.Items.Clear();
            ddlcha.Items.Add(new ListItem("---Chọn cấp cha---", ""));
            for (int i = 0; i < list.Count; i++)
            {
                string space = "";
                for (int j = 0; j < list[i].Level.Length / 5 - 1; j++) space += "-----";
                ddlcha.Items.Add(new ListItem(space + list[i].Name, list[i].Level));
            }
            list.Clear();
            list = null;

        }
        #endregion
        protected void AddButton_Click(object sender, EventArgs e)
        {
            lbtAdd_Click(sender, e);
        }
        protected void RefreshButton_Click(object sender, EventArgs e)
        {
            Viewcategory();
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rptDanhsach.Items.Count; i++)
            {
                TextBox txtThutu = (TextBox)rptDanhsach.Items[i].FindControl("txtThutu");
                Label lblID = (Label)rptDanhsach.Items[i].FindControl("lblID");
                if (txtThutu.Text != "" && txtThutu.Text != "0")
                {
                    Menu abc = db.Menus.SingleOrDefault(p => p.ID == int.Parse(lblID.Text));
                    abc.ID = int.Parse(lblID.Text);
                    abc.Orders = int.Parse(txtThutu.Text);
                    db.SubmitChanges();
                    lblThongbao.Text = "Cập nhật thành công !!";
                }
            }
            LoadItems();
        }
        protected void btxoa_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rptDanhsach.Items.Count; i++)
            {
                CheckBox chk = (CheckBox)rptDanhsach.Items[i].FindControl("chkid");
                HiddenField id = (HiddenField)rptDanhsach.Items[i].FindControl("hiID");
                if (chk.Checked)
                {
                    Menu del = db.Menus.Where(s => s.ID == int.Parse(id.Value) && s.capp == More.MN).FirstOrDefault();
                    if (del != null)
                    {
                        List<Menu> catChild = db.Menus.Where(s => s.Level.Substring(0, del.Level.Length) == del.Level && s.capp == More.MN).ToList();
                        if (catChild.Count() > 0)
                        {
                            for (int ih = 0; ih < catChild.Count; ih++)
                            {
                                // SModulControls.Name_Text("DELETE FROM ModulControls WHERE TangName ='" + catChild[ih].TangName + "'");
                                db.Menus.DeleteOnSubmit(catChild[ih]);
                                db.SubmitChanges();
                            }
                        }
                    }
                    List<Entity.Menu> str5 = SMenu.GETBYID(id.Value.ToString());
                    if (str5.Count > 0)
                    {
                        try
                        {
                            //  SModulControls.Name_Text("DELETE FROM ModulControls WHERE TangName ='" + str5[0].TangName + "'");
                        }
                        catch (Exception)
                        { }
                    }
                    SMenu.DELETE(id.Value);
                }
            }
            LoadItems();
            lblThongbao.Text = "Xóa thành công menu !!";
            base.Response.Redirect(base.Request.Url.ToString().Trim());
        }
        protected string Urltag(string tag)
        {
            return RewriteURLNew.NameToTag(tag);
        }
        protected string Urltags(string tag, string ID)
        {
            string str = "";
            List<Menu> pagee = db.Menus.Where(o => o.ID == int.Parse(ID)).ToList<Menu>();
            if (pagee.Count > 0)
            {
                pagee = db.Menus.Where(o => o.TangName == RewriteURLNew.NameToTag(tag)).ToList<Menu>();
                if (pagee.Count > 1)
                {
                    str = RewriteURLNew.NameToTag(tag) + "-" + pagee.Where(o => o.ID == int.Parse(ID)).FirstOrDefault().ID;
                }
                else
                {
                    str = RewriteURLNew.NameToTag(tag);
                }
            }

            return str.ToString();
        }
        protected void rptDanhsach_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            string sql = "";
            if (drlFilterVitri.SelectedValue != "0")
            {
                sql += " and Views=" + drlFilterVitri.SelectedValue + " ";
            }
            DropDownList ddlCapluoi = (DropDownList)e.Item.FindControl("ddlCap");
            Label lblLevel = (Label)e.Item.FindControl("lblLevel");
            List<Entity.Menu> list = SMenu.Name_Text("SELECT * FROM Menu where capp='" + More.MN + "' and lang='" + lang + "' " + sql + " order by level,Orders asc");
            ddlCapluoi.Items.Clear();
            ddlCapluoi.Items.Add(new ListItem("---Chọn cấp cha---", ""));
            for (int i = 0; i < list.Count; i++)
            {
                string space = "";
                for (int j = 0; j < list[i].Level.Length / 5 - 1; j++) space += "-----";
                ddlCapluoi.Items.Add(new ListItem(space + list[i].Name, list[i].Level));
            }
            if (lblLevel.Text.Length == 5)
            {
                ddlCapluoi.SelectedValue = "0";

            }
            else
            {
                string lecha = lblLevel.Text.Substring(0, lblLevel.Text.Length - 5);
                ddlCapluoi.SelectedValue = lecha;

            }
            list.Clear();
            list = null;
        }
        protected void ddlCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlCap = (DropDownList)sender;
            var a = ddlCap.Parent;
            var b = (Label)a.FindControl("lblID");
            List<Entity.Menu> list = SMenu.Detail(b.Text);
            var strlv1 = list[0].Level;
            var srtlv2 = ddlCap.SelectedValue;
            string sss = More.Level_ID(ddlCap.SelectedValue, More.MN);
            if (strlv1.Length < srtlv2.Length && strlv1 == srtlv2.Substring(0, strlv1.Length))
            {
                lblThongbao.Text = "Không thể chọn cấp con làm cha !!";
                LoadItems();
            }
            else if (b.Text == sss)
            {
                lblThongbao.Text = "Không thể chọn cấp con làm cha !!";
                LoadItems();
            }
            else
            {
                if (list.Count > 0)
                {
                    // list[0].Level = ;
                    /// tbPageDB.tbPage_Update(list[0]);
                    Menu abc = db.Menus.SingleOrDefault(p => p.ID == int.Parse(b.Text));
                    abc.ID = int.Parse(b.Text);
                    abc.Level = ddlCap.SelectedValue + "00000";
                    db.SubmitChanges();
                }
                LoadItems();
                lblThongbao.Text = "Cập nhật CẤP menu thành công !!";
            }

        }
        protected void txtTenmenu_TextChanged(object sender, EventArgs e)
        {
            TextBox txtTenmenu = (TextBox)sender;
            var b = (Label)txtTenmenu.FindControl("lblID");
            Menu abc = db.Menus.SingleOrDefault(p => p.ID == int.Parse(b.Text));
            abc.ID = int.Parse(b.Text);
            abc.Name = txtTenmenu.Text;
            db.SubmitChanges();
            LoadItems();
            lblThongbao.Text = "Cập nhật tên menu thành công !!";
        }
        //protected void txtThutu_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtOrd = (TextBox)sender;
        //    var b = (Label)txtOrd.FindControl("lblID");
        //    Menu abc = db.Menus.SingleOrDefault(p => p.ID == int.Parse(b.Text));
        //    abc.ID = int.Parse(b.Text);
        //    abc.Orders = int.Parse(txtOrd.Text);
        //    db.SubmitChanges();
        //    LoadItems();
        //    lblThongbao.Text = "Cập nhật số thứ tự thành công !!";
        //}
        public static string ShowActiveImage(string Orders)
        {
            return Orders == "1" || Orders == "True" ? "<i class='icon-check'></i>" : "<i class='icon-check-empty'></i>";
        }
        protected void Name_TextChanged(object sender, EventArgs e)
        {
            TextBox Tennhom = (TextBox)sender;
            var b = (Label)Tennhom.FindControl("lblID");
            string TagName = "";
            List<Entity.Menu> item = SMenu.GETBYID(b.Text);
            if (item.Count > 0)
            {
                Menu iitem = db.Menus.SingleOrDefault(p => p.TangName == item[0].TangName);
                Menu obk = db.Menus.SingleOrDefault(p => p.TangName == item[0].TangName);
                obk.Name = Tennhom.Text;
                obk.Module = 99;
                List<Menu> list1 = (from p in db.Menus where p.TangName == obk.TangName orderby p.ID descending select p).ToList();
                if (list1.Count > 2)
                {
                    var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(Tennhom.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(Tennhom.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(Tennhom.Text);
                }
                else
                {
                    if (MoreAll.AddURL.SeoURL(item[0].Name) != MoreAll.AddURL.SeoURL(Tennhom.Text)) { var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(Tennhom.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(Tennhom.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(Tennhom.Text); } else { TagName = item[0].TangName; }
                }
                obk.TangName = TagName;
                db.SubmitChanges();

                iitem.Url_Name = MoreAll.AddURL.SeoURL(Tennhom.Text);
                iitem.Name = Tennhom.Text;
                iitem.Module = 99;
                iitem.TangName = TagName;
                db.SubmitChanges();

            }
            LoadItems();
            lblThongbao.Text = "<span class=alert>Cập nhật tên thành công !!</span>";
        }
        //protected void btxoa_Click(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < rptDanhsach.Items.Count; i++)
        //    {
        //        CheckBox chk = (CheckBox)rptDanhsach.Items[i].FindControl("chkid");
        //        HiddenField id = (HiddenField)rptDanhsach.Items[i].FindControl("hiID");
        //        if (chk.Checked)
        //        {
        //            SMenu.DELETE_PARENT(More.Sub_Menu(More.MN, id.Value));
        //            SMenu.DELETE(id.Value);
        //            Menu del = db.Menus.Where(s => s.ID == int.Parse(id.Value)).FirstOrDefault();
        //            List<Menu> catChild = db.Menus.Where(s => s.Level.Substring(0, del.Level.Length) == del.Level).ToList();
        //            if (catChild.Count() > 0)
        //            {
        //                for (int j = 0; j < catChild.Count; j++)
        //                {
        //                    db.Menus.DeleteOnSubmit(catChild[j]);
        //                    db.SubmitChanges();
        //                }
        //                LoadItems();
        //                lblThongbao.Text = "Xóa thành công menu !!";
        //            }
        //            else
        //            {
        //                SMenu.DELETE(id.Value);
        //                lblThongbao.Text = "Xóa thành công menu !!";
        //                LoadItems();
        //            }
        //        }
        //    }
        //}
        protected void linkTim_Click(object sender, EventArgs e)
        {
            LoadItems();
        }
        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Page&Vitri=" + drlFilterVitri.SelectedValue + "&st=" + ddlstatus.SelectedValue + "&pa=" + ddlPage.SelectedValue + "");
        }
        protected void ddlPage_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Page&Vitri=" + drlFilterVitri.SelectedValue + "&st=" + ddlstatus.SelectedValue + "&pa=" + ddlPage.SelectedValue + "");
        }
        protected void drlFilterVitri_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Page&Vitri=" + drlFilterVitri.SelectedValue + "&st=" + ddlstatus.SelectedValue + "&pa=" + ddlPage.SelectedValue + "");
        }
        protected void lbtCoppy_Click(object sender, EventArgs e)
        {
            Menu abc = db.Menus.SingleOrDefault(p => p.ID == int.Parse(ddlProducts.SelectedValue));
            if (abc != null)
            {
                txtTenmenu.Text = abc.Name;
            }
        }
        protected void lbtCoppy1_Click(object sender, EventArgs e)
        {
            Menu abc = db.Menus.SingleOrDefault(p => p.ID == int.Parse(ddlNews.SelectedValue));
            if (abc != null)
            {
                txtTenmenu.Text = abc.Name;
            }
        }
        protected void lbtCoppy2_Click(object sender, EventArgs e)
        {
            Menu abc = db.Menus.SingleOrDefault(p => p.ID == int.Parse(ddlAmbum.SelectedValue));
            if (abc != null)
            {
                txtTenmenu.Text = abc.Name;
            }
        }
        protected void lbtCoppy3_Click(object sender, EventArgs e)
        {
            Menu abc = db.Menus.SingleOrDefault(p => p.ID == int.Parse(ddlVideo.SelectedValue));
            if (abc != null)
            {
                txtTenmenu.Text = abc.Name;
            }
        }

        protected void btcopyallcatepro_Click(object sender, EventArgs e)
        {
            string capcha = "";
            string str = "";
            if (ddlProducts.SelectedValue != "0")
            {
                str = " and ID in(" + More.Sub_Menu(More.PR, ddlProducts.SelectedValue) + ")  ";
            }
            List<Entity.Menu> table = SMenu.Name_Text("SELECT * FROM Menu where  capp='" + More.PR + "' " + str + " and lang='" + lang + "' order by level,Orders asc");
            foreach (var item in table)
            {
                #region Menu
                string TangName = "";
                int cong = 0;
                List<Entity.Menu> curItem = SMenu.Name_Text("SELECT top 1 * FROM Menu order by ID desc");
                int tong = int.Parse(curItem[0].ID.ToString());
                cong = tong + 1;
                var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(item.Name)).FirstOrDefault();
                TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(item.Name) + "-" + cong : MoreAll.AddURL.SeoURL(item.Name);
                #endregion


                Entity.Menu obj = new Entity.Menu();
                obj.Parent_ID = Convert.ToInt16(this.hd_id.Value.Trim());
                obj.capp = More.MN;
                obj.Type = int.Parse((drlNhomlienket.SelectedValue != "0") ? drlNhomlienket.SelectedValue : drlKieutrang.SelectedValue);
                obj.Lang = lang;
                obj.Name = item.Name;
                obj.Url_Name = RewriteURLNew.NameToTag(item.Name);

                obj.Link = "/danh-muc/" + item.TangName + ".html";
                obj.Styleshow = drlKieuxuathien.SelectedValue;
                obj.Equals = Convert.ToInt16("0");
                obj.Images = "";
                obj.Description = "";
                obj.Create_Date = DateTime.Now;
                obj.Views = int.Parse(drlVitri.SelectedValue);
                obj.ShowID = int.Parse(drlKieutrang.SelectedValue);
                obj.Orders = Convert.ToInt16(item.Orders);
                //if (item.Parent_ID.ToString() != "-1")
                //{
                //    sgrnlevel = item.Level;
                //}
                if (ddlcha.SelectedValue != "")
                {
                    capcha = ddlcha.SelectedValue;
                }
                if (item.Parent_ID.ToString() != "-1")
                {
                    obj.Level = capcha + item.Level;
                }
                else
                {
                    obj.Level = capcha + "00000";
                }
                // obj.Level = sgrnlevel + "00000";
                obj.News = 0;
                obj.page_Home = 0;
                obj.Status = Convert.ToInt16(chkKichhoat.Checked ? "1" : "0");
                obj.Titleseo = item.Titleseo;
                obj.Meta = item.Meta;
                obj.Keyword = item.Keyword;
                obj.Check_01 = 0;
                obj.Check_02 = 0;
                obj.Check_03 = 0;
                obj.Check_04 = 0;
                obj.Check_05 = 0;
                obj.Noidung1 = "";
                obj.Noidung2 = "";
                obj.Noidung3 = "";
                obj.Noidung4 = "";
                obj.Noidung5 = "";
                obj.Module = 99;
                obj.TangName = TangName;
                string tagName = Urltag(item.Name);
                if (SMenu.Insert(obj))
                { }
            }
            lblThongbao.Text = "Thêm mới menu thành công !!";
            Resetcontrol();
            LoadItems();
            pnDanhsach.Visible = true;
            pnUpdate.Visible = false;
        }

        protected void btcopyallcateNews_Click(object sender, EventArgs e)
        {
            string capcha = "";

            string str = "";
            if (ddlNews.SelectedValue != "0")
            {
                str = " and ID in(" + More.Sub_Menu(More.NS, ddlNews.SelectedValue) + ")  ";
            }

            List<Entity.Menu> table = SMenu.Name_Text("SELECT * FROM Menu where  capp='" + More.NS + "' " + str + " and lang='" + lang + "' order by level,Orders asc");
            foreach (var item in table)
            {
                #region Menu
                string TangName = "";
                int cong = 0;
                List<Entity.Menu> curItem = SMenu.Name_Text("SELECT top 1 * FROM Menu order by ID desc");
                int tong = int.Parse(curItem[0].ID.ToString());
                cong = tong + 1;
                var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(item.Name)).FirstOrDefault();
                TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(item.Name) + "-" + cong : MoreAll.AddURL.SeoURL(item.Name);
                #endregion

                Entity.Menu obj = new Entity.Menu();
                obj.Parent_ID = Convert.ToInt16(this.hd_id.Value.Trim());
                obj.capp = More.MN;
                obj.Type = int.Parse((drlNhomlienket.SelectedValue != "0") ? drlNhomlienket.SelectedValue : drlKieutrang.SelectedValue);
                obj.Lang = lang;
                obj.Name = item.Name;
                obj.Url_Name = RewriteURLNew.NameToTag(item.Name);
                obj.Link = "/danh-muc-tin/" + item.TangName + ".html";
                obj.Styleshow = drlKieuxuathien.SelectedValue;
                obj.Equals = Convert.ToInt16("0");
                obj.Images = "";
                obj.Description = "";
                obj.Create_Date = DateTime.Now;
                obj.Views = int.Parse(drlVitri.SelectedValue);
                obj.ShowID = int.Parse(drlKieutrang.SelectedValue);
                obj.Orders = Convert.ToInt16(item.Orders);
                if (ddlcha.SelectedValue != "")
                {
                    capcha = ddlcha.SelectedValue;
                }
                if (item.Parent_ID.ToString() != "-1")
                {
                    obj.Level = capcha + item.Level;
                }
                else
                {
                    obj.Level = capcha + "00000";
                }
                obj.News = 0;
                obj.page_Home = 0;
                obj.Status = Convert.ToInt16(chkKichhoat.Checked ? "1" : "0");
                obj.Titleseo = item.Titleseo;
                obj.Meta = item.Meta;
                obj.Keyword = item.Keyword;
                obj.Check_01 = 0;
                obj.Check_02 = 0;
                obj.Check_03 = 0;
                obj.Check_04 = 0;
                obj.Check_05 = 0;
                obj.Noidung1 = "";
                obj.Noidung2 = "";
                obj.Noidung3 = "";
                obj.Noidung4 = "";
                obj.Noidung5 = "";
                obj.Module = 99;
                obj.TangName = TangName;
                string tagName = Urltag(item.Name);
                if (SMenu.Insert(obj))
                { }
            }
            lblThongbao.Text = "Thêm mới menu thành công !!";
            Resetcontrol();
            LoadItems();
            pnDanhsach.Visible = true;
            pnUpdate.Visible = false;
        }

        protected void btcopyallcateThuvien_Click(object sender, EventArgs e)
        {
            string capcha = "";
            string str = "";
            if (ddlAmbum.SelectedValue != "0")
            {
                str = " and ID in(" + More.Sub_Menu(More.AB, ddlAmbum.SelectedValue) + ")  ";
            }

            List<Entity.Menu> table = SMenu.Name_Text("SELECT * FROM Menu where capp='" + More.AB + "' " + str + " and lang='" + lang + "' order by level,Orders asc");
            foreach (var item in table)
            {
                #region Menu
                string TangName = "";
                int cong = 0;
                List<Entity.Menu> curItem = SMenu.Name_Text("SELECT top 1 * FROM Menu order by ID desc");
                int tong = int.Parse(curItem[0].ID.ToString());
                cong = tong + 1;
                var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(item.Name)).FirstOrDefault();
                TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(item.Name) + "-" + cong : MoreAll.AddURL.SeoURL(item.Name);
                #endregion

                Entity.Menu obj = new Entity.Menu();
                obj.Parent_ID = Convert.ToInt16(this.hd_id.Value.Trim());
                obj.capp = More.MN;
                obj.Type = int.Parse((drlNhomlienket.SelectedValue != "0") ? drlNhomlienket.SelectedValue : drlKieutrang.SelectedValue);
                obj.Lang = lang;
                obj.Name = item.Name;
                obj.Url_Name = RewriteURLNew.NameToTag(item.Name);
                obj.Link = "/danh-muc-anh/" + item.TangName + ".html";
                obj.Styleshow = drlKieuxuathien.SelectedValue;
                obj.Equals = Convert.ToInt16("0");
                obj.Images = "";
                obj.Description = "";
                obj.Create_Date = DateTime.Now;
                obj.Views = int.Parse(drlVitri.SelectedValue);
                obj.ShowID = int.Parse(drlKieutrang.SelectedValue);
                obj.Orders = Convert.ToInt16(item.Orders);
                if (ddlcha.SelectedValue != "")
                {
                    capcha = ddlcha.SelectedValue;
                }
                if (item.Parent_ID.ToString() != "-1")
                {
                    obj.Level = capcha + item.Level;
                }
                else
                {
                    obj.Level = capcha + "00000";
                }
                obj.News = 0;
                obj.page_Home = 0;
                obj.Status = Convert.ToInt16(chkKichhoat.Checked ? "1" : "0");
                obj.Titleseo = item.Titleseo;
                obj.Meta = item.Meta;
                obj.Keyword = item.Keyword;
                obj.Check_01 = 0;
                obj.Check_02 = 0;
                obj.Check_03 = 0;
                obj.Check_04 = 0;
                obj.Check_05 = 0;
                obj.Noidung1 = "";
                obj.Noidung2 = "";
                obj.Noidung3 = "";
                obj.Noidung4 = "";
                obj.Noidung5 = "";
                obj.Module = 99;
                obj.TangName = TangName;
                string tagName = Urltag(item.Name);
                if (SMenu.Insert(obj))
                { }
            }
            lblThongbao.Text = "Thêm mới menu thành công !!";
            Resetcontrol();
            LoadItems();
            pnDanhsach.Visible = true;
            pnUpdate.Visible = false;
        }

        protected void btcopyallcateVideo_Click(object sender, EventArgs e)
        {
            string capcha = "";
            string str = "";
            if (ddlVideo.SelectedValue != "0")
            {
                str = " and ID in(" + More.Sub_Menu(More.VD, ddlVideo.SelectedValue) + ")  ";
            }
            List<Entity.Menu> table = SMenu.Name_Text("SELECT * FROM Menu where  capp='" + More.VD + "' " + str + " and lang='" + lang + "' order by level,Orders asc");
            foreach (var item in table)
            {
                #region Menu
                string TangName = "";
                int cong = 0;
                List<Entity.Menu> curItem = SMenu.Name_Text("SELECT top 1 * FROM Menu order by ID desc");
                int tong = int.Parse(curItem[0].ID.ToString());
                cong = tong + 1;
                var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(item.Name)).FirstOrDefault();
                TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(item.Name) + "-" + cong : MoreAll.AddURL.SeoURL(item.Name);
                #endregion

                Entity.Menu obj = new Entity.Menu();
                obj.Parent_ID = Convert.ToInt16(this.hd_id.Value.Trim());
                obj.capp = More.MN;
                obj.Type = int.Parse((drlNhomlienket.SelectedValue != "0") ? drlNhomlienket.SelectedValue : drlKieutrang.SelectedValue);
                obj.Lang = lang;
                obj.Name = item.Name;
                obj.Url_Name = RewriteURLNew.NameToTag(item.Name);
                obj.Link = "/danh-muc-video/" + item.TangName + ".html";
                obj.Styleshow = drlKieuxuathien.SelectedValue;
                obj.Equals = Convert.ToInt16("0");
                obj.Images = "";
                obj.Description = "";
                obj.Create_Date = DateTime.Now;
                obj.Views = int.Parse(drlVitri.SelectedValue);
                obj.ShowID = int.Parse(drlKieutrang.SelectedValue);
                obj.Orders = Convert.ToInt16(item.Orders);
                if (ddlcha.SelectedValue != "")
                {
                    capcha = ddlcha.SelectedValue;
                }
                if (item.Parent_ID.ToString() != "-1")
                {
                    obj.Level = capcha + item.Level;
                }
                else
                {
                    obj.Level = capcha + "00000";
                }
                obj.News = 0;
                obj.page_Home = 0;
                obj.Status = Convert.ToInt16(chkKichhoat.Checked ? "1" : "0");
                obj.Titleseo = item.Titleseo;
                obj.Meta = item.Meta;
                obj.Keyword = item.Keyword;
                obj.Check_01 = 0;
                obj.Check_02 = 0;
                obj.Check_03 = 0;
                obj.Check_04 = 0;
                obj.Check_05 = 0;
                obj.Noidung1 = "";
                obj.Noidung2 = "";
                obj.Noidung3 = "";
                obj.Noidung4 = "";
                obj.Noidung5 = "";
                obj.Module = 99;
                obj.TangName = TangName;
                string tagName = Urltag(item.Name);
                if (SMenu.Insert(obj))
                { }
            }
            lblThongbao.Text = "Thêm mới menu thành công !!";
            Resetcontrol();
            LoadItems();
            pnDanhsach.Visible = true;
            pnUpdate.Visible = false;
        }

        protected void btkiemtra_Click(object sender, EventArgs e)
        {
            string ssl = "http://" + Request.Url.Host + "/";
            if (MoreAll.Other.Giatri("SSL").Equals("1"))
            {
                ssl = "https://" + Request.Url.Host + "/";
            }
            string Id = HidId.Value;
            string sgrnlevel = hidLevel.Value;
            if (Id.Length == 0)
            {
                #region RewriteUrl
                int cong = 0;
                string TangName = "";
                if (txtRewriteUrl.Text.Length > 0)
                {
                    #region InsertMenu
                    List<Entity.Menu> curItem = SMenu.Name_Text("SELECT top 1 * FROM Menu order by ID desc");
                    int tong = int.Parse(curItem[0].ID.ToString()); cong = tong + 1; var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)).FirstOrDefault(); TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtRewriteUrl.Text) + "-" + cong : MoreAll.AddURL.SeoURL(txtRewriteUrl.Text);
                    #endregion
                }
                else
                {
                    #region InsertMenu
                    List<Entity.Menu> curItem = SMenu.Name_Text("SELECT top 1 * FROM Menu order by ID desc");
                    int tong = int.Parse(curItem[0].ID.ToString()); cong = tong + 1; var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtTenmenu.Text)).FirstOrDefault(); TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtTenmenu.Text) + "-" + cong : MoreAll.AddURL.SeoURL(txtTenmenu.Text);
                    #endregion
                }
                ltshowurl.Text = ssl + TangName + ".html";
                #endregion
            }
            else
            {
                #region RewriteUrl
                string TagName = "";
                if (txtRewriteUrl.Text.Length > 0)
                {
                    #region UpdateMenu
                    List<Entity.Menu> item = SMenu.GETBYID(Id);
                    if (item.Count > 0)
                    {
                        Menu obk = db.Menus.SingleOrDefault(p => p.TangName == item[0].TangName);
                        List<Menu> list = (from p in db.Menus where p.TangName == obk.TangName orderby p.ID descending select p).ToList();
                        if (list.Count > 2)
                        {
                            var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtRewriteUrl.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(txtRewriteUrl.Text);
                        }
                        else
                        {
                            if (MoreAll.AddURL.SeoURL(item[0].TangName) != MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)) { var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtRewriteUrl.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtRewriteUrl.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(txtRewriteUrl.Text); } else { TagName = item[0].TangName; }
                        }
                    }
                    #endregion
                }
                else
                {
                    List<Entity.Menu> item = SMenu.GETBYID(Id);
                    if (item.Count > 0)
                    {
                        Menu obk = db.Menus.SingleOrDefault(p => p.TangName == item[0].TangName);
                        List<Menu> list1 = (from p in db.Menus where p.TangName == obk.TangName orderby p.ID descending select p).ToList();
                        if (list1.Count > 2)
                        {
                            var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtTenmenu.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtTenmenu.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(txtTenmenu.Text);
                        }
                        else
                        {
                            if (MoreAll.AddURL.SeoURL(item[0].TangName) != MoreAll.AddURL.SeoURL(txtTenmenu.Text)) { var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtTenmenu.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtTenmenu.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(txtTenmenu.Text); } else { TagName = item[0].TangName; }
                        }
                    }
                }
                ltshowurl.Text = ssl + TagName + ".html";
                #endregion
            }
        }

        protected void bntcapnhat_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rptDanhsach.Items.Count; i++)
            {
                TextBox txtOrders = (TextBox)rptDanhsach.Items[i].FindControl("txtOrders");
                HiddenField id = (HiddenField)rptDanhsach.Items[i].FindControl("hiID");
                // Cập nhật thứ tự
                if (txtOrders.Text != "" && txtOrders.Text != "0")
                {
                    SMenu.Name_Text("UPDATE [Menu] SET Orders=" + txtOrders.Text + " WHERE ID=" + id.Value + " and capp='" + More.MN + "'");
                    lblThongbao.Text = "<span class=alert>Cập nhật thành công !!</span>";
                }
            }
            LoadItems();
        }

    }
}