using System;
using System.Collections.Generic;

namespace SPPF_API.Models;

public partial class AlarmSetting
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Value { get; set; }

    public string DeviceId { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string Description { get; set; } = null!;

    public bool IsEnable { get; set; }

    public string Operator { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<AlarmRecord> AlarmRecords { get; set; } = new List<AlarmRecord>();

    public virtual Device Device { get; set; } = null!;
}
