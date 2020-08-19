using System;
using System.Collections.Generic;
using System.Text;

namespace MiX.Integrate.Shared.Entities.Journeys
{
	public class BulkAddJourney
	{
		public string AddReference { get; set; }
		public string Description { get; set; }
		public string Purpose { get; set; }
		public long GroupId { get; set; }
		public long SiteId { get; set; }
		public long OwnerDriverId { get; set; }
		public string JobId { get; set; }
		public bool IsHazardous { get; set; }
		public bool IsOversizeVehicle { get; set; }
		public bool IsOversizeLoad { get; set; }
		public List<BulkJourneyAsset> JourneyAssets { get; set; }
		public List<BulkJourneyAssetDriver> JourneyAssetDrivers { get; set; }
		public List<BulkJourneyAssetExternalPassengers> JourneyAssetExternalPassengers { get; set; }
		public BulkJourneyRoute JourneyRoute { get; set; }
		//public bool SubmitJourney { get; set; }
	}


	public class BulkJourneyAsset
	{
		public long AssetId { get; set; }
	}

	public class BulkJourneyAssetDriver {
		public long DriverId { get; set; }
		public long AssetId { get; set; }
	}

	public class BulkJourneyAssetExternalPassengers
	{
			public long AssetId { get; set; }
			public string PassengerName { get; set; }
			public string MobileNumber { get; set; }
			public string Email { get; set; }
	}


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
		public class BulkRouteLocation
	{
		public double? Latitude { get; set; }
		public double? Longitude { get; set; }
		public bool RestStop { get; set; }
		public bool FuelStop { get; set; }
		public bool LoadingStop { get; set; }
		public bool OffLoadingStop { get; set; }
		public int StopDuration { get; set; }
		public string LocationId { get; set; }
		public string StopActivityInstructions { get; set; }
	}

	}


