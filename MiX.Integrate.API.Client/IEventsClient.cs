using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Entities.Carriers;
using MiX.Integrate.Shared.Entities.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public interface IEventsClient : IBaseClient
	{
		IList<Event> GetLatestForAssets(List<long> assetIds, byte quantity = 1, DateTime? cachedSince = null, List<long> eventTypeIds = null, string menuId = null);
		Task<IList<Event>> GetLatestForAssetsAsync(List<long> assetIds, byte quantity = 1, DateTime? cachedSince = null, List<long> eventTypeIds = null, string menuId = null);
		IList<Event> GetLatestForDrivers(List<long> driverIds, byte quantity = 1, DateTime? cachedSince = null, List<long> eventTypeIds = null, string menuId = null);
		Task<IList<Event>> GetLatestForDriversAsync(List<long> driverIds, byte quantity = 1, DateTime? cachedSince = null, List<long> eventTypeIds = null, string menuId = null);
		IList<Event> GetLatestForGroups(List<long> groupIds, string entityType, byte quantity = 1, DateTime? cachedSince = null, List<long> eventTypeIds = null, string menuId = null);
		Task<IList<Event>> GetLatestForGroupsAsync(List<long> groupIds, string entityType, byte quantity = 1, DateTime? cachedSince = null, List<long> eventTypeIds = null, string menuId = null);
		IList<Event> GetRangeForAssets(List<long> assetIds, DateTime from, DateTime to, List<long> eventTypeIds = null, string menuId = null);
		Task<IList<Event>> GetRangeForAssetsAsync(List<long> assetIds, DateTime from, DateTime to, List<long> eventTypeIds = null, string menuId = null);
		IList<Event> GetRangeForDrivers(List<long> driverIds, DateTime from, DateTime to, List<long> eventTypeIds = null, string menuId = null);
		Task<IList<Event>> GetRangeForDriversAsync(List<long> driverIds, DateTime from, DateTime to, List<long> eventTypeIds = null, string menuId = null);
		IList<Event> GetRangeForGroups(List<long> groupIds, string entityType, DateTime from, DateTime to, List<long> eventTypeIds = null, string menuId = null);
		Task<IList<Event>> GetRangeForGroupsAsync(List<long> groupIds, string entityType, DateTime from, DateTime to, List<long> eventTypeIds = null, string menuId = null);
		IList<Event> GetSinceForAssets(List<long> assetIds, DateTime since, byte quantity, List<long> eventTypeIds = null, string menuId = null);
		Task<IList<Event>> GetSinceForAssetsAsync(List<long> assetIds, DateTime since, byte quantity, List<long> eventTypeIds = null, string menuId = null);
		IList<Event> GetSinceForDrivers(List<long> driverIds, DateTime since, byte quantity, List<long> eventTypeIds = null, string menuId = null);
		Task<IList<Event>> GetSinceForDriversAsync(List<long> driverIds, DateTime since, byte quantity, List<long> eventTypeIds = null, string menuId = null);
		IList<Event> GetSinceForGroups(List<long> groupIds, string entityType, DateTime since, List<long> eventTypeIds = null, string menuId = null);
		Task<IList<Event>> GetSinceForGroupsAsync(List<long> groupIds, string entityType, DateTime since, List<long> eventTypeIds = null, string menuId = null);
		CreatedSinceResult<Event> GetCreatedSinceForAssets(List<long> assetIds, string sinceToken, int quantity);
		Task<CreatedSinceResult<Event>> GetCreatedSinceForAssetsAsync(List<long> assetIds, string sinceToken, int quantity);
		CreatedSinceResult<Event> GetCreatedSinceForDrivers(List<long> assetIds, string sinceToken, int quantity);
		Task<CreatedSinceResult<Event>> GetCreatedSinceForDriversAsync(List<long> driverIds, string sinceToken, int quantity);
		CreatedSinceResult<Event> GetCreatedSinceForGroups(List<long> groupIds, string entityType, string sinceToken, int quantity);
		Task<CreatedSinceResult<Event>> GetCreatedSinceForGroupsAsync(List<long> groupIds, string entityType, string sinceToken, int quantity);
		CreatedSinceResult<Event> GetCreatedSinceForOrganisation(long organisationId, string sinceToken, int quantity);
		Task<CreatedSinceResult<Event>> GetCreatedSinceForOrganisationAsync(long organisationId, string sinceToken, int quantity);


		/// <summary>Gets up to 1000 events of the specified type(s) created for an organisation since the specified token time</summary>
		/// <param name="organisationId">Id of the organisation</param>
		/// <param name="sinceToken">Token denoting the "since" time for the query in "yyyyMMddHHmmssfff" format.
		/// This may not be more than than 7 days old, and is expressed in UTC.
		/// If no token is not available, use the NEW keyword to default to the current time.
		/// Use the GetSinceToken property of the results for the next call to this method.</param>
		/// <param name="quantity">Number of events (up to 1000) to retrieve. Result may include more items than requested due to server-side quantisation constraints</param>
		/// <param name="eventTypeIds">EventTypeIds to include - limits the results to include only events with a matching EventTypeId</param>
		/// <returns>A <see cref="CreatedSinceResult{Event}"/> containing the result of the call</returns>
		CreatedSinceResult<Event> GetCreatedSinceForOrganisationFiltered(long organisationId, string sinceToken, int quantity, List<long> eventTypeIds);

		/// <summary>Gets up to 1000 events of the specified type(s) created for an organisation since the specified token time</summary>
		/// <param name="organisationId">Id of the organisation</param>
		/// <param name="sinceToken">Token denoting the "since" time for the query in "yyyyMMddHHmmssfff" format.
		/// This may not be more than than 7 days old, and is expressed in UTC.
		/// If no token is not available, use the NEW keyword to default to the current time.
		/// Use the GetSinceToken property of the results for the next call to this method.</param>
		/// <param name="quantity">Number of events (up to 1000) to retrieve. Result may include more items than requested due to server-side quantisation constraints</param>
		/// <param name="eventTypeIds">EventTypeIds to include - limits the results to include only events with a matching EventTypeId</param>
		/// <returns>A <see cref="CreatedSinceResult{Event}"/> containing the result of the call</returns>
		Task<CreatedSinceResult<Event>> GetCreatedSinceForOrganisationFilteredAsync(long organisationId, string sinceToken, int quantity, List<long> eventTypeIds);

		IList<EventClipResponse> GetMediaUrls(long organisationId, List<EventClip> eventClips);
		Task<IList<EventClipResponse>> GetMediaUrlsAsync(long organisationId, List<EventClip> eventClips);
	}
}
