using API_Net8_OData.Models.HcmTimecheck;
using Microsoft.EntityFrameworkCore;

namespace API_Net8_OData.DBContext;

public partial class HcmTimecheckContext : DbContext
{
    public HcmTimecheckContext(DbContextOptions<HcmTimecheckContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CheckOutType> CheckOutTypes { get; set; }

    public virtual DbSet<DelaySetting> DelaySettings { get; set; }

    public virtual DbSet<EmployeeFault> EmployeeFaults { get; set; }

    public virtual DbSet<FlywaySchemaHistory> FlywaySchemaHistories { get; set; }

    public virtual DbSet<NotificationsSetting> NotificationsSettings { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<SettingsNotification> SettingsNotifications { get; set; }

    public virtual DbSet<TimeCheck> TimeChecks { get; set; }

    public virtual DbSet<TimeCheckDelay> TimeCheckDelays { get; set; }

    public virtual DbSet<TimeCheckSummary> TimeCheckSummaries { get; set; }

    public virtual DbSet<WorkShift> WorkShifts { get; set; }

    public virtual DbSet<WorkShiftAssignment> WorkShiftAssignments { get; set; }

    public virtual DbSet<WorkingDay> WorkingDays { get; set; }

    public virtual DbSet<WorkingDayAssigment> WorkingDayAssigments { get; set; }

    public virtual DbSet<WorkingDaySpec> WorkingDaySpecs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<CheckOutType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("check_out_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CheckOutShowBehaviour).HasColumnName("check_out_show_behaviour");
            entity.Property(e => e.CheckOutStandardType).HasColumnName("check_out_standard_type");
            entity.Property(e => e.Class)
                .HasMaxLength(100)
                .HasColumnName("class");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Icon)
                .HasMaxLength(250)
                .HasColumnName("icon");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasColumnName("name");
            entity.Property(e => e.ShowOrder).HasColumnName("show_order");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
        });

        modelBuilder.Entity<DelaySetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("delay_settings");

