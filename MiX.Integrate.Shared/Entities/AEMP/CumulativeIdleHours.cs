using System;
using System.Xml.Serialization;

namespace MiX.Integrate.Shared.Entities.Aemp
{
	[XmlType(Namespace = "http://standards.iso.org/iso/15143/-3")]
	public class CumulativeIdleHours
	{
		/// <example>1003.89</example>
		[XmlElement] public float Hour { get; set; }
		[XmlAttribute("dateTime")] public DateTime Datetime { get; set; }
	}
}
