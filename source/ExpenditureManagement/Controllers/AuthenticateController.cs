using DataAccess.AzureStorage;
using ExpenditureManagement.Logic;
using ExpenditureManagement.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
#pragma warning disable CS4014

namespace ExpenditureManagement.Controllers
{
    public class AuthenticateController : BaseController
    {
        public ActionResult Index()
        {
            if (Credential != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public JsonResult SendOTP(EmailOTP emailOTP)
        {
            ExecuteTableManager tableManager = new ExecuteTableManager("OTP", WebConfigAppSettingsAccess.AzureStorageConnectionString);

            EmailOTP oldEmailOTP = tableManager.RetrieveEntity<EmailOTP>("PartitionKey eq 'ExpenseManage' " +
                                                        " and UserEmail eq '" + emailOTP.UserEmail + "' " +
                                                        " and IsActive eq true").FirstOrDefault();
            if (oldEmailOTP != null)
            {
                oldEmailOTP.IsActive = false;
                tableManager.UpdateEntity(oldEmailOTP);
            }

            emailOTP.PartitionKey = "ExpenseManage";
            emailOTP.RowKey = GenericLogic.IstNow.TimeStamp().ToString();
            emailOTP.OTP = new Random().Next(10000, 99999);
            emailOTP.IsActive = true;

            //Send mail
            string filePath = Server.MapPath("~/OTP_Mail.html");
            string html = string.Empty;
            if (System.IO.File.Exists(filePath))
            {
                html = System.IO.File.ReadAllText(filePath);
                html = html.Replace("{OTP}", emailOTP.OTP.ToString());
            }
            MailLogic.MailApi(emailOTP.UserEmail, "OTP Validation for Expense Management app", html);


            tableManager.InsertEntity(emailOTP);
            return Json(true);
        }

        [HttpPost]
        public ActionResult Index(LoginCredentials login)
        {
            ExecuteTableManager tableManager = new ExecuteTableManager("OTP", WebConfigAppSettingsAccess.AzureStorageConnectionString);
            EmailOTP emailOTP = tableManager.RetrieveEntity<EmailOTP>("PartitionKey eq 'ExpenseManage' " +
                                                        " and UserEmail eq '" + login.UserEmail + "' " +
                                                        " and IsActive eq true").FirstOrDefault();

            if (emailOTP.UserEmail == login.UserEmail
                    || emailOTP.OTP.ToString() == login.Password)
            {
                emailOTP.IsActive = false;
                tableManager.UpdateEntity(emailOTP);

                login.Password = null;
                Response.Cookies.Add(new HttpCookie("Credential")
                {
                    Value = JsonConvert.SerializeObject(login),
                    Expires = DateTime.Now.AddHours(1)
                });
                return RedirectToAction("Index", "Home", new { id = string.Empty });
            }
            else
            {
                TempData["success"] = "OTP is invalid!!";
                return RedirectToAction("Index", "Authenticate", new { id = string.Empty });
            }
        }
    }    
}