using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Entities.DeviceConfiguration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public interface IDeviceConfigurationClient : IBaseClient
	{
		Task<List<ConnectedPeripheral>> GetConnectedPeripheralsForAssetsAsync(long groupId, List<long> assetIds);
		List<ConnectedPeripheral> GetConnectedPeripheralsForAssets(long groupId, List<long> assetIds);
		Task<List<MobileUnitCommunicationSettings>> GetCommunicationSettingsAsync(long groupId, List<long> assetIds);
		List<MobileUnitCommunicationSettings> GetCommunicationSettings(long groupId, List<long> assetIds);
		Task<List<MobileUnitCameraSettings>> GetCameraSettingsAsync(long groupId, List<long> assetIds);
		List<MobileUnitCameraSettings> GetCameraSettings(long groupId, List<long> assetIds);
		Task<List<MobileUnitConfigurationState>> GetConfigurationStateAsync(long groupId, List<long> assetIds);
		List<MobileUnitConfigurationState> GetConfigurationState(long groupId, List<long> assetIds);
		Task<List<MobileUnitDeviceConfiguration>> GetMobileUnitDeviceConfigurationsByAssetIdsAsync(List<long> assetIds);
		List<MobileUnitDeviceConfiguration> GetMobileUnitDeviceConfigurationsByAssetIds(List<long> assetIds);
		Task<List<MobileUnitDeviceConfiguration>> GetMobileUnitDeviceConfigurationsByGroupIdAsync(long groupId);
		List<MobileUnitDeviceConfiguration> GetMobileUnitDeviceConfigurationsByGroupId(long groupId);

		/// <summary>Returns the mobile device type and configuration group assignment of each asset in the specified group</summary>
		/// <param name="groupId">The groupId of the organisation, organisation subgroup or site to query</param>
		/// <returns>A <see cref="Task"/> representing the asynchronous operation which, once completed, yields a
		/// <see cref="List{MobileUnitMobileDeviceInfo}"/> containing an entry for each asset in the specified group</returns>
		List<MobileUnitMobileDeviceInfo> GetMobileDeviceTypes(long groupId);

		/// <summary>Returns the mobile device type and configuration group assignment of each asset in the specified group as an asynchronours operation</summary>
		/// <param name="groupId">The groupId of the organisation, organisation subgroup or site to query</param>
		/// <returns>A <see cref="List{MobileUnitMobileDeviceInfo}"/> containing an entry for each asset in the specified group</returns>
		Task<List<MobileUnitMobileDeviceInfo>> GetMobileDeviceTypesAsync(long groupId);
	}
}
