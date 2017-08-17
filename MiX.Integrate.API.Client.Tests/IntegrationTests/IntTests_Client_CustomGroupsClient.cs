using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiX.Integrate.Shared.Entities.CustomGroups;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiX.Integrate.Shared;
using MiX.Integrate.API.Client.Tests;

namespace MiX.Integrate.Api.Client.Tests.IntegrationTests
{
	[TestClass]
	public class IntTests_Client_CustomGroupsClient
	{

		private static string _apiUrl = Main.Configuration["appSettings:ApiUrl"];
		private static long _organisationId = Convert.ToInt64(Main.Configuration["appSettings:OrganisationGroupId"]);
		private static long _customDriverGroupId = Convert.ToInt64(Main.Configuration["appSettings:CustomDriverGroupId"]);
		private static long _customVehicleGroupId = Convert.ToInt64(Main.Configuration["appSettings:CustomVehicleGroupId"]);


		private static IdServerResourceOwnerClientSettings _idServerSettings;

		[ClassInitialize()]
		public static void ClassInit(TestContext context)
		{
			_idServerSettings = new IdServerResourceOwnerClientSettings()
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

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_CustomGroupsClient_GetAll()
		{
			//Arrange
			var customGroupsClient = new CustomGroupsClient(_apiUrl, _idServerSettings, false);

			//Act
			var groups = await customGroupsClient.GetAllAsync(_organisationId).ConfigureAwait(false);

			// Assert  
			groups.ShouldNotBeNull();
			groups.ShouldBeOfType<List<CustomGroup>>();
			groups.Count.ShouldBePositive();
		}


		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_CustomGroupsClient_GetById()
		{
			//Arrange
			var customGroupsClient = new CustomGroupsClient(_apiUrl, _idServerSettings, false);

			//Act
			var groupDetails = await customGroupsClient.GetByIdAsync(_organisationId, _customVehicleGroupId).ConfigureAwait(false);

			// Assert  
			groupDetails.ShouldNotBeNull();
			groupDetails.Name.ShouldNotBeNullOrWhiteSpace();
			groupDetails.IsDriverGroup.ShouldBeFalse();
			groupDetails.Members.Count.ShouldBePositive();
			groupDetails.Members.First().EntityType.ShouldBe(EntityTypes.ASSET);
		}

		[TestMethod, TestCategory("Integration")]
		public async void IntTests_Client_CustomGroupsClient_AddCustomGroup()
		{
			//Arrange
			var customGroupsClient = new CustomGroupsClient(_apiUrl, _idServerSettings, true);
			var newGroup = new CustomGroup($"Integrate API Client Test - DELETE ME {DateTime.UtcNow:yyyyMMddHHmmss}", null, true);

			//Act
			var newId = await customGroupsClient.AddCustomGroupAsync(_organisationId, newGroup).ConfigureAwait(false);

			// Assert  
			newId.ShouldNotBe(0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_CustomGroupsClient_UpdateCustomGroup()
		{
			// Arrange
			var customGroupsClient = new CustomGroupsClient(_apiUrl, _idServerSettings, false);

			// Act   
			var groupDetails = await customGroupsClient.GetByIdAsync(_organisationId, _customVehicleGroupId).ConfigureAwait(false);


			//Assert
			groupDetails.ShouldNotBeNull();
			groupDetails.CustomGroupId = _customVehicleGroupId;

			//Arrange
			var originalName = groupDetails.Name;
			var updatedName = groupDetails.Name + "_Updated";

			var grpUpdated = new CustomGroup(updatedName, groupDetails.Description, groupDetails.IsDriverGroup) { CustomGroupId = groupDetails.CustomGroupId };
			var grpOriginal = new CustomGroup(originalName, groupDetails.Description, groupDetails.IsDriverGroup) { CustomGroupId = groupDetails.CustomGroupId };

			await customGroupsClient.UpdateCustomGroupAsync(_organisationId, grpUpdated).ConfigureAwait(false);
			var updatedDetails = await customGroupsClient.GetByIdAsync(_organisationId, _customVehicleGroupId).ConfigureAwait(false);

			await customGroupsClient.UpdateCustomGroupAsync(_organisationId, grpOriginal).ConfigureAwait(false);
			var restoredDetails = await customGroupsClient.GetByIdAsync(_organisationId, _customVehicleGroupId).ConfigureAwait(false);

			// Assert
			updatedDetails.Name.ShouldBe(updatedName);
			restoredDetails.Name.ShouldBe(originalName);
			updatedDetails.Members.Count.ShouldBe(restoredDetails.Members.Count);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_CustomGroupsClient_AddAndRemoveCustomGroupMembers()
		{
			// Arrange  
			var customGroupsClient = new CustomGroupsClient(_apiUrl, _idServerSettings, false);

			// Act   
			var group = await customGroupsClient.GetByIdAsync(_organisationId, _customDriverGroupId).ConfigureAwait(false);

			// Assert 
			group.ShouldNotBeNull();
			group.CustomGroupId.ShouldBe(_customDriverGroupId);
			group.Members.ShouldNotBeNull();
			group.Members.Count.ShouldBePositive();
			group.Members.First().EntityType.ShouldBe(EntityTypes.DRIVER);


			//Arrange
			var driverId = group.Members.First().EntityId;

			//Act
			await customGroupsClient.RemoveMembersAsync(_organisationId, _customDriverGroupId, EntityTypes.DRIVER, new[] { driverId }).ConfigureAwait(false);
			var grpRemoved = await customGroupsClient.GetByIdAsync(_organisationId, _customDriverGroupId).ConfigureAwait(false);
			await customGroupsClient.AddMembersAsync(_organisationId, _customDriverGroupId, EntityTypes.DRIVER, new[] { driverId }).ConfigureAwait(false);
			var grpRestored = await customGroupsClient.GetByIdAsync(_organisationId, _customDriverGroupId).ConfigureAwait(false);

			//Assert
			grpRemoved.ShouldNotBeNull();
			grpRemoved.Name.ShouldBe(group.Name);
			grpRemoved.Description.ShouldBe(group.Description);
			grpRemoved.CustomGroupId.ShouldBe(group.CustomGroupId);
			grpRemoved.Members.ShouldNotBeNull();
			grpRemoved.Members.First().EntityType.ShouldBe(EntityTypes.DRIVER);
			grpRemoved.Members.Count.ShouldBe(group.Members.Count - 1);

			grpRestored.ShouldNotBeNull();
			grpRestored.ShouldBeOfType<CustomGroupDetails>();
			grpRestored.Name.ShouldBe(group.Name);
			grpRestored.Description.ShouldBe(group.Description);
			grpRestored.CustomGroupId.ShouldBe(group.CustomGroupId);
			grpRestored.Members.ShouldNotBeNull();
			grpRestored.Members.First().EntityType.ShouldBe(EntityTypes.DRIVER);
			grpRestored.Members.Count.ShouldBe(group.Members.Count);
		}



	}
}
