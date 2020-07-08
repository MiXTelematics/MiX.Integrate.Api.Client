namespace MiX.Integrate.Shared.Entities.Journeys
{
	public class JourneyAssetPassenger
	{
		public long JourneyAssetPassengerId { get; set; }
		public int JourneyAssetPassengerTypeKey { get; set; }
		public string JourneyAssetPassengerType { get; set; }
		public long JourneyAssetId { get; set; }
		public long AssetId { get; set; }
		public int PassengerCount { get; set; }
		public long PassengerId { get; set; }
		public string PassengerName { get; set; }
		public bool IsDeleted { get; set; }
	}
}
