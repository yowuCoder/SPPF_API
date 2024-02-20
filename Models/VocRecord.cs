using System;
using System.Collections.Generic;

namespace SPPF_API.Models;

public partial class VocRecord
{
    public int Id { get; set; }

    public double Voc { get; set; }

    public DateTime Time { get; set; }

    public DateTime CreatedAt { get; set; }

    public string DeviceId { get; set; } = null!;

    public virtual Device Device { get; set; } = null!;
}
