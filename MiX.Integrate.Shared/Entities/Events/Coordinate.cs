namespace MiX.Integrate.Shared.Entities.Events
{

	public class Coordinate
	{
		public double? Longitude { get; set; }

		public double? Latitude { get; set; }

		public Coordinate(double? longitude, double? latitude)
		{
			Longitude = longitude;
			Latitude = latitude;
		}

		public Coordinate()
		{
			Longitude = null;
			Latitude = null;
		}

		public bool ValidCoordinate()
		{
			return Latitude.HasValue && Longitude.HasValue;
		}
	}
}
