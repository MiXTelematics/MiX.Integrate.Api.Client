using System;
using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.HosData
{
	public class HosEventStartDateTimeByHourChangedSince
	{
		public HosEventStartDateTimeByHourChangedSince()
		{
			EventStartDateTimes = new List<DateTime>();
		}
		public long DriverId { get; set; }
		public List<DateTime> EventStartDateTimes { get; set; }
	}
}