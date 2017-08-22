using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using MiX.Integrate.API.Client.Tests;
using System.Threading.Tasks;
using MiX.Integrate.Shared.Entities.Locations;
using Shouldly;

namespace MiX.Integrate.Api.Client.Tests
{
	[TestClass]
	public class IntTests_Client_LocationsClient
	{
		#region startup 

		string _correlationId = "IntTest@" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

		// Dev data  
		private static string _apiUrl = Main.Configuration["appSettings:ApiUrl"];
		private static long _accountId = Convert.ToInt64(Main.Configuration["appSettings:AccountId"]);
		private static long _groupId = Convert.ToInt64(Main.Configuration["appSettings:GroupId"]);
		private static long _driverId = Convert.ToInt64(Main.Configuration["appSettings:DriverId"]);
		private static long _assetId = Convert.ToInt64(Main.Configuration["appSettings:AssetId"]);
		private static long _lightningLocationsOrganisationGroupId = Convert.ToInt64(Main.Configuration["appSettings:LightningLocationsOrganisationGroupId"]);
		private static long _locationId = Convert.ToInt64(Main.Configuration["appSettings:LocationId"]);
		private static IdServerResourceOwnerClientSettings _idServerResourceOwnerClientSettings;
		private static IdServerResourceOwnerClientSettings _idServerResourceOwnerClientSettings_NotAuth;

		[ClassInitialize()]
		public static void ClassInit(TestContext context)
		{

			_apiUrl = Main.Configuration["appSettings:ApiUrl"];
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

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_LocationsClient_GetAll()
		{
			// Arrange  
			ILocationsClient _client = new LocationsClient(_apiUrl, _idServerResourceOwnerClientSettings);
			_client.GetCorrelationId = () => { return _correlationId; };

			// Act  
			List<Location> items = await _client.GetAllAsync(_lightningLocationsOrganisationGroupId);

			//Assert
			Assert.IsNotNull(items);
			Assert.IsTrue(items is List<Location>);
			Assert.IsTrue(items.Count > 0);
			Assert.IsTrue(items[0].LocationId != 0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_LocationsClient_Get()
		{
			// Arrange  
			ILocationsClient _client = new LocationsClient(_apiUrl, _idServerResourceOwnerClientSettings);
			_client.GetCorrelationId = () => { return _correlationId; };

			// Act  
			Location item = await _client.GetAsync(_locationId);

			//Assert
			Assert.IsNotNull(item);
			Assert.IsTrue(item is Location);
			Assert.IsTrue(item.LocationId != 0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Logic_LocationsManager_AddUpdateDelete()
		{
			// Arrange    
			ILocationsClient client = new LocationsClient(_apiUrl, _idServerResourceOwnerClientSettings);
			//long testLocationId = -960811461965230592;

			//Act 
			IList<Location> locations = await client.GetAllAsync(_lightningLocationsOrganisationGroupId).ConfigureAwait(false);

			//Assert
			locations.ShouldNotBeNull();
			locations.Count.ShouldBePositive();

			// Arrange
			Location location = await client.GetAsync(locations[0].LocationId).ConfigureAwait(false);
			location.LocationId = 0;
			location.Name = $"Test @ { DateTime.Now.ToString("yyyyMMdd_HHmmss.fff")}";

			// Act  
			long locationId = await client.AddAsync(location, _lightningLocationsOrganisationGroupId).ConfigureAwait(false);

			// Assert 
			locationId.ShouldNotBeNull();
			locationId.ShouldNotBe(0);

			// Act 
			Location newLocation = await client.GetAsync(locationId).ConfigureAwait(false);
			// Assert newLocation.ShouldNotBeNull();
			newLocation.LocationId.ShouldBe(locationId);
			newLocation.Name.ShouldBe(location.Name);
			newLocation.Address.ShouldBe(location.Address);
			newLocation.ShapeType.ShouldBe(location.ShapeType);
			newLocation.ShapeWkt.ShouldBe(location.ShapeWkt);

			// Act 
			newLocation.Name = $"Test Update @  { DateTime.Now.ToString("ss.fff")}";
			await client.UpdateAsync(newLocation, _lightningLocationsOrganisationGroupId).ConfigureAwait(false);
			Location updatedLocation = await client.GetAsync(locationId).ConfigureAwait(false);
			//// Assert
			updatedLocation.ShouldNotBeNull();
			updatedLocation.Name.ShouldBe(newLocation.Name);

			// Act   
			await client.DeleteAsync(_lightningLocationsOrganisationGroupId, locationId).ConfigureAwait(false);
			Location deletedlocation = await client.GetAsync(locationId).ConfigureAwait(false);
			// Assert 
			deletedlocation.ShouldNotBeNull();
			deletedlocation.IsDeleted.ShouldBe(true);
		}

		#region bad login

		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_LocationsClient_Get_InvalidClientSettings()
		{
			// Arrange   

			// Act  
			Exception ex = Should.Throw<ArgumentException>(() =>
			{
				ILocationsClient _client = new LocationsClient(_apiUrl, _idServerResourceOwnerClientSettings_NotAuth);
			});

			// Assert
			ex.ShouldNotBeNull();
		}

		#endregion

	}
}
