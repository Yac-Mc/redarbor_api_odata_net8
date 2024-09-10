using System;
using System.Collections.Generic;
using API_Net8_OData.Models.HCMSSO;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace API_Net8_OData.DBContext;

public partial class HcmSsoContext : DbContext
{
    public HcmSsoContext()
    {
    }

    public HcmSsoContext(DbContextOptions<HcmSsoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActionUrl> ActionUrls { get; set; }

    public virtual DbSet<AdminCompanyToken> AdminCompanyTokens { get; set; }

    public virtual DbSet<AdminUser> AdminUsers { get; set; }

    public virtual DbSet<AdminUserToken> AdminUserTokens { get; set; }

    public virtual DbSet<ApiResource> ApiResources { get; set; }

    public virtual DbSet<ApiScope> ApiScopes { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<FlywaySchemaHistory> FlywaySchemaHistories { get; set; }

    public virtual DbSet<OnboardingBusinessToken> OnboardingBusinessTokens { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RoleAction> RoleActions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserDoubleFactorTrack> UserDoubleFactorTracks { get; set; }

    public virtual DbSet<UserLoginTrack> UserLoginTracks { get; set; }

    public virtual DbSet<UserPin> UserPins { get; set; }

    public virtual DbSet<UserToken> UserTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<ActionUrl>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("action_url")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Action)
                .HasMaxLength(75)
                .HasColumnName("action")
                .UseCollation("utf8mb4_general_ci");
            entity.Property(e => e.LevelAccess)
                .HasDefaultValueSql("'0'")
                .HasColumnName("level_access");
            entity.Property(e => e.Link)
                .HasMaxLength(75)
                .HasColumnName("link")
                .UseCollation("utf8mb4_general_ci");
            entity.Property(e => e.MenuGroup)
                .HasMaxLength(75)
                .HasColumnName("menu_group")
                .UseCollation("utf8mb4_general_ci");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
        });

