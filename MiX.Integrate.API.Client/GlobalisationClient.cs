using System;
using System.Net.Http;
using System.Threading.Tasks;
using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Globalisation;

namespace MiX.Integrate.API.Client
{
	public class GlobalisationClient : BaseClient, IGlobalisationClient
	{
		public TimeZoneInfo FindSystemTimeZoneById(string timeZoneId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.GlobalisationController.GETTIMEZONEINFOBYID, HttpMethod.Get);

			request.AddUrlSegment("timeZoneId", timeZoneId);

			IHttpRestResponse<TimeZoneInfoResult> response = Execute<TimeZoneInfoResult>(request);

			return response.Data.TimeZoneInfo;
		}

		public async Task<TimeZoneInfo> FindSystemTimeZoneByIdAsync(string timeZoneId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.GlobalisationController.GETTIMEZONEINFOBYID, HttpMethod.Get);

			request.AddUrlSegment("timeZoneId", timeZoneId);

			IHttpRestResponse<TimeZoneInfoResult> response = await ExecuteAsync<TimeZoneInfoResult>(request).ConfigureAwait(false);

			return response.Data.TimeZoneInfo;
		}
	}
}
