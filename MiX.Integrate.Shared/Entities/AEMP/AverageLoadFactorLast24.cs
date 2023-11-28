using System;
using System.Xml.Serialization;

namespace MiX.Integrate.Shared.Entities.Aemp
{
	
	public class AverageLoadFactorLast24
	{
		[XmlAttribute("dateTime")] public DateTime Datetime { get; set; }

		/// <example>77.2</example>
		[XmlElement] public float Percent { get; set; }
	}
}
