using System;

namespace MiX.Integrate.Shared.Entities.HosData
{
	public class HosEvent
	{
		public long EventId { get; set; }
		public DateTime StartDateTime { get; set; }
		public long DriverId { get; set; }
		public long AssetId { get; set; }
		public long PositionId { get; set; }
		public byte EventTypeId { get; set; }
		public byte EventStatusId { get; set; }
		public byte SourceId { get; set; }
		public string Remarks { get; set; }
		public string StateCode { get; set; }
	}
}