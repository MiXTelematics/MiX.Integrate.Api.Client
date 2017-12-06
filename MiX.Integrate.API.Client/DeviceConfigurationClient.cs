using MiX.Integrate.Api.Client.Base;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.DeviceConfiguration;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiX.Integrate.Api.Client
{
	public class DeviceConfigurationClient : BaseClient, IDeviceConfigurationClient, IBaseClient
	{
		public DeviceConfigurationClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public DeviceConfigurationClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public async Task<List<ConnectedPeripheral>> GetConnectedPeripheralsForAssetsAsync(long groupId, List<long> assetIds)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DEVICECONFIGCONTROLLER.GETCONNECTEDPERIPHERALSFORASSETS, HttpMethod.Post);
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<ConnectedPeripheral>> response = await ExecuteAsync<List<ConnectedPeripheral>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public List<ConnectedPeripheral> GetConnectedPeripheralsForAssets(long groupId, List<long> assetIds)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DEVICECONFIGCONTROLLER.GETCONNECTEDPERIPHERALSFORASSETS, HttpMethod.Post);
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<ConnectedPeripheral>> response = Execute<List<ConnectedPeripheral>>(request);
			return response.Data;
		}

	}
}
