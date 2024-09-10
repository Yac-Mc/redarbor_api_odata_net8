namespace API_Net8_OData.Models.HcmTimecheck;

public partial class TimeCheck
{
    public int Id { get; set; }

    public int CompanyId { get; set; }

    public int EmployeeId { get; set; }

    public long WorkingDayId { get; set; }

    public sbyte CheckTypeId { get; set; }

    public int CheckoutTypeId { get; set; }

    public DateTime TimeCheckDateUtc { get; set; }

    public long TimeCheckDateLong { get; set; }

    public string? TimeCheckTimezone { get; set; }

    public sbyte CheckDeviceTypeId { get; set; }

    public sbyte StatusId { get; set; }

    public int RequesterId { get; set; }

    public DateTime SupervisorStatusDate { get; set; }

    public string? EmployeeNote { get; set; }

    public string? SupervisorNote { get; set; }

    public float Longitude { get; set; }

    public float Latitude { get; set; }

    public string LatitudeEnc { get; set; } = null!;

    public string LongitudeEnc { get; set; } = null!;

    public string IpAddress { get; set; } = null!;

    public string IpAddressEnc { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public DateTime ModifiedOn { get; set; }

    public int DelayId { get; set; }

    public string? PhotoFaceUrl { get; set; }

    public sbyte? PhotoFaceStatusId { get; set; }
}
