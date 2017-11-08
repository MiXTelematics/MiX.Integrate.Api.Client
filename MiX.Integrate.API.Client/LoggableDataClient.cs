using MiX.Integrate.Api.Client.Base;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Events;
using MiX.Integrate.Shared.Entities.LoggableData;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiX.Integrate.Api.Client
{
	public class LoggableDataClient : BaseClient, ILoggableDataClient
	{

		public LoggableDataClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public LoggableDataClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public async Task<List<LoggableDataCarrier>> GetLoggableDataForAssetsByDateRangeAsync(List<long> assetIds, DateTime fromDate, DateTime toDate, string menuId, string menuItemCode)
		{
			EventMenuFilter menuFilter = new EventMenuFilter() { EntityIds = assetIds, MenuId = menuId, MenuItemCode = menuItemCode };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LOGGABLEDATACONTROLLER.GETLOGGABLEDATAFORASSETSBYDATERANGE, HttpMethod.Post);
			request.AddUrlSegment("from", fromDate.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDate.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(menuFilter);
			IHttpRestResponse<List<LoggableDataCarrier>> response = await ExecuteAsync<List<LoggableDataCarrier>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public async Task<List<RoviMessageCarrier>> GetRoviMessagesForAssetsSinceAsync(List<long> assetIds, DateTime since, string menuId, string menuItemCode)
		{
			EventMenuFilter menuFilter = new EventMenuFilter() { EntityIds = assetIds, MenuId = menuId, MenuItemCode = menuItemCode };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LOGGABLEDATACONTROLLER.GETROVIMESSAGESFORASSETSSINCE, HttpMethod.Post);
			request.AddUrlSegment("since", since.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(menuFilter);
			IHttpRestResponse<List<RoviMessageCarrier>> response = await ExecuteAsync<List<RoviMessageCarrier>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public async Task<List<RoviMessageCarrier>> GetRoviMessagesForAssetsByDateRangeAsync(List<long> assetIds, DateTime fromDate, DateTime toDate, string menuId, string menuItemCode)
		{
			EventMenuFilter menuFilter = new EventMenuFilter() { EntityIds = assetIds, MenuId = menuId, MenuItemCode = menuItemCode };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LOGGABLEDATACONTROLLER.GETROVIMESSAGESFORASSETSBYDATERANGE, HttpMethod.Post);
			request.AddUrlSegment("from", fromDate.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDate.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(menuFilter);
			IHttpRestResponse<List<RoviMessageCarrier>> response = await ExecuteAsync<List<RoviMessageCarrier>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public async Task<List<RoviMessageCarrier>> GetRoviMessagesForAssetsLatestAsync(List<long> assetIds, byte count, string menuId, string menuItemCode)
		{
			EventMenuFilter menuFilter = new EventMenuFilter() { EntityIds = assetIds, MenuId = menuId, MenuItemCode = menuItemCode };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LOGGABLEDATACONTROLLER.GETROVIMESSAGESFORASSETSLATEST, HttpMethod.Post);
			request.AddUrlSegment("count", count.ToString());
			request.AddJsonBody(menuFilter);
			IHttpRestResponse<List<RoviMessageCarrier>> response = await ExecuteAsync<List<RoviMessageCarrier>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public List<LoggableDataCarrier> GetLoggableDataForAssetsByDateRange(List<long> assetIds, DateTime fromDate, DateTime toDate, string menuId, string menuItemCode)
		{
			EventMenuFilter menuFilter = new EventMenuFilter() { EntityIds = assetIds, MenuId = menuId, MenuItemCode = menuItemCode };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LOGGABLEDATACONTROLLER.GETLOGGABLEDATAFORASSETSBYDATERANGE, HttpMethod.Post);
			request.AddUrlSegment("from", fromDate.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDate.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(menuFilter);
			IHttpRestResponse<List<LoggableDataCarrier>> response = Execute<List<LoggableDataCarrier>>(request);
			return response.Data;
		}

		public List<RoviMessageCarrier> GetRoviMessagesForAssetsSince(List<long> assetIds, DateTime since, string menuId, string menuItemCode)
		{
			EventMenuFilter menuFilter = new EventMenuFilter() { EntityIds = assetIds, MenuId = menuId, MenuItemCode = menuItemCode };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LOGGABLEDATACONTROLLER.GETROVIMESSAGESFORASSETSSINCE, HttpMethod.Post);
			request.AddUrlSegment("since", since.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(menuFilter);
			IHttpRestResponse<List<RoviMessageCarrier>> response = Execute<List<RoviMessageCarrier>>(request);
			return response.Data;
		}

		public List<RoviMessageCarrier> GetRoviMessagesForAssetsByDateRange(List<long> assetIds, DateTime fromDate, DateTime toDate, string menuId, string menuItemCode)
		{
			EventMenuFilter menuFilter = new EventMenuFilter() { EntityIds = assetIds, MenuId = menuId, MenuItemCode = menuItemCode };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LOGGABLEDATACONTROLLER.GETROVIMESSAGESFORASSETSBYDATERANGE, HttpMethod.Post);
			request.AddUrlSegment("from", fromDate.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDate.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(menuFilter);
			IHttpRestResponse<List<RoviMessageCarrier>> response = Execute<List<RoviMessageCarrier>>(request);
			return response.Data;
		}

		public List<RoviMessageCarrier> GetRoviMessagesForAssetsLatest(List<long> assetIds, byte count, string menuId, string menuItemCode)
		{
			EventMenuFilter menuFilter = new EventMenuFilter() { EntityIds = assetIds, MenuId = menuId, MenuItemCode = menuItemCode };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LOGGABLEDATACONTROLLER.GETROVIMESSAGESFORASSETSLATEST, HttpMethod.Post);
			request.AddUrlSegment("count", count.ToString());
			request.AddJsonBody(menuFilter);
			IHttpRestResponse<List<RoviMessageCarrier>> response = Execute<List<RoviMessageCarrier>>(request);
			return response.Data;
		}

	}
}
