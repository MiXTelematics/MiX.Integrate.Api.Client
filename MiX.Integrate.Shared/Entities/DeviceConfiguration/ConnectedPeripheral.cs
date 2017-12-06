namespace MiX.Integrate.Shared.Entities.DeviceConfiguration
{
	public class ConnectedPeripheral
	{
		public ConnectedPeripheral() { }

		public long AssetId { get; set; } 
		public string WireName { get; set; }  
		public string Connection { get; set; } 
	}
}