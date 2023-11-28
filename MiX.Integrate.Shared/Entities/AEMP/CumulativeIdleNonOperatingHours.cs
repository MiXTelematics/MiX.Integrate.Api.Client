using System;
using System.Xml.Serialization;

namespace MiX.Integrate.Shared.Entities.Aemp
{
	
	public class CumulativeIdleNonOperatingHours
	{
		[XmlAttribute("dateTime")] public DateTime Datetime { get; set; }

		/// <example>7397.12</example>
		[XmlElement] public double Hour { get; set; }
	}
}
