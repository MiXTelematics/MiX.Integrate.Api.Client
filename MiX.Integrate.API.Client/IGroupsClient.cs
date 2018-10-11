using System.Collections.Generic;
using MiX.Integrate.Shared.Entities.Groups;
using System.Threading.Tasks;
using MiX.Integrate.Api.Client.Base;
using MiX.Integrate.Shared.Entities.Organisation;

namespace MiX.Integrate.Api.Client
{
	public interface IGroupsClient : IBaseClient
	{
		GroupSummary GetSubGroups(long groupId);
		Task<GroupSummary> GetSubGroupsAsync(long groupId);

		#region sync

		List<Group> GetAvailableOrganisations();
		long AddSite(long parentGroupId, string name);
		void DeleteSite(long groupId);
		long AddOrganisationSubGroup(long parentGroupId, string name);
		void DeleteOrganisationSubGroup(long groupId);
		void UpdateGroupName(long organisationGroupId, long groupId, string name);
		OrganisationDetail GetOrganisationDetail(long groupId);
		Group GetGroup(long groupId);
		Dictionary<long, int?> GetOrganisationSitesWithLegacyId(long groupId);

		#endregion sync

		#region async

		Task<List<Group>> GetAvailableOrganisationsAsync();
		Task<long> AddSiteAsync(long parentGroupId, string name);
		Task DeleteSiteAsync(long groupId);
		Task<long> AddOrganisationSubGroupAsync(long parentGroupId, string name);
		Task DeleteOrganisationSubGroupAsync(long groupId);
		Task UpdateGroupNameAsync(long organisationGroupId, long groupId, string name);
		Task<OrganisationDetail> GetOrganisationDetailAsync(long groupId);
		Task<Group> GetGroupAsync(long groupId);
		Task<Dictionary<long, int?>> GetOrganisationSitesWithLegacyIdAsync(long groupId);

		
		#endregion async
	}
}
