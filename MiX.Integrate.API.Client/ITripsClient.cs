using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Entities.Carriers;
using MiX.Integrate.Shared.Entities.Drivers;
using MiX.Integrate.Shared.Entities.Trips;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public interface ITripsClient : IBaseClient
	{
		IList<Trip> GetLatestForAssets(List<long> assetIds, byte quantity = 1, DateTime? cachedSince = null, bool includeSubTrips = false);
		Task<IList<Trip>> GetLatestForAssetsAsync(List<long> assetIds, byte quantity = 1, DateTime? cachedSince = null, bool includeSubTrips = false);
		IList<Trip> GetLatestForDrivers(List<long> driverIds, byte quantity = 1, DateTime? cachedSince = null, bool includeSubTrips = false);
		Task<IList<Trip>> GetLatestForDriversAsync(List<long> driverIds, byte quantity = 1, DateTime? cachedSince = null, bool includeSubTrips = false);
		IList<Trip> GetLatestForGroups(List<long> groupIds, string entityType, byte quantity = 1, DateTime? cachedSince = null, bool includeSubTrips = false);
		Task<IList<Trip>> GetLatestForGroupsAsync(List<long> groupIds, string entityType, byte quantity = 1, DateTime? cachedSince = null, bool includeSubTrips = false);

		IList<Trip> GetRangeForAssets(List<long> assetIds, DateTime from, DateTime to, bool includeSubTrips = false);
		Task<IList<Trip>> GetRangeForAssetsAsync(List<long> assetIds, DateTime from, DateTime to, bool includeSubTrips = false);
		IList<Trip> GetRangeForDrivers(List<long> driverIds, DateTime from, DateTime to, bool includeSubTrips = false);
		Task<IList<Trip>> GetRangeForDriversAsync(List<long> driverIds, DateTime from, DateTime to, bool includeSubTrips = false);
		IList<Trip> GetRangeForGroups(List<long> groupIds, string entityType, DateTime from, DateTime to, bool includeSubTrips = false);
		Task<IList<Trip>> GetRangeForGroupsAsync(List<long> groupIds, string entityType, DateTime from, DateTime to, bool includeSubTrips = false);

		IList<Trip> GetSinceForAssets(List<long> assetIds, DateTime since, bool includeSubTrips = false);
		Task<IList<Trip>> GetSinceForAssetsAsync(List<long> assetIds, DateTime since, bool includeSubTrips = false);
		IList<Trip> GetSinceForDrivers(List<long> driverIds, DateTime since, bool includeSubTrips = false);
		Task<IList<Trip>> GetSinceForDriversAsync(List<long> driverIds, DateTime since, bool includeSubTrips = false);
		IList<Trip> GetSinceForGroups(List<long> groupIds, string entityType, DateTime since, bool includeSubTrips = false);
		Task<IList<Trip>> GetSinceForGroupsAsync(List<long> groupIds, string entityType, DateTime since, bool includeSubTrips = false);

		CreatedSinceResult<Trip> GetCreatedSinceForAssets(List<long> assetIds, string sinceToken, int quantity, bool includeSubTrips = false);
		Task<CreatedSinceResult<Trip>> GetCreatedSinceForAssetsAsync(List<long> assetIds, string sinceToken, int quantity, bool includeSubTrips = false);
		CreatedSinceResult<Trip> GetCreatedSinceForDrivers(List<long> driverIds, string sinceToken, int quantity, bool includeSubTrips = false);
		Task<CreatedSinceResult<Trip>> GetCreatedSinceForDriversAsync(List<long> driverIds, string sinceToken, int quantity, bool includeSubTrips = false);
		CreatedSinceResult<Trip> GetCreatedSinceForGroups(List<long> groupIds, string entityType, string sinceToken, int quantity, bool includeSubTrips = false);
		Task<CreatedSinceResult<Trip>> GetCreatedSinceForGroupsAsync(List<long> groupIds, string entityType, string sinceToken, int quantity, bool includeSubTrips = false);

		List<DriverScore> GetDriverScores(List<long> driverIds, DateTime from, DateTime to);
		Task<List<DriverScore>> GetDriverScoresAsync(List<long> driverIds, DateTime from, DateTime to);

		CreatedSinceResult<Trip> GetCreatedSinceForOrganisation(long organisationId, string sinceToken, int quantity, bool includeSubTrips = false);
		Task<CreatedSinceResult<Trip>> GetCreatedSinceForOrganisationAsync(long organisationId, string sinceToken, int quantity, bool includeSubTrips = false);
		void UpdateTripClassification(long tripId, TripClassificationCategory classification);
		Task UpdateTripClassificationAsync(long tripId, TripClassificationCategory classification);
		void UpdateTripClassificationComment(long tripId, string comment);
		Task UpdateTripClassificationCommentAsync(long tripId, string comment);
	}
}
