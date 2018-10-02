using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiX.Integrate.Api.Client.Base;
using MiX.Integrate.Shared.Entities.HosData;

namespace MiX.Integrate.API.Client
{
	public interface IHosDataClient : IBaseClient
	{
		List<HosViolation> GetHosViolations(long driverId, DateTime fromDateTime, DateTime toDateTime);
		Task<List<HosViolation>> GetHosViolationsAsync(long driverId, DateTime fromDateTime, DateTime toDateTime);
	}
}