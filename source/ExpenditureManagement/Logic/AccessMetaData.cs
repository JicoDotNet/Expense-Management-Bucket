using Newtonsoft.Json;
using System;
using System.IO;
using ExpenditureManagement.Models;
using System.Collections.Generic;

namespace ExpenditureManagement.Logic
{
    public class ReadMetaData
    {
        public static string _jsonPath = "~/JsonMetaData.json";

        public static ExpensesTypes GetExpensesTypes()
        {
            try
            {
                string filePath = System.Web.HttpContext.Current.Server.MapPath(_jsonPath);

                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    JsonMetaDataModel jsonObject = JsonConvert.DeserializeObject<JsonMetaDataModel>(json);

                    if (jsonObject != null
                        && jsonObject.ExpensesTypes != null
                        && jsonObject.ExpensesTypes.Count > 0)
                    {
                        ExpensesTypes expensesTypes = new ExpensesTypes();
                        foreach(string expensesType in jsonObject.ExpensesTypes)
                        {
                            expensesTypes.Add(new ExpensesType() { ExpensesTypeName = expensesType });
                        }
                        return expensesTypes;
                    }
                    else
                    {
                        throw new NullReferenceException("ExpensesTypes is not available in JSON file.");
                    }
                }
                else
                {
                    throw new FileNotFoundException("Meta Data Json file not found", "");
                }
            }
            catch (FileNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static TransactionTypes GetTransactionTypes()
        {
            try
            {
                string filePath = System.Web.HttpContext.Current.Server.MapPath(_jsonPath);

                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    JsonMetaDataModel jsonObject = JsonConvert.DeserializeObject<JsonMetaDataModel>(json);

                    if (jsonObject != null
                        && jsonObject.TransactionTypes != null
                        && jsonObject.TransactionTypes.Count > 0)
                    {
                        TransactionTypes transactionTypes = new TransactionTypes();
                        foreach (string transactionType in jsonObject.TransactionTypes)
                        {
                            transactionTypes.Add(new TransactionType() { TransactionTypeName = transactionType });
                        }
                        return transactionTypes;
                    }
                    else
                    {
                        throw new NullReferenceException("TransactionTypes is not available in JSON file.");
                    }
                }
                else
                {
                    throw new FileNotFoundException("Meta Data Json file not found", "");
                }
            }
            catch (FileNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string[] GetBackgroundColor()
        {
            try
            {
                string filePath = System.Web.HttpContext.Current.Server.MapPath(_jsonPath);

                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    JsonMetaDataModel jsonObject = JsonConvert.DeserializeObject<JsonMetaDataModel>(json);

                    if (jsonObject != null
                        && jsonObject.BackgroundColors != null
                        && jsonObject.BackgroundColors.Length > 0)
                    {
                        return Shuffle(jsonObject.BackgroundColors);
                    }
                    else
                    {
                        throw new NullReferenceException("BackgroundColors is not available in JSON file.");
                    }
                }
                else
                {
                    throw new FileNotFoundException("Meta Data Json file not found", "");
                }
            }
            catch (FileNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<int> GetYears()
        {
            try
            {
                string filePath = System.Web.HttpContext.Current.Server.MapPath(_jsonPath);

                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    JsonMetaDataModel jsonObject = JsonConvert.DeserializeObject<JsonMetaDataModel>(json);

                    if (jsonObject != null
                        && jsonObject.StartingYear != null
                        && jsonObject.StartingYear < GenericLogic.IstNow.Year)
                    {
                        List<int> years = new List<int>();
                        for(int i = jsonObject.StartingYear.Value; i < GenericLogic.IstNow.Year + 1; i++)
                        {
                            years.Add(i);
                        }

                        return years;
                    }
                    else
                    {
                        return new List<int>() { GenericLogic.IstNow.Year };
                    }
                }
                else
                {
                    throw new FileNotFoundException("Meta Data Json file not found", "");
                }
            }
            catch (FileNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static T[] Shuffle<T>(T[] array)
        {
            var rng = new Random();
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
            return array;
        }
    }
}
