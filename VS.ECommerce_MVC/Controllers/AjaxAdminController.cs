using Entity;
using Framwork;
using MoreAll;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VS.ECommerce_MVC.Controllers
{
    public class AjaxAdminController : Controller
    {
        private string language = Captionlanguage.SetLanguage();
        DatalinqDataContext db = new DatalinqDataContext();

        [HttpPost]
        public JsonResult ChangeThuPhi(long id)
        {
            bool TrangThai;
            DatalinqDataContext db = new DatalinqDataContext();
            var menu = db.Members.SingleOrDefault(p => p.ID == id);

            if (menu.ThuPhi == 1)
            {
                menu.ThuPhi = 0;
                TrangThai = false;
            }
            else
            {
                menu.ThuPhi = 1;
                TrangThai = true;
            }
            db.SubmitChanges();


            var result = TrangThai;
            return Json(new
            {
                status = result
            });
        }
        // Menu
        #region Menu
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            RemoveCache.Menu();
            bool TrangThai;
            DatalinqDataContext db = new DatalinqDataContext();
            var menu = db.Menus.SingleOrDefault(p => p.ID == id);
            #region RemoveCache
            if (menu.capp == More.NS)
            {
                RemoveCache.News();
            }
            if (menu.capp == More.PR)
            {
                RemoveCache.Products();
            }
            if (menu.capp == More.VD)
            {
                RemoveCache.Video();
            }
            if (menu.capp == More.AB)
            {
                RemoveCache.Album();
            }
            #endregion
            if (menu.Status == 1)
            {
                menu.Status = 0;
                TrangThai = false;
            }
            else
            {
                menu.Status = 1;
                TrangThai = true;
            }
            db.SubmitChanges();


            var result = TrangThai;
            return Json(new
            {
                status = result
            });
        }

        [HttpPost]
        public JsonResult ChangeHome(long id)
        {
            RemoveCache.Menu();
            bool TrangThai;
            DatalinqDataContext db = new DatalinqDataContext();
            var menu = db.Menus.SingleOrDefault(p => p.ID == id);
            #region RemoveCache
            if (menu.capp == More.NS)
            {
                RemoveCache.News();
            }
            if (menu.capp == More.PR)
            {
                RemoveCache.Products();
            }
            if (menu.capp == More.VD)
            {
                RemoveCache.Video();
            }
            if (menu.capp == More.AB)
            {
                RemoveCache.Album();
            }
            #endregion
            if (menu.page_Home == 1)
            {
                menu.page_Home = 0;
                TrangThai = false;
            }
            else
            {
                menu.page_Home = 1;
                TrangThai = true;
            }
            db.SubmitChanges();
            var result = TrangThai;
            return Json(new
            {
                status = result
            });
        }
        #endregion

        // Products
        #region Products

        [HttpPost]
        public JsonResult ChangeProStatus(long id)
        {
            RemoveCache.Menu();
            RemoveCache.Products();

            bool TrangThai;
            DatalinqDataContext db = new DatalinqDataContext();
            var dt = db.products.SingleOrDefault(p => p.ipid == id);
            if (dt.Status == 1)
            {
                dt.Status = 0;
                TrangThai = false;
            }
            else
            {
                dt.Status = 1;
                TrangThai = true;
            }
            db.SubmitChanges();
            SProducts.Name_Text("update products set ThanhVienDuyetBai='" + MoreAll.MoreAll.GetCookies("UName").ToString() + "' where ipid=" + id + "");

            var result = TrangThai;
            return Json(new
            {
                status = result
            });
        }
        [HttpPost]
        public JsonResult ChangeProHome(long id)
        {
            RemoveCache.Menu();
            RemoveCache.Products();

            bool TrangThai;
            DatalinqDataContext db = new DatalinqDataContext();
            var dt = db.products.SingleOrDefault(p => p.ipid == id);
            if (dt.Home == 1)
            {
                dt.Home = 0;
                TrangThai = false;
            }
            else
            {
                dt.Home = 1;
                TrangThai = true;
            }
            db.SubmitChanges();
            var result = TrangThai;
            return Json(new
            {
                status = result
            });
        }
        [HttpPost]
        public JsonResult ChangeProNews(long id)
        {
            RemoveCache.Menu();
            RemoveCache.Products();

            bool TrangThai;
            DatalinqDataContext db = new DatalinqDataContext();
            var dt = db.products.SingleOrDefault(p => p.ipid == id);
            if (dt.News == 1)
            {
                dt.News = 0;
                TrangThai = false;
            }
            else
            {
                dt.News = 1;
                TrangThai = true;
            }
            db.SubmitChanges();
            var result = TrangThai;
            return Json(new
            {
                status = result
            });
        }
        [HttpPost]
        public JsonResult ChangeProCheck_01(long id)
        {
            RemoveCache.Menu();
            RemoveCache.Products();

            bool TrangThai;
            DatalinqDataContext db = new DatalinqDataContext();
            var dt = db.products.SingleOrDefault(p => p.ipid == id);
            if (dt.Check_01 == 1)
            {
                dt.Check_01 = 0;
                TrangThai = false;
            }
            else
            {
                dt.Check_01 = 1;
                TrangThai = true;
            }
            db.SubmitChanges();
            var result = TrangThai;
            return Json(new
            {
                status = result
            });
        }
        [HttpPost]
        public JsonResult ChangeProCheck_02(long id)
        {
            RemoveCache.Menu();
            RemoveCache.Products();

            bool TrangThai;
            DatalinqDataContext db = new DatalinqDataContext();
            var dt = db.products.SingleOrDefault(p => p.ipid == id);
            if (dt.Check_02 == 1)
            {
                dt.Check_02 = 0;
                TrangThai = false;
            }
            else
            {
                dt.Check_02 = 1;
                TrangThai = true;
            }
            db.SubmitChanges();
            var result = TrangThai;
            return Json(new
            {
                status = result
            });
        }
        [HttpPost]
        public JsonResult ChangeProCheck_03(long id)
        {
            RemoveCache.Menu();
            RemoveCache.Products();

            bool TrangThai;
            DatalinqDataContext db = new DatalinqDataContext();
            var dt = db.products.SingleOrDefault(p => p.ipid == id);
            if (dt.Check_03 == 1)
            {
                dt.Check_03 = 0;
                TrangThai = false;
            }
            else
            {
                dt.Check_03 = 1;
                TrangThai = true;
            }
            db.SubmitChanges();
            var result = TrangThai;
            return Json(new
            {
                status = result
            });
        }
        [HttpPost]
        public JsonResult ChangeProCheck_04(long id)
        {
            RemoveCache.Menu();
            RemoveCache.Products();

            bool TrangThai;
            DatalinqDataContext db = new DatalinqDataContext();
            var dt = db.products.SingleOrDefault(p => p.ipid == id);
            if (dt.Check_04 == 1)
            {
                dt.Check_04 = 0;
                TrangThai = false;
            }
            else
            {
                dt.Check_04 = 1;
                TrangThai = true;
            }
            db.SubmitChanges();
            var result = TrangThai;
            return Json(new
            {
                status = result
            });
        }
        [HttpPost]
        public JsonResult ChangeProCheck_05(long id)
        {
            RemoveCache.Menu();
            RemoveCache.Products();

            bool TrangThai;
            DatalinqDataContext db = new DatalinqDataContext();
            var dt = db.products.SingleOrDefault(p => p.ipid == id);
            if (dt.Check_05 == 1)
            {
                dt.Check_05 = 0;
                TrangThai = false;
            }
            else
            {
                dt.Check_05 = 1;
                TrangThai = true;
            }
            db.SubmitChanges();
            var result = TrangThai;
            return Json(new
            {
                status = result
            });
        }
        #endregion

        // News 
        #region News
        [HttpPost]
        public JsonResult ChangeNewsCheckBox1(long id)
        {
            RemoveCache.Menu();
            RemoveCache.News();

            bool TrangThai;
            DatalinqDataContext db = new DatalinqDataContext();
            var menu = db.News.SingleOrDefault(p => p.inid == id);

            if (menu.CheckBox1 == 1)
            {
                menu.CheckBox1 = 0;
                TrangThai = false;
            }
            else
            {
                menu.CheckBox1 = 1;
                TrangThai = true;
            }
            db.SubmitChanges();


            var result = TrangThai;
            return Json(new
            {
                status = result
            });
        }
        [HttpPost]
        public JsonResult ChangeNewsCheckBox2(long id)
        {
            RemoveCache.Menu();
            RemoveCache.News();

            bool TrangThai;
            DatalinqDataContext db = new DatalinqDataContext();
            var menu = db.News.SingleOrDefault(p => p.inid == id);

            if (menu.CheckBox2 == 1)
            {
                menu.CheckBox2 = 0;
                TrangThai = false;
            }
            else
            {
                menu.CheckBox2 = 1;
                TrangThai = true;
            }
            db.SubmitChanges();


            var result = TrangThai;
            return Json(new
            {
                status = result
            });
        }


        [HttpPost]
        public JsonResult ChangeNewsStatus(long id)
        {
            RemoveCache.Menu();
            RemoveCache.News();

            bool TrangThai;
            DatalinqDataContext db = new DatalinqDataContext();
            var menu = db.News.SingleOrDefault(p => p.inid == id);

            if (menu.Status == 1)
            {
                menu.Status = 0;
                TrangThai = false;
            }
            else
            {
                menu.Status = 1;
                TrangThai = true;
            }
            db.SubmitChanges();


            var result = TrangThai;
            return Json(new
            {
                status = result
            });
        }

        [HttpPost]
        public JsonResult ChangeNewsHome(long id)
        {
            RemoveCache.Menu();
            RemoveCache.News();

            bool TrangThai;
            DatalinqDataContext db = new DatalinqDataContext();
            var dt = db.News.SingleOrDefault(p => p.inid == id);
            if (dt.New1 == 1)
            {
                dt.New1 = 0;
                TrangThai = false;
            }
            else
            {
                dt.New1 = 1;
                TrangThai = true;
            }
            db.SubmitChanges();


            var result = TrangThai;
            return Json(new
            {
                status = result
            });
        }
        #endregion

    }
}
