using System;
using System.Collections.Generic;

namespace API_Net8_OData.Models.HCMSSO;

public partial class ActionUrl
{
    public int Id { get; set; }

    public string? Link { get; set; }

    public string? Action { get; set; }

    public int StatusId { get; set; }

    public int? LevelAccess { get; set; }

    public string? MenuGroup { get; set; }
}
