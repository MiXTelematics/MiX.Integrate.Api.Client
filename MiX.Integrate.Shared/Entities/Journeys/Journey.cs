using System;

namespace MiX.Integrate.Shared.Entities.Journeys
{
	public class Journey
	{
		public long JourneyId { get; set; }
		public int JourneyReference { get; set; }
		public string Description { get; set; }
		public string Purpose { get; set; }
		public long GroupId { get; set; }
		public long? SiteId { get; set; }
		public long? OwnerDriverId { get; set; }
		public string JobId { get; set; }
		public string JourneyStatus { get; set; }
		public bool IsHazardous { get; set; }
		public bool IsOversizeVehicle { get; set; }
		public bool IsOversizeLoad { get; set; }
	}
}
