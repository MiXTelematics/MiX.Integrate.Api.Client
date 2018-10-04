﻿using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.TimeEntry
{
	public class DriverAllowedApprovers
	{
		public DriverAllowedApprovers()
		{
			ApproverIds = new List<string>();
		}
		public string HosDriverId { get; set; }
		public List<string> ApproverIds { get; set; }
	}
}
