using System;
using System.Collections.Generic;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Positions;
using System.Threading.Tasks;
using MiX.Integrate.Api.Client.Base;
using System.Net.Http;

namespace MiX.Integrate.Api.Client
{
	public class PositionsClient : BaseClient, IPositionsClient
	{

		public PositionsClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public PositionsClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public List<Position> GetLatestByAssetIds(List<long> assetIds, byte quantity, DateTime? cachedSince = null)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.POSITIONSCONTROLLER.GETLATESTFORASSETS, HttpMethod.Post);
			request.AddUrlSegment("quantity", quantity.ToString());
			if (cachedSince.HasValue)
				request.AddQueryParameter("cachedSince", cachedSince.Value.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<Position>> response = Execute<List<Position>>(request);
			return response.Data;
		}

		public async Task<List<Position>> GetLatestByAssetIdsAsync(List<long> assetIds, byte quantity, DateTime? cachedSince = null)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.POSITIONSCONTROLLER.GETLATESTFORASSETS, HttpMethod.Post);
			request.AddUrlSegment("quantity", quantity.ToString());
			if (cachedSince.HasValue)
				request.AddQueryParameter("cachedSince", cachedSince.Value.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<Position>> response = await ExecuteAsync<List<Position>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public List<Position> GetLatestByGroupIds(List<long> groupIds, byte quantity, DateTime? cachedSince = null)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.POSITIONSCONTROLLER.GETLATESTFORGROUPS, HttpMethod.Post);
			request.AddUrlSegment("quantity", quantity.ToString());
			if (cachedSince.HasValue)
				request.AddQueryParameter("cachedSince", cachedSince.Value.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(groupIds);
			IHttpRestResponse<List<Position>> response = Execute<List<Position>>(request);
			return response.Data;
		}

		public async Task<List<Position>> GetLatestByGroupIdsAsync(List<long> groupIds, byte quantity, DateTime? cachedSince = null)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.POSITIONSCONTROLLER.GETLATESTFORGROUPS, HttpMethod.Post);
			request.AddUrlSegment("quantity", quantity.ToString());
			if (cachedSince.HasValue)
				request.AddQueryParameter("cachedSince", cachedSince.Value.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(groupIds);
			IHttpRestResponse<List<Position>> response = await ExecuteAsync<List<Position>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public List<Position> GetSinceByAssetIds(List<long> assetIds, DateTime since)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.POSITIONSCONTROLLER.GETSINCEFORASSETS, HttpMethod.Post);
			request.AddUrlSegment("since", since.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<Position>> response = Execute<List<Position>>(request);
			return response.Data;
		}

		public async Task<List<Position>> GetSinceByAssetIdsAsync(List<long> assetIds, DateTime since)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.POSITIONSCONTROLLER.GETSINCEFORASSETS, HttpMethod.Post);
			request.AddUrlSegment("since", since.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<Position>> response = await ExecuteAsync<List<Position>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public List<Position> GetByDateRangeByAssetIds(List<long> assetIds, DateTime fromDate, DateTime toDate)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.POSITIONSCONTROLLER.GETRANGEFORASSETS, HttpMethod.Post);
			request.AddUrlSegment("from", fromDate.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDate.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<Position>> response = Execute<List<Position>>(request);
			return response.Data;
		}

		public async Task<List<Position>> GetByDateRangeByAssetIdsAsync(List<long> assetIds, DateTime fromDate, DateTime toDate)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.POSITIONSCONTROLLER.GETRANGEFORASSETS, HttpMethod.Post);
			request.AddUrlSegment("from", fromDate.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDate.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<Position>> response = await ExecuteAsync<List<Position>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public List<Position> GetByDateRangeByGroupIds(List<long> groupIds, DateTime fromDate, DateTime toDate)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.POSITIONSCONTROLLER.GETRANGEFORGROUPS, HttpMethod.Post);
			request.AddUrlSegment("from", fromDate.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDate.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(groupIds);
			IHttpRestResponse<List<Position>> response = Execute<List<Position>>(request);
			return response.Data;
		}

		public async Task<List<Position>> GetByDateRangeByGroupIdsAsync(List<long> groupIds, DateTime fromDate, DateTime toDate)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.POSITIONSCONTROLLER.GETRANGEFORGROUPS, HttpMethod.Post);
			request.AddUrlSegment("from", fromDate.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDate.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(groupIds);
			IHttpRestResponse<List<Position>> response = await ExecuteAsync<List<Position>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public List<Position> GetByDateRangeByDriverIds(List<long> driverIds, DateTime fromDate, DateTime toDate)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.POSITIONSCONTROLLER.GETRANGEFORDRIVERS, HttpMethod.Post);
			request.AddUrlSegment("from", fromDate.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDate.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(driverIds);
			IHttpRestResponse<List<Position>> response = Execute<List<Position>>(request);
			return response.Data;
		}

		public async Task<List<Position>> GetByDateRangeByDriverIdsAsync(List<long> driverIds, DateTime fromDate, DateTime toDate)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.POSITIONSCONTROLLER.GETRANGEFORDRIVERS, HttpMethod.Post);
			request.AddUrlSegment("from", fromDate.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDate.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(driverIds);
			IHttpRestResponse<List<Position>> response = await ExecuteAsync<List<Position>>(request).ConfigureAwait(false);
			return response.Data;
		}
	}
}
