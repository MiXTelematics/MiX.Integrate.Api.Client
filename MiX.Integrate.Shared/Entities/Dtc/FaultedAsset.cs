using System;
using System.Collections.Generic;
using System.Text;

namespace MiX.Integrate.Shared.Entities.Dtc
{
	public class FaultedAsset
	{
		public FaultedAsset() { }

		public FaultedAsset(long assetId, FaultSeverity severity)
		{
			AssetId = assetId;
			MaxSeverity = severity;
		}

		public long AssetId { get; set; }
		public FaultSeverity MaxSeverity { get; set; }
	}
}
