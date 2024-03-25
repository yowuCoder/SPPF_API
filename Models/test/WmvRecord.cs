using System;
using System.Collections.Generic;

namespace SPPF_API.Models.test;

public partial class WmvRecord
{
    public long Id { get; set; }

    public int Number { get; set; }

    public DateTime ProductTime { get; set; }

    public string DeviceId { get; set; } = null!;

    public DateTime Time { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Device Device { get; set; } = null!;
}
