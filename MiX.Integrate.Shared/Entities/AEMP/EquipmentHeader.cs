using System;
using System.Xml.Serialization;

namespace MiX.Integrate.Shared.Entities.Aemp
{
	[XmlType(Namespace = "http://standards.iso.org/iso/15143/-3")]
	public class EquipmentHeader
	{
		[XmlElement] public DateTime? UnitInstallDateTime { get; set; }
		[XmlElement] public string OemNane { get; set; }
		[XmlElement] public string Make { get; set; }
		[XmlElement] public string Model { get; set; }
		[XmlElement] public string EquipmentID { get; set; }
		[XmlElement] public string SerialNumber { get; set; }
	}
}