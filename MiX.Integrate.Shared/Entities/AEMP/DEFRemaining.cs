using System;
using System.Xml.Serialization;

namespace MiX.Integrate.Shared.Entities.Aemp
{
	[XmlType(Namespace = "http://standards.iso.org/iso/15143/-3")]
	public class DEFRemaining
	{
		/// <example>68.2</example>
		[XmlElement] public float Percent { get; set; }

		/// <example>27.8</example>
		[XmlElement] public float? TankCapacity { get; set; }
		[XmlAttribute("dateTime")] public DateTime Datetime { get; set; }
	}
}
