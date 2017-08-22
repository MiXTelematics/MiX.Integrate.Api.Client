using MiX.Integrate.Shared.Entities.LibraryEvents;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace MiX.Integrate.Api.Client
{
	public interface ILibraryEventsClient : IBaseClient
	{
		IList<LibraryEvent> GetAllLibraryEvents(long groupId);
		Task<IList<LibraryEvent>> GetAllLibraryEventsAsync(long groupId);

	}
}
