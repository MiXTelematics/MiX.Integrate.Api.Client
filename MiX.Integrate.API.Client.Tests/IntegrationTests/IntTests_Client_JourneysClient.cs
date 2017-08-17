using System;
using MiX.Integrate.API.Client.Tests;
using System.Threading.Tasks;
using System.Collections.Generic;
using MiX.Integrate.Api.Client.Journeys;
using MiX.Integrate.Shared.Entities.Journeys;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using MiX.JourneyManagement.Services.Shared.Common;

namespace MiX.Integrate.Api.Client.Tests.IntegrationTests
{
	[TestClass]
	public class IntTests_Client_JourneysClient
	{
		#region Startup 

		private static string _apiUrl;
		private static string _safetyApiUrl;
		// Integration data 
		string _correlationId = "IntTest@" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
		private static IdServerResourceOwnerClientSettings _idServerResourceOwnerClientSettings;

		[ClassInitialize()]
		public static void ClassInit(TestContext context)
		{
			_apiUrl = Main.Configuration["appSettings:ApiUrl"];
			_safetyApiUrl = Main.Configuration["appSettings:JourneyManagement.Services.Api"];
			_idServerResourceOwnerClientSettings = new IdServerResourceOwnerClientSettings()
			{
				BaseAddress = Main.Configuration["appSettings:IdentityServerBaseAddress"],
				ClientId = Main.Configuration["appSettings:IdentityServerClientId"],
				ClientSecret = Main.Configuration["appSettings:IdentityServerClientSecret"],
				UserName = Main.Configuration["appSettings:IdentityServerUserName"],
				Password = Main.Configuration["appSettings:IdentityServerPassword"],
				Scopes = Main.Configuration["appSettings:IdentityServerScopes"]

			};
		}

		[ClassCleanup()]
		public static void ClassCleanup() { }

		#endregion

		/// <summary>
		/// Ints the tests client journey client add journey asynchronous details.
		/// </summary>
		/// <returns></returns>
		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_JourneyClient_AddJourneyAsync_Details()
		{
			// Arrange  
			IJourneysClient client = new JourneysClient(_apiUrl, _idServerResourceOwnerClientSettings);
			client.GetCorrelationId = () => { return _correlationId; };
			long journeyId = IdentityGenerator.Generate64Bit();
			Journey journey = new Journey
			{
				GroupId = -3502972875755389865,
				SiteId = 5481198413424238674,
				Description = $"Yiza Ngoku External API Journey One {journeyId}",
				Purpose = $"Yiza Ngoku External API Journey One {journeyId}",
				OwnerDriverId = 5391043086274710121,
				JobId = "",
				IsHazardous = false,
				IsOversizeVehicle = false,
				IsOversizeLoad = false,
			};

			CreateJourney newJourney = new CreateJourney { Journey = journey };

			// Act  
			var result = await client.AddJourneyAsync(newJourney);

			// Assert			
			Assert.IsNotNull(result);
		}

		/// <summary>
		/// Ints the tests client journey client add journey asynchronous basic.
		/// </summary>
		/// <returns></returns>
		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_JourneyClient_AddJourneyAsync_Basic()
		{
			// Arrange  
			IJourneysClient client = new JourneysClient(_apiUrl, _idServerResourceOwnerClientSettings);
			client.GetCorrelationId = () => { return _correlationId; };
			long journeyId = IdentityGenerator.Generate64Bit();
			Journey journey = new Journey
			{
				GroupId = -3502972875755389865,
				Description = $"Yiza Ngoku External API Journey One {journeyId}",
				Purpose = $"Yiza Ngoku External API Journey One {journeyId}",
				JobId = "",
				IsHazardous = false,
				IsOversizeVehicle = false,
				IsOversizeLoad = false,
			};

			CreateJourney newJourney = new CreateJourney { Journey = journey };

			// Act  
			var result = await client.AddJourneyAsync(newJourney);

			// Assert
			Assert.IsNotNull(result);
		}

