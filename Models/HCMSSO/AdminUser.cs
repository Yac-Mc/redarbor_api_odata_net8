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


public static class AdminUserEndpoints
{
    public static void MapAdminUserEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/AdminUser").WithTags(nameof(AdminUser));

        group.MapGet("/", async (HcmSsoContext db) =>
        {
            return await db.AdminUsers.ToListAsync();
        })
        .WithName("GetAllAdminUsers")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<AdminUser>, NotFound>> (int id, HcmSsoContext db) =>
        {
            return await db.AdminUsers.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is AdminUser model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetAdminUserById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, AdminUser adminUser, HcmSsoContext db) =>
        {
            var affected = await db.AdminUsers
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, adminUser.Id)
                  .SetProperty(m => m.Password, adminUser.Password)
                  .SetProperty(m => m.Email, adminUser.Email)
                  .SetProperty(m => m.StatusId, adminUser.StatusId)
                  .SetProperty(m => m.DateAdd, adminUser.DateAdd)
                  .SetProperty(m => m.DateMod, adminUser.DateMod)
                  .SetProperty(m => m.DateDel, adminUser.DateDel)
                  .SetProperty(m => m.ChangePasswordAttempts, adminUser.ChangePasswordAttempts)
                  .SetProperty(m => m.DateChangePassword, adminUser.DateChangePassword)
                  .SetProperty(m => m.Name, adminUser.Name)
                  .SetProperty(m => m.PreferedName, adminUser.PreferedName)
                  .SetProperty(m => m.FirstLastName, adminUser.FirstLastName)
                  .SetProperty(m => m.SecondLastName, adminUser.SecondLastName)
                  .SetProperty(m => m.RoleId, adminUser.RoleId)
                  .SetProperty(m => m.LoginAttempts, adminUser.LoginAttempts)
                  .SetProperty(m => m.Portal, adminUser.Portal)
                  );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateAdminUser")
        .WithOpenApi();

        group.MapPost("/", async (AdminUser adminUser, HcmSsoContext db) =>
        {
            db.AdminUsers.Add(adminUser);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/AdminUser/{adminUser.Id}", adminUser);
        })
        .WithName("CreateAdminUser")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, HcmSsoContext db) =>
        {
            var affected = await db.AdminUsers
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteAdminUser")
        .WithOpenApi();
    }
}