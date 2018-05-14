using System;
using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.Journeys
{
	public class JourneyRouteInfo
	{
		public double PlannedTimeInMinutes { get; set; }
		public double PlannedDistanceInMetres { get; set; }
		public long SavedRouteId { get; set; }
		public List<JourneyRouteLocation> JourneyRouteLocations { get; set; }
	}
}