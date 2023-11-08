using System.Xml.Serialization;


namespace MiX.Integrate.Shared.Entities.Aemp
{
	[XmlType(Namespace = "http://standards.iso.org/iso/15143/-3")]
	public class EquipmentSnapshot
	{
		[XmlElement(Order = 10)] public EquipmentHeader EquipmentHeader { get; set; }
		[XmlElement(Order = 20)] public Location Location { get; set; }
		[XmlElement(Order = 30)] public CumulativeOperatingHours CumulativeOperatingHours { get; set; }
		[XmlElement(Order = 40)] public FuelUsed FuelUsed { get; set; }
		[XmlElement(Order = 50)] public FuelUsedLast24 FuelUsedLast24 { get; set; }
		[XmlElement(Order = 60)] public Distance Distance { get; set; }

		[XmlElement(Order = 110)] public CumulativeIdleHours CumulativeIdleHours { get; set; }
		[XmlElement(Order = 120)] public FuelRemaining FuelRemaining { get; set; }
		[XmlElement(Order = 130)] public DEFRemaining DEFRemaining { get; set; }
		[XmlElement(Order = 140)] public EngineStatus EngineStatus { get; set; }

		[XmlElement(Order = 210)] public CumulativePowerTakeOffHours CumulativePowerTakeOffHours { get; set; }
		[XmlElement(Order = 220)] public AverageLoadFactorLast24 AverageLoadFactorLast24 { get; set; }
		[XmlElement(Order = 230)] public CumulativeLoadCount CumulativeLoadCount { get; set; }
		[XmlElement(Order = 240)] public CumulativePayloadTotals CumulativePayloadTotals { get; set; }
		[XmlElement(Order = 250)] public CumulativeActiveRegenerationHours CumulativeActiveRegenerationHours { get; set; }
		[XmlElement(Order = 260)] public CumulativeIdleNonOperatingHours CumulativeIdleNonOperatingHours { get; set; }

	}
}
