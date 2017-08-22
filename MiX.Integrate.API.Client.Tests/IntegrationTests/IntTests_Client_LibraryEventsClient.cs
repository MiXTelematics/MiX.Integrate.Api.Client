using System; 
using System.Collections.Generic;
using System.Threading.Tasks;
using MiX.Integrate.API.Client.Tests;


using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;

namespace MiX.Integrate.Api.Client.Tests.IntegrationTests
{
	[TestClass]
	public class IntTests_Client_LibraryEventsClient
	{
		#region startup 

		string _correlationId = "IntTest@" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");


		// Dev data  
		private static string _apiUrl = Main.Configuration["appSettings:ApiUrl"];
		private static List<long> _groupIds = Main.Configuration["appSettings:GroupIds"].Split(',').Select(n => Convert.ToInt64(n)).ToList();

		private static IdServerResourceOwnerClientSettings _idServerResourceOwnerClientSettings;

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
		}

		[ClassCleanup()]
		public static void ClassCleanup() { }

		#endregion

		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_LibraryEventsClient_GetAllLibraryEvents()
		{
			// Arrange   
			ILibraryEventsClient _client = new LibraryEventsClient(_apiUrl, _idServerResourceOwnerClientSettings, true);
			_client.GetCorrelationId = () => { return _correlationId; };

			// Act  


			var results = _client.GetAllLibraryEvents(_groupIds.First());

			// Assert 
			Assert.IsNotNull(results);
			Assert.IsTrue(results.Count > 0);
			Assert.IsTrue(results[0].Id != 0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_LibraryEventsClient_GetAllLibraryEventsAsync()
		{
			// Arrange   
			ILibraryEventsClient _client = new LibraryEventsClient(_apiUrl, _idServerResourceOwnerClientSettings, true);
			_client.GetCorrelationId = () => { return _correlationId; };

			// Act  


			var results = await _client.GetAllLibraryEventsAsync(_groupIds.First());

			// Assert 
			Assert.IsNotNull(results);
			Assert.IsTrue(results.Count > 0);
			Assert.IsTrue(results[0].Id != 0);
		}
	}
}
