using System;
using System.Collections.Generic;
using MiX.Integrate.API.Client.Tests;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiX.Integrate.Shared.Entities.Messages;
using Shouldly;
using MiX.Integrate.Shared.Entities.Communications;

namespace MiX.Integrate.Api.Client.Tests.IntegrationTests
{
	[TestClass]
	public class IntTests_Client_MessagesClient
	{
		#region startup 
		// Dev data  
		private static string _apiUrl = Main.Configuration["appSettings:ApiUrl"];
		private static long _organisationId = 1;
		private static int _messageId = 1;

		private static IdServerResourceOwnerClientSettings _idServerResourceOwnerClientSettings;
		private static IMessagesClient _messagesClient;

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

			_messagesClient = new MessagesClient(_apiUrl, _idServerResourceOwnerClientSettings, true);
		}

		[ClassCleanup()]
		public static void ClassCleanup() { }

		#endregion

		#region Async

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_MessagesClient_GetMessageAsync()
		{
			// Arrange  

			// Act  
			Message message = await _messagesClient.GetMessageAsync(_organisationId, _messageId);

			// Assert  
			message.ShouldNotBeNull();
			message.ShouldBeOfType<Message>();
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_MessagesClient_GetMessageStateAsync()
		{
			// Arrange  

			// Act  
			MessageStates messageState = await _messagesClient.GetMessageStateAsync(_organisationId, _messageId);

			// Assert  
			messageState.ShouldNotBeNull();
			messageState.ShouldBeOfType<MessageStates>();
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_MessagesClient_GetMessageStateHistoryAsync()
		{
			// Arrange  

			// Act  
			IList<MessageStateHistoryItem> messages = await _messagesClient.GetMessageStateHistoryAsync(_organisationId, _messageId);

			// Assert  
			messages.ShouldNotBeNull();
			messages.ShouldBeOfType<List<MessageStateHistoryItem>>();
			messages.Count.ShouldBePositive();
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_MessagesClient_GetMessagesBySinceIdAsync()
		{
			// Arrange  
			int maxRecords = 1000;

			// Act  
			IList<Message> messages = await _messagesClient.GetMessagesBySinceIdAsync(_organisationId, _messageId, maxRecords);

			// Assert  
			messages.ShouldNotBeNull();
			messages.ShouldBeOfType<List<Message>>();
			messages.Count.ShouldBePositive();
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_MessagesClient_SendFreeTextMessageAsync()
		{
			// Arrange  
			SendFreeTextMessageCarrier messageCarrier = new SendFreeTextMessageCarrier()
			{
				VehicleId = 1,
				Subject = $"Test Subject {DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")}",
				Body = $"Test Body {DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")}",
				DefaultResponses = new string[] { "" },
				Urgent = true,
				ExpiryDate = DateTime.UtcNow.AddDays(1),
				NotifyWhenDeleted = true,
				NotifyWhenRead = true,
				NotifyWhenRepliedTo = true,
				Transport = CommsTransports.Default
			};

			// Act  
			SendMessageResult messageResult = await _messagesClient.SendFreeTextMessageAsync(_organisationId, messageCarrier);

			// Assert  
			messageResult.ShouldNotBeNull();
			messageResult.ShouldBeOfType<SendMessageResult>();
		}

		#endregion

		#region Async

		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_MessagesClient_GetMessage()
		{
			// Arrange  

			// Act  
			Message message = _messagesClient.GetMessage(_organisationId, _messageId);

			// Assert  
			message.ShouldNotBeNull();
			message.ShouldBeOfType<Message>();
		}

		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_MessagesClient_GetMessageState()
		{
			// Arrange  

			// Act  
			MessageStates messageState = _messagesClient.GetMessageState(_organisationId, _messageId);

			// Assert  
			messageState.ShouldNotBeNull();
			messageState.ShouldBeOfType<MessageStates>();
		}

		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_MessagesClient_GetMessageStateHistory()
		{
			// Arrange  

			// Act  
			IList<MessageStateHistoryItem> messages = _messagesClient.GetMessageStateHistory(_organisationId, _messageId);

			// Assert  
			messages.ShouldNotBeNull();
			messages.ShouldBeOfType<List<MessageStateHistoryItem>>();
			messages.Count.ShouldBePositive();
		}

		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_MessagesClient_GetMessagesBySinceId()
		{
			// Arrange  
			int maxRecords = 1000;

			// Act  
			IList<Message> messages = _messagesClient.GetMessagesBySinceId(_organisationId, _messageId, maxRecords);

			// Assert  
			messages.ShouldNotBeNull();
			messages.ShouldBeOfType<List<Message>>();
			messages.Count.ShouldBePositive();
		}

		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_MessagesClient_SendFreeTextMessage()
		{
			// Arrange  
			SendFreeTextMessageCarrier messageCarrier = new SendFreeTextMessageCarrier()
			{
				VehicleId = 1,
				Subject = $"Test Subject {DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")}",
				Body = $"Test Body {DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")}",
				DefaultResponses = new string[] { "" },
				Urgent = true,
				ExpiryDate = DateTime.UtcNow.AddDays(1),
				NotifyWhenDeleted = true,
				NotifyWhenRead = true,
				NotifyWhenRepliedTo = true,
				Transport = CommsTransports.Default
			};

			// Act  
			SendMessageResult messageResult = _messagesClient.SendFreeTextMessage(_organisationId, messageCarrier);

			// Assert  
			messageResult.ShouldNotBeNull();
			messageResult.ShouldBeOfType<SendMessageResult>();
		}

		#endregion

	}
}
