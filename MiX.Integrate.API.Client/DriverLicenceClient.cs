using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Drivers;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiX.Integrate.Api.Client.Base;
using System.Net.Http;

namespace MiX.Integrate.Api.Client
{
	public class DriverLicenceClient : BaseClient, IDriverLicenceClient
	{
		public DriverLicenceClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public DriverLicenceClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public IList<DriverLicence> GetDriverLicencesByDriverId(long organisationGroupId, long driverId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERLICENCECONTROLLER.GETDRIVERLICENCES, HttpMethod.Get);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			IHttpRestResponse<List<DriverLicence>> response = Execute<List<DriverLicence>>(request);
			return response.Data;
		}

		public async Task<IList<DriverLicence>> GetDriverLicencesByDriverIdAsync(long organisationGroupId, long driverId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERLICENCECONTROLLER.GETDRIVERLICENCES, HttpMethod.Get);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			IHttpRestResponse<List<DriverLicence>> response = await ExecuteAsync<List<DriverLicence>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public DriverLicence GetDriverLicenceById(long organisationGroupId, long driverId, int licenceCategoryId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERLICENCECONTROLLER.GETDRIVERLICENCE, HttpMethod.Get);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			request.AddUrlSegment("licenceCategoryId", licenceCategoryId.ToString());
			IHttpRestResponse<DriverLicence> response = Execute<DriverLicence>(request);
			return response.Data;
		}

		public async Task<DriverLicence> GetDriverLicenceByIdAsync(long organisationGroupId, long driverId, int licenceCategoryId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERLICENCECONTROLLER.GETDRIVERLICENCE, HttpMethod.Get);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			request.AddUrlSegment("licenceCategoryId", licenceCategoryId.ToString());
			IHttpRestResponse<DriverLicence> response = await ExecuteAsync<DriverLicence>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<LicenceCategory> GetDriverLicenceCategories(long organisationGroupId, long driverId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERLICENCECONTROLLER.GETDRIVERLICENCECATEGORIES, HttpMethod.Get);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			IHttpRestResponse<List<LicenceCategory>> response = Execute<List<LicenceCategory>>(request);
			return response.Data;
		}

		public async Task<IList<LicenceCategory>> GetDriverLicenceCategoriesAsync(long organisationGroupId, long driverId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERLICENCECONTROLLER.GETDRIVERLICENCECATEGORIES, HttpMethod.Get);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			IHttpRestResponse<List<LicenceCategory>> response = await ExecuteAsync<List<LicenceCategory>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public void AddDriverLicence(long organisationGroupId, DriverLicence driverLicence)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERLICENCECONTROLLER.ADDDRIVERLICENCE, HttpMethod.Put);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddJsonBody(driverLicence);
			Execute(request);
		}

		public async Task AddDriverLicenceAsync(long organisationGroupId, DriverLicence driverLicence)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERLICENCECONTROLLER.ADDDRIVERLICENCE, HttpMethod.Put);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddJsonBody(driverLicence);
			await ExecuteAsync(request).ConfigureAwait(false);
		}


		public void UpdateDriverLicence(long organisationGroupId, DriverLicence driverLicence)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERLICENCECONTROLLER.UPDATEDRIVERLICENCE, HttpMethod.Put);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddJsonBody(driverLicence);
			Execute(request);
		}

		public async Task UpdateDriverLicenceAsync(long organisationGroupId, DriverLicence driverLicence)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERLICENCECONTROLLER.UPDATEDRIVERLICENCE, HttpMethod.Put);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddJsonBody(driverLicence);
			await ExecuteAsync(request).ConfigureAwait(false);
		}

		public void DeleteDriverLicence(long organisationGroupId, long driverId, int licenceCategoryId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERLICENCECONTROLLER.DELETEDRIVERLICENCE, HttpMethod.Put);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			request.AddUrlSegment("licenceCategoryId", licenceCategoryId.ToString());
			Execute(request);
		}

		public async Task DeleteDriverLicenceAsync(long organisationGroupId, long driverId, int licenceCategoryId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERLICENCECONTROLLER.DELETEDRIVERLICENCE, HttpMethod.Put);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			request.AddUrlSegment("licenceCategoryId", licenceCategoryId.ToString());
			await ExecuteAsync(request).ConfigureAwait(false);
		}

	}
}
