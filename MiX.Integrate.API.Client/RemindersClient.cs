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

	  public AssetReminders GetAssetReminders(long organisationId, long assetId)
    {
      IHttpRestRequest request = GetRequest(APIControllerRoutes.REMINDERSCONTROLLER.GETASSETREMINDERS, HttpMethod.Get);
	    request.AddUrlSegment("organisationId", organisationId.ToString());
	    request.AddUrlSegment("assetId", assetId.ToString());
      IHttpRestResponse<AssetReminders> response = Execute<AssetReminders>(request);
      return response.Data;
    }

	}
}
