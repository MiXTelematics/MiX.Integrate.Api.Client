using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.Scoring
{
	public class PenaltyScoreByEventType
	{
		public string EventDescription { get; set; }
		public List<long> EventTypeIds { get; set; }
		public int Occurrences { get; set; }
		public int EventCount { get; set; }
		public decimal Duration { get; set; }
		public decimal PenaltyPoints { get; set; }
		public decimal Score { get; set; }
	}
}