using MiX.Integrate.Shared.Entities.Scoring;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public interface IScoringClient
	{
		Report_FlexibleDriver GetFlexibleDriverScorecard(ReportQuery reportQuery);
		Task<Report_FlexibleDriver> GetFlexibleDriverScorecardAsync(ReportQuery reportQuery);
	}
}
