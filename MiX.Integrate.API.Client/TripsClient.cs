using System;
using System.Collections.Generic;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Trips;
using System.Threading.Tasks;
using MiX.Integrate.Api.Client.Base;
using System.Net.Http;

namespace MiX.Integrate.Api.Client
{
	public class TripsClient : BaseClient, ITripsClient
	{

		public TripsClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public TripsClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public IList<Trip> GetLatestForAssets(List<long> assetIds, byte quantity = 1, DateTime? cachedSince = null, bool includeSubTrips = false)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETLATESTFORASSETS, HttpMethod.Post);
			request.AddUrlSegment("quantity", quantity.ToString());
			if (cachedSince.HasValue)
				request.AddQueryParameter("cachedSince", cachedSince.Value.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<Trip>> response = Execute<List<Trip>>(request);
			return response.Data;
		}

		public async Task<IList<Trip>> GetLatestForAssetsAsync(List<long> assetIds, byte quantity = 1, DateTime? cachedSince = null, bool includeSubTrips = false)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETLATESTFORASSETS, HttpMethod.Post);
			request.AddUrlSegment("quantity", quantity.ToString());
			if (cachedSince.HasValue)
				request.AddQueryParameter("cachedSince", cachedSince.Value.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<Trip>> response = await ExecuteAsync<List<Trip>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<Trip> GetLatestForDrivers(List<long> driverIds, byte quantity = 1, DateTime? cachedSince = null, bool includeSubTrips = false)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETLATESTFORDRIVERS, HttpMethod.Post);
			request.AddUrlSegment("quantity", quantity.ToString());
			if (cachedSince.HasValue)
				request.AddQueryParameter("cachedSince", cachedSince.Value.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(driverIds);
			IHttpRestResponse<List<Trip>> response = Execute<List<Trip>>(request);
			return response.Data;
		}

		public async Task<IList<Trip>> GetLatestForDriversAsync(List<long> driverIds, byte quantity = 1, DateTime? cachedSince = null, bool includeSubTrips = false)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETLATESTFORDRIVERS, HttpMethod.Post);
			request.AddUrlSegment("quantity", quantity.ToString());
			if (cachedSince.HasValue)
				request.AddQueryParameter("cachedSince", cachedSince.Value.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(driverIds);
			IHttpRestResponse<List<Trip>> response = await ExecuteAsync<List<Trip>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<Trip> GetLatestForGroups(List<long> groupIds, string entityType, byte quantity = 1, DateTime? cachedSince = null, bool includeSubTrips = false)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETLATESTFORGROUPS, HttpMethod.Post);
			request.AddUrlSegment("quantity", quantity.ToString());
			request.AddUrlSegment("entityType", entityType);
			if (cachedSince.HasValue)
				request.AddQueryParameter("cachedSince", cachedSince.Value.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(groupIds);
			IHttpRestResponse<List<Trip>> response = Execute<List<Trip>>(request);
			return response.Data;
		}

		public async Task<IList<Trip>> GetLatestForGroupsAsync(List<long> groupIds, string entityType, byte quantity = 1, DateTime? cachedSince = null, bool includeSubTrips = false)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETLATESTFORGROUPS, HttpMethod.Post);
			request.AddUrlSegment("quantity", quantity.ToString());
			request.AddUrlSegment("entityType", entityType);
			if (cachedSince.HasValue)
				request.AddQueryParameter("cachedSince", cachedSince.Value.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(groupIds);
			IHttpRestResponse<List<Trip>> response = await ExecuteAsync<List<Trip>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<Trip> GetRangeForAssets(List<long> assetIds, DateTime from, DateTime to, bool includeSubTrips = false)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETRANGEFORASSETS, HttpMethod.Post);
			request.AddUrlSegment("from", from.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<Trip>> response = Execute<List<Trip>>(request);
			return response.Data;
		}

		public async Task<IList<Trip>> GetRangeForAssetsAsync(List<long> assetIds, DateTime from, DateTime to, bool includeSubTrips = false)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETRANGEFORASSETS, HttpMethod.Post);
			request.AddUrlSegment("from", from.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<Trip>> response = await ExecuteAsync<List<Trip>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<Trip> GetRangeForDrivers(List<long> driverIds, DateTime from, DateTime to, bool includeSubTrips = false)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETRANGEFORDRIVERS, HttpMethod.Post);
			request.AddUrlSegment("from", from.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(driverIds);
			IHttpRestResponse<List<Trip>> response = Execute<List<Trip>>(request);
			return response.Data;
		}

		public async Task<IList<Trip>> GetRangeForDriversAsync(List<long> driverIds, DateTime from, DateTime to, bool includeSubTrips = false)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETRANGEFORDRIVERS, HttpMethod.Post);
			request.AddUrlSegment("from", from.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(driverIds);
			IHttpRestResponse<List<Trip>> response = await ExecuteAsync<List<Trip>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<Trip> GetRangeForGroups(List<long> groupIds, string entityType, DateTime from, DateTime to, bool includeSubTrips = false)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETRANGEFORGROUPS, HttpMethod.Post);
			request.AddUrlSegment("entityType", entityType);
			request.AddUrlSegment("from", from.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(groupIds);
			IHttpRestResponse<List<Trip>> response = Execute<List<Trip>>(request);
			return response.Data;
		}

		public async Task<IList<Trip>> GetRangeForGroupsAsync(List<long> groupIds, string entityType, DateTime from, DateTime to, bool includeSubTrips = false)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETRANGEFORGROUPS, HttpMethod.Post);
			request.AddUrlSegment("entityType", entityType);
			request.AddUrlSegment("from", from.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(groupIds);
			IHttpRestResponse<List<Trip>> response = await ExecuteAsync<List<Trip>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<Trip> GetSinceForAssets(List<long> assetIds, DateTime since, bool includeSubTrips = false)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETSINCEFORASSETS, HttpMethod.Post);
			request.AddUrlSegment("since", since.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<Trip>> response = Execute<List<Trip>>(request);
			return response.Data;
		}

		public async Task<IList<Trip>> GetSinceForAssetsAsync(List<long> assetIds, DateTime since, bool includeSubTrips = false)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETSINCEFORASSETS, HttpMethod.Post);
			request.AddUrlSegment("since", since.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<Trip>> response = await ExecuteAsync<List<Trip>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<Trip> GetSinceForDrivers(List<long> driverIds, DateTime since, bool includeSubTrips = false)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETSINCEFORDRIVERS, HttpMethod.Post);
			request.AddUrlSegment("since", since.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(driverIds);
			IHttpRestResponse<List<Trip>> response = Execute<List<Trip>>(request);
			return response.Data;
		}

		public async Task<IList<Trip>> GetSinceForDriversAsync(List<long> driverIds, DateTime since, bool includeSubTrips = false)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETSINCEFORDRIVERS, HttpMethod.Post);
			request.AddUrlSegment("since", since.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(driverIds);
			IHttpRestResponse<List<Trip>> response = await ExecuteAsync<List<Trip>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<Trip> GetSinceForGroups(List<long> groupIds, string entityType, DateTime since, bool includeSubTrips = false)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETSINCEFORGROUPS, HttpMethod.Post);
			request.AddUrlSegment("entityType", entityType);
			request.AddUrlSegment("since", since.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(groupIds);
			IHttpRestResponse<List<Trip>> response = Execute<List<Trip>>(request);
			return response.Data;
		}

		public async Task<IList<Trip>> GetSinceForGroupsAsync(List<long> groupIds, string entityType, DateTime since, bool includeSubTrips = false)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.TRIPSCONTROLLER.GETSINCEFORGROUPS, HttpMethod.Post);
			request.AddUrlSegment("entityType", entityType);
			request.AddUrlSegment("since", since.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddQueryParameter("includeSubTrips", includeSubTrips.ToString());
			request.AddJsonBody(groupIds);
			IHttpRestResponse<List<Trip>> response = await ExecuteAsync<List<Trip>>(request).ConfigureAwait(false);
			return response.Data;
		}

	}
}
