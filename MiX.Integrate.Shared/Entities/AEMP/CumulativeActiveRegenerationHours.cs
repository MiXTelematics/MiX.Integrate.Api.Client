using System;
using System.Xml.Serialization;

namespace MiX.Integrate.Shared.Entities.Aemp
{
	
	public class CumulativeActiveRegenerationHours
	{
		[XmlAttribute("dateTime")] public DateTime Datetime { get; set; }

		/// <example>17.52</example>
		[XmlElement] public double Hour { get; set; }
	}
}
