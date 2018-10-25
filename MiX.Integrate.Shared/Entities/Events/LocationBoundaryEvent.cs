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
		private LocationBoundaryEvent()
		{}

		public LocationBoundaryEvent(bool isEntryEvent)
		{
			EventType = (int) Events.EventType.LocationExit;
			if (isEntryEvent)
			{
				EventType = (int)Events.EventType.LocationEnter;
			}

			Locations = new List<long>();
			AssetEntities = new EntityList();
			DriverEntities = new EntityList();
		}

		public List<long> Locations { get; set; }
	}
}
