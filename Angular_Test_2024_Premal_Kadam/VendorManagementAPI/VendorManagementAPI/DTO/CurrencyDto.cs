﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace VendorManagementAPI.DTO
{
    
    public class CurrencyDto
    {
        public int CurrencyId { get; set; }

        [Required(ErrorMessage = "Currency name cannot be blank!!!")]
        [MinLength(4, ErrorMessage = "Currency name should be at least 4 characters long.")]
        public string CurrencyName { get; set; }

        [Required(ErrorMessage = "Currency code cannot be blank!!!")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Currency code should be three characters long.")]
        [RegularExpression(@"^[A-Z]+$", ErrorMessage = "Currency code should be in uppercase and should not contains digits.")]
        public string CurrencyCode { get; set; }



    }
}


//throw new Exception(