            entity.HasIndex(e => new { e.CompanyId, e.StatusId }, "index_delay_settings_company_id_status_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.DelaysToBeFault).HasColumnName("delays_to_be_fault");
            entity.Property(e => e.FrequencyId).HasColumnName("frequency_id");
            entity.Property(e => e.MinutesToBeDelay).HasColumnName("minutes_to_be_delay");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.ValidFrom).HasColumnName("valid_from");
            entity.Property(e => e.ValidTo).HasColumnName("valid_to");
            entity.Property(e => e.WorkingDayId).HasColumnName("working_day_id");
        });

        modelBuilder.Entity<EmployeeFault>(entity =>
        {
            entity.HasKey(e => new { e.EmployeeId, e.TimecheckId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("employee_fault");

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.TimecheckId).HasColumnName("timecheck_id");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.FaultOn)
                .HasColumnType("datetime")
                .HasColumnName("fault_on");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
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

        modelBuilder.Entity<NotificationsSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("notifications_settings");

            entity.HasIndex(e => new { e.CompanyId, e.WorkingDayId }, "ux_notifications_settings").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.NotificationInSeconds).HasColumnName("notification_in_seconds");
            entity.Property(e => e.NotificationInStatusId).HasColumnName("notification_in_status_id");
            entity.Property(e => e.NotificationOutChannels).HasColumnName("notification_out_channels");
            entity.Property(e => e.NotificationOutSeconds).HasColumnName("notification_out_seconds");
            entity.Property(e => e.NotificationOutStatusId).HasColumnName("notification_out_status_id");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.WorkingDayId).HasColumnName("working_day_id");
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.CompanyId, e.ValidToDate })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("settings");

            entity.HasIndex(e => new { e.CompanyId, e.StatusId }, "idx_company_id_status_id");

            entity.HasIndex(e => new { e.CompanyId, e.ValidFromDate, e.ValidToDate, e.StatusId }, "idx_companyid_validdates_statusid");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.ValidToDate).HasColumnName("valid_to_date");
            entity.Property(e => e.AllowedLateTimeCheckMinutes).HasColumnName("allowed_late_time_check_minutes");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.EmployeeReportExportType)
                .HasDefaultValueSql("'1'")
                .HasColumnName("employee_report_export_type");
            entity.Property(e => e.EnableDelays)
                .HasDefaultValueSql("'1'")
                .HasColumnName("enable_delays");
            entity.Property(e => e.EnableNotifications)
                .HasDefaultValueSql("'1'")
                .HasColumnName("enable_notifications");
            entity.Property(e => e.EnableTimeCheckCommentMobile).HasColumnName("enable_time_check_comment_mobile");
            entity.Property(e => e.ExtraHoursRegulationMonths).HasColumnName("extra_hours_regulation_months");
            entity.Property(e => e.LocalizationAppEnabled).HasColumnName("localization_app_enabled");
            entity.Property(e => e.LocalizationAppOption).HasColumnName("localization_app_option");
            entity.Property(e => e.LocalizationControlType).HasColumnName("localization_control_type");
            entity.Property(e => e.LocalizationKioskControlType)
                .HasDefaultValueSql("'0'")
                .HasColumnName("localization_kiosk_control_type");
            entity.Property(e => e.LocalizationKioskOption)
                .HasDefaultValueSql("'0'")
                .HasColumnName("localization_kiosk_option");
            entity.Property(e => e.LocalizationWebControlType).HasColumnName("localization_web_control_type");
            entity.Property(e => e.LocalizationWebOption).HasColumnName("localization_web_option");
            entity.Property(e => e.MinimumMinutesBetweenTimeCheck).HasColumnName("minimum_minutes_between_time_check");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.NumberDaysAllowedEdit).HasColumnName("number_days_allowed_edit");
            entity.Property(e => e.NumberDaysEditAutoApproved).HasColumnName("number_days_edit_auto_approved");
            entity.Property(e => e.PeriodDisplay).HasColumnName("period_display");
            entity.Property(e => e.PeriodDisplayStartDay).HasColumnName("period_display_start_day");
            entity.Property(e => e.PunctualityControlEnabled).HasColumnName("punctuality_control_enabled");
            entity.Property(e => e.PunctualityStrikesAllowed).HasColumnName("punctuality_strikes_allowed");
            entity.Property(e => e.PunctualityStrikesResetDays).HasColumnName("punctuality_strikes_reset_days");
            entity.Property(e => e.RoundExtraHour).HasColumnName("round_extra_hour");
            entity.Property(e => e.RoundNegativeHour).HasColumnName("round_negative_hour");
            entity.Property(e => e.SendTimeCheckErrorSummary).HasColumnName("send_time_check_error_summary");
            entity.Property(e => e.SendTimeCheckSummary).HasColumnName("send_time_check_summary");
            entity.Property(e => e.ShowAccumulatedHours).HasColumnName("show_accumulated_hours");
            entity.Property(e => e.ShowErrorIcon).HasColumnName("show_error_icon");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.SupervisorsVisualizationType)
                .HasDefaultValueSql("'1'")
                .HasColumnName("supervisors_visualization_type");
            entity.Property(e => e.ValidFromDate).HasColumnName("valid_from_date");
        });

        modelBuilder.Entity<SettingsNotification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("settings_notification");

            entity.HasIndex(e => e.CompanyId, "ux_csettings_notification_company").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.DelaysToSupervisorsChannels)
                .HasMaxLength(25)
                .HasColumnName("delays_to_supervisors_channels");
            entity.Property(e => e.DelaysToSupervisorsEnabled)
                .HasColumnType("bit(1)")
                .HasColumnName("delays_to_supervisors_enabled");
            entity.Property(e => e.EndWorkingDayEnabled)
                .HasColumnType("bit(1)")
                .HasColumnName("end_working_day_enabled");
            entity.Property(e => e.EndWorkingDayMinutesToShow).HasColumnName("end_working_day_minutes_to_show");
            entity.Property(e => e.EndWorkingDayOutChannels)
                .HasMaxLength(25)
                .HasColumnName("end_working_day_out_channels");
            entity.Property(e => e.ErrorsToEmployeesChannels)
                .HasMaxLength(25)
                .HasColumnName("errors_to_employees_channels");
            entity.Property(e => e.ErrorsToEmployeesEnabled)
                .HasColumnType("bit(1)")
                .HasColumnName("errors_to_employees_enabled");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.PendingToSupervisorsChannels)
                .HasMaxLength(25)
                .HasColumnName("pending_to_supervisors_channels");
            entity.Property(e => e.PendingToSupervisorsEnabled)
                .HasColumnType("bit(1)")
                .HasColumnName("pending_to_supervisors_enabled");
            entity.Property(e => e.ReportToSupervisorsChannels)
                .HasMaxLength(25)
                .HasColumnName("report_to_supervisors_channels");
            entity.Property(e => e.ReportToSupervisorsEnabled)
                .HasColumnType("bit(1)")
                .HasColumnName("report_to_supervisors_enabled");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
        });

        modelBuilder.Entity<TimeCheck>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("time_check");

            entity.HasIndex(e => new { e.CompanyId, e.EmployeeId, e.TimeCheckDateLong }, "idx_time_check_company_id_employee_id_time_check_date_long");

            entity.HasIndex(e => new { e.CompanyId, e.StatusId, e.CheckDeviceTypeId }, "idx_time_check_company_id_status_id_check_device_type_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CheckDeviceTypeId).HasColumnName("check_device_type_id");
            entity.Property(e => e.CheckTypeId).HasColumnName("check_type_id");
            entity.Property(e => e.CheckoutTypeId).HasColumnName("checkout_type_id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.DelayId).HasColumnName("delay_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.EmployeeNote)
                .HasMaxLength(1000)
                .HasColumnName("employee_note");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(50)
                .HasColumnName("ip_address");
            entity.Property(e => e.IpAddressEnc)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("ip_address_enc");
            entity.Property(e => e.Latitude)
                .HasColumnType("float(10,6)")
                .HasColumnName("latitude");
            entity.Property(e => e.LatitudeEnc)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("latitude_enc");
            entity.Property(e => e.Longitude)
                .HasColumnType("float(10,6)")
                .HasColumnName("longitude");
            entity.Property(e => e.LongitudeEnc)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("longitude_enc");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.PhotoFaceStatusId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("photo_face_status_id");
            entity.Property(e => e.PhotoFaceUrl)
                .HasMaxLength(255)
                .HasColumnName("photo_face_url");
            entity.Property(e => e.RequesterId).HasColumnName("requester_id");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.SupervisorNote)
                .HasMaxLength(1000)
                .HasColumnName("supervisor_note");
            entity.Property(e => e.SupervisorStatusDate)
                .HasColumnType("datetime")
                .HasColumnName("supervisor_status_date");
            entity.Property(e => e.TimeCheckDateLong).HasColumnName("time_check_date_long");
            entity.Property(e => e.TimeCheckDateUtc)
                .HasColumnType("datetime")
                .HasColumnName("time_check_date_utc");
            entity.Property(e => e.TimeCheckTimezone)
                .HasMaxLength(64)
                .HasColumnName("time_check_timezone");
            entity.Property(e => e.WorkingDayId).HasColumnName("working_day_id");
        });

        modelBuilder.Entity<TimeCheckDelay>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("time_check_delay");

            entity.HasIndex(e => new { e.CompanyId, e.StatusId }, "index_time_check_delay_company_id_status_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApprovedBy).HasColumnName("approved_by");
            entity.Property(e => e.Comments)
                .HasMaxLength(1000)
                .HasColumnName("comments");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.DelaySettingsId).HasColumnName("delay_settings_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.PlannedHourLong).HasColumnName("planned_hour_long");
            entity.Property(e => e.PlannedHourUtc)
                .HasColumnType("datetime")
                .HasColumnName("planned_hour_utc");
            entity.Property(e => e.RealHourLong).HasColumnName("real_hour_long");
            entity.Property(e => e.RealHourUtc)
                .HasColumnType("datetime")
                .HasColumnName("real_hour_utc");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
        });

        modelBuilder.Entity<TimeCheckSummary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("time_check_summary");

            entity.HasIndex(e => new { e.CompanyId, e.EmployeeId, e.DateStart, e.StatusId }, "idx_company_id_status_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccumulatedBalance)
                .HasPrecision(5, 2)
                .HasColumnName("accumulated_balance");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.DateStart).HasColumnName("date_start");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.EstimatedHours)
                .HasPrecision(3, 2)
                .HasColumnName("estimated_hours");
            entity.Property(e => e.Extension).HasColumnName("extension");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.MonthlyBalance)
                .HasPrecision(5, 2)
                .HasColumnName("monthly_balance");
            entity.Property(e => e.RealizedHours)
                .HasPrecision(3, 2)
                .HasColumnName("realized_hours");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
        });

        modelBuilder.Entity<WorkShift>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("work_shift");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.CurrentWorkingday).HasColumnName("current_workingday");
            entity.Property(e => e.DateEnd)
                .HasColumnType("datetime")
                .HasColumnName("date_end");
            entity.Property(e => e.DateStart)
                .HasColumnType("datetime")
                .HasColumnName("date_start");
            entity.Property(e => e.DisplayClass).HasColumnName("display_class");
            entity.Property(e => e.EffectiveDate)
                .HasColumnType("datetime")
                .HasColumnName("effective_date");
            entity.Property(e => e.FrequencyId).HasColumnName("frequency_id");
            entity.Property(e => e.LastExecute)
                .HasColumnType("datetime")
                .HasColumnName("last_execute");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.WorkingdaySequence)
                .HasMaxLength(100)
                .HasColumnName("workingday_sequence");
        });

        modelBuilder.Entity<WorkShiftAssignment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("work_shift_assignment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.DateFrom).HasColumnName("date_from");
            entity.Property(e => e.DateTo)
                .HasDefaultValueSql("'9999'")
                .HasColumnName("date_to");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.WorkshiftId).HasColumnName("workshift_id");
        });

        modelBuilder.Entity<WorkingDay>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("working_day");

            entity.HasIndex(e => new { e.CompanyId, e.StatusId }, "idx_company_id_status_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.EnableDelays)
                .HasDefaultValueSql("'0'")
                .HasColumnName("enable_delays");
            entity.Property(e => e.MobileAllowed)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)")
                .HasColumnName("mobile_allowed");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.WebAllowed)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)")
                .HasColumnName("web_allowed");
            entity.HasMany(w => w.WorkingDayAssigment)
            .WithOne(wd => wd.WorkingDay)
            .HasForeignKey(wd => wd.WorkingDayId);
        });

        modelBuilder.Entity<WorkingDayAssigment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("working_day_assigment");

            entity.HasIndex(e => new { e.CompanyId, e.StatusId }, "idx_working_day_assigment_company_status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuditCreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("audit_created_on");
            entity.Property(e => e.AuditEmployeeId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("audit_employee_id");
            entity.Property(e => e.AuditModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("audit_modified_on");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.IsImmediately)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)")
                .HasColumnName("is_immediately");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.WorkingDayId).HasColumnName("working_day_id");
        });

        modelBuilder.Entity<WorkingDaySpec>(entity =>
        {
            entity.HasKey(e => new { e.WorkingDayId, e.WeekDay, e.ValidFrom, e.ValidTo })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });

            entity.ToTable("working_day_specs");

            entity.HasIndex(e => new { e.DateStart, e.DateEnd }, "idx_working_day_specs_date");

            entity.Property(e => e.WorkingDayId).HasColumnName("working_day_id");
            entity.Property(e => e.WeekDay).HasColumnName("week_day");
            entity.Property(e => e.ValidFrom).HasColumnName("valid_from");
            entity.Property(e => e.ValidTo).HasColumnName("valid_to");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.DailyWorkHours).HasColumnName("daily_work_hours");
            entity.Property(e => e.DateEnd).HasColumnName("date_end");
            entity.Property(e => e.DateStart).HasColumnName("date_start");
            entity.Property(e => e.EndBreakHour)
                .HasMaxLength(10)
                .HasColumnName("end_break_hour");
            entity.Property(e => e.HourType).HasColumnName("hour_type");
            entity.Property(e => e.MaxEntryHour)
                .HasMaxLength(10)
                .HasColumnName("max_entry_hour");
            entity.Property(e => e.MaxExitHour)
                .HasMaxLength(10)
                .HasColumnName("max_exit_hour");
            entity.Property(e => e.MinEntryHour)
                .HasMaxLength(10)
                .HasColumnName("min_entry_hour");
            entity.Property(e => e.MinExitHour)
                .HasMaxLength(10)
                .HasColumnName("min_exit_hour");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.StartBreakHour)
                .HasMaxLength(10)
                .HasColumnName("start_break_hour");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.TwoDayShift).HasColumnName("two_day_shift");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
