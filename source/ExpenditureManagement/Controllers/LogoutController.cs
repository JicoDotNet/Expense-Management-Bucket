using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenditureManagement.Controllers
{
    public class LogoutController : BaseController
    {
        public ActionResult Index()
        {
            if (Credential != null)
            {
                var c = new HttpCookie("Credentials")
                {
                    Expires = DateTime.Now.AddDays(-1)
                };
                Response.Cookies.Add(c);
            }
            return RedirectToAction("Index", "Login", new { id = string.Empty });
        }
    }
}