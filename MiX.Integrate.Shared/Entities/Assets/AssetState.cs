using System;

namespace MiX.Integrate.Shared.Entities.Assets
{
	public class AssetState
	{
		public long AssetStateId { get; set; }

		public long AssetId { get; set; }

		public string State { get; set; }

		public string CreatedBy { get; set; }

		public string Notes { get; set; }

		public DateTime? StateExpiryDate { get; set; }
 
		public DateTimeOffset CreateDate { get; set; }
	}
}
