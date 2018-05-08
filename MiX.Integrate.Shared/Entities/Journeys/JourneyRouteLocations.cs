using System;
using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.Journeys
{
	public class JourneyRouteLocations
	{
		public double TotalTimeInMinutes { get; set; }
		public double TotalDistanceInMetres { get; set; }
		public List<JourneyRouteLocation> RouteLocations { get; set; }
	}
}