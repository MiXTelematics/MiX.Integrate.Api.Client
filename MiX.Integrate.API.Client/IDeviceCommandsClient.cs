using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Entities.DeviceCommands;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public interface IDeviceCommandsClient : IBaseClient
	{

		Task<long> SendPositionRequestMessageAsync(long groupId, long assetId, MessageTransport? preferredTransport = null);
		Task<long> SendRelayCommandAsync(long groupId, long assetId, uint relayDrive, uint relayState, MessageTransport? preferredTransport = null);
		Task<long> SendTrackingRequestAsync(long groupId, long assetId, uint intervalSeconds, uint durationSeconds, MessageTransport? preferredTransport = null);
		Task<long> SendStopTrackingRequestAsync(long groupId, long assetId, MessageTransport? preferredTransport = null);
		Task<long> SendProgressiveShutdownCommandAsync(long groupId, long assetId, uint relayDrive, MessageTransport? preferredTransport = null);
		Task<long> SendDisarmUnitMessageAsync(long groupId, long assetId, MessageTransport? preferredTransport = null);
		Task<long> SendFreeTextMessageAsync(string message, long groupId, long assetId, MessageTransport? preferredTransport = null);
		Task<long> SendSetAcronymCommandAsync(long groupId, long assetId, uint? param1 = null, uint? param2 = null, uint? param3 = null, MessageTransport? preferredTransport = null);

		long SendPositionRequestMessage(long groupId, long assetId, MessageTransport? preferredTransport = null);
		long SendRelayCommand(long groupId, long assetId, uint relayDrive, uint relayState, MessageTransport? preferredTransport = null);
		long SendTrackingRequest(long groupId, long assetId, uint intervalSeconds, uint durationSeconds, MessageTransport? preferredTransport = null);
		long SendStopTrackingRequest(long groupId, long assetId, MessageTransport? preferredTransport = null);
		long SendProgressiveShutdownCommand(long groupId, long assetId, uint relayDrive, MessageTransport? preferredTransport = null);
		long SendDisarmUnitMessage(long groupId, long assetId, MessageTransport? preferredTransport = null);
		long SendFreeTextMessage(string message, long groupId, long assetId, MessageTransport? preferredTransport = null);
		long SendSetAcronymCommand(long groupId, long assetId, uint? param1 = null, uint? param2 = null, uint? param3 = null, MessageTransport? preferredTransport = null);

	}
}
