namespace MiX.Integrate.Shared.Entities.Locations
{
	/// <summary>
	/// Indicates the type of a shape.
	/// </summary>
	public enum ShapeType : byte
	{
		/// <summary>
		/// Point and radius (circle) shape type.
		/// </summary> 
		Circle = 0,

		/// <summary>
		/// Polygon shape type.
		/// </summary> 
		Polygon = 1,

		/// <summary>
		/// Rectangle shape type.
		/// </summary> 
		Rectangle = 2,

		/// <summary>
		/// Polyline shape type.
		/// </summary> 
		PolyLine = 3
	}
}
