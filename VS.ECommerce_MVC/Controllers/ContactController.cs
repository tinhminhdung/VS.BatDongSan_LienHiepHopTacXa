using MoreAll;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VS.ECommerce_MVC.Controllers
{
    public class ContactController : BaseController
    {
        private string language = Captionlanguage.SetLanguage();

        [HttpGet]
        public ActionResult Index()
        {
            //ViewBag.ShowDropdowlist = LoadDropdowlist();// show lên html Dropdowlist
            return View();
        }

        #region Dropdowlist đa cấp
        protected string LoadDropdowlist()
        {
            string str = "";
            string strs = "0";
            str += "<select id=\"ddlcategory\" name=\"ddlcategory\">";
            str += "<option value=\"0\">== Chọn chuyên mục ==</option>";
            List<Entity.Menu> dt = SMenu.LOAD_CATESPARENT_ID(More.PR, "VIE", "-1", "1");
            for (int i = 0; i < dt.Count; i++)
            {
                if (dt[i].Parent_ID.ToString() == "-1")
                {
                    str += "<option value=\"" + dt[i].ID.ToString() + "\">" + dt[i].Name.ToString() + "</option>";
                    strs = strs + 1;
                    str += Categories(dt[i].ID.ToString(), strs, "===");
                }
            }
            str += "</select>";
            return str;
        }
        protected string Categories(string id, string strs, string j)
        {
            string str = "";
            List<SelectListItem> cateList = new List<SelectListItem>();
            List<Entity.Menu> dt = SMenu.LOAD_CATESPARENT_ID(More.PR, "VIE", id, "1");
            for (int i = 0; i < dt.Count; i++)
            {
                if (dt[i].Parent_ID.ToString() == id)
                {
                    str += "<option value=\"" + dt[i].ID.ToString() + "\">" + j + dt[i].Name.ToString() + "</option>";
                    strs = strs + 1;
                    str += Categories(dt[i].ID.ToString(), strs, j + j);
                }
            }
            return str.ToString();
        }
        #endregion

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(FormCollection collect)
        {
            // string ddllist = collect["ddlcategory"];// lấy ra ID của Dropdowlist
            if (ModelState.IsValid)
            {
                if (collect["txtHoTen"] == "")
                {
                    ViewBag.ThongBao = AlertMessage(Commond.label("lienhes1"), "warning");
                    // SetAlert("Vui lòng điền đầy đủ họ và tên", "warning");
                }
                else if (collect["txtphone"] == "")
                {
                    // SetAlert("Vui lòng điền điện thoại", "warning");
                    ViewBag.ThongBao = AlertMessage(Commond.label("lienhes2"), "warning");
                }
                else if (MoreAll.RegularExpressions.phone(collect["txtphone"]))
                {
                    // SetAlert("Điện thoại không đúng định dạng", "warning");
                    ViewBag.ThongBao = AlertMessage(Commond.label("lienhes3"), "warning");
                }
                else if (collect["txtaddress"] == "")
                {
                    // SetAlert("Vui lòng điền địa chỉ", "warning");
                    ViewBag.ThongBao = AlertMessage(Commond.label("lienhes4"), "warning");
                }
                else if (!MoreAll.RegularExpressions.IsValidEmail(collect["txtemail"]))
                {
                    // SetAlert("Email không đúng định dạng", "warning");
                    ViewBag.ThongBao = AlertMessage(Commond.label("lienhes5"), "warning");
                }
                else if (collect["txtemail"] == "")
                {
                    //  SetAlert("Vui lòng điền email", "warning");
                    ViewBag.ThongBao = AlertMessage(Commond.label("lienhes6"), "warning");
                }
                else
                {
                    System.Threading.Thread.Sleep(1000);
                    #region Contacts
                    Entity.Contacts obj = new Entity.Contacts();
                    obj.vtitle = collect["txttieude"];
                    obj.vname = collect["txtHoTen"];
                    obj.vaddress = collect["txtaddress"];
                    obj.vphone = collect["txtphone"];
                    obj.vemail = collect["txtemail"];
                    obj.vcontent = collect["txtcontent"];
                    obj.dcreatedate = DateTime.Now;
                    obj.lang = "VIE";
                    obj.istatus = 0;
                    if (SContacts.INSERT(obj) == true)
                    {
                        //SetAlert("Gửi liên hệ thành công", "success");
                        ViewBag.ThongBao = AlertMessage(Commond.label("lienhes7"), "success");
//TempData["ThongBao"] 
                        #region Senmail
                        if (!Commond.Setting("Emailden").Equals(""))
                            Senmail(collect["txtHoTen"], collect["txtaddress"], collect["txtphone"], collect["txtemail"], collect["txttieude"], collect["txtcontent"]);
                        #endregion
                    }
                    #endregion
                }
            }
			//  return RedirectToAction("Index", "Home");
            return View();
      
        }
        void Senmail(string txtHoTen, string txtaddress, string txtphone, string txtemail, string txttieude, string txtcontent)
        {
            try
            {
                string title = "";
                System.Text.StringBuilder strb = new System.Text.StringBuilder();
                strb.AppendLine("<div style=\"width:100%; padding:10px; line-height:22px;\"> ");
                strb.AppendLine("<div style=\"font-size:18px; font-weight:bold; text-align:center; color:#F00; text-decoration:none;text-transform:uppercase;\">Thông tin liên hệ của khách hàng</div> ");
                strb.AppendLine("<div style=\"font-weight:bold; color:#666; padding-top:10px; text-align:center;text-decoration:none;\"> Website: " + MoreAll.MoreAll.RequestUrl(Request.Url.Authority) + "/</div>");
                strb.AppendLine("<div style=\" color:#666; padding-top:10px\"> ");
                strb.AppendLine("<div style=\"font-size:14px;font-weight:bold; padding-bottom:5px;text-transform:uppercase; text-decoration:underline;color:#fe0505\">Thông tin khách hàng</div> ");
                strb.AppendLine(" <table cellpadding=\"0\" cellspacing=\"0\" style=\"width:100%\"> ");
                strb.AppendLine(" <tr> ");
                strb.AppendLine(" <td style=\"border-bottom:dotted 1px #d6d6d6; height:22px; width:20%\">Họ và tên:</td> ");
                strb.AppendLine(" <td style=\"border-bottom:dotted 1px #d6d6d6; height:22px;color:#fe0505\">" + txtHoTen + "</td> ");
                strb.AppendLine("</tr> ");
                strb.AppendLine("<tr> ");
                strb.AppendLine(" <td style=\"border-bottom:dotted 1px #d6d6d6; height:22px;\">Địa chỉ:</td>");
                strb.AppendLine(" <td style=\"border-bottom:dotted 1px #d6d6d6; height:22px;\">" + txtaddress + "</td>");
                strb.AppendLine("</tr>");
                strb.AppendLine("<tr>");
                strb.AppendLine(" <td style=\"border-bottom:dotted 1px #d6d6d6; height:22px;\">Điện thoại:</td>");
                strb.AppendLine("<td style=\"border-bottom:dotted 1px #d6d6d6; height:22px;\">" + txtphone + "</td>");
                strb.AppendLine("</tr>");
                strb.AppendLine(" <tr>");
                strb.AppendLine("  <td style=\"border-bottom:dotted 1px #d6d6d6;height:22px;\">Email:</td>");
                strb.AppendLine(" <td style=\"border-bottom:dotted 1px #d6d6d6; height:22px;\">" + txtemail + "</td>");
                strb.AppendLine("</tr>");
                strb.AppendLine("<tr>");
                strb.AppendLine("<td style=\"border-bottom:dotted 1px #d6d6d6; height:22px;\">Tiêu đề:</td>");
                strb.AppendLine("<td style=\"border-bottom:dotted 1px #d6d6d6; height:22px;\"> " + txttieude + "</td>");
                strb.AppendLine("</tr>");
                strb.AppendLine("<tr>");
                strb.AppendLine("<td style=\"border-bottom:dotted 1px #d6d6d6; height:22px;\">Ngày Gửi:</td>");
                strb.AppendLine("<td style=\"border-bottom:dotted 1px #d6d6d6; height:22px;\"> " + DateTime.Now.AddYears(3).ToString("MM/dd/yyyy HH:mm:ss") + "</td>");
                strb.AppendLine("</tr>");
                strb.AppendLine("<tr>");
                strb.AppendLine("<td style=\"border-bottom:dotted 1px #d6d6d6; height:22px;\">Nội dung:</td>");
                strb.AppendLine("<td style=\"border-bottom:dotted 1px #d6d6d6; height:22px;\"> " + txtcontent + "</td>");
                strb.AppendLine("</tr>");
                strb.AppendLine("</table>");
                strb.AppendLine("</div>");
                strb.AppendLine("</div>");
                string email = Email.email();
                string password = Email.password();
                int port = Convert.ToInt32(Email.port());
                string host = Email.host();
                MailUtilities.SendMail("Liên hệ từ " + txtHoTen + "", email, password, Commond.Setting("Emailden"), host, port, "Thông tin liên hệ của khách hàng từ Website: " + MoreAll.MoreAll.RequestUrl(Request.Url.Authority) + "", strb.ToString());
                //MailUtilities.SendMail("Liên hệ từ " + txtHoTen.Text.Trim() + "", email, password, this.txtemail.Text.Trim(), host, port, "Thông tin liên hệ của khách hàng từ Website: " + MoreAll.MoreAll.RequestUrl(Request.Url.Authority) + "", strb.ToString());
            }
            catch (Exception)
            { }
        }
    }
}