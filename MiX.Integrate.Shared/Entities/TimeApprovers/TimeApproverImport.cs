using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.TimeApprovers
{
	public class TimeApproverImport
	{
		public TimeApproverImport()
		{
			Approvers = new List<Approver>();
			DriverApproverLevels = new List<DriverApproverLevel>();
		}
		public List<Approver> Approvers { get; set; }
		public List<DriverApproverLevel> DriverApproverLevels { get; set; }
	}
}