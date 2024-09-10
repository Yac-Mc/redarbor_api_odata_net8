using System;
using System.Collections.Generic;

namespace API_Net8_OData.Models.HCMSSO;

public partial class AdminUserToken
{
    public int UserId { get; set; }

    public string? Token { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime ExpirationDate { get; set; }

    public sbyte TokenTypeId { get; set; }
}
