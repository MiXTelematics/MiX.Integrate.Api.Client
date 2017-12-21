using System;
using System.Collections.Generic;
using MiX.Integrate.Shared.Entities.Positions;
using System.Threading.Tasks;
using MiX.Integrate.Api.Client.Base;
using MiX.Integrate.Shared.Entities.Carriers;

namespace MiX.Integrate.Api.Client
{
	public interface IPositionsClient : IBaseClient
	{
		List<Position> GetLatestByAssetIds(List<long> assetIds, byte quantity, DateTime? cachedSince = null);
		Task<List<Position>> GetLatestByAssetIdsAsync(List<long> assetIds, byte quantity, DateTime? cachedSince = null);
		List<Position> GetLatestByGroupIds(List<long> groupIds, byte quantity, DateTime? cachedSince = null);
		Task<List<Position>> GetLatestByGroupIdsAsync(List<long> groupIds, byte quantity, DateTime? cachedSince = null);
		List<Position> GetSinceByAssetIds(List<long> assetIds, DateTime since);
		Task<List<Position>> GetSinceByAssetIdsAsync(List<long> assetIds, DateTime since);
		List<Position> GetByDateRangeByGroupIds(List<long> groupIds, DateTime fromDate, DateTime toDate);
		Task<List<Position>> GetByDateRangeByGroupIdsAsync(List<long> groupIds, DateTime fromDate, DateTime toDate);
		List<Position> GetByDateRangeByAssetIds(List<long> assetIds, DateTime fromDate, DateTime toDate);
		Task<List<Position>> GetByDateRangeByAssetIdsAsync(List<long> assetIds, DateTime fromDate, DateTime toDate);
		List<Position> GetByDateRangeByDriverIds(List<long> driverIds, DateTime fromDate, DateTime toDate);
		Task<List<Position>> GetByDateRangeByDriverIdsAsync(List<long> driverIds, DateTime fromDate, DateTime toDate);
		CreatedSinceResult<Position> GetCreatedSinceForGroups(List<long> groupIds, string entityType, string sinceToken, int quantity);
		Task<CreatedSinceResult<Position>> GetCreatedSinceForGroupsAsync(List<long> groupIds, string entityType, string sinceToken, int quantity);
	}
}
