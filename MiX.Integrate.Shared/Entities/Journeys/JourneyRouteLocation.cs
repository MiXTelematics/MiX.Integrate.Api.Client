using System;
using System.Collections.Generic;
using System.Text;

namespace MiX.Integrate.Shared.Entities.Journeys
{
	public class JourneyRouteLocation
	{
		public long JourneyRouteId { get; set; }
		public long JourneyRouteLocationId { get; set; }
		public int RouteOrder { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public int StopDuration { get; set; }
		public long? DmxLocationId { get; set; }
		public DateTimeOffset ActualDepartureDate { get; set; }
		public DateTimeOffset ActualArrivalDate { get; set; }
		public DateTimeOffset AdjustedDepartureDate { get; set; }
		public DateTimeOffset AdjustedArrivalDate { get; set; }
		public string StopActivityInstructions { get; set; }
		public double DepartureOdometer { get; set; }
		public double ArrivalOdometer { get; set; }
	}
}
