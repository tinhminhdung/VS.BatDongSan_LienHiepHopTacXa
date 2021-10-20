using MoreAll;
using Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Linq;
using AutoMapper;
using VS.ECommerce_MVC.Models;
using System.Threading.Tasks;
using NganLuongAPI;
using System.Web;
using System.IO;
using OfficeOpenXml;

namespace VS.ECommerce_MVC.Api
{
    //[Route("api/[controller]")]
    public class ProductController : ApiControllerBase
    {
        DatalinqDataContext db = new DatalinqDataContext();
        private string language = "VIE";

        [Route("product/getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var query = SProducts.GetByAll("VIE");
                var responseData = Mapper.Map<List<Entity.Products>, List<ProductViewModel>>(query);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        [Route("product/GetById/{id}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = SProducts.GetById(id.ToString());
                var responseData = Mapper.Map<List<Entity.Products>, List<ProductViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                //var response = request.CreateResponse(HttpStatusCode.OK, model);
                return response;
            });
        }


        #region TEDU
        // Code APi vào đây lấy về học và làm theo
        //H:\MVC\Thiết kế RESTful API với ASP.NET Core và Dapper ORM\tedushop-webapi-master\tedushop-webapi-master
        [Route("product/category/{id}/{page}/{pageSize}")]
        [HttpGet]
        public HttpResponseMessage Getcategory(HttpRequestMessage request, int id, int page = 0, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
               // var model = SProducts.CategoryDisplay(More.Sub_Menu(More.NS, id.ToString()), "VIE", "1");
                var model = SProducts.Name_Text("SELECT * FROM products WHERE  lang='VIE' and Status=1  order by Create_Date desc");
                //model = model.Where(s => s.icid.ToString().Split(',').Any(a => id.ToString().Contains(a))).OrderBy(s => s.Create_Date).ThenByDescending(s => s.ipid).ToList();
                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.Create_Date).Skip(page * pageSize).Take(pageSize).ToList();
                var responseData = Mapper.Map<IEnumerable<Entity.Products>, IEnumerable<ProductViewModel>>(query);// Sử dụng AutoMapper và cần phải khai báo trong AutoMapperConfiguration
                var paginationSet = new PaginationSet<ProductViewModel>()
                {
                    Items = responseData,
                    PageIndex = page,
                    TotalRows = totalRow,
                    PageSize = pageSize
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }

        [Route("product/getallkeyword/{keyword}/{page}/{pageSize}")]
        [HttpGet]
        public HttpResponseMessage GetAllKeyword(HttpRequestMessage request, string keyword, int page = 0, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = SProducts.Name_Text("SELECT * FROM products WHERE Name  LIKE N'" + Framwork.Fproducts.SearchApproximate.Exec((keyword)) + "'  OR Code LIKE N'" + Framwork.Fproducts.SearchApproximate.Exec((keyword)) + "' and lang='VIE' and Status=1  order by Create_Date desc");
                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.Create_Date).Skip(page * pageSize).Take(pageSize).ToList();
                var responseData = Mapper.Map<IEnumerable<Entity.Products>, IEnumerable<ProductViewModel>>(query);// Sử dụng AutoMapper và cần phải khai báo trong AutoMapperConfiguration
                var paginationSet = new PaginationSet<ProductViewModel>()
                {
                    Items = responseData,
                    PageIndex = page,
                    TotalRows = totalRow,
                    PageSize = pageSize
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }

        [Route("product/getallkeywordLoadCount/{keyword}/{Count}")]
        [HttpGet]
        public HttpResponseMessage GetAllKeyword(HttpRequestMessage request, string keyword, int Count = 10)
        {
            return CreateHttpResponse(request, () =>
            {
                var query = SProducts.Name_Text("SELECT  top " + Count.ToString() + " * FROM products WHERE Title LIKE N'" + Framwork.Fproducts.SearchApproximate.Exec(keyword) + "'  OR search LIKE N'" + Framwork.Fproducts.SearchApproximate.Exec((keyword)) + "' and lang='VIE' and Status=1  order by Create_Date desc");
                var responseData = Mapper.Map<IEnumerable<Entity.Products>, IEnumerable<ProductViewModel>>(query);// Sử dụng AutoMapper và cần phải khai báo trong AutoMapperConfiguration
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("product/GetAllLoadCount/{Count}")]
        [HttpGet]
        public HttpResponseMessage GetAllLoadCount(HttpRequestMessage request, int Count = 10)
        {
            return CreateHttpResponse(request, () =>
            {
                var query = SProducts.Name_Text("select  top " + Count.ToString() + " * from products where  lang='VIE'  order by Create_Date desc");
                var responseData = Mapper.Map<IEnumerable<Entity.Products>, IEnumerable<ProductViewModel>>(query);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("product/CategoryLoadCount/{id}/{Count}")]
        [HttpGet]
        public HttpResponseMessage CategoryLoadCount(HttpRequestMessage request, int id, int Count = 10)
        {
            return CreateHttpResponse(request, () =>
            {
                var query = SProducts.Name_Text("select  top " + Count.ToString() + " * from products where icid in ('" + More.Sub_Menu(More.NS, id.ToString()) + "') and  lang='VIE'  order by Create_Date desc");
                var responseData = Mapper.Map<IEnumerable<Entity.Products>, IEnumerable<ProductViewModel>>(query);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }


        //http://localhost:63136/delete?id=164
        //[Route("delete")]
        //[HttpDelete]
        //[AllowAnonymous]
        //public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        if (!ModelState.IsValid)
        //        {
        //            response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {
        //            var query = SProducts.GETBYID(id.ToString());
        //            SProducts.News_DELETE(id.ToString());
        //            var responseData = Mapper.Map<IEnumerable<Entity.Products>, IEnumerable<ProductViewModel>>(query);
        //            response = request.CreateResponse(HttpStatusCode.Created, responseData);
        //        }
        //        return response;
        //    });
        //}

        #endregion

        [HttpGet]
        [Route("product/ExportXls")]
        public async Task<HttpResponseMessage> ExportXls(HttpRequestMessage request)
        {
            string fileName = string.Concat("Products" + DateTime.Now.ToString("yyyyMMddhhmmsss") + ".xlsx");
            var folderReport = ConfigHelper.GetByKey("ReportFolder");
            string filePath = HttpContext.Current.Server.MapPath(folderReport);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            string fullPath = Path.Combine(filePath, fileName);
            try
            {
                // Lấy 1 số trường thôi thì làm như Automaper hoặc obj 
                var data = SProducts.GetByAll("VIE");
                var responseData = Mapper.Map<List<Entity.Products>, List<ProductViewModel>>(data);
                await ReportHelper.GenerateXls(responseData, fullPath);
                
                // Lấy tất cả các trường
                //var data = SProducts.GetByAll("VIE");
                //await ReportHelper.GenerateXls(data, fullPath);

                return request.CreateErrorResponse(HttpStatusCode.OK, Path.Combine(folderReport, fileName));
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        [HttpGet]
        [Route("product/ExportPdf")]
        public async Task<HttpResponseMessage> ExportPdf(HttpRequestMessage request, int id)
        {
            string fileName = string.Concat("Product" + DateTime.Now.ToString("yyyyMMddhhmmssfff") + ".pdf");
            var folderReport = ConfigHelper.GetByKey("ReportFolder");
            string filePath = HttpContext.Current.Server.MapPath(folderReport);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            string fullPath = Path.Combine(filePath, fileName);
            try
            {
                var template = File.ReadAllText(HttpContext.Current.Server.MapPath("/Uploads/Templates/product-detail.html"));
                var replaces = new Dictionary<string, string>();
                var product = SProducts.GetById(id.ToString());
                replaces.Add("{{ProductName}}", product[0].Name);
                //replaces.Add("{{Price}}", product[0].Price);
                replaces.Add("{{Description}}", product[0].Brief);
                replaces.Add("{{Create_Date}}", product[0].Create_Date + " ");

                template = template.Parse(replaces);

                await ReportHelper.GeneratePdf(template, fullPath);
                return request.CreateErrorResponse(HttpStatusCode.OK, Path.Combine(folderReport, fileName));
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //[Route("product/import")]
        //[HttpPost]
        //public async Task<HttpResponseMessage> Import()
        //{
        //    if (!Request.Content.IsMimeMultipartContent())
        //    {
        //        Request.CreateErrorResponse(HttpStatusCode.UnsupportedMediaType, "Định dạng không được server hỗ trợ");
        //    }

        //    var root = HttpContext.Current.Server.MapPath("~/Uploads/UploadedFiles/Excels");
        //    if (!Directory.Exists(root))
        //    {
        //        Directory.CreateDirectory(root);
        //    }

        //    var provider = new MultipartFormDataStreamProvider(root);
        //    var result = await Request.Content.ReadAsMultipartAsync(provider);
        //    //do stuff with files if you wish
        //    if (result.FormData["categoryId"] == null)
        //    {
        //        Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bạn chưa chọn danh mục sản phẩm.");
        //    }

        //    //Upload files
        //    int addedCount = 0;
        //    int categoryId = 0;
        //    int.TryParse(result.FormData["categoryId"], out categoryId);
        //    foreach (MultipartFileData fileData in result.FileData)
        //    {
        //        if (string.IsNullOrEmpty(fileData.Headers.ContentDisposition.FileName))
        //        {
        //            return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Yêu cầu không đúng định dạng");
        //        }
        //        string fileName = fileData.Headers.ContentDisposition.FileName;
        //        if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
        //        {
        //            fileName = fileName.Trim('"');
        //        }
        //        if (fileName.Contains(@"/") || fileName.Contains(@"\"))
        //        {
        //            fileName = Path.GetFileName(fileName);
        //        }

        //        var fullPath = Path.Combine(root, fileName);
        //        File.Copy(fileData.LocalFileName, fullPath, true);

        //        //insert to DB
        //        var listProduct = this.ReadProductFromExcel(fullPath, categoryId);
        //        if (listProduct.Count > 0)
        //        {
        //            foreach (var product in listProduct)
        //            {
        //                _productService.Add(product);
        //                addedCount++;
        //            }
        //            _productService.Save();
        //        }
        //    }
        //    return Request.CreateResponse(HttpStatusCode.OK, "Đã nhập thành công " + addedCount + " sản phẩm thành công.");
        //}


        // dang làm giở, chưa xong
        //private List<Entity.Products> ReadProductFromExcel(string fullPath, int categoryId)
        //{
        //    using (var package = new ExcelPackage(new FileInfo(fullPath)))
        //    {
        //        ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
        //        List<Entity.Products> listProduct = new List<Entity.Products>();
        //        ProductViewModel productViewModel;
        //        Entity.Products product;

        //        string originalPrice = "0";
        //        string price = "0";
        //        decimal promotionPrice;

        //        bool status = false;
        //        bool showHome = false;
        //        bool isHot = false;
        //        int warranty;

        //        for (int i = workSheet.Dimension.Start.Row + 1; i <= workSheet.Dimension.End.Row; i++)
        //        {
        //            productViewModel = new ProductViewModel();
        //            product = new Entity.Products();

        //            productViewModel.Name = workSheet.Cells[i, 1].Value.ToString();
        //          //  productViewModel.Brief = productViewModel.Brief;// StringHelper.ToUnsignString(productViewModel.Name);
        //            productViewModel.Code = workSheet.Cells[i, 2].Value.ToString();

        //            if (int.TryParse(workSheet.Cells[i, 3].Value.ToString(), out warranty))
        //            {
        //                productViewModel.Warranty = warranty;
        //            }

        //           /// decimal.TryParse(workSheet.Cells[i, 4].Value.ToString().Replace(",", ""), out originalPrice);
        //           /// 
        //            productViewModel.OldPrice = workSheet.Cells[i, 4].Value.ToString().Replace(",", "");

        //            decimal.TryParse(workSheet.Cells[i, 5].Value.ToString().Replace(",", ""), out price);
        //            productViewModel.Price = price;

        //            if (decimal.TryParse(workSheet.Cells[i, 6].Value.ToString(), out promotionPrice))
        //            {
        //                productViewModel.PromotionPrice = promotionPrice;
        //            }

        //            productViewModel.Content = workSheet.Cells[i, 7].Value.ToString();
        //            productViewModel.MetaKeyword = workSheet.Cells[i, 8].Value.ToString();
        //            productViewModel.MetaDescription = workSheet.Cells[i, 9].Value.ToString();

        //            productViewModel.CategoryID = categoryId;

        //            bool.TryParse(workSheet.Cells[i, 10].Value.ToString(), out status);
        //            productViewModel.Status = status;

        //            bool.TryParse(workSheet.Cells[i, 11].Value.ToString(), out showHome);
        //            productViewModel.HomeFlag = showHome;

        //            bool.TryParse(workSheet.Cells[i, 12].Value.ToString(), out isHot);
        //            productViewModel.HotFlag = isHot;

        //            product.UpdateProduct(productViewModel);
        //            listProduct.Add(product);
        //        }
        //        return listProduct;
        //    }
        //}
    }
}



