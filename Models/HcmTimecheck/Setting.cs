using System;
using System.Collections.Generic;

namespace API_Net8_OData.Models.HcmTimecheck;

public partial class Setting
{
    public long Id { get; set; }

    public int CompanyId { get; set; }

    public long ValidFromDate { get; set; }

    public long ValidToDate { get; set; }

    public bool ShowAccumulatedHours { get; set; }

    public int PeriodDisplay { get; set; }

    public int PeriodDisplayStartDay { get; set; }

    public bool ShowErrorIcon { get; set; }

    public bool SendTimeCheckSummary { get; set; }

    public bool SendTimeCheckErrorSummary { get; set; }

    public sbyte SupervisorsVisualizationType { get; set; }

    public sbyte EmployeeReportExportType { get; set; }

    public sbyte LocalizationControlType { get; set; }

    public sbyte LocalizationWebControlType { get; set; }

    public sbyte LocalizationWebOption { get; set; }

    public sbyte LocalizationAppEnabled { get; set; }

    public sbyte LocalizationAppOption { get; set; }

    public bool PunctualityControlEnabled { get; set; }

    public int PunctualityStrikesAllowed { get; set; }

    public int PunctualityStrikesResetDays { get; set; }

    public int MinimumMinutesBetweenTimeCheck { get; set; }

    public int NumberDaysAllowedEdit { get; set; }

    public int NumberDaysEditAutoApproved { get; set; }

    public int AllowedLateTimeCheckMinutes { get; set; }

    public int RoundExtraHour { get; set; }

    public int RoundNegativeHour { get; set; }

    public int ExtraHoursRegulationMonths { get; set; }

    public int StatusId { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime ModifiedOn { get; set; }

    public sbyte? EnableDelays { get; set; }

    public int EnableNotifications { get; set; }

    public int EnableTimeCheckCommentMobile { get; set; }

    public sbyte? LocalizationKioskControlType { get; set; }

    public sbyte? LocalizationKioskOption { get; set; }
}
