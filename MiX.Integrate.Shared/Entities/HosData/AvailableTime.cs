using System;

namespace MiX.Integrate.Shared.Entities.HosData
{
	public class AvailableTime
	{
		public ushort RuleId { get; set; }
		public int AvailableTimeType { get; set; }
		public string Name { get; set; }
		public TimeSpan FullAvailableTime { get; set; }
		public TimeSpan CurrentAvailableTime { get; set; }
		public bool HasSplitValue { get; set; }
		public TimeSpan SplitValue { get; set; }
		public string OverrideDescription { get; set; }
		public DateTime DateTimeValue { get; set; }
		public bool IsDateTimeValue { get; set; }
	}
}