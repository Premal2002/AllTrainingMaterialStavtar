using System.Xml.Linq;

namespace VendorManagementAPI
{
    public class Currency
    {
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }

        public static List<Currency> currencyList = new List<Currency>()
        {
            new Currency(){CurrencyId = 1, CurrencyName = "rupee", CurrencyCode = "INR"},
            new Currency(){CurrencyId = 2, CurrencyName = "dollar", CurrencyCode = "USD"},
            new Currency(){CurrencyId = 3, CurrencyName = "euro", CurrencyCode = "EUR"},
            new Currency(){CurrencyId = 4, CurrencyName = "pound", CurrencyCode = "GBP"},
            new Currency(){CurrencyId = 5, CurrencyName = "yen", CurrencyCode = "JPY"}
        };

        static public int autoCurrencyId { get; set; }

        #region Methods
        public List<Currency> GetAllCurrency()
        {
            if (currencyList.Count == 0)
            {
                throw new Exception("Currency List is empty!!!");
            }
            return currencyList;
        }
        public string AddCurrency(Currency currency)
        {
            #region Auto generated currency Id
            autoCurrencyId = currencyList.Count + 1;
            #endregion

            currency.CurrencyId = autoCurrencyId;

            if (string.IsNullOrWhiteSpace(currency.CurrencyCode))
            {
                throw new Exception("Currency code cannot be blank!!!");
            }
            else if (currencyList.Any(c => c.CurrencyCode == currency.CurrencyCode))
            {
                throw new Exception("Currency already present.");
            }
            else if (currency.CurrencyCode.Length != 3 || currency.CurrencyCode.Any(char.IsDigit))
            {
                throw new Exception("Currency code should be three characters long.");
            }


            if (string.IsNullOrWhiteSpace(currency.CurrencyName))
            {
                throw new Exception("Currency name cannot be blank!!!");
            }
            else if (currency.CurrencyName.Length < 4)
            {
                throw new Exception("Currency name should be atleast 4 charcters long!!!");
            }
            currencyList.Add(currency);
            return "Currency added successfully";
        }

        public string UpdateCurrency(string cCode,Currency currency)
        {
            var tempCurrency = (from c in currencyList
                                where c.CurrencyCode == cCode
                                select c).SingleOrDefault();

            if (tempCurrency != null)
            {

                if (string.IsNullOrWhiteSpace(currency.CurrencyName))
                {
                    throw new Exception("Currency name cannot be blank!!!");
                }
                else if (currency.CurrencyName.Length < 4)
                {
                    throw new Exception("Currency name should be atleast 4 charcters long!!!");
                }
                

                tempCurrency.CurrencyName = currency.CurrencyName;
                return "Currency updated successfully";
            }
            throw new Exception("Currency with currency code " + cCode + " is not present");
        }
        public string DeleteCurrency(string cCode)
        {
            Currency tempCurrency = (from c in currencyList
                                 where c.CurrencyCode == cCode
                                 select c).FirstOrDefault();

            if (tempCurrency != null)
            {
                if (Invoice.invoiceList.Any(i => i.InvoiceCurrencyId == tempCurrency.CurrencyId))
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


//throw new Exception(