using MiX.Integrate.API.Client.Tests;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiX.Integrate.Shared.Entities.Drivers;
using System.Threading.Tasks;
using System;

namespace MiX.Integrate.Api.Client.Tests
{
	[TestClass]
	public class IntTests_Client_DriversClient
	{
		#region startup 
		// Dev data  
		private static string _apiUrl = Main.Configuration["appSettings:BaseUri"];
		private static long _accountId = Convert.ToInt64(Main.Configuration["appSettings:AccountId"]);
		private static long _orgGroupId = Convert.ToInt64(Main.Configuration["appSettings:OrganisationGroupId"]);
		private static long _driverId = Convert.ToInt64(Main.Configuration["appSettings:DriverId"]);
		private static long _assetId = Convert.ToInt64(Main.Configuration["appSettings:AssetId"]);

		private static IdServerResourceOwnerClientSettings _idServerResourceOwnerClientSettings;

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
		}

		[ClassCleanup()]
		public static void ClassCleanup() { }

		#endregion

		#region isTestRequest = false

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_DriversClient_GetAllDriverSummariesAsync()
		{
			// Arrange  
			IDriversClient _client = new DriversClient(_apiUrl, _idServerResourceOwnerClientSettings);

			// Act  
			List<DriverSummary> items = await _client.GetAllDriverSummariesAsync(_orgGroupId);

			// Assert  
			Assert.IsNotNull(items);
			Assert.IsTrue(items is List<DriverSummary>);
			Assert.IsTrue(items.Count > 0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_DriversClient_GetDriverByIdAsync()
		{
			// Arrange  
			IDriversClient _client = new DriversClient(_apiUrl, _idServerResourceOwnerClientSettings);

			// Act  
			Driver item = await _client.GetDriverByIdAsync(_orgGroupId, _driverId);

			// Assert  
			Assert.IsNotNull(item);
			Assert.IsTrue(item is Driver);
			Assert.IsTrue(item.DriverId == _driverId);
			Assert.IsTrue(item.Name.Length > 0);
		}

		#endregion


		#region isTestRequest = true

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_DriversClient_GetAllDriverSummariesAsync_IsTestRequest()
		{
			// Arrange  
			IDriversClient _client = new DriversClient(_apiUrl, _idServerResourceOwnerClientSettings, setTestRequestHeader: true);

			// Act  
			List<DriverSummary> items = await _client.GetAllDriverSummariesAsync(1);

			// Assert  
			Assert.IsNotNull(items);
			Assert.IsTrue(items is List<DriverSummary>);
			Assert.IsTrue(items.Count > 0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_DriversClient_GetDriverByIdAsync_IsTestRequest()
		{
			// Arrange  
			IDriversClient _client = new DriversClient(_apiUrl, _idServerResourceOwnerClientSettings, setTestRequestHeader: true);

			// Act  
			Driver item = await _client.GetDriverByIdAsync(1, 1);

			// Assert  
			Assert.IsNotNull(item);
			Assert.IsTrue(item is Driver);
			Assert.IsTrue(item.DriverId == 1);
			Assert.IsTrue(item.Name.Length > 0);
		}

		#endregion
	}
}
