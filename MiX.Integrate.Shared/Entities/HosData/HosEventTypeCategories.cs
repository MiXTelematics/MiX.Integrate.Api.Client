
using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.HosData
{
	public class HosEventTypeCategories
	{
		public HosEventTypeCategories()
		{
			EventTypes = new List<EventType> { };
		}

		public long Id { get; set; }
		public string Description { get; set; }
		public List<EventType> EventTypes { get; set; }
	}
}
