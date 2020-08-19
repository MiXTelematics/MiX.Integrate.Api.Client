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
}


