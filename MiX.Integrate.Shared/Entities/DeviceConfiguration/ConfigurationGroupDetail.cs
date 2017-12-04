namespace MiX.Integrate.Shared.Entities.DeviceConfiguration
{
	public class ConfigurationGroupDetail
	{
		public ConfigurationGroupDetail() { }

		public long AssetId { get; set; }
		public long MobileUnitId { get; set; }
		public long ConfigurationGroupId { get; set; }
		public string ConfigurationGroupName { get; set; }
		public string WireName { get; set; }
		public int SortOrder { get; set; }
		public string WireIconPath { get; set; }
		public string Connection { get; set; }
		public bool IsOverridden { get; set; }
	}
}