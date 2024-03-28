using System;
using System.Collections.Generic;

namespace SPPF_API.Models.ver03281700;

public partial class ConnectionStatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }

    public string Ip { get; set; } = null!;
}
