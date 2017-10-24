using MiX.Integrate.Api.Client.Base;
using MiX.Integrate.Shared.Entities.Reminders;
using System.Threading.Tasks;

namespace MiX.Integrate.Api.Client
{
	public interface IRemindersClient : IBaseClient
	{
		Task<AssetReminders> GetAssetRemindersAsync(long organisationId, long assetId);
	  AssetReminders GetAssetReminders(long organisationId, long assetId);
	}
}
