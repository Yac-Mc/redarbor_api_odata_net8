using System;
using System.Collections.Generic;

namespace API_Net8_OData.Models.HcmTimecheck;

public partial class NotificationsSetting
{
    public int Id { get; set; }

    public int CompanyId { get; set; }

    public int WorkingDayId { get; set; }

    public int NotificationInStatusId { get; set; }

    public int NotificationInSeconds { get; set; }

    public int NotificationOutStatusId { get; set; }

    public int NotificationOutSeconds { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime ModifiedOn { get; set; }

    public sbyte StatusId { get; set; }

    public int NotificationOutChannels { get; set; }
}
