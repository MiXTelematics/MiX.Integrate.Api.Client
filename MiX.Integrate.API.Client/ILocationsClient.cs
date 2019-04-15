using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Entities.Events;
using MiX.Integrate.Shared.Entities.Locations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
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

		List<Location> InRange(long groupId, Coordinate coordinate, long meters);
		Task<List<Location>> InRangeAsync(long groupId, Coordinate coordinate, long meters);

		ProximityQueryResult Nearest(long groupId, Coordinate coordinate);
		Task<ProximityQueryResult> NearestAsync(long groupId, Coordinate coordinate);

		/// <summary>Returns, for a given organisation, a list of the locations that have been added, modified, or logically deleted since the specified date and time</summary>
		/// <param name="organisationId">The identifier of the organisation to query</param>
		/// <param name="since">The date and time used for the query</param>
		/// <returns>Locations that have changed since the specified date and time</returns>
		List<Location> GetChangedSince(long organisationId, DateTime since);

		/// <summary>Returns, for a given organisation, a list of the locations that have been added, modified, or logically deleted since the specified date and time</summary>
		/// <param name="organisationId">The identifier of the organisation to query</param>
		/// <param name="since">The date and time used for the query</param>
		/// <returns>Locations that have changed since the specified date and time</returns>
		Task<List<Location>> GetChangedSinceAsync(long organisationId, DateTime since);

	 /// <summary>Returns, for a given organisation, a list of the location ids and the migrated legacy location ids</summary>
		/// <param name="organisationId">The identifier of the organisation to query</param>
		/// <returns>Locations ids and the location legacy ids</returns>
		Task<List<LocationLegacy>> MigrateLegacyIdsAsync(long organisationId);
	}
}

