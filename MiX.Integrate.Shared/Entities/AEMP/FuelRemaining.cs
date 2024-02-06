using System;
using System.Xml.Serialization;

namespace MiX.Integrate.Shared.Entities.Aemp
{
	
	public class FuelRemaining
	{
		[XmlAttribute("dateTime")] public DateTime Datetime { get; set; }

		/// <example>46.8</example>
		[XmlElement] public float Percent { get; set; }

		/// <example>41</example>
		[XmlElement(ElementName = "FuelTankCapacity")] public uint? TankCapacity { get; set; }

		[XmlElement] public string FuelTankCapacityUnits { get; set; } = "litre";
	}
}
