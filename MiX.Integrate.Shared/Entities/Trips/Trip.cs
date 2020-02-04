using System;
using System.Linq;
using System.Collections.Generic;
using MiX.Integrate.Shared.Entities.Positions;

namespace MiX.Integrate.Shared.Entities.Trips
{
	/// <summary>
	/// Definition of a Trip
	/// </summary>
	public class Trip
	{
		/// <summary>
		/// Initializes a new instance of the Trip c;ass.
		/// </summary>
		public Trip()
		{
			SubTrips = new List<Trips.SubTrip>();
		}

		public long TripId { get; set; }
		/// <summary>
		/// Identifier for the Asset associated to this trip.
		/// </summary>
		public Int64 AssetId { get; set; }
		/// <summary>
		/// Identifier for the Driver associated to this trip.
		/// </summary>
		public Int64 DriverId { get; set; }
		/// <summary>
		/// Date time the trip started.
		/// </summary>
		public DateTime TripStart { get; set; }
		/// <summary>
		/// Date time trip completed.
		/// </summary>
		public DateTime TripEnd { get; set; }

		/// <summary>
		/// Free text notes on the trip.
		/// </summary>
		public string Notes { get; set; }
		/// <summary>
		/// If connected, the name of the device configuration Parameter monitored by a pulse counting device connected to the mobile device int the asset.
		/// </summary>
		public string PulseParameterName { get; set; }

		/// <summary>
		/// a list of sub trip contained by the trip.
		/// </summary>
		public List<SubTrip> SubTrips { get; private set; }
		/// <summary>
		/// EngineHour difference between start and end of trip.
		/// </summary>
		public int? EngineSeconds
		{
			get
			{
				if (StartEngineSeconds.HasValue && EndEngineSeconds.HasValue)
					return EndEngineSeconds - StartEngineSeconds;
				else
					return null;
			}
			private set { }
		}

		#region parameters to be set from subtrips
		/// <summary>
		/// Start positionid of the first sub trip in the trip.
		/// </summary>
		public long? StartPositionId { get; set; }
		/// <summary>
		/// Start position of the first sub trip in the trip.
		/// </summary>
		public Position StartPosition { get; set; }
		/// <summary>
		/// End positionid of the last sub trip in the trip.
		/// </summary>
		public long? EndPositionId { get; set; }
		/// <summary>
		/// End position of the last sub trip in the trip.
		/// </summary>
		public Position EndPosition { get; set; }
		/// <summary>
		/// Date time of the first depart for the trip.
		/// </summary>  
		public DateTime? FirstDepart { get; set; }
		/// <summary>
		/// Date time of the last halt for the trip.
		/// </summary>
		public DateTime? LastHalt { get; set; }
		/// <summary>
		/// Time between Departs and Halts the asset was moving in the trip.
		/// </summary>
		public decimal DrivingTime { get; set; }
		/// <summary>
		/// Time before Depart and after Halt the asset was not moving.
		/// </summary>
		public decimal StandingTime { get; set; }
		/// <summary>
		/// Duration of the trip.
		/// </summary>
		public decimal Duration { get; set; }
		/// <summary>
		/// Total distance the asset moved in the trip.
		/// </summary>
		public decimal DistanceKilometers { get; set; }
		/// <summary>
		/// Odometer of the asset at the start of the trip.
		/// </summary>
		public decimal? StartOdometerKilometers { get; set; }
		/// <summary>
		/// Odometer of the asset at the end of the trip.
		/// </summary>
		public decimal? EndOdometerKilometers { get; set; }
		/// <summary>
		/// If monitored, the EngineHour reading at the start of the trip.
		/// </summary>
		public int? StartEngineSeconds { get; set; }
		/// <summary>
		/// If monitored, the EngineHour reading at the end of the sub trip.
		/// </summary>
		public int? EndEngineSeconds { get; set; }
		/// <summary>
		/// If the PulseParameterName is monitoring Fuel this value will be empty, otherwise this is the number of pulses received during the duration of sub trip.
		/// </summary>
		public float? PulseValue { get; set; }
		/// <summary>
		/// If the PulseParameterName is monitoring Fuel this value will the amount of fuel used for the duration of the sub trip, otherwise it will be empty.
		/// </summary>
		public float? FuelUsedLitres { get; set; }
		/// <summary>
		/// The maximum speed recored for the asset during the sub trip.
		/// </summary>
		public decimal MaxSpeedKilometersPerHour { get; set; }
		/// <summary>
		/// The maximum acceleration recored for the asset during the sub trip.
		/// </summary>
		public decimal MaxAccelerationKilometersPerHourPerSecond { get; set; }
		/// <summary>
		/// The maximum deceleration recored for the asset during the sub trip.
		/// </summary>
		public decimal MaxDecelerationKilometersPerHourPerSecond { get; set; }
		/// <summary>
		/// The maximum engine revolutions recored for the asset during the sub trip.
		/// </summary>
		public decimal MaxRpm { get; set; }
		/// <summary>
		/// Trip classification
		/// </summary>
		public TripClassification Classification { get; set; }
		#endregion
	}
}
