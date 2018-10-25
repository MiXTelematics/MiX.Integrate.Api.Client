using System;
using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.ServerSideEvents
{
	/// <summary>
	/// Contains the valid values for ServerSideEvent.EventRecordedFor
	/// </summary>
	public enum EventRecordedFor
	{
		Assets = 1,
		Drivers = 2,
		Both = 3
	}

	/// <summary>
	/// Contains the valid values for ServerSideEvent.EventType
	/// </summary>
	public enum EventType
	{
		LocationEnter = 1,
		LocationExit = 2
	}

	public class EntityList
	{
		public EntityList()
		{
			Ids = new List<long>();
		}

		public bool IsGroups { get; set; }
		public List<long> Ids { get; set; }
	}

	/// <summary>
	/// Abstract base class for server side events; use a inherited class.
	/// </summary>
	public abstract class ServerSideEventBase
	{
		public int ServerSideEventId { get; set; }
		public string Description { get; set; }

		/// <summary>
		/// cast EventRecordedFor enum to int for this value
		/// </summary>
		public int EventRecordedFor { get; set; }
		public bool RecurringEvent { get; set; }
		public DateTime ExpiryDate { get; set; }
		public EntityList AssetEntities { get; set; }
		public EntityList DriverEntities { get; set; }

		/// <summary>
		/// cast EventType enum to int for this value
		/// </summary>
		public int EventType { get; set; }
		public bool RecordEventBetweenTimes { get; set; }
		public DateTime RecordEventFrom { get; set; }
		public DateTime RecordEventTo { get; set; }
		public bool Mon { get; set; }
		public bool Tue { get; set; }
		public bool Wed { get; set; }
		public bool Thu { get; set; }
		public bool Fri { get; set; }
		public bool Sat { get; set; }
		public bool Sun { get; set; }

	}
}
