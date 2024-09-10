using System;
using System.Collections.Generic;

namespace API_Net8_OData.Models.HCMSSO;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public sbyte StatusId { get; set; }

    public sbyte? IsAdmin { get; set; }
}
