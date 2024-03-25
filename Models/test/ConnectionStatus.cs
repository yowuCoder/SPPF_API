using System;
using System.Collections.Generic;

namespace SPPF_API.Models.test;

public partial class ConnectionStatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }
}
