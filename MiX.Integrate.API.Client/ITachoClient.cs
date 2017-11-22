using MiX.Integrate.Api.Client.Base;
using MiX.Integrate.Shared.Entities.Tacho;
using System;
using System.Threading.Tasks;

namespace MiX.Integrate.Api.Client
{
	public interface ITachoClient : IBaseClient
	{

		TachoData GetRangeForAsset(long assetId, DateTime from, DateTime to);
		Task<TachoData> GetRangeForAssetAsync(long assetId, DateTime from, DateTime to);

	}
}
