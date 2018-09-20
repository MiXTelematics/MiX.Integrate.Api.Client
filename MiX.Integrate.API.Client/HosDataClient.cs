using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MiX.Integrate.Api.Client;
using MiX.Integrate.Api.Client.Base;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Carriers;
using MiX.Integrate.Shared.Entities.HosData;

namespace MiX.Integrate.API.Client
{
	public class HosDataClient : BaseClient, IHosDataClient
	{
		public HosDataClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public HosDataClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public CreatedSinceResult<HosEvent> GetHosEventData(ParameterEntityType entityTypeId, List<long> entityIds, List<byte> eventTypeIds, DateTime fromDateTime, DateTime toDateTime)
		{
			var dataRequest = new HosEventDataRequest { EntityTypeId = entityTypeId, EntityIds = entityIds, EventTypeIds = eventTypeIds };

			IHttpRestRequest request = GetRequest(APIControllerRoutes.HOSDATACONTROLLER.GETHOSEVENTDATA, HttpMethod.Post);

			request.AddUrlSegment("from", fromDateTime.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDateTime.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(dataRequest);

			IHttpRestResponse<List<HosEvent>> response = Execute<List<HosEvent>>(request);

			var sHasMoreItems = GetResponseHeader(response.Headers, "HasMoreItems");
			var getSinceToken = GetResponseHeader(response.Headers, "GetSinceToken");

			if (!bool.TryParse(sHasMoreItems, out var hasMoreItems))
				throw new Exception("Could not read the HasMoreItems header");

			return new CreatedSinceResult<HosEvent> { HasMoreItems = hasMoreItems, GetSinceToken = getSinceToken, Items = response.Data };
		}

		public async Task<CreatedSinceResult<HosEvent>> GetHosEventDataAsync(ParameterEntityType entityTypeId, List<long> entityIds, List<byte> eventTypeIds, DateTime fromDateTime, DateTime toDateTime)
		{
			var dataRequest = new HosEventDataRequest { EntityTypeId = entityTypeId, EntityIds = entityIds, EventTypeIds = eventTypeIds };

			IHttpRestRequest request = GetRequest(APIControllerRoutes.HOSDATACONTROLLER.GETHOSEVENTDATA, HttpMethod.Post);

			request.AddUrlSegment("from", fromDateTime.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDateTime.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(dataRequest);

			IHttpRestResponse<List<HosEvent>> response = await ExecuteAsync<List<HosEvent>>(request).ConfigureAwait(false);

			var sHasMoreItems = GetResponseHeader(response.Headers, "HasMoreItems");
			var getSinceToken = GetResponseHeader(response.Headers, "GetSinceToken");

			if (!bool.TryParse(sHasMoreItems, out var hasMoreItems))
				throw new Exception("Could not read the HasMoreItems header");

			return new CreatedSinceResult<HosEvent> { HasMoreItems = hasMoreItems, GetSinceToken = getSinceToken, Items = response.Data };
		}

		public List<HosEventDriverSummary> GetHosEventDataSummary(ParameterEntityType entityTypeId, List<long> entityIds, List<byte> eventTypeIds, DateTime fromDateTime, DateTime toDateTime)
		{
			var dataRequest = new HosEventDataRequest { EntityTypeId = entityTypeId, EntityIds = entityIds, EventTypeIds = eventTypeIds };

			IHttpRestRequest request = GetRequest(APIControllerRoutes.HOSDATACONTROLLER.GETHOSEVENTDATASUMMARY, HttpMethod.Post);

			request.AddUrlSegment("from", fromDateTime.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDateTime.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(dataRequest);

			IHttpRestResponse<List<HosEventDriverSummary>> response = Execute<List<HosEventDriverSummary>>(request);

			return response.Data;
		}

		public async Task<List<HosEventDriverSummary>> GetHosEventDataSummaryAsync(ParameterEntityType entityTypeId, List<long> entityIds, List<byte> eventTypeIds, DateTime fromDateTime, DateTime toDateTime)
		{
			var dataRequest = new HosEventDataRequest { EntityTypeId = entityTypeId, EntityIds = entityIds, EventTypeIds = eventTypeIds };

			IHttpRestRequest request = GetRequest(APIControllerRoutes.HOSDATACONTROLLER.GETHOSEVENTDATASUMMARY, HttpMethod.Post);

			request.AddUrlSegment("from", fromDateTime.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDateTime.ToString(DataFormats.DateTime_Format));
			request.AddJsonBody(dataRequest);

			IHttpRestResponse<List<HosEventDriverSummary>> response = await ExecuteAsync<List<HosEventDriverSummary>>(request).ConfigureAwait(false);

			return response.Data;
		}
	}
}
