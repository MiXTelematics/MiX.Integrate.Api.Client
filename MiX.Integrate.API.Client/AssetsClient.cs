using System.Collections.Generic;

using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Assets;

using RestSharp;
using System.Threading.Tasks;
using MiX.Integrate.Api.Client.Base;

namespace MiX.Integrate.Api.Client
{
	public class AssetsClient : BaseClient, IAssetsClient
	{

		public AssetsClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public AssetsClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public List<Asset> GetAll(long groupId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.ASSETSCONTROLLER.GETALL, Method.GET);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			IRestResponse<List<Asset>> response = Execute<List<Asset>>(request);
			return response.Data;
		}

		public async Task<List<Asset>> GetAllAsync(long groupId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.ASSETSCONTROLLER.GETALL, Method.GET);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			IRestResponse<List<Asset>> response = await ExecuteAsync<List<Asset>>(request);
			return response.Data;
		}

		public Asset Get(long assetId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.ASSETSCONTROLLER.GET, Method.GET);
			request.AddUrlSegment("assetId:long", assetId.ToString());
			IRestResponse<Asset> response = Execute<Asset>(request);
			return response.Data;
		}

		public async Task<Asset> GetAsync(long assetId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.ASSETSCONTROLLER.GET, Method.GET);
			request.AddUrlSegment("assetId:long", assetId.ToString());
			IRestResponse<Asset> response = await ExecuteAsync<Asset>(request);
			return response.Data;
		}

		public Asset GetByGroup(long groupId, long assetId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.ASSETSCONTROLLER.GETBYGROUP, Method.GET);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddUrlSegment("assetId:long", assetId.ToString());
			IRestResponse<Asset> response = Execute<Asset>(request);
			return response.Data;
		}

		public async Task<Asset> GetByGroupAsync(long groupId, long assetId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.ASSETSCONTROLLER.GETBYGROUP, Method.GET);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddUrlSegment("assetId:long", assetId.ToString());
			IRestResponse<Asset> response = await ExecuteAsync<Asset>(request);
			return response.Data;
		}

		public void Update(Asset asset)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.ASSETSCONTROLLER.GETBYGROUP, Method.PUT);
			request.AddJsonBody(asset);
			Execute(request);
		}

		public async Task UpdateAsync(Asset asset)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.ASSETSCONTROLLER.GETBYGROUP, Method.PUT);
			request.AddJsonBody(asset);
			await ExecuteAsync(request);
		}

	}
}