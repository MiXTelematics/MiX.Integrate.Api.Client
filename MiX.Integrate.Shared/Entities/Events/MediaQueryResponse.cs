using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.Events
{
	public class MediaQueryResponse : AssetMediaReference
	{
		public List<string> MediaUrls { get; set; }

		public List<string> ThumbnailUrls { get; set; }
	}
}