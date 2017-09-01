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
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.GETDRIVERCERTIFICATIONASYNC, HttpMethod.Get);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			request.AddUrlSegment("certificationTypeId", certificationTypeId.ToString());
			IHttpRestResponse<DriverCertification> response = Execute<DriverCertification>(request);
			return response.Data;
		}
		public async Task<DriverCertification> GetDriverCertificationByIdAsync(long organisationGroupId, long driverId, int certificationTypeId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.GETDRIVERCERTIFICATIONASYNC, HttpMethod.Get);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			request.AddUrlSegment("certificationTypeId", certificationTypeId.ToString());
			IHttpRestResponse<DriverCertification> response = await ExecuteAsync<DriverCertification>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<DriverCertification> GetDriverCertificationsForDriver(long organisationGroupId, long driverId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.GETDRIVERCERTIFICATIONSASYNC, HttpMethod.Get);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			IHttpRestResponse<List<DriverCertification>> response = Execute<List<DriverCertification>>(request);
			return response.Data;
		}
		public async Task<IList<DriverCertification>> GetDriverCertificationsForDriverAsync(long organisationGroupId, long driverId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.GETDRIVERCERTIFICATIONSASYNC, HttpMethod.Get);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			IHttpRestResponse<List<DriverCertification>> response = await ExecuteAsync<List<DriverCertification>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<CertificationType> GetDriverCertificationTypes(long organisationGroupId, long driverId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.GETDRIVERCERTIFICATIONTYPESASYNC, HttpMethod.Get);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			IHttpRestResponse<List<CertificationType>> response = Execute<List<CertificationType>>(request);
			return response.Data;
		}

		public async Task<IList<CertificationType>> GetDriverCertificationTypesAsync(long organisationGroupId, long driverId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.GETDRIVERCERTIFICATIONTYPESASYNC, HttpMethod.Get);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			IHttpRestResponse<List<CertificationType>> response = await ExecuteAsync<List<CertificationType>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public void AddDriverCertification(long organisationGroupId, DriverCertification driverCertification)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.ADDDRIVERCERTIFICATIONASYNC, HttpMethod.Put);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddJsonBody(driverCertification);
			Execute(request);
		}

		public async Task AddDriverCertificationAsync(long organisationGroupId, DriverCertification driverCertification)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.ADDDRIVERCERTIFICATIONASYNC, HttpMethod.Put);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddJsonBody(driverCertification);
			await ExecuteAsync(request).ConfigureAwait(false);
		}

		public void UpdateDriverCertification(long organisationGroupId, DriverCertification driverCertification)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.UPDATEDRIVERCERTIFICATIONASYNC, HttpMethod.Put);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddJsonBody(driverCertification);
			Execute(request);
		}

		public async Task UpdateDriverCertificationAsync(long organisationGroupId, DriverCertification driverCertification)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.UPDATEDRIVERCERTIFICATIONASYNC, HttpMethod.Put);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddJsonBody(driverCertification);
			await ExecuteAsync(request).ConfigureAwait(false);
		}

		public void DeleteDriverCertification(long organisationGroupId, long driverId, int certificationTypeId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.DELETEDRIVERCERTIFICATIONASYNC, HttpMethod.Put);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			request.AddUrlSegment("certificationTypeId", certificationTypeId.ToString());
			Execute(request);
		}

		public async Task DeleteDriverCertificationAsync(long organisationGroupId, long driverId, int certificationTypeId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.DELETEDRIVERCERTIFICATIONASYNC, HttpMethod.Put);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			request.AddUrlSegment("certificationTypeId", certificationTypeId.ToString());
			await ExecuteAsync(request).ConfigureAwait(false);
		}

	}
}
