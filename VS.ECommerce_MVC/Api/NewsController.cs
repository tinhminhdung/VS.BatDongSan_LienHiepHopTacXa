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
using Framework;
using Entity;
using System.IO;
using System.Web;
using NganLuongAPI;
using System.Threading.Tasks;

namespace VS.ECommerce_MVC.Api
{
    //[Route("api/[controller]")]
    public class NewsController : ApiControllerBase
    {
        DatalinqDataContext db = new DatalinqDataContext();

        #region Code Cũ vẫn chạy được nhé.
        // GET api/default1
        //DatalinqDataContext db = new DatalinqDataContext();
        //public IHttpActionResult Get()
        //{
        //    var obj = db.News.ToList();
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(obj);
        //}

        //public IHttpActionResult Get(int id)
        //{
        //    var obj = db.News.FirstOrDefault((p) => p.inid == id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(obj);
        //}
        //// Rút gọn
        //// đây là cách rút gọn code thay automapper
        //public IEnumerable<NewsViewModel> GetRutGon(int id)
        //{
        //    DatalinqDataContext db = new DatalinqDataContext();
        //    var query = from p in db.News.Where(s => s.inid == id)
        //                select new NewsViewModel
        //                {
        //                    inid = p.inid,
        //                    Title = p.Title,
        //                    Brief = p.Brief,
        //                    Images = p.Images != null ? p.Images : "no-image.jpg",
        //                    ImagesSmall = p.ImagesSmall != null ? p.ImagesSmall : "no-image.jpg",
        //                    Create_Date = p.Create_Date,
        //                    TangName = p.TangName,
        //                    Alt = p.Alt
        //                };
        //    return query.ToList();
        //}

        ////http://localhost:63136/api/News/GetAllPaging?request.number=1&request.pageSize=3
        //[HttpGet]
        //public IEnumerable<New> GetAllPaging([FromUri]PagingAPI request)
        //{
        //    // Return List of Customer  
        //    var source = (from customer in db.News.
        //                    OrderBy(a => a.Create_Date)
        //                  select customer).AsQueryable();

        //    //Tham số tìm kiếm [Với kiểm tra rỗng]
        //    // ------------------------------------ tìm kiếm-------------------   
        //    if (!string.IsNullOrEmpty(request.QuerySearch))
        //    {
        //        source = source.Where(a => a.Title.Contains(request.QuerySearch));
        //    }

        //    // ------------------------------------ Search -------------------  

        //    int count = source.Count();

        //    //Tham số được truyền từ chuỗi Truy vấn nếu nó là null thì nó mặc định Giá trị sẽ là pageNumber: 1
        //    // Parameter is passed from Query string if it is null then it default Value will be pageNumber:1  
        //    int CurrentPage = request.PageNumber;

        //    //Tham số được truyền từ chuỗi Truy vấn nếu nó là null thì nó mặc định Giá trị sẽ là pageSize: 20
        //    // Parameter is passed from Query string if it is null then it default Value will be pageSize:20  
        //    int PageSize = request.pageSize;

        //    // Display TotalCount to Records to User  
        //    //Hiển thị TotalCount 
        //    int TotalCount = count;

        //    //Tính tổng trang bằng cách chia (Không có bản ghi / Kích thước trang)
        //    // Calculating Totalpage by Dividing (No of Records / Pagesize)  
        //    int TotalPages = (int)Math.Ceiling(count / (double)PageSize);

        //    // Trả lại danh sách khách hàng sau khi áp dụng Phân trang
        //    var items = source.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();

        //    // nếu CurrentPage lớn hơn 1 nghĩa là nó có Trang trước
        //    var previousPage = CurrentPage > 1 ? "Yes" : "No";

        //    // nếu TotalPages lớn hơn CurrentPage nghĩa là nó có nextPage
        //    var nextPage = CurrentPage < TotalPages ? "Yes" : "No";

        //    // Object which we are going to send in header   

        //    //Đối tượng mà chúng tôi sẽ gửi trong tiêu đề
        //    var paginationMetadata = new
        //    {
        //        totalCount = TotalCount,
        //        pageSize = PageSize,
        //        currentPage = CurrentPage,
        //        totalPages = TotalPages,
        //        previousPage,
        //        nextPage,
        //        QuerySearch = string.IsNullOrEmpty(request.QuerySearch) ? "Không tìm thấy" : request.QuerySearch
        //    };

        //    // Setting Header  
        //    //  HttpContext.Current.Response.Headers.Add("Paging-Headers", JsonConvert.SerializeObject(paginationMetadata));
        //    // Returing List of Customers Collections  
        //    return items;

