using System;
using MiX.Integrate.API.Client.Tests;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Shouldly;

namespace MiX.Integrate.Api.Client.Tests
{
	[TestClass]
	public class IntTests_Client_TripsClient
	{
		#region startup 
		// Dev data  
		private static string _apiUrl = Main.Configuration["appSettings:ApiUrl"];
		private static List<long> _assetIds = new List<long>() { 1, 2, 3 };
		private static List<long> _groupIds = new List<long>() { 1, 2, 3 };
		private static List<long> _driverIds = new List<long>() { 1, 2, 3 };
		private static List<long> _tripIds = new List<long>() { 1, 2, 3 };

		private static IdServerResourceOwnerClientSettings _idServerResourceOwnerClientSettings;
		private static ITripsClient _tripsClient;

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

			_tripsClient = new TripsClient(_apiUrl, _idServerResourceOwnerClientSettings, true);
		}

		[ClassCleanup()]
		public static void ClassCleanup() { }

		#endregion

		#region Async
		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_TripsClient_GetLatestForAssetsAsync()
		{
			// Arrange   

			// Act  
			//List<Trip>
			var Trips = await _tripsClient.GetLatestForAssetsAsync(_assetIds, 10, DateTime.Now.AddHours(-3));

			// Assert 
			Assert.IsNotNull(Trips);
			Assert.IsTrue(Trips.Count > 0);
			Assert.IsTrue(Trips[0].AssetId != 0);
			Trips[0].TripId.ShouldNotBe(0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_TripsClient_GetLatestForDriversAsync()
		{
			// Arrange   

			// Act  
			//List<Trip>
			var Trips = await _tripsClient.GetLatestForDriversAsync(_driverIds, 10, DateTime.Now.AddHours(-3));

			// Assert 
			Assert.IsNotNull(Trips);
			Assert.IsTrue(Trips.Count > 0);
			Assert.IsTrue(Trips[0].AssetId != 0);
			Trips[0].TripId.ShouldNotBe(0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_TripsClient_GetLatestForGroupsAsync()
		{
			// Arrange   

			// Act  
			//List<Trip>
			var Trips = await _tripsClient.GetLatestForGroupsAsync(_groupIds, "Asset", 10, DateTime.Now.AddHours(-3));

			// Assert 
			Assert.IsNotNull(Trips);
			Assert.IsTrue(Trips.Count > 0);
			Assert.IsTrue(Trips[0].AssetId != 0);
			Trips[0].TripId.ShouldNotBe(0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_TripsClient_GetRangeForAssetsAsync()
		{
			// Arrange   

			// Act  
			//List<Trip>
			var Trips = await _tripsClient.GetRangeForAssetsAsync(_assetIds, DateTime.Now.AddHours(-3), DateTime.Now);

			// Assert 
			Assert.IsNotNull(Trips);
			Assert.IsTrue(Trips.Count > 0);
			Assert.IsTrue(Trips[0].AssetId != 0);
			Trips[0].TripId.ShouldNotBe(0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_TripsClient_GetRangeForDriversAsync()
		{
			// Arrange   

			// Act  
			//List<Trip>
			var Trips = await _tripsClient.GetRangeForDriversAsync(_driverIds, DateTime.Now.AddHours(-3), DateTime.Now);

			// Assert 
			Assert.IsNotNull(Trips);
			Assert.IsTrue(Trips.Count > 0);
			Assert.IsTrue(Trips[0].AssetId != 0);
			Trips[0].TripId.ShouldNotBe(0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_TripsClient_GetRangeForGroupsAsync()
		{
			// Arrange   

			// Act  
			//List<Trip>
			var Trips = await _tripsClient.GetRangeForGroupsAsync(_groupIds, "Asset", DateTime.Now.AddHours(-3), DateTime.Now);

			// Assert 
			Assert.IsNotNull(Trips);
			Assert.IsTrue(Trips.Count > 0);
			Assert.IsTrue(Trips[0].AssetId != 0);
			Trips[0].TripId.ShouldNotBe(0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_TripsClient_GetSinceForAssetsAsync()
		{
			// Arrange   

			// Act  
			//List<Trip>
			var Trips = await _tripsClient.GetSinceForAssetsAsync(_assetIds, DateTime.Now.AddHours(-3));

			// Assert 
			Assert.IsNotNull(Trips);
			Assert.IsTrue(Trips.Count > 0);
			Assert.IsTrue(Trips[0].AssetId != 0);
			Trips[0].TripId.ShouldNotBe(0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_TripsClient_GetSinceForDriversAsync()
		{
			// Arrange   

			// Act  
			//List<Trip>
			var Trips = await _tripsClient.GetSinceForDriversAsync(_driverIds, DateTime.Now.AddHours(-3));

			// Assert 
			Assert.IsNotNull(Trips);
			Assert.IsTrue(Trips.Count > 0);
			Assert.IsTrue(Trips[0].AssetId != 0);
			Trips[0].TripId.ShouldNotBe(0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_TripsClient_GetSinceForGroupsAsync()
		{
			// Arrange   

			// Act  
			//List<Trip>
			var Trips = await _tripsClient.GetSinceForGroupsAsync(_groupIds, "Asset", DateTime.Now.AddHours(-3));

			// Assert 
			Assert.IsNotNull(Trips);
			Assert.IsTrue(Trips.Count > 0);
			Assert.IsTrue(Trips[0].AssetId != 0);
			Trips[0].TripId.ShouldNotBe(0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_TripsClient_GetSinceForGroupsAsync_NoGroupIds()
		{
			// Arrange   

			Exception exAsync = await Should.ThrowAsync<HttpClientException>(async () =>
			{
				await _tripsClient.GetSinceForGroupsAsync(new List<long>(), "Asset", DateTime.Now.AddHours(-3)).ConfigureAwait(false);
			});

			// Assert  
			exAsync.ShouldNotBeNull();
			exAsync.Message.ShouldContain("ArgumentException: GroupIds list is empty");
		}

		#endregion

		#region Sync

		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_TripsClient_GetLatestForAssets()
		{
			// Arrange   

			// Act  
			//List<Trip>
			var Trips = _tripsClient.GetLatestForAssets(_assetIds, 10, DateTime.Now.AddHours(-3));

			// Assert 
			Assert.IsNotNull(Trips);
			Assert.IsTrue(Trips.Count > 0);
			Assert.IsTrue(Trips[0].AssetId != 0);
			Trips[0].TripId.ShouldNotBe(0);
		}

		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_TripsClient_GetLatestForDrivers()
		{
			// Arrange   

			// Act  
			//List<Trip>
			var Trips = _tripsClient.GetLatestForDrivers(_driverIds, 10, DateTime.Now.AddHours(-3));

			// Assert 
			Assert.IsNotNull(Trips);
			Assert.IsTrue(Trips.Count > 0);
			Assert.IsTrue(Trips[0].AssetId != 0);
			Trips[0].TripId.ShouldNotBe(0);
		}

		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_TripsClient_GetLatestForGroups()
		{
			// Arrange   

			// Act  
			//List<Trip>
			var Trips = _tripsClient.GetLatestForGroups(_groupIds, "Asset", 10, DateTime.Now.AddHours(-3));

			// Assert 
			Assert.IsNotNull(Trips);
			Assert.IsTrue(Trips.Count > 0);
			Assert.IsTrue(Trips[0].AssetId != 0);
			Trips[0].TripId.ShouldNotBe(0);
		}

		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_TripsClient_GetRangeForAssets()
		{
			// Arrange   

			// Act  
			//List<Trip>
			var Trips = _tripsClient.GetRangeForAssets(_assetIds, DateTime.Now.AddHours(-3), DateTime.Now);

			// Assert 
			Assert.IsNotNull(Trips);
			Assert.IsTrue(Trips.Count > 0);
			Assert.IsTrue(Trips[0].AssetId != 0);
			Trips[0].TripId.ShouldNotBe(0);
		}

		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_TripsClient_GetRangeForDrivers()
		{
			// Arrange   

			// Act  
			//List<Trip>
			var Trips = _tripsClient.GetRangeForDrivers(_driverIds, DateTime.Now.AddHours(-3), DateTime.Now);

			// Assert 
			Assert.IsNotNull(Trips);
			Assert.IsTrue(Trips.Count > 0);
			Assert.IsTrue(Trips[0].AssetId != 0);
			Trips[0].TripId.ShouldNotBe(0);
		}

		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_TripsClient_GetRangeForGroups()
		{
			// Arrange   

			// Act  
			//List<Trip>
			var Trips = _tripsClient.GetRangeForGroups(_groupIds, "Asset", DateTime.Now.AddHours(-3), DateTime.Now);

			// Assert 
			Assert.IsNotNull(Trips);
			Assert.IsTrue(Trips.Count > 0);
			Assert.IsTrue(Trips[0].AssetId != 0);
			Trips[0].TripId.ShouldNotBe(0);
		}

		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_TripsClient_GetSinceForAssets()
		{
			// Arrange   

			// Act  
			//List<Trip>
			var Trips = _tripsClient.GetSinceForAssets(_assetIds, DateTime.Now.AddHours(-3));

			// Assert 
			Assert.IsNotNull(Trips);
			Assert.IsTrue(Trips.Count > 0);
			Assert.IsTrue(Trips[0].AssetId != 0);
			Trips[0].TripId.ShouldNotBe(0);
		}

		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_TripsClient_GetSinceForDrivers()
		{
			// Arrange   

			// Act  
			//List<Trip>
			var Trips = _tripsClient.GetSinceForDrivers(_driverIds, DateTime.Now.AddHours(-3));

			// Assert 
			Assert.IsNotNull(Trips);
			Assert.IsTrue(Trips.Count > 0);
			Assert.IsTrue(Trips[0].AssetId != 0);
			Trips[0].TripId.ShouldNotBe(0);
		}

		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_TripsClient_GetSinceForGroups()
		{
			// Arrange 

			// Act  
			//List<Trip>
			var Trips = _tripsClient.GetSinceForGroups(_groupIds, "Asset", DateTime.Now.AddHours(-3));

			// Assert 
			Assert.IsNotNull(Trips);
			Assert.IsTrue(Trips.Count > 0);
			Assert.IsTrue(Trips[0].AssetId != 0);
			Trips[0].TripId.ShouldNotBe(0);
		}

		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_TripsClient_GetSinceForGroups_NoGroupIds()
		{
			// Arrange   

			Exception exSync = Should.Throw<HttpClientException>(() =>
			{
				_tripsClient.GetSinceForGroups(new List<long>(), "Asset", DateTime.Now.AddHours(-3));
			});

			// Assert 
			exSync.ShouldNotBeNull();
			exSync.Message.ShouldContain("ArgumentException: GroupIds list is empty");
		}

		#endregion

	}
}
