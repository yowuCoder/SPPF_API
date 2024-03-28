using System;
using System.Collections.Generic;

namespace SPPF_API.Models.ver03281700;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Device> Devices { get; set; } = new List<Device>();
}
