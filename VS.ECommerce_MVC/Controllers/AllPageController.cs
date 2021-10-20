using MoreAll;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace VS.ECommerce_MVC.Controllers
{
    public class AllPageController : Controller
    {
        private string language = Captionlanguage.SetLanguage();
        DatalinqDataContext db = new DatalinqDataContext();
        public ActionResult Register_Email()
        {
            return View();
        }

        [HttpPost]
        public string Register_Email(string VEmail)
        {
            if (ModelState.IsValid)
            {
                if (VEmail.Length < 0)
                {
                    return "Kiểm tra dữ liệu nhập vào";
                }
                else if (!RegularExpressions.IsValidEmail(VEmail))
                {
                    return "Kiểm tra dữ liệu nhập vào";
                }
                else if (SMarketing.Name_Text("select * from Marketing where Email='" + VEmail.Trim().ToLower() + "'").Count > 0)
                {
                    return "Email này đã tồn tại trong hệ thống";
                }
                else
                {
                    #region Marketing
                    Entity.Marketing ob = new Entity.Marketing();
                    ob.Name = "Kh\x00e1ch h\x00e0ng nhận th\x00f4ng b\x00e1o qua email";
                    ob.Email = VEmail;
                    ob.Phone = "";
                    ob.Address = "";
                    ob.dcreatedate = DateTime.Now;
                    ob.istatus = 0;
                    if (SMarketing.INSERT(ob) == true)
                    {
                        return "Đăng ký nhận tin qua Email thành công";
                    }
                    #endregion
                }
            }
            return "";
        }


        [HttpPost]
        public string Register_Phone(string VPhone)
        {
            if (ModelState.IsValid)
            {
                if (VPhone.Length < 0)
                {
                    return "Kiểm tra dữ liệu nhập vào";
                }
                else if (SMarketing.Name_Text("select * from Marketing where Phone='" + VPhone.Trim().ToLower() + "'").Count > 0)
                {
                    return "Điện thoại này đã tồn tại trong hệ thống";
                }
                else
                {
                    #region Marketing
                    Entity.Marketing ob = new Entity.Marketing();
                    ob.Name = "Kh\x00e1ch h\x00e0ng nhận th\x00f4ng b\x00e1o qua điện thoại";
                    ob.Email = "";
                    ob.Phone = VPhone;
                    ob.Address = "";
                    ob.dcreatedate = DateTime.Now;
                    ob.istatus = 0;
                    if (SMarketing.INSERT(ob) == true)
                    {
                        return "Đăng ký nhận tin qua điện thoại thành công";
                    }
                    #endregion
                }
            }
            return "";
        }


        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult Box_Facebook()
        {
            ViewBag.Show = " <iframe src=\"https://www.facebook.com/plugins/likebox.php?href=" + Commond.Setting("Facebook") + "&amp;width=" + Commond.Setting("txtfbwidth") + "&amp;height=" + Commond.Setting("txtfbheight") + "&amp;show_faces=true&amp;colorscheme=light&amp;stream=false&amp;show_border=true&amp;header=true\" scrolling=\"no\" frameborder=\"0\" style=\"border: none; overflow: hidden; width:" + Commond.Setting("txtfbwidth") + "px; height:" + Commond.Setting("txtfbheight") + "px; margin-bottom: 8px;\" allowtransparency=\"true\"></iframe>";
            return PartialView();
        }
        public ActionResult Box_TimKiem_Top()
        {
            ViewBag.ddlcountry = Bind_ddlCountry();
            ViewBag.NhaDatBan = NhaDatBan();
            return PartialView();
        }

        [HttpGet]
        public string NhaDatBan()
        {
            string str = "";
            str += "<option value=\"0\">Chọn loại nhà đất</option>";
            List<Menu> dt = db.Menus.Where(p => p.Parent_ID.ToString() == "792" && p.capp == "PR").OrderBy(s => s.Orders).ToList();
            for (int i = 0; i < dt.Count; i++)
            {
                str += "<option value=\"" + dt[i].ID.ToString() + "\">" + dt[i].Name.ToString() + "</option>";
            }
            return str;
        }

        [HttpGet]
        public string NhaChoThue()
        {
            string str = "";
            str += "<option value=\"0\">Chọn loại nhà đất</option>";
            List<Menu> dt = db.Menus.Where(p => p.Parent_ID.ToString() == "794" && p.capp == "PR").OrderByDescending(s => s.Orders).ToList();
            for (int i = 0; i < dt.Count; i++)
            {
                str += "<option value=\"" + dt[i].ID.ToString() + "\">" + dt[i].Name.ToString() + "</option>";
            }
            return str;
        }
        [HttpGet]
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

        protected string PhuongXa(int CountryId)
        {
            string str = "";
            str += "<option value=\"0\">Chọn phường/xã</option>";
            List<Tinhthanh> dt = db.Tinhthanhs.Where(p => p.Parent_ID == CountryId && p.capp == "TT").OrderBy(s => s.Orders).ToList();
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
            return PhuongXa(CountryId);
        }
        #endregion
    }
}