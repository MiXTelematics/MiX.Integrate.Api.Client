using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Messages;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public class MessagesClient : BaseClient, IMessagesClient
	{
		public MessagesClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public MessagesClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public async Task<Message> GetMessageAsync(long organisationId, int messageId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.MessagesController.GET, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("messageId", messageId.ToString());
			IHttpRestResponse<Message> response = await ExecuteAsync<Message>(request).ConfigureAwait(false);
			return response.Data;
		}

		public Message GetMessage(long organisationId, int messageId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.MessagesController.GET, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("messageId", messageId.ToString());
			IHttpRestResponse<Message> response = Execute<Message>(request);
			return response.Data;
		}

		public async Task<MessageStates> GetMessageStateAsync(long organisationId, int messageId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.MessagesController.GETMESSAGESTATE, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("messageId", messageId.ToString());
			IHttpRestResponse<MessageStates> response = await ExecuteAsync<MessageStates>(request).ConfigureAwait(false);
			return response.Data;
		}

		public MessageStates GetMessageState(long organisationId, int messageId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.MessagesController.GETMESSAGESTATE, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("messageId", messageId.ToString());
			IHttpRestResponse<MessageStates> response = Execute<MessageStates>(request);
			return response.Data;
		}

		public async Task<IList<MessageStateHistoryItem>> GetMessageStateHistoryAsync(long organisationId, int messageId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.MessagesController.GETMESSAGESTATEHISTORY, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("messageId", messageId.ToString());
			IHttpRestResponse<List<MessageStateHistoryItem>> response = await ExecuteAsync<List<MessageStateHistoryItem>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<MessageStateHistoryItem> GetMessageStateHistory(long organisationId, int messageId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.MessagesController.GETMESSAGESTATEHISTORY, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("messageId", messageId.ToString());
			IHttpRestResponse<List<MessageStateHistoryItem>> response = Execute<List<MessageStateHistoryItem>>(request);
			return response.Data;
		}

		public async Task<IList<Message>> GetMessagesBySinceIdAsync(long organisationId, int messageId, int maxRecords)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.MessagesController.GETSINCEID, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("messageId", messageId.ToString());
			request.AddUrlSegment("maxRecords", maxRecords.ToString());
			IHttpRestResponse<List<Message>> response = await ExecuteAsync<List<Message>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<Message> GetMessagesBySinceId(long organisationId, int messageId, int maxRecords)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.MessagesController.GETSINCEID, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("messageId", messageId.ToString());
			request.AddUrlSegment("maxRecords", maxRecords.ToString());
			IHttpRestResponse<List<Message>> response = Execute<List<Message>>(request);
			return response.Data;
		}


		public async Task<SendMessageResult> SendFreeTextMessageAsync(long organisationId, SendFreeTextMessageCarrier messageCarrier)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.MessagesController.SENDFREETEXTMESSAGE, HttpMethod.Post);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddJsonBody(messageCarrier);
			IHttpRestResponse<SendMessageResult> response = await ExecuteAsync<SendMessageResult>(request).ConfigureAwait(false);
			return response.Data;
		}

		public SendMessageResult SendFreeTextMessage(long organisationId, SendFreeTextMessageCarrier messageCarrier)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.MessagesController.SENDFREETEXTMESSAGE, HttpMethod.Post);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddJsonBody(messageCarrier);
			IHttpRestResponse<SendMessageResult> response = Execute<SendMessageResult>(request);
			return response.Data;
		}

		public async Task<SendMessageResult> SendJobMessageAsync(long organisationId, SendJobMessageCarrier jobMessageCarrier, bool saveOnly)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.MessagesController.SENDJOBMESSAGE, HttpMethod.Post);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddQueryParameter("saveOnly", saveOnly.ToString());
			request.AddJsonBody(jobMessageCarrier);
			IHttpRestResponse<SendMessageResult> response = await ExecuteAsync<SendMessageResult>(request).ConfigureAwait(false);
			return response.Data;
		}

		public SendMessageResult SendJobMessage(long organisationId, SendJobMessageCarrier jobMessageCarrier, bool saveOnly)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.MessagesController.SENDJOBMESSAGE, HttpMethod.Post);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddQueryParameter("saveOnly", saveOnly.ToString());
			request.AddJsonBody(jobMessageCarrier);
			IHttpRestResponse<SendMessageResult> response = Execute<SendMessageResult>(request);
			return response.Data;
		}

		public async Task<int> CreateJobListAsync(long organisationId, int[] messageIDList)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.MessagesController.CREATEJOBLIST, HttpMethod.Post);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddJsonBody(messageIDList);
			IHttpRestResponse<int> response = await ExecuteAsync<int>(request).ConfigureAwait(false);
			return response.Data;
		}

		public int CreateJobList(long organisationId, int[] messageIDList)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.MessagesController.CREATEJOBLIST, HttpMethod.Post);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddJsonBody(messageIDList);
			IHttpRestResponse<int> response = Execute<int>(request);
			return response.Data;
		}
	}
}
