using System.Collections.Generic;
using System.Threading.Tasks;
using MiX.Integrate.Shared.Entities.Locations;
using MiX.Integrate.Api.Client.Base;

namespace MiX.Integrate.Api.Client
{
	public interface ILocationsClient : IBaseClient
	{
		Task<Location> GetAsync(long locationId);
		Location Get(long locationId);

		Task<List<Location>> GetAllAsync(long groupId);
		List<Location> GetAll(long groupId);
		Task UpdateAsync(Location location, long groupId);
		void Update(Location location, long groupId);
		Task<long> AddAsync(Location location, long groupId);
		long Add(Location location, long groupId);
		Task DeleteAsync(long groupId, long locationId);
		void Delete(long groupId, long locationId);
	}
}

