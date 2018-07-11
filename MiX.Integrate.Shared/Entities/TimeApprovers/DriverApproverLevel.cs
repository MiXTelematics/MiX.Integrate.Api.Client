using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.TimeApprovers
{
	public class DriverApproverLevel
	{
		public ushort ApproverLevel { get; set; }
		public List<DriverAllowedApprovers> DriversAllowedApprovers { get; set; }
	}
}