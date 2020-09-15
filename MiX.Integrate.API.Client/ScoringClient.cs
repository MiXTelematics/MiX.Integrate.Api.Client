using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Scoring;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public class ScoringClient : BaseClient, IScoringClient
	{

		#region constructors

		public ScoringClient(string url) : base(url, false) { }
		public ScoringClient(string url, IdServerResourceOwnerClientSettings settings) : base(url, settings, false) { }

		#endregion

		#region Scorecards

		public Report_FlexibleDriver GetFlexibleDriverScorecard(ReportQuery reportQuery)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ScoringController.GETFLEXIBLEDRIVERSORECARD, HttpMethod.Post);
			request.AddJsonBody(reportQuery);
			IHttpRestResponse<Report_FlexibleDriver> response = Execute<Report_FlexibleDriver>(request);
			return response.Data;
		}

		public async Task<Report_FlexibleDriver> GetFlexibleDriverScorecardAsync(ReportQuery reportQuery)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ScoringController.GETFLEXIBLEDRIVERSORECARD, HttpMethod.Post);
			request.AddJsonBody(reportQuery);
			IHttpRestResponse<Report_FlexibleDriver> response = await ExecuteAsync<Report_FlexibleDriver>(request).ConfigureAwait(false);
			return response.Data;
		}

		public Report_FlexibleRAG GetFlexibleRAGScoreReport(ReportQuery reportQuery)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ScoringController.GETFLEXIBLERAGSCORINGREPORT, HttpMethod.Post);
			request.AddJsonBody(reportQuery);
			IHttpRestResponse<Report_FlexibleRAG> response = Execute<Report_FlexibleRAG>(request);
			return response.Data;
		}

		public async Task<Report_FlexibleRAG> GetFlexibleRAGScoreReportAsync(ReportQuery reportQuery)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ScoringController.GETFLEXIBLERAGSCORINGREPORT, HttpMethod.Post);
			request.AddJsonBody(reportQuery);
			IHttpRestResponse<Report_FlexibleRAG> response = await ExecuteAsync<Report_FlexibleRAG>(request).ConfigureAwait(false);
			return response.Data;
		}

		public Report_FlexibleStandard GetFlexibleStandardScoreReport(ReportQuery reportQuery)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ScoringController.GETFLEXIBLESTANDARDSCORINGREPORT, HttpMethod.Post);
			request.AddJsonBody(reportQuery);
			IHttpRestResponse<Report_FlexibleStandard> response = Execute<Report_FlexibleStandard>(request);
			return response.Data;
		}

		public async Task<Report_FlexibleStandard> GetFlexibleStandardScoreReportAsync(ReportQuery reportQuery)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.ScoringController.GETFLEXIBLESTANDARDSCORINGREPORT, HttpMethod.Post);
			request.AddJsonBody(reportQuery);
			IHttpRestResponse<Report_FlexibleStandard> response = await ExecuteAsync<Report_FlexibleStandard>(request).ConfigureAwait(false);
			return response.Data;
		}

		#endregion

	}
}
