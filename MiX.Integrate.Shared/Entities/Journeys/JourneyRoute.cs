using System;
using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.Journeys
{
	public class JourneyRoute
	{
		public DateTimeOffset? DepartureDateTime { get; set; }
		public DateTimeOffset? ArrivalDateTime { get; set; }
		public string RouteId { get; set; }
		public bool TruckRouting { get; set; }
		public double MaxTruckWeight { get; set; }
		public RouteLocation StartLocation { get; set; }
		public RouteLocation EndLocation { get; set; }
		public List<RouteLocation> Waypoints { get; set; }
		public string RoutingBoatFerry { get; set; }
		public string RoutingDirtRoad { get; set; }
		public string RoutingMotorway { get; set; }
		public string RoutingRailFerry { get; set; }
		public string RoutingTollRoad { get; set; }
		public string RoutingTrafficMode { get; set; }
		public string RoutingTunnel { get; set; }
		public string RoutingType { get; set; }
		public bool IsReturnJourney { get; set; }
		public bool SpecifyTimes { get; set; }

		public JourneyRoute()
		{
			TruckRouting = false;
			MaxTruckWeight = 0;
			StartLocation = new RouteLocation();
			EndLocation = new RouteLocation();
			Waypoints = new List<RouteLocation>();
			IsReturnJourney = false;
		}
	}
}