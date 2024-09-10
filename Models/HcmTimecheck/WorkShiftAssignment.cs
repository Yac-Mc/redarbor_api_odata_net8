using System;
using System.Collections.Generic;

namespace API_Net8_OData.Models.HcmTimecheck;

public partial class WorkShiftAssignment
{
    public long Id { get; set; }

    public int CompanyId { get; set; }

    public int WorkshiftId { get; set; }

    public int EmployeeId { get; set; }

    public int StatusId { get; set; }

    public int? DateTo { get; set; }

    public int? DateFrom { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime ModifiedOn { get; set; }
}
