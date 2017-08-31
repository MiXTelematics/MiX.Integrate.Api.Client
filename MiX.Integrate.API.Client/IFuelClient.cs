using MiX.Integrate.Api.Client.Base;
using MiX.Integrate.Shared.Entities.Fuel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiX.Integrate.Api.Client
{
  public interface IFuelClient : IBaseClient
	{
		Task<IList<FuelTransaction>> GetFuelByDateRangeForGroupAsync(long organisationId, DateTime from, DateTime to);
	  IList<FuelTransaction> GetFuelByDateRangeForGroup(long organisationId, DateTime from, DateTime to);
	}
}
