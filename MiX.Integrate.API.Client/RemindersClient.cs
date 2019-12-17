using System.Collections.Generic;
using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Reminders;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public class RemindersClient : BaseClient, IRemindersClient
	{
		public RemindersClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public RemindersClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

	  public async Task<AssetReminders> GetAssetRemindersAsync(long organisationId, long assetId)
    {
			IHttpRestRequest request = GetRequest(APIControllerRoutes.RemindersController.GETASSETREMINDERS, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
      request.AddUrlSegment("assetId", assetId.ToString());
			IHttpRestResponse<AssetReminders> response = await ExecuteAsync<AssetReminders>(request).ConfigureAwait(false);
			return response.Data;
		}

		public async Task UpdateAssetLicenceReminderAsync(long organisationId, AssetLicenceReminder assetLicenceReminder)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.RemindersController.ASSETLICENCEREMINDERS, HttpMethod.Put);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("assetId", assetLicenceReminder.AssetId.ToString());
			request.AddJsonBody(assetLicenceReminder);
			await ExecuteAsync(request).ConfigureAwait(false);
		}

		public async Task UpdateAssetServiceReminderAsync(long organisationId, AssetServiceReminder assetServiceReminder)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.RemindersController.ASSETSERVICEREMINDERS, HttpMethod.Put);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("assetId", assetServiceReminder.AssetId.ToString());
			request.AddJsonBody(assetServiceReminder);
			await ExecuteAsync(request).ConfigureAwait(false);
		}

		public async Task UpdateAssetRoadworthyCertificateReminderAsync(long organisationId, AssetRoadworthyCertificateReminder assetRoadworthyCertificateReminder)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.RemindersController.ASSETROADWORTHYREMINDERS, HttpMethod.Put);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("assetId", assetRoadworthyCertificateReminder.AssetId.ToString());
			request.AddJsonBody(assetRoadworthyCertificateReminder);
			await ExecuteAsync(request).ConfigureAwait(false);
		}

		/// <summary>Retrieves asset service reminders for assets in the specified group and its descendants.</summary>
		/// <param name="groupId">Identifies the <see cref="MiX.Integrate.Shared.Entities.Groups.Group">Group</see> to search,
		/// which must be an OrganisationGroup, OrganisationSubgroup, SubGroup, or DefaultSite.</param>
		public async Task<List<AssetServiceReminder>> GetAssetServiceRemindersAsync(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.RemindersController.GETASSETSERVICEREMINDERSFORGROUP, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			IHttpRestResponse<List<AssetServiceReminder>> response = await ExecuteAsync<List<AssetServiceReminder>>(request).ConfigureAwait(false);
			return response.Data;
		}

		/// <summary>Retrieves asset licence reminders for assets in the specified group and its descendants.</summary>
		/// <param name="groupId">Identifies the <see cref="MiX.Integrate.Shared.Entities.Groups.Group">Group</see> to search,
		/// which must be an OrganisationGroup, OrganisationSubgroup, SubGroup, or DefaultSite.</param>
		public async Task<List<AssetLicenceReminder>> GetAssetLicenceRemindersAsync(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.RemindersController.GETASSETLICENCEREMINDERSFORGROUP, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			IHttpRestResponse<List<AssetLicenceReminder>> response = await ExecuteAsync<List<AssetLicenceReminder>>(request).ConfigureAwait(false);
			return response.Data;
		}

		/// <summary>Retrieves asset roadworthy certificate reminders for assets in the specified group and its descendants.</summary>
		/// <param name="groupId">Identifies the <see cref="MiX.Integrate.Shared.Entities.Groups.Group">Group</see> to search,
		/// which must be an OrganisationGroup, OrganisationSubgroup, SubGroup, or DefaultSite.</param>
		public async Task<List<AssetRoadworthyCertificateReminder>> GetAssetRoadworthyCertificateRemindersAsync(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.RemindersController.GETASSETROADWORTHYREMINDERSFORGROUP, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			IHttpRestResponse<List<AssetRoadworthyCertificateReminder>> response = await ExecuteAsync<List<AssetRoadworthyCertificateReminder>>(request).ConfigureAwait(false);
			return response.Data;
		}


		public AssetReminders GetAssetReminders(long organisationId, long assetId)
    {
      IHttpRestRequest request = GetRequest(APIControllerRoutes.RemindersController.GETASSETREMINDERS, HttpMethod.Get);
	    request.AddUrlSegment("organisationId", organisationId.ToString());
	    request.AddUrlSegment("assetId", assetId.ToString());
      IHttpRestResponse<AssetReminders> response = Execute<AssetReminders>(request);
      return response.Data;
    }

		public void UpdateAssetLicenceReminder(long organisationId, AssetLicenceReminder assetLicenceReminder)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.RemindersController.ASSETLICENCEREMINDERS, HttpMethod.Put);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("assetId", assetLicenceReminder.AssetId.ToString());
			request.AddJsonBody(assetLicenceReminder);
			Execute(request);
		}

		public void UpdateAssetServiceReminder(long organisationId, AssetServiceReminder assetServiceReminder)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.RemindersController.ASSETSERVICEREMINDERS, HttpMethod.Put);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("assetId", assetServiceReminder.AssetId.ToString());
			request.AddJsonBody(assetServiceReminder);
			Execute(request);
		}

		public void UpdateAssetRoadworthyCertificateReminder(long organisationId, AssetRoadworthyCertificateReminder assetRoadworthyCertificateReminder)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.RemindersController.ASSETROADWORTHYREMINDERS, HttpMethod.Put);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("assetId", assetRoadworthyCertificateReminder.AssetId.ToString());
			request.AddJsonBody(assetRoadworthyCertificateReminder);
			Execute(request);
		}

		/// <summary>Retrieves asset service reminders for assets in the specified group and its descendants.</summary>
		/// <param name="groupId">Identifies the <see cref="MiX.Integrate.Shared.Entities.Groups.Group">Group</see> to search,
		/// which must be an OrganisationGroup, OrganisationSubgroup, SubGroup, or DefaultSite.</param>
		public List<AssetServiceReminder> GetAssetServiceReminders(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.RemindersController.GETASSETSERVICEREMINDERSFORGROUP, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			IHttpRestResponse<List<AssetServiceReminder>> response =  Execute<List<AssetServiceReminder>>(request);
			return response.Data;
		}

		/// <summary>Retrieves asset licence reminders for assets in the specified group and its descendants.</summary>
		/// <param name="groupId">Identifies the <see cref="MiX.Integrate.Shared.Entities.Groups.Group">Group</see> to search,
		/// which must be an OrganisationGroup, OrganisationSubgroup, SubGroup, or DefaultSite.</param>
		public List<AssetLicenceReminder> GetAssetLicenceReminders(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.RemindersController.GETASSETLICENCEREMINDERSFORGROUP, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			IHttpRestResponse<List<AssetLicenceReminder>> response = Execute<List<AssetLicenceReminder>>(request);
			return response.Data;
		}

		/// <summary>Retrieves asset roadworthy certificate reminders for assets in the specified group and its descendants.</summary>
		/// <param name="groupId">Identifies the <see cref="MiX.Integrate.Shared.Entities.Groups.Group">Group</see> to search,
		/// which must be an OrganisationGroup, OrganisationSubgroup, SubGroup, or DefaultSite.</param>
		public List<AssetRoadworthyCertificateReminder> GetAssetRoadworthyCertificateReminders(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.RemindersController.GETASSETROADWORTHYREMINDERSFORGROUP, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			IHttpRestResponse<List<AssetRoadworthyCertificateReminder>> response = Execute<List<AssetRoadworthyCertificateReminder>>(request);
			return response.Data;
		}
	}
}
