using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Groups;

using RestSharp;
using System.Threading.Tasks;

namespace MiX.Integrate.Api.Client
{
	public class GroupsClient : BaseClient, IGroupsClient
	{
		public GroupsClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public GroupsClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public GroupSummary GetSubGroups(long groupId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.GROUPSCONTROLLER.GETSUBGROUPS, Method.GET);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			IRestResponse<GroupSummary> response = Execute<GroupSummary>(request);
			return response.Data;
		}

		public async Task<GroupSummary> GetSubGroupsAsync(long groupId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.GROUPSCONTROLLER.GETSUBGROUPS, Method.GET);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			IRestResponse<GroupSummary> response = await ExecuteAsync<GroupSummary>(request);
			return response.Data;
		}

	}
}
