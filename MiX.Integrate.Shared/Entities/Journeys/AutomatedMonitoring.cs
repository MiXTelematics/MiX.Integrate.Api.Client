namespace MiX.Integrate.Shared.Entities.Journeys
{
	public class AutomatedMonitoring
	{
		public string JourneyId { get; set; }
		public string JourneyStatus { get; set; }
		public string TimeBasedStatus { get; set; }
		public string PositionBasedStatus { get; set; }
		public string OverdueUpdate { get; set; }
	}
}
