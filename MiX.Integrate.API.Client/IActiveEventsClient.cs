﻿using System;
using System.Collections.Generic;
using MiX.Integrate.Shared.Entities.Events;
using System.Threading.Tasks;
using MiX.Integrate.Api.Client.Base;
using MiX.Integrate.Shared.Entities.Carriers;

namespace MiX.Integrate.Api.Client
{
	public interface IActiveEventsClient : IBaseClient
	{
		/// <summary>Get a list of the most recent active events for an organisation</summary>
		/// <param name="organisationId">The group id of the organisation</param>
		/// <param name="quantity">The maximum number of active events to retrieve</param>
		/// <param name="eventTypeIds">(Optional) A list of event type ids to use in filtering the results</param>
		/// <returns>A list of the most recent active events for an organisation</returns>
		List<ActiveEvent> GetLatestForOrganisation(long organisationId, byte quantity = 1, List<long> eventTypeIds = null);

		/// <summary>Gets the active events in a specified date range (max 30 days) for assets</summary>
		/// <param name="assetIds">The IDs of the assets to be queried</param>
		/// <param name="from">The start of the date range</param>
		/// <param name="to">The end of the date range</param>
		/// <param name="eventTypeIds">(Optional) A list of event type ids to use in filtering the results</param>
		/// <returns>A list of active events in the specified data range for the specified assets</returns>
		List<ActiveEvent> GetRangeForAssets(List<long> assetIds, DateTime from, DateTime to, List<long> eventTypeIds = null);

		/// <summary>Get a list of the most recent active events for an organisation</summary>
		/// <param name="organisationId">The group id of the organisation</param>
		/// <param name="quantity">The maximum number of active events to retrieve</param>
		/// <param name="eventTypeIds">(Optional) A list of event type ids to use in filtering the results</param>
		/// <returns>A list of the most recent active events for an organisation</returns>
		Task<List<ActiveEvent>> GetLatestForOrganisationAsync(long organisationId, byte quantity = 1, List<long> eventTypeIds = null);

		/// <summary>Gets the active events in a specified date range (max 30 days) for assets</summary>
		/// <param name="assetIds">The IDs of the assets to be queried</param>
		/// <param name="from">The start of the date range</param>
		/// <param name="to">The end of the date range</param>
		/// <param name="eventTypeIds">(Optional) A list of event type ids to use in filtering the results</param>
		/// <returns>A list of active events in the specified data range for the specified assets</returns>
		Task<List<ActiveEvent>> GetRangeForAssetsAsync(List<long> assetIds, DateTime from, DateTime to, List<long> eventTypeIds = null);

		CreatedSinceResult<ActiveEvent> GetCreatedSinceForAssets(List<long> assetIds, string sinceToken, int quantity);
		Task<CreatedSinceResult<ActiveEvent>> GetCreatedSinceForAssetsAsync(List<long> assetIds, string sinceToken, int quantity);
		CreatedSinceResult<ActiveEvent> GetCreatedSinceForDrivers(List<long> assetIds, string sinceToken, int quantity);
		Task<CreatedSinceResult<ActiveEvent>> GetCreatedSinceForDriversAsync(List<long> driverIds, string sinceToken, int quantity);
		CreatedSinceResult<ActiveEvent> GetCreatedSinceForGroups(List<long> groupIds, string entityType, string sinceToken, int quantity);
		Task<CreatedSinceResult<ActiveEvent>> GetCreatedSinceForGroupsAsync(List<long> groupIds, string entityType, string sinceToken, int quantity);

	}
}
