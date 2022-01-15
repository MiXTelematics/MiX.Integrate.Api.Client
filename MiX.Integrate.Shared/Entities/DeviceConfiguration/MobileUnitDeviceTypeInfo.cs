using MiX.Integrate.Shared.Entities.Assets;

namespace MiX.Integrate.Shared.Entities.DeviceConfiguration
{
	public sealed class MobileUnitMobileDeviceInfo
	{
		/// <summary>Id of the <see cref="Asset"/> associated with this information</summary>
		public long AssetId { get; set; }

		/// <summary>The asset's configured mobile device type</summary>
		public string MobileDeviceType { get; set; }

		/// <summary>Nsme of the configuration group to which the asset is assigned</summary>
		public string ConfigurationGroup { get; set; }
	}
}
