using System;
using System.Collections.Generic;

namespace ShoppingAPI.Model;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? ProductCategory { get; set; }

    public int? ProductPrice { get; set; }

    public bool? ProductIsInStock { get; set; }

   
}
