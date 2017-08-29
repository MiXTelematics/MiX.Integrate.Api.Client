using MiX.Integrate.Shared.Entities.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiX.Integrate.Api.Client.Base;

namespace MiX.Integrate.Api.Client
{
	public interface IDriverCertificationClient
	{
		DriverCertification GetDriverCertificationById(long organisationGroupId, long driverId, int certificationTypeId);
		Task<DriverCertification> GetDriverCertificationByIdAsync(long organisationGroupId, long driverId, int certificationTypeId);

		IList<DriverCertification> GetDriverCertificationsForDriver(long organisationGroupId, long driverId);
		Task<IList<DriverCertification>> GetDriverCertificationsForDriverAsync(long organisationGroupId, long driverId);

		IList<CertificationType> GetDriverCertificationTypes(long organisationGroupId, long driverId);
		Task<IList<CertificationType>> GetDriverCertificationTypesAsync(long organisationGroupId, long driverId);

		void AddDriverCertification(long organisationGroupId, DriverCertification driverCertification);
		Task AddDriverCertificationAsync(long organisationGroupId, DriverCertification driverCertification);

		void UpdateDriverCertification(long organisationGroupId, DriverCertification driverCertification);
		Task UpdateDriverCertificationAsync(long organisationGroupId, DriverCertification driverCertification);

		void DeleteDriverCertification(long organisationGroupId, long driverId, int certificationTypeId);
		Task DeleteDriverCertificationAsync(long organisationGroupId, long driverId, int certificationTypeId);
	}
}
