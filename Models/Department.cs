using System;
using System.Collections.Generic;

namespace SPPF_API.Models;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
