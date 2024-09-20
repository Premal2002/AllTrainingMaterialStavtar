using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstTest.Model
{
    [Table("Currency")]
    public class Currency
    {

        private List<Currency> currencyList;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CurrencyId { get; set; }

        [Required]
        [StringLength(3)] 
        public string CurrencyCode { get; set; }

        [Required]
        [StringLength(50)]
        public string CurrencyName { get; set; }

        public List<Currency> GetAllCurrency(List<Currency> currencyList)
        {
            if (currencyList.Count  == 0)
            {
                throw new Exception("Currency List is empty!!!");
            }
            return currencyList;
        }


        public Currency GetCurrencyByCode(string cCode, List<Currency> currencyList)
        {
            Currency currency = currencyList.Find(c => c.CurrencyCode == cCode);
            if (currency != null)
            {
                return currency;
            }
            throw new Exception("Currency with code " + cCode + " is not present");
        }

        public string AddCurrency(Currency currency, List<Currency> currencyList)
        {

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

        // Navigation property: one currency can be used in many invoices
        //public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
