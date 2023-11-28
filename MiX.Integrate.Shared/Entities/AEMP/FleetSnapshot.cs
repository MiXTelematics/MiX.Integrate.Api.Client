using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MiX.Integrate.Shared.Entities.Aemp
{
	[XmlType(TypeName = "Fleet")]
	public class FleetSnapshot
	{
		[XmlAttribute("snapshotTime")] public DateTime SnapshotTime { get; set; }

		[XmlAttribute("version")] public uint Version { get; set; }
		
		[XmlElement] public List<Link> Links { get;  set; }

		[XmlElement] public List<EquipmentSnapshot> Equipment { get; set; }
	}
}