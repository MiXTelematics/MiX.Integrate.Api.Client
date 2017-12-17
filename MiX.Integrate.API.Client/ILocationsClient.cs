using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiX.Integrate.Shared.Entities.Locations;
using MiX.Integrate.Api.Client.Base;
using MiX.Integrate.Shared.Entities.Events;

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
	}
}

