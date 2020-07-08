using System;
using System.Collections.Generic;
using MiX.Integrate.Shared.Entities.Positions;

namespace MiX.Integrate.Shared.Entities.Events
{
	/// <summary>
	/// Definition of a recorded Event.
	/// </summary>
	public class Event
	{
		/// <summary>
		/// Identifier for the Asset associated to this event.
		/// </summary>
		public Int64 AssetId { get; set; }

		/// <summary>
		/// Identifier for the Driver associated to this event.
		/// </summary>
		public long DriverId { get; set; }

		/// <summary>
		/// Unique identifier for this event.
		/// </summary>
		public long EventId { get; set; }

		/// <summary>
		/// The type of the event description
		/// </summary>
		public long EventTypeId { get; set; }

		/// <summary>
		/// category of the event: Detail, Summary, Notify or Terminal
		/// </summary>
		public string EventCategory { get; set; }

		/// <summary>
		/// The date and time at the start of the event. For a Summary category this is the start of the period being summarised.
		/// </summary>
		public DateTime? StartDateTime { get; set; }
		/// <summary>
		/// Odometer of the asset at the end of the trip.
		/// </summary>
		public decimal? StartOdometerKilometres { get; set; }
		/// <summary>
		/// Start position of the event.
		/// </summary>
		public Position StartPosition { get; set; }

		/// <summary>
		/// The date and time at the end of the event. For a Summary category this is the end of the period being summarised.
		/// </summary>
		public DateTime? EndDateTime { get; set; }
		/// <summary>
		/// Odometer of the asset at the end of the event.
		/// </summary>
		public decimal? EndOdometerKilometres { get; set; }
		/// <summary>
		/// End position of the event.
		/// </summary>
		public Position EndPosition { get; set; }

		/// <summary>
		/// The value recorded for the event.
		/// </summary>
		public double? Value { get; set; }

		/// <summary>The amount of fuel used, in litres, during the event</summary>
		public float? FuelUsedLitres { get; set; }

		/// <summary>
		/// The type of value recorded for the event, Minumum, Maximum, Average or current.
		/// </summary>
		public string ValueType { get; set; }
		/// <summary>
		/// The dispaly units from the event type definition
		/// </summary>
		public string ValueUnits { get; set; }

		/// <summary>
		/// The duration the event's condition was true.
		/// </summary>
		public int TotalTimeSeconds { get; set; }
		/// <summary>
		/// The number of occurances for the instance of the event. If the category is not Summary this will be 1.
		/// </summary>
		public int TotalOccurances { get; set; }

		/// <summary>
		/// URLs to media recorded with this event, if available.
		/// </summary>
		public IDictionary<string, string> MediaUrls { get; set; }

		/// <summary>
		/// The Location ID of a Location for this event, if available
		/// </summary>
		public long? LocationId { get; set; }

		/// <summary>
		/// The speed limit of the location event occured in
		/// </summary>
		public float? SpeedLimit { get; set; }
	}
}
