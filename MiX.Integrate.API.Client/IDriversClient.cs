using System.Collections.Generic;

using MiX.Integrate.Shared.Entities.Drivers;
using System.Threading.Tasks;

namespace MiX.Integrate.Api.Client
{
	public interface IDriversClient : IBaseClient
	{

		List<DriverSummary> GetAllDriverSummaries (long groupId);
		Task<List<DriverSummary>> GetAllDriverSummariesAsync (long groupId);
		Driver GetDriverById (long groupId, long driverId);
		Task<Driver> GetDriverByIdAsync (long groupId, long driverId);

	}
}
