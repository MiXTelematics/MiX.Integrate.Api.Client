using System;

namespace MiX.Integrate.Shared.Entities.Permissions
{
	public class PermissionRefreshResult
	{
		public bool Refreshed { get; set; }
		public string Message { get; set; }
		public DateTime NextAllowedUtcRefresh { get; set; }
	}
}
