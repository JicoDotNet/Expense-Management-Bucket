using DataAccess.AzureStorage;
using ExpenditureManagement.Models;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace ExpenditureManagement.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public object StorageCon = WebConfigurationManager.ConnectionStrings["StorageAccount"].ToString();

        public ActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginCred login)
        {
            if (WebConfigAppSettingsAccess.UserEmail != login.UserName
                    || WebConfigAppSettingsAccess.Password != login.Password)
            {
                TempData["success"] = "Either Email or Password is wrong!!";
                return RedirectToAction("Login", "Home", new { id = string.Empty });
            }
            else
            {
                Response.Cookies.Add(new HttpCookie("cred")
                {
                    Value = login.UserName,
                    Expires = DateTime.Now.AddMonths(11)
                });
                return RedirectToAction("Add", "Home", new { id = string.Empty });
            }            
        }
        
        public ActionResult Logout()
        {
            if (GetCookieValue() != null)
            {
                var c = new HttpCookie("cred")
                {
                    Expires = DateTime.Now.AddDays(-1)
                };
                Response.Cookies.Add(c);
            }
            return RedirectToAction("Login", "Home", new { id = string.Empty });
        }

        public ActionResult Index()
        {
            if (GetCookieValue() != null)
                return View();
            else
            {
                return RedirectToAction("Login", "Home", new { id = string.Empty });
            }
        }

        [HttpGet]
        public JsonResult Tag()
        {
            ExecuteTableManager tableManager = new ExecuteTableManager("Expenses", StorageCon);
            ExpensesModels models = new ExpensesModels
            {
                Expensess = tableManager.RetrieveEntity<Expenses>("PartitionKey eq '" + GetCookieValue() + "' " +
                                                        " and IsDeleted eq false"),
            };
            var t = models.Expensess?.Select(x => x.Details).Distinct().ToArray();
            return Json(models.Expensess?.Select(x => x.Details).Distinct(StringComparer.CurrentCultureIgnoreCase).OrderBy(a => a.ToString()).ToArray(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Bind(int Month, int Year)
        {
            ExecuteTableManager tableManager = new ExecuteTableManager("Expenses", StorageCon);
            DateTime fromDt = new DateTime(Year, Month, 1);
            DateTime ToDt = fromDt.AddMonths(1).AddSeconds(-1);

            //TransactionDate ge datetime'2023-02-28T18:30:00.000Z' and TransactionDate lt datetime'2023-03-31T18:29:58.000Z'
            string Q = "PartitionKey eq '" + GetCookieValue() + "'" +
                " and TransactionDate ge datetime'" + fromDt.ToString("o") + "' " +
                                                                " and TransactionDate lt datetime'" + ToDt.ToString("o") + "'" +
                                                                " and IsDeleted eq false";
            ExpensesModels models = new ExpensesModels
            {
                Expensess = tableManager.RetrieveEntity<Expenses>(Q).OrderByDescending(a => a.TransactionDate).ThenByDescending(n => n.RowKey).ToList(),
            };
            return PartialView("_PartialViewPage", models);
        }

        public ActionResult Add(string id)
        {
            if (GetCookieValue() == null)
                return RedirectToAction("Login", "Home", new { id = string.Empty });

            ExpensesModels models = new ExpensesModels
            {
                ExpensesTypes = new ExecuteTableManager("ExpensesType", StorageCon).RetrieveEntity<ExpensesType>("PartitionKey eq '" + GetCookieValue() + "'").OrderBy(a => a.ExpensesTypeName).ToList(),
                TransactionTypes = new ExecuteTableManager("TransactionType", StorageCon).RetrieveEntity<TransactionType>("PartitionKey eq '" + GetCookieValue() + "'").OrderBy(a => a.TransactionTypeName).ToList()
            };
            if (!string.IsNullOrEmpty(id))
            {
                models.Expenses = new ExecuteTableManager("Expenses", StorageCon)
                                .RetrieveEntity<Expenses>("PartitionKey eq '" + GetCookieValue() + "' " +
                                                "and RowKey eq '" + id + "' and IsDeleted eq false")
                                .FirstOrDefault();
                if (models.Expenses == null)
                {
                    TempData["success"] = "No <b>Record</b> Found!";
                    return RedirectToAction("Index", "Home", new { id = string.Empty });
                }
            }
            return View(models);
        }

        public ActionResult Delete(string id)
        {
            ExecuteTableManager tableManager = new ExecuteTableManager("Expenses", StorageCon);
            if (!string.IsNullOrEmpty(id))
            {
                Expenses expenses = tableManager
                                .RetrieveEntity<Expenses>("PartitionKey eq '" + GetCookieValue() + "' " +
                                                    " and RowKey eq '" + id + "' and IsDeleted eq false")
                                .FirstOrDefault();
                expenses.IsDeleted = true;
                tableManager.InsertEntity(expenses, false);
                TempData["success"] = "Expenses <b>Deleted</b> successfully";
            }
            return RedirectToAction("Index", "Home", new { id = string.Empty });
        }

        

        [HttpPost]
        public ActionResult Add(Expenses expenses)
        {
            ExecuteTableManager tableManager = new ExecuteTableManager("Expenses", StorageCon);
            try
            {
                expenses.TransactionDate = new DateTime(expenses.Year, expenses.Month, expenses.Day);
            }
            catch
            {
                expenses.TransactionDate = GenericLogic.IstNow;
            }
            expenses.PartitionKey = GetCookieValue();
            if (string.IsNullOrEmpty(expenses.RowKey))
            {
                expenses.RowKey = GenericLogic.IstNow.TimeStamp().ToString();
                tableManager.InsertEntity(expenses);
                TempData["success"] = "Expenses <b>added</b> successfully";
                return RedirectToAction("Add", "Home", new { id = string.Empty });
            }
            else
            {
                tableManager.InsertEntity(expenses, false);
                TempData["success"] = "Expenses <b>Edited</b> successfully";
                return RedirectToAction("Index", "Home", new { id = string.Empty });
            }            
        }

        public ActionResult Graph()
        {
            if (GetCookieValue() == null)
                return RedirectToAction("Login", "Home", new { id = string.Empty });
            return View();
        }

        public JsonResult GraphBind(int Month, int Year)
        {
            ExecuteTableManager tableManager = new ExecuteTableManager("ExpensesType", StorageCon);
            GraphModel gModel = new GraphModel
            {
                labels = tableManager.RetrieveEntity<ExpensesType>("PartitionKey eq '" + GetCookieValue() + "' ").Where(a => a.ExpensesTypeName != null).Select(a => a.ExpensesTypeName).ToArray(),
            };

            tableManager = new ExecuteTableManager("Expenses", StorageCon);
            DateTime fromDt = new DateTime(Year, Month, 1);
            DateTime ToDt = fromDt.AddMonths(1).AddSeconds(-1);
            string Q = "PartitionKey eq '" + GetCookieValue() + "' and TransactionDate ge datetime'" + fromDt.ToString("o") + "' " +
                                                                " and TransactionDate lt datetime'" + ToDt.ToString("o") + "'" +
                                                                " and IsDeleted eq false";
            List<Expenses> expenses = tableManager.RetrieveEntity<Expenses>(Q);
            double SumVal = expenses.Select(a => a.Amount).Sum();

            var GroupByExpensesTypeWithAmountSum = expenses.GroupBy(a => a.ExpensesType)
                            .Select(t => new
                            {
                                ExpensesType = t.Key,
                                Amount = t.Sum(a => a.Amount)
                            }).ToList();

            List<int> data = new List<int>();
            List<string> backgroundColor = new List<string>();
            for (int i = 0; i < gModel.labels.Length; i++)
            {
                var gi = GroupByExpensesTypeWithAmountSum.Where(a => a.ExpensesType == gModel.labels[i]).FirstOrDefault();
                if (gi != null)
                    data.Add((int)gi.Amount); 
                else
                    data.Add(0);
                backgroundColor.Add(BackgroundColor.label[i]);
            }

            gModel.datasets = new List<DataSet>
            {
                new DataSet
                {
                    borderWidth = 1,
                    data = data.ToArray(),
                    label = " Total Expenses: ₹" + SumVal + "",
                    backgroundColor = backgroundColor.ToArray(),
                }
            };

            return Json(gModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult WahtsApp()
        {
            if (GetCookieValue() == null)
                return RedirectToAction("Login", "Home", new { id = string.Empty });
            return View();
        }

        [HttpPost]
        public ActionResult WahtsApp(string Number)
        {
            return Redirect("http://wa.me/+91" + Number);
        }

        public string GetCookieValue()
        {
            HttpCookie reqCookies = Request.Cookies["cred"];
            if (reqCookies != null)
            {
                return reqCookies.Value;
            }
            return null;
        }
    }
}