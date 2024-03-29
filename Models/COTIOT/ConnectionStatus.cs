﻿using System;
using System.Collections.Generic;

namespace SPPF_API.Models.COTIOT;

public partial class ConnectionStatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool Status { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string Ip { get; set; } = null!;
}
