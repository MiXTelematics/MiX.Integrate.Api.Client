using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Entities.Aemp;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public interface IAempClient : IBaseClient
	{
		/// <summary>Gets a page of up to 100 AEMP <see cref="EquipmentSnapshot"/> AEMP records for the specified organisation</summary>
		/// <param name="organisationId">Identifier of the organisation to be queried</param>
		/// <param name="pageNum">Number of the "page" to be retrieved</param>
		/// <returns>A <see cref="FleetSnapshot"/> containing up to 100 <see cref="EquipmentSnapshot"/>s</returns>
		FleetSnapshot GetFleetSnapshotPaged(long organisationId, uint pageNum = 1);

		/// <summary>Gets a page of up to 100 AEMP <see cref="EquipmentSnapshot"/> records for the specified organisation as an asynchronous operation</summary>
		/// <param name="organisationId">Identifier of the organisation to be queried</param>
		/// <param name="pageNum">Number of the "page" to be retrieved</param>
		/// <returns>An awaitable <see cref="Task"/> representing the operation</returns>
		Task<FleetSnapshot> GetFleetSnapshotPagedAsync(long organisationId, uint pageNum = 1);

	}
}
