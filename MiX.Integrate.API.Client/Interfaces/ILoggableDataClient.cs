using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Entities.LoggableData;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public interface ILoggableDataClient : IBaseClient
	{
		Task<List<LoggableDataCarrier>> GetLoggableDataForAssetsByDateRangeAsync(List<long> assetIds, DateTime fromDate, DateTime toDate, string menuId, string menuItemCode);
		Task<List<RoviMessageCarrier>> GetRoviMessagesForAssetsSinceAsync(List<long> assetIds, DateTime since, string menuId, string menuItemCode);
		Task<List<RoviMessageCarrier>> GetRoviMessagesForAssetsByDateRangeAsync(List<long> assetIds, DateTime fromDate, DateTime toDate, string menuId, string menuItemCode);
		Task<List<RoviMessageCarrier>> GetRoviMessagesForAssetsLatestAsync(List<long> assetIds, byte count, string menuId, string menuItemCode);

		List<LoggableDataCarrier> GetLoggableDataForAssetsByDateRange(List<long> assetIds, DateTime fromDate, DateTime toDate, string menuId, string menuItemCode);
		List<RoviMessageCarrier> GetRoviMessagesForAssetsSince(List<long> assetIds, DateTime since, string menuId, string menuItemCode);
		List<RoviMessageCarrier> GetRoviMessagesForAssetsByDateRange(List<long> assetIds, DateTime fromDate, DateTime toDate, string menuId, string menuItemCode);
		List<RoviMessageCarrier> GetRoviMessagesForAssetsLatest(List<long> assetIds, byte count, string menuId, string menuItemCode);
	}
}
