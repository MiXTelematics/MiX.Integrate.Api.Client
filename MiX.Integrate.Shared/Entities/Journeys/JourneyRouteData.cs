

namespace MiX.Integrate.Shared.Entities.Journeys
{
	/// <summary>Represents the turn-by-turn instructions in JSON format for a journey's route</summary>
	public class JourneyRouteData
	{
		public long JourneyId { get; set; }
		public string RouteId { get; set; }
		public string RouteData { get; set; }

		public JourneyRouteData()
		{
			JourneyId = 0;
			RouteData = null;
			RouteId = null;
		}
	}
}