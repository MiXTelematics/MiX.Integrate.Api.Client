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
		//void UpdateTripClassification(long tripId, TripClassificationForUpdate classification);
		//Task UpdateTripClassificationAsync(long tripId, TripClassificationForUpdate classification);
		//void UpdateTripClassificationComment(long tripId, string comment);
		//Task UpdateTripClassificationCommentAsync(long tripId, string comment);

		/// <summary>Gets the RIBAS metrics of trips by the specified drivers in the specified date range</summary>
		/// <param name="driverIds">Ids of the drivers for whom trip metrics are required</param>
		/// <param name="from">Start of date range for query</param>
		/// <param name="to">End of date range for query</param>
		/// <returns>RIBAS metrics for trips by the specified drivers in the specified date range</returns>
		List<TripRibasMetrics> GetRibasMetricsForDrivers(List<long> driverIds, DateTime from, DateTime to);

		/// <summary>Gets the RIBAS metrics of trips by the specified drivers in the specified date range as an asynchronous operation</summary>
		/// <param name="driverIds">Ids of the drivers for whom trip metrics are required</param>
		/// <param name="from">Start of date range for query</param>
		/// <param name="to">End of date range for query</param>
		/// <returns>The task object representing the asynchronous operation</returns>
		Task<List<TripRibasMetrics>> GetRibasMetricsForDriversAsync(List<long> driverIds, DateTime from, DateTime to);

		/// <summary>Gets occurrences of DEMT amendments made to trips for an organisation</summary>
		/// <param name="organisationId">Identifier of the organisation</param>
		/// <param name="from">Start of query date range as YYYYMMDD</param>
		/// <param name="to">End of query date range as YYYYMMDD</param>
		/// <returns>DEMT amendments made to trips during the date range specified</returns>
		List<TripAmendment> GetTripAmendmentsForOrganisation(long organisationId, string from, string to);

		/// <summary>Gets occurrences of DEMT amendments made to trips for an organisation as an asynchronous operation</summary>
		/// <param name="organisationId">Identifier of the organisation</param>
		/// <param name="from">Start of query date range as YYYYMMDD</param>
		/// <param name="to">End of query date range as YYYYMMDD</param>
		/// <returns>A <see cref="Task"/> representing the asynchronous operation</returns>
		Task<List<TripAmendment>> GetTripAmendmentsForOrganisationAsync(long organisationId, string from, string to);

	}
}
