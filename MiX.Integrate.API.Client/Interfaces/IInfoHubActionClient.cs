using MiX.Integrate.API.Client.Base;
using System.Threading.Tasks;
using MiX.Integrate.Shared.Entities.Carriers;
using MiX.Integrate.Shared.Entities.InfoHub;

namespace MiX.Integrate.API.Client
{
	public interface IInfoHubActionClient : IBaseClient
	{
		/// <summary>Get info hub actions created for the specified organisation since the specified token time</summary>
		/// <param name="organisationId">Identifier of the organisation to be queried</param>
		/// <param name="sinceToken">Token denoting the "since" time for the query in "yyyyMMddHHmmssfff" format.
		/// This may not be more than than 7 days old, and is expressed in UTC.
		/// If no token is available, use the NEW keyword to default to the current time.
		/// Use the GetSinceToken property of the results for the next call to this method.</param>
		/// <param name="quantity">Number of records (up to 1000) to retrieve. Result may include more items than requested due to server-side quantisation constraints</param>
		/// <returns>A <see cref="CreatedSinceResult{ActiveEventAction}"/> containing the result of the call</returns>
		CreatedSinceResult<ActiveEventAction> GetActiveEventActionsCreatedSince(long organisationId, string sinceToken, int quantity);

		/// <summary>Get info hub actions created for the specified organisation since the specified token time, as an asynchronous operation</summary>
		/// <param name="organisationId">Identifier of the organisation to be queried</param>
		/// <param name="sinceToken">Token denoting the "since" time for the query in "yyyyMMddHHmmssfff" format.
		/// This may not be more than than 7 days old, and is expressed in UTC.
		/// If no token is available, use the NEW keyword to default to the current time.
		/// Use the GetSinceToken property of the results for the next call to this method.</param>
		/// <param name="quantity">Number of records (up to 1000) to retrieve. Result may include more items than requested due to server-side quantisation constraints</param>
		/// <returns>A <see cref="Task"/> representing the asynchronous operation</returns>
		Task<CreatedSinceResult<ActiveEventAction>> GetActiveEventActionsCreatedSinceAsync(long organisationId, string sinceToken, int quantity);
	}
}
