using System;
using System.Collections.Generic;

namespace API_Net8_OData.Models.HcmTimecheck;

public partial class CheckOutType
{
    public int Id { get; set; }

    public int CompanyId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int ShowOrder { get; set; }

    public sbyte StatusId { get; set; }

    public int CheckOutStandardType { get; set; }

    public int CheckOutShowBehaviour { get; set; }

    public string? Icon { get; set; }

    public string? Class { get; set; }

    public DateTime CreatedOn { get; set; }
}
