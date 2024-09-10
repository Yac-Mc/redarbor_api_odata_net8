using System;
using System.Collections.Generic;

namespace API_Net8_OData.Models.HCMSSO;

public partial class OnboardingBusinessToken
{
    public int Id { get; set; }

    public int BusinessId { get; set; }

    public string Token { get; set; } = null!;
}
