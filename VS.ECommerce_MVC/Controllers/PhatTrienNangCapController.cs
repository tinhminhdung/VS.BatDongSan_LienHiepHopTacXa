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

namespace VS.ECommerce_MVC.Controllers
{
    //public interface IGHTKPostService
    //{
    //    Task<PriceGhtkResultModel> GetPrice(PriceGhtkRequestModel model);
    //    Task<string> CreateOrder();
    //    Task<string> OrderStatus();
    //    Task<string> CancelOrder();
    //    Task<string> PrintOrder();
    //}

    //public class PhatTrienNangCapController : Controller
    //{
    //    private readonly PhatTienNangCap.ServiceConnect.IPostConnect postService;
    //    public static string Host = "https://dev.ghtk.vn";
    //    //public static string Host = "https://services.giaohangtietkiem.vn";
    //    public static string Token = "3d6C65727cF5A5791E495236d31Be8E64cc7f4ea";

    //    Uri baseAddress = new Uri("http://localhost:55117/api");
    //    HttpClient client;

    //    public PhatTrienNangCapController(
    //        PhatTienNangCap.ServiceConnect.IPostConnect postService)
    //    {
    //        this.postService = postService;
    //    }

    //    //Lấy giá vận chuyển của một đơn hàng
    //    //public async Task<PriceGhtkResultModel> GetPrice(PriceGhtkRequestModel model)
    //    //{

    //    //    var strContent = JsonConvert.SerializeObject(model,
    //    //                   new JsonSerializerSettings
    //    //                   {
    //    //                       ContractResolver = new CamelCasePropertyNamesContractResolver()
    //    //                   });

    //    //    string path = string.Format("/services/shipment/fee?{0}", WebUtility.UrlEncode(strContent));
    //    //    var result = await postService.CallAsync<PriceGhtkResultModel>(Host, path, Token, HttpMethod.Get, null);
    //    //    if (result != null)
    //    //    {
    //    //        if (result.fee != null)
    //    //        {
    //    //            var fee = result.fee.fee;
    //    //            var insurance_fee = result.fee.insurance_fee;
    //    //        }

    //    //    }
    //    //    return result;
    //    //}

     



    //    //public async Task<ActionResult> Index()
    //    //{
    //    //    string value = "9000000";// tiền vnd về sản phẩm
    //    //    string weight = "90000";// trọng lượng 
    //    //    string pick_province = "Hà Nội";//Tên tỉnh/thành phố nơi lấy hàng hóa
    //    //    string pick_district = "Quận Hai Bà Trưng";
    //    //    string province = "Hà Nội";
    //    //    string district = "Quận Cầu Giấy";
    //    //    string address = "P.503 tòa nhà Auu Việt, số 1 Lê Đức Thọ";
    //    //    string tRequest = "https://dev.ghtk.vn/services/shipment/fee?/services/shipment/fee?address=" + address + "&province=" + province + "&district=" + district + "&pick_province=" + pick_province + "&pick_district=" + pick_district + "&weight=" + weight + "&value=" + value + "";
    //    //    //var strContent = JsonConvert.SerializeObject(tRequest,
    //    //    //               new JsonSerializerSettings
    //    //    //               {
    //    //    //                   ContractResolver = new CamelCasePropertyNamesContractResolver()
    //    //    //               });

    //    //    //string path = string.Format("/services/shipment/fee?{0}", WebUtility.UrlEncode(strContent));
    //    //    var result = await postService.CallAsync<PriceGhtkResultModel>(Host, tRequest, Token, HttpMethod.Get, null);
    //    //    if (result != null)
    //    //    {
    //    //        if (result.fee != null)
    //    //        {
    //    //            var fee = result.fee.fee;
    //    //            var insurance_fee = result.fee.insurance_fee;
    //    //        }
    //    //    }
    //    //    // Response.Write(result);
    //    //    ViewBag.Thongbao = "";
    //    //    return View();
    //    //}
    //    public ActionResult Index()
    //    {
    //       // string tRequest, string Token

