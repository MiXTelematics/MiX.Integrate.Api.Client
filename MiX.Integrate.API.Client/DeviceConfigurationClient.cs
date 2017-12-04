using MiX.Integrate.Api.Client.Base;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.DeviceConfiguration;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiX.Integrate.Api.Client
{
	public class DeviceConfigurationClient : BaseClient, IDeviceConfigurationClient
	{
		public DeviceConfigurationClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public DeviceConfigurationClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public async Task<List<ConfigurationGroupDetail>> GetConnectedPeripheralsForAssetsAsync(long groupId, List<long> assetIds)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DEVICECONFIGCONTROLLER.GETCONNECTEDPERIPHERALSFORASSETS, HttpMethod.Post);
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<ConfigurationGroupDetail>> response = await ExecuteAsync<List<ConfigurationGroupDetail>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public List<ConfigurationGroupDetail> GetConnectedPeripheralsForAssets(long groupId, List<long> assetIds)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DEVICECONFIGCONTROLLER.GETCONNECTEDPERIPHERALSFORASSETS, HttpMethod.Post);
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<ConfigurationGroupDetail>> response = Execute<List<ConfigurationGroupDetail>>(request);
			return response.Data;
		}

	}
}
