using System;
using System.Xml.Serialization;

namespace MiX.Integrate.Shared.Entities.Aemp
{
	
	public class FuelUsed
	{
		[XmlAttribute("dateTime")] public DateTime Datetime { get; set; }

		/// <example>74</example>
		[XmlElement(ElementName="FuelConsumed")] public uint FuelConsumedLitres { get; set; }
		[XmlElement] public string FuelUnits { get; set; } = "litres";
	}
}
