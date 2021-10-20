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

namespace VS.ECommerce_MVC.Api
{
    //[Route("api/[controller]")]
    public class AlbumController : ApiControllerBase
    {
        DatalinqDataContext db = new DatalinqDataContext();
        private string language = "VIE";

        [Route("album/getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var query = SAlbum.GET_GY_ALL("VIE");
                var responseData = Mapper.Map<List<Entity.Album>, List<AlbumViewModel>>(query);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        [Route("album/GetById/{id}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = SAlbum.GETBYID(id.ToString());
                var responseData = Mapper.Map<List<Entity.Album>, List<AlbumViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                //var response = request.CreateResponse(HttpStatusCode.OK, model);
                return response;
            });
        }


        #region TEDU
        // Code APi vào đây lấy về học và làm theo
        //H:\MVC\Thiết kế RESTful API với ASP.NET Core và Dapper ORM\tedushop-webapi-master\tedushop-webapi-master
        [Route("album/category/{id}/{page}/{pageSize}")]
        [HttpGet]
        public HttpResponseMessage Getcategory(HttpRequestMessage request, int id, int page = 0, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
               // var model = SAlbum.CategoryDisplay(More.Sub_Menu(More.NS, id.ToString()), "VIE", "1");
                var model = SAlbum.Name_Text("SELECT * FROM Album WHERE  lang='VIE' and Status=1  order by Create_Date desc");
               // model = model.Where(s => s.Menu_ID.ToString().Split(',').Any(a => id.ToString().Contains(a))).OrderBy(s => s.Create_Date).ThenByDescending(s => s.ID).ToList();
                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.Create_Date).Skip(page * pageSize).Take(pageSize).ToList();
                var responseData = Mapper.Map<IEnumerable<Entity.Album>, IEnumerable<AlbumViewModel>>(query);// Sử dụng AutoMapper và cần phải khai báo trong AutoMapperConfiguration
                var paginationSet = new PaginationSet<AlbumViewModel>()
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

        [Route("album/getallkeyword/{keyword}/{page}/{pageSize}")]
        [HttpGet]
        public HttpResponseMessage GetAllKeyword(HttpRequestMessage request, string keyword, int page = 0, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = SAlbum.Name_Text("SELECT * FROM Album WHERE Name  LIKE N'" + Framwork.Fproducts.SearchApproximate.Exec((keyword)) + "'  OR Code LIKE N'" + Framwork.Fproducts.SearchApproximate.Exec((keyword)) + "' and lang='VIE' and Status=1  order by Create_Date desc");
                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.Create_Date).Skip(page * pageSize).Take(pageSize).ToList();
                var responseData = Mapper.Map<IEnumerable<Entity.Album>, IEnumerable<AlbumViewModel>>(query);// Sử dụng AutoMapper và cần phải khai báo trong AutoMapperConfiguration
                var paginationSet = new PaginationSet<AlbumViewModel>()
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

        [Route("album/getallkeywordLoadCount/{keyword}/{Count}")]
        [HttpGet]
        public HttpResponseMessage GetAllKeyword(HttpRequestMessage request, string keyword, int Count = 10)
        {
            return CreateHttpResponse(request, () =>
            {
                var query = SAlbum.Name_Text("SELECT  top " + Count.ToString() + " * FROM Album WHERE Title LIKE N'" + Framwork.Fproducts.SearchApproximate.Exec(keyword) + "'  OR search LIKE N'" + Framwork.Fproducts.SearchApproximate.Exec((keyword)) + "' and lang='VIE' and Status=1  order by Create_Date desc");
                var responseData = Mapper.Map<IEnumerable<Entity.Album>, IEnumerable<AlbumViewModel>>(query);// Sử dụng AutoMapper và cần phải khai báo trong AutoMapperConfiguration
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("album/GetAllLoadCount/{Count}")]
        [HttpGet]
        public HttpResponseMessage GetAllLoadCount(HttpRequestMessage request, int Count = 10)
        {
            return CreateHttpResponse(request, () =>
            {
                var query = SAlbum.Name_Text("select  top " + Count.ToString() + " * from Album where  lang='VIE'  order by Create_Date desc");
                var responseData = Mapper.Map<IEnumerable<Entity.Album>, IEnumerable<AlbumViewModel>>(query);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("album/CategoryLoadCount/{id}/{Count}")]
        [HttpGet]
        public HttpResponseMessage CategoryLoadCount(HttpRequestMessage request, int id, int Count = 10)
        {
            return CreateHttpResponse(request, () =>
            {
                var query = SAlbum.Name_Text("select  top " + Count.ToString() + " * from Album where icid in ('" + More.Sub_Menu(More.NS, id.ToString()) + "') and  lang='VIE'  order by Create_Date desc");
                var responseData = Mapper.Map<IEnumerable<Entity.Album>, IEnumerable<AlbumViewModel>>(query);
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
        //            var query = SAlbum.GETBYID(id.ToString());
        //            SAlbum.News_DELETE(id.ToString());
        //            var responseData = Mapper.Map<IEnumerable<Entity.Album>, IEnumerable<AlbumViewModel>>(query);
        //            response = request.CreateResponse(HttpStatusCode.Created, responseData);
        //        }
        //        return response;
        //    });
        //}

        #endregion
    }
}



