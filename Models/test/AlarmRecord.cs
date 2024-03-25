using System;
using System.Collections.Generic;

namespace SPPF_API.Models.test;

public partial class AlarmRecord
{
    public long Id { get; set; }

    public int AlarmId { get; set; }

    public string Status { get; set; } = null!;

    public double Duration { get; set; }

    public DateTime Time { get; set; }

    public string Message { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual AlarmSetting Alarm { get; set; } = null!;
}
