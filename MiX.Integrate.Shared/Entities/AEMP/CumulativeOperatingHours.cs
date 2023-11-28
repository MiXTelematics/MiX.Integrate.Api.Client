using System;
using System.Xml.Serialization;

namespace MiX.Integrate.Shared.Entities.Aemp
{
	
	public class CumulativeOperatingHours
	{
		[XmlAttribute("dateTime")] public DateTime Datetime { get; set; }

		/// <example>42038.42</example>
		[XmlElement] public double Hour { get; set; }

	}
}
