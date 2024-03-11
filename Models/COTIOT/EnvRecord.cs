using System;
using System.Collections.Generic;

namespace SPPF_API.Models.COTIOT;

public partial class EnvRecord
{
    public long Id { get; set; }

    public double Temperature { get; set; }

    public double Humidity { get; set; }

    public string DeviceId { get; set; } = null!;

    public DateTime Time { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Device Device { get; set; } = null!;
}
