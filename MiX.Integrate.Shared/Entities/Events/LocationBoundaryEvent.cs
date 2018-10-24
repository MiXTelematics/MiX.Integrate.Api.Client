using System;
using System.Collections.Generic;
using System.Text;

namespace MiX.Integrate.Shared.Entities.Events
{
	/// <summary>
	/// Carrier for Location entered and Location left events
	/// </summary>
	[Serializable]
	public class LocationBoundaryEvent : ServerSideEventBase
	{
		public List<long> Locations { get; set; }
	}
}
