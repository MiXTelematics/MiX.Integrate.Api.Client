using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Assets;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	/// <inheritdoc cref="IAssetsClient"/>
	public class AssetsClient : BaseClient, IAssetsClient
	{
		public AssetsClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public AssetsClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public List<Asset> GetAll(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.AssetsController.GETALL, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			IHttpRestResponse<List<Asset>> response = Execute<List<Asset>>(request);
			return response.Data;
		}

		public async Task<List<Asset>> GetAllAsync(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.AssetsController.GETALL, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			IHttpRestResponse<List<Asset>> response = await ExecuteAsync<List<Asset>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public List<AdditionalDetails> GetAdditionalDetailsByGroup(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.AssetsController.GETADDITIONALDETAILSBYGROUP, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			IHttpRestResponse<List<AdditionalDetails>> response = Execute<List<AdditionalDetails>>(request);
			return response.Data;
		}

		public async Task<List<AdditionalDetails>> GetAdditionalDetailsByGroupAsync(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.AssetsController.GETADDITIONALDETAILSBYGROUP, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			IHttpRestResponse<List<AdditionalDetails>> response = await ExecuteAsync<List<AdditionalDetails>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public List<AssetDiagnostics> GetAssetDiagnostics(long organisationId, IList<long> assetIds)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.AssetsController.GETASSETDIAG, HttpMethod.Post);
			request.AddUrlSegment("groupId", organisationId.ToString());
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<AssetDiagnostics>> response = Execute<List<AssetDiagnostics>>(request);
			return response.Data;
		}

		public async Task<List<AssetDiagnostics>> GetAssetDiagnosticsAsync(long organisationId, IList<long> assetIds)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.AssetsController.GETASSETDIAG, HttpMethod.Post);
			request.AddUrlSegment("groupId", organisationId.ToString());
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<AssetDiagnostics>> response = await ExecuteAsync<List<AssetDiagnostics>>(request).ConfigureAwait(false);
			return response.Data;
		}


		public List<Asset> GetAll(long groupId, string filterType, string wildCard)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.AssetsController.GETALL, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddQueryParameter("filterType", filterType);
			request.AddQueryParameter("wildCard", wildCard);
			IHttpRestResponse<List<Asset>> response = Execute<List<Asset>>(request);
			return response.Data;
		}

		public async Task<List<Asset>> GetAllAsync(long groupId, string filterType, string wildCard)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.AssetsController.GETALL, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddQueryParameter("filterType", filterType);
			request.AddQueryParameter("wildCard", wildCard);
			IHttpRestResponse<List<Asset>> response = await ExecuteAsync<List<Asset>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public Asset Get(long assetId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.AssetsController.GET, HttpMethod.Get);
			request.AddUrlSegment("assetId", assetId.ToString());
			IHttpRestResponse<Asset> response = Execute<Asset>(request);
			return response.Data;
		}

		public async Task<Asset> GetAsync(long assetId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.AssetsController.GET, HttpMethod.Get);
			request.AddUrlSegment("assetId", assetId.ToString());
			IHttpRestResponse<Asset> response = await ExecuteAsync<Asset>(request).ConfigureAwait(false);
			return response.Data;
		}

		public Asset GetByGroup(long groupId, long assetId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.AssetsController.GETBYGROUP, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddUrlSegment("assetId", assetId.ToString());
			IHttpRestResponse<Asset> response = Execute<Asset>(request);
			return response.Data;
		}

		public async Task<Asset> GetByGroupAsync(long groupId, long assetId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.AssetsController.GETBYGROUP, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddUrlSegment("assetId", assetId.ToString());
			IHttpRestResponse<Asset> response = await ExecuteAsync<Asset>(request).ConfigureAwait(false);
			return response.Data;
		}

		public void Update(Asset asset)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.AssetsController.UPDATE, HttpMethod.Put);
			request.AddJsonBody(asset);
			Execute(request);
		}

		public async Task UpdateAsync(Asset asset)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.AssetsController.UPDATE, HttpMethod.Put);
			request.AddJsonBody(asset);
			await ExecuteAsync(request).ConfigureAwait(false);
		}

		public bool AddAssetState(long groupId, AssetState assetState)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.AssetsController.ADDASSETSTATE, HttpMethod.Post);
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
			IHttpRestRequest request = GetRequest(APIControllerRoutes.AssetsController.ADDASSETSTATE, HttpMethod.Post);
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
			IHttpRestRequest request = GetRequest(APIControllerRoutes.AssetsController.ADD, HttpMethod.Post);
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
			IHttpRestRequest request = GetRequest(APIControllerRoutes.AssetsController.ADD, HttpMethod.Post);
			request.AddJsonBody(asset);
			IHttpRestResponse response = await ExecuteAsync(request).ConfigureAwait(false);
			string idHeaderVal = GetResponseHeader(response.Headers, "assetId");
			long assetId;
			if (!long.TryParse(idHeaderVal, out assetId) || assetId == 0)
				throw new Exception("Could not determine the id of the newly-created asset");
			return assetId;
		}


		public List<string> GetManufacturerNames()
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.AssetsController.GETMANUFACTURERS, HttpMethod.Get);
			IHttpRestResponse<List<string>> response = Execute<List<string>>(request);
			return response.Data;
		}

		public async Task<List<string>> GetManufacturerNamesAsync()
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.AssetsController.GETMANUFACTURERS, HttpMethod.Get);
			IHttpRestResponse<List<string>> response = await ExecuteAsync<List<string>>(request);
			return response.Data;
		}

		/// <summary>Gets a list of the <see cref="Trailer"/> assets for the specified organisation</summary>
		public List<Trailer> GetTrailers(long organisationId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.AssetsController.GETTRAILERSFORORGANISATION, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			IHttpRestResponse<List<Trailer>> response = Execute<List<Trailer>>(request);
			return response.Data;
		}

		/// <summary>Gets a list of the <see cref="Trailer"/> assets for the specified organisation</summary>
		public async Task<List<Trailer>> GetTrailersAsync(long organisationId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.AssetsController.GETTRAILERSFORORGANISATION, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			IHttpRestResponse<List<Trailer>> response = await ExecuteAsync<List<Trailer>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public List<AssetService> GetServiceHistory(List<long> assetIds, DateTime @from, DateTime to)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.AssetsController.GETSERVICEHISTORY, HttpMethod.Post);
			request.AddUrlSegment("from", @from.ToString("yyyyMMdd"));
			request.AddUrlSegment("to", to.ToString("yyyyMMdd"));
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<AssetService>> response = Execute<List<AssetService>>(request);
			return response.Data;
		}

		public async Task<List<AssetService>> GetServiceHistoryAsync(List<long> assetIds, DateTime @from, DateTime to)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.AssetsController.GETSERVICEHISTORY, HttpMethod.Post);
			request.AddUrlSegment("from", @from.ToString("yyyyMMdd"));
			request.AddUrlSegment("to", to.ToString("yyyyMMdd"));
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<AssetService>> response = await ExecuteAsync<List<AssetService>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public List<AssetService> GetServiceHistoryByGroup(long groupId, DateTime @from, DateTime to)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.AssetsController.GETSERVICEHISTORYBYGROUP, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddUrlSegment("from", @from.ToString("yyyyMMdd"));
			request.AddUrlSegment("to", to.ToString("yyyyMMdd"));
			IHttpRestResponse<List<AssetService>> response = Execute<List<AssetService>>(request);
			return response.Data;
		}

		public async Task<List<AssetService>> GetServiceHistoryByGroupAsync(long groupId, DateTime @from, DateTime to)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.AssetsController.GETSERVICEHISTORYBYGROUP, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddUrlSegment("from", @from.ToString("yyyyMMdd"));
			request.AddUrlSegment("to", to.ToString("yyyyMMdd"));
			IHttpRestResponse<List<AssetService>> response = await ExecuteAsync<List<AssetService>>(request).ConfigureAwait(false);
			return response.Data;
		}
	}
}