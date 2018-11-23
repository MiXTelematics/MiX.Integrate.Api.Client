using System;
using System.Collections.Generic;
using System.Text;

namespace MiX.Integrate.Shared.Entities.HosData
{
	public class HosDriverInfoSummary
	{
		public long DriverId { get; set; }
		public long OrganisationId { get; set; }
		public short FmRuleSetId { get; set; }
		public byte StartOfDay { get; set; }
		public long HomeMapLocationId { get; set; }
		public string HosId { get; set; }
		public string TimeZoneId { get; set; }
		public string Remarks { get; set; }
		public DateTime? EldEnabledOn { get; set; }
		public bool AllowPersonalConveyance { get; set; }
		public bool AllowYardMovement { get; set; }
		public bool IsTimeEntryEnabled { get; set; }
	}
}
