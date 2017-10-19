namespace MiX.Integrate.Shared.Entities.Locations
{
	public class ProximityQueryResult
	{
		public double DistanceTo { get; set; }
		public double Bearing { get; set; }
		public string CardinalDirection { get; set; }
		public Location Location { get; set; }
	}
}