        modelBuilder.Entity<AdminCompanyToken>(entity =>
        {
            entity.HasKey(e => new { e.AdminId, e.CompanyId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity
                .ToTable("admin_company_token")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Token, "IDX_admin_company_token");

            entity.Property(e => e.AdminId).HasColumnName("admin_id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasColumnName("creation_date");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.ExpirationDate)
                .HasColumnType("datetime")
                .HasColumnName("expiration_date");
            entity.Property(e => e.Token)
                .HasMaxLength(32)
                .HasColumnName("token");
        });

        modelBuilder.Entity<AdminUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("admin_user")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.DateMod, "IDX_admin_user_date_mod");

            entity.HasIndex(e => e.Email, "UK_admin_user_email").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChangePasswordAttempts).HasColumnName("change_password_attempts");
            entity.Property(e => e.DateAdd)
                .HasColumnType("datetime")
                .HasColumnName("date_add");
            entity.Property(e => e.DateChangePassword)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("date_change_password");
            entity.Property(e => e.DateDel)
                .HasColumnType("datetime")
                .HasColumnName("date_del");
            entity.Property(e => e.DateMod)
                .HasColumnType("datetime")
                .HasColumnName("date_mod");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.FirstLastName)
                .HasMaxLength(75)
                .HasColumnName("first_last_name");
            entity.Property(e => e.LoginAttempts).HasColumnName("login_attempts");
            entity.Property(e => e.Name)
                .HasMaxLength(75)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Portal)
                .HasMaxLength(100)
                .HasColumnName("portal");
            entity.Property(e => e.PreferedName)
                .HasMaxLength(75)
                .HasColumnName("prefered_name");
            entity.Property(e => e.RoleId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("role_id");
            entity.Property(e => e.SecondLastName)
                .HasMaxLength(75)
                .HasColumnName("second_last_name");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
        });

        modelBuilder.Entity<AdminUserToken>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity
                .ToTable("admin_user_token")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Token, "IDX_admin_user_token");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_id");
            entity.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasColumnName("creation_date");
            entity.Property(e => e.ExpirationDate)
                .HasColumnType("datetime")
                .HasColumnName("expiration_date");
            entity.Property(e => e.Token)
                .HasMaxLength(32)
                .HasColumnName("token");
            entity.Property(e => e.TokenTypeId).HasColumnName("token_type_id");
        });

        modelBuilder.Entity<ApiResource>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("ApiResource")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Configuration).HasColumnType("json");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Status).HasDefaultValueSql("'2'");
        });

        modelBuilder.Entity<ApiScope>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("ApiScope")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Configuration).HasColumnType("json");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Status).HasDefaultValueSql("'2'");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("Client")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.Name, "Name").IsUnique();

            entity.Property(e => e.Configuration).HasColumnType("json");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Status).HasDefaultValueSql("'2'");
        });

        modelBuilder.Entity<FlywaySchemaHistory>(entity =>
        {
            entity.HasKey(e => e.InstalledRank).HasName("PRIMARY");

            entity.ToTable("flyway_schema_history");

            entity.HasIndex(e => e.Success, "flyway_schema_history_s_idx");

            entity.Property(e => e.InstalledRank)
                .ValueGeneratedNever()
                .HasColumnName("installed_rank");
            entity.Property(e => e.Checksum).HasColumnName("checksum");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.ExecutionTime).HasColumnName("execution_time");
            entity.Property(e => e.InstalledBy)
                .HasMaxLength(100)
                .HasColumnName("installed_by");
            entity.Property(e => e.InstalledOn)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("installed_on");
            entity.Property(e => e.Script)
                .HasMaxLength(1000)
                .HasColumnName("script");
            entity.Property(e => e.Success).HasColumnName("success");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .HasColumnName("type");
            entity.Property(e => e.Version)
                .HasMaxLength(50)
                .HasColumnName("version");
        });

        modelBuilder.Entity<OnboardingBusinessToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("onboarding_business_token");

            entity.HasIndex(e => e.BusinessId, "UX_onboarding_business_token_business_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BusinessId).HasColumnName("business_id");
            entity.Property(e => e.Token)
                .HasColumnType("text")
                .HasColumnName("token");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("role")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description")
                .UseCollation("utf8mb4_general_ci");
            entity.Property(e => e.IsAdmin)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_admin");
            entity.Property(e => e.Name)
                .HasMaxLength(75)
                .HasDefaultValueSql("''")
                .HasColumnName("name")
                .UseCollation("utf8mb4_general_ci");
            entity.Property(e => e.StatusId)
                .HasDefaultValueSql("'2'")
                .HasColumnName("status_id");
        });

        modelBuilder.Entity<RoleAction>(entity =>
        {
            entity.HasKey(e => new { e.RoleId, e.ActionId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity
                .ToTable("role_action")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.ActionId).HasColumnName("action_id");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("user")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.DateMod, "IDX_user_date_mod");

            entity.HasIndex(e => new { e.Email, e.CompanyId }, "ux_email_company").IsUnique();

            entity.HasIndex(e => new { e.Username, e.CompanyId }, "ux_username_company").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChangePasswordAttempts).HasColumnName("change_password_attempts");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.DateAdd)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("date_add");
            entity.Property(e => e.DateChangePassword)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("date_change_password");
            entity.Property(e => e.DateDel)
                .HasColumnType("datetime")
                .HasColumnName("date_del");
            entity.Property(e => e.DateMod)
                .HasColumnType("datetime")
                .HasColumnName("date_mod");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.LoginAttempts).HasColumnName("login_attempts");
            entity.Property(e => e.LoginAttemptsDate)
                .HasColumnType("datetime")
                .HasColumnName("login_attempts_date");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.Username).HasColumnName("username");
        });

        modelBuilder.Entity<UserDoubleFactorTrack>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("user_double_factor_track")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.Uid)
                .HasMaxLength(255)
                .HasColumnName("uid");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<UserLoginTrack>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("user_login_track")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AreaId).HasColumnName("area_id");
            entity.Property(e => e.ClientIp)
                .HasMaxLength(255)
                .HasColumnName("client_ip");
            entity.Property(e => e.Cookie)
                .HasMaxLength(255)
                .HasColumnName("cookie");
            entity.Property(e => e.DateEvent)
                .HasColumnType("datetime")
                .HasColumnName("date_event");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.ResultOfLogin).HasColumnName("result_of_login");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<UserPin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("user_pin")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => new { e.CompanyId, e.PinNumber }, "unique_user_pin_per_company").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.LastLoginDate)
                .HasColumnType("datetime")
                .HasColumnName("last_login_date");
            entity.Property(e => e.PinNumber)
                .HasMaxLength(50)
                .HasColumnName("pin_number");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
        });

        modelBuilder.Entity<UserToken>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity
                .ToTable("user_token")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Token, "IDX_user_token");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_id");
            entity.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasColumnName("creation_date");
            entity.Property(e => e.ExpirationDate)
                .HasColumnType("datetime")
                .HasColumnName("expiration_date");
            entity.Property(e => e.Token)
                .HasMaxLength(32)
                .HasColumnName("token");
            entity.Property(e => e.TokenTypeId).HasColumnName("token_type_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
