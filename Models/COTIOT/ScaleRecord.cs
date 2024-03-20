using System;
using System.Collections.Generic;

namespace SPPF_API.Models.COTIOT;

public partial class ScaleRecord
{
    public long Id { get; set; }

    public string Address { get; set; } = null!;

    public string Line { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Value { get; set; } = null!;

    public DateTime Time { get; set; }

    public DateTime CreatedAt { get; set; }
}
