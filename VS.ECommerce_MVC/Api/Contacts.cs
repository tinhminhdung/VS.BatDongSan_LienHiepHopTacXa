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
    public class ContactController : ApiControllerBase
    {
        DatalinqDataContext db = new DatalinqDataContext();
        private string language = "VIE";


        // Xem ảnh đã làm demo ở Api\Note\lienhe.png
        [HttpPost]
        public HttpResponseMessage Save(HttpRequestMessage request, Entity.Contacts person)
        {
            Entity.Contacts obj = new Entity.Contacts();
            obj.vtitle = person.vtitle;
            obj.vname = person.vname;
            obj.vaddress = person.vaddress;
            obj.vphone = person.vphone;
            obj.vemail = person.vemail;
            obj.vcontent = person.vcontent;
            obj.dcreatedate = DateTime.Now;
            obj.lang = "VIE";
            obj.istatus = 0;
            if (SContacts.INSERT(obj) == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse("Lỗi");
        }

        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, Entity.Contacts person)
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
                    Entity.Contacts obj = new Entity.Contacts();
                    obj.vtitle = person.vtitle;
                    obj.vname = person.vname;
                    obj.vaddress = person.vaddress;
                    obj.vphone = person.vphone;
                    obj.vemail = person.vemail;
                    obj.vcontent = person.vcontent;
                    obj.dcreatedate = DateTime.Now;
                    obj.lang = "VIE";
                    obj.istatus = 0;
                    if (SContacts.INSERT(obj) == true)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    response = request.CreateResponse(HttpStatusCode.Created, person);
                }
                return response;
            });
        }
    }
}
