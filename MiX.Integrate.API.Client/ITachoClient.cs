using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Entities.Tacho;
using System;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public interface ITachoClient : IBaseClient
	{

		TachoData GetRangeForAsset(long assetId, DateTime from, DateTime to);
		Task<TachoData> GetRangeForAssetAsync(long assetId, DateTime from, DateTime to);

		TachoData GetRangeForAssetPerSecond(long assetId, DateTime from, DateTime to);
		Task<TachoData> GetRangeForAssetPerSecondAsync(long assetId, DateTime from, DateTime to);

	}
}
