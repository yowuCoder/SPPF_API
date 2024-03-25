using System;
using System.Collections.Generic;

namespace SPPF_API.Models.test;

public partial class PlcSetting
{
    public int Id { get; set; }

    public string Ip { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Protocol { get; set; } = null!;

    public double Second { get; set; }

    public bool Enable { get; set; }

    public string? DeviceId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Device? Device { get; set; }
}
