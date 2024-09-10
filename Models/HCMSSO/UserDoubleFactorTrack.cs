using System;
using System.Collections.Generic;

namespace API_Net8_OData.Models.HCMSSO;

public partial class UserDoubleFactorTrack
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? Uid { get; set; }

    public int CompanyId { get; set; }
}
