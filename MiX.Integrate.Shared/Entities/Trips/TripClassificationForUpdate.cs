namespace MiX.Integrate.Shared.Entities.Trips
{
	public class TripClassificationForUpdate
	{
		/// <summary>
		/// Trip classification i.e. Business or Private
		/// </summary>
		public TripClassificationUpdateCategory Classification { get; set; }
		/// <summary>
		/// A comment regarding the trip classification
		/// </summary>
		public string Comment { get; set; }
	}
}
