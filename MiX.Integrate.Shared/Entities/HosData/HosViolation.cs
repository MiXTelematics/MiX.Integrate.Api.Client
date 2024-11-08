using System;

namespace MiX.Integrate.Shared.Entities.HosData
{
	public class HosViolation
	{
        public long DriverId { get; set; }
		public string ViolationName { get; set; }
		public string ViolationDescription { get; set; }
		public int ViolationRuleId { get; set; }
		public DateTime InitialStartDateTime { get; set; }
		public DateTime StartDateTime { get; set; }
		public DateTime? EndDateTime { get; set; }
		public bool IsOngoingViolation { get; set; }
	}
}