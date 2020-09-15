using System;
using System.Collections.Generic;
using System.Text;

namespace MiX.Integrate.Shared.Entities.Journeys
{
	public class BulkJourneyRoute
	{
		public DateTimeOffset? DepartureDateTime { get; set; }
		public DateTimeOffset? ArrivalDateTime { get; set; }
		public string RouteId { get; set; }
		public bool TruckRouting { get; set; }
		public double MaxTruckWeight { get; set; }
		public BulkRouteLocation StartLocation { get; set; }
		public BulkRouteLocation EndLocation { get; set; }
		public List<BulkRouteLocation> Waypoints { get; set; }
		public string RoutingBoatFerry { get; set; }
		public string RoutingDirtRoad { get; set; }
		public string RoutingMotorway { get; set; }
		public string RoutingRailFerry { get; set; }
		public string RoutingTollRoad { get; set; }
		public string RoutingTrafficMode { get; set; }
		public string RoutingTunnel { get; set; }
		public string RoutingType { get; set; }
		public bool IsReturnJourney { get; set; }

		public BulkJourneyRoute()
		{
			TruckRouting = false;
			MaxTruckWeight = 0;
			StartLocation = new BulkRouteLocation();
			EndLocation = new BulkRouteLocation();
			Waypoints = new List<BulkRouteLocation>();
			IsReturnJourney = false;
		}
	}
}
