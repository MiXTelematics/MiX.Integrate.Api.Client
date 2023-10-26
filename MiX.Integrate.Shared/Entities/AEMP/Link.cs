using System.Xml.Serialization;

namespace MiX.Integrate.Shared.Entities.Aemp
{
	public class Link
	{
		[XmlElement] public string rel { get; set; }
		[XmlElement] public string href { get; set; }
	}
}