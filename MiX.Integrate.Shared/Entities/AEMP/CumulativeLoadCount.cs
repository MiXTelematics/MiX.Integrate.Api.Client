using System;
using System.Xml.Serialization;

namespace MiX.Integrate.Shared.Entities.Aemp
{
	[XmlType(Namespace = "http://standards.iso.org/iso/15143/-3")]
	public class CumulativeLoadCount
	{
		/// <example>7013</example>
		[XmlElement] public int Count { get; set; }
		[XmlAttribute("dateTime")] public DateTime Datetime { get; set; }
	}
}
