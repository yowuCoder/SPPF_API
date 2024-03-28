using System;
using System.Collections.Generic;

namespace SPPF_API.Models.ver03281700;

public partial class ViscosityRecord
{
    public long Id { get; set; }

    public double Viscosity { get; set; }

    public DateTime Time { get; set; }

    public DateTime CreatedAt { get; set; }
}
