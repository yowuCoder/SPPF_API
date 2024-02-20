using System;
using System.Collections.Generic;

namespace SPPF_API.Models;

public partial class EnvRecord
{
    public int Id { get; set; }

    public double Temperature { get; set; }

    public double Humidity { get; set; }

    public DateTime Time { get; set; }

    public DateTime CreatedAt { get; set; }

    public string DeviceId { get; set; } = null!;

    public virtual Device Device { get; set; } = null!;
}
