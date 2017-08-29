using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Drivers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiX.Integrate.Api.Client.Base;

namespace MiX.Integrate.Api.Client
{
	public class DriverCertificationClient : BaseClient, IDriverCertificationClient
	{
		public DriverCertificationClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public DriverCertificationClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }


		public DriverCertification GetDriverCertificationById(long organisationGroupId, long driverId, int certificationTypeId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.GETDRIVERCERTIFICATIONASYNC, Method.GET);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			request.AddUrlSegment("certificationTypeId", certificationTypeId.ToString());
			IRestResponse<DriverCertification> response = Execute<DriverCertification>(request);
			return response.Data;
		}
		public async Task<DriverCertification> GetDriverCertificationByIdAsync(long organisationGroupId, long driverId, int certificationTypeId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.GETDRIVERCERTIFICATIONASYNC, Method.GET);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			request.AddUrlSegment("certificationTypeId", certificationTypeId.ToString());
			IRestResponse<DriverCertification> response = await ExecuteAsync<DriverCertification>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<DriverCertification> GetDriverCertificationsForDriver(long organisationGroupId, long driverId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.GETDRIVERCERTIFICATIONSASYNC, Method.GET);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			IRestResponse<List<DriverCertification>> response = Execute<List<DriverCertification>>(request);
			return response.Data;
		}
		public async Task<IList<DriverCertification>> GetDriverCertificationsForDriverAsync(long organisationGroupId, long driverId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.GETDRIVERCERTIFICATIONSASYNC, Method.GET);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			IRestResponse<List<DriverCertification>> response = await ExecuteAsync<List<DriverCertification>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<CertificationType> GetDriverCertificationTypes(long organisationGroupId, long driverId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.GETDRIVERCERTIFICATIONTYPESASYNC, Method.GET);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			IRestResponse<List<CertificationType>> response = Execute<List<CertificationType>>(request);
			return response.Data;
		}

		public async Task<IList<CertificationType>> GetDriverCertificationTypesAsync(long organisationGroupId, long driverId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.GETDRIVERCERTIFICATIONTYPESASYNC, Method.GET);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			IRestResponse<List<CertificationType>> response = await ExecuteAsync<List<CertificationType>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public void AddDriverCertification(long organisationGroupId, DriverCertification driverCertification)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.ADDDRIVERCERTIFICATIONASYNC, Method.PUT);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddJsonBody(driverCertification);
			Execute(request);
		}

		public async Task AddDriverCertificationAsync(long organisationGroupId, DriverCertification driverCertification)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.ADDDRIVERCERTIFICATIONASYNC, Method.PUT);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddJsonBody(driverCertification);
			await ExecuteAsync(request).ConfigureAwait(false);
		}

		public void UpdateDriverCertification(long organisationGroupId, DriverCertification driverCertification)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.UPDATEDRIVERCERTIFICATIONASYNC, Method.PUT);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddJsonBody(driverCertification);
			Execute(request);
		}

		public async Task UpdateDriverCertificationAsync(long organisationGroupId, DriverCertification driverCertification)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.UPDATEDRIVERCERTIFICATIONASYNC, Method.PUT);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddJsonBody(driverCertification);
			await ExecuteAsync(request).ConfigureAwait(false);
		}

		public void DeleteDriverCertification(long organisationGroupId, long driverId, int certificationTypeId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.DELETEDRIVERCERTIFICATIONASYNC, Method.PUT);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			request.AddUrlSegment("certificationTypeId", certificationTypeId.ToString());
			Execute(request);
		}

		public async Task DeleteDriverCertificationAsync(long organisationGroupId, long driverId, int certificationTypeId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DRIVERCERTIFICATIONCONTROLLER.DELETEDRIVERCERTIFICATIONASYNC, Method.PUT);
			request.AddUrlSegment("organisationGroupId:long", organisationGroupId.ToString());
			request.AddUrlSegment("driverId:long", driverId.ToString());
			request.AddUrlSegment("certificationTypeId", certificationTypeId.ToString());
			await ExecuteAsync(request).ConfigureAwait(false);
		}

	}
}
