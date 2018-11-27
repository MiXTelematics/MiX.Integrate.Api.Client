using System;
using System.Net.Http;
using System.Threading.Tasks;
using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Constants;

namespace MiX.Integrate.API.Client
{
	public class GlobalisationClient : BaseClient, IGlobalisationClient
	{
		public GlobalisationClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public GlobalisationClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		#if !NETSTANDARD1_6
		public TimeZoneInfo FindSystemTimeZoneById(string timeZoneId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.GlobalisationController.GETTIMEZONEINFOBYID, HttpMethod.Post);

			request.AddJsonBody(timeZoneId);

			IHttpRestResponse response = Execute(request);

			var timeZoneString = response.Content;
			return TimeZoneInfo.FromSerializedString(timeZoneString);
		}

		public async Task<TimeZoneInfo> FindSystemTimeZoneByIdAsync(string timeZoneId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.GlobalisationController.GETTIMEZONEINFOBYID, HttpMethod.Post);

			request.AddJsonBody(timeZoneId);

			IHttpRestResponse response = await ExecuteAsync(request).ConfigureAwait(false);

			var timeZoneString = response.Content;
			return TimeZoneInfo.FromSerializedString(timeZoneString);
		}
		#endif
	}
}
