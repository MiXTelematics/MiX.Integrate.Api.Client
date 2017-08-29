using System.Collections.Generic;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Drivers;
using System.Threading.Tasks;
using MiX.Integrate.Api.Client.Base;
using MiX.Integrate.API.Client.Base;
using System.Net.Http;

namespace MiX.Integrate.Api.Client
{
	public class DriversClient : BaseClient, IDriversClient
	{
		public DriversClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public DriversClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public List<DriverSummary> GetAllDriverSummaries(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERSCONTROLLER.GETALLDRIVERSUMMARIES, HttpMethod.Get);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			IHttpRestResponse<List<DriverSummary>> response = Execute<List<DriverSummary>>(request);
			return response.Data;
		}

		public async Task<List<DriverSummary>> GetAllDriverSummariesAsync(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERSCONTROLLER.GETALLDRIVERSUMMARIES, HttpMethod.Get);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			IHttpRestResponse<List<DriverSummary>> response = await ExecuteAsync<List<DriverSummary>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public Driver GetDriverById(long groupId, long driverId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERSCONTROLLER.GETDRIVERBYID, HttpMethod.Get);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			IHttpRestResponse<Driver> response = Execute<Driver>(request);
			return response.Data;
		}

		public async Task<Driver> GetDriverByIdAsync(long groupId, long driverId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERSCONTROLLER.GETDRIVERBYID, HttpMethod.Get);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			IHttpRestResponse<Driver> response = await ExecuteAsync<Driver>(request).ConfigureAwait(false);
			return response.Data;
		}

	}
}