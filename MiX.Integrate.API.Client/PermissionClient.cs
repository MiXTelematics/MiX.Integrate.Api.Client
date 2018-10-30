using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Permissions;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public class PermissionClient : BaseClient, IPermissionClient
	{
		public PermissionClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public PermissionClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }


		public async Task<PermissionRefreshResult> RefreshResolvedPermissionsAsync(long accountId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.PermissionController.REFRESHPERMISSIONS, HttpMethod.Get);
			request.AddUrlSegment("accountId", accountId.ToString());
			IHttpRestResponse<PermissionRefreshResult> response = await ExecuteAsync<PermissionRefreshResult>(request).ConfigureAwait(false);
			return response.Data;
		}

		public PermissionRefreshResult RefreshResolvedPermissions(long accountId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.PermissionController.REFRESHPERMISSIONS, HttpMethod.Get);
			request.AddUrlSegment("accountId", accountId.ToString());
			IHttpRestResponse<PermissionRefreshResult> response = Execute<PermissionRefreshResult>(request);
			return response.Data;
		}
	}
}
