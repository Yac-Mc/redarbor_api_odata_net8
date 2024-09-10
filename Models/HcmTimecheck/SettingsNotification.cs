using System;
using System.Collections.Generic;

namespace API_Net8_OData.Models.HcmTimecheck;

public partial class SettingsNotification
{
    public long Id { get; set; }

    public int CompanyId { get; set; }

    public int StatusId { get; set; }

    public ulong EndWorkingDayEnabled { get; set; }

    public int EndWorkingDayMinutesToShow { get; set; }

    public string EndWorkingDayOutChannels { get; set; } = null!;

    public ulong ErrorsToEmployeesEnabled { get; set; }

    public string ErrorsToEmployeesChannels { get; set; } = null!;

    public ulong PendingToSupervisorsEnabled { get; set; }

    public string PendingToSupervisorsChannels { get; set; } = null!;

    public ulong ReportToSupervisorsEnabled { get; set; }

    public string ReportToSupervisorsChannels { get; set; } = null!;

    public ulong DelaysToSupervisorsEnabled { get; set; }

    public string DelaysToSupervisorsChannels { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public DateTime ModifiedOn { get; set; }
}
