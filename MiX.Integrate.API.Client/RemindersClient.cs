using MiX.Integrate.Api.Client.Base;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Reminders;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiX.Integrate.Api.Client
{
	public class RemindersClient : BaseClient, IRemindersClient
	{
		public RemindersClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public RemindersClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

	  public async Task<AssetReminders> GetAssetRemindersAsync(long organisationId, long assetId)
    {
			IHttpRestRequest request = GetRequest(APIControllerRoutes.REMINDERSCONTROLLER.GETASSETREMINDERS, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
      request.AddUrlSegment("assetId", assetId.ToString());
			IHttpRestResponse<AssetReminders> response = await ExecuteAsync<AssetReminders>(request).ConfigureAwait(false);
			return response.Data;
		}

		public async Task UpdateAssetLicenceReminderAsync(long organisationId, AssetLicenceReminder assetLicenceReminder)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.REMINDERSCONTROLLER.ASSETLICENCEREMINDERS, HttpMethod.Put);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("assetId", assetLicenceReminder.AssetId.ToString());
			request.AddJsonBody(assetLicenceReminder);
			await ExecuteAsync(request).ConfigureAwait(false);
		}

		public async Task UpdateAssetServiceReminderAsync(long organisationId, AssetServiceReminder assetServiceReminder)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.REMINDERSCONTROLLER.ASSETSERVICEREMINDERS, HttpMethod.Put);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("assetId", assetServiceReminder.AssetId.ToString());
			request.AddJsonBody(assetServiceReminder);
			await ExecuteAsync(request).ConfigureAwait(false);
		}

		public async Task UpdateAssetRoadworthyCertificateReminderAsync(long organisationId, AssetRoadworthyCertificateReminder assetRoadworthyCertificateReminder)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.REMINDERSCONTROLLER.ASSETROADWORTHYREMINDERS, HttpMethod.Put);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("assetId", assetRoadworthyCertificateReminder.AssetId.ToString());
			request.AddJsonBody(assetRoadworthyCertificateReminder);
			await ExecuteAsync(request).ConfigureAwait(false);
		}


		public AssetReminders GetAssetReminders(long organisationId, long assetId)
    {
      IHttpRestRequest request = GetRequest(APIControllerRoutes.REMINDERSCONTROLLER.GETASSETREMINDERS, HttpMethod.Get);
	    request.AddUrlSegment("organisationId", organisationId.ToString());
	    request.AddUrlSegment("assetId", assetId.ToString());
      IHttpRestResponse<AssetReminders> response = Execute<AssetReminders>(request);
      return response.Data;
    }

		public void UpdateAssetLicenceReminder(long organisationId, AssetLicenceReminder assetLicenceReminder)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.REMINDERSCONTROLLER.ASSETLICENCEREMINDERS, HttpMethod.Put);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("assetId", assetLicenceReminder.AssetId.ToString());
			request.AddJsonBody(assetLicenceReminder);
			Execute(request);
		}

		public void UpdateAssetServiceReminder(long organisationId, AssetServiceReminder assetServiceReminder)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.REMINDERSCONTROLLER.ASSETSERVICEREMINDERS, HttpMethod.Put);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("assetId", assetServiceReminder.AssetId.ToString());
			request.AddJsonBody(assetServiceReminder);
			Execute(request);
		}

		public void UpdateAssetRoadworthyCertificateReminder(long organisationId, AssetRoadworthyCertificateReminder assetRoadworthyCertificateReminder)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.REMINDERSCONTROLLER.ASSETROADWORTHYREMINDERS, HttpMethod.Put);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("assetId", assetRoadworthyCertificateReminder.AssetId.ToString());
			request.AddJsonBody(assetRoadworthyCertificateReminder);
			Execute(request);
		}
	}
}
