using System.Collections.Generic;
using System.Threading.Tasks;
using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Entities.Customers;


namespace MiX.Integrate.API.Client
{
	public interface ICustomersClient : IBaseClient
	{

		/// <summary>Gets customers for an organisation</summary>
		/// <param name="organisationId">Identifier of the organisation to be queried</param>
		/// <returns>The <see cref="Customer"/> records associated with the specified organisation</returns>
		List<Customer> GetCustomers(long organisationId);

		/// <summary>Gets customers for an organisation as an asynchronous operation</summary>
		/// <param name="organisationId">Identifier of the organisation to be queried</param>
		/// <returns>A <see cref="T:System.Threading.Tasks.Task"/> representing the asynchronous operation</returns>
		Task<List<Customer>> GetCustomersAsync(long organisationId);

		/// <summary>Gets the delivery points associated with a customer</summary>
		/// <param name="organisationId">Identifier of the organisation to which the customer belongs</param>
		/// <param name="customerId">Identifier of the customer to be queried</param>
		/// <returns>The <see cref="DeliveryPoint"/> records associated with the specified customer</returns>
		List<DeliveryPoint> GetDeliveryPoints(long organisationId, long customerId);

		/// <summary>Gets the delivery points associated with a customer as an asynchronous operation</summary>
		/// <param name="organisationId">Identifier of the organisation to which the customer belongs</param>
		/// <param name="customerId">Identifier of the customer to be queried</param>
		/// <returns>A <see cref="T:System.Threading.Tasks.Task"/> representing the asynchronous operation</returns>
		Task<List<DeliveryPoint>> GetDeliveryPointsAsync(long organisationId, long customerId);


	}
}
