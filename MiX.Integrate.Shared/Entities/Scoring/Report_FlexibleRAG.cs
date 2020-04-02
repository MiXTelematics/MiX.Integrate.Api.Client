using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.Scoring
{
	public class Report_FlexibleRAG
	{
		public List<Score_FlexibleRAG> Scores { get; set; }
		public List<ScoringTemplate> ScoringTemplates { get; set; }
	}
}
