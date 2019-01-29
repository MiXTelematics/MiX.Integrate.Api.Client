﻿using MiX.Integrate.API.Client;
using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Carriers;
using MiX.Integrate.Shared.Entities.Positions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public class PositionsClient : BaseClient, IPositionsClient
	{

		public PositionsClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public PositionsClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public List<Position> GetLatestByAssetIds(List<long> assetIds, byte quantity, DateTime? cachedSince = null)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.PositionsController.GETLATESTFORASSETS, HttpMethod.Post);
			request.AddUrlSegment("quantity", quantity.ToString());
			if (cachedSince.HasValue)
				request.AddQueryParameter("cachedSince", cachedSince.Value.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<Position>> response = Execute<List<Position>>(request);
			return response.Data;
		}

		public async Task<List<Position>> GetLatestByAssetIdsAsync(List<long> assetIds, byte quantity, DateTime? cachedSince = null)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.PositionsController.GETLATESTFORASSETS, HttpMethod.Post);
			request.AddUrlSegment("quantity", quantity.ToString());
			if (cachedSince.HasValue)
				request.AddQueryParameter("cachedSince", cachedSince.Value.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<Position>> response = await ExecuteAsync<List<Position>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public List<Position> GetLatestByGroupIds(List<long> groupIds, byte quantity, DateTime? cachedSince = null)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.PositionsController.GETLATESTFORGROUPS, HttpMethod.Post);
			request.AddUrlSegment("quantity", quantity.ToString());
			if (cachedSince.HasValue)
				request.AddQueryParameter("cachedSince", cachedSince.Value.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(groupIds);
			IHttpRestResponse<List<Position>> response = Execute<List<Position>>(request);
			return response.Data;
		}

		public async Task<List<Position>> GetLatestByGroupIdsAsync(List<long> groupIds, byte quantity, DateTime? cachedSince = null)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.PositionsController.GETLATESTFORGROUPS, HttpMethod.Post);
			request.AddUrlSegment("quantity", quantity.ToString());
			if (cachedSince.HasValue)
				request.AddQueryParameter("cachedSince", cachedSince.Value.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(groupIds);
			IHttpRestResponse<List<Position>> response = await ExecuteAsync<List<Position>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public List<Position> GetSinceByAssetIds(List<long> assetIds, DateTime since)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.PositionsController.GETSINCEFORASSETS, HttpMethod.Post);
			request.AddUrlSegment("since", since.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<Position>> response = Execute<List<Position>>(request);
			return response.Data;
		}

		public async Task<List<Position>> GetSinceByAssetIdsAsync(List<long> assetIds, DateTime since)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.PositionsController.GETSINCEFORASSETS, HttpMethod.Post);
			request.AddUrlSegment("since", since.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<Position>> response = await ExecuteAsync<List<Position>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public List<Position> GetByDateRangeByAssetIds(List<long> assetIds, DateTime fromDate, DateTime toDate)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.PositionsController.GETRANGEFORASSETS, HttpMethod.Post);
			request.AddUrlSegment("from", fromDate.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDate.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<Position>> response = Execute<List<Position>>(request);
			return response.Data;
		}

		public async Task<List<Position>> GetByDateRangeByAssetIdsAsync(List<long> assetIds, DateTime fromDate, DateTime toDate)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.PositionsController.GETRANGEFORASSETS, HttpMethod.Post);
			request.AddUrlSegment("from", fromDate.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDate.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<Position>> response = await ExecuteAsync<List<Position>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public List<Position> GetByDateRangeByGroupIds(List<long> groupIds, DateTime fromDate, DateTime toDate)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.PositionsController.GETRANGEFORGROUPS, HttpMethod.Post);
			request.AddUrlSegment("from", fromDate.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDate.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(groupIds);
			IHttpRestResponse<List<Position>> response = Execute<List<Position>>(request);
			return response.Data;
		}

		public async Task<List<Position>> GetByDateRangeByGroupIdsAsync(List<long> groupIds, DateTime fromDate, DateTime toDate)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.PositionsController.GETRANGEFORGROUPS, HttpMethod.Post);
			request.AddUrlSegment("from", fromDate.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDate.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(groupIds);
			IHttpRestResponse<List<Position>> response = await ExecuteAsync<List<Position>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public List<Position> GetByDateRangeByDriverIds(List<long> driverIds, DateTime fromDate, DateTime toDate)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.PositionsController.GETRANGEFORDRIVERS, HttpMethod.Post);
			request.AddUrlSegment("from", fromDate.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDate.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(driverIds);
			IHttpRestResponse<List<Position>> response = Execute<List<Position>>(request);
			return response.Data;
		}

		public async Task<List<Position>> GetByDateRangeByDriverIdsAsync(List<long> driverIds, DateTime fromDate, DateTime toDate)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.PositionsController.GETRANGEFORDRIVERS, HttpMethod.Post);
			request.AddUrlSegment("from", fromDate.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDate.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(driverIds);
			IHttpRestResponse<List<Position>> response = await ExecuteAsync<List<Position>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public CreatedSinceResult<Position> GetCreatedSinceForGroups(List<long> groupIds, string entityType, string sinceToken, int quantity)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.PositionsController.GETCREATEDSINCEFORGROUPSASYNC, HttpMethod.Post);
			request.AddUrlSegment("entityType", entityType);
			request.AddUrlSegment("sinceToken", sinceToken);
			request.AddUrlSegment("quantity", quantity.ToString());
			request.AddJsonBody(groupIds);
			IHttpRestResponse<List<Position>> response = Execute<List<Position>>(request);
			string sHasMoreItems = GetResponseHeader(response.Headers, "HasMoreItems");
			string getSinceToken = GetResponseHeader(response.Headers, "GetSinceToken");
			bool hasMoreItems = false;
			if (!bool.TryParse(sHasMoreItems, out hasMoreItems))
				throw new Exception("Could not read the HasMoreItems header");
			return new CreatedSinceResult<Position>() { HasMoreItems = hasMoreItems, GetSinceToken = getSinceToken, Items = response.Data };
		}

		public async Task<CreatedSinceResult<Position>> GetCreatedSinceForGroupsAsync(List<long> groupIds, string entityType, string sinceToken, int quantity)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.PositionsController.GETCREATEDSINCEFORGROUPSASYNC, HttpMethod.Post);
			request.AddUrlSegment("entityType", entityType);
			request.AddUrlSegment("sinceToken", sinceToken);
			request.AddUrlSegment("quantity", quantity.ToString());
			request.AddJsonBody(groupIds);
			IHttpRestResponse<List<Position>> response = await ExecuteAsync<List<Position>>(request).ConfigureAwait(false);
			string sHasMoreItems = GetResponseHeader(response.Headers, "HasMoreItems");
			string getSinceToken = GetResponseHeader(response.Headers, "GetSinceToken");
			bool hasMoreItems = false;
			if (!bool.TryParse(sHasMoreItems, out hasMoreItems))
				throw new Exception("Could not read the HasMoreItems header");
			return new CreatedSinceResult<Position>() { HasMoreItems = hasMoreItems, GetSinceToken = getSinceToken, Items = response.Data };
		}

	}
}
