using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Entities.Permissions;
using System;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	[Obsolete("This interface is deprecated and will be removed in a future version", false)]
	public interface IPermissionClient : IBaseClient
	{
		/// <summary>
		/// Refresh the users resolved permission
		/// </summary>
		/// <returns>A PermissionRefreshResult object to indicate the refresh status</returns>
		[Obsolete("This method is deprecated and will be removed in a future version", false)]
		Task<PermissionRefreshResult> RefreshResolvedPermissionsAsync();

		/// <summary>
		/// Refresh the users resolved permission
		/// </summary>
		/// <returns>A PermissionRefreshResult object to indicate the refresh status</returns>
		[Obsolete("This method is deprecated and will be removed in a future version", false)]
		PermissionRefreshResult RefreshResolvedPermissions();
	}
}
