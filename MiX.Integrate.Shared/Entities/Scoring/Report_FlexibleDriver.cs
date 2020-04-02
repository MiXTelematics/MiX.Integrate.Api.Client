using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.Scoring
{
	public class Report_FlexibleDriver
	{
		public List<Score_FlexibleDriver> Scores { get; set; }
		public List<ScoringTemplate> ScoringTemplates { get; set; }
	}
}
