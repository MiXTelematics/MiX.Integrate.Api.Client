using System.Threading.Tasks;
using System.Collections.Generic;
using MiX.Integrate.Shared.Entities.Journeys;
using MiX.Integrate.Api.Client.Base;

namespace MiX.Integrate.Api.Client.Journeys
{
	public interface IJourneysClient : IBaseClient
	{
		Journey GetJourney(long journeyId);
		Task<Journey> GetJourneyAsync(long journeyId);

		long AddJourney(CreateJourney newjourney);
		Task<long> AddJourneyAsync(CreateJourney newjourney);

		List<Route> GetRouteList(long groupId);
		Task<List<Route>> GetRouteListAsync(long groupId);

		AutomatedMonitoring GetJourneyProgress(long journeyId);
		Task<AutomatedMonitoring> GetJourneyProgressAsync(long journeyId);

		List<JourneyInProgressCurrentStatus> GetJourneyInProgressCurrentStatus(long groupId);
		Task<List<JourneyInProgressCurrentStatus>> GetJourneyInProgressCurrentStatusAsync(long groupId);
	}
}
