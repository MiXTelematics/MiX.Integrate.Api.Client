using System;
using System.Xml.Serialization;

namespace MiX.Integrate.Shared.Entities.Aemp
{
	[XmlType(Namespace = "http://standards.iso.org/iso/15143/-3")]
	public class FuelUsed
	{
		/// <example>74</example>
		[XmlElement] public uint FuelConsumedLitres { get; set; }

		[XmlAttribute("dateTime")] public DateTime Datetime { get; set; }
	}
}
