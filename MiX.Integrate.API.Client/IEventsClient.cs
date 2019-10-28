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
		//PagedResult<Event> GetRangeForAssetsPaged(List<long> assetIds, DateTime from, DateTime to, byte pageSize, List<long> eventTypeIds = null, string menuId = null);
		//Task<PagedResult<Event>> GetRangeForAssetsPagedAsync(List<long> assetIds, DateTime from, DateTime to, byte pageSize, List<long> eventTypeIds = null, string menuId = null);
		IList<Event> GetRangeForDrivers(List<long> driverIds, DateTime from, DateTime to, List<long> eventTypeIds = null, string menuId = null);
		Task<IList<Event>> GetRangeForDriversAsync(List<long> driverIds, DateTime from, DateTime to, List<long> eventTypeIds = null, string menuId = null);
		//PagedResult<Event> GetRangeForDriversPaged(List<long> driverIds, DateTime from, DateTime to, byte pageSize, List<long> eventTypeIds = null, string menuId = null);
		//Task<PagedResult<Event>> GetRangeForDriversPagedAsync(List<long> driverIds, DateTime from, DateTime to, byte pageSize, List<long> eventTypeIds = null, string menuId = null);
		IList<Event> GetRangeForGroups(List<long> groupIds, string entityType, DateTime from, DateTime to, List<long> eventTypeIds = null, string menuId = null);
		Task<IList<Event>> GetRangeForGroupsAsync(List<long> groupIds, string entityType, DateTime from, DateTime to, List<long> eventTypeIds = null, string menuId = null);
		//PagedResult<Event> GetRangeForGroupsPaged(List<long> groupIds, string entityType, DateTime from, DateTime to, byte pageSize, List<long> eventTypeIds = null, string menuId = null);
		//<PagedResult<Event>> GetRangeForGroupsPagedAsync(List<long> groupIds, string entityType, DateTime from, DateTime to, byte pageSize, List<long> eventTypeIds = null, string menuId = null);
		IList<Event> GetSinceForAssets(List<long> assetIds, DateTime since, byte quantity, List<long> eventTypeIds = null, string menuId = null);
		Task<IList<Event>> GetSinceForAssetsAsync(List<long> assetIds, DateTime since, byte quantity, List<long> eventTypeIds = null, string menuId = null);
		//PagedResult<Event> GetSinceForAssetsPaged(List<long> assetIds, DateTime since, byte pageSize, List<long> eventTypeIds = null, string menuId = null);
		//Task<PagedResult<Event>> GetSinceForAssetsPagedAsync(List<long> assetIds, DateTime since, byte pageSize, List<long> eventTypeIds = null, string menuId = null);
		IList<Event> GetSinceForDrivers(List<long> driverIds, DateTime since, byte quantity, List<long> eventTypeIds = null, string menuId = null);
		Task<IList<Event>> GetSinceForDriversAsync(List<long> driverIds, DateTime since, byte quantity, List<long> eventTypeIds = null, string menuId = null);
		//PagedResult<Event> GetSinceForDriversPaged(List<long> driverIds, DateTime since, byte pageSize, List<long> eventTypeIds = null, string menuId = null);
		//Task<PagedResult<Event>> GetSinceForDriversPagedAsync(List<long> driverIds, DateTime since, byte pageSize, List<long> eventTypeIds = null, string menuId = null);
		IList<Event> GetSinceForGroups(List<long> groupIds, string entityType, DateTime since, List<long> eventTypeIds = null, string menuId = null);
		Task<IList<Event>> GetSinceForGroupsAsync(List<long> groupIds, string entityType, DateTime since, List<long> eventTypeIds = null, string menuId = null);
		//PagedResult<Event> GetSinceForGroupsPaged(List<long> groupIds, string entityType, DateTime since, byte pageSize, List<long> eventTypeIds = null, string menuId = null);
		//Task<PagedResult<Event>> GetSinceForGroupsPagedAsync(List<long> groupIds, string entityType, DateTime since, byte pageSize, List<long> eventTypeIds = null, string menuId = null);
		CreatedSinceResult<Event> GetCreatedSinceForAssets(List<long> assetIds, string sinceToken, int quantity);
		Task<CreatedSinceResult<Event>> GetCreatedSinceForAssetsAsync(List<long> assetIds, string sinceToken, int quantity);
		CreatedSinceResult<Event> GetCreatedSinceForDrivers(List<long> assetIds, string sinceToken, int quantity);
		Task<CreatedSinceResult<Event>> GetCreatedSinceForDriversAsync(List<long> driverIds, string sinceToken, int quantity);
		CreatedSinceResult<Event> GetCreatedSinceForGroups(List<long> groupIds, string entityType, string sinceToken, int quantity);
		Task<CreatedSinceResult<Event>> GetCreatedSinceForGroupsAsync(List<long> groupIds, string entityType, string sinceToken, int quantity);
		CreatedSinceResult<Event> GetCreatedSinceForOrganisation(long organisationId, string sinceToken, int quantity);
		Task<CreatedSinceResult<Event>> GetCreatedSinceForOrganisationAsync(long organisationId, string sinceToken, int quantity);
	}
}
