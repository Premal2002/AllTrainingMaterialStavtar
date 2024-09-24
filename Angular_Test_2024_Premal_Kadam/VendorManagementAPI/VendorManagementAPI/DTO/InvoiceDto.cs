using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text.Json.Serialization;
using VendorManagementAPI.DTO;
using VendorManagementAPI.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VendorManagementAPI.DTO
{

    public class InvoiceDto
    {
        public int InvoiceId { get; set; }
        [Required(ErrorMessage = "Invoice number cannot be blank!!!")]
        public int InvoiceNumber { get; set; }

        [Required(ErrorMessage = "Invoice currency is required!!!")]
        public int CurrencyId { get; set; }

        [Required(ErrorMessage = "Vendor is required!!!")]
        public int VendorId { get; set; }

        [Required(ErrorMessage = "Invoice amount date is required!!!")]
        public decimal InvoiceAmount { get; set; }
        [Required(ErrorMessage = "Invoice received date is required!!!")]
        public DateTime InvoiceReceivedDate { get; set; }

        [Required(ErrorMessage = "Invoice due date is required!!!")]
        [DueDateAfterReceivedDate(ErrorMessage = "Invoice due date must be on or after the invoice received date.")]
        public DateTime InvoiceDueDate { get; set; }

        public bool IsActive { get; set; }





    }
}


public class DueDateAfterReceivedDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var invoice = (InvoiceDto)validationContext.ObjectInstance;

        if (invoice.InvoiceDueDate < invoice.InvoiceReceivedDate)
        {
            return new ValidationResult("Invoice due date cannot be earlier than the received date.");
        }

        return ValidationResult.Success;
    }
}

//throw new Exception(