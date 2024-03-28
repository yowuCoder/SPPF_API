using System;
using System.Collections.Generic;

namespace SPPF_API.Models.ver03281700;

public partial class SpeedRecord
{
    public long Id { get; set; }

    public double Speed { get; set; }

    public string DeviceId { get; set; } = null!;

    public DateTime Time { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Device Device { get; set; } = null!;
}
