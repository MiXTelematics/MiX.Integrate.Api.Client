using MiX.Integrate.Shared.Entities.Groups;
using System.Threading.Tasks;

namespace MiX.Integrate.Api.Client
{
	public interface IGroupsClient : IBaseClient
	{
		GroupSummary GetSubGroups(long groupId);
		Task<GroupSummary> GetSubGroupsAsync(long groupId);

	}
}
