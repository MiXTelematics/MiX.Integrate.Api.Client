using MiX.Integrate.API.Client.Tests;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MiX.Integrate.Shared.Entities.Groups;
using System.Threading.Tasks;
using System;

namespace MiX.Integrate.Api.Client.Tests
{
	[TestClass]
	public class IntTests_Client_GroupsClient
	{
		#region startup
		// Dev data  
		private static string _apiUrl = Main.Configuration["appSettings:BaseUri"];
		private static long _accountId = Convert.ToInt64(Main.Configuration["appSettings:AccountId"]);
		private static long _groupId = Convert.ToInt64(Main.Configuration["appSettings:GroupId"]);

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
	}
}
