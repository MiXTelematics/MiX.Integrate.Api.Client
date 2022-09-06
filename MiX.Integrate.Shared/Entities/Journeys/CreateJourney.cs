using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.Journeys
{
	public class CreateJourney
	{
		public Journey Journey { get; set; }
		public List<JourneyAsset> JourneyAssets { get; set; }
		public List<JourneyAssetDriver> JourneyAssetDrivers { get; set; }
		public List<JourneyAssetExternalPassenger> JourneyAssetExternalPassengers { get; set; }
		public List<JourneyAssetTrailer> JourneyAssetTrailers { get; set; }
		public List<JourneyResource> JourneyResources { get; set; }
		public JourneyRoute JourneyRoute { get; set; }
		public bool SubmitJourney { get; set; }

		public CreateJourney()
		{
			JourneyAssets = new List<JourneyAsset>();
			JourneyAssetDrivers = new List<JourneyAssetDriver>();
			JourneyAssetExternalPassengers = new List<JourneyAssetExternalPassenger>();
			JourneyAssetTrailers = new List<JourneyAssetTrailer>();
			JourneyResources = new List<JourneyResource>();
		}
	}
}
