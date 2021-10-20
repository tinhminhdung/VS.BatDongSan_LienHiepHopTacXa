using GHTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using AjaxPro;
using System.Text;
using VS.ECommerce_MVC.Models;
using Services;

namespace VS.ECommerce_MVC.Controllers
{
    public class API_ProdutcsController : Controller
    {
        public class ViewProduct
        {
            public int icid { get; set; }
            public string Brief { get; set; }
            public string Code { get; set; }
            public string Create_Date { get; set; }
            public int ID_Hang { get; set; }
            public string Images { get; set; }
            public string ImagesSmall { get; set; }
            public int ipid { get; set; }
            public string Name { get; set; }
            public string Price { get; set; }
            public string Alt { get; set; }
            public string OldPrice { get; set; }
            public string TangName { get; set; }
        }
        public ActionResult Index()
        {
            List<Entity.Products> list = new List<Entity.Products>();
            HttpClient client = new HttpClient();
            var result = client.GetAsync("http://localhost:63136/api/product/GetById/37").Result;
            if (result.IsSuccessStatusCode)
            {
                list = result.Content.ReadAsAsync<List<Entity.Products>>().Result;
            }
            return View(list);
        }
        public ActionResult All()
        {
            //Có thể Lấy luôn Entity.Products để chạy nếu cùng 1 dự án code
            //Khi đưa sang dự án khác để kết nối API thì phải viết lại Entity cho nó như là: ViewProduct
            //List<Entity.Products> list = new List<Entity.Products>();
            List<ViewProduct> list = new List<ViewProduct>();
            HttpClient client = new HttpClient();
            var result = client.GetAsync("http://localhost:63136/api/product/GetAll").Result;
            if (result.IsSuccessStatusCode)
            {
                //Có thể Lấy luôn Entity.Products để chạy nếu cùng 1 dự án code
                //Khi đưa sang dự án khác để kết nối API thì phải viết lại Entity cho nó như là: ViewProduct
                // list = result.Content.ReadAsAsync<List<Entity.Products>>().Result;
                list = result.Content.ReadAsAsync<List<ViewProduct>>().Result;
            }
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

      


    }
}