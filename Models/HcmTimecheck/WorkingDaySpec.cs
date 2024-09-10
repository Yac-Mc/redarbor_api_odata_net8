using System;
using System.Collections.Generic;

namespace API_Net8_OData.Models.HcmTimecheck;

public partial class WorkingDaySpec
{
    public long WorkingDayId { get; set; }

    public sbyte WeekDay { get; set; }

    public int ValidFrom { get; set; }

    public int ValidTo { get; set; }

    public int? DateStart { get; set; }

    public int? DateEnd { get; set; }

    public int StatusId { get; set; }

    public sbyte HourType { get; set; }

    public string? MinEntryHour { get; set; }

    public string? MaxEntryHour { get; set; }

    public string? StartBreakHour { get; set; }

    public string? EndBreakHour { get; set; }

    public string? MinExitHour { get; set; }

    public string? MaxExitHour { get; set; }

    public int? DailyWorkHours { get; set; }

    public sbyte TwoDayShift { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime ModifiedOn { get; set; }
}
