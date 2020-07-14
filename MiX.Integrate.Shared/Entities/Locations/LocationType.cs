namespace MiX.Integrate.Shared.Entities.Locations
{
	/// <summary>
	/// Indicates the type of a location.
	/// </summary>
	public enum LocationType : byte
	{
		/// <summary>
		/// Customer location type.
		/// </summary> 
		Customer = 1,

		/// <summary>
		/// No-go Zone location type.
		/// </summary> 
		NoGoZone = 2,

		/// <summary>
		/// Site location type.
		/// </summary> 
		Site = 3,

		/// <summary>
		/// Other location type.
		/// </summary> 
		Other = 4,

		/// <summary>
		/// Street PolyLine location type.
		/// </summary> 
		StreetPolyLine = 5,

		/// <summary>
		/// Route PolyLine location type.
		/// </summary> 
		RoutePolyLine = 6,

		/// <summary>
		/// Fuel stop location type.
		/// </summary> 
		FuelStop = 7,

		/// <summary>
		/// Rest stop location type.
		/// </summary> 
		RestStop = 8,

		/// <summary>
		/// Speed zone location type.
		/// </summary> 
		SpeedZone = 9,

		/// <summary>
		/// Business location type.
		/// </summary> 
		Business = 10,

		/// <summary>
		/// Private location type.
		/// </summary> 
		Private = 12,

		/// <summary>
		/// UnClassified location type.
		/// </summary> 
		UnClassified = 14
	}
}
