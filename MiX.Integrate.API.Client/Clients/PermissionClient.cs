using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Permissions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	[Obsolete("This client is deprecated and will be removed in a future version - remove references to it from your code", false)]
	public class PermissionClient : BaseClient, IPermissionClient
	{
		public PermissionClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public PermissionClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		[Obsolete("This method is deprecated and will be removed in a future version", false)]
		public async Task<PermissionRefreshResult> RefreshResolvedPermissionsAsync()
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.PermissionController.REFRESHPERMISSIONS, HttpMethod.Get);
			IHttpRestResponse<PermissionRefreshResult> response = await ExecuteAsync<PermissionRefreshResult>(request).ConfigureAwait(false);
			return response.Data;
		}

		[Obsolete("This method is deprecated and will be removed in a future version", false)]
		public PermissionRefreshResult RefreshResolvedPermissions()
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.PermissionController.REFRESHPERMISSIONS, HttpMethod.Get);
			IHttpRestResponse<PermissionRefreshResult> response = Execute<PermissionRefreshResult>(request);
			return response.Data;
		}
	}
}
