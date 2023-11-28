using System;
using System.Xml.Serialization;

namespace MiX.Integrate.Shared.Entities.Aemp
{
	
	public class CumulativeLoadCount
	{
		[XmlAttribute("dateTime")] public DateTime Datetime { get; set; }

		/// <example>7013</example>
		[XmlElement] public int Count { get; set; }
	}
}
