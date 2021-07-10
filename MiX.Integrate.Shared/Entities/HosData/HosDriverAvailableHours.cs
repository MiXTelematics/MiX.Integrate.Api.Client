using System;
using System.Collections.Generic;
using System.Text;

namespace MiX.Integrate.Shared.Entities.HosData
{
	public class HosDriverAvailableHours
	{
		public long DriverId { get; set; }
		public HosAvailableHours AvailableHours { get; set; }
	}
}
