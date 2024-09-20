namespace CodeFirstTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Vendor
    {
        [Key] // Specifies that this is the primary key
        public int VendorId { get; set; }

        [Required] // Ensures that this field is not null
        [StringLength(100)] // Sets the maximum length for this field
        public string Name { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [Required]
        [Phone] // Ensures that this is a valid phone number format
        public string ContactNumber { get; set; }

        // Navigation property: one vendor can have many invoices
        public virtual ICollection<Invoice> Invoices { get; set; }
    }

}
