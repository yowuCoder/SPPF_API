﻿using System;
using System.Collections.Generic;

namespace SPPF_API.Models.COTIOT;

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
    [System.Text.Json.Serialization.JsonIgnoreAttribute]

    public virtual ICollection<AlarmSetting> AlarmSettings { get; set; } = new List<AlarmSetting>();

    [System.Text.Json.Serialization.JsonIgnoreAttribute]
    public virtual Category? Category { get; set; }

    [System.Text.Json.Serialization.JsonIgnoreAttribute]
   // public virtual ICollection<EnvRecord> EnvRecords { get; set; } = new List<EnvRecord>();
    //[System.Text.Json.Serialization.JsonIgnoreAttribute]

    public virtual ICollection<OperatorRecord> OperatorRecords { get; set; } = new List<OperatorRecord>();

    [System.Text.Json.Serialization.JsonIgnoreAttribute]
    public virtual ICollection<PlcSetting> PlcSettings { get; set; } = new List<PlcSetting>();

    [System.Text.Json.Serialization.JsonIgnoreAttribute]
    public virtual ICollection<Setting> Settings { get; set; } = new List<Setting>();

    [System.Text.Json.Serialization.JsonIgnoreAttribute]
    public virtual ICollection<SpeedRecord> SpeedRecords { get; set; } = new List<SpeedRecord>();

    [System.Text.Json.Serialization.JsonIgnoreAttribute]
    public virtual ICollection<VocRecord> VocRecords { get; set; } = new List<VocRecord>();

    [System.Text.Json.Serialization.JsonIgnoreAttribute]
    public virtual ICollection<WeightRecord> WeightRecords { get; set; } = new List<WeightRecord>();

    [System.Text.Json.Serialization.JsonIgnoreAttribute]
    public virtual ICollection<WmvRecord> WmvRecords { get; set; } = new List<WmvRecord>();
}
