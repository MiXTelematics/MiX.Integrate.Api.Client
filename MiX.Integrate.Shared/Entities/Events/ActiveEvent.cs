using System;
using MiX.Integrate.Shared.Entities.Positions;

namespace MiX.Integrate.Shared.Entities.Events
{
	/// <summary>Definition of an active event (event notification)</summary>
	public class ActiveEvent
	{
		/// <summary>Identifier for the Asset associated with the active event</summary>
		public Int64 AssetId { get; set; }

		/// <summary>Identifier for the Driver associated with the active event</summary>
		public long DriverId { get; set; }

		/// <summary>Unique identifier for the active event</summary>
		public long EventId { get; set; }

		/// <summary>The type of the event description</summary>
		public long EventTypeId { get; set; }

		/// <summary>The priority assigned to the event notification</summary>
		public byte Priority { get; set; }

		/// <summary>The armed/disarmed state of the unit when the event occurred</summary>
		public bool Armed { get; set; }

		/// <summary>The date and time at which the event occurred</summary>
		public DateTime EventDateTime { get; set; }

		/// <summary>The date and time at which the event was received by the comms system</summary>
		public DateTime? ReceivedDateTime { get; set; }

		/// <summary>Odometer of the asset at the time the event occurred</summary>
		public decimal? OdometerKilometres { get; set; }

		/// <summary>GPS position of the active event</summary>
		public Position Position { get; set; }

		/// <summary>The value recorded for the event</summary>
		public double? Value { get; set; }

		/// <summary>The type of value recorded for the event: Minumum, Maximum, Average or Current</summary>
		public string ValueType { get; set; }

		/// <summary>The display units from the event type definition</summary>
		public string ValueUnits { get; set; }

		/// <summary>
		/// The speed limit of the location event occured in
		/// </summary>
		public float? SpeedLimit { get; set; }
	}
}

