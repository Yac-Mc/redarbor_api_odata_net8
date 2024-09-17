using System;
using System.Collections.Generic;
using API_Net8_OData.DBContext;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;

namespace API_Net8_OData.Models.HCMSSO;

public partial class AdminUser
{
    public int Id { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public short StatusId { get; set; }

    public DateTime? DateAdd { get; set; }

    public DateTime? DateMod { get; set; }

    public DateTime? DateDel { get; set; }

    public int ChangePasswordAttempts { get; set; }

    public DateTime DateChangePassword { get; set; }

    public string? Name { get; set; }

    public string? PreferedName { get; set; }

    public string? FirstLastName { get; set; }

    public string? SecondLastName { get; set; }

    public sbyte? RoleId { get; set; }

    public int LoginAttempts { get; set; }

    public string? Portal { get; set; }
}