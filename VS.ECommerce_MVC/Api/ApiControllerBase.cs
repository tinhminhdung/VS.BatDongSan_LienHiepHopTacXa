﻿using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VS.ECommerce_MVC.Api
{
    public class ApiControllerBase : ApiController
    {
        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage requestMessage, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage response = null;
            try
            {
                response = function.Invoke();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Trace.WriteLine("Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Trace.WriteLine("- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }
                //LogError(ex);
                ShowLog.WriteErrorLog(ex.InnerException.Message);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }
            catch (DbUpdateException dbEx)
            {
                /// LogError(dbEx);
                ShowLog.WriteErrorLog(dbEx.InnerException.Message);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, dbEx.InnerException.Message);
            }
            catch (Exception ex)
            {
                //LogError(ex);
                ShowLog.WriteErrorLog(ex.Message);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }

        //private void LogError(Exception ex)
        //{
        //    try
        //    {
        //        Error error = new Error();
        //        error.CreatedDate = DateTime.Now;
        //        error.Message = ex.Message;
        //        error.StackTrace = ex.StackTrace;
        //        _errorService.Create(error);
        //        _errorService.Save();
        //    }
        //    catch
        //    {
        //    }
        //}
    }
}