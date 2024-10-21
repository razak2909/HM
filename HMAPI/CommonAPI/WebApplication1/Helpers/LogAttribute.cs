using Microsoft.Owin;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Helpers
{
    public class LogAttribute : ActionFilterAttribute
    {
        private readonly LogRepository _logRepo;
        public LogAttribute()
        {
            _logRepo = new LogRepository();
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            ApiLogs obj = new ApiLogs();

            obj.Controller = actionContext.ControllerContext.ControllerDescriptor.ControllerName;
            obj.CreatedAt = DateTime.Now;
            obj.CreatedBy = GetClientIpAddress(actionContext.Request);
            obj.MethodName = actionContext.ActionDescriptor.ActionName;
            obj.ModifiedAt = obj.CreatedAt;
            obj.ModifiedBy = GetClientIpAddress(actionContext.Request);
            obj.Parameters = String.Join(",", actionContext.ActionArguments.Keys.ToList());
            obj.PostData = JsonConvert.SerializeObject(actionContext.ActionArguments);
            obj.Status = true;
            obj.UserId = HttpContext.Current.User.Identity.Name;

            _logRepo.SaveLog(obj);

            Trace.WriteLine(string.Format("Action Method {0} executing at {1}", actionContext.ActionDescriptor.ActionName, DateTime.Now.ToShortDateString()), "Web API Logs");
        }

        private string GetClientIpAddress(HttpRequestMessage request)
        {
            if (request.Properties.ContainsKey("MS_HttpContext"))
            {
                return IPAddress.Parse(((HttpContextBase)request.Properties["MS_HttpContext"]).Request.UserHostAddress).ToString();
            }

            if (request.Properties.ContainsKey("MS_OwinContext"))
            {
                return IPAddress.Parse(((OwinContext)request.Properties["MS_OwinContext"]).Request.RemoteIpAddress).ToString();
            }

            return String.Empty;
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            Trace.WriteLine(string.Format("Action Method {0} executed at {1}", actionExecutedContext.ActionContext.ActionDescriptor.ActionName, DateTime.Now.ToShortDateString()), "Web API Logs");
        }
    }
}
