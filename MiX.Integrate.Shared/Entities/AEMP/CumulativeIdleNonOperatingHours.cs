using System;
using System.Xml.Serialization;

namespace MiX.Integrate.Shared.Entities.Aemp
{
	[XmlType(Namespace = "http://standards.iso.org/iso/15143/-3")]
	public class CumulativeIdleNonOperatingHours
	{
		/// <example>7397.12</example>
		[XmlElement] public double Hour { get; set; }
		[XmlAttribute("dateTime")] public DateTime Datetime { get; set; }
	}
}
