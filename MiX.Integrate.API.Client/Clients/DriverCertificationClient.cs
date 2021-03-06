﻿using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Drivers;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public class DriverCertificationClient : BaseClient, IDriverCertificationClient
	{
		public DriverCertificationClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public DriverCertificationClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }


		/// <summary>Retrieves driver certifications for all drivers in the specified group and its descendants.</summary>
		/// <param name="groupId">Identifies the <see cref="MiX.Integrate.Shared.Entities.Groups.Group">Group</see> to search,
		/// which must be an OrganisationGroup, OrganisationSubgroup, SubGroup, or DefaultSite.</param>
		public Dictionary<long, List<DriverCertification>> GetDriverCertificationsForGroup(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DriverCertificationController.GETDRIVERCERTIFICATIONSFORGROUP, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			IHttpRestResponse<Dictionary<long,List<DriverCertification>>> response = Execute<Dictionary<long,List<DriverCertification>>>(request);
			return response.Data;
		}

		/// <summary>Retrieves driver certifications for all drivers in the specified group and its descendants.</summary>
		/// <param name="groupId">Identifies the <see cref="MiX.Integrate.Shared.Entities.Groups.Group">Group</see> to search,
		/// which must be an OrganisationGroup, OrganisationSubgroup, SubGroup, or DefaultSite.</param>
		public async Task<Dictionary<long, List<DriverCertification>>> GetDriverCertificationsForGroupAsync(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DriverCertificationController.GETDRIVERCERTIFICATIONSFORGROUP, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			IHttpRestResponse<Dictionary<long,List<DriverCertification>>> response = await ExecuteAsync<Dictionary<long,List<DriverCertification>>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public DriverCertification GetDriverCertificationById(long organisationGroupId, long driverId, int certificationTypeId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DriverCertificationController.GETDRIVERCERTIFICATION, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddUrlSegment("driverId", driverId.ToString());
			request.AddUrlSegment("certificationTypeId", certificationTypeId.ToString());
			IHttpRestResponse<DriverCertification> response = Execute<DriverCertification>(request);
			return response.Data;
		}
		public async Task<DriverCertification> GetDriverCertificationByIdAsync(long organisationGroupId, long driverId, int certificationTypeId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DriverCertificationController.GETDRIVERCERTIFICATION, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddUrlSegment("driverId", driverId.ToString());
			request.AddUrlSegment("certificationTypeId", certificationTypeId.ToString());
			IHttpRestResponse<DriverCertification> response = await ExecuteAsync<DriverCertification>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<DriverCertification> GetDriverCertificationsForDriver(long organisationGroupId, long driverId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DriverCertificationController.GETDRIVERCERTIFICATIONS, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddUrlSegment("driverId", driverId.ToString());
			IHttpRestResponse<List<DriverCertification>> response = Execute<List<DriverCertification>>(request);
			return response.Data;
		}
		public async Task<IList<DriverCertification>> GetDriverCertificationsForDriverAsync(long organisationGroupId, long driverId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DriverCertificationController.GETDRIVERCERTIFICATIONS, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddUrlSegment("driverId", driverId.ToString());
			IHttpRestResponse<List<DriverCertification>> response = await ExecuteAsync<List<DriverCertification>>(request).ConfigureAwait(false);
			return response.Data;
		}

		/// <summary>Retrieves driver certification types for the specified organisation</summary>
		/// <param name="organisationGroupId">Identifies the organisation to query</param>
		public List<CertificationType> GetDriverCertificationTypes(long organisationGroupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DriverCertificationController.GETDRIVERCERTIFICATIONTYPESFORORGANISATION, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			IHttpRestResponse<List<CertificationType>> response = Execute<List<CertificationType>>(request);
			return response.Data;
		}

		/// <summary>Retrieves driver certification types for the specified organisation</summary>
		/// <param name="organisationGroupId">Identifies the organisation to query</param>
		public async Task<List<CertificationType>> GetDriverCertificationTypesAsync(long organisationGroupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DriverCertificationController.GETDRIVERCERTIFICATIONTYPESFORORGANISATION, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			IHttpRestResponse<List<CertificationType>> response = await ExecuteAsync<List<CertificationType>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<CertificationType> GetDriverCertificationTypes(long organisationGroupId, long driverId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DriverCertificationController.GETDRIVERCERTIFICATIONTYPES, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddUrlSegment("driverId", driverId.ToString());
			IHttpRestResponse<List<CertificationType>> response = Execute<List<CertificationType>>(request);
			return response.Data;
		}

		public async Task<IList<CertificationType>> GetDriverCertificationTypesAsync(long organisationGroupId, long driverId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DriverCertificationController.GETDRIVERCERTIFICATIONTYPES, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddUrlSegment("driverId", driverId.ToString());
			IHttpRestResponse<List<CertificationType>> response = await ExecuteAsync<List<CertificationType>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public void AddDriverCertification(long organisationGroupId, DriverCertification driverCertification)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DriverCertificationController.ADDDRIVERCERTIFICATION, HttpMethod.Post);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddJsonBody(driverCertification);
			Execute(request);
		}

		public async Task AddDriverCertificationAsync(long organisationGroupId, DriverCertification driverCertification)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DriverCertificationController.ADDDRIVERCERTIFICATION, HttpMethod.Post);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddJsonBody(driverCertification);
			await ExecuteAsync(request).ConfigureAwait(false);
		}

		public void UpdateDriverCertification(long organisationGroupId, DriverCertification driverCertification)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DriverCertificationController.UPDATEDRIVERCERTIFICATION, HttpMethod.Put);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddJsonBody(driverCertification);
			Execute(request);
		}

		public async Task UpdateDriverCertificationAsync(long organisationGroupId, DriverCertification driverCertification)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DriverCertificationController.UPDATEDRIVERCERTIFICATION, HttpMethod.Put);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddJsonBody(driverCertification);
			await ExecuteAsync(request).ConfigureAwait(false);
		}

		public void DeleteDriverCertification(long organisationGroupId, long driverId, int certificationTypeId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DriverCertificationController.DELETEDRIVERCERTIFICATION, HttpMethod.Delete);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddUrlSegment("driverId", driverId.ToString());
			request.AddUrlSegment("certificationTypeId", certificationTypeId.ToString());
			Execute(request);
		}

		public async Task DeleteDriverCertificationAsync(long organisationGroupId, long driverId, int certificationTypeId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DriverCertificationController.DELETEDRIVERCERTIFICATION, HttpMethod.Delete);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddUrlSegment("driverId", driverId.ToString());
			request.AddUrlSegment("certificationTypeId", certificationTypeId.ToString());
			await ExecuteAsync(request).ConfigureAwait(false);
		}

	}
}
