using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.Events
{
	public class EventFilter
	{
		public List<long> EntityIds { get; set; }
		public List<long> EventTypeIds { get; set; }
	}
}
