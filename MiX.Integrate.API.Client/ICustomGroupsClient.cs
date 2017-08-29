using MiX.Integrate.Shared.Entities.CustomGroups;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiX.Integrate.Api.Client.Base;

namespace MiX.Integrate.Api.Client
{
  public interface ICustomGroupsClient : IBaseClient
	{
  #region async

	  Task<IList<CustomGroup>> GetAllAsync(long organisationId);
	  Task<CustomGroupDetails> GetByIdAsync(long organisationId, long customGroupId);

	  Task<long> AddCustomGroupAsync(long organisationId, CustomGroup customGroup);
	  Task UpdateCustomGroupAsync(long organisationId, CustomGroup customGroup);

	  Task AddMembersAsync(long organisationId, long customGroupId, string entityType, IEnumerable<long> entityIds);
	  Task RemoveMembersAsync(long organisationId, long customGroupId, string entityType, IEnumerable<long> entityIds);

    #endregion async

    #region sync

	  IList<CustomGroup> GetAll(long organisationId);
	  CustomGroupDetails GetById(long organisationId, long customGroupId);

	  long AddCustomGroup(long organisationId, CustomGroup customGroup);
	  void UpdateCustomGroup(long organisationId, CustomGroup customGroup);

	  void AddMembers(long organisationId, long customGroupId, string entityType, IEnumerable<long> entityIds);
	  void RemoveMembers(long organisationId, long customGroupId, string entityType, IEnumerable<long> entityIds);

    #endregion sync
  }
}
