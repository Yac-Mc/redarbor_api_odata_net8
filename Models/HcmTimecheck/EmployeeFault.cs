using System;
using System.Collections.Generic;

namespace API_Net8_OData.Models.HcmTimecheck;

public partial class EmployeeFault
{
    public long EmployeeId { get; set; }

    public DateTime FaultOn { get; set; }

    public long TimecheckId { get; set; }

    public int StatusId { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime ModifiedOn { get; set; }
}
