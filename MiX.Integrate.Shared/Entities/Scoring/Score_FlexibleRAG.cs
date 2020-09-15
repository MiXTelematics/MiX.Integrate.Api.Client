using System;
using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.Scoring
{

	public class Score_FlexibleRAG
	{
		//Standard
		public DateTime DateKey { get; set; }
		public string Period { get; set; }
		public long SiteId { get; set; }
		public long DriverID { get; set; }
		public string UnitOfMeasure { get; set; }

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
		public decimal TotalScore { get; set; }
		public bool IsScored { get; set; }
		public List<ScoreByEventType> ScoresByEventType { get; set; }

		//SiteScore
		public decimal SiteTotalScore { get; set; }
		public bool SiteIsScored { get; set; }
		public List<ScoreByEventType> SiteScoresByEventType { get; set; }
	}
}
