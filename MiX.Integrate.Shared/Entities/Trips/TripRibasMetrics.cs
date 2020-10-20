using System;

namespace MiX.Integrate.Shared.Entities.Trips
{
	/// <summary>Encapsulates the RIBAS metrics of a trip</summary>
	public class TripRibasMetrics
	{

		/// <summary>Unique identifier of the trip</summary>
		public long TripId { get; set; }

		/// <summary>Identifies the asset associated with the trip</summary>
		public long AssetId { get; set; }

		/// <summary>Identifies the driver associated with the trip</summary>
		public long DriverId { get; set; }

		/// <summary>Date and time the trip started</summary>
		public DateTime TripStart { get; set; }

		/// <summary>Time, in seconds, spent driving</summary>
		public decimal DrivingTime { get; set; }

		/// <summary>Total duration, in seconds, of the trip</summary>
		public decimal Duration { get; set; }

		/// <summary>Total distance the asset moved in the trip</summary>
		public decimal DistanceKilometers { get; set; }

		/// <summary>Total over-speeding duration, in seconds</summary>
		public int? SpeedingTime{ get; set; }

		/// <summary>Total time, in seconds, that harsh braking occurred</summary>
    public int? HarshBrakeTime{ get; set; }

		/// <summary>Total time, in seconds, that harsh acceleration occurred</summary>
		public int? HarshAccelerationTime{ get; set; }
    
		/// <summary>Total time, in seconds, that over-revving occurred</summary>
		public int? OverRevTime{ get; set; }
    
		/// <summary>Total time, in seconds, that normal idling occurred</summary>
		public int? IdleTime{ get; set; } 
    
		/// <summary>Total time, in seconds, excessive idling occurred</summary>
		public int? ExcessiveIdleTime{ get; set; } 
    
		/// <summary>Total time, in seconds, spent out of green band</summary>
		public int? OutOfGreenBandTime{ get; set; }

		/// <summary>Number of times over-speeding occurred</summary>
    public int? SpeedingOccurs{ get; set; }

		/// <summary>Number of times harsh braking occurred</summary>
		public int? HarshBrakeOccurs{ get; set; }
    
		/// <summary>Number of times harsh acceleration occurred</summary>
		public int? HarshAccelerationOccurs{ get; set; } 
    
		/// <summary>Number of times over-revving occurred</summary>
		public int? OverRevOccurs{ get; set; }
    
		/// <summary>Number of times excessive idling occurred</summary>
		public int? ExcessiveIdleOccurs{ get; set; }

		/// <summary>Number of times idling occurred</summary>
		public int? IdleOccurs{ get; set; }

		/// <summary>Highest speed recorded during the trip</summary>
		public decimal MaxSpeedKilometersPerHour { get; set; }

		/// <summary>Maximum acceleration recorded during the trip</summary>
		public decimal MaxAccelerationKilometersPerHourPerSecond { get; set; }

		/// <summary>Maximum deceleration recorded during the trip</summary>
		public decimal MaxDecelerationKilometersPerHourPerSecond { get; set; }
		
		/// <summary>Highest engine RPM recorded during the trip</summary>
		public decimal MaxRpm { get; set; }

	}
}
