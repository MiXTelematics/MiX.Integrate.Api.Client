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
		Task<JourneyRouteInfo> GetJourneyRouteLocationsAsync(long journeyId);
		Task<bool> RemoveJourneyAsync(long journeyId);
		Task<bool> CancelJourneyAsync(long journeyId);
		Task<bool> UpdateJourneyAssetDriversAsync(long journeyId, List<JourneyAssetDriver> journeyAssetDriver);
		Task<List<JourneyAssetDriver>> GetJourneyAssetsAndDriversAsync(long journeyId);
		List<JourneyAssetDriver> GetJourneyAssetsAndDrivers(long journeyId);
		bool UpdateJourneyAssetDrivers(long journeyId, List<JourneyAssetDriver> journeyAssetDriver);
		bool RemoveJourney(long journeyId);
		bool CancelJourney(long journeyId);
		JourneyRouteInfo GetJourneyRouteLocations(long journeyId);
		Task<bool> SubmitJourneyAsync(long journeyId);
		bool SubmitJourney(long journeyId);

		Task<int> UpdateJourneyAssetPassengersAsync(long journeyId, JourneyAssetAndPassengerData journeyAssetAndPassengerData);
		int UpdateJourneyAssetPassengers(long journeyId, JourneyAssetAndPassengerData journeyAssetAndPassengerData);
		Task<int> RemoveJourneyAssetPassengersAsync(long journeyId, JourneyAssetAndPassengerData journeyAssetAndPassengerData);
		int RemoveJourneyAssetPassengers(long journeyId, JourneyAssetAndPassengerData journeyAssetAndPassengerData);
		Task<JourneyAssetAndPassengerData> GetJourneyAssetPassengersAsync(long journeyId);
		JourneyAssetAndPassengerData GetJourneyAssetPassengers(long journeyId);
		
	}
}
