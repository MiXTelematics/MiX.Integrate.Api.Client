using System;

namespace MiX.Integrate.Shared.Entities.HosData
{
	public class HosEventSummary
	{
		public byte EventTypeId { get; set; }
		public byte EventStatusId { get; set; }
		public int Count { get; set; }
		public TimeSpan TotalDuration { get; set; }
	}
}