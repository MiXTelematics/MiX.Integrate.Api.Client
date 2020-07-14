using System;

namespace MiX.Integrate.Shared.Entities.Reminders
{
  public class AssetServiceReminder
	{
		public long AssetId { get; set; }

		public bool IsConnectedTrailer { get; set; }

		public bool EnableOnDistance { get; set; }
		public float? LastServiceRecordedKm { get; set; }
		public float? NextServiceDueAtKm { get; set; }
		public float? ServiceIntervalKm { get; set; }
		public float? ReminderIntervalKm { get; set; }

		public bool EnableOnDuration { get; set; }
		public DateTime? LastServiceRecordedAt { get; set; }
		public DateTime? NextServiceDueAt { get; set; }
		public short? ServiceIntervalMonths { get; set; }
		public short? ReminderIntervalWeeks { get; set; }

		public bool EnableOnEngineHours { get; set; }
		public int? LastServiceOnHours { get; set; }
		public int? NextServiceDueOnHours { get; set; }
		public int? EngineHoursInterval { get; set; }
		public int? EngineHoursReminderPeriod { get; set; }
	}
}
