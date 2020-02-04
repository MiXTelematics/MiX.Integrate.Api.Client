namespace MiX.Integrate.Shared.Entities.Trips
{
	public class TripClassification
	{
		/// <summary>
		/// Trip classification i.e. None , Business or Private
		/// </summary>
		public TripClassificationCategory Classification { get; set; }
		/// <summary>
		/// A comment regarding the trip classification
		/// </summary>
		public string Comment { get; set; }
	}
}
