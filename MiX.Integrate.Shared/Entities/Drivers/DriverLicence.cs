using System;
using System.Diagnostics;


namespace MiX.Integrate.Shared.Entities.Drivers
{ 
	[DebuggerDisplay("{DriverId}:{LicenceNumber}")]
	public class DriverLicence
	{
		public DriverLicence()
		{
		}

		public DriverLicence(int licenceCategoryId, long driverId, string licenceCode, string licenceNumber)
		{
			this.LicenceCategoryId = licenceCategoryId;
			this.DriverId = driverId;
			this.LicenceCode = licenceCode;
			this.LicenceNumber = licenceNumber;
		}

		public int LicenceCategoryId { get; set; }
		public long DriverId { get; set; }
		public string LicenceCode { get; set; }
		public string LicenceCodeCountry { get; set; }
		public string LicenceNumber { get; set; }
		public string IssuedState { get; set; }
		public DateTime Obtained { get; set; }
		public DateTime Expires { get; set; }
	}
}
