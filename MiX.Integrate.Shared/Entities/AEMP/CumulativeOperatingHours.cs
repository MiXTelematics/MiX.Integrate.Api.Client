using System;
using System.Xml.Serialization;

namespace MiX.Integrate.Shared.Entities.Aemp
{
	[XmlType(Namespace = "http://standards.iso.org/iso/15143/-3")]
	public class CumulativeOperatingHours
	{
		/// <example>42038.42</example>
		[XmlElement] public double Hour { get; set; }

		[XmlAttribute("dateTime")] public DateTime Datetime { get; set; }
	}
}
