using System;
using System.Xml.Serialization;

namespace MiX.Integrate.Shared.Entities.Aemp
{
	public class Location
	{
		[XmlAttribute("dateTime")] public DateTime Datetime { get; set; }

		/// <example>16.927989342</example>
		[XmlElement] public double Latitude { get; set; }

		/// <example>-124.40205794</example>
		[XmlElement] public double Longitude { get; set; }

		/// <example>742</example>
		[XmlElement] public double? Altitude { get; set; }

		/// <example>Metres</example>
		[XmlElement] public string AltitudeUnits { get; set; }
	}
}
