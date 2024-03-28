using System;
using System.Collections.Generic;

namespace SPPF_API.Models.ver03281700;

public partial class SolidRecord
{
    public long Id { get; set; }

    public double Solid { get; set; }

    public DateTime Time { get; set; }

    public DateTime CreatedAt { get; set; }
}
