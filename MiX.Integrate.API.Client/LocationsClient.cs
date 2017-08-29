using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Locations;
using MiX.Integrate.Api.Client.Base;
using System.Net.Http;
using MiX.Integrate.API.Client.Base;

namespace MiX.Integrate.Api.Client
{
	public class LocationsClient : BaseClient, ILocationsClient
	{
		public LocationsClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public LocationsClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }


		public async Task<Location> GetAsync(long locationId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LOCATIONSCONTROLLER.GET, HttpMethod.Get);
			request.AddUrlSegment("locationId:long", locationId.ToString());
			IHttpRestResponse<Location> response = await ExecuteAsync<Location>(request).ConfigureAwait(false);
			return response.Data;
		}

		public Location Get(long locationId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LOCATIONSCONTROLLER.GET, HttpMethod.Get);
			request.AddUrlSegment("locationId:long", locationId.ToString());
			IHttpRestResponse<Location> response = Execute<Location>(request);
			return response.Data;
		}

		public async Task<List<Location>> GetAllAsync(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LOCATIONSCONTROLLER.GETALL, HttpMethod.Get);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			IHttpRestResponse<List<Location>> response = await ExecuteAsync<List<Location>>(request);
			return response.Data;
		}
		public List<Location> GetAll(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LOCATIONSCONTROLLER.GETALL, HttpMethod.Get);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			IHttpRestResponse<List<Location>> response = Execute<List<Location>>(request);
			return response.Data;
		}

		public async Task UpdateAsync(Location location, long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LOCATIONSCONTROLLER.UPDATEASYNC, HttpMethod.Put);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddJsonBody(location);
			await ExecuteAsync(request);
		}
		public void Update(Location location, long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LOCATIONSCONTROLLER.UPDATEASYNC, HttpMethod.Put);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddJsonBody(location);
			Execute(request);
		}

		public async Task<long> AddAsync(Location location, long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LOCATIONSCONTROLLER.ADDASYNC, HttpMethod.Post);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddJsonBody(location);
			IHttpRestResponse response = await ExecuteAsync(request);
			long locationId = Convert.ToInt64(GetResponseHeader(response.Headers, "locationId"));
			return locationId;
		}

		public long Add(Location location, long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LOCATIONSCONTROLLER.ADDASYNC, HttpMethod.Post);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddJsonBody(location);
			IHttpRestResponse response = Execute(request);
			long locationId = Convert.ToInt64(GetResponseHeader(response.Headers, "locationId"));
			return locationId;
		}

		public async Task DeleteAsync(long groupId, long locationId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LOCATIONSCONTROLLER.DELETEASYNC, HttpMethod.Delete);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddUrlSegment("locationId:long", locationId.ToString());
			await ExecuteAsync(request);
		}

		public void Delete(long groupId, long locationId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LOCATIONSCONTROLLER.DELETEASYNC, HttpMethod.Delete);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddUrlSegment("locationId:long", locationId.ToString());
			Execute(request);
		}
	}
}
