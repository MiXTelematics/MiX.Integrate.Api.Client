using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.Carriers
{
	public sealed class PagedResult<T> where T : class
	{
		public bool HasMoreItems { get; set; }
		public string NextTimestamp { get; set; }
		public List<T> Items { get; set; }
	}
}
