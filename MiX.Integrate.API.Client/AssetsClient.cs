using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Assets;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public class AssetsClient : BaseClient, IAssetsClient
	{

		public AssetsClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public AssetsClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public List<Asset> GetAll(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ASSETSCONTROLLER.GETALL, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			IHttpRestResponse<List<Asset>> response = Execute<List<Asset>>(request);
			return response.Data;
		}

		public async Task<List<Asset>> GetAllAsync(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ASSETSCONTROLLER.GETALL, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			IHttpRestResponse<List<Asset>> response = await ExecuteAsync<List<Asset>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public List<Asset> GetAll(long groupId, string filterType, string wildCard)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ASSETSCONTROLLER.GETALL, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddQueryParameter("filterType", filterType);
			request.AddQueryParameter("wildCard", wildCard);
			IHttpRestResponse<List<Asset>> response = Execute<List<Asset>>(request);
			return response.Data;
		}

		public async Task<List<Asset>> GetAllAsync(long groupId, string filterType, string wildCard)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ASSETSCONTROLLER.GETALL, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddQueryParameter("filterType", filterType);
			request.AddQueryParameter("wildCard", wildCard);
			IHttpRestResponse<List<Asset>> response = await ExecuteAsync<List<Asset>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public Asset Get(long assetId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ASSETSCONTROLLER.GET, HttpMethod.Get);
			request.AddUrlSegment("assetId", assetId.ToString());
			IHttpRestResponse<Asset> response = Execute<Asset>(request);
			return response.Data;
		}

		public async Task<Asset> GetAsync(long assetId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ASSETSCONTROLLER.GET, HttpMethod.Get);
			request.AddUrlSegment("assetId", assetId.ToString());
			IHttpRestResponse<Asset> response = await ExecuteAsync<Asset>(request).ConfigureAwait(false);
			return response.Data;
		}

		public Asset GetByGroup(long groupId, long assetId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ASSETSCONTROLLER.GETBYGROUP, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddUrlSegment("assetId", assetId.ToString());
			IHttpRestResponse<Asset> response = Execute<Asset>(request);
			return response.Data;
		}

		public async Task<Asset> GetByGroupAsync(long groupId, long assetId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ASSETSCONTROLLER.GETBYGROUP, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddUrlSegment("assetId", assetId.ToString());
			IHttpRestResponse<Asset> response = await ExecuteAsync<Asset>(request).ConfigureAwait(false);
			return response.Data;
		}

		public void Update(Asset asset)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ASSETSCONTROLLER.UPDATE, HttpMethod.Put);
			request.AddJsonBody(asset);
			Execute(request);
		}

		public async Task UpdateAsync(Asset asset)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ASSETSCONTROLLER.UPDATE, HttpMethod.Put);
			request.AddJsonBody(asset);
			await ExecuteAsync(request).ConfigureAwait(false);
		}

		public bool AddAssetState(long groupId, AssetState assetState)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ASSETSCONTROLLER.ADDASSETSTATE, HttpMethod.Post);
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddJsonBody(assetState);
			IHttpRestResponse response = Execute(request);
			if (response.StatusCode == System.Net.HttpStatusCode.OK)
				return true;
			else
				return false;
		}

		public async Task<bool> AddAssetStateAsync(long groupId, AssetState assetState)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ASSETSCONTROLLER.ADDASSETSTATE, HttpMethod.Post);
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddJsonBody(assetState);
			IHttpRestResponse response = await ExecuteAsync(request).ConfigureAwait(false);
			if (response.StatusCode == System.Net.HttpStatusCode.OK)
				return true;
			else
				return false;
		}

		public long Add(Asset asset)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ASSETSCONTROLLER.ADD, HttpMethod.Post);
			request.AddJsonBody(asset);
			IHttpRestResponse response = Execute(request);
			string idHeaderVal = GetResponseHeader(response.Headers, "assetId");
			long assetId;
			if (!long.TryParse(idHeaderVal, out assetId) || assetId == 0)
				throw new Exception("Could not determine the id of the newly-created asset");
			return assetId;
		}

		public async Task<long> AddAsync(Asset asset)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ASSETSCONTROLLER.ADD, HttpMethod.Post);
			request.AddJsonBody(asset);
			IHttpRestResponse response = await ExecuteAsync(request).ConfigureAwait(false);
			string idHeaderVal = GetResponseHeader(response.Headers, "assetId");
			long assetId;
			if (!long.TryParse(idHeaderVal, out assetId) || assetId == 0)
				throw new Exception("Could not determine the id of the newly-created asset");
			return assetId;
		}

	}
}