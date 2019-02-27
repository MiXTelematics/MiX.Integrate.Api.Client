namespace MiX.Integrate.Shared.Entities.DeviceConfiguration
{
	public class MobileUnitCommunicationSettings
	{
		public long MobileUnitId { get; set; }
		public string GprsContext { get; set; }
		public string PinCode { get; set; }
		public string SMSNumber { get; set; }
		public string ModemInitialisationString { get; set; }
	}
}
