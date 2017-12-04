using MiX.Integrate.Shared.Entities.DeviceConfiguration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public interface IDeviceConfigurationClient
	{
		Task<List<ConfigurationGroupDetail>> GetConnectedPeripheralsForAssetsAsync(long groupId, List<long> assetIds);
		List<ConfigurationGroupDetail> GetConnectedPeripheralsForAssets(long groupId, List<long> assetIds);
	}
}
