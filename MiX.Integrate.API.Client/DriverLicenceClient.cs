using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Drivers;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public class DriverLicenceClient : BaseClient, IDriverLicenceClient
	{
		public DriverLicenceClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public DriverLicenceClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		/// <summary>Retrieves driver licences for all drivers in the specified group and its descendants.</summary>
		/// <param name="groupId">Identifies the <see cref="MiX.Integrate.Shared.Entities.Groups.Group">Group</see> to search,
		/// which must be an OrganisationGroup, OrganisationSubgroup, SubGroup, or DefaultSite.</param>
		public Dictionary<long, List<DriverLicence>> GetDriverLicencesForGroup(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DriverLicenceController.GETDRIVERLICENCESFORGROUP, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			IHttpRestResponse<Dictionary<long,List<DriverLicence>>> response = Execute<Dictionary<long,List<DriverLicence>>>(request);
			return response.Data;
		}

		/// <summary>Retrieves driver licences for all drivers in the specified group and its descendants.</summary>
		/// <param name="groupId">Identifies the <see cref="MiX.Integrate.Shared.Entities.Groups.Group">Group</see> to search,
		/// which must be an OrganisationGroup, OrganisationSubgroup, SubGroup, or DefaultSite.</param>
		public async Task<Dictionary<long, List<DriverLicence>>> GetDriverLicencesForGroupAsync(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DriverLicenceController.GETDRIVERLICENCESFORGROUP, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			IHttpRestResponse<Dictionary<long,List<DriverLicence>>> response = await ExecuteAsync<Dictionary<long,List<DriverLicence>>>(request).ConfigureAwait(false);
			return response.Data;
		}

 		public IList<DriverLicence> GetDriverLicencesByDriverId(long organisationGroupId, long driverId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DriverLicenceController.GETDRIVERLICENCES, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddUrlSegment("driverId", driverId.ToString());
			IHttpRestResponse<List<DriverLicence>> response = Execute<List<DriverLicence>>(request);
			return response.Data;
		}

		public async Task<IList<DriverLicence>> GetDriverLicencesByDriverIdAsync(long organisationGroupId, long driverId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DriverLicenceController.GETDRIVERLICENCES, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddUrlSegment("driverId", driverId.ToString());
			IHttpRestResponse<List<DriverLicence>> response = await ExecuteAsync<List<DriverLicence>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public DriverLicence GetDriverLicenceById(long organisationGroupId, long driverId, int licenceCategoryId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DriverLicenceController.GETDRIVERLICENCE, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddUrlSegment("driverId", driverId.ToString());
			request.AddUrlSegment("licenceCategoryId", licenceCategoryId.ToString());
			IHttpRestResponse<DriverLicence> response = Execute<DriverLicence>(request);
			return response.Data;
		}

		public async Task<DriverLicence> GetDriverLicenceByIdAsync(long organisationGroupId, long driverId, int licenceCategoryId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DriverLicenceController.GETDRIVERLICENCE, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddUrlSegment("driverId", driverId.ToString());
			request.AddUrlSegment("licenceCategoryId", licenceCategoryId.ToString());
			IHttpRestResponse<DriverLicence> response = await ExecuteAsync<DriverLicence>(request).ConfigureAwait(false);
			return response.Data;
		}

		/// <summary>Retrieves a list of driver licence categories for the specified organisation</summary>
		/// <param name="organisationGroupId">Identifies the organisation to query</param>
		public List<LicenceCategory> GetDriverLicenceCategories(long organisationGroupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DriverLicenceController.GETDRIVERLICENCECATEGORIESFORORGANISATION, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			IHttpRestResponse<List<LicenceCategory>> response = Execute<List<LicenceCategory>>(request);
			return response.Data;
		}

		/// <summary>Retrieves a list of driver licence categories for the specified organisation</summary>
		/// <param name="organisationGroupId">Identifies the organisation to query</param>
		public async Task<List<LicenceCategory>> GetDriverLicenceCategoriesAsync(long organisationGroupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DriverLicenceController.GETDRIVERLICENCECATEGORIESFORORGANISATION, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			IHttpRestResponse<List<LicenceCategory>> response = await ExecuteAsync<List<LicenceCategory>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<LicenceCategory> GetDriverLicenceCategories(long organisationGroupId, long driverId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DriverLicenceController.GETDRIVERLICENCECATEGORIES, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddUrlSegment("driverId", driverId.ToString());
			IHttpRestResponse<List<LicenceCategory>> response = Execute<List<LicenceCategory>>(request);
			return response.Data;
		}

		public async Task<IList<LicenceCategory>> GetDriverLicenceCategoriesAsync(long organisationGroupId, long driverId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DriverLicenceController.GETDRIVERLICENCECATEGORIES, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddUrlSegment("driverId", driverId.ToString());
			IHttpRestResponse<List<LicenceCategory>> response = await ExecuteAsync<List<LicenceCategory>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public void AddDriverLicence(long organisationGroupId, DriverLicence driverLicence)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DriverLicenceController.ADDDRIVERLICENCE, HttpMethod.Post);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddJsonBody(driverLicence);
			Execute(request);
		}

		public async Task AddDriverLicenceAsync(long organisationGroupId, DriverLicence driverLicence)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DriverLicenceController.ADDDRIVERLICENCE, HttpMethod.Post);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddJsonBody(driverLicence);
			await ExecuteAsync(request).ConfigureAwait(false);
		}


		public void UpdateDriverLicence(long organisationGroupId, DriverLicence driverLicence)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DriverLicenceController.UPDATEDRIVERLICENCE, HttpMethod.Put);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddJsonBody(driverLicence);
			Execute(request);
		}

		public async Task UpdateDriverLicenceAsync(long organisationGroupId, DriverLicence driverLicence)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DriverLicenceController.UPDATEDRIVERLICENCE, HttpMethod.Put);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddJsonBody(driverLicence);
			await ExecuteAsync(request).ConfigureAwait(false);
		}

		public void DeleteDriverLicence(long organisationGroupId, long driverId, int licenceCategoryId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DriverLicenceController.DELETEDRIVERLICENCE, HttpMethod.Delete);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddUrlSegment("driverId", driverId.ToString());
			request.AddUrlSegment("licenceCategoryId", licenceCategoryId.ToString());
			Execute(request);
		}

		public async Task DeleteDriverLicenceAsync(long organisationGroupId, long driverId, int licenceCategoryId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DriverLicenceController.DELETEDRIVERLICENCE, HttpMethod.Delete);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddUrlSegment("driverId", driverId.ToString());
			request.AddUrlSegment("licenceCategoryId", licenceCategoryId.ToString());
			await ExecuteAsync(request).ConfigureAwait(false);
		}

	}
}
