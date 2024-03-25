using System;
using System.Collections.Generic;

namespace SPPF_API.Models.test;

public partial class AlarmSetting
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double? Max { get; set; }

    public double? Min { get; set; }

    public bool Enabled { get; set; }

    public string DeviceId { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<AlarmRecord> AlarmRecords { get; set; } = new List<AlarmRecord>();

    public virtual Device Device { get; set; } = null!;
}
