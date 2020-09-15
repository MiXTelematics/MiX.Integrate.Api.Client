using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.Scoring
{
	public class ScoreByEventType
	{
		public string EventDescription { get; set; }
		public List<long> EventTypeIds { get; set; }
		public int EventOccurrences { get; set; }
		public int EventCount { get; set; }
		public decimal EventDuration { get; set; }
		public decimal EventMinValue { get; set; }
		public decimal EventMaxValue { get; set; }
		public decimal EventScore { get; set; }
	}
}