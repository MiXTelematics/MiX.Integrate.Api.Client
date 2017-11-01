using MiX.Integrate.Api.Client.Base;
using MiX.Integrate.Shared.Entities.Reminders;
using System.Threading.Tasks;

namespace MiX.Integrate.Api.Client
{
	public interface IRemindersClient : IBaseClient
	{
		Task<AssetReminders> GetAssetRemindersAsync(long organisationId, long assetId);
		Task UpdateAssetLicenceReminderAsync(long organisationId, AssetLicenceReminder assetLicenceReminder);
		Task UpdateAssetServiceReminderAsync(long organisationId, AssetServiceReminder assetServiceReminder);
		Task UpdateAssetRoadworthyCertificateReminderAsync(long organisationId, AssetRoadworthyCertificateReminder assetRoadworthyCertificateReminder);

		AssetReminders GetAssetReminders(long organisationId, long assetId);
		void UpdateAssetLicenceReminder(long organisationId, AssetLicenceReminder assetLicenceReminder);
		void UpdateAssetServiceReminder(long organisationId, AssetServiceReminder assetServiceReminder);
		void UpdateAssetRoadworthyCertificateReminder(long organisationId, AssetRoadworthyCertificateReminder assetRoadworthyCertificateReminder);
	}
}
