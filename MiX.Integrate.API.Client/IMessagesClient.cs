using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Entities.Messages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public interface IMessagesClient : IBaseClient
	{
		Task<Message> GetMessageAsync(long organisationId, int messageId);
		Message GetMessage(long organisationId, int messageId);
		Task<MessageStates> GetMessageStateAsync(long organisationId, int messageId);
		MessageStates GetMessageState(long organisationId, int messageId);
		Task<IList<MessageStateHistoryItem>> GetMessageStateHistoryAsync(long organisationId, int messageId);
		IList<MessageStateHistoryItem> GetMessageStateHistory(long organisationId, int messageId);
		Task<IList<Message>> GetMessagesBySinceIdAsync(long organisationId, int messageId, int maxRecords);
		IList<Message> GetMessagesBySinceId(long organisationId, int messageId, int maxRecords);
		Task<SendMessageResult> SendFreeTextMessageAsync(long organisationId, SendFreeTextMessageCarrier messageCarrier);
		SendMessageResult SendFreeTextMessage(long organisationId, SendFreeTextMessageCarrier messageCarrier);
		Task<SendMessageResult> SendJobMessageAsync(long organisationId, SendJobMessageCarrier jobMessageCarrier,
			bool saveOnly);
		SendMessageResult SendJobMessage(long organisationId, SendJobMessageCarrier jobMessageCarrier, bool saveOnly);
		Task<int> CreateJobListAsync(long organisationId, int[] messageIDList);
		int CreateJobList(long organisationId, int[] messageIDList);
	}
}
