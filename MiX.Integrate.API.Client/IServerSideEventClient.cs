using System.Threading.Tasks;
using MiX.Integrate.Api.Client.Base;
using MiX.Integrate.Shared.Entities.ServerSideEvents;

namespace MiX.Integrate.API.Client
{
	public interface IServerSideEventClient : IBaseClient
	{
		LocationBoundaryEvent AddLocationBoundaryEvent(string authToken, long organisationId, LocationBoundaryEvent eventModel);

		Task<LocationBoundaryEvent> AddLocationBoundaryEventAsync(string authToken, long organisationId, LocationBoundaryEvent eventModel);
	}
}
