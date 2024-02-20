using System;
using System.Collections.Generic;

namespace SPPF_API.Models;

public partial class ViscosityRecord
{
    public int Id { get; set; }

    public double Viscosity { get; set; }

    public DateTime Time { get; set; }

    public DateTime CreatedAt { get; set; }
}
