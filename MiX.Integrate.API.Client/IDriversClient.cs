using MiX.Integrate.Api.Client.Base;
using MiX.Integrate.Shared.Entities.Drivers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiX.Integrate.Api.Client
{
	public interface IDriversClient : IBaseClient
	{

		//List<DriverSummary> GetAllDriverSummaries(long groupId);
		//Task<List<DriverSummary>> GetAllDriverSummariesAsync(long groupId);
		Driver GetDriver(long groupId, long driverId);
		Task<Driver> GetDriverAsync(long groupId, long driverId); 
		void UpdateDriver(Driver driver);
		Task UpdateDriverAsync(Driver driver);
		long AddDriver(Driver driver);
		Task<long> AddDriverAsync(Driver driver);
		List<Driver> GetAllDrivers(long organisationId);
		Task<List<Driver>> GetAllDriversAsync(long organisationId);
		List<Driver> GetAllDrivers(long organisationId, string filterType, string wildCard);
		Task<List<Driver>> GetAllDriversAsync(long organisationId, string filterType, string wildCard);

	}
}
