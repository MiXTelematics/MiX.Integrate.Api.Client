namespace MiX.Integrate.Shared.Entities.Journeys
{
  // Current journey, status and route location details
  public class JourneyState
	{
		/// <summary>Identifier of the journey</summary>
		public long JourneyId { get; set; }

		 /// <summary>Base journey details</summary>
		public Journey Journey { get; set; }

		/// <summary>Journey route location details</summary>
		public JourneyRouteInfo RouteInfo { get; set; }

		/// <summary>Current status</summary>
		public JourneyInProgressCurrentStatus InProgressCurrentStatus { get; set; }

		/// <summary>Details of error(s) encountered retrieving journey state</summary>
		public string ErrorMessage { get; set; }
	}
}
