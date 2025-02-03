using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public decimal? Price { get; set; }

    public DateOnly? ExpiredDate { get; set; }

    public DateOnly? ManufactureDate { get; set; }

    public int? Quantity { get; set; }

    public string? Description { get; set; }

    public int? VendorId { get; set; }

    public virtual Vendor? Vendor { get; set; }
}
