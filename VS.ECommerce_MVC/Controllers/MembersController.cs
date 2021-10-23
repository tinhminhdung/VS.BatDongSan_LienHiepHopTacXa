using Common;
using Facebook;
using MoreAll;
using Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VS.ECommerce_MVC.Controllers
{
    // kế thừ từ BaseController nhé
    //public class MembersController : Controller
    public class MembersController : BaseController
    {
        private string language = Captionlanguage.SetLanguage();
        DatalinqDataContext db = new DatalinqDataContext();
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }
        public ActionResult LoginFacebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email",
            });

            return Redirect(loginUrl.AbsoluteUri);
        }

        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });


            var accessToken = result.access_token;
            if (!string.IsNullOrEmpty(accessToken))
            {
                fb.AccessToken = accessToken;
                // Get the user's information, like email, first name, middle name etc
                dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email");
                string email = me.email;
                string userName = me.email;
                string firstname = me.first_name;
                string middlename = me.middle_name;
                string lastname = me.last_name;

                var user = db.Members.SingleOrDefault(x => x.Email == email);
                if (user == null)
                {
                    string validatekey = DateTime.Now.Ticks.ToString();
                    Member obj = new Member();
                    obj.PasWord = "";
                    obj.HoVaTen = firstname + " " + middlename + " " + lastname;
                    obj.GioiTinh = 0;
                    obj.NgaySinh = DateTime.Now.ToString("dd/MM/yyyy");
                    obj.DiaChi = "";
                    obj.DienThoai = "";
                    obj.Email = email;
                    obj.AnhDaiDien = "";
                    obj.NgayTao = DateTime.Now;
                    obj.Key = validatekey;
                    obj.TrangThai = 1;
                    obj.Lang = language;
                    db.Members.InsertOnSubmit(obj);
                    db.SubmitChanges();
                }
                else
                {
                    MoreAll.MoreAll.SetCookie("Members", email.Trim().ToLower(), 5000);
                    MoreAll.MoreAll.SetCookie("MembersID", user.ID.ToString(), 5000);
                    return Redirect("/");
                }
                //var user = new User();
                //user.Email = email;
                //user.UserName = email;
                //user.Status = true;
                //user.Name = firstname + " " + middlename + " " + lastname;
                //user.CreatedDate = DateTime.Now;
                //var resultInsert = new UserDao().InsertForFacebook(user);
                //if (resultInsert > 0)
                //{
                //    var userSession = new UserLogin();
                //    userSession.UserName = user.UserName;
                //    userSession.UserID = user.ID;
                //    Session.Add(CommonConstants.USER_SESSION, userSession);
                //}
            }
            return Redirect("/");
        }

        #region Dang_Ky
        public ActionResult Dang_Ky(string info)
        {
            try
            {
                if (info != "")// trường hợp có coupon và không có link ?aff
                {
                    List<Entity.Member> iEmail = SMember.Name_Text("select * from Members  where DienThoai='" + info + "' and TrangThai=1");//and iuser_id !=" + MoreAll.MoreAll.GetCookies("MembersID") + " 
                    if (iEmail.Count > 0)
                    {
                        ViewBag.txtnguoigioithieu = iEmail[0].DienThoai.ToString();
                        ViewBag.ltgoithieu = "Người giới thiệu: " + iEmail[0].HoVaTen.ToString();
                        ViewBag.style = "<style>.nguoigioithieu{pointer-events: none; opacity: 0.6;}</style>";
                        //  txtnguoigioithieu.Style.Add("pointer-events", "none");
                        // txtnguoigioithieu.Style.Add("opacity", "0.6");
                    }
                }
            }
            catch (Exception)
            { }
            return View();
        }


        //Dạng bình thường ko qua Ajax
        //[HttpPost]
        //[ValidateInput(false)]
        //public ActionResult Dang_Ky(FormCollection collect)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Member list = db.Members.SingleOrDefault(s => s.Email.Contains(collect["txtemail"].Trim().ToLower()));
        //        Member listDienThoai = db.Members.SingleOrDefault(s => s.DienThoai.Contains(collect["txtphone"].Trim().ToLower()));
        //        if (collect["txtHoTen"]=="")
        //        {
        //            ViewBag.ThongBao = "Vui lòng điền đầy đủ họ và tên";
        //        }
        //        else if (collect["txtphone"]=="")
        //        {
        //            ViewBag.ThongBao = "Vui lòng điền điện thoại";
        //        }
        //        else if (MoreAll.RegularExpressions.phone(collect["txtphone"]))
        //        {
        //            ViewBag.ThongBao = "Điện thoại không đúng định dạng";
        //        }
        //        else if (listDienThoai != null)
        //        {
        //            ViewBag.ThongBao = "Điện thoại đã tồn tại trong hệ thống";
        //        }
        //        else if (collect["txtaddress"]=="")
        //        {
        //            ViewBag.ThongBao = "Vui lòng điền địa chỉ";
        //        }
        //        else if (!MoreAll.RegularExpressions.IsValidEmail(collect["txtemail"]))
        //        {
        //            ViewBag.ThongBao = "Email không đúng định dạng";
        //        }
        //        else if (collect["txtemail"]=="")
        //        {
        //            ViewBag.ThongBao = "Vui lòng điền email";
        //        }
        //        else if (list != null)
        //        {
        //            ViewBag.ThongBao = "Email đã tồn tại trong hệ thống";
        //        }
        //        else
        //        {
        //            //System.Threading.Thread.Sleep(1000);
        //            //#region Senmail
        //            //if (!Commond.Setting("Emailden").Equals(""))
        //            //    Senmail(collect["txtHoTen"], collect["txtaddress"], collect["txtphone"], collect["txtemail"], collect["txttieude"], collect["txtcontent"]);
        //            //#endregion

        //            string validatekey = DateTime.Now.Ticks.ToString();
        //            Member obj = new Member();
        //            obj.PasWord = collect["txtmatkhau"];
        //            obj.HoVaTen = collect["txtHoTen"];
        //            obj.GioiTinh = 0;
        //            obj.NgaySinh = DateTime.Now;
        //            obj.DiaChi = collect["txtaddress"];
        //            obj.DienThoai = collect["txtphone"];
        //            obj.Email = collect["txtemail"];
        //            obj.AnhDaiDien = "";
        //            obj.NgayTao = DateTime.Now;
        //            obj.Key = validatekey;
        //            obj.TrangThai = 0;
        //            obj.Lang = language;
        //            db.Members.InsertOnSubmit(obj);
        //            db.SubmitChanges();
        //            ViewBag.ThongBao = "Đăng ký tài khoản thành công";
        //        }
        //    }
        //    return View();
        //}

        //Ajax

        [HttpPost]
        public ActionResult Dang_Ky(string txtHoTen, string txtemail, string txtphone, string txtaddress, string txtmatkhau, string txtnguoigioithieu)
        {
            if (ModelState.IsValid)
            {
                List<Entity.Member> list = SMember.Name_Text("select * from Members  where Email='" + txtemail.Trim().ToLower() + "'");
                List<Entity.Member> listDienThoai = SMember.Name_Text("select * from Members  where DienThoai='" + txtphone.Trim().ToLower() + "'");
                if (MoreAll.RegularExpressions.phone(txtphone))
                {
                    ViewBag.ThongBao = "Điện thoại không đúng định dạng";
                }
                else if (listDienThoai.Count > 0)
                {
                    ViewBag.ThongBao = "Điện thoại đã tồn tại trong hệ thống";
                }
                else if (list.Count > 0)
                {
                    ViewBag.ThongBao = "Email đã tồn tại trong hệ thống";
                }
                if (txtnguoigioithieu == "")
                {
                    ViewBag.ThongBao = "Vui lòng nhập người giới thiệu.";
                }
                else
                {
                    //System.Threading.Thread.Sleep(1000);
                    //#region Senmail
                    //if (!Commond.Setting("Emailden").Equals(""))
                    //    Senmail(txtHoTen, txtaddress, txtphone, txtemail, txttieude, txtcontent);
                    //#endregion

                    string Nguoigioithieu = "0";
                    string VTree = "0";
                    if (txtnguoigioithieu.Length > 0)
                    {
                        if (txtemail.Trim() != txtnguoigioithieu.Trim() || txtphone.Trim() != txtnguoigioithieu.Trim())
                        {
                            List<Entity.Member> iEmail = SMember.Name_Text("select * from Members  where DienThoai='" + txtnguoigioithieu.Trim().ToLower() + "'");// and DuyetTienDanap=1/  //and iuser_id !=" + MoreAll.MoreAll.GetCookies("MembersID") + " 
                            if (iEmail.Count > 0)
                            {
                                Nguoigioithieu = iEmail[0].ID.ToString();
                                VTree = iEmail[0].MTRee.ToString();
                            }
                            else
                            {
                                ViewBag.ThongBao = " Người giới thiệu không tồn tại hoặc chưa được kích hoạt trong hệ thống.";
                                return View();
                            }
                        }
                    }
                    String mtree = "|0|";
                    if (Nguoigioithieu != "0")
                    {
                        mtree = VTree;
                    }
                    String mtrees = mtree;

                    string validatekey = DateTime.Now.Ticks.ToString();
                    Member obj = new Member();
                    obj.PasWord = txtmatkhau;
                    obj.HoVaTen = txtHoTen;
                    obj.GioiTinh = 0;
                    obj.NgaySinh = DateTime.Now.ToString("dd/MM/yyyy");
                    obj.DiaChi = txtaddress;
                    obj.DienThoai = txtphone;
                    obj.Email = txtemail;
                    obj.AnhDaiDien = "";
                    obj.NgayTao = DateTime.Now;
                    obj.Key = validatekey;
                    obj.TrangThai = 1;
                    obj.Lang = language;
                    obj.GioiThieu = int.Parse(Nguoigioithieu);
                    if (Nguoigioithieu == "0")
                    {
                        obj.MTRee = "|0|";
                    }
                    else
                    {
                        obj.MTRee = mtrees.Replace("|0|", "|");
                    }
                    obj.TongTienDaMua = "0";
                    db.Members.InsertOnSubmit(obj);
                    db.SubmitChanges();

                    List<Entity.Member> Them = SMember.Name_Text("select top 1 * from Members order by ID desc");
                    if (Them.Count > 0)
                    {
                        string Cay = mtrees.Replace("|0|", "|") + Them[0].ID.ToString() + "|";
                        SMember.Name_Text("UPDATE [Members] SET MTRee='" + Cay + "' WHERE ID =" + Them[0].ID.ToString() + "");
                    }

                    ViewBag.ThongBao = "Đăng ký tài khoản thành công";
                }
            }
            return View();
        }

        #endregion

        #region Dang_Nhap
        public ActionResult Dang_Nhap(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //Ajax
        [HttpPost]
        public ActionResult Dang_Nhap(string txttendangnhap, string txtmatkhau, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if ((txttendangnhap.Trim().Length < 1) || (txtmatkhau.Trim().Length < 1))
                {
                    ViewBag.ThongBao = "Vui lòng điền thông tin đăng nhập";
                }
                else
                {
                    if (!RegularExpressions.phone(txttendangnhap.Trim().ToLower()))
                    {
                        List<Entity.Member> table = SMember.Name_Text("select * from Members where DienThoai='" + txttendangnhap.Trim().ToLower() + "' and PasWord='" + (txtmatkhau.Trim().ToLower()) + "' and TrangThai=1");
                        if (table.Count < 1)
                        {
                            ViewBag.ThongBao = "Tài khoản không đúng hoặc chưa được kích hoạt";
                        }
                        else
                        {

                            MoreAll.MoreAll.SetCookie("Members", txttendangnhap.Trim().ToLower(), 5000);
                            MoreAll.MoreAll.SetCookie("MembersID", table[0].ID.ToString(), 5000);
                            // return Redirect("/");
                            if (Url.IsLocalUrl(returnUrl))
                            {
                                ViewBag.ReturnUrl = returnUrl;
                                return Redirect(returnUrl);
                            }
                            else
                            {
                                return Redirect("/");
                                // return RedirectToAction("Index", "Home");
                            }
                        }
                    }
                }
            }
            return View();
        }

        #endregion

        #region XinChao Thoat
        public ActionResult XinChao()
        {
            if (MoreAll.MoreAll.GetCookies("Members").ToString() != "")
            {
                Member dt = db.Members.SingleOrDefault(p => p.ID == int.Parse(MoreAll.MoreAll.GetCookies("MembersID").ToString()));
                if (dt == null)
                {
                    return HttpNotFound();
                }
                else if (dt != null)
                {
                    return View(dt);
                }
            }
            return PartialView();
        }

        [HttpGet]
        public ActionResult Thoat()
        {
            MoreAll.MoreAll.SetCookie("Members", "", -1);
            MoreAll.MoreAll.SetCookie("MembersID", "", -1);
            Response.Redirect("/");
            return View();
        }

        #endregion

        #region XinChao Thoat
        public ActionResult XinChaoMobile()
        {
            if (MoreAll.MoreAll.GetCookies("Members").ToString() != "")
            {
                Member dt = db.Members.SingleOrDefault(p => p.ID == int.Parse(MoreAll.MoreAll.GetCookies("MembersID").ToString()));
                if (dt == null)
                {
                    return HttpNotFound();
                }
                else if (dt != null)
                {
                    return View(dt);
                }
            }
            return PartialView();
        }
        #endregion

        #region HoSoThanhVien
        [HttpGet]
        public ActionResult HoSoThanhVien()
        {
            // load lại thế này sẽ ko bị mất giá trị trong from text
            ShowLoad();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult HoSoThanhVien(FormCollection collect, HttpPostedFileBase file)
        {
            List<Entity.Member> list = SMember.Name_Text("select * from Members  where Email='" + collect["txtemail"].Trim().ToLower() + "' and ID!=" + MoreAll.MoreAll.GetCookies("MembersID").ToString() + "");
            List<Entity.Member> listDienThoai = SMember.Name_Text("select * from Members  where DienThoai='" + collect["txtphone"].Trim().ToLower() + "' and ID!=" + MoreAll.MoreAll.GetCookies("MembersID").ToString() + "");
            ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
            string _FileName = "";
            try
            {
                if (file.ContentLength > 0)
                {
                    _FileName = Path.GetFileName(file.FileName);
                    if (collect["HiddenAnhDaiDien"].Length > 0)
                    {
                        try
                        {
                            System.IO.File.Delete(utlitities.APPL_PHYSICAL_PATH + collect["HiddenAnhDaiDien"]);
                        }
                        catch (Exception)
                        {
                        }
                    }
                    string _path = Path.Combine(Server.MapPath("~/Uploads/avatar"), _FileName);
                    file.SaveAs(_path);
                }
            }
            catch (Exception)
            { }
            if (ModelState.IsValid)
            {
                if (collect["txtHoTen"] == "")
                {

                    SetAlert("Vui lòng điền đầy đủ họ và tên", "warning");
                    // ViewBag.ThongBao = "Vui lòng điền đầy đủ họ và tên";
                    ShowLoad(); // --> sẽ load lại giá trị cũ ở db
                    // giữ lại giá trị vừa nhập trên giao diện
                    ViewBag.Name = collect["txtHoTen"];
                }
                else if (collect["txtphone"] == "")
                {
                    SetAlert("Vui lòng điền điện thoại", "warning");
                    //ViewBag.ThongBao = "Vui lòng điền điện thoại";
                    ShowLoad();
                    ViewBag.Phone = collect["txtphone"];
                }
                else if (MoreAll.RegularExpressions.phone(collect["txtphone"]))
                {
                    SetAlert("Điện thoại không đúng định dạng", "warning");
                    //ViewBag.ThongBao = "Điện thoại không đúng định dạng";
                    ShowLoad();
                    ViewBag.Phone = collect["txtphone"];
                }
                else if (listDienThoai.Count > 0)
                {
                    SetAlert("Điện thoại đã tồn tại trong hệ thống", "warning");
                    // ViewBag.ThongBao = "Điện thoại đã tồn tại trong hệ thống";
                    ShowLoad();
                    ViewBag.Phone = collect["txtphone"];
                }
                else if (collect["txtaddress"] == "")
                {
                    SetAlert("Vui lòng điền địa chỉ", "warning");
                    // ViewBag.ThongBao = "Vui lòng điền địa chỉ";
                    ShowLoad();
                    ViewBag.Address = collect["txtaddress"];
                }
                else if (!MoreAll.RegularExpressions.IsValidEmail(collect["txtemail"]))
                {
                    SetAlert("Email không đúng định dạng", "warning");
                    // ViewBag.ThongBao = "Email không đúng định dạng";
                    ShowLoad();
                    ViewBag.Email = collect["txtemail"];
                }
                else if (collect["txtemail"] == "")
                {
                    SetAlert("Vui lòng điền email", "warning");
                    //ViewBag.ThongBao = "Vui lòng điền email";
                    ShowLoad();
                    ViewBag.Email = collect["txtemail"];
                }
                else if (list.Count > 0)
                {
                    SetAlert("Email đã tồn tại trong hệ thống", "warning");
                    //ViewBag.ThongBao = "Email đã tồn tại trong hệ thống";
                    ShowLoad();
                    ViewBag.Email = collect["txtemail"];
                }
                else
                {
                    Member obj = db.Members.SingleOrDefault(p => p.ID == int.Parse(MoreAll.MoreAll.GetCookies("MembersID").ToString()));
                    obj.HoVaTen = collect["txtHoTen"];
                    obj.GioiTinh = 0;
                    obj.NgaySinh = collect["txtngaysinh"];
                    obj.DiaChi = collect["txtaddress"];
                    obj.DienThoai = collect["txtphone"];
                    obj.Email = collect["txtemail"];
                    if (_FileName.Length > 0)
                    {
                        obj.AnhDaiDien = "/Uploads/avatar/" + _FileName;
                    }
                    obj.Lang = language;
                    db.SubmitChanges();
                    SetAlert("Cập nhật tài khoản thành công", "success");
                    // ViewBag.ThongBao = "Cập nhật tài khoản thành công";
                    // load lại thế này sẽ ko bị mất giá trị trong from text
                    ShowLoad();
                }
            }
            // ModelState.AddModelError("", "Mật khẩu không đúng.");
            //return RedirectToAction("HoSoThanhVien");
            return View();
        }
        public void ShowLoad()
        {
            if (MoreAll.MoreAll.GetCookies("MembersID").ToString() != "")
            {
                Member dt = db.Members.SingleOrDefault(p => p.ID == int.Parse(MoreAll.MoreAll.GetCookies("MembersID").ToString()));
                if (dt != null)
                {
                    ViewBag.Name = dt.HoVaTen;
                    ViewBag.Address = dt.DiaChi;
                    ViewBag.Email = dt.Email;
                    ViewBag.Phone = dt.DienThoai;
                    ViewBag.NgaySinh = dt.NgaySinh;
                    if (dt.AnhDaiDien.Length > 0)
                    {
                        ViewBag.AnhDaiDiens = dt.AnhDaiDien;
                        ViewBag.Avata = " <img src=\"" + dt.AnhDaiDien + "\" style=\" width:100px\" />";
                    }
                }
            }
        }
        #endregion

        #region DoiMatKhau
        public ActionResult DoiMatKhau()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult DoiMatKhau(FormCollection collect)
        {
            if (ModelState.IsValid)
            {
                if (((collect["txtmatkhaumoicu"] == "") || (collect["txtmatkhaumoi"] == "")) || (collect["txtmatkhauxacnhan"] == ""))
                {
                    ViewBag.ThongBao = AlertMessage(Commond.label("matkhau1"), "warning");
                }
                else if (collect["txtmatkhaumoi"].Length < 3)
                {
                    ViewBag.ThongBao = AlertMessage(Commond.label("matkhau2"), "warning");
                }
                else if (!collect["txtmatkhaumoi"].Equals(collect["txtmatkhauxacnhan"]))
                {
                    ViewBag.ThongBao = AlertMessage(Commond.label("matkhau2"), "warning");
                }
                else
                {
                    if (MoreAll.MoreAll.GetCookie("Members") != null)
                    {
                        Member itel = db.Members.SingleOrDefault(p => p.ID == int.Parse(MoreAll.MoreAll.GetCookies("MembersID").ToString()) && p.PasWord == collect["txtmatkhaumoicu"].Trim());
                        if (itel == null)
                        {
                            ViewBag.ThongBao = AlertMessage(Commond.label("matkhau3"), "warning");
                        }
                        else
                        {
                            Member abc = db.Members.SingleOrDefault(p => p.ID == int.Parse(MoreAll.MoreAll.GetCookies("MembersID").ToString()));
                            abc.PasWord = collect["txtmatkhaumoi"].Trim();
                            db.SubmitChanges();
                            ViewBag.ThongBao = AlertMessage(Commond.label("matkhau4"), "success");
                        }
                    }
                    else
                    {
                        base.Response.Redirect(MoreAll.MoreAll.RequestUrl(Request.Url.ToString()));
                    }
                }
            }
            return View();
        }
        #endregion

        #region QuenMatKhau
        public ActionResult QuenMatKhau()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult QuenMatKhau(FormCollection collect)
        {
            if (ModelState.IsValid)
            {
                if (collect["txtemail"] == "")
                {
                    SetAlert("Vui lòng nhập địa chỉ Email", "warning");
                }
                else if (collect["txtemail"].Length < 3)
                {
                    SetAlert("Vui lòng nhập địa chỉ Email", "warning");
                }
                else
                {
                    Member itel = db.Members.SingleOrDefault(p => p.Email == collect["txtemail"].Trim());
                    if (itel == null)
                    {
                        SetAlert("Email của bạn không tồn tại trong hệ thống.", "warning");
                    }
                    else
                    {
                        string newpassword = DateTime.Now.Ticks.ToString();
                        newpassword = newpassword.Substring(newpassword.Length - 8, 7);
                        Member abc = db.Members.SingleOrDefault(p => p.ID == int.Parse(itel.ID.ToString()));
                        abc.PasWord = newpassword;
                        db.SubmitChanges();

                        string info = "Thông tin tài khoản từ web : http://" + MoreAll.MoreAll.RequestUrl(Request.Url.Authority) + "/Dang-nhap.html" + "<br>Thông tin tài khoản của bạn!<br>Tên đăng nhập: <b>" + itel.Email + " </b><br>Mật khẩu mới:  <b>" + newpassword + " </b>";
                        string title = "Cập nhật lại mật khẩu Mới!";

                        string email = Email.email();
                        string password = Email.password();
                        int str6 = Convert.ToInt32(Email.port());
                        string host = Email.host();

                        MailUtilities.SendMail("Cập nhật lại mật khẩu Mới!", email, password, itel.Email.ToString(), host, Convert.ToInt32(str6), title, info);

                        SetAlert("Email x\x00e1c nhận đ\x00e3 được gởi đến t\x00e0i khoản Email của bạn. <br>Vui l\x00f2ng check Email để x\x00e1c nhận.", "success");

                    }
                }
            }
            return View();
        }
        #endregion

        #region LichSuMuaHang
        public ActionResult LichSuMuaHang(int page = 1, int pageSize = 20)
        {
            // Phân trang bằng MVC
            if (MoreAll.MoreAll.GetCookies("MembersID").ToString() != "")
            {
                var model = SQLCart.ListLichSu(page, pageSize, MoreAll.MoreAll.GetCookies("MembersID").ToString());// truy vấn sang class khác cho gọn
                return View(model);

                //string sql = "select * from Carts where IDThanhVien=" + MoreAll.MoreAll.GetCookies("MembersID").ToString() + "";
                //sql = sql + " order by Create_Date desc";
                //List<LCart> dt = db.ExecuteQuery<LCart>(@"" + sql + "").ToList();
                //if (dt.Count > 0)
                //{
                //    return View(dt);
                //}
            }
            else
            {
                Response.Redirect("/dang-nhap.html");
            }
            return View();
        }

        public ActionResult ChiTietDonHang(int ID)
        {
            if (MoreAll.MoreAll.GetCookies("MembersID").ToString() != "")
            {
                List<LCart> dt = db.LCarts.Where(x => x.IDThanhVien == int.Parse(MoreAll.MoreAll.GetCookies("MembersID").ToString()) && x.ID == ID).ToList();
                if (dt != null)
                {
                    ViewBag.ltmadonhang = dt[0].ID.ToString();
                    ViewBag.ltngaydathang = dt[0].Create_Date.ToString();
                    ViewBag.lttrangthai = AllQuery.MorePro.ShowTrangThai(dt[0].Status.ToString());
                    ViewBag.lthovaten = dt[0].Name.ToString();
                    ViewBag.ltdiachi = dt[0].Address.ToString();
                    ViewBag.ltdienthoai = dt[0].Phone.ToString();
                    ViewBag.lttongtien = AllQuery.MorePro.Detail_Price(dt[0].Money.ToString());
                    ViewBag.lttongtienbangchu = MoreAll.Hamdoisorachu.So_chu(Convert.ToDouble(dt[0].Money.ToString()));

                    List<Entity.CartDetail> model = SCartDetail.Detail_ID_Cart(dt[0].ID.ToString());
                    if (model.Count > 0)
                    {
                        ViewBag.Chitiet = model;
                    }
                }
            }
            else
            {
                Response.Redirect("/dang-nhap.html?ReturnUrl=" + Request.RawUrl.ToString() + "");
            }
            return View();
        }
        #endregion

        #region LinkGioiThieu
        public ActionResult LinkGioiThieu()
        {
            if (MoreAll.MoreAll.GetCookies("MembersID").ToString() == "")
            {
                return Redirect("/dang-nhap.html?ReturnUrl=" + Request.RawUrl.ToString() + "");
            }
            string ssl = "http://";
            if (Commond.Setting("SSL").Equals("1"))
            {
                ssl = "https://";
            }
            if (MoreAll.MoreAll.GetCookies("MembersID") != "")
            {
                Member table = db.Members.SingleOrDefault(p => p.ID == int.Parse(MoreAll.MoreAll.GetCookies("MembersID").ToString()));
                if (table != null)
                {
                    //if (table.KichHoatThanhVien == 0)
                    //{
                    //    Response.Write("<script type=\"text/javascript\">alert('Bạn không thể sử dụng tính năng này. Yêu cầu kích hoạt tài khoản thành viên.');window.location.href='/vi-tien.html'; </script>");
                    //}
                    ViewBag.txtlinkgioithieu = "https://bds3mien.vn/dang-ky.html?info=" + table.DienThoai.ToString() + "";
                    ViewBag.ltshare = "<div style='margin-left: 6px;' class=\"zalo-share-button\" data-href=\"https://bds3mien.vn/dang-ky.html?info=" + table.DienThoai.ToString() + "\"  data-oaid=\"3853758560685742933\" data-layout=\"1\" data-color=\"blue\" data-customize=false></div>";
                }
            }
            return View();
        }
        #endregion

        public ActionResult DangTin()
        {
            if (MoreAll.MoreAll.GetCookies("MembersID").ToString() != "")
            {
                ViewBag.ddlcountry = Bind_ddlCountry();
            }
            else
            {
                Response.Redirect("/dang-nhap.html");
            }
            return View();
        }

        #region Tỉnh thành
        protected string Bind_ddlCountry()
        {
            string str = "";
            str += "<select id=\"ddlcountry\" name=\"ddlcountry\" class='form-control custom-select'>";
            str += "<option value=\"0\">Chọn tỉnh thành</option>";
            List<Tinhthanh> dt = db.Tinhthanhs.Where(p => p.Parent_ID.ToString() == "-1" && p.capp == "TT").OrderByDescending(s => s.Orders).ToList();
            for (int i = 0; i < dt.Count; i++)
            {
                if (dt[i].Parent_ID.ToString() == "-1")
                {
                    str += "<option value=\"" + dt[i].ID.ToString() + "\">" + dt[i].Name.ToString() + "</option>";
                }
            }
            str += "</select>";
            return str;
        }
        protected string Bind_ddlState(int CountryId)
        {
            string str = "";
            str += "<option value=\"0\">Chọn quận/huyện</option>";
            List<Tinhthanh> dt = db.Tinhthanhs.Where(p => p.Parent_ID == CountryId && p.capp == "TT").OrderByDescending(s => s.Orders).ToList();
            for (int i = 0; i < dt.Count; i++)
            {
                str += "<option value=\"" + dt[i].ID.ToString() + "\">" + dt[i].Name.ToString() + "</option>";
            }
            return str;
        }

        protected string PhuongXaHtml(int CountryId)
        {
            string str = "";
            str += "<option value=\"0\">Chọn phường/xã</option>";
            List<Tinhthanh> dt = db.Tinhthanhs.Where(p => p.Parent_ID == CountryId && p.capp == "TT").OrderByDescending(s => s.Orders).ToList();
            for (int i = 0; i < dt.Count; i++)
            {
                str += "<option value=\"" + dt[i].ID.ToString() + "\">" + dt[i].Name.ToString() + "</option>";
            }
            return str;
        }
        [HttpGet]
        public string StateDetails(int CountryId)
        {
            return Bind_ddlState(CountryId);
        }

        [HttpGet]
        public string StatePhuongXa(int CountryId)
        {
            return PhuongXaHtml(CountryId);
        }
        #endregion

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult DangTin(string title, string demand, string category, string ddlcountry, string ddlstate, string PhuongXa, string address, string Dientich, string DonGia, string price, string huongnha, string Mattien, string Logioi, string Sotang, string Sophongngu, string Sotoilet, string LinkYoutube, string txtMImage, string txttomtat)
        {
            bool Loi = true;
            if (ModelState.IsValid)
            {
                if (title == "")
                {
                    ViewBag.ThongBao += "Bạn chưa nhập tiêu đề.<br>";
                    Loi = false;
                }
                if (demand == "")
                {
                    ViewBag.ThongBao += "Bạn chưa chọn nhu cầu.<br>";
                    Loi = false;
                }
                if (category == "")
                {
                    ViewBag.ThongBao += "Bạn chưa chọn loại nhà đất.<br>";
                    Loi = false;
                }
                if (ddlcountry == "")
                {
                    ViewBag.ThongBao += "Bạn chưa chọn tỉnh/thành.<br>";
                    Loi = false;
                }
                if (ddlstate == "")
                {
                    ViewBag.ThongBao += "Bạn chưa chọn quận/huyện.<br>";
                    Loi = false;
                }
                if (PhuongXa == "")
                {
                    ViewBag.ThongBao += "Bạn chưa chọn phường/xã.<br>";
                    Loi = false;
                }
                if (address == "")
                {
                    ViewBag.ThongBao += "Bạn chưa nhập địa chỉ.<br>";
                    Loi = false;
                }
                if (Dientich == "")
                {
                    ViewBag.ThongBao += "Bạn chưa nhập diện tích.<br>";
                    Loi = false;
                }
                if (price == "")
                {
                    ViewBag.ThongBao += "Bạn chưa nhập giá.<br>";
                    Loi = false;
                }
                if (DonGia == "")
                {
                    ViewBag.ThongBao += "Bạn chưa chọn đơn giá.<br>";
                    Loi = false;
                }
                if (txttomtat == "")
                {
                    ViewBag.ThongBao += "Bạn chưa nhập thông tin mô tả.<br>";
                    Loi = false;
                }

                if (Loi == true)
                {
                    int cong = 0;
                    string TangName = "";

                    #region InsertMenu
                    List<Entity.Products> curItem = SProducts.Name_Text("SELECT top 1 * FROM Products order by ipid desc");
                    if (curItem.Count > 0) { int tong = int.Parse(curItem[0].ipid.ToString()); cong = tong + 1; }
                    var hasTagName = db.products.Where(s => s.TangName == MoreAll.AddURL.SeoURL(title)).FirstOrDefault();
                    TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(title) + "-" + cong : MoreAll.AddURL.SeoURL(title);
                    #endregion

                    product obj = new product();
                    #region MyRegion
                    obj.icid = int.Parse(category);
                    obj.ID_Hang = int.Parse("0");
                    obj.sanxuat = int.Parse("0");
                    obj.Code = "";
                    obj.Name = title;
                    obj.Brief = title;
                    obj.Contents = txttomtat;
                    obj.search = RewriteURLNew.NameSearch(title);
                    //obj.Images = vimg;
                    //obj.ImagesSmall = small;
                    obj.Images = Commond.CatAnhSP(txtMImage);//Lấy ảnh đầu tiên thôi
                    obj.ImagesSmall = Commond.CatAnhSP(txtMImage).Replace("uploads", "uploads/_thumbs");

                    obj.Equals = 0;
                    obj.Quantity = 1;// int.Parse(txtquantity.Text.Trim());
                    obj.Price = Convert.ToInt32(price);
                    obj.OldPrice = 0;// Convert.ToInt32(txtoldprice.Text); 
                    obj.Views = 0;
                    obj.Chekdata = 1;
                    obj.Create_Date = DateTime.Now;
                    obj.Modified_Date = DateTime.Now.AddYears(10);
                    obj.lang = this.language;
                    obj.News = 0;
                    obj.Home = 0;
                    obj.Check_01 = 0;
                    obj.Check_02 = 0;
                    obj.Check_03 = 0;
                    obj.Check_04 = 0;
                    obj.Check_05 = 0;
                    obj.Status = 0;
                    obj.Titleseo = "";
                    obj.Keyword = "";
                    obj.Meta = "";
                    obj.Anh = txtMImage.TrimEnd(',');
                    obj.Noidung1 = "";
                    obj.Noidung2 = "";
                    obj.Noidung3 = "";
                    obj.Noidung4 = "";
                    obj.Noidung5 = "";
                    obj.TangName = TangName;
                    obj.RateCount = 0;
                    obj.RateSum = 0;
                    obj.Alt = "";

                    obj.Thanhpho = int.Parse(ddlcountry);
                    obj.Quanhuyen = int.Parse(ddlstate);
                    obj.Phuongxa = int.Parse(PhuongXa);

                    obj.DiaChi = address;
                    obj.DienTich = Dientich;
                    obj.DonGia = int.Parse(DonGia);
                    obj.HuongNha = int.Parse(huongnha);
                    obj.MatTien = Mattien;
                    obj.LoGioi = Logioi;
                    obj.SoTang = int.Parse(Sotang);
                    obj.SoPhong = int.Parse(Sophongngu);
                    obj.SoToilet = int.Parse(Sotoilet);
                    obj.LinkYoutube = LinkYoutube;
                    obj.IDThanhVien = Convert.ToInt32(MoreAll.MoreAll.GetCookies("MembersID").ToString());
                    obj.ThanhVienDuyetBai = "";
                    #endregion
                    //SProducts.Insert(obj);
                    db.products.InsertOnSubmit(obj);
                    db.SubmitChanges();
                    ViewBag.ThongBao = "Đăng ký tài khoản thành công";
                    ViewBag.ddlcountry = Bind_ddlCountry();
                    Response.Redirect("/danh-sach-tin-dang.html");
                }
                else
                {
                    ViewBag.ddlcountry = Bind_ddlCountry();
                }
            }
            return View();
        }

        public string ShowLoaiDat(string CountryId)
        {
            string str = "";
            str += "<option value=\"0\">Chọn loại nhà đất</option>";
            List<Menu> dt = db.Menus.Where(p => p.Parent_ID.ToString() == CountryId && p.capp == "PR").OrderByDescending(s => s.Orders).ToList();
            for (int i = 0; i < dt.Count; i++)
            {
                str += "<option value=\"" + dt[i].ID.ToString() + "\">" + dt[i].Name.ToString() + "</option>";
            }
            return str;
        }

        public ActionResult EditDangTin()
        {
            if (MoreAll.MoreAll.GetCookies("MembersID").ToString() != "")
            {
                ViewBag.ddlcountry = Bind_ddlCountry();
                Int32 ID = 1;
                if ((Request.QueryString["id"] != null) && (Request.QueryString["id"] != ""))
                {
                    ID = Convert.ToInt16(Request.QueryString["id"].Trim());
                }
                List<product> dtdetail = db.ExecuteQuery<product>(@"SELECT * FROM products where  ipid=" + ID + " and IDThanhVien=" + Convert.ToInt32(MoreAll.MoreAll.GetCookies("MembersID").ToString()) + " order by Create_Date desc").ToList();
                if (dtdetail.Count > 0)
                {
                    ViewBag.ipid = dtdetail[0].ipid.ToString();

                    ViewBag.DonGia = dtdetail[0].DonGia.ToString();
                    ViewBag.HuongNha = dtdetail[0].HuongNha.ToString();
                    ViewBag.SoTang = dtdetail[0].SoTang.ToString();
                    ViewBag.SoPhong = dtdetail[0].SoPhong.ToString();
                    ViewBag.SoToilet = dtdetail[0].SoToilet.ToString();
                    ViewBag.NhaDatBan = ShowLoaiDat(More.MenuDacap(dtdetail[0].icid.ToString()));
                    ViewBag.category = dtdetail[0].icid.ToString();
                    ViewBag.demand = More.MenuDacap(dtdetail[0].icid.ToString());

                    try
                    {
                        Bind_ddlCountry();
                        ViewBag.TinhThanhc = dtdetail[0].Thanhpho.ToString();
                    }
                    catch (Exception)
                    { }

                    try
                    {
                        ViewBag.QuanHuyenView = Bind_ddlState(int.Parse(dtdetail[0].Thanhpho.ToString()));
                        ViewBag.Quanhuyen = dtdetail[0].Quanhuyen.ToString();
                    }
                    catch (Exception)
                    { }

                    try
                    {
                        ViewBag.PhgXa = dtdetail[0].Phuongxa.ToString();
                        ViewBag.PhuongXaView = PhuongXaHtml(int.Parse(dtdetail[0].Quanhuyen.ToString()));
                    }
                    catch (Exception)
                    { }

                    ViewBag.Dientich = dtdetail[0].DienTich.ToString();
                    ViewBag.title = dtdetail[0].Name.ToString();
                    ViewBag.address = dtdetail[0].DiaChi.ToString();

                    ViewBag.price = dtdetail[0].Price.ToString();
                    ViewBag.Mattien = dtdetail[0].MatTien.ToString();
                    ViewBag.Logioi = dtdetail[0].LoGioi.ToString();
                    ViewBag.LinkYoutube = dtdetail[0].LinkYoutube.ToString();
                    ViewBag.txttomtat = dtdetail[0].Contents.ToString();

                    if (dtdetail[0].Anh.Length > 0)
                    {
                        ViewBag.txtMImage = dtdetail[0].Anh;
                        ViewBag.scriptMG = "<script type='text/javascript'>LoadStringImg('" + dtdetail[0].Anh + "','txtMImage');</script>";
                    }
                    else
                    {
                        ViewBag.txtMImage = "";
                    }

                }
            }
            else
            {
                Response.Redirect("/dang-nhap.html");
            }
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditDangTin(string hdipid, string title, string demand, string category, string ddlcountry, string ddlstate, string PhuongXa, string address, string Dientich, string DonGia, string price, string huongnha, string Mattien, string Logioi, string Sotang, string Sophongngu, string Sotoilet, string LinkYoutube, string txtMImage, string txttomtat)
        {
            List<product> dtdetail = db.ExecuteQuery<product>(@"SELECT * FROM products where  ipid=" + hdipid + " and IDThanhVien=" + Convert.ToInt32(MoreAll.MoreAll.GetCookies("MembersID").ToString()) + " order by Create_Date desc").ToList();
            if (dtdetail.Count > 0)
            {
                bool Loi = true;
                if (ModelState.IsValid)
                {
                    if (title == "")
                    {
                        ViewBag.ThongBao += "Bạn chưa nhập tiêu đề.<br>";
                        Loi = false;
                    }
                    if (demand == "")
                    {
                        ViewBag.ThongBao += "Bạn chưa chọn nhu cầu.<br>";
                        Loi = false;
                    }
                    if (category == "")
                    {
                        ViewBag.ThongBao += "Bạn chưa chọn loại nhà đất.<br>";
                        Loi = false;
                    }
                    if (ddlcountry == "")
                    {
                        ViewBag.ThongBao += "Bạn chưa chọn tỉnh/thành.<br>";
                        Loi = false;
                    }
                    if (ddlstate == "")
                    {
                        ViewBag.ThongBao += "Bạn chưa chọn quận/huyện.<br>";
                        Loi = false;
                    }
                    if (PhuongXa == "")
                    {
                        ViewBag.ThongBao += "Bạn chưa chọn phường/xã.<br>";
                        Loi = false;
                    }
                    if (address == "")
                    {
                        ViewBag.ThongBao += "Bạn chưa nhập địa chỉ.<br>";
                        Loi = false;
                    }
                    if (Dientich == "")
                    {
                        ViewBag.ThongBao += "Bạn chưa nhập diện tích.<br>";
                        Loi = false;
                    }
                    if (price == "")
                    {
                        ViewBag.ThongBao += "Bạn chưa nhập giá.<br>";
                        Loi = false;
                    }
                    if (DonGia == "")
                    {
                        ViewBag.ThongBao += "Bạn chưa chọn đơn giá.<br>";
                        Loi = false;
                    }
                    if (txttomtat == "")
                    {
                        ViewBag.ThongBao += "Bạn chưa nhập thông tin mô tả.<br>";
                        Loi = false;
                    }

                    if (Loi == true)
                    {
                        int cong = 0;
                        string TangName = "";

                        #region InsertMenu
                        List<Entity.Products> curItem = SProducts.Name_Text("SELECT top 1 * FROM Products order by ipid desc");
                        if (curItem.Count > 0) { int tong = int.Parse(curItem[0].ipid.ToString()); cong = tong + 1; }
                        var hasTagName = db.products.Where(s => s.TangName == MoreAll.AddURL.SeoURL(title)).FirstOrDefault();
                        TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(title) + "-" + cong : MoreAll.AddURL.SeoURL(title);
                        #endregion

                        product obj = db.products.SingleOrDefault(p => p.ipid == Convert.ToInt32(dtdetail[0].ipid.ToString()));
                        #region MyRegion
                        obj.icid = int.Parse(category);
                        obj.ID_Hang = int.Parse("0");
                        obj.sanxuat = int.Parse("0");
                        obj.Code = "";
                        obj.Name = title;
                        obj.Brief = title;
                        obj.Contents = txttomtat;
                        obj.search = RewriteURLNew.NameSearch(title);
                        //obj.Images = vimg;
                        //obj.ImagesSmall = small;
                        obj.Images = Commond.CatAnhSP(txtMImage);//Lấy ảnh đầu tiên thôi
                        obj.ImagesSmall = Commond.CatAnhSP(txtMImage).Replace("uploads", "uploads/_thumbs");

                        obj.Equals = 0;
                        obj.Quantity = 1;// int.Parse(txtquantity.Text.Trim());
                        obj.Price = Convert.ToInt32(price);
                        obj.OldPrice = 0;// Convert.ToInt32(txtoldprice.Text); 
                        obj.Views = 0;
                        obj.Chekdata = 1;
                        //obj.Create_Date = DateTime.Now;
                        // obj.Modified_Date = DateTime.Now.AddYears(10);
                        obj.lang = this.language;
                        obj.News = 0;
                        obj.Home = 0;
                        obj.Check_01 = 0;
                        obj.Check_02 = 0;
                        obj.Check_03 = 0;
                        obj.Check_04 = 0;
                        obj.Check_05 = 0;
                        obj.Status = 0;
                        obj.Titleseo = "";
                        obj.Keyword = "";
                        obj.Meta = "";
                        obj.Anh = txtMImage.TrimEnd(',');
                        obj.Noidung1 = "";
                        obj.Noidung2 = "";
                        obj.Noidung3 = "";
                        obj.Noidung4 = "";
                        obj.Noidung5 = "";
                        obj.TangName = TangName;
                        obj.RateCount = 0;
                        obj.RateSum = 0;
                        obj.Alt = "";

                        obj.Thanhpho = int.Parse(ddlcountry);
                        obj.Quanhuyen = int.Parse(ddlstate);
                        obj.Phuongxa = int.Parse(PhuongXa);

                        obj.DiaChi = address;
                        obj.DienTich = Dientich;
                        obj.DonGia = int.Parse(DonGia);
                        obj.HuongNha = int.Parse(huongnha);
                        obj.MatTien = Mattien;
                        obj.LoGioi = Logioi;
                        obj.SoTang = int.Parse(Sotang);
                        obj.SoPhong = int.Parse(Sophongngu);
                        obj.SoToilet = int.Parse(Sotoilet);
                        obj.LinkYoutube = LinkYoutube;
                        obj.IDThanhVien = Convert.ToInt32(MoreAll.MoreAll.GetCookies("MembersID").ToString());
                        obj.ThanhVienDuyetBai = "";
                        #endregion
                        db.SubmitChanges();
                        Response.Redirect("/danh-sach-tin-dang.html");
                    }
                }
            }
            else
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm";
            }
            return View();
        }

        public ActionResult DanhSachDangTin()
        {
            if (MoreAll.MoreAll.GetCookies("MembersID").ToString() != "")
            {
                ViewBag.ddlcountry = Bind_ddlCountry();
            }
            else
            {
                Response.Redirect("/dang-nhap.html");
            }
            int Tongsobanghi = 0;
            Int16 pages = 1;
            int Tongsotrang = int.Parse("15");

            if ((Request.QueryString["page"] != null) && (Request.QueryString["page"] != ""))
            {
                pages = Convert.ToInt16(Request.QueryString["page"].Trim());
            }
            List<product> iitem = db.ExecuteQuery<product>(@"SELECT * FROM products where  lang='" + language + "' and IDThanhVien=" + Convert.ToInt32(MoreAll.MoreAll.GetCookies("MembersID").ToString()) + " order by Create_Date desc").ToList();
            if (iitem.Count() > 0)
            {
                Tongsobanghi = iitem.Count();
            }
            int PageIndex = (pages - 1);
            int Tongpage = Tongsotrang;
            int StartRecord = PageIndex * Tongpage;
            int EndRecord = StartRecord + Tongpage + 1;
            List<product> dt = db.ExecuteQuery<product>(@"SELECT * FROM (SELECT ROW_NUMBER() OVER ( order by Create_Date desc) AS rowindex ,*  FROM  products  where   lang='" + language + "'   and IDThanhVien=" + Convert.ToInt32(MoreAll.MoreAll.GetCookies("MembersID").ToString()) + ") AS A WHERE  ( A.rowindex >  " + StartRecord.ToString() + " AND A.rowindex < " + EndRecord + ")").ToList();
            //if (dt.Count >= 1)
            // ViewBag.ShowKQ = dt;

            if (Tongsobanghi % Tongsotrang > 0)
            {
                Tongsobanghi = (Tongsobanghi / Tongsotrang) + 1;
            }
            else
            {
                Tongsobanghi = Tongsobanghi / Tongsotrang;
            }
            ViewBag.ltpage = Commond.Phantrang("/danh-sach-tin-dang.html", Tongsobanghi, pages);
            return View(dt);
        }
        public ActionResult XoaBaiViet(string deleteid)
        {
            if (MoreAll.MoreAll.GetCookies("MembersID").ToString() != "")
            {
                List<product> iitem = db.ExecuteQuery<product>(@"SELECT * FROM products where  lang='" + language + "' and IDThanhVien=" + Convert.ToInt32(MoreAll.MoreAll.GetCookies("MembersID").ToString()) + " order by Create_Date desc").ToList();
                if (iitem.Count() > 0)
                {
                    SProducts.Name_Text("DELETE FROM Products WHERE ipid=" + deleteid + "");
                    Response.Redirect("/danh-sach-tin-dang.html");
                }

            }
            else
            {
                Response.Redirect("/dang-nhap.html");
            }
            return View();
        }


        #region MThanhVien
        public ActionResult MThanhVien()
        {
            DatalinqDataContext db = new DatalinqDataContext();
            string ID = MoreAll.MoreAll.GetCookies("MembersID").ToString();
            if (MoreAll.MoreAll.GetCookies("MembersID").ToString() == "")
            {
                return Redirect("/dang-nhap.html?ReturnUrl=" + Request.RawUrl.ToString() + "");
            }
            if (MoreAll.MoreAll.GetCookies("MembersID") != "")
            {
                if (Request["ID"] != null && !Request["ID"].Equals(""))
                {
                    ID = Request["ID"];
                }
                List<Entity.Member> dt = SMember.Name_Text("SELECT * FROM Members  WHERE ID = " + ID + " ");
                if (dt.Count > 0)
                {
                    string Mtr = "|" + dt[0].MTRee.ToString();
                    if (Mtr.Contains("|" + MoreAll.MoreAll.GetCookies("MembersID").ToString() + "|"))
                    {
                        ViewBag.ltphanmuc = LoadNav(int.Parse(ID.ToString()));
                        LoadItems();
                    }
                    else
                    {
                        // ViewBag.ThongBao = "Bạn ko có quyền xem ID này. Vì ID này không nằm trong hệ thống của bạn";
                        //WebMsgBox.Show("Bạn ko có quyền xem ID này. Vì ID này không nằm trong hệ thống của bạn");
                    }
                }
            }
            return View();
        }
        public void LoadItems()
        {
            string Loc = "";
            string ID = MoreAll.MoreAll.GetCookies("MembersID").ToString();
            if (Request["ID"] != null && !Request["ID"].Equals(""))
            {
                ID = Request["ID"];
                Loc += "&ID=" + ID;
            }
            if (MoreAll.MoreAll.GetCookies("MembersID") != "")
            {
                int Tongsobanghi = 0;
                Int16 pages = 1;
                int Tongsotrang = int.Parse("10");
                if ((Request.QueryString["page"] != null) && (Request.QueryString["page"] != ""))
                {
                    pages = Convert.ToInt16(Request.QueryString["page"].Trim());
                }
                List<Member> iitem = db.ExecuteQuery<Member>(@"SELECT * FROM Members where 1=1 and GioiThieu=" + ID + " order by ID desc").ToList();
                if (iitem.Count() > 0)
                {
                    Tongsobanghi = iitem.Count();
                }
                int PageIndex = (pages - 1);
                int Tongpage = Tongsotrang;
                int StartRecord = PageIndex * Tongpage;
                int EndRecord = StartRecord + Tongpage + 1;
                List<Member> dt = db.ExecuteQuery<Member>(@"SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY ID DESC) AS rowindex ,*  FROM  Members  where 1=1 and GioiThieu=" + ID + ") AS A WHERE  ( A.rowindex >  " + StartRecord.ToString() + " AND A.rowindex < " + EndRecord + ")").ToList();
                {
                    ViewBag.Show = dt;
                }
                if (Tongsobanghi % Tongsotrang > 0)
                {
                    Tongsobanghi = (Tongsobanghi / Tongsotrang) + 1;
                }
                else
                {
                    Tongsobanghi = Tongsobanghi / Tongsotrang;
                }
                ViewBag.ltpage = Commond.PhantrangAdmin("/danh-sach-thanh-vien.html?ID=" + ID + "", Tongsobanghi, pages);
            }
        }
        private string LoadNav(int ID)
        {
            string nav = "";
            try
            {
                var item = db.Members.FirstOrDefault(s => s.ID == ID);
                if (item != null)
                {
                    nav = "<span> <i class=\"fa fa-angle-right\"></i> </span> <a href=\"/Danh-sach-thanh-vien.html?ID=" + item.ID + "\">" + item.HoVaTen + "</a>" + nav;
                    if (item.GioiThieu >= int.Parse(MoreAll.MoreAll.GetCookies("MembersID").ToString()))
                    {
                        LoadNav(Convert.ToInt32(item.GioiThieu));
                    }
                }
            }
            catch (Exception)
            { }
            return nav;
        }
        #endregion



        #region ThanhToan
        public ActionResult ThanhToan()
        {
            if (MoreAll.MoreAll.GetCookies("MembersID").ToString() == "")
            {
                return Redirect("/dang-nhap.html?ReturnUrl=" + Request.RawUrl.ToString() + "");
            }
            if (MoreAll.MoreAll.GetCookies("MembersID") != "")
            {
                ShowThanhToan();
            }
            return View();
        }


        private void ShowThanhToan()
        {
            if (MoreAll.MoreAll.GetCookies("MembersID") != "")
            {
                Member table = db.Members.SingleOrDefault(p => p.ID == int.Parse(MoreAll.MoreAll.GetCookies("MembersID").ToString()));
                if (table != null)
                {
                    //if (table.F1 < Convert.ToInt32(Commond.Setting("trxtduF1")))
                    //{
                    //    Response.Write("<script type=\"text/javascript\">alert('Bạn phải đủ giới thiệu ra " + Commond.Setting("trxtduF1") + " F1 thì mới rút được điểm.');window.location.href='/wallet.html'; </script>");
                    //}
                    if (table.TienHoaHong.ToString() != "0")
                    {
                        ViewBag.lttongtien = table.TienHoaHong.ToString();
                    }
                    else
                    {
                        ViewBag.lttongtien = "0";
                    }
                }
            }
        }

        [HttpPost]
        public ActionResult ThanhToan(string txtsotiencanrut, string txttennganhang, string txthovaten, string txtsotaikhoan, string txtchinhanh, string txtnoidungchuyentien)
        {
            if (MoreAll.MoreAll.GetCookies("MembersID").ToString() == "")
            {
                return Redirect("/dang-nhap.html?ReturnUrl=" + Request.RawUrl.ToString() + "");
            }
            if (MoreAll.MoreAll.GetCookies("MembersID") != "")
            {
                #region Trừ tiền trong ví
                Member iitem = db.Members.SingleOrDefault(p => p.ID == int.Parse(MoreAll.MoreAll.GetCookies("MembersID").ToString()));
                if (iitem != null)
                {
                    double ConglaiCoin = 0;
                    double TongSoCoinDaCo = Convert.ToDouble(iitem.TienHoaHong);
                    double TongTienCanRutCoin = Convert.ToDouble(txtsotiencanrut);

                    #region Chỉ được rút tiền khi điểm lớn hơn hoặc = 200 điểm
                    if (TongSoCoinDaCo <= 200)
                    {
                        ViewBag.ltmsg = "<div class=\"ruttienthongbaos\">Chỉ được rút tiền khi điểm lớn hơn hoặc bằng 200.000 VNĐ.</div>";
                        return View();
                    }
                    #endregion
                    //if (iitem.F1 < Convert.ToInt32(Commond.Setting("trxtduF1")))
                    //{
                    //    ViewBag.ltmsg = ("<script type=\"text/javascript\">alert('Bạn phải đủ giới thiệu ra " + Commond.Setting("trxtduF1") + " F1 thì mới rút được điểm.');window.location.href='/wallet.html'; </script>");
                    //    return View();
                    //}
                    //if (iitem.TrangThaiMuaHangDatTongTien == 0)
                    //{
                    //    ViewBag.ltmsg = ("<script type=\"text/javascript\">alert('Tài khoản của bạn phải có đơn hàng có giá trị : " + Commond.Setting("txtgiatridonhang") + " triệu trở lên thì mới rút được tiền.');window.location.href='/rut-tien.html'; </script>");
                    //    return View();
                    //}

                    // double QuYVNDRaCoin = (TongTienCanRutCoin) / 1000;
                    if (TongSoCoinDaCo >= TongTienCanRutCoin)
                    {
                        if (TongSoCoinDaCo.ToString() != "0")// Nếu trong ví có lớn hơn 0 đồng thì cộng tiếp
                        {
                            ConglaiCoin = ((TongSoCoinDaCo) - (TongTienCanRutCoin));
                            iitem.TienHoaHong = ConglaiCoin.ToString();
                            db.SubmitChanges();
                        }
                        if (TongSoCoinDaCo.ToString() != "0")// Nếu trong ví có lớn hơn 0 đồng thì cộng tiếp
                        {
                            LichSuRutTien obj = new LichSuRutTien();
                            obj.IDThanhVien = int.Parse(MoreAll.MoreAll.GetCookies("MembersID"));
                            obj.TongTienTrongVi = "";// iitem.TongTienCongLai;
                            obj.SoTienCanRut = txtsotiencanrut;
                            obj.SoCoin = ConglaiCoin.ToString();
                            obj.TenNganHang = txttennganhang;
                            obj.HoVaTen = txthovaten;
                            obj.SoTaiKHoan = txtsotaikhoan;
                            obj.ChiNhanh = txtchinhanh;
                            obj.NoiDungChuyenTien = txtnoidungchuyentien;
                            obj.GhiChu = "";
                            obj.TrangThai = 0;
                            obj.NgayTao = DateTime.Now;
                            obj.NgayDuyet = "";
                            obj.NguoiDuyet = "";
                            db.LichSuRutTiens.InsertOnSubmit(obj);
                            db.SubmitChanges();

                            CongTienDaRut(MoreAll.MoreAll.GetCookies("MembersID"), TongTienCanRutCoin.ToString());

                            ViewBag.ltmsg += "<div class=\"thongbaos\">Bạn đã gửi yêu cầu rút tiền thành công.</div> ";
                            ViewBag.ltmsg += "<div class=\"thongbaos\">Số tiền đã rút :" + txtsotiencanrut + " điểm</div>";
                            ViewBag.ThongBao += ("<script type=\"text/javascript\">alert('Bạn đã gửi yêu cầu rút tiền thành công..');window.location.href='/wallet.html'; </script>");

                            // Sent Mail
                            string content = System.IO.File.ReadAllText(Server.MapPath("~/Views/SentMail/RutTien.html"));
                            content = content.Replace("{{CustomerName}}", txthovaten);
                            content = content.Replace("{{Phone}}", iitem.DienThoai);
                            content = content.Replace("{{Email}}", iitem.Email);
                            content = content.Replace("{{Address}}", iitem.DiaChi);
                            content = content.Replace("{{Total}}", txtsotiencanrut);

                            content = content.Replace("{{Tennganhang}}", txttennganhang);
                            content = content.Replace("{{Sotaikhoan}}", txtsotaikhoan);
                            content = content.Replace("{{Chinhanh}}", txtchinhanh);
                            content = content.Replace("{{Noidung}}", txtnoidungchuyentien);
                            // content = content.Replace("{{Ghichu}}", txtghichu.Text);

                            //emailnhanthongbaorutien
                            try
                            {
                                var EmailContTy = Commond.Setting("Emailden");
                                // var emailnhanthongbaorutien = Commond.Setting("emailnhanthongbaorutien");
                                if (!EmailContTy.Equals(""))
                                    new MailHelper().SendMail(EmailContTy, "Thành viên " + txthovaten + " rút tiền trên hệ thống", content);
                                //if (!emailnhanthongbaorutien.Equals(""))
                                // new MailHelper().SendMail(emailnhanthongbaorutien, "Thành viên " + txthovaten.Text + " rút tiền trên hệ thống V-Paris", content);
                            }
                            catch (Exception)
                            { }

                            // ShowInfo();
                        }
                    }
                    else
                    {
                        ViewBag.ltmsg = "Số tiền không đủ để thanh toán ";
                        return View();
                    }
                }
                #endregion
            }
            return View();
        }
        void CongTienDaRut(string IDThanhVien, string TongRut)
        {
            #region Cộng điểm theo hoa hồng
            List<Entity.Member> iitem = SMember.Name_Text("select * from Members where ID=" + IDThanhVien.ToString() + "");
            if (iitem != null)
            {
                double TongSoCoinDaCo = Convert.ToDouble(iitem[0].TongTienDaRut);
                double TongRuts = Convert.ToDouble(TongRut);
                double Conglai = 0;
                Conglai = ((TongSoCoinDaCo) + (TongRuts));
                SMember.Name_Text("update Members set TongTienDaRut=" + Conglai.ToString() + "  where ID=" + iitem[0].ID.ToString() + "");
            }
            #endregion
        }

        #endregion

        #region MLichSuThanhToan
        public ActionResult MLichSuThanhToan()
        {
            if (MoreAll.MoreAll.GetCookies("MembersID").ToString() == "")
            {
                return Redirect("/dang-nhap.html?ReturnUrl=" + Request.RawUrl.ToString() + "");
            }
            if (MoreAll.MoreAll.GetCookies("MembersID") != "")
            {
                string TuNgay = "";
                string DenNgay = "";
                string loc = "";
                if ((Request.QueryString["TuNgay"] != null) && (Request.QueryString["TuNgay"] != ""))
                {
                    TuNgay = Request.QueryString["TuNgay"].Trim();
                    loc += "&TuNgay=" + TuNgay + "";
                }
                if ((Request.QueryString["DenNgay"] != null) && (Request.QueryString["DenNgay"] != ""))
                {
                    DenNgay = Request.QueryString["DenNgay"].Trim();
                    loc += "&DenNgay=" + DenNgay + "";
                }
                string sql = "";
                if (TuNgay != "" && DenNgay != "")
                {
                    sql += " AND NgayTao IS NOT NULL AND ((DATEADD(dd,-31,NgayTao)>='" + Commond.FormatDate(Commond.ConvertStringToDate(TuNgay, "dd/MM/yyyy").Date) + " 00:00:00.000' OR NgayTao>='" + Commond.FormatDate(Commond.ConvertStringToDate(TuNgay, "dd/MM/yyyy").Date) + " 00:00:00.000') AND NgayTao <='" + Commond.FormatDate(Commond.ConvertStringToDate(DenNgay, "dd/MM/yyyy").Date) + " 23:59:59.999')";
                }
                else if (TuNgay == "" && DenNgay != "")
                {
                    sql += " AND NgayTao IS NOT NULL AND NgayTao <='" + Commond.FormatDate(Commond.ConvertStringToDate(DenNgay, "dd/MM/yyyy").Date) + " 23:59:59.999'";
                }
                else if (TuNgay != "" && DenNgay == "")
                {
                    sql += " AND NgayTao IS NOT NULL AND (DATEADD(dd,-31,NgayTao)>='" + Commond.FormatDate(Commond.ConvertStringToDate(TuNgay, "dd/MM/yyyy").Date) + " 00:00:00.000' OR NgayTao>='" + Commond.FormatDate(Commond.ConvertStringToDate(TuNgay, "dd/MM/yyyy").Date) + " 00:00:00.000')";
                }
                sql += " and IDThanhVien =" + MoreAll.MoreAll.GetCookies("MembersID") + " ";

                int Tongsobanghi = 0;
                Int16 pages = 1;
                int Tongsotrang = int.Parse("20");
                if ((Request.QueryString["page"] != null) && (Request.QueryString["page"] != ""))
                {
                    pages = Convert.ToInt16(Request.QueryString["page"].Trim());
                }
                List<LichSuRutTien> iitem = db.ExecuteQuery<LichSuRutTien>(@"SELECT * FROM LichSuRutTien where 1=1 " + sql + " order by NgayTao desc").ToList();
                if (iitem.Count() > 0)
                {
                    Tongsobanghi = iitem.Count();
                }
                int PageIndex = (pages - 1);
                int Tongpage = Tongsotrang;
                int StartRecord = PageIndex * Tongpage;
                int EndRecord = StartRecord + Tongpage + 1;
                List<LichSuRutTien> dt = db.ExecuteQuery<LichSuRutTien>(@"SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY NgayTao DESC) AS rowindex ,*  FROM  LichSuRutTien  where 1=1 " + sql + " ) AS A WHERE  ( A.rowindex >  " + StartRecord.ToString() + " AND A.rowindex < " + EndRecord + ")").ToList();
                if (dt.Count >= 1)
                {
                    double Tien = 0.0;
                    for (int i = 0; i < dt.Count; i++)
                    {
                        Tien += Convert.ToDouble(dt[i].SoTienCanRut.ToString());
                    }
                    ViewBag.Show = dt;
                    ViewBag.ltCoin = AllQuery.MorePro.FormatMoney(Tien.ToString());
                }

                if (Tongsobanghi % Tongsotrang > 0)
                {
                    Tongsobanghi = (Tongsobanghi / Tongsotrang) + 1;
                }
                else
                {
                    Tongsobanghi = Tongsobanghi / Tongsotrang;
                }
                ViewBag.Phantrang = Commond.Phantrang_loc("/lich-su-thanh-toan.html", "&TuNgay=" + TuNgay + "&DenNgay=" + DenNgay + "", Tongsobanghi, pages);
                ViewBag.TuNgays = TuNgay;
                ViewBag.DenNgays = DenNgay;
            }
            return View();
        }
        #endregion

        #region Vidiem
        public ActionResult Vidiem()
        {
            if (MoreAll.MoreAll.GetCookies("MembersID").ToString() == "")
            {
                return Redirect("/dang-nhap.html?ReturnUrl=" + Request.RawUrl.ToString() + "");
            }
            if (MoreAll.MoreAll.GetCookies("MembersID") != "")
            {
                ShowInfo();
            }
            return View();
        }
        private void ShowInfo()
        {
            string ssl = "http://";
            if (Commond.Setting("SSL").Equals("1"))
            {
                ssl = "https://";
            }

            if (MoreAll.MoreAll.GetCookies("Members") != "")
            {
                Member table = db.Members.SingleOrDefault(p => p.ID == int.Parse(MoreAll.MoreAll.GetCookies("MembersID").ToString()));
                if (table != null)
                {
                    ChiaHoaHong.CapNhatTrangThai(table.ID.ToString());
                    if (table.TienHoaHong.ToString() == "0")
                    {
                        ViewBag.lttongtien = "0";
                    }
                    else
                    {
                        ViewBag.lttongtien = AllQuery.MorePro.Detail_Price(table.TienHoaHong.ToString());
                    }

                    if (table.TongTienDaRut.ToString() == "0")
                    {
                        ViewBag.lttongtiendarut = "0";
                    }
                    else
                    {
                        ViewBag.lttongtiendarut = AllQuery.MorePro.Detail_Price(table.TongTienDaRut.ToString());
                    }

                    try
                    {
                        var tongthanhvien = db.TongThanhVienBenDuoi(int.Parse(table.ID.ToString())).ToList();
                        if (tongthanhvien.Count > 0)
                        {
                            ViewBag.lttongthanhvien = tongthanhvien[0].COUNT.ToString();
                        }
                        else
                        {
                            ViewBag.lttongthanhvien = "0";
                        }
                    }
                    catch (Exception)
                    { }

                    ViewBag.ltcapbac = Commond.ShowCapbacView(table.CapBac.ToString());
                    //   ViewBag.ltttongF1 = table.F1.ToString();
                    ViewBag.txtlinkgioithieu = "https://lienhiephoptac.vn/dang-ky.html?info=" + table.DienThoai.ToString() + "";
                }
            }
        }
        #endregion

        #region MHoaHong
        public ActionResult MHoaHong()
        {
            string Category = "0";
            string TuNgay = "";
            string DenNgay = "";
            string loc = "";
            if ((Request.QueryString["Category"] != null) && (Request.QueryString["Category"] != ""))
            {
                Category = Request.QueryString["Category"].Trim();
                loc += "&Category=" + Category + "";
            }
            if ((Request.QueryString["TuNgay"] != null) && (Request.QueryString["TuNgay"] != ""))
            {
                TuNgay = Request.QueryString["TuNgay"].Trim();
                loc += "&TuNgay=" + TuNgay + "";
            }
            if ((Request.QueryString["DenNgay"] != null) && (Request.QueryString["DenNgay"] != ""))
            {
                DenNgay = Request.QueryString["DenNgay"].Trim();
                loc += "&DenNgay=" + DenNgay + "";
            }

            if (MoreAll.MoreAll.GetCookies("Members") != "")
            {
                //DateTime fDate;
                //DateTime tDate;
                string sql = "";

                //if (Commond.Check(TuNgay))
                //    fDate = Commond.ConvertStringToDate(TuNgay, "dd/MM/yyyy");
                //if (Commond.Check(DenNgay))
                //    tDate = Commond.ConvertStringToDate(DenNgay, "dd/MM/yyyy");

                if (TuNgay != "" && DenNgay != "")
                {
                    sql += " AND NgayTao IS NOT NULL AND ((DATEADD(dd,-31,NgayTao)>='" + Commond.FormatDate(Commond.ConvertStringToDate(TuNgay, "dd/MM/yyyy").Date) + " 00:00:00.000' OR NgayTao>='" + Commond.FormatDate(Commond.ConvertStringToDate(TuNgay, "dd/MM/yyyy").Date) + " 00:00:00.000') AND NgayTao <='" + Commond.FormatDate(Commond.ConvertStringToDate(DenNgay, "dd/MM/yyyy").Date) + " 23:59:59.999')";
                }
                else if (TuNgay == "" && DenNgay != "")
                {
                    sql += " AND NgayTao IS NOT NULL AND NgayTao <='" + Commond.FormatDate(Commond.ConvertStringToDate(DenNgay, "dd/MM/yyyy").Date) + " 23:59:59.999'";
                }
                else if (TuNgay != "" && DenNgay == "")
                {
                    sql += " AND NgayTao IS NOT NULL AND (DATEADD(dd,-31,NgayTao)>='" + Commond.FormatDate(Commond.ConvertStringToDate(TuNgay, "dd/MM/yyyy").Date) + " 00:00:00.000' OR NgayTao>='" + Commond.FormatDate(Commond.ConvertStringToDate(TuNgay, "dd/MM/yyyy").Date) + " 00:00:00.000')";
                }
                if (Category != "0")
                {
                    sql += " and KieuHoaHong in (" + Category + ")";
                }
                sql += " and IDThanhVienHuong =" + MoreAll.MoreAll.GetCookies("MembersID") + " ";
                int Tongsobanghi = 0;
                Int16 pages = 1;
                int Tongsotrang = int.Parse("20");
                if ((Request.QueryString["page"] != null) && (Request.QueryString["page"] != ""))
                {
                    pages = Convert.ToInt16(Request.QueryString["page"].Trim());
                }
                List<HoaHong> iitem = db.ExecuteQuery<HoaHong>(@"SELECT * FROM HoaHong where 1=1 " + sql + " order by NgayTao desc").ToList();
                if (iitem.Count() > 0)
                {
                    //double coin = 0.0;
                    //for (int i = 0; i < iitem.Count; i++)
                    //{
                    //    coin += Convert.ToDouble(iitem[i].TienDonHang.ToString());
                    //}
                    //lttongtien.Text = AllQuery.MorePro.FormatMoney(coin.ToString());
                    Tongsobanghi = iitem.Count();
                }
                int PageIndex = (pages - 1);
                int Tongpage = Tongsotrang;
                int StartRecord = PageIndex * Tongpage;
                int EndRecord = StartRecord + Tongpage + 1;
                List<HoaHong> dt = db.ExecuteQuery<HoaHong>(@"SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY NgayTao DESC) AS rowindex ,*  FROM  HoaHong  where 1=1 " + sql + " ) AS A WHERE  ( A.rowindex >  " + StartRecord.ToString() + " AND A.rowindex < " + EndRecord + ")").ToList();
                if (dt.Count >= 1)
                {
                    double Tien = 0.0;
                    for (int i = 0; i < dt.Count; i++)
                    {
                        Tien += Convert.ToDouble(dt[i].SoTienDuocHuong.ToString());
                    }
                    ViewBag.Show = dt;
                    ViewBag.ltCoin = AllQuery.MorePro.FormatMoney(Tien.ToString());
                }

                if (Tongsobanghi % Tongsotrang > 0)
                {
                    Tongsobanghi = (Tongsobanghi / Tongsotrang) + 1;
                }
                else
                {
                    Tongsobanghi = Tongsobanghi / Tongsotrang;
                }
                ViewBag.Phantrang = Commond.Phantrang_loc("/lich-su-hoa-hong.html", "&Category=" + Category + "&TuNgay=" + TuNgay + "&DenNgay=" + DenNgay + "", Tongsobanghi, pages);

            }
            else
            {
                Response.Redirect("/dang-nhap.html?ReturnUrl=" + Request.RawUrl.ToString() + "");
            }
            ViewBag.Categorys = Category;
            ViewBag.TuNgays = TuNgay;
            ViewBag.DenNgays = DenNgay;
            return View();
        }
        #endregion
    }
}