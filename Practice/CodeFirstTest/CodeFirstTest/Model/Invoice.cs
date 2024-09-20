using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstTest.Model
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        [Required]
        [ForeignKey("Vendor")] // Specifies the foreign key relationship
        public int VendorId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime InvoiceReceivedDate { get; set; }

        [Required]
        public DateTime InvoiceDueDate { get; set; }

        [Required]
        public bool IsActive { get; set; }


        // Navigation property to the Vendor entity
        public virtual Vendor Vendor { get; set; }

        // Navigation property: one invoice can be in one currency
        [ForeignKey("Currency")]
        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
    }

}
