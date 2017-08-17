using System;
using System.Collections.Generic;

using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Positions;

using RestSharp;
using System.Threading.Tasks;

namespace MiX.Integrate.Api.Client
{
	public class PositionsClient : BaseClient, IPositionsClient
	{

		public PositionsClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public PositionsClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public List<Position> GetLatestByAssetIds(List<long> assetIds, byte quantity, DateTime? cachedSince = null)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.POSITIONSCONTROLLER.GETLATESTBYASSETIDS, Method.POST);
			request.AddUrlSegment("quantity", quantity.ToString());
			if (cachedSince.HasValue)
				request.AddParameter("cachedSince", cachedSince.Value.ToUniversalTime().ToString(DataFormats.DateTime_Format), ParameterType.QueryString);
			request.AddJsonBody(assetIds);
			IRestResponse<List<Position>> response = Execute<List<Position>>(request);
			return response.Data;
		}

		public async Task<List<Position>> GetLatestByAssetIdsAsync(List<long> assetIds, byte quantity, DateTime? cachedSince = null)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.POSITIONSCONTROLLER.GETLATESTBYASSETIDS, Method.POST);
			request.AddUrlSegment("quantity", quantity.ToString());
			if (cachedSince.HasValue)
				request.AddParameter("cachedSince", cachedSince.Value.ToUniversalTime().ToString(DataFormats.DateTime_Format), ParameterType.QueryString);
			request.AddJsonBody(assetIds);
			IRestResponse<List<Position>> response = await ExecuteAsync<List<Position>>(request);
			return response.Data;
		}

		public List<Position> GetLatestByGroupIds(List<long> groupIds, byte quantity, DateTime? cachedSince = null)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.POSITIONSCONTROLLER.GETLATESTBYGROUPIDS, Method.POST);
			request.AddUrlSegment("quantity", quantity.ToString());
			if (cachedSince.HasValue)
				request.AddParameter("cachedSince", cachedSince.Value.ToUniversalTime().ToString(DataFormats.DateTime_Format), ParameterType.QueryString);
			request.AddJsonBody(groupIds);
			IRestResponse<List<Position>> response = Execute<List<Position>>(request);
			return response.Data;
		}

		public async Task<List<Position>> GetLatestByGroupIdsAsync(List<long> groupIds, byte quantity, DateTime? cachedSince = null)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.POSITIONSCONTROLLER.GETLATESTBYGROUPIDS, Method.POST);
			request.AddUrlSegment("quantity", quantity.ToString());
			if (cachedSince.HasValue)
				request.AddParameter("cachedSince", cachedSince.Value.ToUniversalTime().ToString(DataFormats.DateTime_Format), ParameterType.QueryString);
			request.AddJsonBody(groupIds);
			IRestResponse<List<Position>> response = await ExecuteAsync<List<Position>>(request);
			return response.Data;
		}

		public List<Position> GetSinceByAssetIds(List<long> assetIds, DateTime since)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.POSITIONSCONTROLLER.GETSINCEBYASSETIDS, Method.POST);
			request.AddUrlSegment("since", since.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(assetIds);
			IRestResponse<List<Position>> response = Execute<List<Position>>(request);
			return response.Data;
		}

		public async Task<List<Position>> GetSinceByAssetIdsAsync(List<long> assetIds, DateTime since)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.POSITIONSCONTROLLER.GETSINCEBYASSETIDS, Method.POST);
			request.AddUrlSegment("since", since.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(assetIds);
			IRestResponse<List<Position>> response = await ExecuteAsync<List<Position>>(request);
			return response.Data;
		}

		public List<Position> GetByDateRangeByAssetIds(List<long> assetIds, DateTime fromDate, DateTime toDate)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.POSITIONSCONTROLLER.GETBYDATERANGEBYASSETTIDS, Method.POST);
			request.AddUrlSegment("from", fromDate.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDate.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(assetIds);
			IRestResponse<List<Position>> response = Execute<List<Position>>(request);
			return response.Data;
		}

		public async Task<List<Position>> GetByDateRangeByAssetIdsAsync(List<long> assetIds, DateTime fromDate, DateTime toDate)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.POSITIONSCONTROLLER.GETBYDATERANGEBYASSETTIDS, Method.POST);
			request.AddUrlSegment("from", fromDate.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDate.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(assetIds);
			IRestResponse<List<Position>> response = await ExecuteAsync<List<Position>>(request);
			return response.Data;
		}

		public List<Position> GetByDateRangeByGroupIds(List<long> groupIds, DateTime fromDate, DateTime toDate)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.POSITIONSCONTROLLER.GETBYDATERANGEBYGROUPIDS, Method.POST);
			request.AddUrlSegment("from", fromDate.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDate.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(groupIds);
			IRestResponse<List<Position>> response =  Execute<List<Position>>(request);
			return response.Data;
		}

		public async Task<List<Position>> GetByDateRangeByGroupIdsAsync(List<long> groupIds, DateTime fromDate, DateTime toDate)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.POSITIONSCONTROLLER.GETBYDATERANGEBYGROUPIDS, Method.POST);
			request.AddUrlSegment("from", fromDate.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDate.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(groupIds);
			IRestResponse<List<Position>> response = await ExecuteAsync<List<Position>>(request);
			return response.Data;
		}

		public List<Position> GetByDateRangeByDriverIds(List<long> driverIds, DateTime fromDate, DateTime toDate)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.POSITIONSCONTROLLER.GETBYDATERANGEBYDRIVERIDS, Method.POST);
			request.AddUrlSegment("from", fromDate.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDate.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(driverIds);
			IRestResponse<List<Position>> response =  Execute<List<Position>>(request);
			return response.Data;
		}

		public async Task<List<Position>> GetByDateRangeByDriverIdsAsync(List<long> driverIds, DateTime fromDate, DateTime toDate)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.POSITIONSCONTROLLER.GETBYDATERANGEBYDRIVERIDS, Method.POST);
			request.AddUrlSegment("from", fromDate.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDate.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(driverIds);
			IRestResponse<List<Position>> response = await ExecuteAsync<List<Position>>(request);
			return response.Data;
		}
	}
}
