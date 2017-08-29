using System;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.CustomGroups;
using RestSharp;
using System.Collections.Generic;
using System.Linq; 
using System.Threading.Tasks;
using MiX.Integrate.Api.Client.Base;

namespace MiX.Integrate.Api.Client
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
      var request = GetRequest(APIControllerRoutes.CUSTOMGROUPSCONTROLLER.GETALLCUSTOMGROUPS, Method.GET);
      request.AddUrlSegment("organisationId:long", organisationId.ToString());
      var response = await ExecuteAsync<List<CustomGroup>>(request).ConfigureAwait(false);
      return response.Data;
    }

    /// <summary>Gets the details of a custom group</summary>
    /// <param name="organisationId"></param>
    /// <param name="customGroupId"></param>
    /// <returns></returns>
    public async Task<CustomGroupDetails> GetByIdAsync(long organisationId, long customGroupId)
    {
      var request = GetRequest(APIControllerRoutes.CUSTOMGROUPSCONTROLLER.GETCUSTOMGROUPBYID, Method.GET);
      request.AddUrlSegment("organisationId:long", organisationId.ToString());
      request.AddUrlSegment("customGroupId:long", customGroupId.ToString());
      var response = await ExecuteAsync<CustomGroupDetails>(request).ConfigureAwait(false);
      return response.Data;
    }

    /// <summary>Creates a new custom group</summary>
    /// <param name="organisationId"></param>
    /// <param name="customGroup"></param>
    /// <returns></returns>
    public async Task<long> AddCustomGroupAsync(long organisationId, CustomGroup customGroup)
    {
      var request = GetRequest(APIControllerRoutes.CUSTOMGROUPSCONTROLLER.ADDCUSTOMGROUP, Method.POST);
      request.AddUrlSegment("organisationId:long", organisationId.ToString());
      request.AddJsonBody(customGroup);
      var response = await ExecuteAsync(request).ConfigureAwait(false);
      var idHeaderVal = response.Headers.ToList().FirstOrDefault(h => h.Name.ToLowerInvariant().Equals("customgroupid"))
        ?.Value.ToString();
      long customGroupId;
      if (!long.TryParse(idHeaderVal, out customGroupId) || customGroupId==0)
        throw new Exception("Could not determine the id of the newly-created group");
      return customGroupId;
    }

    /// <summary>Updates the details of a custom group</summary>
    /// <param name="organisationId"></param>
    /// <param name="customGroup"></param>
    public async Task UpdateCustomGroupAsync(long organisationId, CustomGroup customGroup)
    {
      var request = GetRequest(APIControllerRoutes.CUSTOMGROUPSCONTROLLER.UPDATECUSTOMGROUP, Method.PUT);
      request.AddUrlSegment("organisationId:long", organisationId.ToString());
      request.AddJsonBody(customGroup);
      await ExecuteAsync(request).ConfigureAwait(false);
    }

    /// <summary>Adds members tp a custom groups</summary>
    /// <param name="organisationId"></param>
    /// <param name="customGroupId"></param>
    /// <param name="entityType"></param>
    /// <param name="entityIds"></param>
    public async Task AddMembersAsync(long organisationId, long customGroupId, string entityType, IEnumerable<long> entityIds)
    {
      var request = GetRequest(APIControllerRoutes.CUSTOMGROUPSCONTROLLER.ADDCUSTOMGROUPMEMBERS, Method.PUT);
      request.AddUrlSegment("organisationId:long", organisationId.ToString());
      request.AddUrlSegment("customGroupId:long", customGroupId.ToString());
      request.AddUrlSegment("entityType", entityType);
      request.AddJsonBody(entityIds);
      await ExecuteAsync(request).ConfigureAwait(false);
    }

    /// <summary>Removes members from a custom group</summary>
    /// <param name="organisationId"></param>
    /// <param name="customGroupId"></param>
    /// <param name="entityType"></param>
    /// <param name="entityIds"></param>
    public async Task RemoveMembersAsync(long organisationId, long customGroupId, string entityType, IEnumerable<long> entityIds)
    {
      var request = GetRequest(APIControllerRoutes.CUSTOMGROUPSCONTROLLER.DELETECUSTOMGROUPMEMBERS, Method.DELETE);
      request.AddUrlSegment("organisationId:long", organisationId.ToString());
      request.AddUrlSegment("customGroupId:long", customGroupId.ToString());
      request.AddUrlSegment("entityType", entityType);
      request.AddJsonBody(entityIds);
      await ExecuteAsync(request).ConfigureAwait(false);
    }

    /// <summary>Gets a list of the custom groups in an organisation</summary>
    /// <param name="organisationId"></param>
    /// <returns></returns>
    public IList<CustomGroup> GetAll(long organisationId)
    {
      return GetAllAsync(organisationId).Result;
    }

    /// <summary>Gets the details of a custom group</summary>
    /// <param name="organisationId"></param>
    /// <param name="customGroupId"></param>
    /// <returns></returns>
    public CustomGroupDetails GetById(long organisationId, long customGroupId)
    {
      return GetByIdAsync(organisationId, customGroupId).Result;
    }

    /// <summary>Creates a new custom group</summary>
    /// <param name="organisationId"></param>
    /// <param name="customGroup"></param>
    /// <returns></returns>
    public long AddCustomGroup(long organisationId, CustomGroup customGroup)
    {
      return AddCustomGroupAsync(organisationId, customGroup).Result;
    }

    /// <summary>Updates the details of a custom group</summary>
    /// <param name="organisationId"></param>
    /// <param name="customGroup"></param>
    /// <returns></returns>
    public void UpdateCustomGroup(long organisationId, CustomGroup customGroup)
    {
      UpdateCustomGroupAsync(organisationId, customGroup).GetAwaiter().GetResult();
    }
 
    /// <summary>Adds members tp a custom groups</summary>
    /// <param name="organisationId"></param>
    /// <param name="customGroupId"></param>
    /// <param name="entityType"></param>
    /// <param name="entityIds"></param>
    public void AddMembers(long organisationId, long customGroupId, string entityType, IEnumerable<long> entityIds)
    {
      AddMembersAsync(organisationId, customGroupId, entityType, entityIds).GetAwaiter().GetResult();
    }

    /// <summary>Removes members from a custom group</summary>
    /// <param name="organisationId"></param>
    /// <param name="customGroupId"></param>
    /// <param name="entityType"></param>
    /// <param name="entityIds"></param>
    public void RemoveMembers(long organisationId, long customGroupId, string entityType, IEnumerable<long> entityIds)
    {
      RemoveMembersAsync(organisationId, customGroupId, entityType, entityIds).GetAwaiter().GetResult();
    }
  }
}