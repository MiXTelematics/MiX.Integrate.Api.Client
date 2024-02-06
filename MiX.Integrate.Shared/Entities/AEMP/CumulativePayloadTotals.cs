using System;
using System.Xml.Serialization;

namespace MiX.Integrate.Shared.Entities.Aemp
{
	
	public class CumulativePayloadTotals
	{
		[XmlAttribute("dateTime")] public DateTime Datetime { get; set; }

		/// <example>201.1</example>
		[XmlElement(ElementName="Payload")] public double PayloadKilograms { get; set; }

		[XmlElement] public string PayloadUnits { get; set; } = "kilogram";
	}
}
