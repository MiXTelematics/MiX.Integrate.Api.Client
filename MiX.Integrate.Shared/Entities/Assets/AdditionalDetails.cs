using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.Assets
{
	/// <summary>Represents custom data associated with an asset</summary>
  public class AdditionalDetails
	{
		/// <summary>Identified the asset to which the custom data pertains</summary>
		public long AssetId { get; set; }

		/// <summary>The <see cref="AdditionalDetailItem"/>s containing the custom data</summary>
		public List<AdditionalDetailItem> Items { get; set; } = new List<AdditionalDetailItem>();
	}
}
