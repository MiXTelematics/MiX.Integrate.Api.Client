using MiX.Integrate.Shared.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Drivers;
using RestSharp;
using MiX.Integrate.Api.Client.Base;

namespace MiX.Integrate.Api.Client
{
	public class MessagesClient : BaseClient, IMessagesClient
	{
		public MessagesClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public MessagesClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public async Task<Message> GetMessageAsync(long organisationId, int messageId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.MESSAGESCONTROLLER.GET, Method.GET);
			request.AddUrlSegment("organisationId:long", organisationId.ToString());
			request.AddUrlSegment("messageId", messageId.ToString());
			IRestResponse<Message> response = await ExecuteAsync<Message>(request).ConfigureAwait(false);
			return response.Data;
		}

		public Message GetMessage(long organisationId, int messageId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.MESSAGESCONTROLLER.GET, Method.GET);
			request.AddUrlSegment("organisationId:long", organisationId.ToString());
			request.AddUrlSegment("messageId", messageId.ToString());
			IRestResponse<Message> response = Execute<Message>(request);
			return response.Data;
		}

		public async Task<MessageStates> GetMessageStateAsync(long organisationId, int messageId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.MESSAGESCONTROLLER.GETMESSAGESTATE, Method.GET);
			request.AddUrlSegment("organisationId:long", organisationId.ToString());
			request.AddUrlSegment("messageId", messageId.ToString());
			IRestResponse<MessageStates> response = await ExecuteAsync<MessageStates>(request).ConfigureAwait(false);
			return response.Data;
		}

		public MessageStates GetMessageState(long organisationId, int messageId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.MESSAGESCONTROLLER.GETMESSAGESTATE, Method.GET);
			request.AddUrlSegment("organisationId:long", organisationId.ToString());
			request.AddUrlSegment("messageId", messageId.ToString());
			IRestResponse<MessageStates> response = Execute<MessageStates>(request);
			return response.Data;
		}

		public async Task<IList<MessageStateHistoryItem>> GetMessageStateHistoryAsync(long organisationId, int messageId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.MESSAGESCONTROLLER.GETMESSAGESTATEHISTORY, Method.GET);
			request.AddUrlSegment("organisationId:long", organisationId.ToString());
			request.AddUrlSegment("messageId", messageId.ToString());
			IRestResponse<List<MessageStateHistoryItem>> response = await ExecuteAsync<List<MessageStateHistoryItem>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<MessageStateHistoryItem> GetMessageStateHistory(long organisationId, int messageId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.MESSAGESCONTROLLER.GETMESSAGESTATEHISTORY, Method.GET);
			request.AddUrlSegment("organisationId:long", organisationId.ToString());
			request.AddUrlSegment("messageId", messageId.ToString());
			IRestResponse<List<MessageStateHistoryItem>> response = Execute <List<MessageStateHistoryItem>> (request);
			return response.Data;
		}

		public async Task<IList<Message>> GetMessagesBySinceIdAsync(long organisationId, int messageId, int maxRecords)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.MESSAGESCONTROLLER.GETSINCEID, Method.GET);
			request.AddUrlSegment("organisationId:long", organisationId.ToString());
			request.AddUrlSegment("messageId", messageId.ToString());
			request.AddUrlSegment("maxRecords", maxRecords.ToString());
			IRestResponse<List<Message>> response = await ExecuteAsync<List<Message>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<Message> GetMessagesBySinceId(long organisationId, int messageId, int maxRecords)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.MESSAGESCONTROLLER.GETSINCEID, Method.GET);
			request.AddUrlSegment("organisationId:long", organisationId.ToString());
			request.AddUrlSegment("messageId", messageId.ToString());
			request.AddUrlSegment("maxRecords", maxRecords.ToString());
			IRestResponse<List<Message>> response = Execute<List<Message>>(request);
			return response.Data;
		}


		public async Task<SendMessageResult> SendFreeTextMessageAsync(long organisationId, SendFreeTextMessageCarrier messageCarrier)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.MESSAGESCONTROLLER.SENDFREETEXTMESSAGE, Method.POST);
			request.AddUrlSegment("organisationId:long", organisationId.ToString());
			request.AddJsonBody(messageCarrier);
			IRestResponse<SendMessageResult> response = await ExecuteAsync<SendMessageResult>(request).ConfigureAwait(false);
			return response.Data;
		}

		public SendMessageResult SendFreeTextMessage(long organisationId, SendFreeTextMessageCarrier messageCarrier)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.MESSAGESCONTROLLER.SENDFREETEXTMESSAGE, Method.POST);
			request.AddUrlSegment("organisationId:long", organisationId.ToString());
			request.AddJsonBody(messageCarrier);
			IRestResponse<SendMessageResult> response = Execute<SendMessageResult>(request);
			return response.Data;
		}
	}
}
