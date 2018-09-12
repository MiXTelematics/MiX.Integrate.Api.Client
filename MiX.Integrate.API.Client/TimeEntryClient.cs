using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MiX.Integrate.Api.Client.Base;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.TimeEntry;

namespace MiX.Integrate.Api.Client
{
	public class TimeEntryClient : BaseClient, ITimeEntryClient
	{
		public TimeEntryClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public TimeEntryClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public bool ImportApprovers(long organisationId, TimeApproverImport timeApproverImport)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.TIMEENTRYCONTROLLER.IMPORTAPPROVERS, HttpMethod.Post);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddJsonBody(timeApproverImport);
			IHttpRestResponse response = Execute(request);

			return (response.StatusCode == System.Net.HttpStatusCode.OK);
		}

		public async Task<bool> ImportApproversAsync(long organisationId, TimeApproverImport timeApproverImport)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.TIMEENTRYCONTROLLER.IMPORTAPPROVERS, HttpMethod.Post);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddJsonBody(timeApproverImport);
			IHttpRestResponse response = await ExecuteAsync(request).ConfigureAwait(false);

			return (response.StatusCode == System.Net.HttpStatusCode.OK);
		}
		public async Task<List<GroupSubstatus>> GetStatusCodes(long organisationId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.TIMEENTRYCONTROLLER.GETSTATUSCODES, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			IHttpRestResponse<List<GroupSubstatus>> response = await ExecuteAsync<List<GroupSubstatus>>(request).ConfigureAwait(false);
			return response.Data;
		}
	}
}