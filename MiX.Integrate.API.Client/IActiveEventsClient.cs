using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Entities.Carriers;
using MiX.Integrate.Shared.Entities.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public interface IActiveEventsClient : IBaseClient
	{
		/// <summary>
		/// Get a list of the most recent active events for an organisation
		/// </summary>
		/// <param name="organisationId">The group id of the organisation</param>
		/// <param name="quantity">The maximum number of active events to retrieve</param>
		/// <param name="eventTypeIds">(Optional) A list of event type ids to use in filtering the results</param>
		/// <returns>
		/// A list of the most recent active events for an organisation
		/// </returns>
		List<ActiveEvent> GetLatestForOrganisation(long organisationId, byte quantity = 1, List<long> eventTypeIds = null);

		/// <summary>
		/// Get a list of the most recent active events for an organisation
		/// </summary>
		/// <param name="organisationId">The group id of the organisation</param>
		/// <param name="quantity">The maximum number of active events to retrieve</param>
		/// <param name="eventTypeIds">(Optional) A list of event type ids to use in filtering the results</param>
		/// <returns>
		/// A list of the most recent active events for an organisation
		/// </returns>
		Task<List<ActiveEvent>> GetLatestForOrganisationAsync(long organisationId, byte quantity = 1, List<long> eventTypeIds = null);

		/// <summary>
		/// Gets the active events in a specified date range (max 30 days) for assets
		/// </summary>
		/// <param name="assetIds">The IDs of the assets to be queried</param>
		/// <param name="from">The start of the date range</param>
		/// <param name="to">The end of the date range</param>
		/// <param name="eventTypeIds">(Optional) A list of event type ids to use in filtering the results</param>
		/// <returns>
		/// A list of active events in the specified data range for the specified assets
		/// </returns>
		List<ActiveEvent> GetRangeForAssets(List<long> assetIds, DateTime from, DateTime to, List<long> eventTypeIds = null);

		/// <summary>
		/// Gets the active events in a specified date range (max 30 days) for assets
		/// </summary>
		/// <param name="assetIds">The IDs of the assets to be queried</param>
		/// <param name="from">The start of the date range</param>
		/// <param name="to">The end of the date range</param>
		/// <param name="eventTypeIds">(Optional) A list of event type ids to use in filtering the results</param>
		/// <returns>
		/// A list of active events in the specified data range for the specified assets
		/// </returns>
		Task<List<ActiveEvent>> GetRangeForAssetsAsync(List<long> assetIds, DateTime from, DateTime to, List<long> eventTypeIds = null);

		CreatedSinceResult<ActiveEvent> GetCreatedSinceForAssets(List<long> assetIds, string sinceToken, int quantity);
		Task<CreatedSinceResult<ActiveEvent>> GetCreatedSinceForAssetsAsync(List<long> assetIds, string sinceToken, int quantity);
		CreatedSinceResult<ActiveEvent> GetCreatedSinceForDrivers(List<long> assetIds, string sinceToken, int quantity);
		Task<CreatedSinceResult<ActiveEvent>> GetCreatedSinceForDriversAsync(List<long> driverIds, string sinceToken, int quantity);
		CreatedSinceResult<ActiveEvent> GetCreatedSinceForGroups(List<long> groupIds, string entityType, string sinceToken, int quantity);
		Task<CreatedSinceResult<ActiveEvent>> GetCreatedSinceForGroupsAsync(List<long> groupIds, string entityType, string sinceToken, int quantity);
		CreatedSinceResult<ActiveEvent> GetCreatedSinceForOrganisation(long organisationId, string sinceToken, int quantity);
		Task<CreatedSinceResult<ActiveEvent>> GetCreatedSinceForOrganisationAsync(long organisationId, string sinceToken, int quantity);

		/// <summary>Gets up to 1000 active events of the specified type(s) created for an organisation since the specified token time</summary>
		/// <param name="organisationId">Id of the organisation</param>
		/// <param name="sinceToken">Token denoting the "since" time for the query in "yyyyMMddHHmmssfff" format.
		/// This may not be more than than 7 days old, and is expressed in UTC.
		/// If no token is not available, use the NEW keyword to default to the current time.
		/// Use the GetSinceToken property of the results for the next call to this method.</param>
		/// <param name="quantity">Number of active events (up to 1000) to retrieve. Result may include more items than requested due to server-side quantisation constraints</param>
		/// <param name="eventTypeIds">EventTypeIds to include - limits the results to include only active events with a matching EventTypeId</param>
		/// <returns>A <see cref="CreatedSinceResult{ActiveEvent}"/> containing the result of the call</returns>
		CreatedSinceResult<ActiveEvent> GetCreatedSinceForOrganisationFiltered(long organisationId, string sinceToken, int quantity, List<long> eventTypeIds);

		/// <summary>Gets up to 1000 active events of the specified type(s) created for an organisation since the specified token time</summary>
		/// <param name="organisationId">Id of the organisation</param>
		/// <param name="sinceToken">Token denoting the "since" time for the query in "yyyyMMddHHmmssfff" format.
		/// This may not be more than than 7 days old, and is expressed in UTC.
		/// If no token is not available, use the NEW keyword to default to the current time.
		/// Use the GetSinceToken property of the results for the next call to this method.</param>
		/// <param name="quantity">Number of active events (up to 1000) to retrieve. Result may include more items than requested due to server-side quantisation constraints</param>
		/// <param name="eventTypeIds">EventTypeIds to include - limits the results to include only active events with a matching EventTypeId</param>
		/// <returns>A <see cref="CreatedSinceResult{ActiveEvent}"/> containing the result of the call</returns>
		Task<CreatedSinceResult<ActiveEvent>> GetCreatedSinceForOrganisationFilteredAsync(long organisationId, string sinceToken, int quantity, List<long> eventTypeIds);
	}
}
