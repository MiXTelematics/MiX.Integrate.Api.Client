using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiX.Integrate.Shared.Entities.Drivers
{ 
	public class DriverSummary
	{
		public DriverSummary()
		{
		}

		public DriverSummary(long driverId, string name, long siteId, string driverImage)
		{
			DriverId = driverId;
			Name = name;
			SiteId = siteId;
			ImageUri = driverImage;
		}

		public long SiteId { get; set; }
		public long DriverId { get; set; }
		public string Name { get; set; }
		public string ImageUri { get; set; }
	}
}
