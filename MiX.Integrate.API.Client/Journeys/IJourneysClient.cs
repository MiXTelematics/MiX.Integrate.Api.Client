using System.Threading.Tasks;
using System.Collections.Generic;
using MiX.Integrate.Shared.Entities.Journeys;
using MiX.Integrate.API.Client.Base;
using System;

namespace MiX.Integrate.API.Client.Journeys
{
	public interface IJourneysClient : IBaseClient
	{
		Journey GetJourney(long journeyId);
		Task<Journey> GetJourneyAsync(long journeyId);

		List<long> GetJourneyIdList(long groupId, DateTime startDate, DateTime endDate);
		Task<List<long>> GetJourneyIdListAsync(long groupId, DateTime startDate, DateTime endDate);
		Task<List<JourneyIdStatus>> GetJourneyIdStatusListAsync(long groupId, DateTime startDate, DateTime endDate);

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

		JourneyRouteData GetJourneyRouteData(long journeyId);
		Task<JourneyRouteData> GetJourneyRouteDataAsync(long journeyId);

		Task<int> UpdateJourneyAssetPassengersAsync(long journeyId, JourneyAssetAndPassengerData journeyAssetAndPassengerData);
		int UpdateJourneyAssetPassengers(long journeyId, JourneyAssetAndPassengerData journeyAssetAndPassengerData);
		Task<int> RemoveJourneyAssetPassengersAsync(long journeyId, JourneyAssetAndPassengerData journeyAssetAndPassengerData);
		int RemoveJourneyAssetPassengers(long journeyId, JourneyAssetAndPassengerData journeyAssetAndPassengerData);
		Task<JourneyAssetAndPassengerData> GetJourneyAssetPassengersAsync(long journeyId);
		JourneyAssetAndPassengerData GetJourneyAssetPassengers(long journeyId);

		List<CurrentJourney> GetJourneyCurrentIdList(List<long> journeyIdList);
		Task<List<CurrentJourney>> GetJourneyCurrentIdListAsync(List<long> journeyIdList);
		Task<List<AutomatedMonitoring>> GetBulkJourneyProgressAsync(List<long> bulkJourneyProgress);
		Task<List<BulkSubmitJourney>> SubmitBulkJourneysAsync(List<long> journeyIds);

		/// <summary>Gets the details, route locations, and current status of the specified journeys</summary>
		/// <param name="organisationId">Identifier of the organisation to which the journeys belong</param>
		/// <param name="journeyIds">A <see cref="T:System.Collections.Generic.List`1"/> of journey identifiers to query</param>
		/// <returns>A <see cref="List{JourneyState}"/> as a <see cref="T:List&lt;JourneyState&gt;"/> for the specified journeys</returns>
		List<JourneyState> GetJourneyStates(long organisationId, List<long> journeyIds);

		/// <summary>Gets the details, route locations, and current status of the specified journeys as an asynchronous operation</summary>
		/// <param name="organisationId">Identifier of the organisation to which the journeys belong</param>
		/// <param name="journeyIds">An <see cref="I:IReadOnlyList&lt;long&gt;"/> of journey identifiers to query</param>
		/// <returns>A <see cref="T:System.Threading.Tasks.Task"/> representing the asynchronous operation</returns>
		Task<List<JourneyState>> GetJourneyStatesAsync(long organisationId, List<long> journeyIds);

		/// <summary>Gets customers for an organisation</summary>
		/// <param name="organisationId">Identifier of the organisation to be queried</param>
		/// <returns>The <see cref="Customer"/> records associated with the specified organisation</returns>
		List<Customer> GetOrganisationCustomers(long organisationId);

		/// <summary>Gets customers for an organisation as an asynchronous operation</summary>
		/// <param name="organisationId">Identifier of the organisation to be queried</param>
		/// <returns>A <see cref="T:System.Threading.Tasks.Task"/> representing the asynchronous operation</returns>
		Task<List<Customer>> GetOrganisationCustomersAsync(long organisationId);

		/// <summary>Gets the delivery points associated with a customer</summary>
		/// <param name="organisationId">Identifier of the organisation to which the customer belongs</param>
		/// <param name="customerId">Identifier of the customer to be queried</param>
		/// <returns>The <see cref="DeliveryPoint"/> records associated with the specified customer</returns>
		List<DeliveryPoint> GetCustomerDeliveryPoints(long organisationId, long customerId);

		/// <summary>Gets the delivery points associated with a customer as an asynchronous operation</summary>
		/// <param name="organisationId">Identifier of the organisation to which the customer belongs</param>
		/// <param name="customerId">Identifier of the customer to be queried</param>
		/// <returns>A <see cref="T:System.Threading.Tasks.Task"/> representing the asynchronous operation</returns>
		Task<List<DeliveryPoint>> GetCustomerDeliveryPointsAsync(long organisationId, long customerId);


	}
}
