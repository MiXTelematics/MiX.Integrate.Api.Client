using System.Xml.Serialization;

namespace MiX.Integrate.Shared.Entities.Aemp
{
	public class Link
	{
		/// <summary>relation</summary>
		/// <example>next</example>
		/// <example>prev</example>
		/// <example>first</example>
		/// <example>last</example>
		[XmlElement] public string rel { get; set; }

		/// <summary>Url of linked document</summary>
		/// <example>$APIROOT$/aemp/organisation/98709827345098107843/2</example>
		[XmlElement] public string href { get; set; }
	}
}