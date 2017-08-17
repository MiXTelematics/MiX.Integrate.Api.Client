using System;
using System.Collections.Generic;

using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Trips;

using RestSharp;
using System.Threading.Tasks;

namespace MiX.Integrate.Api.Client
{
	public class TripsClient : BaseClient, ITripsClient
	{

		public TripsClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public TripsClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public IList<Trip> GetLatestForAssets(List<long> assetIds, byte quantity = 1, DateTime? cachedSince = null, bool includeSubTrips = false)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETLATESTFORASSETS, Method.POST);
			request.AddUrlSegment("quantity", quantity.ToString());
			if (cachedSince.HasValue)
				request.AddParameter("cachedSince", cachedSince.Value.ToUniversalTime().ToString(DataFormats.DateTime_Format), ParameterType.QueryString);
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(assetIds);
			IRestResponse<List<Trip>> response = Execute<List<Trip>>(request);
			return response.Data;
		}

		public async Task<IList<Trip>> GetLatestForAssetsAsync(List<long> assetIds, byte quantity = 1, DateTime? cachedSince = null, bool includeSubTrips = false)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETLATESTFORASSETS, Method.POST);
			request.AddUrlSegment("quantity", quantity.ToString());
			if (cachedSince.HasValue)
				request.AddParameter("cachedSince", cachedSince.Value.ToUniversalTime().ToString(DataFormats.DateTime_Format), ParameterType.QueryString);
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(assetIds);
			IRestResponse<List<Trip>> response = await ExecuteAsync<List<Trip>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<Trip> GetLatestForDrivers(List<long> driverIds, byte quantity = 1, DateTime? cachedSince = null, bool includeSubTrips = false)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETLATESTFORDRIVERS, Method.POST);
			request.AddUrlSegment("quantity", quantity.ToString());
			if (cachedSince.HasValue)
				request.AddParameter("cachedSince", cachedSince.Value.ToUniversalTime().ToString(DataFormats.DateTime_Format), ParameterType.QueryString);
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(driverIds);
			IRestResponse<List<Trip>> response = Execute<List<Trip>>(request);
			return response.Data;
		}

		public async Task<IList<Trip>> GetLatestForDriversAsync(List<long> driverIds, byte quantity = 1, DateTime? cachedSince = null, bool includeSubTrips = false)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETLATESTFORDRIVERS, Method.POST);
			request.AddUrlSegment("quantity", quantity.ToString());
			if (cachedSince.HasValue)
				request.AddParameter("cachedSince", cachedSince.Value.ToUniversalTime().ToString(DataFormats.DateTime_Format), ParameterType.QueryString);
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(driverIds);
			IRestResponse<List<Trip>> response = await ExecuteAsync<List<Trip>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<Trip> GetLatestForGroups(List<long> groupIds, string entityType, byte quantity = 1, DateTime? cachedSince = null, bool includeSubTrips = false)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETLATESTFORGROUPS, Method.POST);
			request.AddUrlSegment("quantity", quantity.ToString());
			request.AddUrlSegment("entityType", entityType);
			if (cachedSince.HasValue)
				request.AddParameter("cachedSince", cachedSince.Value.ToUniversalTime().ToString(DataFormats.DateTime_Format), ParameterType.QueryString);
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(groupIds);
			IRestResponse<List<Trip>> response = Execute<List<Trip>>(request);
			return response.Data;
		}

		public async Task<IList<Trip>> GetLatestForGroupsAsync(List<long> groupIds, string entityType, byte quantity = 1, DateTime? cachedSince = null, bool includeSubTrips = false)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETLATESTFORGROUPS, Method.POST);
			request.AddUrlSegment("quantity", quantity.ToString());
			request.AddUrlSegment("entityType", entityType);
			if (cachedSince.HasValue)
				request.AddParameter("cachedSince", cachedSince.Value.ToUniversalTime().ToString(DataFormats.DateTime_Format), ParameterType.QueryString);
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(groupIds);
			IRestResponse<List<Trip>> response = await ExecuteAsync<List<Trip>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<Trip> GetRangeForAssets(List<long> assetIds, DateTime from, DateTime to, bool includeSubTrips = false)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETRANGEFORASSETS, Method.POST);
			request.AddUrlSegment("from", from.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(assetIds);
			IRestResponse<List<Trip>> response = Execute<List<Trip>>(request);
			return response.Data;
		}

		public async Task<IList<Trip>> GetRangeForAssetsAsync(List<long> assetIds, DateTime from, DateTime to, bool includeSubTrips = false)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETRANGEFORASSETS, Method.POST);
			request.AddUrlSegment("from", from.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(assetIds);
			IRestResponse<List<Trip>> response = await ExecuteAsync<List<Trip>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<Trip> GetRangeForDrivers(List<long> driverIds, DateTime from, DateTime to, bool includeSubTrips = false)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETRANGEFORDRIVERS, Method.POST);
			request.AddUrlSegment("from", from.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(driverIds);
			IRestResponse<List<Trip>> response = Execute<List<Trip>>(request);
			return response.Data;
		}

		public async Task<IList<Trip>> GetRangeForDriversAsync(List<long> driverIds, DateTime from, DateTime to, bool includeSubTrips = false)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETRANGEFORDRIVERS, Method.POST);
			request.AddUrlSegment("from", from.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(driverIds);
			IRestResponse<List<Trip>> response = await ExecuteAsync<List<Trip>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<Trip> GetRangeForGroups(List<long> groupIds, string entityType, DateTime from, DateTime to, bool includeSubTrips = false)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETRANGEFORGROUPS, Method.POST);
			request.AddUrlSegment("entityType", entityType);
			request.AddUrlSegment("from", from.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(groupIds);
			IRestResponse<List<Trip>> response = Execute<List<Trip>>(request);
			return response.Data;
		}

		public async Task<IList<Trip>> GetRangeForGroupsAsync(List<long> groupIds, string entityType, DateTime from, DateTime to, bool includeSubTrips = false)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETRANGEFORGROUPS, Method.POST);
			request.AddUrlSegment("entityType", entityType);
			request.AddUrlSegment("from", from.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(groupIds);
			IRestResponse<List<Trip>> response = await ExecuteAsync<List<Trip>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<Trip> GetSinceForAssets(List<long> assetIds, DateTime since, bool includeSubTrips = false)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETSINCEFORASSETS, Method.POST);
			request.AddUrlSegment("since", since.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(assetIds);
			IRestResponse<List<Trip>> response = Execute<List<Trip>>(request);
			return response.Data;
		}

		public async Task<IList<Trip>> GetSinceForAssetsAsync(List<long> assetIds, DateTime since, bool includeSubTrips = false)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETSINCEFORASSETS, Method.POST);
			request.AddUrlSegment("since", since.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(assetIds);
			IRestResponse<List<Trip>> response = await ExecuteAsync<List<Trip>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<Trip> GetSinceForDrivers(List<long> driverIds, DateTime since, bool includeSubTrips = false)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETSINCEFORDRIVERS, Method.POST);
			request.AddUrlSegment("since", since.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(driverIds);
			IRestResponse<List<Trip>> response = Execute<List<Trip>>(request);
			return response.Data;
		}

		public async Task<IList<Trip>> GetSinceForDriversAsync(List<long> driverIds, DateTime since, bool includeSubTrips = false)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETSINCEFORDRIVERS, Method.POST);
			request.AddUrlSegment("since", since.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(driverIds);
			IRestResponse<List<Trip>> response = await ExecuteAsync<List<Trip>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<Trip> GetSinceForGroups(List<long> groupIds, string entityType, DateTime since, bool includeSubTrips = false)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETSINCEFORGROUPS, Method.POST);
			request.AddUrlSegment("entityType", entityType);
			request.AddUrlSegment("since", since.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(groupIds);
			IRestResponse<List<Trip>> response = Execute<List<Trip>>(request);
			return response.Data;
		}

		public async Task<IList<Trip>> GetSinceForGroupsAsync(List<long> groupIds, string entityType, DateTime since, bool includeSubTrips = false)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETSINCEFORGROUPS, Method.POST);
			request.AddUrlSegment("entityType", entityType);
			request.AddUrlSegment("since", since.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(groupIds);
			IRestResponse<List<Trip>> response = await ExecuteAsync<List<Trip>>(request).ConfigureAwait(false);
			return response.Data;
		}

	}
}
