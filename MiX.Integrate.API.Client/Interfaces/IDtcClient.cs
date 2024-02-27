using System;
using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Entities.Dtc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public interface IDtcClient : IBaseClient
	{
		/// <summary>Gets a list of assets with open faults in the specified group</summary>
		/// <param name="groupId">Identifier of the organisation, organisation subgroup, or site group</param>
		/// <returns>A list containing the asset id and highest open fault severity of assets with open faults in the specified group</returns>
		IList<FaultedAsset> GetFaultedAssetsByGroup(long groupId);

		/// <summary>Gets a list of assets with open faults in the specified group as an asynchronous operation</summary>
		/// <param name="groupId">Identifier of the organisation, organisation subgroup, or site group</param>
		/// <returns>A <see cref="Task"/> which, on completion, yields a list containing the asset id and highest open fault severity of assets with open faults in the specified group</returns>
		Task<IList<FaultedAsset>> GetFaultedAssetsByGroupAsync(long groupId);

		/// <summary>Gets faults associated with the specified assets</summary>
		/// <param name="assetIds">Identifiers of the assets</param>
		/// <param name="includeClosed"><see cref="Task"/> to include resolved faults</param>
		/// <returns>A list of <see cref="AssetFaults"/> for the specified assets</returns>
		IList<AssetFaults> GetAssetFaults(List<long> assetIds, bool includeClosed = false);

		/// <summary>Gets faults associated with the specified assets, as an asynchronous operation</summary>
		/// <param name="assetIds">Identifiers of the assets</param>
		/// <param name="includeClosed"><see cref="Task"/> to include resolved faults</param>
		/// <returns>A <see cref="Task"/> which, on completion, yields a list of <see cref="AssetFaults"/> for the specified assets</returns>
		Task<IList<AssetFaults>> GetAssetFaultsAsync(List<long> assetIds, bool includeClosed = false);

		/// <summary>Gets the DTC messages logged the specified assets during the specified period</summary>
		/// <param name="assetIds">Identifiers of the assets</param>
		/// <param name="from">Period start</param>
		/// <param name="to">Period end</param>
		/// <returns><see cref="FaultMessage"/>s for the specified assets and period</returns>
		IList<FaultMessage> GetFaultMessageHistory(List<long> assetIds, DateTime from, DateTime to);

		/// <summary>Gets the DTC messages logged the specified assets during the specified period</summary>
		/// <param name="assetIds">Identifiers of the assets</param>
		/// <param name="from">Period start</param>
		/// <param name="to">Period end</param>
		/// <returns>A <see cref="Task"/> which, on completion, yields a list of <see cref="FaultMessage"/>s for the specified assets and period</returns>
		Task<IList<FaultMessage>> GetFaultMessageHistoryAsync(List<long> assetIds, DateTime from, DateTime to);



	}
}
