using System;
using MiX.Integrate.Shared.Entities.Positions;

namespace MiX.Integrate.Shared.Entities.Trips
{
	public class SubTrip
	{
		/// <summary>
		/// The date time of the start of the period monitored by the sub trip.
		/// </summary>
		public DateTime? SubTripStart { get; set; }
		/// <summary>
		/// Where the sub trip started.
		/// </summary>
		public Position StartPosition { get; set; }
		/// <summary>
		/// The date time when the asset started to move in the sub trip.
		/// </summary>
		public DateTime? Depart { get; set; }
		/// <summary>
		/// The date time when the asset last moved in the sub trip.
		/// </summary>
		public DateTime? Halt { get; set; }
		/// <summary>
		/// The date time of the end of the period monitored by the sub trip.
		/// </summary>
		public DateTime? SubTripEnd { get; set; }
		/// <summary>
		/// Where the sub trip ended.
		/// </summary>
		public Position EndPosition { get; set; }
		/// <summary>
		/// Time between Depart and Halt the asset was moving.
		/// </summary>
		public int DrivingTime { get; set; }
		/// <summary>
		/// Time before Depart and after Halt the asset was not moving.
		/// </summary>
		public int StandingTime { get; set; }
		/// <summary>
		/// Duration of the sub trip.
		/// </summary>
		public int Duration { get { return StandingTime + DrivingTime; } }
		/// <summary>
		/// Distance the asset moved in the sub trip.
		/// </summary>
		public decimal DistanceKilometres { get; set; }
		/// <summary>
		/// Odometer of the asset at the start of the sub trip.
		/// </summary>
		public decimal? StartOdometerKilometres { get; set; }
		/// <summary>
		/// Odometer of the asset at the end of the sub trip.
		/// </summary>
		public decimal? EndOdometerKilometres { get; set; }
		/// <summary>
		/// If monitored, the EngineHour reading at the start of the sub trip.
		/// </summary>
		public int? StartEngineSeconds { get; set; }
		/// <summary>
		/// If monitored, the EngineHour reading at the end of the sub trip.
		/// </summary>
		public int? EndEngineSeconds { get; set; }
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
		}

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

	}
}
