using System;
using System.Collections.Generic;
using System.Text;

namespace MiX.Integrate.Shared.Entities.HosData
{
	public class RuleSetSummary
	{
		public short FmRuleSetId { get; set; }
		public string Description { get; set; }
		public string Region { get; set; }
		public bool HasOilFieldRules { get; set; }
		public bool DriverIsExempt { get; set; }
		
	}
}