		/// <summary>
		/// Ints the tests client journey client add journey asynchronous.
		/// </summary>
		/// <returns></returns>
		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_JourneyClient_AddJourneyAsync()
		{
			// Arrange  
			IJourneysClient client = new JourneysClient(_apiUrl, _idServerResourceOwnerClientSettings);
			client.GetCorrelationId = () => { return _correlationId; };
			long journeyId = IdentityGenerator.Generate64Bit();
			Journey journey = new Journey
			{
				GroupId = -3502972875755389865,
				SiteId = 5481198413424238674,
				Description = $"Yiza Ngoku External API Journey One {journeyId}",
				Purpose = $"Yiza Ngoku External API Journey One {journeyId}",
				OwnerDriverId = 5391043086274710121,
				JobId = "",
				IsHazardous = false,
				IsOversizeVehicle = false,
				IsOversizeLoad = false,
			};

			CreateJourney newJourney = new CreateJourney { Journey = journey };

			List<JourneyAsset> assetList = new List<JourneyAsset>
			{
				new JourneyAsset {AssetId = -6177754749965323802},
				new JourneyAsset {AssetId = -7230181143451827110}
			};
			newJourney.JourneyAssets = assetList;

			List<JourneyAssetDriver> assetDrivers = new List<JourneyAssetDriver>
			{
				new JourneyAssetDriver
				{
					AssetId = -6177754749965323802,
					DriverId = 6460949734141936482
				},
				new JourneyAssetDriver
				{
					AssetId = -7230181143451827110,
					DriverId = -8611235146110715701
				}
			};
			newJourney.JourneyAssetDrivers = assetDrivers;

			List<JourneyAssetExternalPassenger> externalPassengers = new List<JourneyAssetExternalPassenger>
			{
				new JourneyAssetExternalPassenger
				{
					AssetId = -7230181143451827110,
					PassengerName = "Libo Mbiza",
					Email = "libo@gmail.com",
					MobileNumber = "+27 76 456 8793"
				},
				new JourneyAssetExternalPassenger
				{
					AssetId = -7230181143451827110,
					PassengerName = "Bubu Mbiza",
					Email = "bubu@gmail.com",
					MobileNumber = "+27 82 456 8793"
				}
			};
			newJourney.JourneyAssetExternalPassengers = externalPassengers;

			var routeId = -7533041629094890465;
			JourneyRoute journeyRoute = new JourneyRoute
			{
				RouteId = routeId.ToString(),
				DepartureDateTime = DateTimeOffset.UtcNow.AddDays(2),
			};
			newJourney.JourneyRoute = journeyRoute;

			// Act  
			var result = await client.AddJourneyAsync(newJourney);

			// Assert
			Assert.IsNotNull(result);
		}

		/// <summary>
		/// Ints the tests client journey client get journey asynchronous.
		/// </summary>
		/// <returns></returns>
		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_JourneyClient_GetJourneyAsync()
		{
			// Arrange  
			IJourneysClient client = new JourneysClient(_apiUrl, _idServerResourceOwnerClientSettings);
			client.GetCorrelationId = () => { return _correlationId; };
			long journeyId = 5649381434703158952;

			// Act  
			var results = await client.GetJourneyAsync(journeyId);

			// Assert 
			Assert.IsNotNull(results);
		}

		/// <summary>
		/// Ints the tests client journey client get route list asynchronous.
		/// </summary>
		/// <returns></returns>
		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_JourneyClient_GetRouteListAsync()
		{
			// Arrange  
			IJourneysClient client = new JourneysClient(_apiUrl, _idServerResourceOwnerClientSettings);
			client.GetCorrelationId = () => { return _correlationId; };
			long groupId = -3502972875755389865;

			// Act  
			var results = await client.GetRouteListAsync(groupId);

			// Assert 
			Assert.IsNotNull(results);
		}

		/// <summary>
		/// Ints the tests client journey client get journey progress asynchronous.
		/// </summary>
		/// <returns></returns>
		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_JourneyClient_GetJourneyProgressAsync()
		{
			// Arrange  
			IJourneysClient client = new JourneysClient(_apiUrl, _idServerResourceOwnerClientSettings);
			client.GetCorrelationId = () => { return _correlationId; };
			long journeyId = -625956753382140555;

			// Act  
			var results = await client.GetJourneyProgressAsync(journeyId);

			// Assert 
			Assert.IsNotNull(results);
			Assert.AreEqual(journeyId.ToString(), results.JourneyId);
		}

		/// <summary>
		/// Ints the tests client journey client get journey in progress current status asynchronous.
		/// </summary>
		/// <returns></returns>
		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_JourneyClient_GetJourneyInProgressCurrentStatusAsync()
		{
			// Arrange  
			IJourneysClient client = new JourneysClient(_apiUrl, _idServerResourceOwnerClientSettings);
			client.GetCorrelationId = () => { return _correlationId; };
			long groupId = -3502972875755389865;

			// Act  
			var results = await client.GetJourneyInProgressCurrentStatusAsync(groupId);

			// Assert 
			Assert.IsNotNull(results);
		}
	}
}
