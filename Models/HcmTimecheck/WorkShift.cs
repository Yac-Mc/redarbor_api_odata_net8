using System;
using System.Collections.Generic;

namespace API_Net8_OData.Models.HcmTimecheck;

public partial class WorkShift
{
    public long Id { get; set; }

    public int CompanyId { get; set; }

    public int StatusId { get; set; }

    public string? Name { get; set; }

    public int DisplayClass { get; set; }

    public DateTime DateStart { get; set; }

    public DateTime? DateEnd { get; set; }

    public string? WorkingdaySequence { get; set; }

    public int? CurrentWorkingday { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime ModifiedOn { get; set; }

    public int FrequencyId { get; set; }

    public DateTime? LastExecute { get; set; }

    public DateTime? EffectiveDate { get; set; }
}
