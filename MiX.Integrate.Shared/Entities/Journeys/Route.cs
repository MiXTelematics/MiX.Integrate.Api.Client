using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.Journeys
{
	public class Route
	{
		public string RouteId { get; set; }
		public string SiteId { get; set; }
		public string RouteDescription { get; set; }
		public string StartLocation { get; set; }
		public string EndLocation { get; set; }
		public List<RouteLocation> RouteLocations { get; set; }
	}
}
