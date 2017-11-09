using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Drivers;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiX.Integrate.Api.Client.Base;
using System.Net.Http;

namespace MiX.Integrate.Api.Client
{
	public class DriverCertificationClient : BaseClient, IDriverCertificationClient
	{
		public DriverCertificationClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public DriverCertificationClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }


		public DriverCertification GetDriverCertificationById(long organisationGroupId, long driverId, int certificationTypeId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.GETDRIVERCERTIFICATION, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddUrlSegment("driverId", driverId.ToString());
			request.AddUrlSegment("certificationTypeId", certificationTypeId.ToString());
			IHttpRestResponse<DriverCertification> response = Execute<DriverCertification>(request);
			return response.Data;
		}
		public async Task<DriverCertification> GetDriverCertificationByIdAsync(long organisationGroupId, long driverId, int certificationTypeId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.GETDRIVERCERTIFICATION, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddUrlSegment("driverId", driverId.ToString());
			request.AddUrlSegment("certificationTypeId", certificationTypeId.ToString());
			IHttpRestResponse<DriverCertification> response = await ExecuteAsync<DriverCertification>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<DriverCertification> GetDriverCertificationsForDriver(long organisationGroupId, long driverId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.GETDRIVERCERTIFICATIONS, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddUrlSegment("driverId", driverId.ToString());
			IHttpRestResponse<List<DriverCertification>> response = Execute<List<DriverCertification>>(request);
			return response.Data;
		}
		public async Task<IList<DriverCertification>> GetDriverCertificationsForDriverAsync(long organisationGroupId, long driverId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.GETDRIVERCERTIFICATIONS, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddUrlSegment("driverId", driverId.ToString());
			IHttpRestResponse<List<DriverCertification>> response = await ExecuteAsync<List<DriverCertification>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<CertificationType> GetDriverCertificationTypes(long organisationGroupId, long driverId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.GETDRIVERCERTIFICATIONTYPES, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddUrlSegment("driverId", driverId.ToString());
			IHttpRestResponse<List<CertificationType>> response = Execute<List<CertificationType>>(request);
			return response.Data;
		}

		public async Task<IList<CertificationType>> GetDriverCertificationTypesAsync(long organisationGroupId, long driverId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.GETDRIVERCERTIFICATIONTYPES, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddUrlSegment("driverId", driverId.ToString());
			IHttpRestResponse<List<CertificationType>> response = await ExecuteAsync<List<CertificationType>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public void AddDriverCertification(long organisationGroupId, DriverCertification driverCertification)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.ADDDRIVERCERTIFICATION, HttpMethod.Post);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddJsonBody(driverCertification);
			Execute(request);
		}

		public async Task AddDriverCertificationAsync(long organisationGroupId, DriverCertification driverCertification)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.ADDDRIVERCERTIFICATION, HttpMethod.Post);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddJsonBody(driverCertification);
			await ExecuteAsync(request).ConfigureAwait(false);
		}

		public void UpdateDriverCertification(long organisationGroupId, DriverCertification driverCertification)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.UPDATEDRIVERCERTIFICATION, HttpMethod.Put);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddJsonBody(driverCertification);
			Execute(request);
		}

		public async Task UpdateDriverCertificationAsync(long organisationGroupId, DriverCertification driverCertification)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.UPDATEDRIVERCERTIFICATION, HttpMethod.Put);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddJsonBody(driverCertification);
			await ExecuteAsync(request).ConfigureAwait(false);
		}

		public void DeleteDriverCertification(long organisationGroupId, long driverId, int certificationTypeId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.DELETEDRIVERCERTIFICATION, HttpMethod.Delete);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddUrlSegment("driverId", driverId.ToString());
			request.AddUrlSegment("certificationTypeId", certificationTypeId.ToString());
			Execute(request);
		}

		public async Task DeleteDriverCertificationAsync(long organisationGroupId, long driverId, int certificationTypeId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.DELETEDRIVERCERTIFICATION, HttpMethod.Delete);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddUrlSegment("driverId", driverId.ToString());
			request.AddUrlSegment("certificationTypeId", certificationTypeId.ToString());
			await ExecuteAsync(request).ConfigureAwait(false);
		}

	}
}
