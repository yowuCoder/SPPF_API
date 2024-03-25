using System;
using System.Collections.Generic;

namespace SPPF_API.Models.test;

public partial class WorkOrder
{
    public int Id { get; set; }

    public string OrderId { get; set; } = null!;

    public string OrderName { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string Line { get; set; } = null!;

    public double Number { get; set; }

    public double ProductNumber { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
