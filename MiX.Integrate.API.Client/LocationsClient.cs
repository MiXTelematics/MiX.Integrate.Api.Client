using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Locations;
using RestSharp;

namespace MiX.Integrate.Api.Client
{
	public class LocationsClient : BaseClient, ILocationsClient
	{
		public LocationsClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public LocationsClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }


		public async Task<Location> GetAsync(long locationId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.LOCATIONSCONTROLLER.GET, Method.GET);
			request.AddUrlSegment("locationId:long", locationId.ToString());
			IRestResponse<Location> response = await ExecuteAsync<Location>(request).ConfigureAwait(false);
			return response.Data;
		}

		public Location Get(long locationId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.LOCATIONSCONTROLLER.GET, Method.GET);
			request.AddUrlSegment("locationId:long", locationId.ToString());
			IRestResponse<Location> response = Execute<Location>(request);
			return response.Data;
		}

		public async Task<List<Location>> GetAllAsync(long groupId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.LOCATIONSCONTROLLER.GETALL, Method.GET);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			IRestResponse<List<Location>> response = await ExecuteAsync<List<Location>>(request);
			return response.Data;
		}
		public List<Location> GetAll(long groupId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.LOCATIONSCONTROLLER.GETALL, Method.GET);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			IRestResponse<List<Location>> response = Execute<List<Location>>(request);
			return response.Data;
		}

		public async Task UpdateAsync(Location location, long groupId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.LOCATIONSCONTROLLER.UPDATEASYNC, Method.PUT);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddJsonBody(location);
			await ExecuteAsync(request);
		}
		public void Update(Location location, long groupId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.LOCATIONSCONTROLLER.UPDATEASYNC, Method.PUT);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddJsonBody(location);
			Execute(request);
		}

		public async Task<long> AddAsync(Location location, long groupId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.LOCATIONSCONTROLLER.ADDASYNC, Method.POST);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddJsonBody(location);
			IRestResponse response = await ExecuteAsync(request); 
			long locationId = Convert.ToInt64(response.Headers.ToList().Find(x => x.Name.ToLower() == "locationId".ToLower()).Value.ToString());
			return locationId;
		}

		public long Add(Location location, long groupId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.LOCATIONSCONTROLLER.ADDASYNC, Method.POST);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddJsonBody(location);
			IRestResponse response = Execute(request);
			long locationId = Convert.ToInt64(response.Headers.ToList().Find(x => x.Name.ToLower() == "locationId".ToLower()).Value.ToString());
			return locationId;
		}

		public async Task DeleteAsync(long groupId, long locationId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.LOCATIONSCONTROLLER.DELETEASYNC, Method.DELETE);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddUrlSegment("locationId:long", locationId.ToString());
			await ExecuteAsync(request);
		}

		public void Delete(long groupId, long locationId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.LOCATIONSCONTROLLER.DELETEASYNC, Method.DELETE);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddUrlSegment("locationId:long", locationId.ToString());
			Execute(request);
		}
	}
}
