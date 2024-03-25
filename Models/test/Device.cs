using System;
using System.Collections.Generic;

namespace SPPF_API.Models.test;

public partial class Device
{
    public int Id { get; set; }

    public string DeviceId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Line { get; set; }

    public string? OfficeGroup { get; set; }

    public string? Description { get; set; }

    public bool Enable { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? CategoryId { get; set; }

    public virtual ICollection<AlarmSetting> AlarmSettings { get; set; } = new List<AlarmSetting>();

    public virtual Category? Category { get; set; }

    public virtual ICollection<OperatorRecord> OperatorRecords { get; set; } = new List<OperatorRecord>();

    public virtual ICollection<PlcSetting> PlcSettings { get; set; } = new List<PlcSetting>();

    public virtual ICollection<Setting> Settings { get; set; } = new List<Setting>();

    public virtual ICollection<SpeedRecord> SpeedRecords { get; set; } = new List<SpeedRecord>();

    public virtual ICollection<VocRecord> VocRecords { get; set; } = new List<VocRecord>();

    public virtual ICollection<WeightRecord> WeightRecords { get; set; } = new List<WeightRecord>();

    public virtual ICollection<WmvRecord> WmvRecords { get; set; } = new List<WmvRecord>();
}
