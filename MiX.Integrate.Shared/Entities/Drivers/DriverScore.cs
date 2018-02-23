namespace MiX.Integrate.Shared.Entities.Drivers
{
	public class DriverScore
	{
		public DriverScore() { }
		public long DriverId { get; set; }
		public decimal OverallScore { get; set; }
		public int Duration { get; set; }
		public decimal Distance { get; set; }
		public decimal OverSpeedingScore { get; set; }
		public decimal HarshBrakingScore { get; set; }
		public decimal HarshAccelerationScore { get; set; }
		public decimal OverRevvingScore { get; set; }
		public decimal OutOfGreenBandDrivingScore { get; set; }
		public decimal ExcessiveIdlingScore { get; set; }
	}
}
