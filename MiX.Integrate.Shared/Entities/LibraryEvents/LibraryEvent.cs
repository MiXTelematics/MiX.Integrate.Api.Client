using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiX.Integrate.Shared.Entities.LibraryEvents
{
	/// <summary>Describes a library event</summary>
	public class LibraryEvent
	{
		public LibraryEvent()
		{
		}

		public string Description { get; set; }
		public long EventTypeId { get; set; }
		public string EventType { get; set; }
		public string DisplayUnits { get; set; }
		public string FormatType { get; set; }
		public string ValueName { get; set; }
	}
}
