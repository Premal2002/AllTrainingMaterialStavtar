using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text.Json.Serialization;
using VendorManagementAPI.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VendorManagementAPI.Models
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
        [ForeignKey(nameof(Currency))]
        public int CurrencyId { get; set; }

        [Required(ErrorMessage = "Vendor is required!!!")]
        [ForeignKey(nameof(Vendor))]
        public int VendorId { get; set; }

        [Required(ErrorMessage = "Invoice amount date is required!!!")]
        public decimal InvoiceAmount { get; set; }

        [Required(ErrorMessage = "Invoice received date is required!!!")]
        public DateTime InvoiceReceivedDate { get; set; }

        [Required(ErrorMessage = "Invoice due date is required!!!")]
        public DateTime InvoiceDueDate { get; set; }

        public bool IsActive { get; set; }

        [JsonIgnore]
        public virtual Vendor vendor { get; set; }

        [JsonIgnore]
        public virtual Currency currency { get; set; }




    }
}


//throw new Exception(