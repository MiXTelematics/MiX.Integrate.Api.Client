using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiX.Integrate.Shared.Entities.Reminders
{
	public class AssetLicenceReminder
	{
		public long AssetId { get; set; }
		public bool EnableReminder { get; set; }
		public DateTime? ValidFrom { get; set; }
		public DateTime? ExpiryDate { get; set; }
		public byte? LicenseDurationMonths { get; set; }
		public byte? ReminderPeriodWeeks { get; set; }
	}
}
