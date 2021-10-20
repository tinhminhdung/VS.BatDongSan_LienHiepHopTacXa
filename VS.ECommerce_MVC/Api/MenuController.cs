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
    public class MenuController : ApiControllerBase
    {
        DatalinqDataContext db = new DatalinqDataContext();
        private string language = "VIE";

        [Route("Menu/MenuPage")]
        [HttpGet]
        public HttpResponseMessage MenuPage(HttpRequestMessage request, string Vitri)
        {
            return CreateHttpResponse(request, () =>
            {
                var query = SMenu.Name_Text_Rg("SELECT capp,Create_Date,Description,Equals,ID,Images,Lang,Level,Link,Module,Name,Orders,Parent_ID,ShowID,Styleshow,TangName,Type,Url_Name,Views FROM Menu where capp='" + More.MN + "' and lang='VIE' and Views=" + Vitri + " and status=1 order by level,Orders asc").ToList();//Views là vị trí menu top
                //var responseData = Mapper.Map<List<Entity.VideoClip>, List<VideoViewModel>>(query);
                var response = request.CreateResponse(HttpStatusCode.OK, query);
                return response;
            });
        }

        [Route("Menu/MenuPro")]
        [HttpGet]
        public HttpResponseMessage MenuPro(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var query = SMenu.Name_Text_Rg("SELECT capp,Create_Date,Description,Equals,ID,Images,Lang,Level,Link,Module,Name,Orders,Parent_ID,ShowID,Styleshow,TangName,Type,Url_Name,Views FROM Menu where capp='" + More.PR + "' and lang='VIE' and status=1 order by level,Orders asc").ToList();//Views là vị trí menu top
                //var responseData = Mapper.Map<List<Entity.VideoClip>, List<VideoViewModel>>(query);
                var response = request.CreateResponse(HttpStatusCode.OK, query);
                return response;
            });
        }

        [Route("Menu/MenuNew")]
        [HttpGet]
        public HttpResponseMessage MenuNew(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var query = SMenu.Name_Text_Rg("SELECT capp,Create_Date,Description,Equals,ID,Images,Lang,Level,Link,Module,Name,Orders,Parent_ID,ShowID,Styleshow,TangName,Type,Url_Name,Views FROM Menu where capp='" + More.NS + "' and lang='VIE' and status=1 order by level,Orders asc").ToList();//Views là vị trí menu top
                //var responseData = Mapper.Map<List<Entity.VideoClip>, List<VideoViewModel>>(query);
                var response = request.CreateResponse(HttpStatusCode.OK, query);
                return response;
            });
        }

        [Route("Menu/MenuAlbum")]
        [HttpGet]
        public HttpResponseMessage MenuAlbum(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var query = SMenu.Name_Text_Rg("SELECT capp,Create_Date,Description,Equals,ID,Images,Lang,Level,Link,Module,Name,Orders,Parent_ID,ShowID,Styleshow,TangName,Type,Url_Name,Views FROM Menu where capp='" + More.AB + "' and lang='VIE' and status=1 order by level,Orders asc").ToList();//Views là vị trí menu top
                //var responseData = Mapper.Map<List<Entity.VideoClip>, List<VideoViewModel>>(query);
                var response = request.CreateResponse(HttpStatusCode.OK, query);
                return response;
            });
        }
        [Route("Menu/MenuVideo")]
        [HttpGet]
        public HttpResponseMessage MenuVideo(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var query = SMenu.Name_Text_Rg("SELECT capp,Create_Date,Description,Equals,ID,Images,Lang,Level,Link,Module,Name,Orders,Parent_ID,ShowID,Styleshow,TangName,Type,Url_Name,Views FROM Menu where capp='" + More.VD + "' and lang='VIE' and status=1 order by level,Orders asc").ToList();//Views là vị trí menu top
                //var responseData = Mapper.Map<List<Entity.VideoClip>, List<VideoViewModel>>(query);
                var response = request.CreateResponse(HttpStatusCode.OK, query);
                return response;
            });
        }

        [Route("Menu/GetById")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = SMenu.GETBYID(id.ToString());
                //  var responseData = Mapper.Map<List<Entity.VideoClip>, List<VideoViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, model);
                //var response = request.CreateResponse(HttpStatusCode.OK, model);
                return response;
            });
        }

        [Route("Menu/ParentID")]
        [HttpGet]
        public HttpResponseMessage GetByParentID(HttpRequestMessage request, string capp, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = SMenu.Name_Text_Rg("SELECT capp,Create_Date,Description,Equals,ID,Images,Lang,Level,Link,Module,Name,Orders,Parent_ID,ShowID,Styleshow,TangName,Type,Url_Name,Views  FROM [Menu]  where capp='" + capp + "' and  Lang='VIE'  and Parent_ID=" + id + " and Status=1 order by ID asc,Orders desc");
                //  var responseData = Mapper.Map<List<Entity.VideoClip>, List<VideoViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, model);
                //var response = request.CreateResponse(HttpStatusCode.OK, model);
                return response;
            });
        }

    }
}



