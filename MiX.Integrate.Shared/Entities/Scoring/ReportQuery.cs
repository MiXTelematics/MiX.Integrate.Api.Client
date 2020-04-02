using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.Scoring
{
	public class ReportQuery
	{
		public long OrganisationId { get; set; }
		public string From { get; set; }
		public string To { get; set; }
		public string AggregationPeriod { get; set; }
		public List<long> DriverIds { get; set; }
	}
}

