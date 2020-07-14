using System;
using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.Scoring
{
	public class ScoringTemplate
	{
		public long TemplateId { get; set; }
		public long OrganisationId { get; set; }
		public string TemplateType { get; set; }
		public string ModelType { get; set; }
		public IModelSettings ModelSettings { get; set; }
		public DateTime DateValidFrom { get; set; }
	}

	public interface IModelSettings
	{
		decimal MinDistance { get; set; }
		string RankOrder { get; }
		string RankType { get; }
	}

	public sealed class ModelSettings_FlexibleDriver : IModelSettings
	{
		public List<ScoreSetting_FlexibleDriver> PenaltySettings { get; set; }
		public decimal TotalScoreAmberBandStart { get; set; }
		public decimal TotalScoreAmberBandEnd { get; set; }
		public decimal MinDistance { get; set; }
		public string RankOrder { get; set; }
		public string RankType { get; set; }
	}

	public sealed class ModelSettings_FlexibleRAG : IModelSettings
	{
		public string TripScoreMetric { get; set; }
		public decimal DistanceMultiple { get; set; }
		public List<ScoreSetting_FlexibleRAG> EventSettings { get; set; }
		public decimal TotalScoreAmberBandStart { get; set; }
		public decimal TotalScoreAmberBandEnd { get; set; }
		public decimal MinDistance { get; set; }
		public string RankOrder { get; set; }
		public string RankType { get; set; }
	}

	public sealed class ModelSettings_FlexibleStandard : IModelSettings
	{
		public decimal TotalScoreAmberBandStart { get; set; }
		public decimal TotalScoreAmberBandEnd { get; set; }
		public List<ScoreSetting_FlexibleStandard> ScoreSettings { get; set; }
		public decimal MinDistance { get; set; }
		public string RankOrder { get; set; }
		public string RankType { get; set; }
	}

	public sealed class ScoreSetting_FlexibleDriver
	{
		public string Description { get; set; }
		public List<long> EventTypeIds { get; set; }
		public decimal PenaltyPoints { get; set; }
		public int CumulativeViolationTime { get; set; }
		public decimal AmberBandStart { get; set; }
		public decimal AmberBandEnd { get; set; }
	}

	public sealed class ScoreSetting_FlexibleRAG
	{
		public string EventDescription { get; set; }
		public List<long> EventTypeIds { get; set; }
		public string EventScoreMetric { get; set; }
		public decimal AmberBandStart { get; set; }
		public decimal AmberBandEnd { get; set; }
		public int EventDurationSize { get; set; }
	}

	public sealed class ScoreSetting_FlexibleStandard
	{
		public List<long> EventTypeIds { get; set; }
		public decimal Weight { get; set; }
		public decimal? ScoreTriggerValue { get; set; }
		public decimal? ThreshHoldValue { get; set; }
		public decimal AmberBandStart { get; set; }
		public decimal AmberBandEnd { get; set; }
	}

}
