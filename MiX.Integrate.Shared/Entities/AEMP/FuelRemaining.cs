using System;
using System.Xml.Serialization;

namespace MiX.Integrate.Shared.Entities.Aemp
{
	[XmlType(Namespace = "http://standards.iso.org/iso/15143/-3")]
	public class FuelRemaining
	{
		/// <example>46.8</example>
		[XmlElement] public float Percent { get; set; }

		/// <example>41</example>
		[XmlElement] public uint? TankCapacity { get; set; }

		[XmlAttribute("dateTime")] public DateTime Datetime { get; set; }
	}
}
