using System;
using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.DeviceConfiguration
{
  public class MobileUnitDeviceConfiguration
  {
		public string AssetId { get; set; }
		public string ConfigurationGroup { get; set; }
		public string MobileDeviceType { get; set; }
		public DateTimeOffset LastChangeDate { get; set; }
		public List<MobileUnitDeviceConfigurationPeripheral> ConnectedPeripherals { get; set; }
		public List<MobileUnitDeviceConfigurationProperty> Properties { get; set; }
  }

  public class MobileUnitDeviceConfigurationPeripheral
  {
		public string Description { get; set; }
		public string Wire { get; set; }
		public List<MobileUnitDeviceConfigurationProperty> Properties { get; set; }
  }

  public class MobileUnitDeviceConfigurationProperty
  {
		public string Name { get; set; }
		public string Value { get; set; }
  }
}
