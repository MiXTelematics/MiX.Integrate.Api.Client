using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.TimeEntry
{
	public class DriverApproverLevel
	{
		public ushort ApproverLevel { get; set; }
		public List<DriverAllowedApprovers> DriversAllowedApprovers { get; set; }
	}
}