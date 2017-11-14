using System.Collections.Generic;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Drivers;
using System.Threading.Tasks;
using MiX.Integrate.Api.Client.Base;
using System.Net.Http;
using System;

namespace MiX.Integrate.Api.Client
{
	public class DriversClient : BaseClient, IDriversClient
	{
		public DriversClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public DriversClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		//public List<DriverSummary> GetAllDriverSummaries(long groupId)
		//{
		//	IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERSCONTROLLER.GETALLDRIVERSUMMARIES, HttpMethod.Get);
		//	request.AddUrlSegment("groupId", groupId.ToString());
		//	IHttpRestResponse<List<DriverSummary>> response = Execute<List<DriverSummary>>(request);
		//	return response.Data;
		//}

		//public async Task<List<DriverSummary>> GetAllDriverSummariesAsync(long groupId)
		//{
		//	IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERSCONTROLLER.GETALLDRIVERSUMMARIES, HttpMethod.Get);
		//	request.AddUrlSegment("groupId", groupId.ToString());
		//	IHttpRestResponse<List<DriverSummary>> response = await ExecuteAsync<List<DriverSummary>>(request).ConfigureAwait(false);
		//	return response.Data;
		//}

		public Driver GetDriver(long groupId, long driverId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERSCONTROLLER.GETDRIVER, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddUrlSegment("driverId", driverId.ToString());
			IHttpRestResponse<Driver> response = Execute<Driver>(request);
			return response.Data;
		}

		public async Task<Driver> GetDriverAsync(long groupId, long driverId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERSCONTROLLER.GETDRIVER, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddUrlSegment("driverId", driverId.ToString());
			IHttpRestResponse<Driver> response = await ExecuteAsync<Driver>(request).ConfigureAwait(false);
			return response.Data;
		}

		public void UpdateDriver(Driver driver)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERSCONTROLLER.UPDATEDRIVER, HttpMethod.Put);
			request.AddJsonBody(driver);
			Execute(request);
		}

		public async Task UpdateDriverAsync(Driver driver)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERSCONTROLLER.UPDATEDRIVER, HttpMethod.Put);
			request.AddJsonBody(driver);
			await ExecuteAsync(request).ConfigureAwait(false);
		}

		public long AddDriver(Driver driver)
		{
			if (driver.FmDriverId == -1 || driver.FmDriverId == 0 || driver.FmDriverId == 1) throw new ArgumentException("FmDriverId -1, 0 and 1 was reserved");
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERSCONTROLLER.ADDDRIVER, HttpMethod.Post);
			request.AddJsonBody(driver);
			IHttpRestResponse response = Execute(request);
			var idHeaderVal = GetResponseHeader(response.Headers, "driverid");
			long driverId;
			if (!long.TryParse(idHeaderVal, out driverId) || driverId == 0)
				throw new Exception("Could not determine the id of the newly-created driver");
			return driverId;
		}

		public async Task<long> AddDriverAsync(Driver driver)
		{
			if (driver.FmDriverId == -1 || driver.FmDriverId == 0 || driver.FmDriverId == 1) throw new ArgumentException("FmDriverId -1, 0 and 1 was reserved");
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERSCONTROLLER.ADDDRIVER, HttpMethod.Post);
			request.AddJsonBody(driver);
			IHttpRestResponse response = await ExecuteAsync(request).ConfigureAwait(false);
			var idHeaderVal = GetResponseHeader(response.Headers, "driverid");
			long driverId;
			if (!long.TryParse(idHeaderVal, out driverId) || driverId == 0)
				throw new Exception("Could not determine the id of the newly-created driver");
			return driverId;
		}

		public List<Driver> GetAllDrivers(long organisationId, string filterType, string wildCard)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERSCONTROLLER.GETALLDRIVERS, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddQueryParameter("filterType", filterType);
			request.AddQueryParameter("wildCard", wildCard);
			IHttpRestResponse<List<Driver>> response = Execute<List<Driver>>(request);
			return response.Data;
		}

		public async Task<List<Driver>> GetAllDriversAsync(long organisationId, string filterType, string wildCard)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERSCONTROLLER.GETALLDRIVERS, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddQueryParameter("filterType", filterType);
			request.AddQueryParameter("wildCard", wildCard);
			IHttpRestResponse<List<Driver>> response = await ExecuteAsync<List<Driver>>(request).ConfigureAwait(false);
			return response.Data;
		}

	}
}