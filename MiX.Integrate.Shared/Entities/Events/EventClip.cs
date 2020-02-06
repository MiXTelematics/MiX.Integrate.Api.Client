using System;
using System.Collections.Generic;
using System.Text;

namespace MiX.Integrate.Shared.Entities.Events
{
	public class EventClip
	{
		public long EventId { get; set; }
		public string MediaReference { get; set; }
		public long AssetId { get; set; }
	}
}
