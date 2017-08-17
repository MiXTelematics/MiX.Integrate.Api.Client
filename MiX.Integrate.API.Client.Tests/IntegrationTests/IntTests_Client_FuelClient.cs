using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiX.Integrate.Shared.Entities.Fuel;
using Shouldly;
using System;
using System.Collections.Generic;
using MiX.Integrate.API.Client.Tests;
using System.Threading.Tasks;

namespace MiX.Integrate.Api.Client.Tests.IntegrationTests
{
	[TestClass]
	public class IntTests_Client_FuelClient
	{

		private static string _apiUrl = Main.Configuration["appSettings:ApiUrl"];
		private static long _organisationId = Convert.ToInt64(Main.Configuration["appSettings:OrganisationGroupId"]);
		private static IdServerResourceOwnerClientSettings _idServerResourceOwnerClientSettings;
		private static DateTime _date2000;
		private static DateTime _dateNow;
		private static FuelClient _fuelClient;


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

			_fuelClient = new FuelClient(_apiUrl, _idServerResourceOwnerClientSettings, true);
			_date2000 = DateTime.SpecifyKind(new DateTime(2000, 1, 1), DateTimeKind.Utc);
			_dateNow = DateTime.UtcNow;

		}

		[ClassCleanup()]
		public static void ClassCleanup() { }

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_FuelClient_GetFuelByDateRangeForGroupAsyncReturnsResults()
		{
			var transactions = await _fuelClient.GetFuelByDateRangeForGroupAsync(_organisationId, _date2000, _dateNow);

			// Assert  
			transactions.ShouldNotBeNull();
			transactions.ShouldBeOfType<List<FuelTransaction>>();
			transactions.Count.ShouldBePositive();
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_FuelClient_GetFuelByDateRangeForGroupAsyncReturnsEmptyResultWhenFromGreaterThanTo()
		{
			var transactions = await _fuelClient.GetFuelByDateRangeForGroupAsync(_organisationId, _dateNow, _date2000);

			// Assert  
			transactions.ShouldNotBeNull();
			transactions.ShouldBeOfType<List<FuelTransaction>>();
			transactions.Count.ShouldBe(0);
		}

		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_FuelClient_GetFuelByDateRangeForGroupReturnsResults()
		{
			var transactions = _fuelClient.GetFuelByDateRangeForGroup(_organisationId, _date2000, _dateNow);

			// Assert  
			transactions.ShouldNotBeNull();
			transactions.ShouldBeOfType<List<FuelTransaction>>();
			transactions.Count.ShouldBePositive();
		}

		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_FuelClient_GetFuelByDateRangeForGroupReturnsEmptyResultWhenFromGreaterThanTo()
		{
			var transactions = _fuelClient.GetFuelByDateRangeForGroup(_organisationId, _dateNow, _date2000);

			// Assert  
			transactions.ShouldNotBeNull();
			transactions.ShouldBeOfType<List<FuelTransaction>>();
			transactions.Count.ShouldBe(0);
		}
	}
}
