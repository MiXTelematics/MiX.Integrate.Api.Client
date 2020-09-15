using System;

namespace MiX.Integrate.Shared.Entities.Reminders
{
  public class AssetRoadworthyCertificateReminder
	{
		public long AssetId { get; set; }
		public bool EnableReminder { get; set; }
		public DateTime? ValidFrom { get; set; }
		public DateTime? ExpiryDate { get; set; }
		public byte? CertificateDurationMonths { get; set; }
		public byte? ReminderPeriodWeeks { get; set; }
	}
}
