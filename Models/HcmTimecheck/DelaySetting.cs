using System;
using System.Collections.Generic;

namespace API_Net8_OData.Models.HcmTimecheck;

public partial class DelaySetting
{
    public int Id { get; set; }

    public int CompanyId { get; set; }

    public int WorkingDayId { get; set; }

    public short MinutesToBeDelay { get; set; }

    public sbyte DelaysToBeFault { get; set; }

    public sbyte FrequencyId { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime ModifiedOn { get; set; }

    public sbyte StatusId { get; set; }

    public uint? ValidFrom { get; set; }

    public uint? ValidTo { get; set; }
}
