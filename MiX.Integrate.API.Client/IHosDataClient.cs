using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiX.Integrate.Api.Client.Base;
using MiX.Integrate.Shared.Entities.Carriers;
using MiX.Integrate.Shared.Entities.HosData;

namespace MiX.Integrate.API.Client
{
	public interface IHosDataClient : IBaseClient
	{
		CreatedSinceResult<HosEvent> GetHosEventData(ParameterEntityType entityTypeId, List<long> entityIds, List<byte> eventTypeIds, DateTime fromDateTime, DateTime toDateTime);

		Task<CreatedSinceResult<HosEvent>> GetHosEventDataAsync(ParameterEntityType entityTypeId, List<long> entityIds, List<byte> eventTypeIds, DateTime fromDateTime, DateTime toDateTime);
	}
}