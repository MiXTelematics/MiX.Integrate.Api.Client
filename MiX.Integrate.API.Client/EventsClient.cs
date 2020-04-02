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
	public class EventsClient : BaseClient, IEventsClient
	{

		public EventsClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public EventsClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public IList<Event> GetLatestForAssets(List<long> assetIds, byte quantity = 1, DateTime? cachedSince = null, List<long> eventTypeIds = null, string menuId = null)
		{
			EventFilter eventFilter = new EventFilter() { EntityIds = assetIds, EventTypeIds = eventTypeIds, MenuId = menuId };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.EventsController.GETLATESTFORASSETS, HttpMethod.Post);
			request.AddUrlSegment("quantity", quantity.ToString());
			if (cachedSince.HasValue)
				request.AddQueryParameter("cachedSince", cachedSince.Value.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<List<Event>> response = Execute<List<Event>>(request);
			return response.Data;
		}

		public async Task<IList<Event>> GetLatestForAssetsAsync(List<long> assetIds, byte quantity = 1, DateTime? cachedSince = null, List<long> eventTypeIds = null, string menuId = null)
		{
			EventFilter eventFilter = new EventFilter() { EntityIds = assetIds, EventTypeIds = eventTypeIds, MenuId = menuId };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.EventsController.GETLATESTFORASSETS, HttpMethod.Post);
			request.AddUrlSegment("quantity", quantity.ToString());
			if (cachedSince.HasValue)
				request.AddQueryParameter("cachedSince", cachedSince.Value.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<List<Event>> response = await ExecuteAsync<List<Event>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<Event> GetLatestForDrivers(List<long> driverIds, byte quantity = 1, DateTime? cachedSince = null, List<long> eventTypeIds = null, string menuId = null)
		{
			EventFilter eventFilter = new EventFilter() { EntityIds = driverIds, EventTypeIds = eventTypeIds, MenuId = menuId };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.EventsController.GETLATESTFORDRIVERS, HttpMethod.Post);
			request.AddUrlSegment("quantity", quantity.ToString());
			if (cachedSince.HasValue)
				request.AddQueryParameter("cachedSince", cachedSince.Value.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<List<Event>> response = Execute<List<Event>>(request);
			return response.Data;
		}

		public async Task<IList<Event>> GetLatestForDriversAsync(List<long> driverIds, byte quantity = 1, DateTime? cachedSince = null, List<long> eventTypeIds = null, string menuId = null)
		{
			EventFilter eventFilter = new EventFilter() { EntityIds = driverIds, EventTypeIds = eventTypeIds, MenuId = menuId };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.EventsController.GETLATESTFORDRIVERS, HttpMethod.Post);
			request.AddUrlSegment("quantity", quantity.ToString());
			if (cachedSince.HasValue)
				request.AddQueryParameter("cachedSince", cachedSince.Value.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<List<Event>> response = await ExecuteAsync<List<Event>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<Event> GetLatestForGroups(List<long> groupIds, string entityType, byte quantity = 1, DateTime? cachedSince = null, List<long> eventTypeIds = null, string menuId = null)
		{
			EventFilter eventFilter = new EventFilter() { EntityIds = groupIds, EventTypeIds = eventTypeIds, MenuId = menuId };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.EventsController.GETLATESTFORGROUPS, HttpMethod.Post);
			request.AddUrlSegment("quantity", quantity.ToString());
			request.AddUrlSegment("entityType", entityType);
			if (cachedSince.HasValue)
				request.AddQueryParameter("cachedSince", cachedSince.Value.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<List<Event>> response = Execute<List<Event>>(request);
			return response.Data;
		}

		public async Task<IList<Event>> GetLatestForGroupsAsync(List<long> groupIds, string entityType, byte quantity = 1, DateTime? cachedSince = null, List<long> eventTypeIds = null, string menuId = null)
		{
			EventFilter eventFilter = new EventFilter() { EntityIds = groupIds, EventTypeIds = eventTypeIds, MenuId = menuId };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.EventsController.GETLATESTFORGROUPS, HttpMethod.Post);
			request.AddUrlSegment("quantity", quantity.ToString());
			request.AddUrlSegment("entityType", entityType);
			if (cachedSince.HasValue)
				request.AddQueryParameter("cachedSince", cachedSince.Value.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<List<Event>> response = await ExecuteAsync<List<Event>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<Event> GetRangeForAssets(List<long> assetIds, DateTime from, DateTime to, List<long> eventTypeIds = null, string menuId = null)
		{
			EventFilter eventFilter = new EventFilter() { EntityIds = assetIds, EventTypeIds = eventTypeIds, MenuId = menuId };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.EventsController.GETRANGEFORASSETS, HttpMethod.Post);
			request.AddUrlSegment("from", from.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<List<Event>> response = Execute<List<Event>>(request);
			return response.Data;
		}

		public async Task<IList<Event>> GetRangeForAssetsAsync(List<long> assetIds, DateTime from, DateTime to, List<long> eventTypeIds = null, string menuId = null)
		{
			EventFilter eventFilter = new EventFilter() { EntityIds = assetIds, EventTypeIds = eventTypeIds, MenuId = menuId };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.EventsController.GETRANGEFORASSETS, HttpMethod.Post);
			request.AddUrlSegment("from", from.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<List<Event>> response = await ExecuteAsync<List<Event>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<Event> GetRangeForDrivers(List<long> driverIds, DateTime from, DateTime to, List<long> eventTypeIds = null, string menuId = null)
		{
			EventFilter eventFilter = new EventFilter() { EntityIds = driverIds, EventTypeIds = eventTypeIds, MenuId = menuId };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.EventsController.GETRANGEFORDRIVERS, HttpMethod.Post);
			request.AddUrlSegment("from", from.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<List<Event>> response = Execute<List<Event>>(request);
			return response.Data;
		}

		public async Task<IList<Event>> GetRangeForDriversAsync(List<long> driverIds, DateTime from, DateTime to, List<long> eventTypeIds = null, string menuId = null)
		{
			EventFilter eventFilter = new EventFilter() { EntityIds = driverIds, EventTypeIds = eventTypeIds, MenuId = menuId };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.EventsController.GETRANGEFORDRIVERS, HttpMethod.Post);
			request.AddUrlSegment("from", from.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<List<Event>> response = await ExecuteAsync<List<Event>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<Event> GetRangeForGroups(List<long> groupIds, string entityType, DateTime from, DateTime to, List<long> eventTypeIds = null, string menuId = null)
		{
			EventFilter eventFilter = new EventFilter() { EntityIds = groupIds, EventTypeIds = eventTypeIds, MenuId = menuId };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.EventsController.GETRANGEFORGROUPS, HttpMethod.Post);
			request.AddUrlSegment("entityType", entityType);
			request.AddUrlSegment("from", from.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<List<Event>> response = Execute<List<Event>>(request);
			return response.Data;
		}

		public async Task<IList<Event>> GetRangeForGroupsAsync(List<long> groupIds, string entityType, DateTime from, DateTime to, List<long> eventTypeIds = null, string menuId = null)
		{
			EventFilter eventFilter = new EventFilter() { EntityIds = groupIds, EventTypeIds = eventTypeIds, MenuId = menuId };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.EventsController.GETRANGEFORGROUPS, HttpMethod.Post);
			request.AddUrlSegment("entityType", entityType);
			request.AddUrlSegment("from", from.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<List<Event>> response = await ExecuteAsync<List<Event>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<Event> GetSinceForAssets(List<long> assetIds, DateTime since, byte quantity, List<long> eventTypeIds = null, string menuId = null)
		{
			EventFilter eventFilter = new EventFilter() { EntityIds = assetIds, EventTypeIds = eventTypeIds, MenuId = menuId };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.EventsController.GETSINCEFORASSETS, HttpMethod.Post);
			request.AddUrlSegment("since", since.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("quantity", quantity.ToString());
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<List<Event>> response = Execute<List<Event>>(request);
			return response.Data;
		}

		public async Task<IList<Event>> GetSinceForAssetsAsync(List<long> assetIds, DateTime since, byte quantity, List<long> eventTypeIds = null, string menuId = null)
		{
			EventFilter eventFilter = new EventFilter() { EntityIds = assetIds, EventTypeIds = eventTypeIds, MenuId = menuId };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.EventsController.GETSINCEFORASSETS, HttpMethod.Post);
			request.AddUrlSegment("since", since.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("quantity", quantity.ToString());
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<List<Event>> response = await ExecuteAsync<List<Event>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<Event> GetSinceForDrivers(List<long> driverIds, DateTime since, byte quantity, List<long> eventTypeIds = null, string menuId = null)
		{
			EventFilter eventFilter = new EventFilter() { EntityIds = driverIds, EventTypeIds = eventTypeIds, MenuId = menuId };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.EventsController.GETSINCEFORDRIVERS, HttpMethod.Post);
			request.AddUrlSegment("since", since.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("quantity", quantity.ToString());
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<List<Event>> response = Execute<List<Event>>(request);
			return response.Data;
		}

		public async Task<IList<Event>> GetSinceForDriversAsync(List<long> driverIds, DateTime since, byte quantity, List<long> eventTypeIds = null, string menuId = null)
		{
			EventFilter eventFilter = new EventFilter() { EntityIds = driverIds, EventTypeIds = eventTypeIds, MenuId = menuId };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.EventsController.GETSINCEFORDRIVERS, HttpMethod.Post);
			request.AddUrlSegment("since", since.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("quantity", quantity.ToString());
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<List<Event>> response = await ExecuteAsync<List<Event>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<Event> GetSinceForGroups(List<long> groupIds, string entityType, DateTime since, List<long> eventTypeIds = null, string menuId = null)
		{
			EventFilter eventFilter = new EventFilter() { EntityIds = groupIds, EventTypeIds = eventTypeIds, MenuId = menuId };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.EventsController.GETSINCEFORGROUPS, HttpMethod.Post);
			request.AddUrlSegment("entityType", entityType);
			request.AddUrlSegment("since", since.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<List<Event>> response = Execute<List<Event>>(request);
			return response.Data;
		}

		public async Task<IList<Event>> GetSinceForGroupsAsync(List<long> groupIds, string entityType, DateTime since, List<long> eventTypeIds = null, string menuId = null)
		{
			EventFilter eventFilter = new EventFilter() { EntityIds = groupIds, EventTypeIds = eventTypeIds, MenuId = menuId };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.EventsController.GETSINCEFORGROUPS, HttpMethod.Post);
			request.AddUrlSegment("entityType", entityType);
			request.AddUrlSegment("since", since.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<List<Event>> response = await ExecuteAsync<List<Event>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public CreatedSinceResult<Event> GetCreatedSinceForAssets(List<long> assetIds, string sinceToken, int quantity)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.EventsController.GETCREATEDSINCEFORASSETSASYNC, HttpMethod.Post);
			request.AddUrlSegment("sinceToken", sinceToken);
			request.AddUrlSegment("quantity", quantity.ToString());
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<Event>> response = Execute<List<Event>>(request);
			string sHasMoreItems = GetResponseHeader(response.Headers, "HasMoreItems");
			string getSinceToken = GetResponseHeader(response.Headers, "GetSinceToken");
			bool hasMoreItems = false;
			if (!bool.TryParse(sHasMoreItems, out hasMoreItems))
				throw new Exception("Could not read the HasMoreItems header");
			return new CreatedSinceResult<Event>() { HasMoreItems = hasMoreItems, GetSinceToken = getSinceToken, Items = response.Data };
		}

		public async Task<CreatedSinceResult<Event>> GetCreatedSinceForAssetsAsync(List<long> assetIds, string sinceToken, int quantity)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.EventsController.GETCREATEDSINCEFORASSETSASYNC, HttpMethod.Post);
			request.AddUrlSegment("sinceToken", sinceToken);
			request.AddUrlSegment("quantity", quantity.ToString());
			request.AddJsonBody(assetIds);
			IHttpRestResponse<List<Event>> response = await ExecuteAsync<List<Event>>(request).ConfigureAwait(false);
			string sHasMoreItems = GetResponseHeader(response.Headers, "HasMoreItems");
			string getSinceToken = GetResponseHeader(response.Headers, "GetSinceToken");
			bool hasMoreItems = false;
			if (!bool.TryParse(sHasMoreItems, out hasMoreItems))
				throw new Exception("Could not read the HasMoreItems header");
			return new CreatedSinceResult<Event>() { HasMoreItems = hasMoreItems, GetSinceToken = getSinceToken, Items = response.Data };
		}

		public CreatedSinceResult<Event> GetCreatedSinceForDrivers(List<long> driverIds, string sinceToken, int quantity)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.EventsController.GETCREATEDSINCEFORDRIVERSASYNC, HttpMethod.Post);
			request.AddUrlSegment("sinceToken", sinceToken);
			request.AddUrlSegment("quantity", quantity.ToString());
			request.AddJsonBody(driverIds);
			IHttpRestResponse<List<Event>> response = Execute<List<Event>>(request);
			string sHasMoreItems = GetResponseHeader(response.Headers, "HasMoreItems");
			string getSinceToken = GetResponseHeader(response.Headers, "GetSinceToken");
			bool hasMoreItems = false;
			if (!bool.TryParse(sHasMoreItems, out hasMoreItems))
				throw new Exception("Could not read the HasMoreItems header");
			return new CreatedSinceResult<Event>() { HasMoreItems = hasMoreItems, GetSinceToken = getSinceToken, Items = response.Data };
		}

		public async Task<CreatedSinceResult<Event>> GetCreatedSinceForDriversAsync(List<long> driverIds, string sinceToken, int quantity)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.EventsController.GETCREATEDSINCEFORDRIVERSASYNC, HttpMethod.Post);
			request.AddUrlSegment("sinceToken", sinceToken);
			request.AddUrlSegment("quantity", quantity.ToString());
			request.AddJsonBody(driverIds);
			IHttpRestResponse<List<Event>> response = await ExecuteAsync<List<Event>>(request).ConfigureAwait(false);
			string sHasMoreItems = GetResponseHeader(response.Headers, "HasMoreItems");
			string getSinceToken = GetResponseHeader(response.Headers, "GetSinceToken");
			bool hasMoreItems = false;
			if (!bool.TryParse(sHasMoreItems, out hasMoreItems))
				throw new Exception("Could not read the HasMoreItems header");
			return new CreatedSinceResult<Event>() { HasMoreItems = hasMoreItems, GetSinceToken = getSinceToken, Items = response.Data };
		}

		public CreatedSinceResult<Event> GetCreatedSinceForGroups(List<long> groupIds, string entityType, string sinceToken, int quantity)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.EventsController.GETCREATEDSINCEFORGROUPSASYNC, HttpMethod.Post);
			request.AddUrlSegment("entityType", entityType);
			request.AddUrlSegment("sinceToken", sinceToken);
			request.AddUrlSegment("quantity", quantity.ToString());
			request.AddJsonBody(groupIds);
			IHttpRestResponse<List<Event>> response = Execute<List<Event>>(request);
			string sHasMoreItems = GetResponseHeader(response.Headers, "HasMoreItems");
			string getSinceToken = GetResponseHeader(response.Headers, "GetSinceToken");
			bool hasMoreItems = false;
			if (!bool.TryParse(sHasMoreItems, out hasMoreItems))
				throw new Exception("Could not read the HasMoreItems header");
			return new CreatedSinceResult<Event>() { HasMoreItems = hasMoreItems, GetSinceToken = getSinceToken, Items = response.Data };
		}

		public async Task<CreatedSinceResult<Event>> GetCreatedSinceForGroupsAsync(List<long> groupIds, string entityType, string sinceToken, int quantity)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.EventsController.GETCREATEDSINCEFORGROUPSASYNC, HttpMethod.Post);
			request.AddUrlSegment("entityType", entityType);
			request.AddUrlSegment("sinceToken", sinceToken);
			request.AddUrlSegment("quantity", quantity.ToString());
			request.AddJsonBody(groupIds);
			IHttpRestResponse<List<Event>> response = await ExecuteAsync<List<Event>>(request).ConfigureAwait(false);
			string sHasMoreItems = GetResponseHeader(response.Headers, "HasMoreItems");
			string getSinceToken = GetResponseHeader(response.Headers, "GetSinceToken");
			bool hasMoreItems = false;
			if (!bool.TryParse(sHasMoreItems, out hasMoreItems))
				throw new Exception("Could not read the HasMoreItems header");
			return new CreatedSinceResult<Event>() { HasMoreItems = hasMoreItems, GetSinceToken = getSinceToken, Items = response.Data };
		}

		public CreatedSinceResult<Event> GetCreatedSinceForOrganisation(long organisationId, string sinceToken, int quantity)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.EventsController.GETCREATEDSINCEFORORGANISATION, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("sinceToken", sinceToken);
			request.AddUrlSegment("quantity", quantity.ToString());
			IHttpRestResponse<List<Event>> response = Execute<List<Event>>(request);
			string sHasMoreItems = GetResponseHeader(response.Headers, "HasMoreItems");
			string getSinceToken = GetResponseHeader(response.Headers, "GetSinceToken");
			bool hasMoreItems = false;
			if (!bool.TryParse(sHasMoreItems, out hasMoreItems))
				throw new Exception("Could not read the HasMoreItems header");
			return new CreatedSinceResult<Event>() { HasMoreItems = hasMoreItems, GetSinceToken = getSinceToken, Items = response.Data };
		}

		public async Task<CreatedSinceResult<Event>> GetCreatedSinceForOrganisationAsync(long organisationId, string sinceToken, int quantity)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.EventsController.GETCREATEDSINCEFORORGANISATION, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("sinceToken", sinceToken);
			request.AddUrlSegment("quantity", quantity.ToString());
			IHttpRestResponse<List<Event>> response = await ExecuteAsync<List<Event>>(request).ConfigureAwait(false);
			string sHasMoreItems = GetResponseHeader(response.Headers, "HasMoreItems");
			string getSinceToken = GetResponseHeader(response.Headers, "GetSinceToken");
			bool hasMoreItems = false;
			if (!bool.TryParse(sHasMoreItems, out hasMoreItems))
				throw new Exception("Could not read the HasMoreItems header");
			return new CreatedSinceResult<Event>() { HasMoreItems = hasMoreItems, GetSinceToken = getSinceToken, Items = response.Data };
		}

			/// <summary>Gets up to 1000 events of the specified type(s) created for an organisation since the specified token time</summary>
			/// <param name="organisationId">Id of the organisation</param>
			/// <param name="sinceToken">Token denoting the "since" time for the query in "yyyyMMddHHmmssfff" format.
			/// This may not be more than than 7 days old, and is expressed in UTC.
			/// If no token is not available, use the NEW keyword to default to the current time.
			/// Use the GetSinceToken property of the results for the next call to this method.</param>
			/// <param name="quantity">Number of events (up to 1000) to retrieve. Result may include more items than requested due to server-side quantisation constraints</param>
			/// <param name="eventTypeIds">EventTypeIds to include - limits the results to include only events with a matching EventTypeId</param>
			/// <returns>A <see cref="CreatedSinceResult{Event}"/> containing the result of the call</returns>
			public CreatedSinceResult<Event> GetCreatedSinceForOrganisationFiltered(long organisationId, string sinceToken, int quantity, List<long> eventTypeIds)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.EventsController.GETCREATEDSINCEFORORGANISATION, HttpMethod.Post);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("sinceToken", sinceToken);
			request.AddUrlSegment("quantity", quantity.ToString());
			request.AddJsonBody(eventTypeIds);
			IHttpRestResponse<List<Event>> response = Execute<List<Event>>(request);
			string sHasMoreItems = GetResponseHeader(response.Headers, "HasMoreItems");
			string getSinceToken = GetResponseHeader(response.Headers, "GetSinceToken");
			bool hasMoreItems = false;
			if (!bool.TryParse(sHasMoreItems, out hasMoreItems))
				throw new Exception("Could not read the HasMoreItems header");
			return new CreatedSinceResult<Event>() { HasMoreItems = hasMoreItems, GetSinceToken = getSinceToken, Items = response.Data };
		}

			/// <summary>Gets up to 1000 events of the specified type(s) created for an organisation since the specified token time</summary>
			/// <param name="organisationId">Id of the organisation</param>
			/// <param name="sinceToken">Token denoting the "since" time for the query in "yyyyMMddHHmmssfff" format.
			/// This may not be more than than 7 days old, and is expressed in UTC.
			/// If no token is not available, use the NEW keyword to default to the current time.
			/// Use the GetSinceToken property of the results for the next call to this method.</param>
			/// <param name="quantity">Number of events (up to 1000) to retrieve. Result may include more items than requested due to server-side quantisation constraints</param>
			/// <param name="eventTypeIds">EventTypeIds to include - limits the results to include only events with a matching EventTypeId</param>
			/// <returns>A <see cref="CreatedSinceResult{Event}"/> containing the result of the call</returns>
		public async Task<CreatedSinceResult<Event>> GetCreatedSinceForOrganisationFilteredAsync(long organisationId, string sinceToken, int quantity, List<long> eventTypeIds)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.EventsController.GETCREATEDSINCEFORORGANISATION, HttpMethod.Post);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("sinceToken", sinceToken);
			request.AddUrlSegment("quantity", quantity.ToString());
			request.AddJsonBody(eventTypeIds);
			IHttpRestResponse<List<Event>> response = await ExecuteAsync<List<Event>>(request).ConfigureAwait(false);
			string sHasMoreItems = GetResponseHeader(response.Headers, "HasMoreItems");
			string getSinceToken = GetResponseHeader(response.Headers, "GetSinceToken");
			bool hasMoreItems = false;
			if (!bool.TryParse(sHasMoreItems, out hasMoreItems))
				throw new Exception("Could not read the HasMoreItems header");
			return new CreatedSinceResult<Event>() { HasMoreItems = hasMoreItems, GetSinceToken = getSinceToken, Items = response.Data };
		}

	public IList<EventClipResponse> GetMediaUrls(long organisationId, List<EventClip> eventClips)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.EventsController.GETMEDIAURLS, HttpMethod.Post);
			request.AddUrlSegment("groupId", organisationId.ToString());
			request.AddJsonBody(eventClips);
			IHttpRestResponse<List<EventClipResponse>> response = Execute<List<EventClipResponse>>(request);
			return response.Data;
		}

		public async Task<IList<EventClipResponse>> GetMediaUrlsAsync(long organisationId, List<EventClip> eventClips)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.EventsController.GETMEDIAURLS, HttpMethod.Post);
			request.AddUrlSegment("groupId", organisationId.ToString());
			request.AddJsonBody(eventClips);
			IHttpRestResponse<List<EventClipResponse>> response = await ExecuteAsync<List<EventClipResponse>>(request).ConfigureAwait(false);
			return response.Data;
		}
	}
}
