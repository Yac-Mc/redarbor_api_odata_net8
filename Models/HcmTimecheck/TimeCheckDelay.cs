using System;
using System.Collections.Generic;

namespace API_Net8_OData.Models.HcmTimecheck;

public partial class TimeCheckDelay
{
    public int Id { get; set; }

    public int CompanyId { get; set; }

    public string? Comments { get; set; }

    public sbyte StatusId { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime ModifiedOn { get; set; }

    public int ApprovedBy { get; set; }

    public int EmployeeId { get; set; }

    public int? DelaySettingsId { get; set; }

    public DateTime? PlannedHourUtc { get; set; }

    public long? PlannedHourLong { get; set; }

    public DateTime? RealHourUtc { get; set; }

    public long? RealHourLong { get; set; }
}
