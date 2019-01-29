using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Entities.TimeEntry;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public interface ITimeEntryClient : IBaseClient
	{
		bool ImportApprovers(long organisationId, TimeApproverImport timeApproverImport);
		Task<bool> ImportApproversAsync(long organisationId, TimeApproverImport timeApproverImport);
		Task<List<GroupSubstatus>> GetStatusCodes(long organisationId);
	}
}