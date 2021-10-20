using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VS.ECommerce_MVC.Models;

namespace VS.ECommerce_MVC.Controllers
{
    public class CodeMauController : Controller
    {
        DatalinqDataContext db = new DatalinqDataContext();
        public ActionResult LienHe()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LienHe(LienHeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Contact obj = new Contact();
                obj.vname = model.vname;
                obj.vemail = model.vemail;
                db.Contacts.InsertOnSubmit(obj);
                db.SubmitChanges();
                ViewData["SuccessMsg"] = "Gửi phản hồi thành công -" + model.vname + " - " + model.vemail + "";
            }
            return View();
        }
	}
}