﻿using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.CustomGroups;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public class CustomGroupsClient : BaseClient, ICustomGroupsClient
	{

		public CustomGroupsClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public CustomGroupsClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		/// <summary>Gets a list of the custom groups in an organisation</summary>
		/// <param name="organisationId"></param>
		/// <returns></returns>
		public async Task<IList<CustomGroup>> GetAllAsync(long organisationId)
		{
			var request = GetRequest(APIControllerRoutes.CustomGroupsController.GETALLCUSTOMGROUPS, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			var response = await ExecuteAsync<List<CustomGroup>>(request).ConfigureAwait(false);
			return response.Data;
		}

		/// <summary>Gets a list of custom groups for an asset</summary>
		/// <param name="organisationId"></param>
		/// <param name="assetId"></param>
		/// <returns></returns>
		public async Task<IList<CustomGroup>> GetListForAssetAsync(long organisationId, long assetId)
		{
			var request = GetRequest(APIControllerRoutes.CustomGroupsController.GETCUSTOMGROUPSFORASSET, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("assetId", assetId.ToString());
			var response = await ExecuteAsync<List<CustomGroup>>(request).ConfigureAwait(false);
			return response.Data;
		}

		/// <summary>Gets a list of custom groups for a driver</summary>
		/// <param name="organisationId"></param>
		/// <param name="driverId"></param>
		/// <returns></returns>
		public async Task<IList<CustomGroup>> GetListForDriverAsync(long organisationId, long driverId)
		{
			var request = GetRequest(APIControllerRoutes.CustomGroupsController.GETCUSTOMGROUPSFORDRIVER, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("driverId", driverId.ToString());
			var response = await ExecuteAsync<List<CustomGroup>>(request).ConfigureAwait(false);
			return response.Data;
		}

		/// <summary>Gets the details of a custom group</summary>
		/// <param name="organisationId"></param>
		/// <param name="customGroupId"></param>
		/// <returns></returns>
		public async Task<CustomGroupDetails> GetByIdAsync(long organisationId, long customGroupId)
		{
			var request = GetRequest(APIControllerRoutes.CustomGroupsController.GETCUSTOMGROUPBYID, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("customGroupId", customGroupId.ToString());
			var response = await ExecuteAsync<CustomGroupDetails>(request).ConfigureAwait(false);
			return response.Data;
		}

		/// <summary>Creates a new custom group</summary>
		/// <param name="organisationId"></param>
		/// <param name="customGroup"></param>
		/// <returns></returns>
		public async Task<long> AddCustomGroupAsync(long organisationId, CustomGroup customGroup)
		{
			var request = GetRequest(APIControllerRoutes.CustomGroupsController.ADDCUSTOMGROUP, HttpMethod.Post);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddJsonBody(customGroup);
			var response = await ExecuteAsync(request).ConfigureAwait(false);
			var idHeaderVal = GetResponseHeader(response.Headers, "customgroupid");
			long customGroupId;
			if (!long.TryParse(idHeaderVal, out customGroupId) || customGroupId == 0)
				throw new Exception("Could not determine the id of the newly-created group");
			return customGroupId;
		}

		/// <summary>Updates the details of a custom group</summary>
		/// <param name="organisationId">Identifier of the organisation to which the custom group belongs</param>
		/// <param name="customGroup">The custom group to update</param>
		public async Task UpdateCustomGroupAsync(long organisationId, CustomGroup customGroup)
		{
			var request = GetRequest(APIControllerRoutes.CustomGroupsController.UPDATECUSTOMGROUP, HttpMethod.Put);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddJsonBody(customGroup);
			await ExecuteAsync(request).ConfigureAwait(false);
		}

		/// <summary>Deletes a custom group</summary>
		/// <param name="organisationId">Identifier of the organisation to which the custom group belongs</param>
		/// <param name="customGroupId">Identifier of the custom group to be deleted</param>
		public async Task DeleteCustomGroupAsync(long organisationId, long customGroupId)
		{
			var request = GetRequest(APIControllerRoutes.CustomGroupsController.DELETECUSTOMGROUP, HttpMethod.Delete);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("customGroupId", customGroupId.ToString());
			await ExecuteAsync(request).ConfigureAwait(false);
		}

		/// <summary>Adds members to a custom groups</summary>
		/// <param name="organisationId">Identifier of the organisation to which the custom group belongs</param>
		/// <param name="customGroupId">Identifier of the custom group to update</param>
		/// <param name="entityType">Type of the entities (Asset or Driver) to add</param>
		/// <param name="entityIds">Identifiers of the entities to add</param>
		public async Task AddMembersAsync(long organisationId, long customGroupId, string entityType, IEnumerable<long> entityIds)
		{
			var request = GetRequest(APIControllerRoutes.CustomGroupsController.ADDCUSTOMGROUPMEMBERS, HttpMethod.Put);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("customGroupId", customGroupId.ToString());
			request.AddUrlSegment("entityType", entityType);
			request.AddJsonBody(entityIds);
			await ExecuteAsync(request).ConfigureAwait(false);
		}

		/// <summary>Removes members from a custom group</summary>
		/// <param name="organisationId">Identifier of the organisation to which the custom group belongs</param>
		/// <param name="customGroupId">Identifier of the custom group to update</param>
		/// <param name="entityType">Type of the entities (Asset or Driver) to remove</param>
		/// <param name="entityIds">Identifiers of the entities to remove</param>
		public async Task RemoveMembersAsync(long organisationId, long customGroupId, string entityType, IEnumerable<long> entityIds)
		{
			var request = GetRequest(APIControllerRoutes.CustomGroupsController.DELETECUSTOMGROUPMEMBERS, HttpMethod.Delete);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("customGroupId", customGroupId.ToString());
			request.AddUrlSegment("entityType", entityType);
			request.AddJsonBody(entityIds);
			await ExecuteAsync(request).ConfigureAwait(false);
		}

		/// <summary>Gets a list of the custom groups in an organisation</summary>
		/// <param name="organisationId"></param>
		/// <returns></returns>
		public IList<CustomGroup> GetAll(long organisationId)
		{
			return GetAllAsync(organisationId).ConfigureAwait(false).GetAwaiter().GetResult(); 
		}

		/// <summary>Gets a list of custom groups for an asset</summary>
		/// <param name="organisationId">Identifier of the organisation thr asset belongs to</param>
		/// <param name="assetId">Identifier of the asset to query</param>
		/// <returns>A list containing the <see cref="CustomGroup"/>s of which the asset is a member</returns>
		public IList<CustomGroup> GetListForAsset(long organisationId, long assetId)
		{
			var request = GetRequest(APIControllerRoutes.CustomGroupsController.GETCUSTOMGROUPSFORASSET, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("assetId", assetId.ToString());
			var response = Execute<List<CustomGroup>>(request);
			return response.Data;
		}

		/// <summary>Gets a list of custom groups for a driver</summary>
		/// <param name="organisationId">Identifier of the organisation the driver belongs to</param>
		/// <param name="driverId">Identifier of the driver to query</param>
		/// <returns>A list containing the <see cref="CustomGroup"/>s of which the driver is a member</returns>
		public IList<CustomGroup> GetListForDriver(long organisationId, long driverId)
		{
			var request = GetRequest(APIControllerRoutes.CustomGroupsController.GETCUSTOMGROUPSFORDRIVER, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("driverId", driverId.ToString());
			var response = Execute<List<CustomGroup>>(request);
			return response.Data;
		}

		/// <summary>Gets the details of a custom group</summary>
		/// <param name="organisationId"></param>
		/// <param name="customGroupId"></param>
		/// <returns></returns>
		public CustomGroupDetails GetById(long organisationId, long customGroupId)
		{
			return GetByIdAsync(organisationId, customGroupId).ConfigureAwait(false).GetAwaiter().GetResult();
		}

		/// <summary>Creates a new custom group</summary>
		/// <param name="organisationId"></param>
		/// <param name="customGroup"></param>
		/// <returns></returns>
		public long AddCustomGroup(long organisationId, CustomGroup customGroup)
		{
			return AddCustomGroupAsync(organisationId, customGroup).ConfigureAwait(false).GetAwaiter().GetResult();
		}

		/// <summary>Updates the details of a custom group</summary>
		/// <param name="organisationId"></param>
		/// <param name="customGroup"></param>
		/// <returns></returns>
		public void UpdateCustomGroup(long organisationId, CustomGroup customGroup)
		{
			UpdateCustomGroupAsync(organisationId, customGroup).ConfigureAwait(false).GetAwaiter().GetResult();
		}
		/// <summary>Deletes a custom group</summary>
		/// <param name="organisationId">Identifier of the organisation to which the custom group belongs</param>
		/// <param name="customGroupId">Identifier of the custom group to delete</param>
		public void DeleteCustomGroup(long organisationId, long customGroupId)
		{
			DeleteCustomGroupAsync(organisationId, customGroupId).ConfigureAwait(false).GetAwaiter().GetResult();
		}

		/// <summary>Adds members to a custom groups</summary>
		/// <param name="organisationId">Identifier of the organisation to which the custom group belongs</param>
		/// <param name="customGroupId">Identifier of the custom group to update</param>
		/// <param name="entityType">Type of the entities (Asset or Driver) to add</param>
		/// <param name="entityIds">Identifiers of the entities to add</param>
		public void AddMembers(long organisationId, long customGroupId, string entityType, IEnumerable<long> entityIds)
		{
			AddMembersAsync(organisationId, customGroupId, entityType, entityIds).ConfigureAwait(false).GetAwaiter().GetResult();
		}

		/// <summary>Removes members from a custom group</summary>
		/// <param name="organisationId">Identifier of the organisation to which the custom group belongs</param>
		/// <param name="customGroupId">Identifier of the custom group to update</param>
		/// <param name="entityType">Type of the entities (Asset or Driver) to remove</param>
		/// <param name="entityIds">Identifiers of the entities to remove</param>
		public void RemoveMembers(long organisationId, long customGroupId, string entityType, IEnumerable<long> entityIds)
		{
			RemoveMembersAsync(organisationId, customGroupId, entityType, entityIds).ConfigureAwait(false).GetAwaiter().GetResult();
		}
	}
}