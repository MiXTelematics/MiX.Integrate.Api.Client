namespace MiX.Integrate.Shared.Entities.Tacho
{
	/// <summary>
	/// Parameter detail for tacho interval
	/// </summary>
	//[DebuggerDisplay("Key:{Key}=={Value}")]
	public class TachoParameterValue
	{
		/// <summary>
		/// <see cref="TachoParameterDefinition.Key"/> of parameter relating to the value.
		/// </summary>
		public byte Key { get; set; }

		/// <summary>
		/// Value of the parameter at time of containing interval
		/// </summary>
		public decimal Value { get; set; }
	}
}