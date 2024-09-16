using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenderManagementConsole
{
    internal class Currency
    {
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }

        #region methods
        public string AddCurrency(Currency currency, List<Currency> currencyList)
        {
            //Checking if this particular vendor is already there in list

            currencyList.Add(currency);
            return "Currency Added Successfully";

        }

        public string DeleteCurrency(string cCode, List<Currency> currencyList,List<Invoice> invoiceList)
        {
            Currency tempCurrency = (from c in currencyList
                                   where c.CurrencyCode == cCode
                                   select c).FirstOrDefault();

            if (tempCurrency != null)
            {
                if (invoiceList.Any(i => i.InvoiceCurrencyId == tempCurrency.CurrencyId))
                {
                    throw new Exception("This currency is used in current invoices. First clear those invoices then try to remove this currency!!!");
                }
                currencyList.Remove(tempCurrency);
                return "Currency removed successfully";
            }
            throw new Exception("Currency with currency code " + cCode + " is not present");
        }
        
        #endregion
    }
}
