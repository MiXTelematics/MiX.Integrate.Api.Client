using MiX.Integrate.Api.Client.Base;
using MiX.Integrate.Shared.Entities.Assets;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiX.Integrate.Api.Client
{
	public interface IAssetsClient : IBaseClient
	{

		List<Asset> GetAll(long groupId);
		Task<List<Asset>> GetAllAsync(long groupId);
		List<Asset> GetAll(long groupId, string filterType, string wildCard);
		Task<List<Asset>> GetAllAsync(long groupId, string filterType, string wildCard);
		Asset Get(long assetId);
		Task<Asset> GetAsync(long assetId);
		Asset GetByGroup(long groupId, long assetId);
		Task<Asset> GetByGroupAsync(long groupId, long assetId);
		void Update(Asset asset);
		Task UpdateAsync(Asset asset);
		bool AddAssetState(long groupId, AssetState assetState);
		Task<bool> AddAssetStateAsync(long groupId, AssetState assetState);

	}
}
