using System.Threading.Tasks;
using MiX.Integrate.Api.Client.Base;
using MiX.Integrate.Shared.Entities.TimeApprovers;

namespace MiX.Integrate.API.Client
{
	public interface ITimeApproversClient : IBaseClient
	{
		bool Import(long groupId, TimeApproverImport timeApproverImport);
		Task<bool> ImportAsync(long groupId, TimeApproverImport timeApproverImport);
	}
}