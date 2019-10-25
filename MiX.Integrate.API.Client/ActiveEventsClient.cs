using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Carriers;
using MiX.Integrate.Shared.Entities.Events;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public class ActiveEventsClient : BaseClient, IActiveEventsClient
	{

		public ActiveEventsClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public ActiveEventsClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public List<ActiveEvent> GetLatestForOrganisation(long organisationId, byte quantity = 1, List<long> eventTypeIds = null)
		{
			EventFilter eventFilter = new EventFilter() { EventTypeIds = eventTypeIds };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ActiveEventsController.GETLATESTFORGROUP, HttpMethod.Post);
			request.AddUrlSegment("groupId", organisationId.ToString());
			request.AddUrlSegment("quantity", quantity.ToString());
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<List<ActiveEvent>> response = Execute<List<ActiveEvent>>(request);
			return response.Data;
		}

		public async Task<List<ActiveEvent>> GetLatestForOrganisationAsync(long organisationId, byte quantity = 1, List<long> eventTypeIds = null)
		{
			EventFilter eventFilter = new EventFilter() { EventTypeIds = eventTypeIds };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ActiveEventsController.GETLATESTFORGROUP, HttpMethod.Post);
			request.AddUrlSegment("groupId", organisationId.ToString());
			request.AddUrlSegment("quantity", quantity.ToString());
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<List<ActiveEvent>> response = await ExecuteAsync<List<ActiveEvent>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public async Task<List<ActiveEvent>> GetRangeForAssetsAsync(List<long> assetIds, DateTime from, DateTime to, List<long> eventTypeIds = null)
		{
			EventFilter eventFilter = new EventFilter() { EntityIds = assetIds, EventTypeIds = eventTypeIds };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ActiveEventsController.GETRANGEFORASSETS, HttpMethod.Post);
			request.AddUrlSegment("from", from.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<List<ActiveEvent>> response = await ExecuteAsync<List<ActiveEvent>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public List<ActiveEvent> GetRangeForAssets(List<long> assetIds, DateTime from, DateTime to, List<long> eventTypeIds = null)
		{
			EventFilter eventFilter = new EventFilter() { EntityIds = assetIds, EventTypeIds = eventTypeIds };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ActiveEventsController.GETRANGEFORASSETS, HttpMethod.Post);
			request.AddUrlSegment("from", from.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<List<ActiveEvent>> response = Execute<List<ActiveEvent>>(request);
			return response.Data;
		}

		public async Task<PagedResult<ActiveEvent>> GetRangeForAssetsPagedAsync(List<long> assetIds, DateTime from, DateTime to, byte pageSize, List<long> eventTypeIds = null)
		{
			EventFilter eventFilter = new EventFilter() { EntityIds = assetIds, EventTypeIds = eventTypeIds };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ActiveEventsController.GETRANGEPAGEDFORASSETS, HttpMethod.Post);
			request.AddUrlSegment("from", from.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("pageSize", pageSize.ToString());
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<PagedResult<ActiveEvent>> response = await ExecuteAsync<PagedResult<ActiveEvent>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public PagedResult<ActiveEvent> GetRangeForAssetsPaged(List<long> assetIds, DateTime from, DateTime to, byte pageSize, List<long> eventTypeIds = null)
		{
			EventFilter eventFilter = new EventFilter() { EntityIds = assetIds, EventTypeIds = eventTypeIds };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ActiveEventsController.GETRANGEPAGEDFORASSETS, HttpMethod.Post);
			request.AddUrlSegment("from", from.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("pageSize", pageSize.ToString());
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<PagedResult<ActiveEvent>> response = Execute<PagedResult<ActiveEvent>>(request);
			return response.Data;
		}

		public CreatedSinceResult<ActiveEvent> GetCreatedSinceForAssets(List<long> assetIds, string sinceToken, int quantity)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ActiveEventsController.GETCREATEDSINCEFORASSETSASYNC, HttpMethod.Post);
			request.AddUrlSegment("sinceToken", sinceToken);
			request.AddUrlSegment("quantity", quantity.ToString());
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<ActiveEvent>> response = Execute<List<ActiveEvent>>(request);
			string sHasMoreItems = GetResponseHeader(response.Headers, "HasMoreItems");
			string getSinceToken = GetResponseHeader(response.Headers, "GetSinceToken");
			bool hasMoreItems = false;
			if (!bool.TryParse(sHasMoreItems, out hasMoreItems))
				throw new Exception("Could not read the HasMoreItems header");
			return new CreatedSinceResult<ActiveEvent>() { HasMoreItems = hasMoreItems, GetSinceToken = getSinceToken, Items = response.Data };
		}

		public async Task<CreatedSinceResult<ActiveEvent>> GetCreatedSinceForAssetsAsync(List<long> assetIds, string sinceToken, int quantity)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ActiveEventsController.GETCREATEDSINCEFORASSETSASYNC, HttpMethod.Post);
			request.AddUrlSegment("sinceToken", sinceToken);
			request.AddUrlSegment("quantity", quantity.ToString());
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<ActiveEvent>> response = await ExecuteAsync<List<ActiveEvent>>(request).ConfigureAwait(false);
			string sHasMoreItems = GetResponseHeader(response.Headers, "HasMoreItems");
			string getSinceToken = GetResponseHeader(response.Headers, "GetSinceToken");
			bool hasMoreItems = false;
			if (!bool.TryParse(sHasMoreItems, out hasMoreItems))
				throw new Exception("Could not read the HasMoreItems header");
			return new CreatedSinceResult<ActiveEvent>() { HasMoreItems = hasMoreItems, GetSinceToken = getSinceToken, Items = response.Data };
		}

		public async Task<List<ActiveEvent>> GetRangeForDriversAsync(List<long> driverIds, DateTime from, DateTime to, List<long> eventTypeIds = null)
		{
			EventFilter eventFilter = new EventFilter() { EntityIds = driverIds, EventTypeIds = eventTypeIds };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ActiveEventsController.GETRANGEFORDRIVERS, HttpMethod.Post);
			request.AddUrlSegment("from", from.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<List<ActiveEvent>> response = await ExecuteAsync<List<ActiveEvent>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public List<ActiveEvent> GetRangeForDrivers(List<long> driverIds, DateTime from, DateTime to, List<long> eventTypeIds = null)
		{
			EventFilter eventFilter = new EventFilter() { EntityIds = driverIds, EventTypeIds = eventTypeIds };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ActiveEventsController.GETRANGEFORDRIVERS, HttpMethod.Post);
			request.AddUrlSegment("from", from.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<List<ActiveEvent>> response = Execute<List<ActiveEvent>>(request);
			return response.Data;
		}

		public async Task<PagedResult<ActiveEvent>> GetRangeForDriversPagedAsync(List<long> driverIds, DateTime from, DateTime to, byte pageSize, List<long> eventTypeIds = null)
		{
			EventFilter eventFilter = new EventFilter() { EntityIds = driverIds, EventTypeIds = eventTypeIds };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ActiveEventsController.GETRANGEPAGEDFORDRIVERS, HttpMethod.Post);
			request.AddUrlSegment("from", from.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("pageSize", pageSize.ToString());
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<PagedResult<ActiveEvent>> response = await ExecuteAsync<PagedResult<ActiveEvent>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public PagedResult<ActiveEvent> GetRangeForDriversPaged(List<long> driverIds, DateTime from, DateTime to, byte pageSize, List<long> eventTypeIds = null)
		{
			EventFilter eventFilter = new EventFilter() { EntityIds = driverIds, EventTypeIds = eventTypeIds };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ActiveEventsController.GETRANGEPAGEDFORDRIVERS, HttpMethod.Post);
			request.AddUrlSegment("from", from.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("pageSize", pageSize.ToString());
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<PagedResult<ActiveEvent>> response = Execute<PagedResult<ActiveEvent>>(request);
			return response.Data;
		}

		public CreatedSinceResult<ActiveEvent> GetCreatedSinceForDrivers(List<long> driverIds, string sinceToken, int quantity)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ActiveEventsController.GETCREATEDSINCEFORDRIVERSASYNC, HttpMethod.Post);
			request.AddUrlSegment("sinceToken", sinceToken);
			request.AddUrlSegment("quantity", quantity.ToString());
			request.AddJsonBody(driverIds);
			IHttpRestResponse<List<ActiveEvent>> response = Execute<List<ActiveEvent>>(request);
			string sHasMoreItems = GetResponseHeader(response.Headers, "HasMoreItems");
			string getSinceToken = GetResponseHeader(response.Headers, "GetSinceToken");
			bool hasMoreItems = false;
			if (!bool.TryParse(sHasMoreItems, out hasMoreItems))
				throw new Exception("Could not read the HasMoreItems header");
			return new CreatedSinceResult<ActiveEvent>() { HasMoreItems = hasMoreItems, GetSinceToken = getSinceToken, Items = response.Data };
		}

		public async Task<CreatedSinceResult<ActiveEvent>> GetCreatedSinceForDriversAsync(List<long> driverIds, string sinceToken, int quantity)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ActiveEventsController.GETCREATEDSINCEFORDRIVERSASYNC, HttpMethod.Post);
			request.AddUrlSegment("sinceToken", sinceToken);
			request.AddUrlSegment("quantity", quantity.ToString());
			request.AddJsonBody(driverIds);
			IHttpRestResponse<List<ActiveEvent>> response = await ExecuteAsync<List<ActiveEvent>>(request).ConfigureAwait(false);
			string sHasMoreItems = GetResponseHeader(response.Headers, "HasMoreItems");
			string getSinceToken = GetResponseHeader(response.Headers, "GetSinceToken");
			bool hasMoreItems = false;
			if (!bool.TryParse(sHasMoreItems, out hasMoreItems))
				throw new Exception("Could not read the HasMoreItems header");
			return new CreatedSinceResult<ActiveEvent>() { HasMoreItems = hasMoreItems, GetSinceToken = getSinceToken, Items = response.Data };
		}

		public PagedResult<ActiveEvent> GetRangeForGroupsPaged(List<long> groupIds, string entityType, DateTime from, DateTime to, byte pageSize, List<long> eventTypeIds = null)
		{
			EventFilter eventFilter = new EventFilter() { EntityIds = groupIds, EventTypeIds = eventTypeIds };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ActiveEventsController.GETRANGEFORGROUPSPAGED, HttpMethod.Post);
			request.AddUrlSegment("entityType", entityType);
			request.AddUrlSegment("from", from.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("pageSize", pageSize.ToString());
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<PagedResult<ActiveEvent>> response = Execute<PagedResult<ActiveEvent>>(request);
			return response.Data;
		}

		public async Task<PagedResult<ActiveEvent>> GetRangeForGroupsPagedAsync(List<long> groupIds, string entityType, DateTime from, DateTime to, byte pageSize, List<long> eventTypeIds = null)
		{
			EventFilter eventFilter = new EventFilter() { EntityIds = groupIds, EventTypeIds = eventTypeIds };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ActiveEventsController.GETRANGEFORGROUPSPAGED, HttpMethod.Post);
			request.AddUrlSegment("entityType", entityType);
			request.AddUrlSegment("from", from.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("pageSize", pageSize.ToString());
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<PagedResult<ActiveEvent>> response = await ExecuteAsync<PagedResult<ActiveEvent>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public CreatedSinceResult<ActiveEvent> GetCreatedSinceForGroups(List<long> groupIds, string entityType, string sinceToken, int quantity)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ActiveEventsController.GETCREATEDSINCEFORGROUPSASYNC, HttpMethod.Post);
			request.AddUrlSegment("entityType", entityType);
			request.AddUrlSegment("sinceToken", sinceToken);
			request.AddUrlSegment("quantity", quantity.ToString());
			request.AddJsonBody(groupIds);
			IHttpRestResponse<List<ActiveEvent>> response = Execute<List<ActiveEvent>>(request);
			string sHasMoreItems = GetResponseHeader(response.Headers, "HasMoreItems");
			string getSinceToken = GetResponseHeader(response.Headers, "GetSinceToken");
			bool hasMoreItems = false;
			if (!bool.TryParse(sHasMoreItems, out hasMoreItems))
				throw new Exception("Could not read the HasMoreItems header");
			return new CreatedSinceResult<ActiveEvent>() { HasMoreItems = hasMoreItems, GetSinceToken = getSinceToken, Items = response.Data };
		}

		public async Task<CreatedSinceResult<ActiveEvent>> GetCreatedSinceForGroupsAsync(List<long> groupIds, string entityType, string sinceToken, int quantity)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ActiveEventsController.GETCREATEDSINCEFORGROUPSASYNC, HttpMethod.Post);
			request.AddUrlSegment("entityType", entityType);
			request.AddUrlSegment("sinceToken", sinceToken);
			request.AddUrlSegment("quantity", quantity.ToString());
			request.AddJsonBody(groupIds);
			IHttpRestResponse<List<ActiveEvent>> response = await ExecuteAsync<List<ActiveEvent>>(request).ConfigureAwait(false);
			string sHasMoreItems = GetResponseHeader(response.Headers, "HasMoreItems");
			string getSinceToken = GetResponseHeader(response.Headers, "GetSinceToken");
			bool hasMoreItems = false;
			if (!bool.TryParse(sHasMoreItems, out hasMoreItems))
				throw new Exception("Could not read the HasMoreItems header");
			return new CreatedSinceResult<ActiveEvent>() { HasMoreItems = hasMoreItems, GetSinceToken = getSinceToken, Items = response.Data };
		}

		public CreatedSinceResult<ActiveEvent> GetCreatedSinceForOrganisation(long organisationId, string sinceToken, int quantity)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ActiveEventsController.GETCREATEDSINCEFORORGANISATION, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("sinceToken", sinceToken);
			request.AddUrlSegment("quantity", quantity.ToString());
			IHttpRestResponse<List<ActiveEvent>> response = Execute<List<ActiveEvent>>(request);
			string sHasMoreItems = GetResponseHeader(response.Headers, "HasMoreItems");
			string getSinceToken = GetResponseHeader(response.Headers, "GetSinceToken");
			bool hasMoreItems = false;
			if (!bool.TryParse(sHasMoreItems, out hasMoreItems))
				throw new Exception("Could not read the HasMoreItems header");
			return new CreatedSinceResult<ActiveEvent>() { HasMoreItems = hasMoreItems, GetSinceToken = getSinceToken, Items = response.Data };
		}

		public async Task<CreatedSinceResult<ActiveEvent>> GetCreatedSinceForOrganisationAsync(long organisationId, string sinceToken, int quantity)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ActiveEventsController.GETCREATEDSINCEFORORGANISATION, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("sinceToken", sinceToken);
			request.AddUrlSegment("quantity", quantity.ToString());
			IHttpRestResponse<List<ActiveEvent>> response = await ExecuteAsync<List<ActiveEvent>>(request).ConfigureAwait(false);
			string sHasMoreItems = GetResponseHeader(response.Headers, "HasMoreItems");
			string getSinceToken = GetResponseHeader(response.Headers, "GetSinceToken");
			bool hasMoreItems = false;
			if (!bool.TryParse(sHasMoreItems, out hasMoreItems))
				throw new Exception("Could not read the HasMoreItems header");
			return new CreatedSinceResult<ActiveEvent>() { HasMoreItems = hasMoreItems, GetSinceToken = getSinceToken, Items = response.Data };
		}

	}
}
