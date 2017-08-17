namespace MiX.Integrate.Shared.Entities.Journeys
{
	public class RouteLocation
	{
		public string RouteId { get; set; }
		public int RouteOrder { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public bool RestStop { get; set; }
		public bool FuelStop { get; set; }
		public bool LoadingStop { get; set; }
		public bool OffLoadingStop { get; set; }
		public int StopDuration { get; set; }
		public string ReverseGeo { get; set; }
		public string LocationId { get; set; }
		public string StopActivityInstructions { get; set; }

		/// <summary>
		/// Copies the entity.
		/// </summary>
		/// <returns></returns>
		public RouteLocation CopyEntity()
		{
			return (RouteLocation) this.MemberwiseClone();
		}
	}
}
