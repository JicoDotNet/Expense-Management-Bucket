using ExpenditureManagement.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace System.Web.Mvc
{
    public abstract class BaseController : Controller
    {
        public LoginCredentials Credential { get; private set; }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpCookie reqCookies = filterContext.RequestContext.HttpContext.Request.Cookies["Credential"];
            if (reqCookies != null)
            {
                try
                {
                    Credential = JsonConvert.DeserializeObject<LoginCredentials>(reqCookies.Value);
                    return;
                }
                catch
                {
                    Credential = null;
                }
            }
            Credential = null;
        }
    }
}