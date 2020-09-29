using System.Collections.Generic;
using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Entities.Reminders;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public interface IRemindersClient : IBaseClient
	{
		Task<AssetReminders> GetAssetRemindersAsync(long organisationId, long assetId);
		Task UpdateAssetLicenceReminderAsync(long organisationId, AssetLicenceReminder assetLicenceReminder);
		Task UpdateAssetServiceReminderAsync(long organisationId, AssetServiceReminder assetServiceReminder);
		Task UpdateAssetRoadworthyCertificateReminderAsync(long organisationId, AssetRoadworthyCertificateReminder assetRoadworthyCertificateReminder);
		Task<List<AssetServiceReminder>> GetAssetServiceRemindersAsync(long groupId);
		Task<List<AssetLicenceReminder>> GetAssetLicenceRemindersAsync(long groupId);
		Task<List<AssetRoadworthyCertificateReminder>> GetAssetRoadworthyCertificateRemindersAsync(long groupId);

		AssetReminders GetAssetReminders(long organisationId, long assetId);
		void UpdateAssetLicenceReminder(long organisationId, AssetLicenceReminder assetLicenceReminder);
		void UpdateAssetServiceReminder(long organisationId, AssetServiceReminder assetServiceReminder);
		void UpdateAssetRoadworthyCertificateReminder(long organisationId, AssetRoadworthyCertificateReminder assetRoadworthyCertificateReminder);
		List<AssetServiceReminder> GetAssetServiceReminders(long groupId);
		List<AssetLicenceReminder> GetAssetLicenceReminders(long groupId);
		List<AssetRoadworthyCertificateReminder> GetAssetRoadworthyCertificateReminders(long groupId);

	}
}
