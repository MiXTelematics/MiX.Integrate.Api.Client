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
		Task<List<MobileUnitCommunicationSettings>> GetCommunicationSettingsAsync(List<long> assetIds);
		List<MobileUnitCommunicationSettings> GetCommunicationSettings(List<long> assetIds);
		Task<List<MobileUnitCameraSettings>> GetCameraSettingsAsync(List<long> assetIds);
		List<MobileUnitCameraSettings> GetCameraSettings(List<long> assetIds);
		Task<List<MobileUnitConfigurationState>> GetConfigurationStateAsync(List<long> assetIds);
		List<MobileUnitConfigurationState> GetConfigurationState(List<long> assetIds);
		Task<List<MobileUnitDeviceConfiguration>> GetMobileUnitDeviceConfigurationsByAssetIdsAsync(List<long> assetIds);
		List<MobileUnitDeviceConfiguration> GetMobileUnitDeviceConfigurationsByAssetIds(List<long> assetIds);
		Task<List<MobileUnitDeviceConfiguration>> GetMobileUnitDeviceConfigurationsByGroupIdAsync(long groupId);
		List<MobileUnitDeviceConfiguration> GetMobileUnitDeviceConfigurationsByGroupId(long groupId);
	}
}
