using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace VendorManagementAPI
{
    [Table("Currency")]
    public class Currency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CurrencyId { get; set; }

        [Required(ErrorMessage = "Currency name cannot be blank!!!")]
        [MinLength(4, ErrorMessage = "Currency name should be at least 4 characters long.")]
        public string CurrencyName { get; set; }

        [Required(ErrorMessage = "Currency code cannot be blank!!!")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Currency code should be three characters long.")]
        [RegularExpression(@"^[A-Z]+$", ErrorMessage = "Currency code should be in uppercase and should not contains digits.")]
        public string CurrencyCode { get; set; }

        public static List<Currency> currencyList = new List<Currency>()
        {
            new Currency(){CurrencyId = 1, CurrencyName = "rupee", CurrencyCode = "INR"},
            new Currency(){CurrencyId = 2, CurrencyName = "dollar", CurrencyCode = "USD"},
            new Currency(){CurrencyId = 3, CurrencyName = "euro", CurrencyCode = "EUR"},
            new Currency(){CurrencyId = 4, CurrencyName = "pound", CurrencyCode = "GBP"},
            new Currency(){CurrencyId = 5, CurrencyName = "yen", CurrencyCode = "JPY"}
        };

        
    }
}


//throw new Exception(