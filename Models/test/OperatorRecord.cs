using System;
using System.Collections.Generic;

namespace SPPF_API.Models.test;

public partial class OperatorRecord
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Operator { get; set; } = null!;

    public string DeviceId { get; set; } = null!;

    public DateTime Time { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Device Device { get; set; } = null!;
}
