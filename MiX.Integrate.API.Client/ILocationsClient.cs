using System.Collections.Generic;
using System.Threading.Tasks;
using MiX.Integrate.Shared.Entities.Locations;

namespace MiX.Integrate.Api.Client
{
	public interface ILocationsClient : IBaseClient
	{
		Task<Location> GetAsync(long locationId);
		Location Get(long locationId);

		Task<List<Location>> GetAllAsync(long groupId);
		List<Location> GetAll(long groupId);
	}
}
