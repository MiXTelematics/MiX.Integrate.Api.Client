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

	}
}
