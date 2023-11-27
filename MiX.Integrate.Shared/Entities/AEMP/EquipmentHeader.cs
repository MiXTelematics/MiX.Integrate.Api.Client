using System;
using System.Xml.Serialization;

namespace MiX.Integrate.Shared.Entities.Aemp
{
	[XmlType(Namespace = "http://standards.iso.org/iso/15143/-3")]
	public class EquipmentHeader
	{
		// Telematics Unit Installation Date
		[XmlElement] public DateTime? UnitInstallDateTime { get; set; }

		// Equipment Make
		/// <example>FORD</example>
		[XmlElement] public string OEMName { get; set; }

		// Equipment Model
		/// <example>F-150</example>
		[XmlElement] public string Model { get; set; }

		// Equipment ID
		[XmlElement] public string EquipmentID { get; set; }

		// Serial Number
		[XmlElement] public string SerialNumber { get; set; }

		// OEM ISO Number (VIN)
		/// <example>1C3CCCAB8FN540394</example>
		[XmlElement] public string PIN { get; set; }
	}
}