using System.Collections.Generic;
using MiX.Integrate.Shared.Entities.Assets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System;
using MiX.Integrate.API.Client.Tests;

namespace MiX.Integrate.Api.Client.Tests
{
	[TestClass]
	public class IntTests_Client_AssetsClient
	{

		#region startup 

		string _correlationId = "IntTest@" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

		// Dev data  
		private static string _apiUrl = Main.Configuration["appSettings:ApiUrl"];
		private static long _accountId = Convert.ToInt64(Main.Configuration["appSettings:AccountId"]);
		private static long _groupId = Convert.ToInt64(Main.Configuration["appSettings:GroupId"]);
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
		public async Task IntTests_Client_AssetsClient_GetAll()
		{
			// Arrange  
			IAssetsClient _client = new AssetsClient(_apiUrl, _idServerResourceOwnerClientSettings);
			//_client.GetCorrelationId = () => { return IdentityGenerator.Generate64Bit().ToString(); };
			_client.GetCorrelationId = () => { return _correlationId; };

			// Act  
			List<Asset> items = await _client.GetAllAsync(_groupId);

			// Assert  
			Assert.IsNotNull(items);
			Assert.IsTrue(items is List<Asset>);
			Assert.IsTrue(items.Count > 0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_AssetsClient_Get()
		{
			// Arrange  
			IAssetsClient _client = new AssetsClient(_apiUrl, _idServerResourceOwnerClientSettings);
			_client.GetCorrelationId = () => { return _correlationId; };

			// Act  
			Asset item = await _client.GetAsync(_assetId);

			// Assert  
			Assert.IsNotNull(item);
			Assert.IsTrue(item is Asset);
			Assert.IsTrue(item.AssetId == _assetId);
			Assert.IsTrue(item.Description.Length > 0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_AssetsClient_GetByGroup()
		{
			// Arrange  
			IAssetsClient _client = new AssetsClient(_apiUrl, _idServerResourceOwnerClientSettings);

			// Act  
			Asset item = await _client.GetByGroupAsync(_groupId, _assetId);

			// Assert  
			Assert.IsNotNull(item);
			Assert.IsTrue(item is Asset);
			Assert.IsTrue(item.AssetId == _assetId);
			Assert.IsTrue(item.Description.Length > 0);
		}


		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_AssetsClient_InvalidApiUrl()
		{
			// Arrange	 

			// Act
			try
			{
				IAssetsClient _client = new AssetsClient("", _idServerResourceOwnerClientSettings);
				throw new Exception("Test should fail with ArgumentException");
			}
			catch (Exception exc)
			{
				// Assert
				Assert.AreSame(typeof(ArgumentException), exc.GetType());
			}
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_AssetsClient_InvalidIdServerResourceOwnerClientSettings()
		{
			// Arrange	 
			IdServerResourceOwnerClientSettings invalidSettings = new IdServerResourceOwnerClientSettings()
			{
				BaseAddress = Main.Configuration["appSettings:"],
				ClientId = Main.Configuration["appSettings:IdentityServerClientId"],
				ClientSecret = Main.Configuration["appSettings:IdentityServerClientSecret"],
				UserName = Main.Configuration["appSettings:IdentityServerUserName"],
				Password = Main.Configuration["appSettings:IdentityServerPassword"],
				Scopes = Main.Configuration["appSettings:IdentityServerScopes"]

			};

			// Act
			try
			{
				IAssetsClient _client = new AssetsClient(_apiUrl, invalidSettings);
				Asset item = await _client.GetAsync(_assetId);
				throw new Exception("Test should fail with ArgumentException");
			}
			catch (Exception exc)
			{
				// Assert
				Assert.AreSame(typeof(ArgumentException), exc.GetType(), "Invalid exception: " + exc.Message);
			}
		}

		#endregion

		#region isTestRequest = false

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_AssetsClient_GetAll_IsTestRequest()
		{
			// Arrange  
			IAssetsClient _client = new AssetsClient(_apiUrl, _idServerResourceOwnerClientSettings, setTestRequestHeader: true);
			//_client.GetCorrelationId = () => { return IdentityGenerator.Generate64Bit().ToString(); };
			_client.GetCorrelationId = () => { return _correlationId; };

			// Act  
			List<Asset> items = await _client.GetAllAsync(_groupId);

			// Assert  
			Assert.IsNotNull(items);
			Assert.IsTrue(items is List<Asset>);
			Assert.IsTrue(items.Count > 0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_AssetsClient_Get_IsTestRequest()
		{
			// Arrange  
			IAssetsClient _client = new AssetsClient(_apiUrl, _idServerResourceOwnerClientSettings, setTestRequestHeader: true);
			_client.GetCorrelationId = () => { return _correlationId; };

			// Act  
			Asset item = await _client.GetAsync(_assetId);

			// Assert  
			Assert.IsNotNull(item);
			Assert.IsTrue(item is Asset);
			Assert.IsTrue(item.AssetId == _assetId);
			Assert.IsTrue(item.Description.Length > 0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_AssetsClient_GetByGroup_IsTestRequest()
		{
			// Arrange  
			IAssetsClient _client = new AssetsClient(_apiUrl, _idServerResourceOwnerClientSettings, setTestRequestHeader: true);

			// Act  
			Asset item = await _client.GetByGroupAsync(_groupId, _assetId);

			// Assert  
			Assert.IsNotNull(item);
			Assert.IsTrue(item is Asset);
			Assert.IsTrue(item.AssetId == _assetId);
			Assert.IsTrue(item.Description.Length > 0);
		}


		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_AssetsClient_InvalidApiUrl_IsTestRequest()
		{
			// Arrange	 

			// Act
			try
			{
				IAssetsClient _client = new AssetsClient("", _idServerResourceOwnerClientSettings, setTestRequestHeader: true);
				throw new Exception("Test should fail with ArgumentException");
			}
			catch (Exception exc)
			{
				// Assert
				Assert.AreSame(typeof(ArgumentException), exc.GetType());
			}
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_AssetsClient_InvalidIdServerResourceOwnerClientSettings_IsTestRequest()
		{
			// Arrange	 
			IdServerResourceOwnerClientSettings invalidSettings = new IdServerResourceOwnerClientSettings()
			{
				BaseAddress = Main.Configuration["appSettings:"],
				ClientId = Main.Configuration["appSettings:IdentityServerClientId"],
				ClientSecret = Main.Configuration["appSettings:IdentityServerClientSecret"],
				UserName = Main.Configuration["appSettings:IdentityServerUserName"],
				Password = Main.Configuration["appSettings:IdentityServerPassword"],
				Scopes = Main.Configuration["appSettings:IdentityServerScopes"]

			};

			// Act
			try
			{
				IAssetsClient _client = new AssetsClient(_apiUrl, invalidSettings, setTestRequestHeader: true);
				Asset item = await _client.GetAsync(_assetId);
				throw new Exception("Test should fail with ArgumentException");
			}
			catch (Exception exc)
			{
				// Assert
				Assert.AreSame(typeof(ArgumentException), exc.GetType(), "Invalid exception: " + exc.Message);
			}
		}

		#endregion

	}
}
