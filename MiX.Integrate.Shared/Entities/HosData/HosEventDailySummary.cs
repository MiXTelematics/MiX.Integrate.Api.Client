using System;
using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.HosData
{
	public class HosEventDailySummary
	{
		public HosEventDailySummary()
		{
			EventSummaries = new List<HosEventSummary> { };
		}
		public DateTime Day { get; set; }
		public List<HosEventSummary> EventSummaries { get; set; }
	}
}