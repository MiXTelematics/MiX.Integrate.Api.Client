using System.Threading.Tasks;
using System.Collections.Generic;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Journeys;
using MiX.Integrate.Api.Client.Base;
using System.Net.Http;
using System;

namespace MiX.Integrate.Api.Client.Journeys
{
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
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JOURNEYSCONTROLLER.ADDJOURNEY, HttpMethod.Put);
			request.AddJsonBody(newJourney);
			IHttpRestResponse<long> response = Execute<long>(request, 1);
			return response.Data;
		}

		/// <summary>
		/// Adds the journey.
		/// </summary>
		/// <param name="newJourney">The new journey.</param>
		/// <returns></returns>
		public async Task<long> AddJourneyAsync(CreateJourney newJourney)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JOURNEYSCONTROLLER.ADDJOURNEY, HttpMethod.Put);
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
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JOURNEYSCONTROLLER.ADDJOURNEY, HttpMethod.Put);
			request.AddJsonBody(journey);
			request.AddJsonBody(journeyAssets);
			request.AddJsonBody(journeyAssetDrivers);
			request.AddJsonBody(journeyAssetExternalPassengers);
			request.AddJsonBody(journeyRoute);
			IHttpRestResponse<Journey> response = Execute<Journey>(request,1);
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
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JOURNEYSCONTROLLER.ADDJOURNEY, HttpMethod.Put);
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
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JOURNEYSCONTROLLER.GETJOURNEY, HttpMethod.Get);
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
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JOURNEYSCONTROLLER.GETJOURNEY, HttpMethod.Get);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			IHttpRestResponse<Journey> response = await ExecuteAsync<Journey>(request).ConfigureAwait(false);
			return response.Data;
		}

		/// <summary>
		/// Gets the route list.
		/// </summary>
		/// <param name="groupId">The group identifier.</param>
		/// <returns></returns>
		public List<Route> GetRouteList(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JOURNEYSCONTROLLER.GETJOURNEYROUTE, HttpMethod.Get);
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
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JOURNEYSCONTROLLER.GETJOURNEYROUTE, HttpMethod.Get);
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
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JOURNEYSCONTROLLER.GETJOURNEYPROGRESS, HttpMethod.Get);
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
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JOURNEYSCONTROLLER.GETJOURNEYPROGRESS, HttpMethod.Get);
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
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JOURNEYSCONTROLLER.GETJOURNEYINPROGRESSCURRENTSTATUS, HttpMethod.Get);
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
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JOURNEYSCONTROLLER.GETJOURNEYINPROGRESSCURRENTSTATUS, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			IHttpRestResponse<List<JourneyInProgressCurrentStatus>> response = await ExecuteAsync<List<JourneyInProgressCurrentStatus>>(request).ConfigureAwait(false);
			return response.Data;
		}


		public List<JourneyAssetDriver> GetJourneyAssetsAndDrivers(long journeyId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JOURNEYSCONTROLLER.GETJOURNEYASSETSANDDRIVERSASYNC, HttpMethod.Get);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			IHttpRestResponse<List<JourneyAssetDriver>> response =  Execute<List<JourneyAssetDriver>>(request);
			return response.Data;

		}

		public async Task<List<JourneyAssetDriver>> GetJourneyAssetsAndDriversAsync(long journeyId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JOURNEYSCONTROLLER.GETJOURNEYASSETSANDDRIVERSASYNC, HttpMethod.Get);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			IHttpRestResponse<List<JourneyAssetDriver>> response = await ExecuteAsync<List<JourneyAssetDriver>>(request).ConfigureAwait(false);
			return response.Data;
					
		}

		public bool UpdateJourneyAssetDrivers(long journeyId, List<JourneyAssetDriver> journeyAssetDriver)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JOURNEYSCONTROLLER.UPDATEJOURNEYASSETDRIVERSASYNC, HttpMethod.Put);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			request.AddJsonBody(journeyAssetDriver);
			IHttpRestResponse<bool> response = Execute<bool>(request,1);
			return response.Data;

		}

		public async Task<bool> UpdateJourneyAssetDriversAsync(long journeyId, List<JourneyAssetDriver> journeyAssetDriver)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JOURNEYSCONTROLLER.UPDATEJOURNEYASSETDRIVERSASYNC, HttpMethod.Put);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			request.AddJsonBody(journeyAssetDriver);
			IHttpRestResponse<bool> response = await ExecuteAsync<bool>(request,1).ConfigureAwait(false);
			return response.Data;
			
		}


		public async Task<bool> RemoveJourneyAsync(long journeyId)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JOURNEYSCONTROLLER.REMOVEJOURNEYASYNC, HttpMethod.Delete);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			IHttpRestResponse<bool> response = await ExecuteAsync<bool>(request).ConfigureAwait(false);
			return response.Data;

		}

		public bool RemoveJourney(long journeyId)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JOURNEYSCONTROLLER.REMOVEJOURNEYASYNC, HttpMethod.Delete);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			IHttpRestResponse<bool> response = Execute<bool>(request);
			return response.Data;

		}

		public async Task<bool> CancelJourneyAsync(long journeyId)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JOURNEYSCONTROLLER.CANCELJOURNEYASYNC, HttpMethod.Post);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			IHttpRestResponse<bool> response = await ExecuteAsync<bool>(request).ConfigureAwait(false);
			return response.Data;

		}

		public bool CancelJourney(long journeyId)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JOURNEYSCONTROLLER.CANCELJOURNEYASYNC, HttpMethod.Post);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			IHttpRestResponse<bool> response = Execute<bool>(request);
			return response.Data;

		}


		public async Task<JourneyRouteInfo> GetJourneyRouteLocationsAsync(long journeyId)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JOURNEYSCONTROLLER.GETJOURNEYROUTELOCATIONSASYNC, HttpMethod.Get);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			IHttpRestResponse<JourneyRouteInfo> response = await ExecuteAsync<JourneyRouteInfo>(request).ConfigureAwait(false);
			return response.Data;
		
		}

		public JourneyRouteInfo GetJourneyRouteLocations(long journeyId)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JOURNEYSCONTROLLER.GETJOURNEYROUTELOCATIONSASYNC, HttpMethod.Get);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			IHttpRestResponse<JourneyRouteInfo> response = Execute<JourneyRouteInfo>(request);
			return response.Data;

		}

		public async Task<bool> SubmitJourneyAsync(long journeyId)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JOURNEYSCONTROLLER.SUBMITJOURNEY, HttpMethod.Put);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			IHttpRestResponse<bool> response = await ExecuteAsync<bool>(request,1).ConfigureAwait(false);
			return response.Data;

		}

		public bool SubmitJourney(long journeyId)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JOURNEYSCONTROLLER.SUBMITJOURNEY, HttpMethod.Put);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			IHttpRestResponse<bool> response = Execute<bool>(request,1);
			return response.Data;
		}

		public async Task<int> UpdateJourneyAssetPassengersAsync(long journeyId, JourneyAssetAndPassengerData journeyAssetAndPassengerData)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JOURNEYSCONTROLLER.UPDATEJOURNEYASSETPASSENGERASYNC, HttpMethod.Post);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			request.AddJsonBody(journeyAssetAndPassengerData);
			IHttpRestResponse<int> response = await ExecuteAsync<int>(request,1).ConfigureAwait(false);
			return response.Data;

		}

		public int UpdateJourneyAssetPassengers(long journeyId, JourneyAssetAndPassengerData journeyAssetAndPassengerData)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JOURNEYSCONTROLLER.UPDATEJOURNEYASSETPASSENGERASYNC, HttpMethod.Post);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			request.AddJsonBody(journeyAssetAndPassengerData);
			IHttpRestResponse<int> response = Execute<int>(request,1);
			return response.Data;

		}

		public async Task<int> RemoveJourneyAssetPassengersAsync(long journeyId, JourneyAssetAndPassengerData journeyAssetAndPassengerData)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JOURNEYSCONTROLLER.REMOVEJOURNEYASSETPASSENGERASYNC, HttpMethod.Post);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			request.AddJsonBody(journeyAssetAndPassengerData);
			IHttpRestResponse<int> response = await ExecuteAsync<int>(request,1).ConfigureAwait(false);
			return response.Data;

		}

		public  int RemoveJourneyAssetPassengers(long journeyId, JourneyAssetAndPassengerData journeyAssetAndPassengerData)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JOURNEYSCONTROLLER.REMOVEJOURNEYASSETPASSENGERASYNC, HttpMethod.Post);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			request.AddJsonBody(journeyAssetAndPassengerData);
			IHttpRestResponse<int> response =  Execute<int>(request,1);
			return response.Data;

		}

		public async Task<JourneyAssetAndPassengerData> GetJourneyAssetPassengersAsync(long journeyId)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JOURNEYSCONTROLLER.GETJOURNEYASSETPASSENGERASYNC, HttpMethod.Get);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			IHttpRestResponse<JourneyAssetAndPassengerData> response = await ExecuteAsync<JourneyAssetAndPassengerData>(request).ConfigureAwait(false);
			return response.Data;
		}

		public JourneyAssetAndPassengerData GetJourneyAssetPassengers(long journeyId)
		{

			IHttpRestRequest request = GetRequest(APIControllerRoutes.JOURNEYSCONTROLLER.GETJOURNEYASSETPASSENGERASYNC, HttpMethod.Get);
			request.AddUrlSegment("journeyId", journeyId.ToString());
			IHttpRestResponse<JourneyAssetAndPassengerData> response = Execute<JourneyAssetAndPassengerData>(request);
			return response.Data;
		}

		#endregion
	}
	}
