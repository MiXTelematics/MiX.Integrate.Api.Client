using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.DeviceConfiguration;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public class DeviceConfigurationClient : BaseClient, IDeviceConfigurationClient
	{
		public DeviceConfigurationClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public DeviceConfigurationClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public async Task<List<ConnectedPeripheral>> GetConnectedPeripheralsForAssetsAsync(long groupId, List<long> assetIds)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DeviceConfigController.GETCONNECTEDPERIPHERALSFORASSETS, HttpMethod.Post);
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<ConnectedPeripheral>> response = await ExecuteAsync<List<ConnectedPeripheral>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public List<ConnectedPeripheral> GetConnectedPeripheralsForAssets(long groupId, List<long> assetIds)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DeviceConfigController.GETCONNECTEDPERIPHERALSFORASSETS, HttpMethod.Post);
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<ConnectedPeripheral>> response = Execute<List<ConnectedPeripheral>>(request);
			return response.Data;
		}

		public async Task<List<MobileUnitCommunicationSettings>> GetCommunicationSettingsAsync(List<long> assetIds)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DeviceConfigController.GETCOMMUNICATIONSETTINGS, HttpMethod.Post);
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<MobileUnitCommunicationSettings>> response = await ExecuteAsync<List<MobileUnitCommunicationSettings>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public List<MobileUnitCommunicationSettings> GetCommunicationSettings(List<long> assetIds)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DeviceConfigController.GETCOMMUNICATIONSETTINGS, HttpMethod.Post);
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<MobileUnitCommunicationSettings>> response = Execute<List<MobileUnitCommunicationSettings>>(request);
			return response.Data;
		}

		public async Task<List<MobileUnitCameraSettings>> GetCameraSettingsAsync(List<long> assetIds)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DeviceConfigController.GETCAMERASETTINGS, HttpMethod.Post);
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<MobileUnitCameraSettings>> response = await ExecuteAsync<List<MobileUnitCameraSettings>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public List<MobileUnitCameraSettings> GetCameraSettings(List<long> assetIds)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DeviceConfigController.GETCAMERASETTINGS, HttpMethod.Post);
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<MobileUnitCameraSettings>> response = Execute<List<MobileUnitCameraSettings>>(request);
			return response.Data;
		}

		public async Task<List<MobileUnitConfigurationState>> GetConfigurationStateAsync(List<long> assetIds)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DeviceConfigController.GETCONFIGURATIONSTATE, HttpMethod.Post);
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<MobileUnitConfigurationState>> response = await ExecuteAsync<List<MobileUnitConfigurationState>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public List<MobileUnitConfigurationState> GetConfigurationState(List<long> assetIds)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DeviceConfigController.GETCONFIGURATIONSTATE, HttpMethod.Post);
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<MobileUnitConfigurationState>> response = Execute<List<MobileUnitConfigurationState>>(request);
			return response.Data;
		}

		public async Task<List<MobileUnitDeviceConfiguration>> GetMobileUnitDeviceConfigurationsByAssetIdsAsync(List<long> assetIds)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DeviceConfigController.GETCONFIGURATIONSBYASSETIDS, HttpMethod.Post);
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<MobileUnitDeviceConfiguration>> response = await ExecuteAsync<List<MobileUnitDeviceConfiguration>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public List<MobileUnitDeviceConfiguration> GetMobileUnitDeviceConfigurationsByAssetIds(List<long> assetIds)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DeviceConfigController.GETCONFIGURATIONSBYASSETIDS, HttpMethod.Post);
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<MobileUnitDeviceConfiguration>> response = Execute<List<MobileUnitDeviceConfiguration>>(request);
			return response.Data;
		}

		public async Task<List<MobileUnitDeviceConfiguration>> GetMobileUnitDeviceConfigurationsByGroupIdAsync(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DeviceConfigController.GETCONFIGURATIONSBYGROUPID, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			IHttpRestResponse<List<MobileUnitDeviceConfiguration>> response = await ExecuteAsync<List<MobileUnitDeviceConfiguration>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public List<MobileUnitDeviceConfiguration> GetMobileUnitDeviceConfigurationsByGroupId(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DeviceConfigController.GETCONFIGURATIONSBYGROUPID, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			IHttpRestResponse<List<MobileUnitDeviceConfiguration>> response = Execute<List<MobileUnitDeviceConfiguration>>(request);
			return response.Data;
		}
  }
}
