using System.ComponentModel.DataAnnotations.Schema;

namespace API_Net8_OData.Models.HcmTimecheck;

public partial class WorkingDayAssigment
{
    public long Id { get; set; }

    public int CompanyId { get; set; }

    public int EmployeeId { get; set; }

    [ForeignKey("WorkingDay")]
    public long WorkingDayId { get; set; }

    public int StatusId { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime ModifiedOn { get; set; }

    public ulong IsImmediately { get; set; }

    public DateTime? AuditCreatedOn { get; set; }

    public DateTime? AuditModifiedOn { get; set; }

    public long? AuditEmployeeId { get; set; }

    public virtual WorkingDay? WorkingDay { get; set; }
}
