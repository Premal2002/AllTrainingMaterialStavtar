using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace VendorManagementAPI.Models
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

        [JsonIgnore]
        public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();


    }
}


//throw new Exception(