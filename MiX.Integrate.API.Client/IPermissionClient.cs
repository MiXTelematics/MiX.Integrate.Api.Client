using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Entities.Permissions;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public interface IPermissionClient : IBaseClient
	{
		/// <summary>
		/// Refresh the users resolved permission
		/// </summary>
		/// <param name="accountId"></param>
		/// <returns>A PermissionRefreshResult object to indicate the refresh status</returns>
		Task<PermissionRefreshResult> RefreshResolvedPermissionsAsync(long accountId);

		/// <summary>
		/// Refresh the users resolved permission
		/// </summary>
		/// <param name="accountId"></param>
		/// <returns>A PermissionRefreshResult object to indicate the refresh status</returns>
		PermissionRefreshResult RefreshResolvedPermissions(long accountId);
	}
}
