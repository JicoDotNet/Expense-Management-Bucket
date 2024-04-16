using DataAccess.AzureStorage;
using ExpenditureManagement.Logic;
using ExpenditureManagement.Models;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace ExpenditureManagement.Controllers
{
    public class HomeController : BaseController
    {
        [SessionAuthenticate]
        public ActionResult Index(string id)
        {
            ExpensesModels models = new ExpensesModels
            {
                ExpensesTypes = ReadMetaData.GetExpensesTypes(),
                TransactionTypes = ReadMetaData.GetTransactionTypes(),
                Years = ReadMetaData.GetYears(),
            };
            if (!string.IsNullOrEmpty(id))
            {
                models.Expenses = new ExecuteTableManager("Expenses", WebConfigAppSettingsAccess.AzureStorageConnectionString)
                                .RetrieveEntity<Expenses>("PartitionKey eq '" + Credential.UserEmail + "' " +
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

        public PartialViewResult MenuBind()
        {
            if (Credential != null)
            {
                return PartialView("_PartialMenuBindPage", Credential);
            }
            return PartialView("_PartialMenuBindPage", null);
        }

        [SessionAuthenticate]
        public ActionResult Report()
        {
            ExpensesModels models = new ExpensesModels
            {
                Years = ReadMetaData.GetYears(),
            };
            return View(models);
        }

        [HttpGet]
        [SessionAuthenticate]
        public JsonResult Tag()
        {
            ExecuteTableManager tableManager = new ExecuteTableManager("Expenses", WebConfigAppSettingsAccess.AzureStorageConnectionString);
            ExpensesModels models = new ExpensesModels
            {
                Expensess = tableManager.RetrieveEntity<Expenses>("PartitionKey eq '" + Credential.UserEmail + "' " +
                                                        " and IsDeleted eq false"),
            };
            var t = models.Expensess?.Select(x => x.Details).Distinct().ToArray();
            return Json(models.Expensess?.Select(x => x.Details).Distinct(StringComparer.CurrentCultureIgnoreCase).OrderBy(a => a.ToString()).ToArray(), JsonRequestBehavior.AllowGet);
        }

        [SessionAuthenticate]
        public ActionResult Bind(int Month, int Year)
        {
            ExecuteTableManager tableManager = new ExecuteTableManager("Expenses", WebConfigAppSettingsAccess.AzureStorageConnectionString);
            DateTime fromDt = new DateTime(Year, Month, 1);
            DateTime ToDt = fromDt.AddMonths(1).AddSeconds(-1);

            //TransactionDate ge datetime'2023-02-28T18:30:00.000Z' and TransactionDate lt datetime'2023-03-31T18:29:58.000Z'
            string Q = "PartitionKey eq '" + Credential.UserEmail + "'" +
                " and TransactionDate ge datetime'" + fromDt.ToString("o") + "' " +
                                                                " and TransactionDate lt datetime'" + ToDt.ToString("o") + "'" +
                                                                " and IsDeleted eq false";
            ExpensesModels models = new ExpensesModels
            {
                Expensess = tableManager.RetrieveEntity<Expenses>(Q).OrderByDescending(a => a.TransactionDate).ThenByDescending(n => n.RowKey).ToList(),
            };
            return PartialView("_PartialViewPage", models);
        }        

        [SessionAuthenticate]
        public ActionResult Delete(string id)
        {
            ExecuteTableManager tableManager = new ExecuteTableManager("Expenses", WebConfigAppSettingsAccess.AzureStorageConnectionString);
            if (!string.IsNullOrEmpty(id))
            {
                Expenses expenses = tableManager
                                .RetrieveEntity<Expenses>("PartitionKey eq '" + Credential.UserEmail + "' " +
                                                    " and RowKey eq '" + id + "' and IsDeleted eq false")
                                .FirstOrDefault();
                expenses.IsDeleted = true;
                tableManager.InsertEntity(expenses, false);
                TempData["success"] = "Expenses <b>Deleted</b> successfully";
            }
            return RedirectToAction("Index", "Home", new { id = string.Empty });
        }
       

        [SessionAuthenticate, HttpPost]
        public ActionResult Add(Expenses expenses)
        {
            ExecuteTableManager tableManager = new ExecuteTableManager("Expenses", WebConfigAppSettingsAccess.AzureStorageConnectionString);
            try
            {
                expenses.TransactionDate = new DateTime(expenses.Year, expenses.Month, expenses.Day);
            }
            catch
            {
                expenses.TransactionDate = GenericLogic.IstNow;
            }
            expenses.PartitionKey = Credential.UserEmail;
            if (string.IsNullOrEmpty(expenses.RowKey))
            {
                expenses.RowKey = GenericLogic.IstNow.TimeStamp().ToString();
                tableManager.InsertEntity(expenses);
                TempData["success"] = "Expenses <b>added</b> successfully";
                return RedirectToAction("Index", "Home", new { id = string.Empty });
            }
            else
            {
                tableManager.InsertEntity(expenses, false);
                TempData["success"] = "Expenses <b>Edited</b> successfully";
                return RedirectToAction("Index", "Home", new { id = string.Empty });
            }            
        }

        [SessionAuthenticate]
        public ActionResult Graph()
        {
            if (Credential == null)
                return RedirectToAction("Login", "Home", new { id = string.Empty });

            ExpensesModels models = new ExpensesModels
            {
                Years = ReadMetaData.GetYears(),
            };
            return View(models);
        }

        [SessionAuthenticate]
        public JsonResult GraphBind(int Month, int Year)
        {
            ExecuteTableManager tableManager = new ExecuteTableManager("ExpensesType", WebConfigAppSettingsAccess.AzureStorageConnectionString);
            GraphModel gModel = new GraphModel
            {
                labels = ReadMetaData.GetExpensesTypes().Select(a => a.ExpensesTypeName).ToArray(),
            };

            tableManager = new ExecuteTableManager("Expenses", WebConfigAppSettingsAccess.AzureStorageConnectionString);
            DateTime fromDt = new DateTime(Year, Month, 1);
            DateTime ToDt = fromDt.AddMonths(1).AddSeconds(-1);
            string Q = "PartitionKey eq '" + Credential.UserEmail + "' and TransactionDate ge datetime'" + fromDt.ToString("o") + "' " +
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
                backgroundColor.Add(ReadMetaData.GetBackgroundColor()[i]);
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
    }
}