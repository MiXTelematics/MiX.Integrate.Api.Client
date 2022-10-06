using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.Journeys
{
	public class JourneyAssetDriversUpdate
	{
		public IList<JourneyAssetDriversUpdateAsset> JourneyAssets { get; set; }

		public class JourneyAssetDriversUpdateAsset
		{
			public string AssetId { get; set; }
			public IList<JourneyAssetDriversUpdateDriver> Drivers { get; set; }
		}

		public class JourneyAssetDriversUpdateDriver
		{
			public string DriverId { get; set; }
			public bool IsOwner { get; set; }
		}
	}
}
