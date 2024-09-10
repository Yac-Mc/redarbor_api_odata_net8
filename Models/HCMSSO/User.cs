using System;
using System.Collections.Generic;

namespace API_Net8_OData.Models.HCMSSO;

public partial class User
{
    public int Id { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? Username { get; set; }

    public short StatusId { get; set; }

    public DateTime DateAdd { get; set; }

    public DateTime? DateMod { get; set; }

    public DateTime? DateDel { get; set; }

    public int ChangePasswordAttempts { get; set; }

    public DateTime DateChangePassword { get; set; }

    public int CompanyId { get; set; }

    public int LoginAttempts { get; set; }

    public DateTime? LoginAttemptsDate { get; set; }
}
