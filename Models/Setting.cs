using System;
using System.Collections.Generic;

namespace SPPF_API.Models;

public partial class Setting
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Value { get; set; } = null!;

    public string DeviceId { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Device Device { get; set; } = null!;
}
