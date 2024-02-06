using System.Xml.Serialization;


namespace MiX.Integrate.Shared.Entities.Aemp
{
	[XmlType(TypeName="Equipment")]
	public class EquipmentSnapshot
	{
		[XmlElement(Order = 10)] public EquipmentHeader EquipmentHeader { get; set; }
		[XmlElement(Order = 20, IsNullable = false)] public Location Location { get; set; }
		[XmlElement(Order = 30, IsNullable = false)] public CumulativeOperatingHours CumulativeOperatingHours { get; set; }
		[XmlElement(Order = 40, IsNullable = false)] public FuelUsed FuelUsed { get; set; }
		[XmlElement(Order = 50, IsNullable = false)] public FuelUsed FuelUsedLast24 { get; set; }
		[XmlElement(Order = 60, IsNullable = false)] public Distance Distance { get; set; }

		[XmlElement(Order = 110, IsNullable = false)] public CumulativeIdleHours CumulativeIdleHours { get; set; }
		[XmlElement(Order = 120, IsNullable = false)] public FuelRemaining FuelRemaining { get; set; }
		[XmlElement(Order = 130, IsNullable = false)] public DEFRemaining DEFRemaining { get; set; }
		[XmlElement(Order = 140, IsNullable = false)] public EngineStatus EngineStatus { get; set; }

		[XmlElement(Order = 210, IsNullable = false)] public CumulativePowerTakeOffHours CumulativePowerTakeOffHours { get; set; }
		[XmlElement(Order = 220, IsNullable = false)] public AverageLoadFactorLast24 AverageLoadFactorLast24 { get; set; }
		[XmlElement(Order = 230, IsNullable = false)] public CumulativeLoadCount CumulativeLoadCount { get; set; }
		[XmlElement(Order = 240, IsNullable = false)] public CumulativePayloadTotals CumulativePayloadTotals { get; set; }
		[XmlElement(Order = 250, IsNullable = false)] public CumulativeActiveRegenerationHours CumulativeActiveRegenerationHours { get; set; }
		[XmlElement(Order = 260, IsNullable = false)] public CumulativeIdleNonOperatingHours CumulativeIdleNonOperatingHours { get; set; }

	}
}
