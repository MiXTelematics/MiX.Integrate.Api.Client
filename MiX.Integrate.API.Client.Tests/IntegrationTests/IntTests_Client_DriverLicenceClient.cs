using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using MiX.Integrate.API.Client.Tests;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiX.Integrate.Shared.Entities.Drivers;
using Shouldly;

namespace MiX.Integrate.Api.Client.Tests.IntegrationTests
{
	[TestClass]
	public class IntTests_Client_DriverLicenceClient
	{
		#region startup 
		// Dev data  
		private static string _apiUrl = Main.Configuration["appSettings:BaseUri"];
		private static long _accountId = Convert.ToInt64(Main.Configuration["appSettings:AccountId"]);
		private static long _orgGroupId = Convert.ToInt64(Main.Configuration["appSettings:OrganisationGroupId"]);
		private static long _driverId = Convert.ToInt64(Main.Configuration["appSettings:DriverId"]);
		private static long _assetId = Convert.ToInt64(Main.Configuration["appSettings:AssetId"]);
		private static int _licenceCategoryId = 5;

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

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_DriverLicenceClient_GetDriverLicenceByIdAsync()
		{
			// Arrange  
			IDriverLicenceClient _client = new DriverLicenceClient(_apiUrl, _idServerResourceOwnerClientSettings);

			// Act  
			DriverLicence item = await _client.GetDriverLicenceByIdAsync(_orgGroupId, _driverId, _licenceCategoryId);

			// Assert  
			Assert.IsNotNull(item);
			Assert.IsTrue(item is DriverLicence);
			Assert.IsTrue(item.DriverId == _driverId);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_DriverLicenceClient_GetDriverLicencesByDriverIdAsync()
		{
			// Arrange  
			IDriverLicenceClient _client = new DriverLicenceClient(_apiUrl, _idServerResourceOwnerClientSettings);

			// Act  
			IList<DriverLicence> items = await _client.GetDriverLicencesByDriverIdAsync(_orgGroupId, _driverId);

			// Assert  
			Assert.IsNotNull(items);
			Assert.IsTrue(items is List<DriverLicence>);
			Assert.IsTrue(items.Count > 0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_DriverLicenceClient_GetDriverLicenceCategoriesAsync()
		{
			// Arrange  
			IDriverLicenceClient _client = new DriverLicenceClient(_apiUrl, _idServerResourceOwnerClientSettings);

			// Act  
			IList<LicenceCategory> items = await _client.GetDriverLicenceCategoriesAsync(_orgGroupId, _driverId);

			// Assert  
			Assert.IsNotNull(items);
			Assert.IsTrue(items is List<LicenceCategory>);
			Assert.IsTrue(items.Count > 0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_DriverLicenceClient_AddUpdateDelete()
		{
			// Arrange
			IDriverLicenceClient _client = new DriverLicenceClient(_apiUrl, _idServerResourceOwnerClientSettings);

			string newLicenceNumber = "TestNo";
			string updatedLicenceNumber = "TestNo-Updated";

			// Act - get original cert details
			var categoryTypes = await _client.GetDriverLicenceCategoriesAsync(_orgGroupId, _driverId).ConfigureAwait(false);
			var driverLicenses = await _client.GetDriverLicencesByDriverIdAsync(_orgGroupId, _driverId).ConfigureAwait(false);

			//Assert 
			categoryTypes.Count.ShouldBePositive();
			driverLicenses.Count.ShouldBePositive();

			// Act 
			var categoryTypesUsed = driverLicenses.Select(o => o.LicenceCategoryId).Distinct().ToList<int>();
			var categoryTypesNotUsed = categoryTypes.Select(o => o.LicenceCategoryId).Where(o => o >= 0).Distinct().ToList<int>().Where(o => !categoryTypesUsed.Contains(o)).ToList<int>();

			//Assert 
			categoryTypesUsed.Count.ShouldBePositive();
			categoryTypesNotUsed.Count.ShouldBePositive();

			// Arrange
			int categoryTypeId = categoryTypesNotUsed[0];
			DriverLicence newLicense = new DriverLicence()
			{
				DriverId = _driverId,
				LicenceCategoryId = categoryTypeId,
				LicenceCode = "A",
				LicenceCodeCountry = "ZA",
				LicenceNumber = newLicenceNumber,
				IssuedState = "",
				Obtained = DateTime.UtcNow,
				Expires = DateTime.UtcNow.AddYears(5)
			};

			//Act - add new license
			await _client.AddDriverLicenceAsync(_orgGroupId, newLicense).ConfigureAwait(false);
			DriverLicence confirmAddLicense = await _client.GetDriverLicenceByIdAsync(_orgGroupId, _driverId, categoryTypeId).ConfigureAwait(false);

			//Assert 
			confirmAddLicense.ShouldNotBeNull();
			confirmAddLicense.DriverId.ShouldBe(_driverId);
			confirmAddLicense.LicenceCategoryId.ShouldBe(categoryTypeId);
			confirmAddLicense.LicenceNumber.ShouldBe(newLicenceNumber);

			//Act - update new license
			newLicense.LicenceNumber = updatedLicenceNumber;
			await _client.UpdateDriverLicenceAsync(_orgGroupId, newLicense).ConfigureAwait(false);
			DriverLicence confirmUpdateLicense = await _client.GetDriverLicenceByIdAsync(_orgGroupId, _driverId, categoryTypeId).ConfigureAwait(false);

			//Assert 
			confirmUpdateLicense.ShouldNotBeNull();
			confirmUpdateLicense.DriverId.ShouldBe(_driverId);
			confirmUpdateLicense.LicenceCategoryId.ShouldBe(categoryTypeId);
			confirmUpdateLicense.LicenceNumber.ShouldBe(updatedLicenceNumber);

			//Act - delete new license
			await _client.DeleteDriverLicenceAsync(_orgGroupId, _driverId, categoryTypeId).ConfigureAwait(false);
			var newDriverLicenses = await _client.GetDriverLicencesByDriverIdAsync(_orgGroupId, _driverId).ConfigureAwait(false);

			//Assert 
			newDriverLicenses.ShouldNotBeNull();
			newDriverLicenses.Count.ShouldBe(driverLicenses.Count);
		}

	}
}
