using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.DeviceCommands;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiX.Integrate.Api.Client
{
	public class DeviceCommandsClient : BaseClient, IDeviceCommandsClient
	{

		public DeviceCommandsClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public DeviceCommandsClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public async Task<long> SendPositionRequestMessageAsync(long groupId, long assetId, MessageTransport? preferredTransport = null)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DEVICECOMMANDSCONTROLLER.SENDPOSITIONREQUESTMESSAGE, Method.GET);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddUrlSegment("assetId:long", assetId.ToString());
			if (preferredTransport.HasValue) request.AddQueryParameter("preferredTransport", preferredTransport.ToString());
			IRestResponse<long> response = await ExecuteAsync<long>(request).ConfigureAwait(false);
			return response.Data;
		}

		public async Task<long> SendRelayCommandAsync(long groupId, long assetId, uint relayDrive, uint relayState, MessageTransport? preferredTransport = null)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DEVICECOMMANDSCONTROLLER.SENDRELAYCOMMAND, Method.GET);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddUrlSegment("assetId:long", assetId.ToString());
			request.AddUrlSegment("relayDrive", relayDrive.ToString());
			request.AddUrlSegment("relayState", relayState.ToString());
			if (preferredTransport.HasValue) request.AddQueryParameter("preferredTransport", preferredTransport.ToString());
			IRestResponse<long> response = await ExecuteAsync<long>(request).ConfigureAwait(false);
			return response.Data;
		}

		public async Task<long> SendTrackingRequestAsync(long groupId, long assetId, uint intervalSeconds, uint durationSeconds, MessageTransport? preferredTransport = null)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DEVICECOMMANDSCONTROLLER.SENDTRACKINGREQUEST, Method.GET);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddUrlSegment("assetId:long", assetId.ToString());
			request.AddUrlSegment("intervalSeconds", intervalSeconds.ToString());
			request.AddUrlSegment("durationSeconds", durationSeconds.ToString());
			if (preferredTransport.HasValue) request.AddQueryParameter("preferredTransport", preferredTransport.ToString());
			IRestResponse<long> response = await ExecuteAsync<long>(request).ConfigureAwait(false);
			return response.Data;
		}

		public async Task<long> SendStopTrackingRequestAsync(long groupId, long assetId, MessageTransport? preferredTransport = null)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DEVICECOMMANDSCONTROLLER.SENDSTOPTRACKINGREQUEST, Method.GET);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddUrlSegment("assetId:long", assetId.ToString());
			if (preferredTransport.HasValue) request.AddQueryParameter("preferredTransport", preferredTransport.ToString());
			IRestResponse<long> response = await ExecuteAsync<long>(request).ConfigureAwait(false);
			return response.Data;
		}

		public async Task<long> SendProgressiveShutdownCommandAsync(long groupId, long assetId, uint relayDrive, MessageTransport? preferredTransport = null)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DEVICECOMMANDSCONTROLLER.SENDPROGRESSIVESHUTDOWNCOMMAND, Method.GET);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddUrlSegment("assetId:long", assetId.ToString());
			request.AddUrlSegment("relayDrive", relayDrive.ToString());
			if (preferredTransport.HasValue) request.AddQueryParameter("preferredTransport", preferredTransport.ToString());
			IRestResponse<long> response = await ExecuteAsync<long>(request).ConfigureAwait(false);
			return response.Data;
		}

		public async Task<long> SendDisarmUnitMessageAsync(long groupId, long assetId, MessageTransport? preferredTransport = null)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DEVICECOMMANDSCONTROLLER.SENDDISARMUNITMESSAGE, Method.GET);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddUrlSegment("assetId:long", assetId.ToString());
			if (preferredTransport.HasValue) request.AddQueryParameter("preferredTransport", preferredTransport.ToString());
			IRestResponse<long> response = await ExecuteAsync<long>(request).ConfigureAwait(false);
			return response.Data;
		}

		public async Task<long> SendFreeTextMessageAsync(string message, long groupId, long assetId, MessageTransport? preferredTransport = null)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DEVICECOMMANDSCONTROLLER.SENDFREETEXTMESSAGE, Method.POST);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddUrlSegment("assetId:long", assetId.ToString());
			if (preferredTransport.HasValue) request.AddQueryParameter("preferredTransport", preferredTransport.ToString());
			request.AddJsonBody(message);
			IRestResponse<long> response = await ExecuteAsync<long>(request).ConfigureAwait(false);
			return response.Data;
		}

		public async Task<long> SendSetAcronymCommandAsync(long groupId, long assetId, uint? param1 = null, uint? param2 = null, uint? param3 = null, MessageTransport? preferredTransport = null)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DEVICECOMMANDSCONTROLLER.SENDSETACRONYMCOMMAND, Method.GET);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddUrlSegment("assetId:long", assetId.ToString());
			request.AddUrlSegment("param1", param1.HasValue ? param1.Value.ToString() : "0");
			request.AddUrlSegment("param2", param2.HasValue ? param2.Value.ToString() : "0");
			request.AddUrlSegment("param3", param3.HasValue ? param3.Value.ToString() : "0");
			if (preferredTransport.HasValue) request.AddQueryParameter("preferredTransport", preferredTransport.ToString());
			IRestResponse<long> response = await ExecuteAsync<long>(request).ConfigureAwait(false);
			return response.Data;
		}



		public long SendPositionRequestMessage(long groupId, long assetId, MessageTransport? preferredTransport = null)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DEVICECOMMANDSCONTROLLER.SENDPOSITIONREQUESTMESSAGE, Method.GET);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddUrlSegment("assetId:long", assetId.ToString());
			if (preferredTransport.HasValue) request.AddQueryParameter("preferredTransport", preferredTransport.ToString());
			IRestResponse<long> response = Execute<long>(request);
			return response.Data;
		}

		public long SendRelayCommand(long groupId, long assetId, uint relayDrive, uint relayState, MessageTransport? preferredTransport = null)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DEVICECOMMANDSCONTROLLER.SENDRELAYCOMMAND, Method.GET);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddUrlSegment("assetId:long", assetId.ToString());
			request.AddUrlSegment("relayDrive", relayDrive.ToString());
			request.AddUrlSegment("relayState", relayState.ToString());
			if (preferredTransport.HasValue) request.AddQueryParameter("preferredTransport", preferredTransport.ToString());
			IRestResponse<long> response = Execute<long>(request);
			return response.Data;
		}

		public long SendTrackingRequest(long groupId, long assetId, uint intervalSeconds, uint durationSeconds, MessageTransport? preferredTransport = null)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DEVICECOMMANDSCONTROLLER.SENDTRACKINGREQUEST, Method.GET);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddUrlSegment("assetId:long", assetId.ToString());
			request.AddUrlSegment("intervalSeconds", intervalSeconds.ToString());
			request.AddUrlSegment("durationSeconds", durationSeconds.ToString());
			if (preferredTransport.HasValue) request.AddQueryParameter("preferredTransport", preferredTransport.ToString());
			IRestResponse<long> response = Execute<long>(request);
			return response.Data;
		}

		public long SendStopTrackingRequest(long groupId, long assetId, MessageTransport? preferredTransport = null)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DEVICECOMMANDSCONTROLLER.SENDSTOPTRACKINGREQUEST, Method.GET);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddUrlSegment("assetId:long", assetId.ToString());
			if (preferredTransport.HasValue) request.AddQueryParameter("preferredTransport", preferredTransport.ToString());
			IRestResponse<long> response = Execute<long>(request);
			return response.Data;
		}

		public long SendProgressiveShutdownCommand(long groupId, long assetId, uint relayDrive, MessageTransport? preferredTransport = null)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DEVICECOMMANDSCONTROLLER.SENDPROGRESSIVESHUTDOWNCOMMAND, Method.GET);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddUrlSegment("assetId:long", assetId.ToString());
			request.AddUrlSegment("relayDrive", relayDrive.ToString());
			if (preferredTransport.HasValue) request.AddQueryParameter("preferredTransport", preferredTransport.ToString());
			IRestResponse<long> response = Execute<long>(request);
			return response.Data;
		}

		public long SendDisarmUnitMessage(long groupId, long assetId, MessageTransport? preferredTransport = null)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DEVICECOMMANDSCONTROLLER.SENDDISARMUNITMESSAGE, Method.GET);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddUrlSegment("assetId:long", assetId.ToString());
			if (preferredTransport.HasValue) request.AddQueryParameter("preferredTransport", preferredTransport.ToString());
			IRestResponse<long> response = Execute<long>(request);
			return response.Data;
		}

		public long SendFreeTextMessage(string message, long groupId, long assetId, MessageTransport? preferredTransport = null)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DEVICECOMMANDSCONTROLLER.SENDFREETEXTMESSAGE, Method.POST);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddUrlSegment("assetId:long", assetId.ToString());
			if (preferredTransport.HasValue) request.AddQueryParameter("preferredTransport", preferredTransport.ToString());
			request.AddJsonBody(message);
			IRestResponse<long> response = Execute<long>(request);
			return response.Data;
		}

		public long SendSetAcronymCommand(long groupId, long assetId, uint? param1 = null, uint? param2 = null, uint? param3 = null, MessageTransport? preferredTransport = null)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.DEVICECOMMANDSCONTROLLER.SENDSETACRONYMCOMMAND, Method.GET);
			request.AddUrlSegment("groupId:long", groupId.ToString());
			request.AddUrlSegment("assetId:long", assetId.ToString());
			request.AddUrlSegment("param1", param1.HasValue ? param1.Value.ToString() : "0");
			request.AddUrlSegment("param2", param2.HasValue ? param2.Value.ToString() : "0");
			request.AddUrlSegment("param3", param3.HasValue ? param3.Value.ToString() : "0");
			if (preferredTransport.HasValue) request.AddQueryParameter("preferredTransport", preferredTransport.ToString());
			IRestResponse<long> response = Execute<long>(request);
			return response.Data;
		}
	}
}
