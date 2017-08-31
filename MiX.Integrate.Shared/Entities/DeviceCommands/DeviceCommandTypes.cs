using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiX.Integrate.Shared.Entities.DeviceCommands
{
	public enum DeviceCommandTypes
	{
		SendDisarmUnitMessage,
		SendFreeTextMessage,
		SendPositionRequestMessage,
		SendProgressiveShutdownCommand,
		SendRelayCommand,
		SendStopTrackingRequest,
		SendTrackingRequest,
		SendSetAcronymCommand
	}
}
