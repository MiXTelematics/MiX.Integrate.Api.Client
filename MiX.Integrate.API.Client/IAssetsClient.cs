using System.Collections.Generic; 
using MiX.Integrate.Shared.Entities.Assets;
using System.Threading.Tasks;
using MiX.Integrate.Api.Client.Base;

namespace MiX.Integrate.Api.Client
{
	public interface IAssetsClient : IBaseClient
	{

		List<Asset> GetAll(long groupId);
		Task<List<Asset>> GetAllAsync(long groupId);
		Asset Get(long assetId);
		Task<Asset> GetAsync(long assetId);
		Asset GetByGroup(long groupId, long assetId);
		Task<Asset> GetByGroupAsync(long groupId, long assetId);
		void Update(Asset asset);
		Task UpdateAsync(Asset asset);

	}
}
