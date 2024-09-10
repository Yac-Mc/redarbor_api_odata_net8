using System;
using System.Collections.Generic;

namespace API_Net8_OData.Models.HCMSSO;

public partial class UserLoginTrack
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? Email { get; set; }

    public sbyte ResultOfLogin { get; set; }

    public sbyte AreaId { get; set; }

    public DateTime DateEvent { get; set; }

    public string? ClientIp { get; set; }

    public string? Cookie { get; set; }
}
