﻿using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Groups;
using MiX.Integrate.Shared.Entities.Organisation;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public class GroupsClient : BaseClient, IGroupsClient
	{
		public GroupsClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public GroupsClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public List<Group> GetAvailableOrganisations()
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.GroupsController.GETORGGROUPS, HttpMethod.Get);
			IHttpRestResponse<List<Group>> response = Execute<List<Group>>(request);
			return response.Data;
		}

		public async Task<List<Group>> GetAvailableOrganisationsAsync()
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.GroupsController.GETORGGROUPS, HttpMethod.Get);
			IHttpRestResponse<List<Group>> response = await ExecuteAsync<List<Group>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public GroupSummary GetSubGroups(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.GroupsController.GETSUBGROUPS, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			IHttpRestResponse<GroupSummary> response = Execute<GroupSummary>(request);
			return response.Data;
		}

		public async Task<GroupSummary> GetSubGroupsAsync(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.GroupsController.GETSUBGROUPS, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			IHttpRestResponse<GroupSummary> response = await ExecuteAsync<GroupSummary>(request).ConfigureAwait(false);
			return response.Data;
		}

		public long AddSite(long parentGroupId, string name)
		{
			var request = GetRequest(APIControllerRoutes.GroupsController.ADDSITE, HttpMethod.Post);
			request.AddUrlSegment("parentGroupId", parentGroupId.ToString());
			request.AddJsonBody(name);
			IHttpRestResponse response = Execute(request);
			var idHeaderVal = GetResponseHeader(response.Headers, "groupid");
			long groupId;
			if (!long.TryParse(idHeaderVal, out groupId) || groupId == 0)
				throw new Exception("Could not determine the id of the newly-created site");
			return groupId;
		}

		public void DeleteSite(long groupId)
		{
			var request = GetRequest(APIControllerRoutes.GroupsController.DELETESITE, HttpMethod.Delete);
			request.AddUrlSegment("groupId", groupId.ToString());
			Execute(request);
		}

		public long AddOrganisationSubGroup(long parentGroupId, string name)
		{
			var request = GetRequest(APIControllerRoutes.GroupsController.ADDORGSUBGROUP, HttpMethod.Post);
			request.AddUrlSegment("parentGroupId", parentGroupId.ToString());
			request.AddJsonBody(name);
			IHttpRestResponse response = Execute(request);
			var idHeaderVal = GetResponseHeader(response.Headers, "groupid");
			long groupId;
			if (!long.TryParse(idHeaderVal, out groupId) || groupId == 0)
				throw new Exception("Could not determine the id of the newly-created group");
			return groupId;
		}

		public void DeleteOrganisationSubGroup(long groupId)
		{
			var request = GetRequest(APIControllerRoutes.GroupsController.DELETEORGSUBGROUP, HttpMethod.Delete);
			request.AddUrlSegment("groupId", groupId.ToString());
			Execute(request);
		}

		public void UpdateGroupName(long organisationGroupId, long groupId, string name)
		{
			var request = GetRequest(APIControllerRoutes.GroupsController.UPDATEGROUPNAME, HttpMethod.Put);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddJsonBody(name);
			Execute(request);
		}

		public async Task<long> AddSiteAsync(long parentGroupId, string name)
		{
			var request = GetRequest(APIControllerRoutes.GroupsController.ADDSITE, HttpMethod.Post);
			request.AddUrlSegment("parentGroupId", parentGroupId.ToString());
			request.AddJsonBody(name);
			IHttpRestResponse response = await ExecuteAsync(request).ConfigureAwait(false);
			var idHeaderVal = GetResponseHeader(response.Headers, "groupid");
			long groupId;
			if (!long.TryParse(idHeaderVal, out groupId) || groupId == 0)
				throw new Exception("Could not determine the id of the newly-created site");
			return groupId;
		}

		public async Task DeleteSiteAsync(long groupId)
		{
			var request = GetRequest(APIControllerRoutes.GroupsController.DELETESITE, HttpMethod.Delete);
			request.AddUrlSegment("groupId", groupId.ToString());
			await ExecuteAsync(request).ConfigureAwait(false);
		}

		public async Task<long> AddOrganisationSubGroupAsync(long parentGroupId, string name)
		{
			var request = GetRequest(APIControllerRoutes.GroupsController.ADDORGSUBGROUP, HttpMethod.Post);
			request.AddUrlSegment("parentGroupId", parentGroupId.ToString());
			request.AddJsonBody(name);
			IHttpRestResponse response = await ExecuteAsync(request).ConfigureAwait(false);
			var idHeaderVal = GetResponseHeader(response.Headers, "groupid");
			long groupId;
			if (!long.TryParse(idHeaderVal, out groupId) || groupId == 0)
				throw new Exception("Could not determine the id of the newly-created group");
			return groupId;
		}

		public async Task DeleteOrganisationSubGroupAsync(long groupId)
		{
			var request = GetRequest(APIControllerRoutes.GroupsController.DELETEORGSUBGROUP, HttpMethod.Delete);
			request.AddUrlSegment("groupId", groupId.ToString());
			await ExecuteAsync(request).ConfigureAwait(false);
		}

		public async Task UpdateGroupNameAsync(long organisationGroupId, long groupId, string name)
		{
			var request = GetRequest(APIControllerRoutes.GroupsController.UPDATEGROUPNAME, HttpMethod.Put);
			request.AddUrlSegment("organisationId", organisationGroupId.ToString());
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddJsonBody(name);
			await ExecuteAsync(request).ConfigureAwait(false);
		}

		public OrganisationDetail GetOrganisationDetail(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.GroupsController.GETORGANISATIONDETAILS, HttpMethod.Get);
			request.AddUrlSegment("organisationId", groupId.ToString());
			IHttpRestResponse<OrganisationDetail> response = Execute<OrganisationDetail>(request);
			return response.Data;
		}

		public async Task<OrganisationDetail> GetOrganisationDetailAsync(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.GroupsController.GETORGANISATIONDETAILS, HttpMethod.Get);
			request.AddUrlSegment("organisationId", groupId.ToString());
			IHttpRestResponse<OrganisationDetail> response = await ExecuteAsync<OrganisationDetail>(request).ConfigureAwait(false);
			return response.Data;
		}

		public Group GetGroup(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.GroupsController.GETGROUP, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			IHttpRestResponse<Group> response = Execute<Group>(request);
			return response.Data;
		}

		public async Task<Group> GetGroupAsync(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.GroupsController.GETGROUP, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			IHttpRestResponse<Group> response = await ExecuteAsync<Group>(request).ConfigureAwait(false);
			return response.Data;
		}

		public Dictionary<long, int?> GetOrganisationSitesWithLegacyId(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.GroupsController.GETORGANISATIONSITESWITHLEGACYID, HttpMethod.Get);
			request.AddUrlSegment("organisationId", groupId.ToString());

			IHttpRestResponse<Dictionary<long, int?>> response = Execute<Dictionary<long, int?>>(request);
			return response.Data;
		}
		
		public async Task<Dictionary<long, int?>> GetOrganisationSitesWithLegacyIdAsync(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.GroupsController.GETORGANISATIONSITESWITHLEGACYID, HttpMethod.Get);
			request.AddUrlSegment("organisationId", groupId.ToString());

			IHttpRestResponse<Dictionary<long, int?>> response = await ExecuteAsync<Dictionary<long, int?>>(request).ConfigureAwait(false);
			return response.Data;
		}

	}
}
