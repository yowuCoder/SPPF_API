using System;
using System.Collections.Generic;

namespace SPPF_API.Models;

public partial class User
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? Email { get; set; }

    public DateTime? EmailVerified { get; set; }

    public string? Image { get; set; }

    public string? Password { get; set; }

    public int? DepartmentId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual Department? Department { get; set; }

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
