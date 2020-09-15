using System;
#if DEBUG
using System.Diagnostics;
#endif

namespace MiX.Integrate.Shared.Entities.Drivers
{
#if DEBUG	
	[DebuggerDisplay("{DriverId}:{CertificationTypeId}")]
#endif
	public class DriverCertification
	{
		public DriverCertification()
		{
		}

		public DriverCertification(int certificationTypeId, long driverId)
		{
			this.CertificationTypeId = certificationTypeId;
			this.DriverId = driverId;
		}

		public long DriverId { get; set; }
		public int CertificationTypeId { get; set; }
		public DateTime Obtained { get; set; }
		public string Instructor { get; set; }
		public bool IsInstructorQualified { get; set; }
		//public List<DriverCertificationNotification> Notifications { get; set; }
	}
}