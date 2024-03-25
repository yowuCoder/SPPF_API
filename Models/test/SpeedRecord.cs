﻿using System;
using System.Collections.Generic;

namespace SPPF_API.Models.test;

public partial class SpeedRecord
{
    public long Id { get; set; }

    public double Speed { get; set; }

    public string DeviceId { get; set; } = null!;

    public DateTime Time { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Device Device { get; set; } = null!;
}
