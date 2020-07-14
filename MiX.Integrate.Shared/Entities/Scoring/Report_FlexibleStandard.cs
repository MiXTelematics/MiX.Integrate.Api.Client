using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.Scoring
{
	public class Report_FlexibleStandard
	{
		public List<Score_FlexibleStandard> Scores { get; set; }
		public List<ScoringTemplate> ScoringTemplates { get; set; }
	}
}
