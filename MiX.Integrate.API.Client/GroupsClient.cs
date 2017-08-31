using System;
using System.Linq;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Groups;
using System.Threading.Tasks;
using MiX.Integrate.Api.Client.Base;
using MiX.Integrate.API.Client.Base;
using System.Net.Http;

namespace MiX.Integrate.Api.Client
{
	public class GroupsClient : BaseClient, IGroupsClient
	{
		public GroupsClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public GroupsClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public GroupSummary GetSubGroups(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.GROUPSCONTROLLER.GETSUBGROUPS, HttpMethod.Get);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			IHttpRestResponse<GroupSummary> response = Execute<GroupSummary>(request);
			return response.Data;
		}

		public async Task<GroupSummary> GetSubGroupsAsync(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.GROUPSCONTROLLER.GETSUBGROUPS, HttpMethod.Get);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			IHttpRestResponse<GroupSummary> response = await ExecuteAsync<GroupSummary>(request);
			return response.Data;
		}


		public long AddSite(long parentGroupId, string name)
		{
			var request = GetRequest(APIControllerRoutes.GROUPSCONTROLLER.ADDSITE, HttpMethod.Post);
			request.AddUrlSegment("parentGroupId", parentGroupId.ToString());
			request.AddJsonBody(name);
			IHttpRestResponse response = Execute(request);
			var idHeaderVal = GetResponseHeader(response.Headers, "groupid");
			long groupId;
			if (!long.TryParse(idHeaderVal, out groupId) || groupId == 0)
				throw new Exception("Could not determine the id of the newly-created site");
			return groupId;
		}

		public long AddOrganisationSubGroup(long parentGroupId, string name)
		{
			var request = GetRequest(APIControllerRoutes.GROUPSCONTROLLER.ADDORGSUBGROUP, HttpMethod.Post);
			request.AddUrlSegment("parentGroupId", parentGroupId.ToString());
			request.AddJsonBody(name);
			IHttpRestResponse response = Execute(request);
			var idHeaderVal = GetResponseHeader(response.Headers, "groupid");
			long groupId;
			if (!long.TryParse(idHeaderVal, out groupId) || groupId == 0)
				throw new Exception("Could not determine the id of the newly-created group");
			return groupId;
		}

		public void UpdateGroupName(long organisationGroupId, long groupId, string name)
		{
			var request = GetRequest(APIControllerRoutes.GROUPSCONTROLLER.UPDATEGROUPNAME, HttpMethod.Put);
			request.AddUrlSegment("organisationGroupId", organisationGroupId.ToString());
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddJsonBody(name);
			Execute(request);
		}

		public async Task<long> AddSiteAsync(long parentGroupId, string name)
		{
			var request = GetRequest(APIControllerRoutes.GROUPSCONTROLLER.ADDSITE, HttpMethod.Post);
			request.AddUrlSegment("parentGroupId", parentGroupId.ToString());
			request.AddJsonBody(name);
			IHttpRestResponse response = await ExecuteAsync(request);
			var idHeaderVal = GetResponseHeader(response.Headers, "groupid");
			long groupId;
			if (!long.TryParse(idHeaderVal, out groupId) || groupId == 0)
				throw new Exception("Could not determine the id of the newly-created site");
			return groupId;
		}

		public async Task<long> AddOrganisationSubGroupAsync(long parentGroupId, string name)
		{
			var request = GetRequest(APIControllerRoutes.GROUPSCONTROLLER.ADDORGSUBGROUP, HttpMethod.Post);
			request.AddUrlSegment("parentGroupId", parentGroupId.ToString());
			request.AddJsonBody(name);
			IHttpRestResponse response = await ExecuteAsync(request).ConfigureAwait(false);
			var idHeaderVal = GetResponseHeader(response.Headers, "groupid");
			long groupId;
			if (!long.TryParse(idHeaderVal, out groupId) || groupId == 0)
				throw new Exception("Could not determine the id of the newly-created group");
			return groupId;
		}

		public async Task UpdateGroupNameAsync(long organisationGroupId, long groupId, string name)
		{
			var request = GetRequest(APIControllerRoutes.GROUPSCONTROLLER.UPDATEGROUPNAME, HttpMethod.Put);
			request.AddUrlSegment("organisationGroupId", organisationGroupId.ToString());
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddJsonBody(name);
			await ExecuteAsync(request).ConfigureAwait(false);
		}
	}
}
