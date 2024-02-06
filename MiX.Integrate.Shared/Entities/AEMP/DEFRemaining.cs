using System;
using System.Xml.Serialization;

namespace MiX.Integrate.Shared.Entities.Aemp
{
	
	public class DEFRemaining
	{
		[XmlAttribute("dateTime")] public DateTime Datetime { get; set; }

		/// <example>68.2</example>
		[XmlElement] public float Percent { get; set; }

		/// <example>27.8</example>
		[XmlElement(ElementName = "DEFTankCapacity")] public float? TankCapacity { get; set; }

		[XmlElement] public string DEFTankCapacityUnits { get; set; } = "litre";

	}
}