    //        //using (var client = new HttpClient())
    //        //{
    //        //    client.BaseAddress = new Uri(tRequest);
    //        //    client.DefaultRequestHeaders.Accept.Clear();
    //        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    //        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Token);
    //        //    client.DefaultRequestHeaders.Add("Token", Token);
    //        //    //GET Method
    //        //    HttpResponseMessage response = await client.GetAsync("api/Department/1");
    //        //    if (response.IsSuccessStatusCode)
    //        //    {
    //        //        Department department = await response.Content.ReadAsAsync<Department>();
    //        //        Console.WriteLine("Id:{0}\tName:{1}", department.DepartmentId, department.DepartmentName);
    //        //        Console.WriteLine("No of Employee in Department: {0}", department.Employees.Count);
    //        //    }
    //        //    else
    //        //    {
    //        //        Console.WriteLine("Internal server Error");
    //        //    }
    //        //}

    //        //string value = "9000000";// tiền vnd về sản phẩm
    //        //string weight = "90000";// trọng lượng 
    //        //string pick_province = "Hà Nội";//Tên tỉnh/thành phố nơi lấy hàng hóa
    //        //string pick_district = "Quận Hai Bà Trưng";
    //        //string province = "Hà Nội";
    //        //string district = "Quận Cầu Giấy";
    //        //string address = "P.503 tòa nhà Auu Việt, số 1 Lê Đức Thọ";
    //        //string tRequest = "/services/shipment/fee?/services/shipment/fee?address=" + address + "&province=" + province + "&district=" + district + "&pick_province=" + pick_province + "&pick_district=" + pick_district + "&weight=" + weight + "&value=" + value + "";

    //        //string Host = "https://dev.ghtk.vn";
    //        //IEnumerable<PriceGhtkResultModel> students = null;
    //        //using (var client = new HttpClient())
    //        //{
    //        //    client.BaseAddress = new Uri(Host);
    //        //    client.DefaultRequestHeaders.Accept.Clear();
    //        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    //        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Token);
    //        //    client.DefaultRequestHeaders.Add("Token", Token);

    //        //    //HTTP GET
    //        //    var responseTask = client.GetAsync(tRequest);
    //        //    responseTask.Wait();
    //        //    var result = responseTask.Result;
    //        //    if (result.IsSuccessStatusCode)
    //        //    {
    //        //        var readTask = result.Content.ReadAsAsync<IList<PriceGhtkResultModel>>();
    //        //        readTask.Wait();
    //        //        students = readTask.Result;
    //        //    }
    //        //    else //web api sent error response 
    //        //    {
    //        //        //log response status here..
    //        //        students = Enumerable.Empty<PriceGhtkResultModel>();
    //        //        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
    //        //    }
    //        //}
    //        //ViewBag.Thongbao = students;
    //        return View();
    //    }
    //    public ActionResult CacheMVC()
    //    {
    //        // cách 1
    //        //var Appalias = this.AppID;
    //        // var data=  GetCategories(Appalias);

    //        // cách 2
    //        //  var data = GetDanhMuc();
    //        // return View(data);

    //        return View();
    //    }
    //    public ActionResult DeleteCache()
    //    {
    //        //cách 1
    //        // MemoryCache.Default.Remove("DanhMuc");

    //        //cách 2
    //        //Remove("DanhMuc");
    //        return View();
    //    }

    //    //public List<Entity.Menu> GetDanhMuc()
    //    //{
    //    //    List<Entity.Menu> result = new List<Entity.Menu>();
    //    //    var cache = MemoryCache.Default;
    //    //    if (cache.Get("DanhMuc") == null)
    //    //    {
    //    //        var cachePolicty = new CacheItemPolicy();
    //    //        cachePolicty.AbsoluteExpiration = DateTime.Now.AddHours(200);
    //    //        using (var db = new NorthwindEntities())
    //    //        {
    //    //            result = db.Categories.ToList();
    //    //            cache.Add("DanhMuc", result, cachePolicty);
    //    //        }
    //    //    }
    //    //    else
    //    //    {
    //    //        result = (List<Entity.Menu>)cache.Get("DanhMuc");
    //    //    }
    //    //    return result;
    //    //}

    //    //public void Remove(string cacheKey)
    //    //{
    //    //    var lstCaches = MemoryCache.Default.Where(x => x.Key.ToLower().Contains(cacheKey.ToLower())).ToList();
    //    //    for (int i = 0; i < lstCaches.Count; i++)
    //    //        MemoryCache.Default.Remove(lstCaches[i].Key);
    //    //}

    //}
}