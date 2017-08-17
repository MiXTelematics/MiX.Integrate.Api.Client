using System;
using MiX.Integrate.API.Client.Tests;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MiX.Integrate.Shared.Entities.Events;
using System.Linq;
using Shouldly;

namespace MiX.Integrate.Api.Client.Tests
{
	[TestClass]
	public class IntTests_Client_EventsClient
	{
		#region startup 
		// Dev data  
		private static string _apiUrl = Main.Configuration["appSettings:ApiUrl"];
		private static long _accountId = Convert.ToInt64(Main.Configuration["appSettings:AccountId"]);
		private static List<long> _assetIds = Main.Configuration["appSettings:AssetIds"].Split(',').Select(n => Convert.ToInt64(n)).ToList();
		private static List<long> _groupIds = Main.Configuration["appSettings:GroupIds"].Split(',').Select(n => Convert.ToInt64(n)).ToList();
		private static List<long> _driverIds = Main.Configuration["appSettings:DriverIds"].Split(',').Select(n => Convert.ToInt64(n)).ToList();
		private static List<long> _eventIds = Main.Configuration["appSettings:EventIds"].Split(',').Select(n => Convert.ToInt64(n)).ToList();

		private static IdServerResourceOwnerClientSettings _idServerResourceOwnerClientSettings;
		private static IdServerResourceOwnerClientSettings _idServerResourceOwnerClientSettings_NotAuth;

		[ClassInitialize()]
		public static void ClassInit(TestContext context)
		{
			_idServerResourceOwnerClientSettings = new IdServerResourceOwnerClientSettings()
			{
				BaseAddress = Main.Configuration["appSettings:IdentityServerBaseAddress"],
				ClientId = Main.Configuration["appSettings:IdentityServerClientId"],
				ClientSecret = Main.Configuration["appSettings:IdentityServerClientSecret"],
				UserName = Main.Configuration["appSettings:IdentityServerUserName"],
				Password = Main.Configuration["appSettings:IdentityServerPassword"],
				Scopes = Main.Configuration["appSettings:IdentityServerScopes"]

			};

			_idServerResourceOwnerClientSettings_NotAuth = new IdServerResourceOwnerClientSettings()
			{
				BaseAddress = Main.Configuration["appSettings:IdentityServerBaseAddress"],
				ClientId = Main.Configuration["appSettings:IdentityServerClientId"],
				ClientSecret = string.Empty,
				UserName = Main.Configuration["appSettings:IdentityServerUserName"],
				Password = Main.Configuration["appSettings:IdentityServerPassword"],
				Scopes = Main.Configuration["appSettings:IdentityServerScopes"]
			};
		}

		[ClassCleanup()]
		public static void ClassCleanup() { }

		#endregion