        //}


        #endregion

        ///////////// ******** Làm theo TEDU ****************
        #region TEDU
        // Code APi vào đây lấy về học và làm theo
        //H:\MVC\Thiết kế RESTful API với ASP.NET Core và Dapper ORM\tedushop-webapi-master\tedushop-webapi-master
        //http://localhost:63136/getallkeyword?request=1&keyword=Miranda%20&page=0&pageSize=2


        //http://localhost:63136/getall
        [Route("news/getall")]
       // [Route("/news/getall", Summary = @"Default hello service.",Notes = "Longer description for hello service.")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var query = SNews.GETBYALL("VIE");
                var responseData = Mapper.Map<IEnumerable<Entity.News>, IEnumerable<NewsViewModel>>(query);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        //http://localhost:63136/detail/131
        [Route("news/detail/{id}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var query = SNews.GETBYID(id.ToString());
                var responseData = Mapper.Map<IEnumerable<Entity.News>, IEnumerable<NewsViewModel>>(query);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("news/category/{id}/{page}/{pageSize}")]
        [HttpGet]
        public HttpResponseMessage Getcategory(HttpRequestMessage request, int id, int page = 0, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = SNews.CATEGORY(More.Sub_Menu(More.NS, id.ToString()), "VIE", "1");
                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.Create_Date).Skip(page * pageSize).Take(pageSize).ToList();
                var responseData = Mapper.Map<IEnumerable<Entity.News>, IEnumerable<NewsViewModel>>(query);// Sử dụng AutoMapper và cần phải khai báo trong AutoMapperConfiguration
                var paginationSet = new PaginationSet<NewsViewModel>()
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

        [Route("news/getallkeyword/{keyword}/{page}/{pageSize}")]
        [HttpGet]
        public HttpResponseMessage GetAllKeyword(HttpRequestMessage request, string keyword, int page = 0, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = SNews.SearchNews(keyword, "VIE");
                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.Create_Date).Skip(page * pageSize).Take(pageSize).ToList();
                var responseData = Mapper.Map<IEnumerable<Entity.News>, IEnumerable<NewsViewModel>>(query);// Sử dụng AutoMapper và cần phải khai báo trong AutoMapperConfiguration
                var paginationSet = new PaginationSet<NewsViewModel>()
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

        [Route("news/getallkeywordLoadCount/{keyword}/{Count}")]
        [HttpGet]
        public HttpResponseMessage GetAllKeyword(HttpRequestMessage request, string keyword, int Count = 10)
        {
            return CreateHttpResponse(request, () =>
            {
                var query = SNews.Name_Text("SELECT  top " + Count.ToString() + " * FROM News WHERE Title LIKE N'" + Framwork.Fproducts.SearchApproximate.Exec(keyword) + "'  OR search LIKE N'" + Framwork.Fproducts.SearchApproximate.Exec((keyword)) + "' and lang='VIE' and Status=1  order by Create_Date desc");
                var responseData = Mapper.Map<IEnumerable<Entity.News>, IEnumerable<NewsViewModel>>(query);// Sử dụng AutoMapper và cần phải khai báo trong AutoMapperConfiguration
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("news/GetAllLoadCount/{Count}")]
        [HttpGet]
        public HttpResponseMessage GetAllLoadCount(HttpRequestMessage request, int Count = 10)
        {
            return CreateHttpResponse(request, () =>
            {
                var query = SNews.Name_Text("select  top " + Count.ToString() + " * from News where  lang='VIE'  order by Create_Date desc");
                var responseData = Mapper.Map<IEnumerable<Entity.News>, IEnumerable<NewsViewModel>>(query);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("news/CategoryLoadCount/{id}/{Count}")]
        [HttpGet]
        public HttpResponseMessage CategoryLoadCount(HttpRequestMessage request, int id, int Count = 10)
        {
            return CreateHttpResponse(request, () =>
            {
                var query = SNews.Name_Text("select  top " + Count.ToString() + " * from News where icid in ('" + More.Sub_Menu(More.NS, id.ToString()) + "') and  lang='VIE'  order by Create_Date desc");
                var responseData = Mapper.Map<IEnumerable<Entity.News>, IEnumerable<NewsViewModel>>(query);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("news/add")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, Entity.News NewsVm)
        {
            News obj = new News();
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    //    var newProduct = new Product();
                    //    newProduct.UpdateProduct(productCategoryVm);
                    //    newProduct.CreatedDate = DateTime.Now;
                    //    newProduct.CreatedBy = User.Identity.Name;
                    //    _productService.Add(newProduct);
                    //    _productService.Save();

                    #region RewriteUrl
                    int cong = 0;
                    string TangName = "";
                    if (NewsVm.TangName.Length > 0)
                    {
                        #region InsertMenu
                        List<Entity.News> curItem = SNews.Name_Text("SELECT top 1 * FROM News order by inid desc");
                        if (curItem.Count > 0) { int tong = int.Parse(curItem[0].inid.ToString()); cong = tong + 1; } var hasTagName = db.News.Where(s => s.TangName == MoreAll.AddURL.SeoURL(NewsVm.TangName)).FirstOrDefault(); TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(NewsVm.TangName) + "-" + cong : MoreAll.AddURL.SeoURL(NewsVm.TangName);

                        #endregion
                    }
                    else
                    {
                        #region InsertMenu
                        List<Entity.News> curItem = SNews.Name_Text("SELECT top 1 * FROM News order by inid desc");
                        if (curItem.Count > 0) { int tong = int.Parse(curItem[0].inid.ToString()); cong = tong + 1; } var hasTagName = db.News.Where(s => s.TangName == MoreAll.AddURL.SeoURL(NewsVm.Title)).FirstOrDefault(); TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(NewsVm.Title) + "-" + cong : MoreAll.AddURL.SeoURL(NewsVm.Title);
                        #endregion
                    }
                    #endregion

                    #region MyRegion
                    obj.icid = NewsVm.icid;
                    obj.Title = NewsVm.Title;
                    obj.Brief = NewsVm.Brief;
                    obj.Contents = NewsVm.Contents;
                    obj.Keywords = NewsVm.Keyword;
                    obj.search = RewriteURLNew.NameSearch(NewsVm.Title);

                    obj.Images = NewsVm.Images;
                    obj.ImagesSmall = NewsVm.ImagesSmall.Replace("uploads", "uploads/_thumbs");

                    obj.Equals = 0;
                    obj.Chekdata = NewsVm.Chekdata;
                    obj.Create_Date = NewsVm.Create_Date;
                    obj.Modified_Date = NewsVm.Modified_Date;
                    obj.Views = 0;
                    obj.Tags = NewsVm.Tags;
                    obj.lang = NewsVm.lang;
                    obj.New = NewsVm.New;
                    obj.CheckBox1 = NewsVm.CheckBox1;
                    obj.CheckBox2 = NewsVm.CheckBox2;
                    obj.CheckBox3 = NewsVm.CheckBox3;
                    obj.CheckBox4 = NewsVm.CheckBox4;
                    obj.CheckBox5 = NewsVm.CheckBox5;
                    obj.CheckBox6 = NewsVm.CheckBox6;
                    obj.Status = NewsVm.Status;
                    obj.Titleseo = NewsVm.Titleseo;
                    obj.Meta = NewsVm.Meta;
                    obj.Keyword = NewsVm.Keyword;
                    obj.TangName = TangName;
                    obj.Alt = NewsVm.Alt;
                    SNews.News_INSERT(obj);
                    #endregion

                    var responseData = Mapper.Map<Entity.News, NewsViewModel>(obj);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("news/update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, Entity.News NewsVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    //var dbProduct = _productService.GetById(productVm.ID);
                    //dbProduct.UpdateProduct(productVm);
                    //dbProduct.UpdatedDate = DateTime.Now;
                    //dbProduct.UpdatedBy = User.Identity.Name;
                    //_productService.Update(dbProduct);
                    //_productService.Save();

                    #region RewriteUrl
                    string TagName = "";
                    if (NewsVm.TangName.Length > 0)
                    {
                        #region UpdateMenu
                        List<Entity.News> item = SNews.GETBYID(NewsVm.inid.ToString());
                        if (item.Count > 0)
                        {
                            List<New> list = (from p in db.News where p.TangName == item[0].TangName orderby p.inid descending select p).ToList();
                            if (list.Count > 2)
                            {
                                var hasTagName = db.News.Where(s => s.TangName == MoreAll.AddURL.SeoURL(NewsVm.TangName)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(NewsVm.TangName) + "-" + item[0].inid : MoreAll.AddURL.SeoURL(NewsVm.TangName);
                            }
                            else
                            {
                                if (MoreAll.AddURL.SeoURL(item[0].TangName) != MoreAll.AddURL.SeoURL(NewsVm.TangName)) { var hasTagName = db.News.Where(s => s.TangName == MoreAll.AddURL.SeoURL(NewsVm.TangName)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(NewsVm.TangName) + "-" + item[0].inid : MoreAll.AddURL.SeoURL(NewsVm.TangName); } else { TagName = item[0].TangName; }
                            }

                        }
                        #endregion
                    }
                    else
                    {
                        #region UpdateMenu
                        List<News> item = SNews.GETBYID(NewsVm.inid.ToString());
                        if (item.Count > 0)
                        {
                            List<New> list = (from p in db.News where p.TangName == item[0].TangName orderby p.inid descending select p).ToList();
                            if (list.Count > 2)
                            {
                                var hasTagName = db.News.Where(s => s.TangName == MoreAll.AddURL.SeoURL(NewsVm.Title)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(NewsVm.Title) + "-" + item[0].inid : MoreAll.AddURL.SeoURL(NewsVm.Title);
                            }
                            else
                            {
                                if (MoreAll.AddURL.SeoURL(item[0].TangName) != MoreAll.AddURL.SeoURL(NewsVm.Title)) { var hasTagName = db.News.Where(s => s.TangName == MoreAll.AddURL.SeoURL(NewsVm.Title)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(NewsVm.Title) + "-" + item[0].inid : MoreAll.AddURL.SeoURL(NewsVm.Title); } else { TagName = item[0].TangName; }
                            }

                        }
                        #endregion
                    }
                    #endregion

                    News obj = new News();
                    #region MyRegion
                    obj.inid = NewsVm.inid;
                    obj.icid = NewsVm.icid;
                    obj.Title = NewsVm.Title;
                    obj.Brief = NewsVm.Brief;
                    obj.Contents = NewsVm.Contents;
                    obj.Keywords = NewsVm.Keywords;
                    obj.search = RewriteURLNew.NameSearch(NewsVm.Title);

                    obj.Images = NewsVm.Images;
                    obj.ImagesSmall = NewsVm.ImagesSmall.Replace("uploads", "uploads/_thumbs");

                    obj.Equals = 0;
                    obj.Chekdata = NewsVm.Chekdata;
                    obj.Create_Date = NewsVm.Create_Date;
                    obj.Modified_Date = NewsVm.Modified_Date;
                    obj.Views = 0;
                    obj.Tags = NewsVm.Tags;
                    obj.lang = NewsVm.lang;
                    obj.New = NewsVm.New;
                    obj.CheckBox1 = NewsVm.CheckBox1;
                    obj.CheckBox2 = NewsVm.CheckBox2;
                    obj.CheckBox3 = NewsVm.CheckBox3;
                    obj.CheckBox4 = NewsVm.CheckBox4;
                    obj.CheckBox5 = NewsVm.CheckBox5;
                    obj.CheckBox6 = NewsVm.CheckBox6;
                    obj.Status = NewsVm.Status;
                    obj.Titleseo = NewsVm.Titleseo;
                    obj.Meta = NewsVm.Meta;
                    obj.Keyword = NewsVm.Keyword;
                    obj.TangName = TagName;
                    obj.Alt = NewsVm.Alt;
                    #endregion
                    SNews.News_UPDATE(obj);

                    var responseData = Mapper.Map<Entity.News, NewsViewModel>(obj);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }


        //http://localhost:63136/delete?id=164
        [Route("news/delete/{id}")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var query = SNews.GETBYID(id.ToString());
                    SNews.News_DELETE(id.ToString());
                    var responseData = Mapper.Map<IEnumerable<Entity.News>, IEnumerable<NewsViewModel>>(query);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }




        // kết quả sau khi gét xong nó nằm ở đây -->"Message": "/Reports\\News_20210121101029.xlsx"

       
        [HttpGet]
        [Route("news/ExportXls")]
        public async Task<HttpResponseMessage> ExportXls(HttpRequestMessage request)
        {
            string fileName = string.Concat("News_" + DateTime.Now.ToString("yyyyMMddhhmmsss") + ".xlsx");
            var folderReport = ConfigHelper.GetByKey("ReportFolder");
            string filePath = HttpContext.Current.Server.MapPath(folderReport);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            string fullPath = Path.Combine(filePath, fileName);
            try
            {
                var data = SNews.GETBYALL("VIE");
                await ReportHelper.GenerateXls(data, fullPath);
                return request.CreateErrorResponse(HttpStatusCode.OK, Path.Combine(folderReport, fileName));
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        //[Route("news/import")]
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

        #endregion



    }
}
