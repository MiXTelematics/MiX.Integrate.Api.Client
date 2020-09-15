using System;
using MiX.Integrate.Shared.Entities.Positions;

namespace MiX.Integrate.Shared.Entities.LoggableData
{
	public class LoggableDataCarrier
	{
		public LoggableDataCarrier() { }

		public long EventId { get; set; }
		public long GroupId { get; set; }
		public string GroupType { get; set; }
		public int? GroupLegacyId { get; set; }
		public long AssetId { get; set; }
		public string AssetType { get; set; }
		public int? AssetLegacyId { get; set; }
		public long DriverID { get; set; }
		public int? DriverLegacyId { get; set; }
		public long DeviceId { get; set; }
		public string DeviceType { get; set; }
		public DateTime EventDate { get; set; }
		public Position Position { get; set; }

		//OtherData
		public string MenuID { get; set; }
		public string MenuItemCode { get; set; }
		public byte ValueType { get; set; }
		public string StringValue { get; set; }
		public string EventCategory { get; set; }

	}
}
