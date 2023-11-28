using System;
using System.Xml.Serialization;

namespace MiX.Integrate.Shared.Entities.Aemp
{
	
	public class EquipmentHeader
	{
		// Telematics Unit Installation Date
		[XmlElement] public DateTime? UnitInstallDateTime { get; set; }

		// Equipment Make
		/// <example>FORD</example>
		[XmlElement(IsNullable = false)] public string OEMName { get; set; }

		// Equipment Model
		/// <example>F-150</example>
		[XmlElement(IsNullable = false)] public string Model { get; set; }

		// Equipment ID
		[XmlElement(IsNullable = false)] public string EquipmentID { get; set; }

		// Serial Number
		[XmlElement(IsNullable = false)] public string SerialNumber { get; set; }

		// OEM ISO Number (VIN)
		/// <example>1C3CCCAB8FN540394</example>
		[XmlElement(IsNullable = false)] public string PIN { get; set; }
	}
}