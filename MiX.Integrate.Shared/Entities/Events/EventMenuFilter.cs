using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.Events
{
	public class EventMenuFilter
	{
		public List<long> EntityIds { get; set; }
		public string MenuId { get; set; }
		public string MenuItemCode { get; set; }
	}
}
