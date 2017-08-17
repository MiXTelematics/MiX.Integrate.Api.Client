using System;

namespace MiX.Integrate.Shared.Entities.Positions
{
	/// <summary>
	/// Defintion of a Position
	/// </summary>
	public class Position
	{
		/// <summary>
		/// Unique identifier for the position
		/// </summary>
		public long PositionId { get; set; }
		/// <summary>
		/// Identifier for the Asset associated to this position.
		/// </summary>
		public long AssetId { get; set; }
		/// <summary>
		/// Identifier for the Driver associated to this position.
		/// </summary>
		public long DriverId { get; set; }
		/// <summary>
		/// Date time the position was recorded in the asset.
		/// </summary>
		public DateTime Timestamp { get; set; }
		/// <summary>
		/// Latitude of the position.
		/// </summary>
		public double Latitude { get; set; }
		/// <summary>
		/// Longitude of the position.
		/// </summary>
		public double Longitude { get; set; }
		/// <summary>
		/// Velocity of the asset.
		/// </summary>
		public float? SpeedKilometresPerHour { get; set; }
		/// <summary>
		/// Altitude above sea level.
		/// </summary>
		public int? AltitudeMetres { get; set; }
		/// <summary>
		/// Heading in degress the asset was moving.
		/// </summary>
		public ushort? Heading { get; set; }
		/// <summary>
		/// Number of satellites that were used to determine the position
		/// </summary>
		public byte? NumberOfSatellites { get; set; }
		/// <summary>
		/// The horizontal dilution of precision of the measurement.
		/// </summary>
		public byte? Hdop { get; set; }
		/// <summary>
		/// The vertical dilution of precision of the measurement.
		/// </summary>
		public byte? Vdop { get; set; }
		/// <summary>
		/// The position dilution of precision of the measurement.
		/// </summary>
		public byte? Pdop { get; set; }
		/// <summary>
		/// Time since a valid measurement was received.
		/// </summary>
		public uint? AgeOfReadingSeconds { get; set; }
		/// <summary>
		/// Distance the asset has moved since a valid measurement was received.
		/// </summary>
		public ushort? DistanceSinceReadingKilometres { get; set; }
		/// <summary>
		/// Whether the ignition was seen to be on.
		/// </summary>
		public bool? IgnitionOn { get; set; }
		/// <summary>
		/// Odometer of the asset.
		/// </summary>
		public float? OdometerKilometres { get; set; }
		/// <summary>
		/// Optional address of 
		/// </summary>
		public string FormattedAddress { get; set; }
		/// <summary>
		/// How the position was taken
		///		0 - GPS
		/// </summary>
		public PositionSource? Source { get; set; }

		/// <summary>
		/// Initialises a new Position.
		/// </summary>
		public Position()
		{
		}

		/// <summary>
		/// Initialises a new Position.
		/// </summary>
		public Position(long positionId, long assetId, DateTime timestamp, double latitude, double longitude)
		{
			PositionId = positionId;
			AssetId = assetId;
			Timestamp = timestamp;
			Latitude = latitude;
			Longitude = longitude;
		}
	}
}
