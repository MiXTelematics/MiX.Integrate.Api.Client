using System;

namespace MiX.Integrate.Shared.Entities.Drivers
{
	public class Driver : DriverSummary
	{
		public Driver()
		{
			ExtendedDriverIdType = ExtendedDriverIdType.None;
		}
		public Driver(long driverId, Int16? fmDriverId, string name, long siteId, DateTime lastTrip, string employeeNumber, bool automaticallyCreated, string driverImage, string mobileNumber, string email, string extendedDriverID, ExtendedDriverIdType extendedDriverIdType, string country)
		{
			DriverId = driverId;
			if (fmDriverId.HasValue) FmDriverId = fmDriverId.Value;
			Name = name;
			SiteId = siteId;
			EmployeeNumber = employeeNumber;
			ImageUri = driverImage;
			MobileNumber = mobileNumber;
			Email = email;
			ExtendedDriverId = extendedDriverID;
			ExtendedDriverIdType = extendedDriverIdType;
			Country = country;
		}

		public short FmDriverId { get; set; }
		public string EmployeeNumber { get; set; }
		public bool IsSystemDriver { get { return (FmDriverId == 0 || FmDriverId == 1); } }
		public string MobileNumber { get; set; }
		public string Email { get; set; }
		public string ExtendedDriverId { get; set; }
		public ExtendedDriverIdType ExtendedDriverIdType { get; set; }
		public string Country { get; set; }
	}
}
