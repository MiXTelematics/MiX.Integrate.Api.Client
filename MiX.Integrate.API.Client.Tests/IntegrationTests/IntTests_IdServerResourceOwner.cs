using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using MiX.Integrate.API.Client.Tests;
using System.Threading.Tasks;
using MiX.Integrate.Shared.Entities.Locations;
using Shouldly;
using System.Security;

namespace MiX.Integrate.Api.Client.Tests
{
	[TestClass]
	public class IntTests_IdServerResourceOwner
	{
		#region startup 

		string _correlationId = "IntTest@" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

		// Dev data  
		private static string _apiUrl = Main.Configuration["appSettings:ApiUrl"];

		[ClassInitialize()]
		public static void ClassInit(TestContext context) { }

		[ClassCleanup()]
		public static void ClassCleanup() { }

		#endregion

		[TestMethod, TestCategory("Integration")]
		public void IntTests_IdServerResourceOwner_ValidSettings()
		{
			// Arrange   
			IdServerResourceOwnerClientSettings settings = new IdServerResourceOwnerClientSettings()
			{
				BaseAddress = Main.Configuration["appSettings:IdentityServerBaseAddress"],
				ClientId = Main.Configuration["appSettings:IdentityServerClientId"],
				ClientSecret = Main.Configuration["appSettings:IdentityServerClientSecret"],
				UserName = Main.Configuration["appSettings:IdentityServerUserName"],
				Password = Main.Configuration["appSettings:IdentityServerPassword"],
				Scopes = Main.Configuration["appSettings:IdentityServerScopes"]
			};

			// Act  
			ILocationsClient client = new LocationsClient(_apiUrl, settings);

			// Assert
			client.ShouldNotBeNull();
		}

		[TestMethod, TestCategory("Integration")]
		public void IntTests_IdServerResourceOwner_MissingSettings()
		{
			// Arrange   
			IdServerResourceOwnerClientSettings settings = new IdServerResourceOwnerClientSettings()
			{
				BaseAddress = Main.Configuration["appSettings:IdentityServerBaseAddress"],
				ClientId = Main.Configuration["appSettings:IdentityServerClientId"],
				ClientSecret = string.Empty,
				UserName = Main.Configuration["appSettings:IdentityServerUserName"],
				Password = Main.Configuration["appSettings:IdentityServerPassword"],
				Scopes = Main.Configuration["appSettings:IdentityServerScopes"]
			};

			// Act  
			Exception ex = Should.Throw<ArgumentException>(() =>
			{
				ILocationsClient client = new LocationsClient(_apiUrl, settings);
			});

			// Assert
			ex.ShouldNotBeNull();
		}


		[TestMethod, TestCategory("Integration")]
		public void IntTests_IdServerResourceOwner_InvalidBaseAddress()
		{
			// Arrange
			IdServerResourceOwnerClientSettings settings = new IdServerResourceOwnerClientSettings()
			{
				BaseAddress = "invalidurl",
				ClientId = Main.Configuration["appSettings:IdentityServerClientId"],
				ClientSecret = Main.Configuration["appSettings:IdentityServerClientSecret"],
				UserName = Main.Configuration["appSettings:IdentityServerUserName"],
				Password = Main.Configuration["appSettings:IdentityServerPassword"],
				Scopes = Main.Configuration["appSettings:IdentityServerScopes"]
			};

			// Act  
			Exception ex = Should.Throw<SecurityException>(() =>
			{
				IAssetsClient client = new AssetsClient(_apiUrl, settings, true);
				var asset = client.Get(1);
			});

			// Assert
			ex.ShouldNotBeNull();
		}

		[TestMethod, TestCategory("Integration")]
		public void IntTests_IdServerResourceOwner_InvalidClientId()
		{
			// Arrange
			IdServerResourceOwnerClientSettings settings = new IdServerResourceOwnerClientSettings()
			{
				BaseAddress = Main.Configuration["appSettings:IdentityServerBaseAddress"],
				ClientId = "invalidclientid",
				ClientSecret = Main.Configuration["appSettings:IdentityServerClientSecret"],
				UserName = Main.Configuration["appSettings:IdentityServerUserName"],
				Password = Main.Configuration["appSettings:IdentityServerPassword"],
				Scopes = Main.Configuration["appSettings:IdentityServerScopes"]
			};

			// Act  
			Exception ex = Should.Throw<SecurityException>(() =>
			{
				IAssetsClient client = new AssetsClient(_apiUrl, settings, true);
				var asset = client.Get(1);
			});

			// Assert
			ex.ShouldNotBeNull();
		}

		[TestMethod, TestCategory("Integration")]
		public void IntTests_IdServerResourceOwner_InvalidClientSecret()
		{
			// Arrange   
			IdServerResourceOwnerClientSettings settings = new IdServerResourceOwnerClientSettings()
			{
				BaseAddress = Main.Configuration["appSettings:IdentityServerBaseAddress"],
				ClientId = Main.Configuration["appSettings:IdentityServerClientId"],
				ClientSecret = "incorrectsecret",
				UserName = Main.Configuration["appSettings:IdentityServerUserName"],
				Password = Main.Configuration["appSettings:IdentityServerPassword"],
				Scopes = Main.Configuration["appSettings:IdentityServerScopes"]
			};

			// Act  
			Exception ex = Should.Throw<SecurityException>(() =>
			{
				IAssetsClient client = new AssetsClient(_apiUrl, settings, true);
				var asset = client.Get(1);
			});

			// Assert
			ex.ShouldNotBeNull();
		}
		 
		[TestMethod, TestCategory("Integration")]
		public void IntTests_IdServerResourceOwner_InvalidUserName()
		{
			// Arrange   
			IdServerResourceOwnerClientSettings settings = new IdServerResourceOwnerClientSettings()
			{
				BaseAddress = Main.Configuration["appSettings:IdentityServerBaseAddress"],
				ClientId = Main.Configuration["appSettings:IdentityServerClientId"],
				ClientSecret = Main.Configuration["appSettings:IdentityServerClientSecret"],
				UserName = "invalidusername",
				Password = Main.Configuration["appSettings:IdentityServerPassword"],
				Scopes = Main.Configuration["appSettings:IdentityServerScopes"]
			};

			// Act  
			Exception ex = Should.Throw<SecurityException>(() =>
			{
				IAssetsClient client = new AssetsClient(_apiUrl, settings, true);
				var asset = client.Get(1);
			});

			// Assert
			ex.ShouldNotBeNull();
		}

		[TestMethod, TestCategory("Integration")]
		public void IntTests_IdServerResourceOwner_InvalidScopes()
		{
			// Arrange   
			IdServerResourceOwnerClientSettings settings = new IdServerResourceOwnerClientSettings()
			{
				BaseAddress = Main.Configuration["appSettings:IdentityServerBaseAddress"],
				ClientId = Main.Configuration["appSettings:IdentityServerClientId"],
				ClientSecret = Main.Configuration["appSettings:IdentityServerClientSecret"],
				UserName = Main.Configuration["appSettings:IdentityServerUserName"],
				Password = Main.Configuration["appSettings:IdentityServerPassword"],
				Scopes = "incorrectscopes"
			};

			// Act  
			Exception ex = Should.Throw<SecurityException>(() =>
			{
				IAssetsClient client = new AssetsClient(_apiUrl, settings, true);
				var asset = client.Get(1);
			});

			// Assert
			ex.ShouldNotBeNull();
		}

	}
}
