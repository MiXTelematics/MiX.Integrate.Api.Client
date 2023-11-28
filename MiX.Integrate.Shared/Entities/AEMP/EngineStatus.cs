using System;
using System.Xml.Serialization;

namespace MiX.Integrate.Shared.Entities.Aemp
{
	
	public class EngineStatus
	{
		[XmlAttribute("dateTime")] public DateTime Datetime { get; set; }

		/// <example>18WVJ90831</example>
		[XmlElement] public string EngineNumber { get; set; }

		[XmlElement] public bool Running { get; set; }
	}
}
