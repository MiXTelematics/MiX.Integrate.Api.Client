using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Entities.DeviceConfiguration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public interface IDeviceConfigurationClient : IBaseClient
	{
		Task<List<ConnectedPeripheral>> GetConnectedPeripheralsForAssetsAsync(long groupId, List<long> assetIds);
		List<ConnectedPeripheral> GetConnectedPeripheralsForAssets(long groupId, List<long> assetIds);
	}
}
