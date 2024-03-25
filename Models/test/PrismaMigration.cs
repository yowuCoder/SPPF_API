using System;
using System.Collections.Generic;

namespace SPPF_API.Models.test;

public partial class PrismaMigration
{
    public string Id { get; set; } = null!;

    public string Checksum { get; set; } = null!;

    public DateTimeOffset? FinishedAt { get; set; }

    public string MigrationName { get; set; } = null!;

    public string? Logs { get; set; }

    public DateTimeOffset? RolledBackAt { get; set; }

    public DateTimeOffset StartedAt { get; set; }

    public int AppliedStepsCount { get; set; }
}
