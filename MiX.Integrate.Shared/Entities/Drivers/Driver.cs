using System;
using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.Drivers
{
	public class Driver 
	{
		public Driver()
		{
			ExtendedDriverIdType = ExtendedDriverIdType.None;
		}

		public Driver(long driverId, Int16? fmDriverId, string name, long siteId, string employeeNumber, string driverImage, string mobileNumber, string email, string extendedDriverID, ExtendedDriverIdType extendedDriverIdType, string country)
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

		public long SiteId { get; set; }
		public long DriverId { get; set; }
		public string Name { get; set; }
		public string ImageUri { get; set; }
		public short FmDriverId { get; set; }
		public string EmployeeNumber { get; set; }
		public bool IsSystemDriver { get { return (FmDriverId == 0 || FmDriverId == 1); } }
		public string MobileNumber { get; set; }
		public string Email { get; set; }
		/// <summary>
		/// You can update the ExtendedDriverId by using the UpdateDriverExtendedId method
		/// </summary>
		public string ExtendedDriverId { get; set; }
		public ExtendedDriverIdType ExtendedDriverIdType { get; set; }
		public string Country { get; set; }
		public List<DriverAdditionalDetailField> AdditionalDetailFields { get; set; }
	}
}
