using System.Threading.Tasks;
using MiX.Integrate.Api.Client.Base;
using MiX.Integrate.Shared.Entities.TimeEntry;

namespace MiX.Integrate.Api.Client
{
	public interface ITimeEntryClient : IBaseClient
	{
		bool ImportApprovers(long groupId, TimeApproverImport timeApproverImport);
		Task<bool> ImportApproversAsync(long groupId, TimeApproverImport timeApproverImport);
	}
}