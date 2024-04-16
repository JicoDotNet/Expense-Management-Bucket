using ExpenditureManagement.Models;
using Newtonsoft.Json;
using System.Web.Routing;

namespace System.Web.Mvc
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class SessionAuthenticate : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            RouteValueDictionary LogoutRouteObj =
                    new RouteValueDictionary
                    {
                        { "action", "Index" },
                        { "controller", "Logout" }
                    };

            try
            {
                HttpCookie cookie = filterContext.RequestContext.HttpContext.Request.Cookies["Credential"];
                if (cookie != null)
                {
                    try
                    {
                        LoginCredentials loginCredentials = JsonConvert.DeserializeObject<LoginCredentials>(cookie.Value);
                        return;
                    }
                    catch
                    {
                        filterContext.Result =
                        new RedirectToRouteResult(LogoutRouteObj);
                        return;
                    }
                }
                filterContext.Result =
                        new RedirectToRouteResult(LogoutRouteObj);
                return;
            }
            catch
            {
                filterContext.Result =
                            new RedirectToRouteResult(LogoutRouteObj);
                return;
            }
        }
    }
}