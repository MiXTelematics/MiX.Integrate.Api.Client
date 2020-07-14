using MiX.Integrate.Shared.Entities.Scoring;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public interface IScoringClient
	{
		Report_FlexibleDriver GetFlexibleDriverScorecard(ReportQuery reportQuery);
		Task<Report_FlexibleDriver> GetFlexibleDriverScorecardAsync(ReportQuery reportQuery);

		/// <summary>Gets scoring data based on the Flexible RAG scoring model</summary>
		/// <param name="reportQuery">A <see cref="ReportQuery"/> that encapsulates the criteria for the query</param>
		/// <returns>Scoring data based on the Flexible RAG scoring model, using the criteria specified by <paramref name="reportQuery"/></returns>
		Report_FlexibleRAG GetFlexibleRAGScoreReport(ReportQuery reportQuery);

		/// <summary>Gets scoring data based on the Flexible RAG scoring model as an asynchronous operation</summary>
		/// <param name="reportQuery">A <see cref="ReportQuery"/> that encapsulates the criteria for the query</param>
		/// <returns>A <see cref="Task"/> representing the asynchronous operation</returns>
		Task<Report_FlexibleRAG> GetFlexibleRAGScoreReportAsync(ReportQuery reportQuery);

		/// <summary>Gets scoring data based on the Flexible standard scoring model</summary>
		/// <param name="reportQuery">A <see cref="ReportQuery"/> that encapsulates the criteria for the query</param>
		/// <returns>Scoring data based on the Flexible standard scoring model, using the criteria specified by <paramref name="reportQuery"/></returns>
		Report_FlexibleStandard GetFlexibleStandardScoreReport(ReportQuery reportQuery);

		/// <summary>Gets scoring data based on the Flexible standard scoring model as an asynchronous operation</summary>
		/// <param name="reportQuery">A <see cref="ReportQuery"/> that encapsulates the criteria for the query</param>
		/// <returns>A <see cref="Task"/> representing the asynchronous operation</returns>
		Task<Report_FlexibleStandard> GetFlexibleStandardScoreReportAsync(ReportQuery reportQuery);

	}
}
