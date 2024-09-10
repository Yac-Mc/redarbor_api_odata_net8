using System;
using System.Collections.Generic;

namespace API_Net8_OData.Models.HCMSSO;

public partial class UserPin
{
    public int Id { get; set; }

    public int? CompanyId { get; set; }

    public string? PinNumber { get; set; }

    public int? StatusId { get; set; }

    public DateTime? LastLoginDate { get; set; }
}
