using System;
using System.Collections.Generic;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Events;
using System.Threading.Tasks;
using MiX.Integrate.Api.Client.Base;
using System.Net.Http;
using MiX.Integrate.Shared.Entities.Carriers;

namespace MiX.Integrate.Api.Client
{
	public class ActiveEventsClient : BaseClient, IActiveEventsClient
	{

		public ActiveEventsClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public ActiveEventsClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public List<ActiveEvent> GetRangeForAssets(List<long> assetIds, DateTime from, DateTime to, List<long> eventTypeIds = null)
		{
			EventFilter eventFilter = new EventFilter() { EntityIds = assetIds, EventTypeIds = eventTypeIds };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ACTIVEEVENTSCONTROLLER.GETRANGEFORASSETS, HttpMethod.Post);
			request.AddUrlSegment("from", from.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<List<ActiveEvent>> response = Execute<List<ActiveEvent>>(request);
			return response.Data;
		}

		public List<ActiveEvent> GetLatestForOrganisation(long organisationId, byte quantity = 1, List<long> eventTypeIds = null)
		{
			EventFilter eventFilter = new EventFilter() { EventTypeIds = eventTypeIds };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ACTIVEEVENTSCONTROLLER.GETLATESTFORGROUP, HttpMethod.Post);
			request.AddUrlSegment("groupId", organisationId.ToString());
			request.AddUrlSegment("quantity", quantity.ToString());
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<List<ActiveEvent>> response = Execute<List<ActiveEvent>>(request);
			return response.Data;
		}

		public async Task<List<ActiveEvent>> GetRangeForAssetsAsync(List<long> assetIds, DateTime from, DateTime to, List<long> eventTypeIds = null)
		{
			EventFilter eventFilter = new EventFilter() { EntityIds = assetIds, EventTypeIds = eventTypeIds };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ACTIVEEVENTSCONTROLLER.GETRANGEFORASSETS, HttpMethod.Post);
			request.AddUrlSegment("from", from.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<List<ActiveEvent>> response = await ExecuteAsync<List<ActiveEvent>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public async Task<List<ActiveEvent>> GetLatestForOrganisationAsync(long organisationId, byte quantity = 1, List<long> eventTypeIds = null)
		{
			EventFilter eventFilter = new EventFilter() { EventTypeIds = eventTypeIds };
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ACTIVEEVENTSCONTROLLER.GETLATESTFORGROUP, HttpMethod.Post);
			request.AddUrlSegment("groupId", organisationId.ToString());
			request.AddUrlSegment("quantity", quantity.ToString());
			request.AddJsonBody(eventFilter);
			IHttpRestResponse<List<ActiveEvent>> response = await ExecuteAsync<List<ActiveEvent>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public CreatedSinceResult<ActiveEvent> GetCreatedSinceForAssets(List<long> assetIds, string sinceToken, int quantity)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ACTIVEEVENTSCONTROLLER.GETCREATEDSINCEFORASSETSASYNC, HttpMethod.Post);
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
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ACTIVEEVENTSCONTROLLER.GETCREATEDSINCEFORASSETSASYNC, HttpMethod.Post);
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

		public CreatedSinceResult<ActiveEvent> GetCreatedSinceForDrivers(List<long> driverIds, string sinceToken, int quantity)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ACTIVEEVENTSCONTROLLER.GETCREATEDSINCEFORDRIVERSASYNC, HttpMethod.Post);
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
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ACTIVEEVENTSCONTROLLER.GETCREATEDSINCEFORDRIVERSASYNC, HttpMethod.Post);
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

		public CreatedSinceResult<ActiveEvent> GetCreatedSinceForGroups(List<long> groupIds, string entityType, string sinceToken, int quantity)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ACTIVEEVENTSCONTROLLER.GETCREATEDSINCEFORGROUPSASYNC, HttpMethod.Post);
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
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ACTIVEEVENTSCONTROLLER.GETCREATEDSINCEFORGROUPSASYNC, HttpMethod.Post);
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

	}
}
