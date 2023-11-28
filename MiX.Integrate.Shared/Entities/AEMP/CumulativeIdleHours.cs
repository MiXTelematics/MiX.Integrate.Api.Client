using System;
using System.Xml.Serialization;

namespace MiX.Integrate.Shared.Entities.Aemp
{
	
	public class CumulativeIdleHours
	{
		[XmlAttribute("dateTime")] public DateTime Datetime { get; set; }

		/// <example>1003.89</example>
		[XmlElement] public float Hour { get; set; }
	}
}
