using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.Dtc
{
	public class AssetFaults
	{
		public AssetFaults()
		{
			this.Faults = new List<FaultStatus>();
		}

		public AssetFaults(long assetId, List<FaultStatus> faults)
		{
			this.AssetId = assetId;
			this.Faults = faults;
		}

		public long AssetId { get; set; }

		public List<FaultStatus> Faults { get; set; }
	}
}
