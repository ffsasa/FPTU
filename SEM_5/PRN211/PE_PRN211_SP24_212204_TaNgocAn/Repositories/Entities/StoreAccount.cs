using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class StoreAccount
{
    public int UserId { get; set; }

    public string Password { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string? Email { get; set; }

    public int? Role { get; set; }
}
