using System.Collections.Generic;

using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Drivers;

using RestSharp;
using System.Threading.Tasks;

namespace MiX.Integrate.Api.Client
{
	public class DriversClient : BaseClient, IDriversClient
	{
		public DriversClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public DriversClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public List<DriverSummary> GetAllDriverSummaries(long groupId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DRIVERSCONTROLLER.GETALLDRIVERSUMMARIES, Method.GET);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			IRestResponse<List<DriverSummary>> response = Execute<List<DriverSummary>>(request);
			return response.Data;
		}

		public async Task<List<DriverSummary>> GetAllDriverSummariesAsync(long groupId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DRIVERSCONTROLLER.GETALLDRIVERSUMMARIES, Method.GET);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			IRestResponse<List<DriverSummary>> response = await ExecuteAsync<List<DriverSummary>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public Driver GetDriverById(long groupId, long driverId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DRIVERSCONTROLLER.GETDRIVERBYID, Method.GET);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			IRestResponse<Driver> response = Execute<Driver>(request);
			return response.Data;
		}

		public async Task<Driver> GetDriverByIdAsync(long groupId, long driverId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DRIVERSCONTROLLER.GETDRIVERBYID, Method.GET);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			IRestResponse<Driver> response = await ExecuteAsync<Driver>(request).ConfigureAwait(false);
			return response.Data;
		}

	}
}