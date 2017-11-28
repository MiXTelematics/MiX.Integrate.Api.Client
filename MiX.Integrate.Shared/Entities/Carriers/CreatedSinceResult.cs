using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.Carriers
{
	public sealed class CreatedSinceResult<T> where T : class
	{
		public bool HasMoreItems { get; set; }
		public string CreatedDateTime { get; set; }
		public List<T> Items { get; set; }
	}
}
