using System;
using System.Collections.Generic;

namespace SPPF_API.Models;

public partial class SolidRecord
{
    public int Id { get; set; }

    public double Solid { get; set; }

    public DateTime Time { get; set; }

    public DateTime CreatedAt { get; set; }
}
