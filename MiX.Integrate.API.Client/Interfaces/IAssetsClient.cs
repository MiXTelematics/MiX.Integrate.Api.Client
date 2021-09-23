using System;
using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Entities.Assets;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public interface IAssetsClient : IBaseClient
	{
		List<Asset> GetAll(long groupId);
		Task<List<Asset>> GetAllAsync(long groupId);
		List<Asset> GetAll(long groupId, string filterType, string wildCard);
		Task<List<Asset>> GetAllAsync(long groupId, string filterType, string wildCard);

		/// <summary>Gets the custom asset detail data for assets in the specified group</summary>
		/// <param name="groupId">Identifies the organisation, subgroup or site containing the assets to query</param>
		/// <returns>Data associated with the custom asset detail fields for assets in the specified group</returns>
		List<AdditionalDetails> GetAdditionalDetailsByGroup(long groupId);

		/// <summary>Gets the custom asset detail data for assets in the specified group as an asynchronous operation</summary>
		/// <param name="groupId">Identifies the organisation, subgroup or site containing the assets to query</param>
		/// <returns>An object representing the asynchronous operation</returns>
		Task<List<AdditionalDetails>> GetAdditionalDetailsByGroupAsync(long groupId);

		/// <summary>Gets <see cref="AssetDiagnostics"/> details for the specified assets in the specified organisation</summary>
		/// <param name="organisationId">Identifies the organisation containing the assets to query</param>
		/// <param name="assetIds">Identifies the assets to query</param>
		/// <returns>Asset diagnostics details for the specified assets</returns>
		List<AssetDiagnostics> GetAssetDiagnostics(long organisationId, IList<long> assetIds);

		/// <summary>Gets <see cref="AssetDiagnostics"/> details for the specified assets in the specified organisation</summary>
		/// <param name="organisationId">Identifies the organisation containing the assets to query</param>
		/// <param name="assetIds">Identifies the assets to query</param>
		/// <returns>An object representing the asynchronous operation</returns>
		Task<List<AssetDiagnostics>> GetAssetDiagnosticsAsync(long organisationId, IList<long> assetIds);

		Asset Get(long assetId);
		Task<Asset> GetAsync(long assetId);
		Asset GetByGroup(long groupId, long assetId);
		Task<Asset> GetByGroupAsync(long groupId, long assetId);
		void Update(Asset asset);
		Task UpdateAsync(Asset asset);
		bool AddAssetState(long groupId, AssetState assetState);
		Task<bool> AddAssetStateAsync(long groupId, AssetState assetState);
		long Add(Asset asset);
		Task<long> AddAsync(Asset asset);

		/// <summary>Gets <see cref="Trailer"/> assets for the specified organisation as an asynchronous operation</summary>
		/// <param name="organisationId">Identifies the organisation to be queried</param>
		/// <returns>A list of <see cref="Trailer"/> objects for the specified organisation</returns>
		List<Trailer> GetTrailers(long organisationId);

		/// <summary>Gets <see cref="Trailer"/> assets for the specified organisation as an asynchronous operation</summary>
		/// <param name="organisationId">Identifies the organisation to be queried</param>
		/// <returns>The task object representing the asynchronous operation</returns>
		Task<List<Trailer>> GetTrailersAsync(long organisationId);


		/// <summary>Queries the service history of the specified assets for <see cref="AssetService"/> records
		/// in the specified date range</summary>
		/// <param name="assetIds">Identifies assets from a single organisation to include in the query</param>
		/// <param name="from">Start of the date range to query</param>
		/// <param name="to">End of the date range to query</param>
		/// <returns>A list of <see cref="AssetService"/> records in the specified date range for the specified assets</returns>
		List<AssetService> GetServiceHistory(List<long> assetIds, DateTime from, DateTime to);

		/// <summary>Queries the service history of the specified assets for <see cref="AssetService"/> records
		/// in the specified date range, as an asynchronous operation</summary>
		/// <param name="assetIds">Identifies assets from a single organisation to include in the query</param>
		/// <param name="from">Start of the date range to query</param>
		/// <param name="to">End of the date range to query</param>
		/// <returns>The task object representing the asynchronous operation</returns>
		Task<List<AssetService>> GetServiceHistoryAsync(List<long> assetIds, DateTime from, DateTime to);

		/// <summary>Queries the service history of assets in the specified organisation, organisation subgroup, or site
		/// for <see cref="AssetService"/> records in the specified date range</summary>
		/// <param name="groupId">Identifies an organisation, organisation subgroup, or site to include in the query</param>
		/// <param name="from">Start of the date range to query</param>
		/// <param name="to">End of the date range to query</param>
		/// <returns>A list of <see cref="AssetService"/> records in the specified date range for the specified assets</returns>
		List<AssetService> GetServiceHistoryByGroup(long groupId, DateTime from, DateTime to);

		/// <summary>Queries the service history of assets in the specified organisation, organisation subgroup, or site
		/// for <see cref="AssetService"/> records in the specified date range</summary>
		/// <param name="groupId">Identifies an organisation, organisation subgroup, or site to include in the query</param>
		/// <param name="from">Start of the date range to query</param>
		/// <param name="to">End of the date range to query</param>
		/// <returns>The task object representing the asynchronous operation</returns>
		Task<List<AssetService>> GetServiceHistoryByGroupAsync(long groupId, DateTime from, DateTime to);
	}
}
