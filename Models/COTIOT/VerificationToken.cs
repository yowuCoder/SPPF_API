using System;
using System.Collections.Generic;

namespace SPPF_API.Models.COTIOT;

public partial class VerificationToken
{
    public string Identifier { get; set; } = null!;

    public string Token { get; set; } = null!;

    public DateTime Expires { get; set; }
}
