using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.Journeys
{
    public class JourneyAssetAndPassengerData
    {
		public List<JourneyAsset> JourneyAssets { get; set; }
		public List<JourneyAssetPassenger> JourneyAssetPassengerList { get; set; }
		public List<JourneyAssetExternalPassenger> JourneyAssetExternalPassengerList { get; set; }
	}
}