		#region must succeed

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_EventsClient_GetLatestForAssetsAsync()
		{
			// Arrange   
			IEventsClient _client = new EventsClient(_apiUrl, _idServerResourceOwnerClientSettings, true);
			// Act  
			//List<Event>
			var Events = await _client.GetLatestForAssetsAsync(_assetIds, 10, DateTime.Now.AddHours(-3)).ConfigureAwait(false);

			// Assert 
			Assert.IsNotNull(Events);
			Assert.IsTrue(Events.Count > 0);
			Assert.IsTrue(Events[0].AssetId != 0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_EventsClient_GetLatestForDriversAsync()
		{
			// Arrange   
			IEventsClient _client = new EventsClient(_apiUrl, _idServerResourceOwnerClientSettings, true);

			// Act  
			//List<Event>
			var Events = await _client.GetLatestForDriversAsync(_driverIds, 10, DateTime.Now.AddHours(-3)).ConfigureAwait(false);

			// Assert 
			Assert.IsNotNull(Events);
			Assert.IsTrue(Events.Count > 0);
			Assert.IsTrue(Events[0].AssetId != 0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_EventsClient_GetLatestForGroupsAsync()
		{
			// Arrange   
			IEventsClient _client = new EventsClient(_apiUrl, _idServerResourceOwnerClientSettings, true);

			// Act  
			//List<Event>
			var Events = await _client.GetLatestForGroupsAsync(_groupIds, "Asset", 10, DateTime.Now.AddHours(-3)).ConfigureAwait(false);

			// Assert 
			Assert.IsNotNull(Events);
			Assert.IsTrue(Events.Count > 0);
			Assert.IsTrue(Events[0].AssetId != 0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_EventsClient_GetRangeForAssetsAsync()
		{
			// Arrange   
			IEventsClient _client = new EventsClient(_apiUrl, _idServerResourceOwnerClientSettings, true);

			// Act  
			//List<Event>
			var Events = await _client.GetRangeForAssetsAsync(_assetIds, DateTime.Now.AddHours(-3), DateTime.Now).ConfigureAwait(false);

			// Assert 
			Assert.IsNotNull(Events);
			Assert.IsTrue(Events.Count > 0);
			Assert.IsTrue(Events[0].AssetId != 0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_EventsClient_GetRangeForDriversAsync()
		{
			// Arrange   
			IEventsClient _client = new EventsClient(_apiUrl, _idServerResourceOwnerClientSettings, true);

			// Act  
			//List<Event>
			var Events = await _client.GetRangeForDriversAsync(_driverIds, DateTime.Now.AddHours(-3), DateTime.Now).ConfigureAwait(false);

			// Assert 
			Assert.IsNotNull(Events);
			Assert.IsTrue(Events.Count > 0);
			Assert.IsTrue(Events[0].AssetId != 0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_EventsClient_GetRangeForGroupsAsync()
		{
			// Arrange   
			IEventsClient _client = new EventsClient(_apiUrl, _idServerResourceOwnerClientSettings, true);

			// Act  
			//List<Event>
			var Events = await _client.GetRangeForGroupsAsync(_groupIds, "Asset", DateTime.Now.AddHours(-3), DateTime.Now).ConfigureAwait(false);

			// Assert 
			Assert.IsNotNull(Events);
			Assert.IsTrue(Events.Count > 0);
			Assert.IsTrue(Events[0].AssetId != 0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_EventsClient_GetSinceForAssetsAsync()
		{
			// Arrange   
			IEventsClient _client = new EventsClient(_apiUrl, _idServerResourceOwnerClientSettings, true);

			// Act  
			//List<Event>
			var Events = await _client.GetSinceForAssetsAsync(_assetIds, DateTime.Now.AddHours(-3), 10).ConfigureAwait(false);

			// Assert 
			Assert.IsNotNull(Events);
			Assert.IsTrue(Events.Count > 0);
			Assert.IsTrue(Events[0].AssetId != 0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_EventsClient_GetSinceForDriversAsync()
		{
			// Arrange   
			IEventsClient _client = new EventsClient(_apiUrl, _idServerResourceOwnerClientSettings, true);

			// Act  
			//List<Event>
			var Events = await _client.GetSinceForDriversAsync(_driverIds, DateTime.Now.AddHours(-3), 10).ConfigureAwait(false);

			// Assert 
			Assert.IsNotNull(Events);
			Assert.IsTrue(Events.Count > 0);
			Assert.IsTrue(Events[0].AssetId != 0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_EventsClient_GetSinceForGroupsAsync()
		{
			// Arrange   
			IEventsClient _client = new EventsClient(_apiUrl, _idServerResourceOwnerClientSettings, true);

			// Act  
			//List<Event>
			var Events = await _client.GetSinceForGroupsAsync(_groupIds, "Asset", DateTime.Now.AddHours(-3)).ConfigureAwait(false);

			// Assert 
			Assert.IsNotNull(Events);
			Assert.IsTrue(Events.Count > 0);
			Assert.IsTrue(Events[0].AssetId != 0);
		}

		#endregion

		#region bad login

		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_EventsClient_InvalidClientSettings()
		{
			// Arrange   

			// Act  
			Exception ex = Should.Throw<ArgumentException>(() =>
			{
				IEventsClient _client = new EventsClient(_apiUrl, _idServerResourceOwnerClientSettings_NotAuth, true);
			});

			// Assert
			ex.ShouldNotBeNull();
		}

		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_EventsClient_GetSinceForGroupsAsync_InvalidArgument()
		{
			// Arrange   
			IEventsClient _client = new EventsClient(_apiUrl, _idServerResourceOwnerClientSettings, true);

			// Act    
			Exception ex = Should.Throw<HttpClientException>(async () =>
			{
				var Events = await _client.GetSinceForGroupsAsync(_groupIds, "12", DateTime.Now.AddHours(-3)).ConfigureAwait(false);
			});

			// Assert 
			ex.ShouldNotBeNull();
			ex.Message.ShouldContain("ArgumentException:");
		}

		#endregion

	}
}
