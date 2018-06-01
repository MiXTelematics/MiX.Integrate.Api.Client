namespace MiX.Integrate.Shared.Entities.Journeys
{
	public class JourneyAssetExternalPassenger
	{
		public long JourneyAssetPassengerId { get; set; }
		public long JourneyId { get; set; }
		public long JourneyAssetId { get; set; }
		public long AssetId { get; set; }
		public string PassengerName { get; set; }
		public string MobileNumber { get; set; }
		public string Email { get; set; }
	}
}
