using System;
using System.Xml.Serialization;

namespace MiX.Integrate.Shared.Entities.Aemp
{
	[XmlType(Namespace = "http://standards.iso.org/iso/15143/-3")]
	public class Location
	{
		[XmlElement] public double Latitude { get; set; }
		[XmlElement] public double Longitude { get; set; }
		[XmlElement] public double? Altitude { get; set; }
		[XmlElement] public string AltitudeUnits { get; set; }
		[XmlAttribute("dateTime")] public DateTime Datetime { get; set; }
	}
}
