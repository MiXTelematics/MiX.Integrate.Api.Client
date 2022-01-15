using System;
using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.Tacho
{
	/// <summary>
	/// Definition of Interval for Tacho
	/// </summary>
	//[DebuggerDisplay("{IntervalDateTime}")]
	public class TachoInterval
	{
		/// <summary>
		/// UTC timestamp for interval
		/// </summary>
		public DateTime IntervalDateTime { get; set; }
		/// <summary>
		/// collection of <see cref="TachoParameterValue"/>
		/// </summary>
		public List<TachoParameterValue> Data { get; set; }

	}
}