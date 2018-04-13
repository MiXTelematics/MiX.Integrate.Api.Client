using MiX.Integrate.Api.Client.Base;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Fuel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiX.Integrate.Api.Client
{
	public class FuelClient : BaseClient, IFuelClient
	{
		public FuelClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public FuelClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

	  public async Task<IList<FuelTransaction>> GetFuelByDateRangeForGroupAsync(long organisationId, DateTime from, DateTime to)
    {
			IHttpRestRequest request = GetRequest(APIControllerRoutes.FUELCONTROLLER.GETFUELBYDATERANGEFORGROUP, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
      request.AddUrlSegment("from", from.ToString(DataFormats.DateTime_Format));
      request.AddUrlSegment("to", to.ToString(DataFormats.DateTime_Format));
			IHttpRestResponse<List<FuelTransaction>> response = await ExecuteAsync<List<FuelTransaction>>(request).ConfigureAwait(false);
			return response.Data;
		}

	  public IList<FuelTransaction> GetFuelByDateRangeForGroup(long organisationId, DateTime from, DateTime to)
    {
      IHttpRestRequest request = GetRequest(APIControllerRoutes.FUELCONTROLLER.GETFUELBYDATERANGEFORGROUP, HttpMethod.Get);
      request.AddUrlSegment("organisationId", organisationId.ToString());
      request.AddUrlSegment("from", from.ToString(DataFormats.DateTime_Format));
      request.AddUrlSegment("to", to.ToString(DataFormats.DateTime_Format));
      IHttpRestResponse<List<FuelTransaction>> response = Execute<List<FuelTransaction>>(request);
      return response.Data;
    }

		public async Task<IList<FuelInsertCarrier>> AddFuelTransactionsForGroupAsync(long organisationId, IList<FuelTransaction> transactions)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.FUELCONTROLLER.ADDFUELTRANSACTIONS, HttpMethod.Put);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddJsonBody(transactions);
			IHttpRestResponse<List<FuelInsertCarrier>> response = await ExecuteAsync<List<FuelInsertCarrier>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public IList<FuelInsertCarrier> AddFuelTransactionsForGroup(long organisationId, IList<FuelTransaction> transactions)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.FUELCONTROLLER.ADDFUELTRANSACTIONS, HttpMethod.Put);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddJsonBody(transactions);
			IHttpRestResponse<List<FuelInsertCarrier>> response = Execute<List<FuelInsertCarrier>>(request);
			return response.Data;
		}

	}
}
