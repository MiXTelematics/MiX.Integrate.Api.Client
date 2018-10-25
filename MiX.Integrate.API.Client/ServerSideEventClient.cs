using System.Net.Http;
using System.Threading.Tasks;
using MiX.Integrate.Api.Client.Base;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.ServerSideEvents;

namespace MiX.Integrate.API.Client
{
	public class ServerSideEventClient : BaseClient, IServerSideEventClient
	{
		public LocationBoundaryEvent AddLocationBoundaryEvent(string authToken, long organisationId,
			LocationBoundaryEvent eventModel)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.SERVERSIDEEVENTSCONTROLLER.LOCATIONBOUNDARYEVENT, HttpMethod.Post);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddJsonBody(eventModel);
			IHttpRestResponse<LocationBoundaryEvent> response = Execute<LocationBoundaryEvent>(request);
			return response.Data;
		}

		public async Task<LocationBoundaryEvent> AddLocationBoundaryEventAsync(string authToken, long organisationId, LocationBoundaryEvent eventModel)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.SERVERSIDEEVENTSCONTROLLER.LOCATIONBOUNDARYEVENT, HttpMethod.Post);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddJsonBody(eventModel);
			IHttpRestResponse<LocationBoundaryEvent> response = await ExecuteAsync<LocationBoundaryEvent>(request).ConfigureAwait(false);
			return response.Data;
		}
	}
}
