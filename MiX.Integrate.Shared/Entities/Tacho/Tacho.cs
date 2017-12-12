using System;
using System.Collections.Generic;
using System.Linq;

namespace MiX.Integrate.Shared.Entities.Tacho
{
	/// <summary>
	/// Definition of recorded TachoData
	/// </summary>
	public class TachoData
	{
		public TachoData()
		{
			ParameterDefinitions = new List<TachoParameterDefinition>();
			Intervals = new List<TachoInterval>();
		}

		/// <summary>
		/// <see cref="MiX.Integrate.Shared.Entities.Assets.Asset.AssetId"/> for which tacho data was recorded
		/// </summary>
		public long AssetId { get; set; }

		/// <summary>
		/// first interval's datetime in the collection
		/// </summary>
		public DateTime? StartDateTime
		{
			get
			{
				return Intervals?.OrderBy(x => x.IntervalDateTime)?.FirstOrDefault()?.IntervalDateTime;
			}
			private set { }
		}

		/// <summary>
		/// last interval's datetime in the collection
		/// </summary>
		public DateTime? EndDateTime
		{
			get
			{
				return Intervals?.OrderByDescending(x => x.IntervalDateTime)?.FirstOrDefault()?.IntervalDateTime;
			}
			private set { }
		}

		/// <summary>
		/// List of <see cref="TachoParameterDefinition"/> for <see cref="TachoParameterValue"/>s contained in the <see cref="Intervals"/> collection
		/// </summary>
		public List<TachoParameterDefinition> ParameterDefinitions { get; set; }

		/// <summary>
		/// collection of <see cref="TachoInterval"/>
		/// </summary>
		public List<TachoInterval> Intervals { get; set; }

	}
}
