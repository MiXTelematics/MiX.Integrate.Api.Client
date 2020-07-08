namespace MiX.Integrate.Shared.Entities.DeviceCommands
{
	public enum MessageTransport : byte
	{
		None = 0,
		GSMDataCall = 1,
		GSMSMS = 2,
		GPRS = 3,
		WLAN = 9,
		SatComms = 10
	}
}