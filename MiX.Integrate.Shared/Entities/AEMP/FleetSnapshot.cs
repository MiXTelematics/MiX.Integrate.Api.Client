using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MiX.Integrate.Shared.Entities.Aemp
{
	[XmlType(Namespace = "http://standards.iso.org/iso/15143/-3", TypeName = "Fleet")]
	public class FleetSnapshot
	{
		[XmlElement] public List<Link> Links { get;  set; }

		[XmlElement] public List<EquipmentSnapshot> Equipment { get; set; }

		[XmlAttribute("version")] public uint Version { get; set; }

		[XmlAttribute("snapshotTime")] public DateTime SnapshotTime { get; set; }
	}
}