using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class Vendor
{
    public int VendorId { get; set; }

    public string? VendorName { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
