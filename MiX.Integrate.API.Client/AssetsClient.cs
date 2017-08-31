using System.Collections.Generic; 
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Assets; 
using System.Threading.Tasks;
using MiX.Integrate.Api.Client.Base;
using MiX.Integrate.API.Client.Base;
using System.Net.Http;

namespace MiX.Integrate.Api.Client
{
	public class AssetsClient : BaseClient, IAssetsClient
	{

		public AssetsClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public AssetsClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public List<Asset> GetAll(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ASSETSCONTROLLER.GETALL, HttpMethod.Get);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			IHttpRestResponse<List<Asset>> response = Execute<List<Asset>>(request);
			return response.Data;
		}

		public async Task<List<Asset>> GetAllAsync(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ASSETSCONTROLLER.GETALL, HttpMethod.Get);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			IHttpRestResponse<List<Asset>> response = await ExecuteAsync<List<Asset>>(request);
			return response.Data;
		}

		public Asset Get(long assetId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ASSETSCONTROLLER.GET, HttpMethod.Get);
			request.AddUrlSegment("assetId:long", assetId.ToString());
			IHttpRestResponse<Asset> response = Execute<Asset>(request);
			return response.Data;
		}

		public async Task<Asset> GetAsync(long assetId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ASSETSCONTROLLER.GET, HttpMethod.Get);
			request.AddUrlSegment("assetId:long", assetId.ToString());
			IHttpRestResponse<Asset> response = await ExecuteAsync<Asset>(request);
			return response.Data;
		}

		public Asset GetByGroup(long groupId, long assetId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ASSETSCONTROLLER.GETBYGROUP, HttpMethod.Get);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddUrlSegment("assetId:long", assetId.ToString());
			IHttpRestResponse<Asset> response = Execute<Asset>(request);
			return response.Data;
		}

		public async Task<Asset> GetByGroupAsync(long groupId, long assetId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ASSETSCONTROLLER.GETBYGROUP, HttpMethod.Get);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddUrlSegment("assetId:long", assetId.ToString());
			IHttpRestResponse<Asset> response = await ExecuteAsync<Asset>(request);
			return response.Data;
		}

		public void Update(Asset asset)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ASSETSCONTROLLER.GETBYGROUP, HttpMethod.Put);
			request.AddJsonBody(asset);
			Execute(request);
		}

		public async Task UpdateAsync(Asset asset)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ASSETSCONTROLLER.GETBYGROUP, HttpMethod.Put);
			request.AddJsonBody(asset);
			await ExecuteAsync(request);
		}

	}
}