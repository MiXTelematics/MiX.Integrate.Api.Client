using System;

namespace MiX.Integrate.Shared.Entities.Journeys
{
	public class JourneyInProgressCurrentStatus
	{
		public string Description { get; set; }
		public long JourneyId { get; set; }
		public string JourneyStatus { get; set; }
		public long OwnerDriverId { get; set; }
		public DateTimeOffset? PositionDateTime { get; set; }
		public double? PositionLatitude { get; set; }
		public double? PositionLongitude { get; set; }
		public string PositionProgressStatus { get; set; }
		public long SiteId { get; set; }
		public DateTimeOffset? TimeDateTime { get; set; }
		public double? TimeLatitude { get; set; }
		public double? TimeLongitude { get; set; }
		public string TimeProgressStatus { get; set; }
		public long VehicleId { get; set; }
	}
}
