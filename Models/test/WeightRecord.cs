using System;
using System.Collections.Generic;

namespace SPPF_API.Models.test;

public partial class WeightRecord
{
    public long Id { get; set; }

    public double Weight { get; set; }

    public string DeviceId { get; set; } = null!;

    public DateTime Time { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Device Device { get; set; } = null!;
}
