using MiX.Integrate.API.Client.Tests;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MiX.Integrate.Shared.Entities.Groups;
using System.Threading.Tasks;
using System;
using Shouldly;

namespace MiX.Integrate.Api.Client.Tests.IntegrationTests
{
	[TestClass]
	public class IntTests_Client_GroupsClient
	{
		#region startup
		// Dev data  
		private static string _apiUrl = Main.Configuration["appSettings:BaseUri"];
		private static long _accountId = Convert.ToInt64(Main.Configuration["appSettings:AccountId"]);
		private static long _groupId = Convert.ToInt64(Main.Configuration["appSettings:GroupId"]);
		private static long _organisationGroupId = Convert.ToInt64(Main.Configuration["appSettings:OrganisationGroupId"]);
		private static long _siteId = Convert.ToInt64(Main.Configuration["appSettings:SiteId"]);

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
		public async Task IntTests_Client_GroupsClient_Get()
		{
			// Arrange  
			IGroupsClient _client = new GroupsClient(_apiUrl, _idServerResourceOwnerClientSettings);

			// Act  
			GroupSummary sampleObject = await _client.GetSubGroupsAsync(_groupId);

			// Assert 
			Assert.IsNotNull(sampleObject);
			Assert.IsTrue(sampleObject.GroupId != 0);
			Assert.IsTrue(sampleObject.Name.Length > 0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_GroupsClient_AddSiteAsync()
		{
			//Arrange
			var groupsClient = new GroupsClient(_apiUrl, _idServerResourceOwnerClientSettings, true);
			var siteName = $"IntTests_Client_GroupsClient_AddSiteAsync - DELETE ME {DateTime.UtcNow:yyyyMMddHHmmss}";

			//Act
			var newId = await groupsClient.AddSiteAsync(_organisationGroupId, siteName).ConfigureAwait(false);

			// Assert  
			newId.ShouldNotBe(0);
		}

		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_GroupsClient_AddSite()
		{
			//Arrange
			var groupsClient = new GroupsClient(_apiUrl, _idServerResourceOwnerClientSettings, true);
			var siteName = $"IntTests_Client_GroupsClient_AddSite - DELETE ME {DateTime.UtcNow:yyyyMMddHHmmss}";

			//Act
			var newId = groupsClient.AddSite(_organisationGroupId, siteName);

			// Assert  
			newId.ShouldNotBe(0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_GroupsClient_AddOrganisationSubGroupAsync()
		{
			//Arrange
			var groupsClient = new GroupsClient(_apiUrl, _idServerResourceOwnerClientSettings, true);
			var subgroupName = $"IntTests_Client_GroupsClient_AddOrganisationSubGroupAsync - DELETE ME {DateTime.UtcNow:yyyyMMddHHmmss}";

			//Act
			var newId = await groupsClient.AddOrganisationSubGroupAsync(_organisationGroupId, subgroupName).ConfigureAwait(false);

			// Assert  
			newId.ShouldNotBe(0);
		}

		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_GroupsClient_AddOrganisationSubGroup()
		{
			//Arrange
			var groupsClient = new GroupsClient(_apiUrl, _idServerResourceOwnerClientSettings, true);
			var subgroupName = $"IntTests_Client_GroupsClient_AddOrganisationSubGroup - DELETE ME {DateTime.UtcNow:yyyyMMddHHmmss}";

			//Act
			var newId = groupsClient.AddOrganisationSubGroup(_organisationGroupId, subgroupName);

			// Assert  
			newId.ShouldNotBe(0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_GroupsClient_UpdateGroupNameAsync()
		{
			//Arrange
			var groupsClient = new GroupsClient(_apiUrl, _idServerResourceOwnerClientSettings, false);
			var grpSummary = await groupsClient.GetSubGroupsAsync(_siteId).ConfigureAwait(false);
			var newName = grpSummary.Name + "_ updated _ ";

			//Act
			try
			{
				await groupsClient.UpdateGroupNameAsync(_organisationGroupId, _siteId, newName).ConfigureAwait(false);
				var updSummary = await groupsClient.GetSubGroupsAsync(_siteId).ConfigureAwait(false);
				updSummary.Name.ShouldBe(newName);
			}
			catch (Exception ex)
			{
				Assert.Fail($"Update failed: {ex.Message}");
			}

			//Act
			try
			{
				await groupsClient.UpdateGroupNameAsync(_organisationGroupId, _siteId, grpSummary.Name).ConfigureAwait(false);
				var updSummary = await groupsClient.GetSubGroupsAsync(_siteId).ConfigureAwait(false);
				updSummary.Name.ShouldBe(grpSummary.Name);
			}
			catch (Exception ex)
			{
				Assert.Fail($"Update failed: {ex.Message}");
			}
		}

		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_GroupsClient_UpdateGroupName()
		{
			//Arrange
			var groupsClient = new GroupsClient(_apiUrl, _idServerResourceOwnerClientSettings, false);
			var grpSummary = groupsClient.GetSubGroups(_siteId);
			var newName = grpSummary.Name + "_ updated _ ";

			//Act
			try
			{
				groupsClient.UpdateGroupName(_organisationGroupId, _siteId, newName);
				var updSummary = groupsClient.GetSubGroups(_siteId);
				updSummary.Name.ShouldBe(newName);
			}
			catch (Exception ex)
			{
				Assert.Fail($"Update failed: {ex.Message}");
			}

			//Act
			try
			{
				groupsClient.UpdateGroupName(_organisationGroupId, _siteId, grpSummary.Name);
				var updSummary = groupsClient.GetSubGroups(_siteId);
				updSummary.Name.ShouldBe(grpSummary.Name);
			}
			catch (Exception ex)
			{
				Assert.Fail($"Update failed: {ex.Message}");
			}
		}
	}
}
