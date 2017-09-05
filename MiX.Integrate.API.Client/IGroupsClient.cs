using MiX.Integrate.Shared.Entities.Groups;
using System.Threading.Tasks;
using MiX.Integrate.Api.Client.Base;

namespace MiX.Integrate.Api.Client
{
	public interface IGroupsClient : IBaseClient
	{
		GroupSummary GetSubGroups(long groupId);
		Task<GroupSummary> GetSubGroupsAsync(long groupId);

		#region sync

		long AddSite(long parentGroupId, string name);
		void DeleteSite(long groupId);
		long AddOrganisationSubGroup(long parentGroupId, string name);
		void DeleteOrganisationSubGroup(long groupId);
		void UpdateGroupName(long organisationGroupId, long groupId, string name);

		#endregion sync

		#region async

		Task<long> AddSiteAsync(long parentGroupId, string name);
		Task DeleteSiteAsync(long groupId);
		Task<long> AddOrganisationSubGroupAsync(long parentGroupId, string name);
		Task DeleteOrganisationSubGroupAsync(long groupId);
		Task UpdateGroupNameAsync(long organisationGroupId, long groupId, string name);

		#endregion async
	}
}
