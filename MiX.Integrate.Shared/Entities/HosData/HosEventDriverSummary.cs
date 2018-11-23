using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.HosData
{
	public class HosEventDriverSummary
	{
		public HosEventDriverSummary()
		{
			DailySummaries = new List<HosEventDailySummary> { };
		}
		public long DriverId { get; set; }
		public List<HosEventDailySummary> DailySummaries { get; set; }
	}
}