using System;
using System.Collections.Generic;

using MiX.Integrate.Shared.Constants;

using RestSharp;
using System.Threading.Tasks;
using MiX.Integrate.Shared.Entities.LibraryEvents;
using MiX.Integrate.Api.Client.Base;

namespace MiX.Integrate.Api.Client
{
	public class LibraryEventsClient : BaseClient, ILibraryEventsClient
	{

		public LibraryEventsClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public LibraryEventsClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public IList<LibraryEvent> GetAllLibraryEvents(long organisationId)
		{
			return GetAllLibraryEventsAsync(organisationId).Result;
		}

		public async Task<IList<LibraryEvent>> GetAllLibraryEventsAsync(long organisationId)
		{
			IRestRequest request = GetRequest(APIControllerRoutes.LIBRARYEVENTSCONTROLLER.GETALLLIBRARYEVENTS, Method.GET);
			request.AddUrlSegment("organisationId:long", organisationId.ToString());
			IRestResponse<List<LibraryEvent>> response = await ExecuteAsync<List<LibraryEvent>>(request);
			return response.Data;
		}
	}
}
