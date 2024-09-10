using System;
using System.Collections.Generic;

namespace API_Net8_OData.Models.HcmTimecheck;

public partial class WorkingDay
{
    public long Id { get; set; }

    public int CompanyId { get; set; }

    public int StatusId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public long ParentId { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime ModifiedOn { get; set; }

    public sbyte? EnableDelays { get; set; }

    public ulong? WebAllowed { get; set; }

    public ulong? MobileAllowed { get; set; }
}
