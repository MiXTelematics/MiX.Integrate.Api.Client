using System.Net.Http;
using System.Threading.Tasks;
using MiX.Integrate.Api.Client;
using MiX.Integrate.Api.Client.Base;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.TimeApprovers;

namespace MiX.Integrate.API.Client
{
	public class TimeApproversClient : BaseClient, ITimeApproversClient
	{
		public TimeApproversClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public TimeApproversClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public bool Import(long organisationId, TimeApproverImport timeApproverImport)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.TIMEAPPROVERSCONTROLLER.IMPORT, HttpMethod.Post);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddJsonBody(timeApproverImport);
			IHttpRestResponse response = Execute(request);

			return (response.StatusCode == System.Net.HttpStatusCode.OK);
		}

		public async Task<bool> ImportAsync(long organisationId, TimeApproverImport timeApproverImport)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.TIMEAPPROVERSCONTROLLER.IMPORT, HttpMethod.Post);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddJsonBody(timeApproverImport);
			IHttpRestResponse response = await ExecuteAsync(request).ConfigureAwait(false);

			return (response.StatusCode == System.Net.HttpStatusCode.OK);
		}
	}
}