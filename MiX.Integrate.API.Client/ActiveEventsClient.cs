using System;
using System.Collections.Generic;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Events;
using System.Threading.Tasks;
using MiX.Integrate.Api.Client.Base;
using System.Net.Http;

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
			request.AddUrlSegment("from", from.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToUniversalTime().ToString(DataFormats.DateTime_Format));
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
			request.AddUrlSegment("from", from.ToUniversalTime().ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToUniversalTime().ToString(DataFormats.DateTime_Format));
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
	}
}
