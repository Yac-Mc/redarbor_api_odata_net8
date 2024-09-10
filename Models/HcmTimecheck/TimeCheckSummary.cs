using System;
using System.Collections.Generic;

namespace API_Net8_OData.Models.HcmTimecheck;

public partial class TimeCheckSummary
{
    public long Id { get; set; }

    public int CompanyId { get; set; }

    public long EmployeeId { get; set; }

    public long DateStart { get; set; }

    public int Extension { get; set; }

    public decimal EstimatedHours { get; set; }

    public decimal RealizedHours { get; set; }

    public decimal MonthlyBalance { get; set; }

    public decimal AccumulatedBalance { get; set; }

    public int StatusId { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime ModifiedOn { get; set; }
}
