using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Entities.Assets;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
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
		long Add(Asset asset);
		Task<long> AddAsync(Asset asset);

		/// <summary>Gets <see cref="Trailer"/> assets for the specified organisation as an asynchronous operation</summary>
		/// <param name="organisationId">Identifies the organisation to be queried</param>
		/// <returns>A list of <see cref="Trailer"/> objects for the specified organisation</returns>
		List<Trailer> GetTrailers(long organisationId);

		/// <summary>Gets <see cref="Trailer"/> assets for the specified organisation as an asynchronous operation</summary>
		/// <param name="organisationId">Identifies the organisation to be queried</param>
		/// <returns>The task object representing the asynchronous operation</returns>
		Task<List<Trailer>> GetTrailersAsync(long organisationId);
	}
}
