using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Entities.Drivers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public interface IDriverLicenceClient : IBaseClient
	{
		Dictionary<long,List<DriverLicence>> GetDriverLicencesForGroup(long groupId);
		Task<Dictionary<long,List<DriverLicence>>> GetDriverLicencesForGroupAsync(long groupId);

		IList<DriverLicence> GetDriverLicencesByDriverId(long organisationGroupId, long driverId);
		Task<IList<DriverLicence>> GetDriverLicencesByDriverIdAsync(long organisationGroupId, long driverId);

		DriverLicence GetDriverLicenceById(long organisationGroupId, long driverId, int licenceCategoryId);
		Task<DriverLicence> GetDriverLicenceByIdAsync(long organisationGroupId, long driverId, int licenceCategoryId);

		List<LicenceCategory> GetDriverLicenceCategories(long organisationGroupId);
		Task<List<LicenceCategory>> GetDriverLicenceCategoriesAsync(long organisationGroupId);

		IList<LicenceCategory> GetDriverLicenceCategories(long organisationGroupId, long driverId);
		Task<IList<LicenceCategory>> GetDriverLicenceCategoriesAsync(long organisationGroupId, long driverId);

		void AddDriverLicence (long organisationGroupId, DriverLicence driverLicence);
		Task AddDriverLicenceAsync(long organisationGroupId, DriverLicence driverLicence);

		void UpdateDriverLicence (long organisationGroupId, DriverLicence driverLicence);
		Task UpdateDriverLicenceAsync(long organisationGroupId, DriverLicence driverLicence);

		void DeleteDriverLicence (long organisationGroupId, long driverId, int licenceCategoryId);
		Task DeleteDriverLicenceAsync(long organisationGroupId, long driverId, int licenceCategoryId);
	}
}
