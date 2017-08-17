using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MiX.Integrate.API.Client.Tests;
using System.Threading.Tasks;
using Shouldly;
using MiX.Integrate.Shared.Entities.DeviceCommands;

namespace MiX.Integrate.Api.Client.Tests.IntegrationTests
{
	[TestClass]
	public class IntTests_Client_DeviceCommandsClient
	{

		#region startup 

		string _correlationId = "IntTest@" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

		// Dev data  
		private static string _apiUrl = Main.Configuration["appSettings:ApiUrl"];
		private static long _accountId = Convert.ToInt64(Main.Configuration["appSettings:AccountId"]);

		private static string _apiServerUrl = Main.Configuration["appSettings:ConfigServicesApiServerUrl"];
		private static long _groupId = Convert.ToInt64(Main.Configuration["appSettings:ConfigServicesGroupId"]);
		private static long _deviceId = Convert.ToInt64(Main.Configuration["appSettings:ConfigServicesAssetId"]);
		private static string _authToken = string.Empty;


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
		public async Task IntTests_Client_DeviceCommandsClient_SendPositionRequestMessage()
		{
			// Arrange     
			IDeviceCommandsClient _client = new DeviceCommandsClient(_apiUrl, _idServerResourceOwnerClientSettings, true);
			_client.GetCorrelationId = () => { return _correlationId; };

			// Act  
			long messageId = await _client.SendPositionRequestMessageAsync(_groupId, _deviceId, MessageTransport.None).ConfigureAwait(false);
			// Assert  
			messageId.ShouldNotBeNull();
			messageId.ShouldNotBe(0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_DeviceCommandsClient_SendRelayCommand()
		{
			// Arrange     
			IDeviceCommandsClient _client = new DeviceCommandsClient(_apiUrl, _idServerResourceOwnerClientSettings, true);
			_client.GetCorrelationId = () => { return _correlationId; };

			// Act  
			long messageId = await _client.SendRelayCommandAsync(1, 2, 3, 4, MessageTransport.None).ConfigureAwait(false);
			// Assert  
			messageId.ShouldNotBeNull();
			messageId.ShouldNotBe(0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_DeviceCommandsClient_SendTrackingRequest()
		{
			// Arrange     
			IDeviceCommandsClient _client = new DeviceCommandsClient(_apiUrl, _idServerResourceOwnerClientSettings, true);
			_client.GetCorrelationId = () => { return _correlationId; };

			// Act  
			long messageId = await _client.SendTrackingRequestAsync(1, 2, 3, 4, MessageTransport.None).ConfigureAwait(false);
			// Assert  
			messageId.ShouldNotBeNull();
			messageId.ShouldNotBe(0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_DeviceCommandsClient_SendStopTrackingRequest()
		{
			// Arrange     
			IDeviceCommandsClient _client = new DeviceCommandsClient(_apiUrl, _idServerResourceOwnerClientSettings, true);
			_client.GetCorrelationId = () => { return _correlationId; };

			// Act  
			long messageId = await _client.SendStopTrackingRequestAsync(1, 2, MessageTransport.None).ConfigureAwait(false);
			// Assert  
			messageId.ShouldNotBeNull();
			messageId.ShouldNotBe(0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_DeviceCommandsClient_SendProgressiveShutdownCommand()
		{
			// Arrange     
			IDeviceCommandsClient _client = new DeviceCommandsClient(_apiUrl, _idServerResourceOwnerClientSettings, true);
			_client.GetCorrelationId = () => { return _correlationId; };

			// Act  
			long messageId = await _client.SendProgressiveShutdownCommandAsync(1, 2, 3, MessageTransport.None).ConfigureAwait(false);
			// Assert  
			messageId.ShouldNotBeNull();
			messageId.ShouldNotBe(0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_DeviceCommandsClient_SendDisarmUnitMessage()
		{
			// Arrange     
			IDeviceCommandsClient _client = new DeviceCommandsClient(_apiUrl, _idServerResourceOwnerClientSettings, true);
			_client.GetCorrelationId = () => { return _correlationId; };

			// Act  
			long messageId = await _client.SendDisarmUnitMessageAsync(1, 2, MessageTransport.None).ConfigureAwait(false);
			// Assert  
			messageId.ShouldNotBeNull();
			messageId.ShouldNotBe(0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_DeviceCommandsClient_SendFreeTextMessage()
		{
			// Arrange     
			IDeviceCommandsClient _client = new DeviceCommandsClient(_apiUrl, _idServerResourceOwnerClientSettings, true);
			_client.GetCorrelationId = () => { return _correlationId; };

			// Act  
			long messageId = await _client.SendFreeTextMessageAsync("message", 1, 2, MessageTransport.None).ConfigureAwait(false);
			// Assert  
			messageId.ShouldNotBeNull();
			messageId.ShouldNotBe(0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_DeviceCommandsClient_SendSetAcronymCommand()
		{
			// Arrange     
			IDeviceCommandsClient _client = new DeviceCommandsClient(_apiUrl, _idServerResourceOwnerClientSettings, true);
			_client.GetCorrelationId = () => { return _correlationId; };

			// Act  
			long messageId = await _client.SendSetAcronymCommandAsync(1, 2, 3, null, null, MessageTransport.None).ConfigureAwait(false);
			// Assert  
			messageId.ShouldNotBeNull();
			messageId.ShouldNotBe(0);
		}

	}


}



