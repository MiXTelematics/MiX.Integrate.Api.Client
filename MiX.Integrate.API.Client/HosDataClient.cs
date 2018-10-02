using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MiX.Integrate.Api.Client;
using MiX.Integrate.Api.Client.Base;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.HosData;

namespace MiX.Integrate.API.Client
{
	public class HosDataClient : BaseClient, IHosDataClient
	{
		public HosDataClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public HosDataClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public List<HosViolation> GetHosViolations(long driverId, DateTime fromDateTime, DateTime toDateTime)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.HOSDATACONTROLLER.GETHOSVIOLATIONS, HttpMethod.Get);

			request.AddUrlSegment("driverId", driverId.ToString());
			request.AddUrlSegment("from", fromDateTime.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDateTime.ToString(DataFormats.DateTime_Format));

			IHttpRestResponse<List<HosViolation>> response = Execute<List<HosViolation>>(request);

			return response.Data;
		}

		public async Task<List<HosViolation>> GetHosViolationsAsync(long driverId, DateTime fromDateTime, DateTime toDateTime)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.HOSDATACONTROLLER.GETHOSVIOLATIONS, HttpMethod.Get);

			request.AddUrlSegment("driverId", driverId.ToString());
			request.AddUrlSegment("from", fromDateTime.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", toDateTime.ToString(DataFormats.DateTime_Format));

			IHttpRestResponse<List<HosViolation>> response = await ExecuteAsync<List<HosViolation>>(request).ConfigureAwait(false);

			return response.Data;
		}
	}
}
