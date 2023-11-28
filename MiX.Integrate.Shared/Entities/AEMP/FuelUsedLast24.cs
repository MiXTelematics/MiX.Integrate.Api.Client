using System;
using System.Xml.Serialization;

namespace MiX.Integrate.Shared.Entities.Aemp
{
	
	public class FuelUsedLast24
	{
		[XmlAttribute("dateTime")] public DateTime Datetime { get; set; }

		/// <example>6</example>
		[XmlElement] public uint FuelConsumedLitres { get; set; }

	}
}
