using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Customers;
using MiX.Integrate.Shared.Entities.Journeys;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client.Journeys
{
	/// <inheritdoc/>
	public class JourneysClient : BaseClient, IJourneysClient
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="JourneysClient"/> class.
		/// </summary>
		/// <param name="url">The URL.</param>
		/// <param name="setTestRequestHeader">if set to <c>true</c> [set test request header].</param>
		public JourneysClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="JourneysClient"/> class.
		/// </summary>
		/// <param name="url">The URL.</param>
		/// <param name="settings">The settings.</param>
		/// <param name="setTestRequestHeader">if set to <c>true</c> [set test request header].</param>
		public JourneysClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		#endregion

		#region Implemented Members

		/// <summary>
		/// Adds the journey.
		/// </summary>
		/// <param name="newJourney">The new journey.</param>
		/// <returns></returns>
		public long AddJourney(CreateJourney newJourney)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.ADDJOURNEY, HttpMethod.Put);
			request.AddJsonBody(newJourney);
			IHttpRestResponse<long> response = Execute<long>(request, 1);
			return response.Data;
		}


		public long BulkJourneyAdd(CreateJourney newJourney)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.BULKJOURNEYADD, HttpMethod.Put);
			request.AddJsonBody(newJourney);
			IHttpRestResponse<long> response = Execute<long>(request, 1);
			return response.Data;
		}

		public BulkAddResult GetBulkAddResult(long GroupId, long CorrelationId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.BULKJOURNEYADDRESULT, HttpMethod.Get);
			request.AddUrlSegment("groupId", GroupId.ToString());
			request.AddUrlSegment("correlationId", CorrelationId.ToString());
			IHttpRestResponse<BulkAddResult> response = Execute<BulkAddResult>(request, 1);
			return response.Data;
		}

		/// <summary>
		/// Adds the journey.
		/// </summary>
		/// <param name="newJourney">The new journey.</param>
		/// <returns></returns>
		public async Task<long> AddJourneyAsync(CreateJourney newJourney)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.ADDJOURNEY, HttpMethod.Put);
			request.AddJsonBody(newJourney);
			IHttpRestResponse<long> response = await ExecuteAsync<long>(request, 1).ConfigureAwait(false);
			return response.Data;
		}

		/// <summary>
		/// Adds the journey.
		/// </summary>
		/// <param name="journey">The journey.</param>
		/// <param name="journeyAssets">The journey assets.</param>
		/// <param name="journeyAssetDrivers">The journey asset drivers.</param>
		/// <param name="journeyAssetExternalPassengers">The journey asset external passengers.</param>
		/// <param name="journeyRoute">The journey route.</param>
		/// <returns></returns>

		[Obsolete("Please use  AddJourney(CreateJourney newJourney)", false)]
		public Journey AddJourney(Journey journey, List<JourneyAsset> journeyAssets, List<JourneyAssetDriver> journeyAssetDrivers, List<JourneyAssetExternalPassenger> journeyAssetExternalPassengers, JourneyRoute journeyRoute)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.ADDJOURNEY, HttpMethod.Put);
			request.AddJsonBody(journey);
			request.AddJsonBody(journeyAssets);
			request.AddJsonBody(journeyAssetDrivers);
			request.AddJsonBody(journeyAssetExternalPassengers);
			request.AddJsonBody(journeyRoute);
			IHttpRestResponse<Journey> response = Execute<Journey>(request, 1);
			return response.Data;
		}

		/// <summary>
		/// Adds the journey asynchronous.
		/// </summary>
		/// <param name="journey">The journey.</param>
		/// <param name="journeyAssets">The journey assets.</param>
		/// <param name="journeyAssetDrivers">The journey asset drivers.</param>
		/// <param name="journeyAssetExternalPassengers">The journey asset external passengers.</param>
		/// <param name="journeyRoute">The journey route.</param>
		/// <returns></returns>
		[Obsolete("Please use  AddJourneyAsync(CreateJourney newJourney)", false)]
		public async Task<Journey> AddJourneyAsync(Journey journey, List<JourneyAsset> journeyAssets, List<JourneyAssetDriver> journeyAssetDrivers, List<JourneyAssetExternalPassenger> journeyAssetExternalPassengers, JourneyRoute journeyRoute)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.ADDJOURNEY, HttpMethod.Put);
			request.AddJsonBody(journey);
			request.AddJsonBody(journeyAssets);
			request.AddJsonBody(journeyAssetDrivers);
			request.AddJsonBody(journeyAssetExternalPassengers);
			request.AddJsonBody(journeyRoute);
			IHttpRestResponse<Journey> response = await ExecuteAsync<Journey>(request, 1).ConfigureAwait(false);
			return response.Data;
		}

		/// <summary>
		/// Gets the journey.
		/// </summary>
		/// <param name="journeyId">The journey identifier.</param>
		/// <returns></returns>
		public Journey GetJourney(long journeyId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.GETJOURNEY, HttpMethod.Get);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			IHttpRestResponse<Journey> response = Execute<Journey>(request);
			return response.Data;
		}

		/// <summary>
		/// Gets the journey asynchronous.
		/// </summary>
		/// <param name="journeyId">The journey identifier.</param>
		/// <returns></returns>
		public async Task<Journey> GetJourneyAsync(long journeyId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.GETJOURNEY, HttpMethod.Get);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			IHttpRestResponse<Journey> response = await ExecuteAsync<Journey>(request).ConfigureAwait(false);
			return response.Data;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="groupId"></param>
		/// <param name="startDate"></param>
		/// <param name="endDate"></param>
		/// <returns></returns>
		public List<long> GetJourneyIdList(long groupId, DateTime startDate, DateTime endDate)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.GETJOURNEYIDLIST, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddUrlSegment("startDate", startDate.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("endDate", endDate.ToString(DataFormats.DateTime_Format));
			IHttpRestResponse<List<long>> response = Execute<List<long>>(request);
			return response.Data;
		}

		/// <summary>
		/// Returns the List of JourneyId's that are currently in an active state with a departure date between the supplied dates
		/// </summary>
		/// <param name="groupId"></param>
		/// <param name="startDate"></param>
		/// <param name="endDate"></param>
		/// <returns></returns>
		public async Task<List<long>> GetJourneyIdListAsync(long groupId, DateTime startDate, DateTime endDate)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.GETJOURNEYIDLIST, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddUrlSegment("startDate", startDate.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("endDate", endDate.ToString(DataFormats.DateTime_Format));
			IHttpRestResponse<List<long>> response = await ExecuteAsync<List<long>>(request).ConfigureAwait(false);
			return response.Data;
		}

		/// <summary>
		/// Returns the List of JourneyId's that are currently in an active state with a departure date between the supplied dates
		/// with the current status and the date the the journey details was last updated
		/// </summary>
		/// <param name="groupId"></param>
		/// <param name="startDate"></param>
		/// <param name="endDate"></param>
		/// <returns></returns>
		public async Task<List<JourneyIdStatus>> GetJourneyIdStatusListAsync(long groupId, DateTime startDate, DateTime endDate)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.GETJOURNEYIDSTATUSLIST, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddUrlSegment("startDate", startDate.ToString(DataFormats.DateTime_Format));
			request.AddUrlSegment("endDate", endDate.ToString(DataFormats.DateTime_Format));
			IHttpRestResponse<List<JourneyIdStatus>> response = await ExecuteAsync<List<JourneyIdStatus>>(request).ConfigureAwait(false);
			return response.Data;
		}

		/// <summary>
		/// Gets the route list.
		/// </summary>
		/// <param name="groupId">The group identifier.</param>
		/// <returns></returns>
		public List<Route> GetRouteList(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.GETJOURNEYROUTE, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			IHttpRestResponse<List<Route>> response = Execute<List<Route>>(request);
			return response.Data;
		}

		/// <summary>
		/// Gets the route list asynchronous.
		/// </summary>
		/// <param name="groupId">The group identifier.</param>
		/// <returns></returns>
		public async Task<List<Route>> GetRouteListAsync(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.GETJOURNEYROUTE, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			IHttpRestResponse<List<Route>> response = await ExecuteAsync<List<Route>>(request).ConfigureAwait(false);
			return response.Data;
		}

		/// <summary>
		/// Gets the journey progress.
		/// </summary>
		/// <param name="journeyId">The journey identifier.</param>
		/// <returns></returns>
		public AutomatedMonitoring GetJourneyProgress(long journeyId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.GETJOURNEYPROGRESS, HttpMethod.Get);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			IHttpRestResponse<AutomatedMonitoring> response = Execute<AutomatedMonitoring>(request);
			return response.Data;
		}

		/// <summary>
		/// Gets the journey progress asynchronous.
		/// </summary>
		/// <param name="journeyId">The journey identifier.</param>
		/// <returns></returns>
		public async Task<AutomatedMonitoring> GetJourneyProgressAsync(long journeyId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.GETJOURNEYPROGRESS, HttpMethod.Get);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			IHttpRestResponse<AutomatedMonitoring> response = await ExecuteAsync<AutomatedMonitoring>(request).ConfigureAwait(false);
			return response.Data;
		}

		/// <summary>
		/// Gets the journey in progress current status.
		/// </summary>
		/// <param name="groupId">The group identifier.</param>
		/// <returns></returns>
		public List<JourneyInProgressCurrentStatus> GetJourneyInProgressCurrentStatus(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.GETJOURNEYINPROGRESSCURRENTSTATUS, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			IHttpRestResponse<List<JourneyInProgressCurrentStatus>> response = Execute<List<JourneyInProgressCurrentStatus>>(request);
			return response.Data;
		}

		/// <summary>
		/// Gets the journey in progress current status asynchronous.
		/// </summary>
		/// <param name="groupId">The group identifier.</param>
		/// <returns></returns>
		public async Task<List<JourneyInProgressCurrentStatus>> GetJourneyInProgressCurrentStatusAsync(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.GETJOURNEYINPROGRESSCURRENTSTATUS, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			IHttpRestResponse<List<JourneyInProgressCurrentStatus>> response = await ExecuteAsync<List<JourneyInProgressCurrentStatus>>(request).ConfigureAwait(false);
			return response.Data;
		}


		public List<JourneyAssetDriver> GetJourneyAssetsAndDrivers(long journeyId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.GETJOURNEYASSETSANDDRIVERSASYNC, HttpMethod.Get);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			IHttpRestResponse<List<JourneyAssetDriver>> response = Execute<List<JourneyAssetDriver>>(request);
			return response.Data;

		}

		public async Task<List<JourneyAssetDriver>> GetJourneyAssetsAndDriversAsync(long journeyId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.GETJOURNEYASSETSANDDRIVERSASYNC, HttpMethod.Get);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			IHttpRestResponse<List<JourneyAssetDriver>> response = await ExecuteAsync<List<JourneyAssetDriver>>(request).ConfigureAwait(false);
			return response.Data;

		}

		public bool UpdateJourneyAssetDrivers(long journeyId, List<JourneyAssetDriver> journeyAssetDriver)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.UPDATEJOURNEYASSETDRIVERSASYNC, HttpMethod.Put);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			request.AddJsonBody(journeyAssetDriver);
			IHttpRestResponse<bool> response = Execute<bool>(request, 1);
			return response.Data;

		}

		public async Task<bool> UpdateJourneyAssetDriversAsync(long journeyId, List<JourneyAssetDriver> journeyAssetDriver)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.UPDATEJOURNEYASSETDRIVERSASYNC, HttpMethod.Put);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			request.AddJsonBody(journeyAssetDriver);
			IHttpRestResponse<bool> response = await ExecuteAsync<bool>(request, 1).ConfigureAwait(false);
			return response.Data;

		}


		public async Task<bool> RemoveJourneyAsync(long journeyId)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.REMOVEJOURNEYASYNC, HttpMethod.Delete);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			IHttpRestResponse<bool> response = await ExecuteAsync<bool>(request).ConfigureAwait(false);
			return response.Data;

		}

		public bool RemoveJourney(long journeyId)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.REMOVEJOURNEYASYNC, HttpMethod.Delete);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			IHttpRestResponse<bool> response = Execute<bool>(request);
			return response.Data;

		}

		public async Task<bool> CancelJourneyAsync(long journeyId)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.CANCELJOURNEYASYNC, HttpMethod.Post);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			IHttpRestResponse<bool> response = await ExecuteAsync<bool>(request).ConfigureAwait(false);
			return response.Data;

		}

		public bool CancelJourney(long journeyId)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.CANCELJOURNEYASYNC, HttpMethod.Post);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			IHttpRestResponse<bool> response = Execute<bool>(request);
			return response.Data;

		}


		public async Task<JourneyRouteInfo> GetJourneyRouteLocationsAsync(long journeyId)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.GETJOURNEYROUTELOCATIONSASYNC, HttpMethod.Get);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			IHttpRestResponse<JourneyRouteInfo> response = await ExecuteAsync<JourneyRouteInfo>(request).ConfigureAwait(false);
			return response.Data;

		}

		public JourneyRouteInfo GetJourneyRouteLocations(long journeyId)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.GETJOURNEYROUTELOCATIONSASYNC, HttpMethod.Get);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			IHttpRestResponse<JourneyRouteInfo> response = Execute<JourneyRouteInfo>(request);
			return response.Data;

		}

		/// <summary>Gets the turn-by-turn route data in JSON format for a journey's route</summary>
		/// <param name="journeyId">Identifier of the journey</param>
		/// <returns>A <see cref="JourneyRouteData"/> containing the turn-by-turn route data in JSON format for the specified journey</returns>
		public JourneyRouteData GetJourneyRouteData(long journeyId)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.GETJOURNEYROUTEDATA, HttpMethod.Get);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			IHttpRestResponse<JourneyRouteData> response = Execute<JourneyRouteData>(request);
			return response.Data;

		}

		/// <summary>Gets the turn-by-turn route data in JSON format for a journey's route</summary>
		/// <param name="journeyId">Identifier of the journey</param>
		/// <returns>A <see cref="JourneyRouteData"/> containing the turn-by-turn route data in JSON format for the specified journey</returns>
		public async Task<JourneyRouteData> GetJourneyRouteDataAsync(long journeyId)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.GETJOURNEYROUTEDATA, HttpMethod.Get);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			IHttpRestResponse<JourneyRouteData> response = await ExecuteAsync<JourneyRouteData>(request).ConfigureAwait(false);
			return response.Data;

		}

		/// <summary>
		/// Get journey current ID
		/// </summary>
		/// <param name="journeyIdList">Group identifier</param>
		/// <returns>List of JourneyIds</returns>
		public List<CurrentJourney> GetJourneyCurrentIdList(List<long> journeyIdList)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.GETJOURNEYCURRENTIDLIST, HttpMethod.Post);
			request.AddJsonBody(journeyIdList);
			IHttpRestResponse<List<CurrentJourney>> response = Execute<List<CurrentJourney>>(request);
			return response.Data;
		}

		/// <summary>
		/// Get journey current ID asynchronous
		/// </summary>
		/// <param name="journeyIdList">Group identifier</param>
		/// <returns>List of JourneyIds</returns>
		public async Task<List<CurrentJourney>> GetJourneyCurrentIdListAsync(List<long> journeyIdList)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.GETJOURNEYCURRENTIDLIST, HttpMethod.Post);
			request.AddJsonBody(journeyIdList);
			IHttpRestResponse<List<CurrentJourney>> response = await ExecuteAsync<List<CurrentJourney>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public async Task<bool> SubmitJourneyAsync(long journeyId)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.SUBMITJOURNEY, HttpMethod.Put);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			IHttpRestResponse<bool> response = await ExecuteAsync<bool>(request, 1).ConfigureAwait(false);
			return response.Data;

		}

		public bool SubmitJourney(long journeyId)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.SUBMITJOURNEY, HttpMethod.Put);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			IHttpRestResponse<bool> response = Execute<bool>(request, 1);
			return response.Data;
		}

		public async Task<int> UpdateJourneyAssetPassengersAsync(long journeyId, JourneyAssetAndPassengerData journeyAssetAndPassengerData)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.UPDATEJOURNEYASSETPASSENGERASYNC, HttpMethod.Post);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			request.AddJsonBody(journeyAssetAndPassengerData);
			IHttpRestResponse<int> response = await ExecuteAsync<int>(request, 1).ConfigureAwait(false);
			return response.Data;

		}

		public int UpdateJourneyAssetPassengers(long journeyId, JourneyAssetAndPassengerData journeyAssetAndPassengerData)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.UPDATEJOURNEYASSETPASSENGERASYNC, HttpMethod.Post);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			request.AddJsonBody(journeyAssetAndPassengerData);
			IHttpRestResponse<int> response = Execute<int>(request, 1);
			return response.Data;

		}

		public async Task<int> RemoveJourneyAssetPassengersAsync(long journeyId, JourneyAssetAndPassengerData journeyAssetAndPassengerData)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.REMOVEJOURNEYASSETPASSENGERASYNC, HttpMethod.Post);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			request.AddJsonBody(journeyAssetAndPassengerData);
			IHttpRestResponse<int> response = await ExecuteAsync<int>(request, 1).ConfigureAwait(false);
			return response.Data;

		}

		public int RemoveJourneyAssetPassengers(long journeyId, JourneyAssetAndPassengerData journeyAssetAndPassengerData)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.REMOVEJOURNEYASSETPASSENGERASYNC, HttpMethod.Post);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			request.AddJsonBody(journeyAssetAndPassengerData);
			IHttpRestResponse<int> response = Execute<int>(request, 1);
			return response.Data;

		}

		public async Task<JourneyAssetAndPassengerData> GetJourneyAssetPassengersAsync(long journeyId)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.GETJOURNEYASSETPASSENGERASYNC, HttpMethod.Get);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			IHttpRestResponse<JourneyAssetAndPassengerData> response = await ExecuteAsync<JourneyAssetAndPassengerData>(request).ConfigureAwait(false);
			return response.Data;
		}

		public JourneyAssetAndPassengerData GetJourneyAssetPassengers(long journeyId)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.GETJOURNEYASSETPASSENGERASYNC, HttpMethod.Get);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			IHttpRestResponse<JourneyAssetAndPassengerData> response = Execute<JourneyAssetAndPassengerData>(request);
			return response.Data;
		}

		public async Task<List<AutomatedMonitoring>> GetBulkJourneyProgressAsync(List<long> bulkJourneyProgress)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.GETBULKJOURNEYPROGRESSASYNC, HttpMethod.Post);
			request.AddJsonBody(bulkJourneyProgress);
			IHttpRestResponse<List<AutomatedMonitoring>> response = await ExecuteAsync<List<AutomatedMonitoring>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public async Task<List<BulkSubmitJourney>> SubmitBulkJourneysAsync(List<long> journeyIds)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.SUBMITBULKJOURNEY, HttpMethod.Post);
			request.AddJsonBody(journeyIds);
			IHttpRestResponse<List<BulkSubmitJourney>> response = await ExecuteAsync<List<BulkSubmitJourney>>(request).ConfigureAwait(false);
			return response.Data;
		}


		public List<JourneyState> GetJourneyStates(long organisationId, List<long> journeyIds)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.GETJOURNEYSTATESBATCHED, HttpMethod.Post);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddJsonBody(journeyIds);
			IHttpRestResponse<List<JourneyState>> response = Execute<List<JourneyState>>(request);
			return response.Data;
		}


		public async Task<List<JourneyState>> GetJourneyStatesAsync(long organisationId, List<long> journeyIds)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JourneysController.GETJOURNEYSTATESBATCHED, HttpMethod.Post);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddJsonBody(journeyIds);
			IHttpRestResponse<List<JourneyState>> response = await ExecuteAsync<List<JourneyState>>(request).ConfigureAwait(false);
			return response.Data;
		}
		
		#endregion
	}
}
