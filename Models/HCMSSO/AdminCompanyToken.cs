using System;
using System.Collections.Generic;

namespace API_Net8_OData.Models.HCMSSO;

public partial class AdminCompanyToken
{
    public int AdminId { get; set; }

    public int CompanyId { get; set; }

    public int EmployeeId { get; set; }

    public string? Token { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime ExpirationDate { get; set; }
}
