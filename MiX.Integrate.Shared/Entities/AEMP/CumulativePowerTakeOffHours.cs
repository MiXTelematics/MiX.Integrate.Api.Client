using System;
using System.Xml.Serialization;

namespace MiX.Integrate.Shared.Entities.Aemp
{
	
	public class CumulativePowerTakeOffHours
	{
		[XmlAttribute("dateTime")] public DateTime Datetime { get; set; }

		/// <example>917.18</example>
		[XmlElement] public double Hour { get; set; }
	}
}
