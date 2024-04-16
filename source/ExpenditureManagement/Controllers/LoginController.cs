using ExpenditureManagement.Models;
using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Mvc;

namespace ExpenditureManagement.Controllers
{
    public class LoginController : BaseController
    {
        public ActionResult Index()
        {
            if(Credential != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginCredentials login)
        {
            if (WebConfigAppSettingsAccess.UserEmail != login.UserEmail
                    || WebConfigAppSettingsAccess.Password != login.Password)
            {
                TempData["success"] = "Either Email or Password is wrong!!";
                return RedirectToAction("Login", "Home", new { id = string.Empty });
            }
            else
            {
                login.UserFullName = WebConfigAppSettingsAccess.UserFullName;
                Response.Cookies.Add(new HttpCookie("Credential")
                {
                    Value = JsonConvert.SerializeObject(login),
                    Expires = DateTime.Now.AddMonths(11)
                });
                return RedirectToAction("Index", "Home", new { id = string.Empty });
            }
        }
    }
}