using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VendorManagementAPI
{
    [Table("Invoice")]
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceId { get; set; }
        [Required(ErrorMessage = "Invoice number cannot be blank!!!")]
        public int InvoiceNumber { get; set; }

        [Required(ErrorMessage = "Invoice currency is required!!!")]
        public int InvoiceCurrencyId { get; set; }

        [Required(ErrorMessage = "Vendor is required!!!")]
        public int VendorId { get; set; }

        [Required(ErrorMessage = "Invoice amount date is required!!!")]
        public decimal InvoiceAmount { get; set; }
        [Required(ErrorMessage = "Invoice received date is required!!!")]
        public DateTime InvoiceReceivedDate { get; set; }

        [Required(ErrorMessage = "Invoice due date is required!!!")]
        public DateTime InvoiceDueDate { get; set; }

        public bool IsActive { get; set; }




    }
}


//throw new Exception(