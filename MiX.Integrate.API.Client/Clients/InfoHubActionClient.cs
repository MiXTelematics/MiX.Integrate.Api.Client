using MiX.Integrate.API.Client.Base;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Carriers;
using MiX.Integrate.Shared.Entities.InfoHub;

namespace MiX.Integrate.API.Client
{
	public class InfoHubActionClient : BaseClient, IInfoHubActionClient
	{
		public InfoHubActionClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public InfoHubActionClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public CreatedSinceResult<ActiveEventAction> GetActiveEventActionsCreatedSince(long organisationId, string sinceToken, int quantity)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.InfoHubActionsController.GETACTIONSCREATEDSINCE, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("sinceToken", sinceToken);
			request.AddUrlSegment("quantity", quantity.ToString());
			IHttpRestResponse<List<ActiveEventAction>> response =  Execute<List<ActiveEventAction>>(request);
			return new CreatedSinceResult<ActiveEventAction>()
			{
				HasMoreItems = bool.TryParse(GetResponseHeader(response.Headers, "HasMoreItems"), out bool hasMoreItems)
					? hasMoreItems
					: throw new Exception("Could not read the HasMoreItems header"),
				GetSinceToken = GetResponseHeader(response.Headers, "GetSinceToken"),
				Items = response.Data
			};
		}

		public async Task<CreatedSinceResult<ActiveEventAction>> GetActiveEventActionsCreatedSinceAsync(long organisationId, string sinceToken, int quantity)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.InfoHubActionsController.GETACTIONSCREATEDSINCE, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("sinceToken", sinceToken);
			request.AddUrlSegment("quantity", quantity.ToString());
			IHttpRestResponse<List<ActiveEventAction>> response = await ExecuteAsync<List<ActiveEventAction>>(request).ConfigureAwait(false);
			return new CreatedSinceResult<ActiveEventAction>()
			{
				HasMoreItems = bool.TryParse(GetResponseHeader(response.Headers, "HasMoreItems"), out bool hasMoreItems)
					? hasMoreItems
					: throw new Exception("Could not read the HasMoreItems header"),
				GetSinceToken = GetResponseHeader(response.Headers, "GetSinceToken"),
				Items = response.Data
			};
		}
	}
}
