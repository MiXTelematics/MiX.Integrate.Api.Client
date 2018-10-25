using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.ServerSideEvents
{
	/// <summary>
	/// Carrier for Location entered and Location left events
	/// </summary>
	public class LocationBoundaryEvent : ServerSideEventBase
	{
		public LocationBoundaryEvent()
		{

		}

		public LocationBoundaryEvent(bool isEntryEvent)
		{
			EventType = (int) ServerSideEvents.EventType.LocationExit;
			if (isEntryEvent)
			{
				EventType = (int)ServerSideEvents.EventType.LocationEnter;
			}

			Locations = new List<long>();
			AssetEntities = new EntityList();
			DriverEntities = new EntityList();
		}

		public List<long> Locations { get; set; }
	}
}
