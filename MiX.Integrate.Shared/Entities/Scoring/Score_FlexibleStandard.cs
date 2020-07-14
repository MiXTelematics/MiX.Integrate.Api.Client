using System;
using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.Scoring
{

	public class Score_FlexibleStandard
	{

		//Standard
		public DateTime DateKey { get; set; }
		public string Period { get; set; }
		public long SiteId { get; set; }
		public long DriverID { get; set; }
		public string ScoringUnitOfMeasure { get; set; }
		public long TemplateId { get; set; }
		public int TemplateVersion { get; set; }
		public DateTime TemplateValidFrom { get; set; }

		//Trip summary
		public int TripsCount { get; set; }
		public decimal TripsDistance { get; set; }
		public decimal TripsDuration { get; set; }
		public decimal TripsDrivingTime { get; set; }
		public decimal TripsMaxSpeed { get; set; }

		//Ranking
		public decimal RankingScore() { return TotalScore; }
		public int OrganisationRank { get; set; }
		public int SiteRank { get; set; }

		//Score
		public bool IsScored { get; set; }
		public decimal TotalScore { get; set; }
		public List<ScoreByEventType> ScoresByEventType { get; set; }
		public decimal TotalRAGScore { get; set; }

		//SiteScore
		public bool SiteIsScored { get; set; }
		public decimal SiteTotalScore { get; set; }
		public List<ScoreByEventType> SiteScoresByEventType { get; set; }
		public decimal SiteTotalRAGScore { get; set; }

	}
}
