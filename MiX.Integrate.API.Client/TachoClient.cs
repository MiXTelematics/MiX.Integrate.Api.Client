using System;
using MiX.Integrate.Shared.Constants;
using System.Threading.Tasks;
using MiX.Integrate.Api.Client.Base;
using System.Net.Http;
using MiX.Integrate.Shared.Entities.Tacho;

namespace MiX.Integrate.Api.Client
{
	public class TachoClient : BaseClient, ITachoClient
	{
		public TachoClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public TachoClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public TachoData GetRangeForAsset(long assetId, DateTime from, DateTime to)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.TACHOCONTROLLER.GETRANGEFORASSETASYNC, HttpMethod.Get);
			request.AddUrlSegment("assetId", assetId.ToString());
			request.AddUrlSegment("from", from.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToString(DataFormats.DateTime_Format));
			IHttpRestResponse<TachoData> response = Execute<TachoData>(request);
			return response.Data;
		}

		public async Task<TachoData> GetRangeForAssetAsync(long assetId, DateTime from, DateTime to)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.TACHOCONTROLLER.GETRANGEFORASSETASYNC, HttpMethod.Get);
			request.AddUrlSegment("assetId", assetId.ToString());
			request.AddUrlSegment("from", from.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("to", to.ToString(DataFormats.DateTime_Format));
			IHttpRestResponse<TachoData> response = await ExecuteAsync<TachoData>(request).ConfigureAwait(false);
			return response.Data;
		}

	}
}
