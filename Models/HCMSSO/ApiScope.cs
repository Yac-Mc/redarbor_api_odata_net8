using System;
using System.Collections.Generic;

namespace API_Net8_OData.Models.HCMSSO;

public partial class ApiScope
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Configuration { get; set; }

    public int? Status { get; set; }
}
