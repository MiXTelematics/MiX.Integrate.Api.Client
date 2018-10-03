using System;
using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.HosData
{
	public class HosAvailableHours
	{
		public HosAvailableHours()
		{
			AvailableTimes = new List<AvailableTime>();
		}

		public string RuleSetName { get; set; }
		public byte CurrentStatus { get; set; }
		public string CurrentStatusDescription { get; set; }
		public bool IsOnDuty { get; set; }
		public DateTime LastCalculation { get; set; }
		public List<AvailableTime> AvailableTimes { get; set; }
	}
}