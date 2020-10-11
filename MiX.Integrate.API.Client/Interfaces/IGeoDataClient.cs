using System;
using System.Threading.Tasks;
using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Entities.GeoData;

namespace MiX.Integrate.API.Client
{
  public interface IGeoDataClient : IBaseClient
	{
		/// <summary>Gets geospatial data representing the movements of all assets in a specified group during a given period (max 24 hours)</summary>
		/// <param name="groupId">Identifier of the group</param>
		/// <param name="from">Start of date/time range</param>
		/// <param name="to">Start of date/time range</param>
		/// <param name="format">Format of the geospatial data</param>
		/// <returns>A <see cref="GeoDataFile"/> containing the requested data</returns>
		GeoDataFile GetAssetMovements(long groupId, DateTime from, DateTime to, GeoDataFormat format);

		/// <summary>Gets geospatial data representing the movements of all assets in a specified group during a given period (max 24 hours)
		/// as an asynchronous operation</summary>
		/// <param name="groupId">Identifier of the group</param>
		/// <param name="from">Start of date/time range</param>
		/// <param name="to">Start of date/time range</param>
		/// <param name="format">Format of the geospatial data</param>
		/// <returns>A <see cref="Task"/> representing the asynchronous operation</returns>
		Task<GeoDataFile> GetAssetMovementsAsync(long groupId, DateTime from, DateTime to, GeoDataFormat format);
	}
}
