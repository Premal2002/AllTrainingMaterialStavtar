using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace VendorManagementAPI.DTO
{

    public class VendorDto
    {
        public int VendorId { get; set; }
        [Required(ErrorMessage = "Vendor long name cannot be blank!!!")]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "Vendor long name cannot contain numbers!!!")]
        public string VendorLongName { get; set; }

        [Required(ErrorMessage = "Vendor code cannot be blank!!!")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*[0-9])[A-Za-z0-9_-]{3,10}$", ErrorMessage = "Vendor code must be alphanumeric")]
        public string VendorCode { get; set; }

        [Required(ErrorMessage = "Phone number cannot be blank!!!")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number should be 10 digits long.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Phone number should be digits only.")]
        public string VendorPhoneNumber { get; set; }

        [Required(ErrorMessage = "Email cannot be blank!!!")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string VendorEmail { get; set; }

        [Required(ErrorMessage = "Vendor Status cannot be blank!!!")]
        public bool IsActive { get; set; }

    }
}


//throw new Exception(