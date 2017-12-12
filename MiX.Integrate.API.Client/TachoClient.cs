using System;
using MiX.Integrate.Shared.Constants;
using System.Threading.Tasks;
using MiX.Integrate.Api.Client.Base;
using System.Net.Http;
using MiX.Integrate.Shared.Entities.Tacho;
using System.Collections.Generic;
using System.Linq;

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

		public TachoData GetRangeForAssetPerSecond(long assetId, DateTime from, DateTime to)
		{
			TachoData tachoData = GetRangeForAsset(assetId, from, to);
			return ToPerSecondIntervals(tachoData);
		}

		public async Task<TachoData> GetRangeForAssetPerSecondAsync(long assetId, DateTime from, DateTime to)
		{
			TachoData tachoData = await GetRangeForAssetAsync(assetId, from, to).ConfigureAwait(false);
			return ToPerSecondIntervals(tachoData);
		}

		#region private methods

		private static TachoData ToPerSecondIntervals(TachoData inData)
		{
			if (inData == null) return null;
			TachoData outData = new TachoData()
			{
				ParameterDefinitions = inData.ParameterDefinitions
			};

			if (inData.Intervals != null)
			{
				outData.Intervals = new List<TachoInterval>();
				if (inData.Intervals.Count > 0)
				{
					TachoInterval lastInterval = null;
					foreach (TachoInterval interval in inData.Intervals.OrderBy(o => o.IntervalDateTime))
					{
						if (lastInterval != null)
						{
							while (lastInterval.IntervalDateTime < interval.IntervalDateTime.AddSeconds(-1))
							{
								lastInterval.IntervalDateTime = lastInterval.IntervalDateTime.AddSeconds(1);
								outData.Intervals.Add(new TachoInterval() { Data = lastInterval.Data, IntervalDateTime = lastInterval.IntervalDateTime });
							}
						}
						outData.Intervals.Add(new TachoInterval() { Data = interval.Data, IntervalDateTime = interval.IntervalDateTime });
						lastInterval = new TachoInterval() { Data = interval.Data, IntervalDateTime = interval.IntervalDateTime };
					}
				}
			}
			return outData;
		}

		#endregion

	}
}
