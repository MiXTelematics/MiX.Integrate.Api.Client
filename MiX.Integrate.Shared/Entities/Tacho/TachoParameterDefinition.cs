
namespace MiX.Integrate.Shared.Entities.Tacho
{
	/// <summary>
	/// Indexed parameter definition
	/// </summary>
	public class TachoParameterDefinition
	{
		/// <summary>
		/// Sequence key of the parameter
		/// </summary>
		public byte Key { get; set; }

		/// <summary>
		/// Periperhal device from which the data is recorded.
		/// </summary>
		public long DeviceId { get; set; }

		/// <summary>
		/// Device configuration ParameterId 
		/// </summary>
		public long ParameterId { get; set; }

		/// <summary>
		/// Name of the Mobile Device Line the parameter readings were taken from
		/// </summary>
		public string LineName { get; set; }

	}
}