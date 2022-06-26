using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	/// <summary>
	/// <inheritdoc cref="ICustomersClient"/> 
	/// </summary>
	public class CustomersClient : BaseClient, ICustomersClient
	{
		public CustomersClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public CustomersClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public List<Customer> GetCustomers(long organisationId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.CustomersController.CUSTOMER_LIST_ADD_UPDATE, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			IHttpRestResponse<List<Customer>> response = Execute<List<Customer>>(request);
			return response.Data;
		}


		public async Task<List<Customer>> GetCustomersAsync(long organisationId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.CustomersController.CUSTOMER_LIST_ADD_UPDATE, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			IHttpRestResponse<List<Customer>> response = await ExecuteAsync<List<Customer>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public List<DeliveryPoint> GetDeliveryPoints(long organisationId, long customerId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.CustomersController.DELIVERYPOINT_LIST_ADD_UPDATE, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("customerId", customerId.ToString());
			IHttpRestResponse<List<DeliveryPoint>> response = Execute<List<DeliveryPoint>>(request);
			return response.Data;
		}


		public async Task<List<DeliveryPoint>> GetDeliveryPointsAsync(long organisationId, long customerId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.CustomersController.DELIVERYPOINT_LIST_ADD_UPDATE, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("customerId", customerId.ToString());
			IHttpRestResponse<List<DeliveryPoint>> response = await ExecuteAsync<List<DeliveryPoint>>(request).ConfigureAwait(false);
			return response.Data;
		}
	}
}
