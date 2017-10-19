using System.Threading.Tasks;
using System.Collections.Generic;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Journeys;
using MiX.Integrate.Api.Client.Base;
using System.Net.Http;

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
			IHttpRestResponse<long> response = Execute<long>(request);
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
			IHttpRestResponse<Journey> response = await ExecuteAsync<Journey>(request).ConfigureAwait(false);
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
		public Journey AddJourney(Journey journey, List<JourneyAsset> journeyAssets, List<JourneyAssetDriver> journeyAssetDrivers, List<JourneyAssetExternalPassenger> journeyAssetExternalPassengers, JourneyRoute journeyRoute)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JOURNEYSCONTROLLER.ADDJOURNEY, HttpMethod.Put);
			request.AddJsonBody(journey);
			request.AddJsonBody(journeyAssets);
			request.AddJsonBody(journeyAssetDrivers);
			request.AddJsonBody(journeyAssetExternalPassengers);
			request.AddJsonBody(journeyRoute);
			IHttpRestResponse<Journey> response = Execute<Journey>(request);
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
		public async Task<Journey> AddJourneyAsync(Journey journey, List<JourneyAsset> journeyAssets, List<JourneyAssetDriver> journeyAssetDrivers, List<JourneyAssetExternalPassenger> journeyAssetExternalPassengers, JourneyRoute journeyRoute)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.JOURNEYSCONTROLLER.ADDJOURNEY, HttpMethod.Put);
			request.AddJsonBody(journey);
			request.AddJsonBody(journeyAssets);
			request.AddJsonBody(journeyAssetDrivers);
			request.AddJsonBody(journeyAssetExternalPassengers);
			request.AddJsonBody(journeyRoute);
			IHttpRestResponse<Journey> response = await ExecuteAsync<Journey>(request).ConfigureAwait(false);
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
			request.AddUrlSegment("journeyId:long", journeyId.ToString());
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
			request.AddUrlSegment("journeyId:long", journeyId.ToString());
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
			request.AddUrlSegment("groupId:long", groupId.ToString());
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
			request.AddUrlSegment("groupId:long", groupId.ToString());
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
			request.AddUrlSegment("journeyId:long", journeyId.ToString());
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
			request.AddUrlSegment("journeyId:long", journeyId.ToString());
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
			request.AddUrlSegment("groupId:long", groupId.ToString());
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
			request.AddUrlSegment("groupId:long", groupId.ToString());
			IHttpRestResponse<List<JourneyInProgressCurrentStatus>> response = await ExecuteAsync<List<JourneyInProgressCurrentStatus>>(request).ConfigureAwait(false);
			return response.Data;
		}

		#endregion
	}
}
